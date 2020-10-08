using SeleniumExtras.PageObjects;

namespace BBCAndLoremIpsumTest
{
    public static class Page
    {
        public static T GetPages<T>() where T : new()
        {
            var page = new T();
            PageFactory.InitElements(Browser.WebDriver, page);
            return page;
        }
    }
}
