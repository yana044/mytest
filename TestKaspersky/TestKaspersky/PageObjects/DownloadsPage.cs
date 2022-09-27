using Aquality.Selenium.Browsers;
using OpenQA.Selenium;
using Aquality.Selenium.Elements.Interfaces;

namespace TestKaspersky
{
    public class DownloadsPage
    {
        public void DownloadClick(string os, string product)
        {
            var osname = AqualityServices.Get<IElementFactory>().GetTextBox(By.XPath($"//div[@data-at-selector='osName' and contains(text(), '{os}')]"), "Windows OS submenu");
            osname.WaitAndClick();
            var prodcard = AqualityServices.Get<IElementFactory>().GetTextBox(By.XPath($"//div[@data-at-selector='productName' and contains(text(), '{product}')]//ancestor::div[@data-at-selector= 'downloadApplicationCard']"), "Download Application Card");
            string productId = prodcard.GetAttribute("data-product-id");            
            var downloadbtn = AqualityServices.Get<IElementFactory>().GetTextBox(By.XPath($"//div[@data-product-id='{productId}']//span[contains(text(), 'Скачать')]"), $"'{product}' Download Button"); 
            downloadbtn.WaitAndClick();
        }
    }
}
