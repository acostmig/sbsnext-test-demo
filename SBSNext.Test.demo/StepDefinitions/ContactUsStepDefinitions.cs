using System;
using TechTalk.SpecFlow;

namespace SBSNext.Test.demo.StepDefinitions
{
    [Binding]
    public class ContactUsStepDefinitions
    {
        IPage Page { get; set; }
        SBSNextBasePage SBSNextBasePage { get; set; }

        public ContactUsStepDefinitions(IPage page, SBSNextBasePage SBSNextPage)
        {
            Page = page;
            SBSNextBasePage= SBSNextPage;
        }
        [Given(@"contact us modal is open and empty")]
        public async Task GivenContactUsModalIsOpenAndEmpty()
        {
            //
            // 1.) check if contact us modal is open
            // 2.) if not open, open it
            // 3.) load all input fields
            // 4.) empty all input fields
            //

            //check if contact us modal is open
            var contactUsModal = this.SBSNextBasePage.ContactUsModal;
            var ModalIsOpen = await contactUsModal.IsVisibleAsync();

            //if not open, open it
            if(!ModalIsOpen)
                await this.Page.GetField("Contact Us").ClickAsync();

            //load all input elements
            var fields = await contactUsModal.Locator($"xpath=//*[self::input[@type!='submit'] or self::textarea]").AllAsync();

            //empty all input fields
            foreach(var field in fields)
            {
                await field.SetValueAsync("");
            }

        }


        [When(@"user enters the following field values")]
        public async Task WhenUserEntersTheFollowingFieldValues(Table table)
        {
            foreach (var row in table.Rows)
            {
                var fieldName = row["FieldName"];
                var value = row["Value"];
                await this.Page.GetField(fieldName).SetValueAsync(value);

            }
        }

        [Then(@"contact us request should be sent")]
        public async Task ThenContactUsRequestShouldBeSent()
        {
            await this.Page.GetByText("Sent!").AssertIsVissible();
            await this.SBSNextBasePage.ContactUsModal.AssertNotVissible();
        }

        [Then(@"user should be presented with '([^']*)'")]
        public async Task ThenUserShouldBePresentedWith(string validationMsg)
        {
            await this.Page.GetByText(validationMsg).AssertIsVissible();
            await this.Page.ScreenshotAsync(new PageScreenshotOptions { Path = $"screenshots/{validationMsg}.png" });
        }
    }
}
