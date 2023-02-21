using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationAssignment
{
    internal class FlipkartFlow
    {
        static void Main(string[] args)
        {
            // Open browser and navigate to flipkart.com
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.flipkart.com/");

            // Close the login pop-up
            IWebElement close = driver.FindElement(By.XPath("//script[@id='omni_script']/following-sibling::div/div/div/button"));
            close.Click();

            // Locate the search box and type "ipad"
            IWebElement searchBox = driver.FindElement(By.Name("q"));

            searchBox.SendKeys("ipad");
            // searchBox.SendKeys(Keys.Return);


            IWebElement suggestion = driver.FindElement(By.XPath("//input[@name='q']/following::ul/li"));
            suggestion.Click();

            // Select a product and add to cart

            IWebElement product = driver.FindElement(By.ClassName("_2kHMtA"));
            product.Click();

            driver.SwitchTo().Window(driver.WindowHandles[1]);

            IWebElement addToCart = driver.FindElement(By.XPath("//button[text()='Add to cart']"));
            addToCart.Click();

            // Checkout and place the order

            IWebElement goToCart = driver.FindElement(By.XPath("//a[contains(@href, 'viewcart')]"));
            goToCart.Click();
            IWebElement placeOrder = driver.FindElement(By.XPath("//*[text()='Place Order']"));
            placeOrder.Click();

            // Fill in random phone number
            IWebElement phoneBox = driver.FindElement(By.XPath("//input[@type='text']"));

            Random random = new Random();
            string phone = "+91";
            for (int i = 0; i < 10; i++)
                phone = phone + random.Next(0, 9).ToString();
            phoneBox.SendKeys(phone);
            Thread.Sleep(5000);
            driver.Quit();



        }
    }
}
