using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using StellarAutomation.Helpers;
using System.Configuration;

namespace StellarAutomation.Pages
{
    public class BaseClass 
    {
        #region Variables

        private readonly string urlHomePage = "https://adkgroup:mydevsite@adkcw-wp.adkalpha.com/contact";

        private By acceptCoockiesButton => By.Id("onetrust-accept-btn-handler");

        #endregion


        public BaseClass()            
        {
        }


        #region Actions

        public void OpenHomePage()
        {

            Helper.OpenPage(urlHomePage);

        }

        public void AcceptCoockies()
        {
            Helper.ClickElement(acceptCoockiesButton);
        }

        

        #endregion


    }
}
