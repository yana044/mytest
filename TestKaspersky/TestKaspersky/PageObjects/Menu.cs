using Aquality.Selenium.Browsers;
using OpenQA.Selenium;
using Aquality.Selenium.Elements.Interfaces;

namespace TestKaspersky
{
    public class Menu
    {
        public void DownloadsMenuClick()
        {            
            var downloadsmenu = AqualityServices.Get<IElementFactory>().GetButton(By.XPath("//a[@data-at-menu='Downloads']"), "Downloads Menu");
            downloadsmenu.WaitAndClick();
        }
    }
}
