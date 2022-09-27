using MailKit.Search;
using MailKit;
using MailKit.Net.Imap;
using MimeKit;
using System;
using System.Linq;
using HtmlAgilityPack;
using Polly;

namespace TestKaspersky
{
    public static class ImapClientUtils
    {
        public static string IsLinkInEmail(TestDataModel testdata)
        {
            using (var client = new ImapClient())
            {
                client.Connect("imap.gmail.com", 993, true);
                client.Authenticate(testdata.Username, GetDataUtils.GetConfigData("passwordIMAP"));               
                Policy.Timeout(TimeSpan.FromSeconds(5));
                var inbox = client.Inbox;                
                inbox.Open(FolderAccess.ReadWrite);

                var filters = SearchQuery.FromContains("kaspersky")
                .And(SearchQuery.NotSeen);
                var emails = inbox.Search(filters);                
                var emailsfilter = inbox.Fetch(emails, MessageSummaryItems.UniqueId | MessageSummaryItems.BodyStructure);
                
                string link = "";
                if (emailsfilter.Count() > 0)
                {
                    var lastemail = emailsfilter[emailsfilter.Count - 1];                    
                    if (lastemail.HtmlBody != null)
                    {
                        var html = inbox.GetBodyPart(lastemail.UniqueId, lastemail.HtmlBody);
                        string htmltext = ((TextPart)html).Text;
                        FindLinkInText(htmltext, testdata.Product, testdata.Os, out link);                        
                    }                    
                    client.Disconnect(true);
                }
                return link;
            }
        }  
        public static void FindLinkInText(string htmltext, string product, string os, out string findlink)
        {
            findlink = "";
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(htmltext);
            try
            {
                var nodeshref = document.DocumentNode
                    .Descendants("a")
                    .Where(node => node.Attributes.Contains("href")
                    && node.Attributes["title"].Value == product
                    && node.InnerText.Trim().Contains(os))
                    .Select(node => new
                    {
                        Text = node.InnerText.Trim(),
                        Link = node.GetAttributeValue("href", "").Trim()
                    });
                foreach (var href in nodeshref)
                {
                    findlink = href.Link;                    
                    break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static bool IsLinkContainsDowload(string linktext)
        {
            return linktext.Contains(GetDataUtils.GetConfigData("searchword"));
        }
    }
}
