using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using Project1.Pages;

namespace Project1.StepDefinitions
{
    [Binding]
    public class BaseStepDefinitions
    {
        public static IWebDriver Driver { get; set; }

        protected T Use<T>()
        {
            return (T)ScenarioContext.Current[typeof(T).Name];
        }

        protected void Create<T>(T page)
        {
            ScenarioContext.Current[typeof(T).Name] = page;
        }
    }
}
