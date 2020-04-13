using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace StoreManager
{
    public partial class Form1 : Form
    {

        public string _platformName = "Windows";
        public string _deviceName = "WindowsPC";
        public string _app_id = "";

        WindowsDriver<WindowsElement> _deskTopSessoin;
        CUtility _myUtility;
        public KeyList _keyList;


        MStoreManager _storeManager;
        public Form1()
        {
            InitializeComponent();
        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void Label9_Click(object sender, EventArgs e)
        {

        }

        private void TxtTester_TextChanged(object sender, EventArgs e)
        {
            
        }

        public void getTarget_Attributes(WindowsElement target)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("Parsing Elements"));
            target.Click();
        }
        private void button2_Click(object sender, EventArgs e)
        {



            try
            {
                OpenQA.Selenium.Appium.AppiumOptions ao = new AppiumOptions();
                ao.AddAdditionalCapability("app", "Root");
                ao.AddAdditionalCapability("platformName", _platformName);
                ao.AddAdditionalCapability("deviceName", _deviceName);

                //Default Time out is 1 minutes
                _deskTopSessoin = new WindowsDriver<WindowsElement>(new Uri(@"http://127.0.0.1:4723"), ao, TimeSpan.FromMinutes(2));

                //  element = _deskTopSessoin.FindElementByAccessibilityId(assertion_name/*"ad"*/);
                //AppiumWebElement alarm_button = _deskTopSessoin.FindElement(By.Name("알림 센터"));   //이방법도 OK
                /*WindowsElement*/

                //tile-P~Microsoft.WindowsStore_8wekyb3d8bbwe!App
                //Below Code is test Okay
                AppiumWebElement start_button = _deskTopSessoin.FindElement(By.Name("시작"));
                Thread.Sleep(2000);

                if (start_button != null)
                {
                    System.Diagnostics.Debug.WriteLine(string.Format("Find StartBtn"));
                    start_button.Click();
                }

                Thread.Sleep(3000);
                AppiumWebElement store_button = _deskTopSessoin.FindElementByAccessibilityId("tile-P~Microsoft.WindowsStore_8wekyb3d8bbwe!App");

                Thread.Sleep(2000);
                if (store_button != null)
                {
                    System.Diagnostics.Debug.WriteLine(string.Format("Find Store Btn"));
                    store_button.Click();
                }

                //여기까지 문제 없었으면 Store창이 정상적으로 display되어졌을 것이다.
                Thread.Sleep(7000);
                AppiumWebElement gaming_button = _deskTopSessoin.FindElementByAccessibilityId("gaming");
                if (gaming_button != null)
                {
                    System.Diagnostics.Debug.WriteLine(string.Format("Find gaming Btn"));
                    gaming_button.Click();
                }

                Thread.Sleep(2000);
                AppiumWebElement freegame_list = _deskTopSessoin.FindElement(By.Name("모두 표시 99/+  무료 인기 게임"));
                freegame_list.Click();


                Thread.Sleep(5000);
                var gameElement = _deskTopSessoin.FindElementsByClassName("GridViewItem");
                var currList = gameElement.ToList();
                System.Diagnostics.Debug.WriteLine(string.Format("[Setting MenuList]List Count:{0}", currList.Count));

                foreach (var currItem in currList)
                {
                    Dictionary<string, object> item_info = new Dictionary<string, object>();  //해당 아이템의 필요한 정보를 뽑아서 사전 형태로 저장

                    System.Diagnostics.Debug.WriteLine(string.Format("element name:{0}", currItem.GetAttribute("Name")));
                    //this.getTarget_Attributes(currItem);

                    currItem.Click();

                    //get 1 depth목록
                    Thread.Sleep(3000);

                    //var elements = _deskTopSessoin.FindElementsByXPath("//Button[@Name=\"NavigationControl\"]/child::*");
                    //var elements = _deskTopSessoin.FindElementsByXPath("//Group[@AutomationId=\"pdp\"]//child::*");       //This is OK 
                    //var elements = _deskTopSessoin.FindElementByAccessibilityId("pdp").FindElementsByXPath("//*");      //This is OK
                    //var elements = _deskTopSessoin.FindElementByAccessibilityId("pdp").FindElementsByXPath("//child::*"); //This is OK

                    //step1 : get App Title
                    var element = _deskTopSessoin.FindElementByAccessibilityId("DynamicHeading_productTitle");
                    string itemName = element.GetAttribute("Name");
                    item_info.Add(_keyList.k_store_app_name, itemName.ToString());

                    //var elements = element.FindElementsByXPath("/following-sibling::*");
                    var elements = _deskTopSessoin.FindElementsByXPath("//Text[@AutomationId=\"DynamicHeading_productTitle\"]/following-sibling::*");
                    foreach (var currChild in elements)
                    {
                        System.Diagnostics.Debug.WriteLine(string.Format("child name:{0}", currChild.GetAttribute("Name")));
                    }




                    //TO DO : Add Dictionary to List

                    break;

                }



                //Xpath Code는 정상동작하지 않음...
                //UI Recorder에서 찾아낸 xpath를 C#코드로 변환시킨 것
                ////Console.WriteLine("LeftClick on \"모두 표시 99/+  무료 인기 게임\" at (61,9)");
                //string xp2 = "/Pane[@Name=\"데스크톱 1\"][@ClassName=\"#32769\"]/Window[@Name=\"Microsoft Store\"][@ClassName=\"ApplicationFrameWindow\"]/Window[@Name=\"Microsoft Store\"][@ClassName=\"Windows.UI.Core.CoreWindow\"]/Custom[@AutomationId=\"NavigationChrome\"]/Button[@AutomationId=\"NavigationControl\"]/Pane[@AutomationId=\"_scrollViewer\"]/Custom[@AutomationId=\"topfreegames\"]/Hyperlink[@AutomationId=\"SectionViewAllButton\"][@Name=\"모두 표시 99/+  무료 인기 게임\"]";
                //var winElem2 = MyDesktopSession.FindElementByXPath(xp2);
                //if (winElem2 != null)
                //{
                //    winElem2.Click();
                //}




                //AppiumWebElement searchBtn = _deskTopSessoin.FindElementByClassName("Button");
                //Thread.Sleep(3000);
                //if (/*alarm_button*/searchBtn != null)
                //{
                //    System.Diagnostics.Debug.WriteLine(string.Format("Find SearchBtn"));
                //    _deskTopSessoin.Mouse.Click(searchBtn.Coordinates);
                //    //_deskTopSessoin.Mouse.MouseDown(searchBtn.Coordinates);
                //    //_deskTopSessoin.Mouse.MouseDown(searchBtn.Coordinates);
                //    //session.Mouse.MouseMove(appNameTitle.Coordinates);
                //    // _deskTopSessoin.Mouse.ContextClick(currElement.Coordinates);
                //    // searchBtn.Click();

                //}

                //AppiumWebElement searchBox =  _deskTopSessoin.FindElementByAccessibilityId("SearchTextBox");

                // if (searchBox != null)
                // {
                //     //alarm_button.Click();
                //     System.Diagnostics.Debug.WriteLine(string.Format("Full Stacktrace: Find SearchBox"));
                //     searchBox.SendKeys("store");
                // }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("Full Stacktrace: {0}", ex.ToString()));
            }
            finally
            {

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _storeManager = MStoreManager.Instance;
            _myUtility = CUtility.Instance;
            _keyList = KeyList.Instance;

            // _settingManager.connectUI(this);
            this.composeCategory_combo();
            string categoryName = this.cboCategory.SelectedItem.ToString();
            this.composeSubclass_combo(categoryName);
        }

        public void composeCategory_combo()
        {
            //cboCategory.Items.Add(currObj.ToString());
            cboCategory.Items.Add("게임");
            cboCategory.Items.Add("엔터테인먼트");
            cboCategory.Items.Add("생산성");
            cboCategory.SelectedIndex = 0;
        }

        public void composeSubclass_combo(string name)
        {
            //Category Combo값에 따라 combo-box구성이 틀려진다.
            switch (name)
            {
                case "게임":
                    {
                        cboSubclass.Items.Add("무료인기게임");
                        cboSubclass.Items.Add("유료인기게임");
                        cboSubclass.SelectedIndex = 0;
                        break;
                    }
                case "엔터테인먼트":
                    {

                        break;
                    }
                case "생산성":
                    {
                        break;
                    }
                default:
                    break;
            }

        }
        public void HeyConnect()
        {
            System.Diagnostics.Debug.WriteLine(string.Format("Hey Connect"));
        }

        private void BtnStoreSession_Click(object sender, EventArgs e)
        {

        }

        private void CmdRun_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> sendInfo = new Dictionary<string, string>();

            string categoryName = this.cboCategory.SelectedItem.ToString();
            string subclassName = this.cboSubclass.SelectedItem.ToString();

            string workerMode = EnumSet.ActionMode.STORE_AUTOMATION_TEST.ToString();
            //string platformName = "Windows";
            //string deviceName = "WindowsPC";
            //k_store_category = "k_store_category";   //store대분류 (게임,엔터테인먼트,생산성,특가)
            //k_store_subclass = "k_store_subclass";

            sendInfo.Add(_keyList.k_worker_mode, workerMode);
            sendInfo.Add(_keyList.k_store_category, categoryName);
            sendInfo.Add(_keyList.k_store_subclass, subclassName);
          
            _storeManager.worker.RunWorkerAsync(sendInfo);
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void CboSubclass_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void TxtStartDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtEndDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void CboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.composeSubclass_combo
            string categoryName = "";
            categoryName = this.cboCategory.SelectedItem.ToString();

        }
    }
}