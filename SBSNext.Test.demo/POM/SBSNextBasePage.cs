using SBSNext.Test.Drivers;

namespace SBSNext.Test.demo.POM
{
    public class SBSNextBasePage
    {
        public IPage Page { get; set; }
        public SBSNextBasePage(IPage page)
        {
            this.Page= page;
        }
        
        public ILocator Slogan => Page.Locator("xpath=//h1[normalize-space()=\"Let's push Innovation with Industry-Leading practices.\"]");

        public ILocator ContactUsModal => Page.Locator("xpath=//ngb-modal-window[.//*[text()='Get In Touch']]");

        public ILocator ContactUsAllFields => ContactUsModal.Locator($"xpath=//*[self::input[@type!='submit'] or self::textarea]");
    }
}
