using Aquality.Selenium.Browsers;
using Aquality.Selenium.Core.Elements;
using OpenQA.Selenium;
using Aquality.Selenium.Elements.Interfaces;

namespace TestKaspersky
{
    public class SendToEmailForm
    {
        public string GetEmailFromSendForm()
        {
            var otherDownloads = AqualityServices.Get<IElementFactory>().GetButton(By.XPath("//button[@data-at-selector='otherDownloads']"), "Other Downloads");
            otherDownloads.WaitAndClick();
            var sendToMe = AqualityServices.Get<IElementFactory>().GetButton(By.XPath("//button[@data-at-selector='sendToMe']"), "Send to me button");
            sendToMe.WaitAndClick();
            var emailInput = AqualityServices.Get<IElementFactory>().GetTextBox(By.XPath("//input[@data-at-selector='emailInput']"), "Email input field", state: ElementState.Displayed);
            return emailInput.Value.ToString();
        }
        public void SendBtnClick()
        {            
            var sendbtn = AqualityServices.Get<IElementFactory>().GetButton(By.XPath("//button[@data-at-selector='installerSendSelfBtn']"), "Send Button");
            sendbtn.WaitAndClick();
            var okbtn = AqualityServices.Get<IElementFactory>().GetButton(By.XPath("//button[@data-at-selector='successfullySentOkBtn']"), "OK Button");
            okbtn.State.WaitForClickable();
        }
    }
}
