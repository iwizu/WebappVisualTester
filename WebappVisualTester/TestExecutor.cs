using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WebappVisualTester.Models;

namespace WebappVisualTester
{
    public class TestExecutor : IDisposable
    {
        readonly IProjectManager projectManager;
        readonly List<IWebDriver> drivers;
        readonly Test test;
        public TestExecutor(Test test, IProjectManager projectManager)
        {
            drivers = new List<IWebDriver>();
            this.test = test;
            this.projectManager = projectManager;
        }

        public string Start(List<ICommand> cmds,ChromeDriver driver)
        {
            StringBuilder s = new StringBuilder();
            if (driver == null)
            {
                driver = new ChromeDriver();
                drivers.Add(driver);
            }
            if (test!=null)
            {
                if (cmds == null)
                {
                    cmds = test.Commands.Where(i => !i.BelongsToCommandIndex.HasValue).OrderBy(i => i.OrderIndex).ToList();
                }
                foreach(var cmd in cmds)
                {
                    if (cmd._type.Contains(nameof(NavigateToUrlCommand)))
                    {
                        var d = cmd as NavigateToUrlCommand;
                        if(d!=null)
                        {
                            driver.Navigate().GoToUrl(d.Url);
                            s.AppendLine("Success: Navigate to URL - " + d.Url);
                            cmd.RunSuccessfuly = true;
                        }
                    }
                    else if (cmd._type.Contains(nameof(TakeScreenshotCommand)))
                    {
                        var d = cmd as TakeScreenshotCommand;
                        if (d != null)
                        {
                            s.AppendLine(GetScreenshot(d.OrderIndex,driver));
                            cmd.RunSuccessfuly = true;
                        }
                    }
                    else if (cmd._type.Contains(nameof(IfContainsStringCommand)))
                    {
                        var d = cmd as IfContainsStringCommand;
                        if (d != null && driver.PageSource.Contains(d.IfContainsString))
                        {
                            var subCommands = test.Commands.Where(i => i.BelongsToCommandIndex.HasValue
                                && i.BelongsToCommandIndex.Equals(d.Id))
                                .OrderBy(i => i.OrderIndex).ToList();
                            s.AppendLine(Start(subCommands, driver));
                            cmd.RunSuccessfuly = true;
                        }
                    }
                    else if (cmd._type.Contains(nameof(FillTextboxCommand)))
                    {
                        var d = cmd as FillTextboxCommand;
                        if (d != null)
                        {
                            IWebElement webElement = FindElement(driver, d.FindBy, d.FindByValue, d.Wait);
                            if (webElement != null)
                            {
                                if (d.ScrollToElement)
                                {
                                    Actions actions = new Actions(driver);
                                    actions.MoveToElement(webElement);
                                    actions.Perform();
                                }
                                webElement.SendKeys(d.Text);
                                cmd.RunSuccessfuly = true;
                                s.AppendLine("Success: send text: "+d.Text+" to element Found by " + d.FindBy + " : " + d.FindByValue + " , with " + (d.ScrollToElement ? "" : "no") + " scroll and wait=" + d.Wait.ToString());
                            }
                            else
                            {
                                s.AppendLine("Error: send text: " + d.Text + " to element Found by " + d.FindBy + " : " + d.FindByValue + " , with " + (d.ScrollToElement ? "" : "no") + " scroll and wait=" + d.Wait.ToString());
                            }                            
                        }
                    }
                    else if (cmd._type.Contains(nameof(ClickButtonCommand)))
                    {
                        var d = cmd as ClickButtonCommand;
                        if (d != null)
                        {
                            try
                            {
                                IWebElement webElement = FindElement(driver, d.FindBy, d.FindByValue,d.Wait);
                                if (webElement != null)
                                {
                                    if (d.ScrollToElement)
                                    {
                                        Actions actions = new Actions(driver);
                                        actions.MoveToElement(webElement);
                                        actions.Perform();
                                    }
                                    webElement.Click();
                                    cmd.RunSuccessfuly = true;
                                    s.AppendLine("Success: Click element Found by " + d.FindBy + " : " + d.FindByValue + " , with " + (d.ScrollToElement ? "" : "no") + " scroll and wait=" + d.Wait.ToString());
                                }
                                else
                                {
                                    s.AppendLine("Error: Click element Found by " + d.FindBy + " : " + d.FindByValue + " , with " + (d.ScrollToElement ? "" : "no") + " scroll and wait=" + d.Wait.ToString());
                                }                             
                            }
                            catch(Exception ex)
                            {
                                s.AppendLine("Error: Click Button - Exception:" + ex.ToString());
                            }                     
                        }
                    }
                    else if (cmd._type.Contains(nameof(SelectFromDropdownCommand)))
                    {
                        var d = cmd as SelectFromDropdownCommand;
                        if (d != null)
                        {
                            try
                            {                                
                                IWebElement webElement = FindElement(driver, d.FindBy, d.FindByValue, d.Wait);
                                if (webElement != null)
                                {
                                    if (d.ScrollToElement)
                                    {
                                        Actions actions = new Actions(driver);
                                        actions.MoveToElement(webElement);
                                        actions.Perform();
                                    }
                                    //create select element object 
                                    var selectElement = new SelectElement(webElement);

                                    if (d.SelectByTextValue.Equals("By Value"))
                                    {
                                        selectElement.SelectByValue(d.SelectedValue);
                                    }
                                    else
                                    {
                                        selectElement.SelectByText(d.SelectedValue);
                                    }
                                    cmd.RunSuccessfuly = true;
                                    s.AppendLine("Success: select "+ d.SelectByTextValue +": "+d.SelectedValue+ " element Found by " + d.FindBy + " : " + d.FindByValue + " , with " + (d.ScrollToElement ? "" : "no") + " scroll and wait=" + d.Wait.ToString());
                                }
                                else
                                {
                                    s.AppendLine("Error: select " + d.SelectByTextValue + ": " + d.SelectedValue + " element Found by " + d.FindBy + " : " + d.FindByValue + " , with " + (d.ScrollToElement ? "" : "no") + " scroll and wait=" + d.Wait.ToString());
                                }
                            }
                            catch (Exception ex)
                            {
                                s.AppendLine("Error: Exception:" + ex.ToString());
                            }
                        }
                    }
                }
            }
            return s.ToString();
        }

        private IWebElement FindElement(ChromeDriver driver, string findBy,string findByValue,int wait)
        {
            /*
            if (findBy == "Id" && (findByValue.Contains("-") || findByValue.Contains(".")))
            {
                findBy = "XPath";
                findByValue = "//*[@id=\""+ findByValue + "\"]";
            }
            */
                By by;
            if(findBy.Equals("Class"))
            {
                by = By.ClassName(findByValue);
            }
            else if (findBy.Equals("Css selector"))
            {
                by = By.CssSelector(findByValue);
            }
            else if (findBy.Equals("Id"))
            {
                by = By.Id(findByValue);
            }
            else if (findBy.Equals("LinkText"))
            {
                by = By.LinkText(findByValue);
            }
            else if (findBy.Equals("Name"))
            {
                by = By.Name(findByValue);
            }
            else if (findBy.Equals("PartialLinkText"))
            {
                by = By.PartialLinkText(findByValue);
            }
            else if (findBy.Equals("TagName"))
            {
                by = By.TagName(findByValue);
            }
            else if (findBy.Equals("XPath"))
            {
                by = By.XPath(findByValue);
            }
            else
            {
                by = By.CssSelector(findByValue);
            }

            return FindElement(driver, by, wait);
        }

        public static IWebElement FindElement(IWebDriver driver, By by, int timeoutInSeconds)
        {
            int size = driver.FindElements(By.TagName("iframe")).Count();

            try
            {
                if (timeoutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                    return wait.Until(drv => drv.FindElement(by));
                }

                if (driver.FindElements(by).Count > 0)
                {
                    return driver.FindElement(by);
                }
                for (int i = 0; i < size; i++)
                {
                    driver.SwitchTo().Frame(i);
                    if (driver.FindElements(by).Count > 0)
                    {
                        return driver.FindElement(by);
                    }
                    driver.SwitchTo().DefaultContent();

                }

                return driver.FindElement(by);
            }
            catch {
                return null;
            }          
        }
        private string GetScreenshot(int actionNum, IWebDriver driver)
        {
            try
            {
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                string testFolder=Global.GetTestFolderPath(test, projectManager.Project);
                string imagesFolder = testFolder + "\\Images";
                if (!Directory.Exists(imagesFolder))
                    Directory.CreateDirectory(imagesFolder);
                ss.SaveAsFile(imagesFolder + "\\Image" + actionNum + ".png", ScreenshotImageFormat.Png);
                return "Success: Screenshot - " + "Image" + actionNum + ".png";
            }
            catch(Exception ex)
            {
                return "Error: Screenshot - " + ex.ToString();
            }
        }

        public void Dispose()
        {
            foreach (var driver in drivers)
            {
                driver.Quit();
                driver.Dispose();
            }
        }
    

}
}
