using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibs.Utils;
using OpenQA.Selenium;


namespace Guru99Aplication.Pages
{
    public class HomePage : BasePage
    {

        private readonly IWebDriver driver;

        private By locatorFoNewCustomer => By.LinkText("New Customer");
        private IWebElement newCutomer => driver.FindElement(locatorFoNewCustomer);

        private By locatorFoNewAccount => By.LinkText("New Account");
        private IWebElement newAccount => driver.FindElement(locatorFoNewAccount);

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


        private IWebElement customerIdTextbox => driver.FindElement(By.Name("cusid"));

        private IWebElement accountTypeDropdown => driver.FindElement(By.Name("selaccount"));

        private IWebElement initialDepositTextbox => driver.FindElement(By.Name("inideposit"));

        private IWebElement submitButtonOnNewAccount => driver.FindElement(By.Name("button2"));

        private IWebElement logout => driver.FindElement(By.LinkText("Log out"));

        private IWebElement customerIdInCustomerTable => driver.FindElement(By.XPath("//table[@id='customer']//td[text()='Customer ID']//following-sibling::td"));

        public HomePage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public void AddNewCustomer()
        {
            elementControl.ClickElement(newCutomer);

            elementControl.SetText(customerName, "saurabh Dhingra");
            elementControl.ClickElement(femaleGender);

            elementControl.SetText(dateOfBirth, "06/21/1989");
            elementControl.SetText(address, "No 12 Gurgaon");
            elementControl.SetText(city, "Gurgaon");
            elementControl.SetText(state, "Haryana");
            elementControl.SetText(pinnunber, "231231");
            elementControl.SetText(mobileNumber, "42364273");

            DateTime time = DateTime.Now;

            string uniqueEmailId = $"{time.ToString()}acv@abc.com";

            elementControl.SetText(emailId, uniqueEmailId);

            elementControl.SetText(password, "Pro@124");

            elementControl.ClickElement(submitButton);
        }

        public string GetCustomerId()
        {

            return elementControl.GetText(customerIdInCustomerTable);

        }

        public void AddNewAccount(string customerId, string accountType, string initialDeposit)
        {

            int xLocation = elementControl.GetXLocation(newAccount);

            int yLocation = elementControl.GetYLocation(newAccount);

            jsControl.ScrollDown(xLocation, yLocation);

            WaitUtils.WaitTillElementVisible(driver, locatorFoNewAccount, 10);

            elementControl.ClickElement(newAccount);

            elementControl.SetText(customerIdTextbox, customerId);

            dropdownControl.SelectViaVisibleText(accountTypeDropdown, accountType);

            elementControl.SetText(initialDepositTextbox, initialDeposit);

            elementControl.ClickElement(submitButtonOnNewAccount);


        }

        public void LogOut()
        {
            elementControl.ClickElement(logout);

            alertControl.AcceptAlert();
        }
    }
}
