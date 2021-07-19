using OpenQA.Selenium;

namespace VectorSolutionsTest
{
    public static class Locator
    {
        public static By FavoritesManagerFrame =
            By.Id("favorites-manager-iframe");

        public static By HomepageHeadlineText =
            By.XPath("//h1[@class='contentItem__title contentItem__title--hero contentItem__title--story']");

        public static By UserIcon =
            By.XPath("//li[@data-behavior='favorites_mgmt']");

        public static By AddFavoritesButton =
            By.XPath("//a[@class='button sm open-favs']");

        public static By FollowNFLButton =
            By.XPath("//h2[text()='NFL']//ancestor::li//descendant::button");

        public static By FavoritesSearchBar =
            By.XPath("//input[@class='TypeaheadInput TypeaheadInput--Controls TypeaheadInput--Controls-Single form__control']");

        public static By FollowGrizzliesButton =
            By.XPath("//h2[text()='Grizzlies']//ancestor::li//descendant::button");

        public static By CloseFavoritesWindow = 
            By.XPath("//*[@class='icon--color icon__svg']");

        public static By AddedFavoriteSport =
            By.CssSelector("a[class='fav-header'] > div[class='link-text']");

        public static By AddNFLAsFavorite =
            By.XPath("//li[text()='My Sports']//following-sibling::li//descendant::h2[text()='NFL']");
    }
}
