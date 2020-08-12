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
        //private readonly IWebDriver _driver;
        IProjectManager projectManager;
        List<IWebDriver> drivers;
        Test test;
        public TestExecutor(Test test, IProjectManager projectManager)
        {
            drivers = new List<IWebDriver>();
            this.test = test;
            this.projectManager = projectManager;
        }

        public string Start(List<Command> cmds,ChromeDriver driver)
        {
            StringBuilder s = new StringBuilder();
            if (driver == null)
            {
                driver = new ChromeDriver();
                drivers.Add(driver);
            }
            if (test!=null)
            {
                if(cmds==null)
                cmds= test.commands.Where(i=>!i.BelongsToCommandIndex.HasValue).OrderBy(i => i.OrderIndex).ToList();
                foreach(var cmd in cmds)
                {
                    if (cmd._type.Contains(nameof(NavigateToUrlCommand)))
                    {
                        var d = cmd as NavigateToUrlCommand;
                        if(d!=null)
                        {
                            driver.Navigate().GoToUrl(d.Url);
                            s.AppendLine("Success: Navigate to URL - " + d.Url);
                        }
                    }
                    else if (cmd._type.Contains(nameof(TakeScreenshotCommand)))
                    {
                        var d = cmd as TakeScreenshotCommand;
                        if (d != null)
                        {
                            s.AppendLine(GetScreenshot(d.OrderIndex,driver));
                        }
                    }
                    else if (cmd._type.Contains(nameof(IfContainsStringCommand)))
                    {
                        var d = cmd as IfContainsStringCommand;
                        if (d != null)
                        {
                            if (driver.PageSource.Contains(d.IfContainsString))
                            {
                                var subCommands = test.commands.Where(i => i.BelongsToCommandIndex.HasValue
                                    && i.BelongsToCommandIndex.Equals(d.OrderIndex))
                                    .OrderBy(i => i.OrderIndex).ToList();
                               s.AppendLine(Start(subCommands,driver));
                            }
                        }
                    }
                    else if (cmd._type.Contains(nameof(FillTextboxCommand)))
                    {
                        var d = cmd as FillTextboxCommand;
                        if (d != null)
                        {
                            if (!string.IsNullOrEmpty(d.Id))
                            {
                                var input = driver.FindElement(By.XPath("//input[@id='" + d.Id + "']"));
                                if (input != null)
                                {
                                    input.SendKeys(d.Text);
                                    s.AppendLine("Success: FillTextboxCommand - Send"+d.Text+" to input with Id " + d.Id);
                                }
                                else
                                    s.AppendLine("Error: FillTextboxCommand - Cannot find input with Id " + d.Id);
                            }
                            else if (!string.IsNullOrEmpty(d.Class))
                            {
                                var input = driver.FindElement(By.XPath("//input[@class='" + d.Class + "']"));
                                if (input != null)
                                {
                                    input.SendKeys(d.Text);
                                    s.AppendLine("Success: FillTextboxCommand - Send" + d.Text + " to input with class " + d.Class);
                                }
                                else
                                    s.AppendLine("Error: FillTextboxCommand - Cannot find input with class " + d.Class);
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
                                if (d.ButtonType.Equals("button tag:input"))
                                {
                                    var btn = driver.FindElement(By.XPath("//input[@id='" + d.ButtonId + "']"));
                                    if (btn != null)
                                    {
                                        btn.Click();
                                        s.AppendLine("Success: Click Button - type Input with id " + d.ButtonId);
                                    }
                                    else
                                        s.AppendLine("Error: Click Button - type Input with id " + d.ButtonId);
                                }
                                else if (d.ButtonType.Equals("button tag:a"))
                                {
                                    var btn = driver.FindElement(By.XPath("//a[@id='" + d.ButtonId + "']"));
                                    if (btn != null)
                                    {
                                        btn.Click();
                                        s.AppendLine("Success: Click Button - type a with id " + d.ButtonId);
                                    }
                                    else
                                        s.AppendLine("Error: Click Button - type a with id " + d.ButtonId);
                                }
                                else if (d.ButtonType.Equals("input type:submit"))
                                {
                                    var btn1=FindElement(driver, By.ClassName("dx-button-content"), 10);
                                   

                                    new WebDriverWait(driver, TimeSpan.FromSeconds(7)).Until(ExpectedConditions.ElementExists((
                                            By.XPath("//input[@type='submit']"))));
                                       var btn = driver.FindElement(By.XPath("//input[@type='submit']"));
                                    if (btn != null)
                                    {                                        
                                        Actions actions = new Actions(driver);
                                        actions.MoveToElement(btn);
                                        actions.Perform();
                                                                                
                                        btn.Click();
                                        s.AppendLine("Success: Click Button - with type=submit");
                                    }
                                    else
                                        s.AppendLine("Error: Click Button - with type=submit");
                                }
                                else if (d.ButtonType.Equals("An element with Id"))
                                {
                                    var btn = FindElement(driver, By.Id(d.ButtonId), 10);

                                    if (btn != null)
                                    {
                                        Actions actions = new Actions(driver);
                                        actions.MoveToElement(btn);
                                        actions.Perform();

                                        btn.Click();
                                        s.AppendLine("Success: Click Button - with type=submit " + d.ButtonId);
                                    }
                                    else
                                        s.AppendLine("Error: Click Button - with type=submit " + d.ButtonId);
                                }
                                else if (d.ButtonType.Equals("An element with class"))
                                {
                                    var btn = FindElement(driver, By.ClassName(d.ButtonClass), 10);

                                    if (btn != null)
                                    {
                                        Actions actions = new Actions(driver);
                                        actions.MoveToElement(btn);
                                        actions.Perform();

                                        btn.Click();
                                        s.AppendLine("Success: Click Button - with class "+ d.ButtonClass);
                                    }
                                    else
                                        s.AppendLine("Error: Click Button - with class " + d.ButtonClass);
                                }
                            }
                            catch(Exception ex)
                            {
                                s.AppendLine("Error: Click Button - Exception:" + ex.ToString());
                            }
                     
                        }
                    }
                }
            }
            return s.ToString();
        }
        public static IWebElement FindElement(IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }
        private string GetScreenshot(int actionNum, IWebDriver driver)
        {
            try
            {
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                string currentFolder = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\Screenshots";
                if (!Directory.Exists(currentFolder))
                    Directory.CreateDirectory(currentFolder);
                ss.SaveAsFile(currentFolder + "\\Image" + actionNum + ".png", ScreenshotImageFormat.Png);
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
