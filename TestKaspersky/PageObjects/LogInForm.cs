using OpenQA.Selenium;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;

namespace TestKaspersky
{
    public class LogInForm : Form
    {
        private ITextBox emailTextBox => ElementFactory.GetTextBox(By.XPath("//input[@data-at-selector='emailInput']"), "Email");
        private ITextBox passwordTextBox => ElementFactory.GetTextBox(By.XPath("//input[@data-at-selector='passwordInput']"), "Password");
        private IButton singinbtn => ElementFactory.GetButton(By.XPath("//button[@data-at-selector='welcomeSignInBtn']"), "SignIn Button");

        public LogInForm() : base(By.XPath("//form[@data-at-selector='signInContent']"), "Sign In Form")
        {
        }

        public void LogIn(string username, string password)
        {
            emailTextBox.State.WaitForEnabled();
            emailTextBox.Type(username);
            passwordTextBox.State.WaitForEnabled();
            passwordTextBox.Type(password);
            singinbtn.State.WaitForClickable();
            singinbtn.ClickAndWait();
        }
    }
}
