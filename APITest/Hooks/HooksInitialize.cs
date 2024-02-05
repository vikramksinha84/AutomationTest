using AutomationTest.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using AutomationTest.PagesObject;
using OpenQA.Selenium.Chrome;

namespace AutomationTest.Hooks
{
    [Binding]
    public class HooksInitialize
    {
        public HooksInitialize() { }
  

        [BeforeTestRun]
        public static void TestRun()
        {
            //Initialize the global data like url ,time ets
        }



        [BeforeScenario]
        public void TestInitalize()
        {
            //method launch browser
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //Method to close the browser
        }


        [AfterTestRun]
        public static void TearDownReport()
        {
            //Clean up 
        }
    }
}
