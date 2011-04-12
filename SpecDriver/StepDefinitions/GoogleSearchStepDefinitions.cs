namespace Project1.StepDefinitions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TechTalk.SpecFlow;
    using NUnit.Framework;
    using Project1.Pages;
    
    [Binding]
    public class GoogleSearchStepDefinitions : BaseStepDefinitions
    {

        [Given(@"I am on the Google Home Page")]
        public void GivenIAmOnTheGoogleHomePage()
        {
            Create(new GoogleHomePageModel(Driver));
            Assert.AreEqual("Google", Use<GoogleHomePageModel>().Title);
        }

        [When(@"I search for ""(.+)""")]
        public void WhenISearchForSomething(string searchTerm)
        {
            Create(Use<GoogleHomePageModel>().Search(searchTerm));
        }

        [When(@"I search for a ridiculously small number of results")]
        public void WhenISearchForARidiculouslySmallNumberOfResults()
        {
            Create(Use<GoogleHomePageModel>().Search("macrocryoglobulinemia marvel"));
        }

        [When(@"I convert (.+)")]
        public void WhenIConvertSomething(string ConversionString)
        {
            Create(Use<GoogleHomePageModel>().Search("convert " + ConversionString));
        }

        [Then(@"I should see at most ([\d,]+) results")]
        public void ThenIShouldSeeAtMostNumberOfResults(string expMaxNumberResults)
        {
            expMaxNumberResults = expMaxNumberResults.Replace(",", "");
            Assert.LessOrEqual(Convert.ToInt32(Use<GoogleSearchResultsPageModel>().NumberOfResults), Convert.ToInt32(expMaxNumberResults));
        }

        [Then(@"I should see at least ([\d,]+) results")]
        public void ThenIShouldSeeAtLeastNumberOfResults(string expMinNumberResults)
        {
            expMinNumberResults = expMinNumberResults.Replace(",", "");
            Assert.GreaterOrEqual(Convert.ToInt32(Use<GoogleSearchResultsPageModel>().NumberOfResults), Convert.ToInt32(expMinNumberResults));
        }

        [Then(@"I should see the conversion result ""(.+)""")]
        public void ThenIShouldSeeTheConversionResult(string expectedConversionResult)
        {
            Assert.AreEqual(expectedConversionResult, Use<GoogleSearchResultsPageModel>().ConversionResult);
        }
    }
}