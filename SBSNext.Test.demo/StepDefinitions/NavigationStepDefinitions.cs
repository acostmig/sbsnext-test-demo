using SBSNext.Test.Drivers;
using SBSNext.Test.Extensions;
using System;
using TechTalk.SpecFlow;

namespace SBSNext.Test.demo.StepDefinitions
{
    [Binding]
    public class NavigationStepDefinitions
    {
        IPage Page { get; set; }
        SBSNextBasePage SBSNextBasePage { get; set; }
        Driver Driver { get; set; } 

        public NavigationStepDefinitions(IPage page, SBSNextBasePage sbsnextPage, Driver driver)
        {
            this.Page= page;
            this.SBSNextBasePage= sbsnextPage;
            this.Driver= driver;
        }

        [Given(@"user landed in SBSNext\.com")]
        public async Task GivenUserLandedInSBSNext_Com()
        {
            await this.Page.GotoAsync("https://sbsnext.com", new PageGotoOptions { Timeout=60000});
        }



        [Then(@"user should be on landing page")]
        public async Task ThenUserShouldBeOnLandingPage()
        {
            this.Page.Url.Should().Be("https://sbsnext.com/landing");
            await this.SBSNextBasePage.Slogan.AssertIsVissible();
            await this.Page.GetField("Get Started").AssertIsVissible();
            await this.Page.GetField("Contact Us").AssertIsVissible();
        }

        [When(@"user clicks on ""([^""]*)""")]
        public async Task WhenUserClicksOn(string identifier)
        {
            Thread.Sleep(5000);
            await this.Page.GetField(identifier).ClickAsync();
        }



    }
}
