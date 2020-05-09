using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Guru99Aplication.Pages
{
    public class HomePage : BasePage
    {

        private readonly IWebDriver driver;

        private IWebElement newCutomer => driver.FindElement(By.LinkText("New Customer"));

        private IWebElement customerName => driver.FindElement(By.Name("name"));
        private IWebElement maleGender => driver.FindElement(By.XPath("//input[@value='m']"));

        private IWebElement femaleGender => driver.FindElement(By.XPath("//input[@value='f']"));

        private IWebElement dateOfBirth => driver.FindElement(By.Id("dob"));
        private IWebElement address => driver.FindElement(By.Name("addr"));
        private IWebElement city => driver.FindElement(By.Name("city"));
        private IWebElement state => driver.FindElement(By.Name("state"));
        private IWebElement pinnunber => driver.FindElement(By.Name("pinno"));
        private IWebElement mobileNumber => driver.FindElement(By.Name("telephoneno"));
        private IWebElement emailId => driver.FindElement(By.Name("emailid"));
        private IWebElement password => driver.FindElement(By.Name("password"));

        private IWebElement submitButton => driver.FindElement(By.XPath("//input[@value='Submit']"));

        private IWebElement logout => driver.FindElement(By.LinkText("Log out"));

        public HomePage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public void AddNewCustomer()
        {
            elementControl.SetText(customerName, "saurabh Dhingra");

        }

        public void LogOut()
        {
            elementControl.ClickElement(logout);

            alertControl.AcceptAlert();
        }
    }
}
