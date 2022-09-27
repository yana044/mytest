using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using OpenQA.Selenium;

namespace TestKaspersky
{
    public class LogInForm
    {
        private IButton singinbtn = AqualityServices.Get<IElementFactory>().GetButton(By.XPath("//button[@data-at-selector='welcomeSignInBtn']"), "SignIn Button");
        
        public void LogIn(string username, string password)
        {
            var emailTextBox = AqualityServices.Get<IElementFactory>().GetTextBox(By.XPath("//input[@data-at-selector='emailInput']"), "Email");
            emailTextBox.State.WaitForDisplayed();
            emailTextBox.Type(username);
            var passwordTextBox = AqualityServices.Get<IElementFactory>().GetTextBox(By.XPath("//input[@data-at-selector='passwordInput']"), "Password");
            passwordTextBox.State.WaitForDisplayed();
            passwordTextBox.Type(password);
            singinbtn.State.WaitForClickable();
            singinbtn.ClickAndWait();
        }
        public bool IsLogInFormDisplayed()
        {
            return singinbtn.State.IsDisplayed;
        }
    }
}
