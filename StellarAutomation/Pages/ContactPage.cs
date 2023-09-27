using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using StellarAutomation.Helpers;

namespace StellarAutomation.Pages
{
    public class ContactPage 
    {
        
        public ContactPage() 
        {
        }

        #region Locators
        private By firstNameTxt => By.Id("firstname");

        private By lastNameTxt => By.Id("lastname");

        private By workEmailTxt => By.Id("email");

        private By companyNameTxt => By.Id("company");

        private By phoneNumberTxt => By.Id("phone");

        private By messageTxt => By.Id("message");

        private By submitButton => By.XPath("//button[@type='submit']");

        #endregion


        public void InputFirstName(string firstname)
        {
            Helper.ClearFieldAndSentKeys(firstNameTxt, firstname);
        }

        public void InputLastName(string lastname)
        {
            Helper.ClearFieldAndSentKeys(lastNameTxt, lastname);
        }

        public void InputWorkEmail(string workEmail)
        {
            Helper.ClearFieldAndSentKeys(workEmailTxt, workEmail);
        }

        public void InputCompanyName(string companyName)
        {
            Helper.ClearFieldAndSentKeys(companyNameTxt, companyName);
        }

        public void InputPhoneNumber(string phoneNumber)
        {
            Helper.ClearFieldAndSentKeys(phoneNumberTxt, phoneNumber);
        }

        public void InputMessage(string message)
        {
            Helper.ClearFieldAndSentKeys(messageTxt, message);
        }

        public void ClickLoginButton()
        {
            Helper.ClickElement(submitButton);
        }
        
    }
}
