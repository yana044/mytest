using Aquality.Selenium.Browsers;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;

namespace TestKaspersky
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            AqualityServices.Browser.Maximize();
            AqualityServices.Browser.GoTo(GetDataUtils.GetConfigData("url"));
            AqualityServices.Browser.WaitForPageToLoad();
        }

        [Test]
        [TestCaseSource("GetTestData")]
        public void Test1(TestDataModel testdata)
        {
            LogInForm loginfrm = new LogInForm();
            loginfrm.LogIn(testdata.Username, testdata.Password);
            Assert.IsFalse(loginfrm.IsLogInFormDisplayed(), "Authorization failed");
            Menu menu = new Menu();
            menu.DownloadsMenuClick();
            DownloadsPage dwnldpage = new DownloadsPage();
            dwnldpage.DownloadClick(testdata.Os, testdata.Product);
            SendToEmailForm sendToEmailForm = new SendToEmailForm();
            string email = sendToEmailForm.GetEmailFromSendForm();
            Assert.AreEqual(testdata.Username, email, "The email is NOT displayed or NOT equal current user");
            sendToEmailForm.SendBtnClick();
            string linkinEmail = ImapClientUtils.IsLinkInEmail(testdata);
            Assert.IsTrue(linkinEmail != "", "Link is NOT received in the mail");
            string expextedword = GetDataUtils.GetConfigData("searchword");
            Assert.IsTrue(linkinEmail.Contains(expextedword), $"Link does NOT contains '{expextedword}'");
        }
        public static IEnumerable<TestDataModel> GetTestData()
        {
            string objectJsonFile = File.ReadAllText("testDataDDT.json");
            List<TestDataModel> testdata = JsonConvert.DeserializeObject<List<TestDataModel>>(objectJsonFile);
            foreach (TestDataModel product in testdata)
            {
                yield return product;
            }
        }
        [TearDown]
        public void CleanUp()
        {
            AqualityServices.Browser.Quit();
        }
    }
}