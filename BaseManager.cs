using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace StoreManager
{
    class BaseManager
    {

        public Form1 _uiManager;
        public WindowsDriver<WindowsElement> _deskTopSessoin;

        public BaseManager()
        {
            System.Diagnostics.Debug.WriteLine(string.Format("Default Constructor(BaseManager)"));
        }

        public BaseManager(EnumSet.CATEGORY category)
        {

        }

        public void connectUI(Form1 conn)
        {
            _uiManager = conn;
            System.Diagnostics.Debug.WriteLine(string.Format("connectUI(BaseManager)"));
            conn.HeyConnect();
        }

        public void initDeskTopSession()
        {
            System.Diagnostics.Debug.WriteLine(string.Format("InitDeskTop Session(BaseManager)"));
            string platformName = "Windows";
            string deviceName = "WindowsPC";
            string app_id = "";

            if (_deskTopSessoin != null)
            {
                try
                {
                    OpenQA.Selenium.Appium.AppiumOptions ao = new AppiumOptions();
                    ao.AddAdditionalCapability("app", "Root");
                    ao.AddAdditionalCapability("platformName", platformName);
                    ao.AddAdditionalCapability("deviceName", deviceName);

                    _deskTopSessoin = new WindowsDriver<WindowsElement>(new Uri(@"http://127.0.0.1:4723"), ao, TimeSpan.FromMinutes(2));
                    //_deskTopSessoin = new WindowsDriver<WindowsElement>(new Uri(@"http://127.0.0.1:4723"), ao);
                    //_deskTopSessoin.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
                    _deskTopSessoin.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(string.Format("Full Stacktrace: {0}", ex.ToString()));
                }
            }
        }



    }
}
