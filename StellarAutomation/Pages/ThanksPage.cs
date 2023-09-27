using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using StellarAutomation.Helpers;
using Shouldly;

namespace StellarAutomation.Pages
{
    public class ThanksPage
    {

        private string messageThanks = "Thanks for throwing us a bone.";

        public void VerifyMessageThanksIsDisplayed()
        {
            By messageThanksLabel = By.XPath($"//div[@class='c-split-content__text']//h2[text()='{messageThanks}']");
            Helper.IsElementVisible(messageThanksLabel).ShouldBeTrue();
        }
    }
}
