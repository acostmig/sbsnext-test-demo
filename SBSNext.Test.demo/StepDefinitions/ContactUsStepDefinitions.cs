using System;
using TechTalk.SpecFlow;

namespace SBSNext.Test.demo.StepDefinitions
{
    [Binding]
    public class ContactUsStepDefinitions
    {
        IPage Page { get; set; }
        public ContactUsStepDefinitions(IPage page)
        {
            Page = page;
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
        }

        [Then(@"user should be presented with '([^']*)'")]
        public async Task ThenUserShouldBePresentedWith(string validationMsg)
        {
            await this.Page.GetByText(validationMsg).AssertIsVissible();
        }
    }
}
