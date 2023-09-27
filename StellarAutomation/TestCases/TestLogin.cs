using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StellarAutomation.Pages;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using StellarAutomation.Helpers;

namespace StellarAutomation.TestCases
{
    [TestFixture]
    public class TestLogin
    {
        private readonly BaseClass _baseClass;
        private readonly ContactPage _contactPage;
        private readonly ThanksPage _thanksPage;

        public TestLogin()
        {

            _baseClass = new BaseClass();
            _contactPage = new ContactPage();
            _thanksPage = new ThanksPage();
        }


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _baseClass.OpenHomePage();
            _baseClass.AcceptCoockies();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Helper.DisposeSession();
        }

        [Test]
        public void SuccessfullyLogin()
        {

            _contactPage.InputFirstName("Edier");
            _contactPage.InputLastName("Camacho");
            _contactPage.InputWorkEmail("test@test.com");
            _contactPage.InputCompanyName("Stellar");
            _contactPage.InputPhoneNumber("5595702");
            _contactPage.InputMessage("This is a test case automated");
            _contactPage.ClickLoginButton();
            _thanksPage.VerifyMessageThanksIsDisplayed();
        }

    }
}