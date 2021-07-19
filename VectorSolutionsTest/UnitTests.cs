using NUnit.Framework;
using System;

namespace VectorSolutionsTest
{
    class UnitTests
    {
        [SetUp]
        public void StartBrowser()
        {
            SeleniumDriver.StartBrowser();

            //Assigns the Selenium Driver URL to the ESPN homepage
            SeleniumDriver.Driver.Url = "https://www.espn.com";
        }

        //This unit test navigates to the ESPN homepage, and scrolls to the headline text.
        //It then takes a screenshot and prints the headline text to a .txt file.
        //Both the .png file and .txt file can be found on your desktop.
        //WARNING: This unit test will fail if a headline is not present on the page (e.g. during the middle of a game)
        [Test]
        public void SaveHeadline()
        {
            //Finds the headline text on the homepage and scrolls to it
            SeleniumActions.Scroll(Locator.HomepageHeadlineText);

            //Takes screenshot and assigns it to a file called Screenshot.png
            SeleniumActions.Screenshot("Screenshot");

            //Writes the text from element to a file called Headline.txt
            SeleniumActions.SaveTextToFile(Locator.HomepageHeadlineText, "Headline");
        }

        //This unit test navigates to the ESPN homepage, and clicks on the user icon.
        //It then clicks the "add favorites" button, and follows a suggested sport (NFL).
        [Test]
        public void AddFavoriteSport()
        {
            //Clicks on the user icon
            SeleniumActions.Click(Locator.UserIcon, TimeSpan.FromSeconds(10));

            //Clicks on the "Add Favorites" button
            SeleniumActions.Click(Locator.AddFavoritesButton, TimeSpan.FromSeconds(10));

            //Switches to the default frame (this was necessary prior to switching to the favorites window iframe)
            SeleniumDriver.Driver.SwitchTo().DefaultContent();

            //Switches to the favorites window iframe
            SeleniumActions.SwitchToFrame(Locator.FavoritesManagerFrame, TimeSpan.FromSeconds(10));

            //Ensure that NFL is visible prior to clicking (in case website is running slow)
            bool isvisible = SeleniumActions.IsElementVisible(Locator.FollowNFLButton, TimeSpan.FromSeconds(10));

            if (isvisible)
            {
                //Clicks on the "Follow" button for the NFL
                SeleniumActions.Click(Locator.FollowNFLButton, TimeSpan.FromSeconds(10));
            }

            //Verifies that NFL was added as a favorite
            Assert.That(SeleniumActions.IsElementVisible(Locator.AddNFLAsFavorite, TimeSpan.FromSeconds(10)));
        }

        //(Bonus Test) This unit test navigates to the ESPN homepage, and clicks on the user icon.
        //It then clicks the "add favorites" button, and types in a team name (Memphis Grizzlies).
        //The team is followed, and then a verification is performed to ensure the team was successfully added as a favorite.
        [Test]
        public void AddFavoriteTeam()
        {
            //Clicks on the user icon
            SeleniumActions.Click(Locator.UserIcon, TimeSpan.FromSeconds(10));

            //Clicks on the "Add Favorites" button
            SeleniumActions.Click(Locator.AddFavoritesButton, TimeSpan.FromSeconds(10));

            //Switches to the default frame (this was necessary prior to switching to the favorites window iframe)
            SeleniumDriver.Driver.SwitchTo().DefaultContent();

            //Switches to the favorites window iframe
            SeleniumActions.SwitchToFrame(Locator.FavoritesManagerFrame, TimeSpan.FromSeconds(10));

            //Clicks on the favorites search bar and types in "Memphis Grizzlies"
            SeleniumActions.Type(Locator.FavoritesSearchBar, "Memphis Grizzlies", TimeSpan.FromSeconds(10));

            //Ensure the Grizzlies button is visible prior to clicking (in case website is running slow)
            bool isvisible = SeleniumActions.IsElementVisible(Locator.FollowGrizzliesButton, TimeSpan.FromSeconds(10));

            if (isvisible)
            {
                //Clicks on the "Follow" button for the Memphis Grizzlies
                SeleniumActions.Click(Locator.FollowGrizzliesButton, TimeSpan.FromSeconds(10));
            }

            //Closes out of the favorites window
            SeleniumActions.Click(Locator.CloseFavoritesWindow, TimeSpan.FromSeconds(10));

            //Clicks on the user icon
            SeleniumActions.Click(Locator.UserIcon, TimeSpan.FromSeconds(20));

            //Verifies that the team "Memphis Grizzlies" is present as a favorite
            //If Memphis Grizzlies is not present as a favorite, throw an exception
            Assert.That(SeleniumActions.GetText(Locator.AddedFavoriteSport, TimeSpan.FromSeconds(10)).Contains("Memphis Grizzlies", StringComparison.OrdinalIgnoreCase), "Memphis Grizzlies is not present as a favorite");
        }

        [TearDown]
        public void CloseBrowser()
        {
            SeleniumDriver.Driver.Quit();
        }
    }
}