using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Selenium;

namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {
            ISelenium selenium;
            selenium = new DefaultSelenium("localhost", 4444, "*firefox", "http://www.baidu.com");
            selenium.Start();
            selenium.WindowMaximize();            
            selenium.Open("/");
            selenium.Click("id=kw");
            selenium.Type("id=kw", "shinetech");
            selenium.Click("id=su");
            for (int second = 0; ; second++)
            {
                if (second >= 60)
                {
                    Console.WriteLine("Locate element failed");
                }
                try
                {
                    if (selenium.IsElementPresent("//div[@id='1']")) break;
                }
                catch (Exception)
                { }
                System.Threading.Thread.Sleep(1000);
            }
            selenium.Click("//div[@id='1']/h3/a");
            selenium.Stop();
        }
    }
}
