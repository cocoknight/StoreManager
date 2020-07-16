/*********************************************************************************************************-- 
    
    Copyright (c) 2020, YongMin Kim. All rights reserved. 
    This file is licenced under a Creative Commons license: 
    http://creativecommons.org/licenses/by/2.5/ 

    *Description : This is control and UI Logic for store automation
    * 
    2020-04-13: Make a basic operation 
    2020-04-19: Update test result to listview
    2020-04-22: Make a export module
--***********************************************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace StoreManager
{
    public partial class Form1 : Form
    {

        public string _platformName = "Windows";
        public string _deviceName = "WindowsPC";
        public string _app_id = "";

        WindowsDriver<WindowsElement> _deskTopSession;
        WebDriverWait _wait;
        CUtility _myUtility;
        public KeyList _keyList;


        public List<Dictionary<string, object>> _store_list;
        List<string> _testresult_columninfos;

        MStoreManager _storeManager;

        CReportManager _reportManager;
        CResultLoader _resultLoader;


        public Form1()
        {
            InitializeComponent();

            _reportManager = CReportManager.Instance;
            _resultLoader = CResultLoader.Instance;

            _reportManager.connectUI(this);
            _resultLoader.connectUI(this);
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

        /* Test시나리오
        StoreManager First Draft
        무료 : MS Store 홈 ->무료 인기 앱
        유료 : MS Store 홈 ->뮤료 인기 앱 -> 차트 Top Paid선택(필터에서 선택)
        */




        private void button2_Click(object sender, EventArgs e)
        {



            try
            {
                OpenQA.Selenium.Appium.AppiumOptions ao = new AppiumOptions();
                ao.AddAdditionalCapability("app", "Root");
                ao.AddAdditionalCapability("platformName", _platformName);
                ao.AddAdditionalCapability("deviceName", _deviceName);

                //Default Time out is 1 minutes
                _deskTopSession = new WindowsDriver<WindowsElement>(new Uri(@"http://127.0.0.1:4723"), ao, TimeSpan.FromMinutes(2));
                _deskTopSession.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(500);

                //_deskTopSession = new WindowsDriver<WindowsElement>(new Uri(@"http://127.0.0.1:4723"), ao);

                //  element = _deskTopSession.FindElementByAccessibilityId(assertion_name/*"ad"*/);
                //AppiumWebElement alarm_button = _deskTopSession.FindElement(By.Name("알림 센터"));   //이방법도 OK
                /*WindowsElement*/

                //tile-P~Microsoft.WindowsStore_8wekyb3d8bbwe!App
                //Below Code is test Okay
                AppiumWebElement start_button = _deskTopSession.FindElement(By.Name("시작"));
                Thread.Sleep(2000);

                if (start_button != null)
                {
                    System.Diagnostics.Debug.WriteLine(string.Format("Find StartBtn"));
                    start_button.Click();
                }

                Thread.Sleep(3000);
                AppiumWebElement store_button = _deskTopSession.FindElementByAccessibilityId("tile-P~Microsoft.WindowsStore_8wekyb3d8bbwe!App");

                Thread.Sleep(2000);
                if (store_button != null)
                {
                    System.Diagnostics.Debug.WriteLine(string.Format("Find Store Btn"));
                    store_button.Click();
                }

                //여기까지 문제 없었으면 Store창이 정상적으로 display되어졌을 것이다.
                Thread.Sleep(7000);
                AppiumWebElement gaming_button = _deskTopSession.FindElementByAccessibilityId("gaming");
                if (gaming_button != null)
                {
                    System.Diagnostics.Debug.WriteLine(string.Format("Find gaming Btn"));
                    gaming_button.Click();
                }

                Thread.Sleep(2000);
                AppiumWebElement freegame_list = _deskTopSession.FindElement(By.Name("모두 표시 99/+  무료 인기 게임"));
                freegame_list.Click();


                Thread.Sleep(5000);
                var gameElement = _deskTopSession.FindElementsByClassName("GridViewItem");
                var currList = gameElement.ToList();
                System.Diagnostics.Debug.WriteLine(string.Format("[Setting MenuList]List Count:{0}", currList.Count));

                //compose dictionary info
                string categoryName = this.cboCategory.SelectedItem.ToString();
                string subclassName = this.cboSubclass.SelectedItem.ToString();

                int loop_counter = 1;

                //start of testcode : 04/16
                //foreach (var currItem in currList)
                //{
                //    //TOAN : 04/15/2020. W/A적용
                //    //아래와 같이 했을 때, back한이후에 다시 click했을때, currItem은 존재하지만, click이벤튼 정상동작하지 않는다
                //    //exception : An element command could not be completed because the element is not pointer- or keyboard interactable.
                //    //currItem.Click();
                //    //Thread.Sleep(3000);
                //    //_deskTopSession.Navigate().Back();

                //    //W/A적용 : Click을 보내기 전에 현재 currItem의 AutomationID를 이용해서 명시적으로 선택한 후
                //    //Click Event을 재적용한다.
                //    //_deskTopSession.manage().window().maximize();
                //    //Thread.Sleep(2000);

                //    string itemID = currItem.GetAttribute("AutomationId");
                //    System.Diagnostics.Debug.WriteLine(string.Format("App Name:{0}", currItem.GetAttribute("Name")));
                //    //System.Diagnostics.Debug.WriteLine(string.Format("Automation ID:{0}", currItem.GetAttribute("AutomationId")));
                //    System.Diagnostics.Debug.WriteLine(string.Format("Automation ID:{0}", itemID));
                //    var currTarget = _deskTopSession.FindElementByAccessibilityId(itemID);

                //    currTarget.Click();
                //   // Thread.Sleep(3000); //This is Okay
                //    Thread.Sleep(/*9000*//*15000*/30000); //임의로 충분히 끌기 , 동영상 플레이가 재생되고 navigation bar가 재생중에 화면에 보이지 않는것을 재현하기 위함.

                //    //개요를 선택해서 click. 개요를 선택해도 video가 play될 때,navigation화면이 없어진다
                //    //var overview = _deskTopSession.FindElementByAccessibilityId("pivot-tab-OverviewTab");
                //    //overview.Click();
                //    //Thread.Sleep(2000);
                //    //Thread.Sleep(50000); //미리보기 영상때문에 50초 대기. 이런 코드는 사용하면 안된다. 어떻게 매번 기다릴수 있는가.

                //    //Thread.Sleep(19000); //3sec -> 4sec로 확장
                //    //_deskTopSession.Navigate().Back();



                //    //setup explicit wait(smart wait)
                //    //maximum timeout을 설정하고, 해당시간까지 주기적으로 polling을 해서
                //    //timeout이 되기전에 target element을 발견하면, click이벤트를 실행 한다.
                //    //기존코드
                //    //WebDriverWait wait = new WebDriverWait(_deskTopSession, TimeSpan.FromMinutes(2));
                //    //var tElement = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("NavigationViewBackButton")));
                //    //tElement.Click();

                //    //상세보기 에서 비디오디스플레이가 있을 때 IsOffscreen은 false가 되고
                //    //하지만  IsEnabled=true이다. 이경우 element에 click과 같은 이벤트를 보내면 아래와 같은 exception이 발생
                //    //따라서 Explicit Wait Conditon에 이 조건을 주어야 한다.
                //    //Full Stacktrace: OpenQA.Selenium.WebDriverException: An element could not be located on the page using the given search parameters.
                //    //reference : https://github.com/Microsoft/WinAppDriver/issues/281

                //    //var elementBack = _deskTopSession.FindElementByAccessibilityId("NavigationViewBackButton");
                //    //System.Diagnostics.Debug.WriteLine(string.Format("[BackButton]Element displayed?:{0}", elementBack.Displayed));
                //    //System.Diagnostics.Debug.WriteLine(string.Format("[BackButton]IsOffScreen?:{0}", elementBack.GetAttribute("IsOffscreen")));


                //    //elementBack.Click();
                //    //Thread.Sleep(3000);


                //    //_deskTopSession.Navigate().Back();
                //    //Thread.Sleep(3000);

                //   var wait = new WebDriverWait(_deskTopSession, new TimeSpan(0, 2, 0));
                //    //var btnButton = _deskTopSession.FindElementByName("뒤로 단추");

                //    //Reference URL : https://stackoverflow.com/questions/53902369/explicit-wait-for-automating-windows-application-using-winappdriver
                //    //Reference URL : https://github.com/DotNetSeleniumTools/DotNetSeleniumExtras/blob/master/src/WaitHelpers/ExpectedConditions.cs
                //    //var element1 = wait.Until()
                //    //NavigationViewBackButton

                //    //SeleniumExtras를 사용할때 By.Id에서 id값은 automationID가 아니다.
                //    //var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("NavigationViewBackButton")));
                //    var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Name("뒤로 단추")));
                //    element.Click();

                //    //var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Name("뒤로 단추"))); //fail
                //    //bool result = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementWithText(By.Name("홈"),"홈"));


                //    //if (result == true)
                //    //{
                //    //    var elementBack = _deskTopSession.FindElementByAccessibilityId("NavigationViewBackButton");
                //    //    elementBack.Click();
                //    //}
                //    //bool cResult =wait.Until(pred => btnButton.Displayed);

                //    //if(cResult==true)
                //    //{
                //    //    btnButton.Click();
                //    //}
                //} //end of test code


                //Below is data fetch logic
                foreach (var currItem in currList)
                {
                    System.Diagnostics.Debug.WriteLine(string.Format("Data Fetch Logic Start:{0}", this.getCurrentTime()));

                    Dictionary<string, object> item_info = new Dictionary<string, object>();  //해당 아이템의 필요한 정보를 뽑아서 사전 형태로 저장

                    item_info.Add(_keyList.k_store_category, categoryName);
                    item_info.Add(_keyList.k_store_subclass, subclassName);
                    //Add Category and Subclass

                    //System.Diagnostics.Debug.WriteLine(string.Format("element name:{0}", currItem.GetAttribute("Name")));
                    //System.Diagnostics.Debug.WriteLine(string.Format("loop counter:{0}", loop_counter));
                    //System.Diagnostics.Debug.WriteLine(string.Format("Offscreen value:{0}", currItem.GetAttribute("IsOffScrren")));
                    //this.getTarget_Attributes(currItem);
                    //Assert.isTrue

                    //Thread.Sleep(/*5000*/8000);
                    //TOAN : 04/16/2020. AutomatinID기준으로 item을 찾고 난 후 click진행(for loop반복시 이렇게 하지 않으면 exception발생)
                    string itemID = currItem.GetAttribute("AutomationId");
                    System.Diagnostics.Debug.WriteLine(string.Format("Automation ID:{0}", itemID));
                    var currTarget = _deskTopSession.FindElementByAccessibilityId(itemID);
                    //currTarget이 유효한지 확인 해보자(미니언즈)
                    currTarget.Click();

                    //currItem.Click(); //해당 Item의 상세 정보 보기로 진입 한다.

                    //get 1 depth목록
                    //Thread.Sleep(3000);

                    //var elements = _deskTopSession.FindElementsByXPath("//Button[@Name=\"NavigationControl\"]/child::*");
                    //var elements = _deskTopSession.FindElementsByXPath("//Group[@AutomationId=\"pdp\"]//child::*");       //This is OK 
                    //var elements = _deskTopSession.FindElementByAccessibilityId("pdp").FindElementsByXPath("//*");      //This is OK
                    //var elements = _deskTopSession.FindElementByAccessibilityId("pdp").FindElementsByXPath("//child::*"); //This is OK

                    //step1 : get App Title
                    System.Diagnostics.Debug.WriteLine(string.Format("DynamicHeading_productTitle Element Find Start:{0}", this.getCurrentTime()));
                    var element = _deskTopSession.FindElementByAccessibilityId("DynamicHeading_productTitle");
                    string itemName = element.GetAttribute("Name");

                    item_info.Add(_keyList.k_store_app_name, itemName.ToString());

                    //var elements = element.FindElementsByXPath("/following-sibling::*");
                    //var elements = _deskTopSession.FindElementsByXPath("//Text[@AutomationId=\"DynamicHeading_productTitle\"]/following-sibling::*"); //This is OK

                    //click한 이후에 형제 element들을 가지고 온다.
                    System.Diagnostics.Debug.WriteLine(string.Format("[형제]DynamicHeading_productTitle Sibling Find Start:{0}", this.getCurrentTime()));
                    var elements = _deskTopSession.FindElementsByXPath("//Text[@AutomationId=\"DynamicHeading_productTitle\"]//following-sibling::*"); //This is OK

                    foreach (var currElement in elements)
                    {
                        // System.Diagnostics.Debug.WriteLine(string.Format("child name:{0}", currElement.GetAttribute("Name"))); //print all sibling member
                        //Step1 : Get Publisher
                        string currString = currElement.GetAttribute("Name");
                        System.Diagnostics.Debug.WriteLine(string.Format("current element name:{0}", currString));

                        if (!String.IsNullOrEmpty(currString))
                        {

                            if (currString.Equals("게시자"))
                            {
                                var childElement = currElement.FindElementByXPath("//child::Button"); //Get first button element
                                string publisher_name = childElement.GetAttribute("Name");
                                System.Diagnostics.Debug.WriteLine(string.Format("publisher name:{0}", childElement.GetAttribute("Name"))); //print all sibling member
                                item_info.Add(_keyList.k_sotre_app_manufacture, publisher_name);

                            }
                            //Step2 : Get Category
                            if (currString.Equals("범주"))
                            {

                                var childElements = currElement.FindElementsByXPath("//child::Button"); //Get All button elements
                                string category_string = "";
                                string suffix_string = "의 자세한 결과 보기";
                                int suffix_length = suffix_string.Length;

                                //Store의 범주는 눈에 보여지는 string과 ui element가 가지고 있는 형태가 틀리다.
                                //예를 들어 Roblox의 경우 엑션 및 어드벤처,가족 및 어린이와 같이 표시되나.
                                //내부적으로는
                                //"액션 및 어드벤처의 자세한 결과 보기", "," ,"가족 및 어린이의 자세한 결과 보기"로 구성
                                //즉, 접미사 형태로 "자세한 결과 보기"가 포함되어 있다. 따라서 이것에 대해 substring작업을 통해 별도 처리 한다.
                                //위 작업은 suffix length와 substring을 통해 이루어 진다.


                                foreach (var currButton in childElements)
                                {
                                    //category_string = String.Right()
                                    if (!String.IsNullOrEmpty(category_string))
                                    {
                                        string element_name = currButton.GetAttribute("Name");
                                        category_string = category_string + "," + element_name.Substring(0, element_name.Length - suffix_length);
                                    }
                                    else
                                    {
                                        string element_name = currButton.GetAttribute("Name");
                                        category_string = element_name.Substring(0, element_name.Length - suffix_length);
                                    }


                                }

                                item_info.Add(_keyList.k_store_app_category, category_string); //앱이 상세 범부("액션 및 어드벤쳐", "가족 및 어린이"와 같은 표현

                                System.Diagnostics.Debug.WriteLine(string.Format("item category name:{0}", category_string));
                            } //end of 범주

                            //Step3 : 평점 및 Review갯수 
                            if (currString.Contains("평점"))
                            {
                                //This is abnormal case for element hierarchy. But, This is based on MS Naming Code
                                var result1 = Regex.Split(currString, ":"); // ":"을 기준으로 2개의 파트로 구분 한다.
                                                                            //첫번째 파트에서 숫자만 찾아서, 천단위 구분기호를 넣어준다.(store상에 표기되는 그대로 표시하기 위함)
                                string number_of_vote = Regex.Replace(result1[0], @"\D", "");
                                int vote_number = int.Parse(number_of_vote);
                                string c_number_of_vote = String.Format("{0:#,###}", vote_number);
                                System.Diagnostics.Debug.WriteLine(string.Format("평가 갯수:{0}", c_number_of_vote));

                                item_info.Add(_keyList.k_store_app_review, c_number_of_vote);

                                //두번째 파트에서 실수를 찾는다. (4.0, 2.X와 같이 평점 표현)
                                Regex r = new Regex(@"[0-9]+\.[0-9]+");
                                Match m = r.Match(result1[1]);
                                System.Diagnostics.Debug.WriteLine(string.Format("평점:{0}", m.ToString()));

                                item_info.Add(_keyList.k_store_app_grade, m.ToString());
                                //foreach (var z1 in result1)
                                //{
                                //    System.Diagnostics.Debug.WriteLine(string.Format("part name:{0}", z1));
                                //    string strTmp = Regex.Replace(z1, @"\D", "");
                                //    System.Diagnostics.Debug.WriteLine(string.Format("replace name:{0}", strTmp));
                                //}
                                //_store_list.Add();
                            }

                        } //end of if(string null check)

                    } //end of inner loop

                    //취합된 정보를 list에 insert
                    _store_list.Add(item_info);

                    //다시 이전 gridview로 전환
                    var elementBack = _deskTopSession.FindElementByAccessibilityId("NavigationViewBackButton");
                    elementBack.Click();
                    //Thread.Sleep(2000);
                    //Thread.Sleep(/*5000*/8000);
                    //TO DO : Add Dictionary to List

                    //1번만 하고 종료 시킬려고 break문 사용(test용도)
                    //break;

                    loop_counter = loop_counter + 1;

                } //end of element search

                System.Diagnostics.Debug.WriteLine(string.Format("Data Fetch Logic End:{0}", this.getCurrentTime()));





                //Xpath Code는 정상동작하지 않음...
                //UI Recorder에서 찾아낸 xpath를 C#코드로 변환시킨 것
                ////Console.WriteLine("LeftClick on \"모두 표시 99/+  무료 인기 게임\" at (61,9)");
                //string xp2 = "/Pane[@Name=\"데스크톱 1\"][@ClassName=\"#32769\"]/Window[@Name=\"Microsoft Store\"][@ClassName=\"ApplicationFrameWindow\"]/Window[@Name=\"Microsoft Store\"][@ClassName=\"Windows.UI.Core.CoreWindow\"]/Custom[@AutomationId=\"NavigationChrome\"]/Button[@AutomationId=\"NavigationControl\"]/Pane[@AutomationId=\"_scrollViewer\"]/Custom[@AutomationId=\"topfreegames\"]/Hyperlink[@AutomationId=\"SectionViewAllButton\"][@Name=\"모두 표시 99/+  무료 인기 게임\"]";
                //var winElem2 = MyDesktopSession.FindElementByXPath(xp2);
                //if (winElem2 != null)
                //{
                //    winElem2.Click();
                //}




                //AppiumWebElement searchBtn = _deskTopSession.FindElementByClassName("Button");
                //Thread.Sleep(3000);
                //if (/*alarm_button*/searchBtn != null)
                //{
                //    System.Diagnostics.Debug.WriteLine(string.Format("Find SearchBtn"));
                //    _deskTopSession.Mouse.Click(searchBtn.Coordinates);
                //    //_deskTopSession.Mouse.MouseDown(searchBtn.Coordinates);
                //    //_deskTopSession.Mouse.MouseDown(searchBtn.Coordinates);
                //    //session.Mouse.MouseMove(appNameTitle.Coordinates);
                //    // _deskTopSession.Mouse.ContextClick(currElement.Coordinates);
                //    // searchBtn.Click();

                //}

                //AppiumWebElement searchBox =  _deskTopSession.FindElementByAccessibilityId("SearchTextBox");

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
                System.Diagnostics.Debug.WriteLine(string.Format("Exception Occurred Time:{0}", this.getCurrentTime()));
            }
            finally
            {

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            _storeManager = MStoreManager.Instance;
            _storeManager.connectUI(this);
            _myUtility = CUtility.Instance;
            _keyList = KeyList.Instance;

            _store_list = new List<Dictionary<string, object>>();
            _testresult_columninfos = new List<string>();

            txtTestTitle.Text = "Windows Store_KOR 앱 &Game";

            // _settingManager.connectUI(this);
            this.composeCategory_combo();
            string categoryName = this.cboCategory.SelectedItem.ToString();
            this.composeSubclass_combo(categoryName);

            //this.initDeskTopSession();

            try
            {
                this.initTestResultList();
                
            }catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("Full Stacktrace: {0}", ex.ToString()));
            }
        }

        public void initTestResultList()
        {
            //Display Column Title
           if (grpTestResult.Controls.ContainsKey("ResultListView"))
            {
                ListView resultList= (ListView)grpTestResult.Controls["ResultListView"];

                resultList.View = View.Details;
                resultList.GridLines = true;
                resultList.FullRowSelect = true;
                resultList.CheckBoxes = false;

                resultList.Columns.Add(_keyList.k_store_category, "대분류", 150);
                resultList.Columns.Add(_keyList.k_store_subclass, "소분류", 200);
                resultList.Columns.Add(_keyList.k_store_app_name, "앱이름", 200);
                resultList.Columns.Add(_keyList.k_sotre_app_manufacture, "제작사",200);
                resultList.Columns.Add(_keyList.k_store_app_category, "앱유형", 200);
                resultList.Columns.Add(_keyList.k_store_app_grade, "앱평점", 200);
                resultList.Columns.Add(_keyList.k_store_app_review, "앱평가 갯수", 200);

                //_testresult_columninfos
                _testresult_columninfos.Add(_keyList.k_store_category);
                _testresult_columninfos.Add(_keyList.k_store_subclass);
                _testresult_columninfos.Add(_keyList.k_store_app_name);
                _testresult_columninfos.Add(_keyList.k_sotre_app_manufacture);
                _testresult_columninfos.Add(_keyList.k_store_app_category);
                _testresult_columninfos.Add(_keyList.k_store_app_grade);
                _testresult_columninfos.Add(_keyList.k_store_app_review);

            }
        }

        public void TestResultToListView(List<Dictionary<string, object>> testResult)
        {
            //update 
            //ListView resultList= (ListView)grpTestResult.Controls["ResultListView"];
            ListView itemListView = (ListView)grpTestResult.Controls["ResultListView"];
            string[] row = { "", "", "", "", "", "", "" };

            //k_store_category = "k_store_category";   //store대분류 (게임,엔터테인먼트,생산성,특가)
            //k_store_subclass = "k_store_subclass";   //store소분류 (최다판매게임,무료인기게임,유료인기게임,새롭고 주목할 만한 PC게임 등..)
            //k_store_app_name = "k_store_app_name";   //앱이름
            //k_sotre_app_manufacture = "k_sotre_app_manufacture";  //앱 제작사
            //k_store_app_category = "k_store_app_category";  //앱 유형(성격)
            //k_store_app_grade = "k_store_app_grade"; //앱 평점
            //k_store_app_review = "k_store_app_review"; //앱 평가 개수

            //TOAN : 11/25/2019. code-change
            if (itemListView.Items.Count > 0)
            {
                itemListView.Items.Clear();
            }

            foreach (var currDic in testResult)
            {
                ListViewItem cItem = new ListViewItem(row);
                cItem.UseItemStyleForSubItems = false;  //이 설정이 없으면 subitem의 색상이 변경되지 않는다.

                foreach (string name in _testresult_columninfos)
                {

                    if (currDic.ContainsKey(name))
                    {
                        int columnIndex = itemListView.Columns.IndexOfKey(name);
                        cItem.SubItems[columnIndex].Text = currDic[name].ToString(); //columninfo에 해당하는 키의 값은 string이다.
                    }
                }

                itemListView.Items.Add(cItem);
            }


        }

        public void composeCategory_combo()
        {
            //cboCategory.Items.Add(currObj.ToString());
            cboCategory.Items.Add("게임");
            cboCategory.Items.Add("앱");
            //cboCategory.Items.Add("엔터테인먼트");
            //cboCategory.Items.Add("생산성");
            cboCategory.SelectedIndex = 0;
        }

        public void composeSubclass_combo(string name)
        {
            //Category Combo값에 따라 combo-box구성이 틀려진다.
            cboSubclass.Items.Clear();

            switch (name)
            {
                case "게임":
                    {
                        cboSubclass.Items.Add("무료인기게임");
                        cboSubclass.Items.Add("유료인기게임");
                        cboSubclass.SelectedIndex = 0;
                        break;
                    }
                case "앱":
                    {
                        cboSubclass.Items.Add("무료인기앱");
                        cboSubclass.Items.Add("유료인기앱");
                        cboSubclass.SelectedIndex = 0;
                        break;
                    }
                //case "엔터테인먼트":
                //    {

                //        break;
                //    }
                //case "생산성":
                //    {
                //        break;
                //    }
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
            this.composeSubclass_combo(categoryName);
        }

        private void cmdUseCase_Click(object sender, EventArgs e)
        {
            //Appium관련 키워드 테스트
            //Keyword : implicit, explicit 및 timeout checking
            //keyword : An element could not be located on the page using the given search parameters
            try
            {
                //this.initDeskTopSession();
                // System.Diagnostics.Debug.WriteLine("Element Search:{0}", this.getCurrentTime());

                //test1 : 존재하지 않는 element name. 해당 name을 가진 element가 없으므로 2분뒤에 timeout발생(timed out after 120 seconds)
                //AppiumWebElement start_button = _deskTopSession.FindElement(By.Name("시작"));
                //start_button.Click();
                //test2 : 존재하지 않는 element id. 해당 name을 가진 element가 없으므로 2분뒤에 timeout발생(timed out after 120 seconds)
                //AppiumWebElement start_button = _deskTopSession.FindElementByAccessibilityId("시작356");

                //Explicit wait를 테스트하지. 아니면 내가 만들자.
                //System.Diagnostics.Debug.WriteLine(string.Format("Hey Connect"));
                System.Diagnostics.Debug.WriteLine(string.Format("Element Searching Start:{0}", this.getCurrentTime()));
                var elementBack = _deskTopSession.FindElementByAccessibilityId("NavigationViewBackButton");
                System.Diagnostics.Debug.WriteLine(string.Format("Element Action Start:{0}", this.getCurrentTime()));
                elementBack.Click();
                System.Diagnostics.Debug.WriteLine(string.Format("Element Action is completed:{0}", this.getCurrentTime()));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("Full Stacktrace: {0}", ex.ToString()));
                System.Diagnostics.Debug.WriteLine("Exception Expire:{0}", this.getCurrentTime());
            }
            finally
            {

            }
        }


        public void initDeskTopSession()
        {
            System.Diagnostics.Debug.WriteLine(string.Format("InitDeskTop Session(BaseManager)"));
            string platformName = "Windows";
            string deviceName = "WindowsPC";
            string app_id = "";

            if (_deskTopSession == null)
            {
                try
                {
                    OpenQA.Selenium.Appium.AppiumOptions ao = new AppiumOptions();
                    ao.AddAdditionalCapability("app", "Root");
                    ao.AddAdditionalCapability("platformName", platformName);
                    ao.AddAdditionalCapability("deviceName", deviceName);

                    _deskTopSession = new WindowsDriver<WindowsElement>(new Uri(@"http://127.0.0.1:4723"), ao, TimeSpan.FromMinutes(/*2*/4)); //2분 응답 Timer설정
                   // _deskTopSession = new WindowsDriver<WindowsElement>(new Uri(@"http://127.0.0.1:4723"), ao); //시간을 주지 않으면, Default 1분 응답 Timer
                    //_deskTopSession.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
                    _deskTopSession.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(/*30*/200);

                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(string.Format("Full Stacktrace: {0}", ex.ToString()));
                }
            }
        }

        public void initDeskTopSession_Explicit()
        {
            System.Diagnostics.Debug.WriteLine(string.Format("InitDeskTop Session(BaseManager)"));
            string platformName = "Windows";
            string deviceName = "WindowsPC";
            string app_id = "Root";

            if (_deskTopSession == null)
            {
                try
                {
                    OpenQA.Selenium.Appium.AppiumOptions ao = new AppiumOptions();
                    ao.AddAdditionalCapability("app", "Root");
                    ao.AddAdditionalCapability("platformName", platformName);
                    ao.AddAdditionalCapability("deviceName", deviceName);

                      _deskTopSession = new WindowsDriver<WindowsElement>(new Uri(@"http://127.0.0.1:4723"), ao, TimeSpan.FromMinutes(10));

                      _wait = new WebDriverWait(_deskTopSession, new TimeSpan(0, 5, 0));

                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(string.Format("Full Stacktrace: {0}", ex.ToString()));
                }
            }
        }

        public string getCurrentTime()
        {
            //Get Current Time
            string currTime;
            //startTime = string.Format("{0:hh:mm:ss tt}", DateTime.Now);
            currTime = string.Format("{0:hh:mm:ss tt}", DateTime.Now);
            //_currentTime = currTime;
            //return _currentTime;
            return currTime;
        }

        private void BtnCategory_Click(object sender, EventArgs e)
        {
            //Get Category Element with XPath
            this.initDeskTopSession();

            //Find Element with xpath
            //var elements = _deskTopSession.FindElementsByXPath("//Button[@Name=\"NavigationControl\"]/child::*");
            //var elements = _deskTopSession.FindElementsByXPath("//Group[@AutomationId=\"pdp\"]//child::*");       //This is OK 
            //var elements = _deskTopSession.FindElementByAccessibilityId("pdp").FindElementsByXPath("//*");      //This is OK
            //var elements = _deskTopSession.FindElementByAccessibilityId("pdp").FindElementsByXPath("//child::*"); //This is OK

            var elements = _deskTopSession.FindElementsByXPath("//Group[@AutomationId=\"범주-toggle-target\"]//child::*");
            System.Diagnostics.Debug.WriteLine(string.Format("element name:{0}", elements[0].GetAttribute("Name")));
            System.Diagnostics.Debug.WriteLine(string.Format("element name:{0}", elements[1].GetAttribute("Name")));

            //아래 loop에서 2번째 항목이 "범주"에 해당하는 값이 된다.
            //foreach (var currItem in elements)
            //{
            //    System.Diagnostics.Debug.WriteLine(string.Format("element name:{0}", currItem.GetAttribute("Name")));
            //}

        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            //Report to XML


            string dirName = @"C:\storeranking";
            //string dirName = "C:\\bomautomation";
            DirectoryInfo di = new DirectoryInfo(dirName);

            if (di.Exists == false)
            {
                di.Create();
            }

            this.HandleExcelReport(di, dirName);
          

        }



        public void HandleExcelReport(DirectoryInfo dInfo, string directory)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("Parsing HandleExcelReport"));

            //출력을 Excel로 지정 가능하다.
            string fileName = txtTestTitle.Text;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = fileName;
            saveFileDialog.Filter = "Excel|*.xlsx";
            saveFileDialog.Title = "Save an Excel File";
            saveFileDialog.InitialDirectory = dInfo.ToString();

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog.FileName != "")
                {
                    string cfileName = saveFileDialog.FileName;
                    Properties.Settings.Default.s_filepath = cfileName;
                    Properties.Settings.Default.Save();

                    System.Diagnostics.Debug.WriteLine(string.Format("Save File Name:{0}", saveFileDialog.FileName.ToString()));
                    System.Diagnostics.Debug.WriteLine(string.Format("Save File Name Confirm:{0}", cfileName));

                    //Run Async
                    Dictionary<string, string> sendInfo = new Dictionary<string, string>();
                    string workerMode = EnumSet.ActionMode.STORE_AUTOMATION_REPORT.ToString();
                    sendInfo.Add(_keyList.k_worker_mode, workerMode);
                    sendInfo.Add(_keyList.k_test_result_name, cfileName);
                   
                    _reportManager.worker.RunWorkerAsync(sendInfo);
                }
            }

        }

        private void BtnRun_Click(object sender, EventArgs e)
        {

        }


        //TOAN : 06/04/2020
        private void Button1_Click_1(object sender, EventArgs e)
        {
            //GridView Item을 click해서 상세보기를 실시
            //TOAN : 06/04/2020. 신규 코드 루틴
            //this.initDeskTopSession();


            //TOAN : 06/04/2020. Explicit wait테스트
            string platformName = "Windows";
            string deviceName = "WindowsPC";
            string app_id = "";

            //Test with explicit wait
            OpenQA.Selenium.Appium.AppiumOptions ao = new AppiumOptions();
            ao.AddAdditionalCapability("app", "Root");
            ao.AddAdditionalCapability("platformName", platformName);
            ao.AddAdditionalCapability("deviceName", deviceName);

            _deskTopSession = new WindowsDriver<WindowsElement>(new Uri(@"http://127.0.0.1:4723"), ao, TimeSpan.FromMinutes(10));

            var wait = new WebDriverWait(_deskTopSession, new TimeSpan(0, 12, 0));
            //var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(ByAccessibilityId.AccessibilityId("SystemSettings_Maps_Download_Add_Package_Button")));

            try
            {
                //GridViewItem을 접근한 경우
                //var gameElement = _deskTopSession.FindElementsByClassName("GridViewItem");
                //var currList = gameElement.ToList();

                //var gameElement = _deskTopSession.FindElementsByXPath("//Button[@AutomationId=\"_rootGrid\"]");
                //var gameElement = _deskTopSession.FindElementsByXPath("//*[@AutomationId=\"_rootGrid\"]");
                //var currList = gameElement.ToList();

                var gameElement = _deskTopSession.FindElementsByXPath("//Image[@AutomationId=\"_image\"]");
                var currList = gameElement.ToList();

                System.Diagnostics.Debug.WriteLine(string.Format("[Setting MenuList]List Count:{0}", currList.Count));

                int loop_counter = 0;

                foreach (var currItem in currList)
                {

                    if (loop_counter >= 10)

                    {

                        break; //exit internal loop for testing

                    }

                    //currItem.Click();
                    //var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(ByAccessibilityId.AccessibilityId("SystemSettings_Maps_Download_Add_Package_Button")));



                    loop_counter = loop_counter + 1;
                    //currItem.Click();
                    var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(currItem));
                    element.Click();


                    var elementBack = _deskTopSession.FindElementByAccessibilityId("NavigationViewBackButton");
                    elementBack.Click();



                    //Thread.Sleep(20000);

                }
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("Full Stacktrace: {0}", ex.ToString()));
            }





            //TOAN : 06/04/2020. old code-routin
            //this.initDeskTopSession();

            //try
            //{
            //    //This is test code
            //    //var gameElement = _deskTopSession.FindElementsByClassName("GridViewItem");
            //    //TOAN : 06/03/2020. ListItem을 가지고 오는 방식
            //    //var gameElement = _deskTopSession.FindElementsByXPath("//ListItem[@ClassName=\"GridViewItem\"]");
            //    //var currList = gameElement.ToList();

            //    //TOAN : 06/03/2020. Image을 가지고 오는 방식으로 변경
            //    //var element2 = _deskTopSession.FindElementByXPath("//Group[@Name=\"앱 및 기능\"]/List[@ClassName=\"ListView\"]//child::ListItem[1]//child::Text[4]");
            //    //var gameElement = _deskTopSession.FindElementsByXPath("//ListItem[@ClassName=\"GridViewItem\"]/Button[@AutomationId=\"_rootGrid\"]/Image[@AutomationId=\"_image\"]");
            //    var gameElement = _deskTopSession.FindElementsByXPath("//Image[@AutomationId=\"_image\"]");
            //    //_rootGrid
            //    //var gameElement = _deskTopSession.FindElementsByXPath("//Button[@AutomationId=\"_rootGrid\"]");
            //    var currList = gameElement.ToList();


            //    System.Diagnostics.Debug.WriteLine(string.Format("[Setting MenuList]List Count:{0}", currList.Count));
            //    int loop_counter = 0;



            //    //진입,나옴 반복 테스트 진행
            //    foreach (var currItem in currList)
            //    {
            //        if (loop_counter >= 10)
            //        {
            //            break; //exit internal loop for testing
            //        }
            //        loop_counter = loop_counter + 1;
            //        // _deskTopSession.Mouse.MouseMove(element.Coordinates);
            //        //_deskTopSession.Mouse.Click(currItem.Coordinates);
            //        currItem.Click();
            //        //currItem.Click(); //이클릭은 GridView전체을 클릭하는것

            //        //아래 코드는 gridview자체를 click하는 방법
            //        //이렇게 할 경우, 단추 이미지가 작은 경우는 클릭 이벤트를 처리하지 못한다.
            //        //string itemID = currItem.GetAttribute("AutomationId");
            //        //System.Diagnostics.Debug.WriteLine(string.Format("Automation ID:{0}", itemID));
            //        //var currTarget = _deskTopSession.FindElementByAccessibilityId(itemID);
            //        //System.Diagnostics.Debug.WriteLine(string.Format("Current Element ID:{0}", currTarget));
            //        //currTarget.Click();

            //        //session.FindElementByXPath("//Window[@AutomationId='TitleBar']");
            //        //var target = currItem.FindElementByXPath("/Button[@AutomationId=\"_rootGrid\"]");
            //        ////child::Button
            //        //var childElements = currItem.FindElementsByXPath("//child::Button");

            //        //var childElements = currItem.FindElementsByXPath("//child::*");
            //        //foreach (var currButton in childElements)
            //        //{

            //        //   string element_name = currButton.GetAttribute("Name");

            //        //    System.Diagnostics.Debug.WriteLine(string.Format("Button Name:{0}", element_name));

            //        //}

            //        //var target = currItem.FindElementByXPath("//Image[@AutomationId=\"_image\"]");
            //        //target.Click();

            //        //var element = _deskTopSession.FindElementByAccessibilityId("DynamicHeading_productTitle");
            //        //string itemName = element.GetAttribute("Name");

            //        //System.Diagnostics.Debug.WriteLine(string.Format("Current Application Name:{0}", itemName));


            //        //다시이전으로 back하기
            //        var elementBack = _deskTopSession.FindElementByAccessibilityId("NavigationViewBackButton");
            //        elementBack.Click();
            //    }

            //}
            //catch(Exception ex)
            //{
            //    System.Diagnostics.Debug.WriteLine(string.Format("Full Stacktrace: {0}", ex.ToString()));
            //}



        }

        private void Button3_Click(object sender, EventArgs e)
        {

            this.initDeskTopSession();

            
            try
            {
                //랭키 진입하기-나가기 동작만 순회코드 테스트
                //version 1. GridViewItem의 Control은 ListItem이다.
                var gameElements = _deskTopSession.FindElementsByXPath("//List[@AutomationId=\"AppList\"]//child::ListItem");
                //var currList = gameElement.ToList();

                //전체 게임목록 화면 Display
                //최초 Element접근 후 아래와 같이 접근 문제 없다.
                foreach (var currItem in gameElements)
                {
                    //string itemID = currItem.GetAttribute("AutomationId");
                    //currItem.GetAttribute("Name")
                    System.Diagnostics.Debug.WriteLine(string.Format("element name:{0}", currItem.GetAttribute("AutomationId")));
                    //element.Click();
                }

                gameElements[0].Click();  //Game Elemennt의 첫번째 아이템에 Click Event적용

                //이전화면으로 복귀
                var elementBack = _deskTopSession.FindElementByAccessibilityId("NavigationViewBackButton");
                elementBack.Click();
                Thread.Sleep(50000);

                //복귀한 후 다시 리스트를 출력해보자.
                foreach (var currItem in gameElements)
                {
                    System.Diagnostics.Debug.WriteLine(string.Format("element name:{0}", currItem.GetAttribute("AutomationId")));
                    //element.Click();
                }

                System.Diagnostics.Debug.WriteLine(string.Format("element name:{0}", gameElements[1].GetAttribute("AutomationId")));
                System.Diagnostics.Debug.WriteLine(string.Format("element name:{0}", gameElements[1].GetAttribute("Name")));

                //Thread.Sleep(50000);
                gameElements[1].Click();  //Game Elemennt의 첫번째 아이템에 Click Event적용

                //이전화면으로 복귀
                //var elementBack1 = _deskTopSession.FindElementByAccessibilityId("NavigationViewBackButton");
                //elementBack1.Click();


                //foreach (var currItem in gameElements)
                //{
                //    System.Diagnostics.Debug.WriteLine(string.Format("element name:{0}", currItem.GetAttribute("AutomationId")));
                //    //element.Click();
                //}

                //gameElements[2].Click();  //Game Elemennt의 첫번째 아이템에 Click Event적용

                ////이전화면으로 복귀
                //var elementBack2 = _deskTopSession.FindElementByAccessibilityId("NavigationViewBackButton");
                //elementBack2.Click();

                //foreach (var currItem in gameElements)
                //{
                //    System.Diagnostics.Debug.WriteLine(string.Format("element name:{0}", currItem.GetAttribute("AutomationId")));
                //    //element.Click();
                //}

                //gameElements[3].Click();  //Game Elemennt의 첫번째 아이템에 Click Event적용

                ////이전화면으로 복귀
                //var elementBack3 = _deskTopSession.FindElementByAccessibilityId("NavigationViewBackButton");
                //elementBack3.Click();

                //foreach (var currItem in gameElements)
                //{
                //    System.Diagnostics.Debug.WriteLine(string.Format("element name:{0}", currItem.GetAttribute("AutomationId")));
                //    //element.Click();
                //}

                //gameElements[4].Click();  //Game Elemennt의 첫번째 아이템에 Click Event적용

                ////이전화면으로 복귀
                //var elementBack4 = _deskTopSession.FindElementByAccessibilityId("NavigationViewBackButton");
                //elementBack4.Click();

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("Full Stacktrace: {0}", ex.ToString()));
            }

            //version 2
        }

       
        private void Button4_Click(object sender, EventArgs e)
        {
            //상세보기 진입 - 나오기 (개선버전)
            //step1 : 최초 GridView전체의 DOM정보 획득
            //step2 : DOM정보중 AutomationID별도 저장
            //step3 : AutomationID필요크기 만큼 루프 순회(DOM정보 갱신)
            //step4 : 루프안에서 해당 AutomationID에 해당하는 elment에 필요한 정보를 다시 획득
            //기존이슈 : 최초 획득한 GridView의 돔정보를 진입-나오기해서 사용하면 Driver단에서 에러가 발생한다.
            //DOM은 갱신되었는데, 실제 코드 정보는 최초 획득한 정보를 사용하고 있는 상황인듯 하다.

            //this.initDeskTopSession();
            string platformName = "Windows";
            string deviceName = "WindowsPC";
            string app_id = "";

            //Test with explicit wait
            OpenQA.Selenium.Appium.AppiumOptions ao = new AppiumOptions();
            ao.AddAdditionalCapability("app", "Root");
            ao.AddAdditionalCapability("platformName", platformName);
            ao.AddAdditionalCapability("deviceName", deviceName);

            _deskTopSession = new WindowsDriver<WindowsElement>(new Uri(@"http://127.0.0.1:4723"), ao, TimeSpan.FromMinutes(10));

            var wait = new WebDriverWait(_deskTopSession, new TimeSpan(0, 5, 0));

            List<string> _appList = new List<string>();
            int loop_counter = 0;

            //ExplicitWait을 선언했기 때문에 해당 방식이 지원하는 API만 사용한다.

            try
            {

                //step1
                var gameElements = _deskTopSession.FindElementsByXPath("//List[@AutomationId=\"AppList\"]//child::ListItem");
                //var currList = gameElement.ToList();

                //step2
                //약식 디버깅
                int index_counter = 0;
                foreach (var currItem in gameElements)
                {
                    //string itemID = currItem.GetAttribute("AutomationId");
                    //currItem.GetAttribute("Name")
                    if (index_counter >= 10)
                    {
                       
                        break; 
                    }
                    index_counter++;

                    System.Diagnostics.Debug.WriteLine(string.Format("element id:{0}", currItem.GetAttribute("AutomationId")));
                    System.Diagnostics.Debug.WriteLine(string.Format("element name:{0}", currItem.GetAttribute("Name")));
                    System.Diagnostics.Debug.WriteLine(string.Format("element offScreen:{0}", currItem.GetAttribute("IsOffscreen")));
                    System.Diagnostics.Debug.WriteLine(string.Format("Location X:{0},Location Y:{1}", currItem.Location.X,
                                                                      currItem.Location.Y));
                    _appList.Add(currItem.GetAttribute("AutomationId").ToString());
                    //element.Click();
                }

                //step3
                int applist_index = 0;

                foreach (string autoID in _appList)
                {

                    if (loop_counter >= 10)

                    {

                        break; //exit internal loop for testing

                    }

                    
                    loop_counter = loop_counter + 1;

                    System.Diagnostics.Debug.WriteLine(string.Format("App Automation ID:{0}", autoID));

                    //var celement = _deskTopSession.FindElementByAccessibilityId(autoID);
                    var celement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(ByAccessibilityId.AccessibilityId(autoID)));
                    //var celement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(ByAccessibilityId.AccessibilityId(autoID)));

                    if (celement.GetAttribute("IsOffscreen").ToString().Equals("True"))
                    {
                        //지금 제어하려고 하는 아이템은 화면에 보이지 않는다.
                        
                        string preElementID = _appList[applist_index - 1];
                        var preElement = _deskTopSession.FindElementByAccessibilityId(preElementID);
                        preElement.SendKeys(OpenQA.Selenium.Keys.Down);
                    }


                    var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(ByAccessibilityId.AccessibilityId(autoID)));
                    //var celement = _deskTopSession.FindElementByAccessibilityId(autoID);
                    //_deskTopSession.Mouse.MouseMove(celement.Coordinates);

                    System.Diagnostics.Debug.WriteLine(string.Format("App Name:{0}", element.GetAttribute("Name")));
                    element.Click();

                    System.Diagnostics.Debug.WriteLine(string.Format("Bla Bla Bla !!!!"));

                    //var elementBack = _deskTopSession.FindElementByAccessibilityId("NavigationViewBackButton");
                    //elementBack.Click();

                    var elementBack = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(ByAccessibilityId.AccessibilityId("NavigationViewBackButton")));
                    elementBack.Click();

                    applist_index = applist_index + 1;
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("Full Stacktrace: {0}", ex.ToString()));
            }

            


        }

        private void Button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Store화면 스크롤하기

            this.initDeskTopSession_Explicit();


            try
            {
                var gameElements = _deskTopSession.FindElementsByXPath("//List[@AutomationId=\"AppList\"]//child::ListItem");
                var element= _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(gameElements[0]));

                element.SendKeys(OpenQA.Selenium.Keys.Down);
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("Full Stacktrace: {0}", ex.ToString()));
            }

        }

        private void tabTestInfo_Click(object sender, EventArgs e)
        {

        }
    }
}