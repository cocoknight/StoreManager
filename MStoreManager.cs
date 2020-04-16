/*********************************************************************************************************-- 
    
    Copyright (c) 2020, YongMin Kim. All rights reserved. 
    This file is licenced under a Creative Commons license: 
    http://creativecommons.org/licenses/by/2.5/ 

    *Description : This is main module for Store Automation
                  - Game Ranking, Application Ranking, etc
    2020-04-13: Make a basic operation 
  
--***********************************************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;


using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;


namespace StoreManager
{
    class MStoreManager : BaseManager
    {
        private static readonly MStoreManager instance = new MStoreManager();
        public System.ComponentModel.BackgroundWorker worker;

        public List<Dictionary<string, object>> _store_test_list;
        public CUtility _myUtility;
        public KeyList _keyList;


        public string _categoryName = "";
        public string _subclassName = "";

        private MStoreManager():base()
        {
            System.Diagnostics.Debug.WriteLine(string.Format("CInstallManager Constructor(SingleTone)"));
            _store_test_list = new List<Dictionary<string, object>>();
            _myUtility = CUtility.Instance;
            _keyList = KeyList.Instance;


            //Related with Background Worker
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);

        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("Worker DoWork"));

            Dictionary<string, string> argument = e.Argument as Dictionary<string, string>;

            string operation = argument[_keyList.k_worker_mode];

            System.Diagnostics.Debug.WriteLine(string.Format("Work Mode:{0}", operation));

            try
            {
                _categoryName = argument[_keyList.k_store_category];
                _subclassName = argument[_keyList.k_store_subclass];

                switch (operation)
                {
                    case "STORE_AUTOMATION_TEST":
                        {
                            System.Diagnostics.Debug.WriteLine(string.Format("Run STORE_AUTOMATION_TEST"));
                            System.Diagnostics.Debug.WriteLine(string.Format("Category Name:{0}, Sub Class Name:{1}",_categoryName,_subclassName));
                            this.initDeskTopSession();
                            this.do_automation_parsing(argument);
                            break;
                        }
                    default:
                        break;
                }
            }catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("Full Stacktrace: {0}", ex.ToString()));
            }

        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("Progressed Changed"));
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("Run Completed"));

        }

        void do_automation_parsing(Dictionary<string, string> info)
        {
            _categoryName = info[_keyList.k_store_category];
            _subclassName = info[_keyList.k_store_subclass];

            switch(_categoryName)
            {
                case "게임":
                    {
                        switch(_subclassName)
                        {
                            case "무료인기게임":
                                {
                                    System.Diagnostics.Debug.WriteLine(string.Format("Run Free Popular Automation"));
                                    this.do_free_game_ranking();
                                    break;
                                }
                            case "유료인기게임":
                                {
                                    System.Diagnostics.Debug.WriteLine(string.Format("Paid Popular Automation"));
                                    this.do_paid_game_ranking();
                                    break;
                                }
                            default:
                                break;
                        }
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


        protected void operateTestScenario(List<Dictionary<string, object>> testlist)
                                
        {

        }

        void compose_free_game_ranking()
        {
            //compose testscenario
            Dictionary<string, object> item_testcase = new Dictionary<string, object>();
            item_testcase.Add(_keyList.k_test_scenario, "무료인기 게임순위");

            Dictionary<string, object> assertion_dic = new Dictionary<string, object>();
            assertion_dic.Add(_keyList.k_assertion_name, "시작");
            assertion_dic.Add(_keyList.k_assertion_type, Assertion_Type.name);
            assertion_dic.Add(_keyList.k_assertion_element_type, Assertion_Element_Type.button);
            assertion_dic.Add(_keyList.k_assertion_element_action_type, Assertion_Element_Action_Type.click); //해당 Element의 타입에 맞는 Action을 부여
            assertion_dic.Add(_keyList.k_assertion_value, Assertion_Value.exist_action); //target element의 id존재 여부를 찾고 있으면 Action수행

            Dictionary<string, object> assertion_dic1 = new Dictionary<string, object>();
            assertion_dic1.Add(_keyList.k_assertion_name, "tile-P~Microsoft.WindowsStore_8wekyb3d8bbwe!App");
            assertion_dic1.Add(_keyList.k_assertion_type, Assertion_Type.automation_id);
            assertion_dic1.Add(_keyList.k_assertion_element_type, Assertion_Element_Type.button);
            assertion_dic1.Add(_keyList.k_assertion_element_action_type, Assertion_Element_Action_Type.click); //해당 Element의 타입에 맞는 Action을 부여
            assertion_dic1.Add(_keyList.k_assertion_value, Assertion_Value.exist_action); //target element의 id존재 여부를 찾고 있으면 Action수행

            List<Dictionary<string, object>> assertion_list = new List<Dictionary<string, object>>();
            assertion_list.Add(assertion_dic);
            assertion_list.Add(assertion_dic1);
            //run testscenario

            item_testcase.Add(_keyList.k_check_assertion, assertion_list);
            //_store_test_list
            _store_test_list.Add(item_testcase);
        }


        void do_free_game_ranking()
        {


            //FOZA Horizon demo확인해 볼것(너무 길다)
            //Thread.sleep을 하면, implicitwait, expllicitwait logic까지 영향을 받는듯 하다.

            //TOAN : 04/14/2020. Below is not generalization code

            //TOAN : 04/14/2020. Below is generalization code
            //this.compose_freegame_ranking();
            //this.operateTestScenario(_store_test_list);

            System.Diagnostics.Debug.WriteLine(string.Format("do free game ranking"));


            try
            {
              
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

                //compose dictionary info
                //string categoryName = this.cboCategory.SelectedItem.ToString();
                //string subclassName = this.cboSubclass.SelectedItem.ToString();

                int loop_counter = 1;

               

                //Below is data fetch logic
                foreach (var currItem in currList)
                {
                    System.Diagnostics.Debug.WriteLine(string.Format("Data Fetch Logic Start:{0}", _myUtility.getCurrentTime()));

                    Dictionary<string, object> item_info = new Dictionary<string, object>();  //해당 아이템의 필요한 정보를 뽑아서 사전 형태로 저장

                    //item_info.Add(_keyList.k_store_category, categoryName);
                    //item_info.Add(_keyList.k_store_subclass, subclassName);
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
                    var currTarget = _deskTopSessoin.FindElementByAccessibilityId(itemID);
                    //currTarget이 유효한지 확인 해보자(미니언즈)
                    System.Diagnostics.Debug.WriteLine(string.Format("Current Element ID:{0}", currTarget));
                    currTarget.Click();

                    //currItem.Click(); //해당 Item의 상세 정보 보기로 진입 한다.

                    //get 1 depth목록
                    //Thread.Sleep(3000);

                    //var elements = _deskTopSessoin.FindElementsByXPath("//Button[@Name=\"NavigationControl\"]/child::*");
                    //var elements = _deskTopSessoin.FindElementsByXPath("//Group[@AutomationId=\"pdp\"]//child::*");       //This is OK 
                    //var elements = _deskTopSessoin.FindElementByAccessibilityId("pdp").FindElementsByXPath("//*");      //This is OK
                    //var elements = _deskTopSessoin.FindElementByAccessibilityId("pdp").FindElementsByXPath("//child::*"); //This is OK

                    //step1 : get App Title
                    System.Diagnostics.Debug.WriteLine(string.Format("DynamicHeading_productTitle Element Find Start:{0}", _myUtility.getCurrentTime()));
                    var element = _deskTopSessoin.FindElementByAccessibilityId("DynamicHeading_productTitle");
                    string itemName = element.GetAttribute("Name");

                    item_info.Add(_keyList.k_store_app_name, itemName.ToString());

                    //var elements = element.FindElementsByXPath("/following-sibling::*");
                    //var elements = _deskTopSessoin.FindElementsByXPath("//Text[@AutomationId=\"DynamicHeading_productTitle\"]/following-sibling::*"); //This is OK

                    //click한 이후에 형제 element들을 가지고 온ㄷ.
                    System.Diagnostics.Debug.WriteLine(string.Format("[형제]DynamicHeading_productTitle Sibling Find Start:{0}", _myUtility.getCurrentTime()));
                    var elements = _deskTopSessoin.FindElementsByXPath("//Text[@AutomationId=\"DynamicHeading_productTitle\"]//following-sibling::*"); //This is OK

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
                    //_store_list.Add(item_info);

                    //다시 이전 gridview로 전환
                    var elementBack = _deskTopSessoin.FindElementByAccessibilityId("NavigationViewBackButton");
                    elementBack.Click();
                    //Thread.Sleep(2000);
                    //Thread.Sleep(/*5000*/8000);
                    //TO DO : Add Dictionary to List

                    //1번만 하고 종료 시킬려고 break문 사용(test용도)
                    //break;
                    System.Diagnostics.Debug.WriteLine(string.Format("Loop Counter:{0}", loop_counter));
                    loop_counter = loop_counter + 1;
                    System.Diagnostics.Debug.WriteLine(string.Format("Data Fetch Logic End:{0}", _myUtility.getCurrentTime()));
                } //end of element search

                


            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("Full Stacktrace: {0}", ex.ToString()));
                System.Diagnostics.Debug.WriteLine(string.Format("Exception Occurred Time:{0}", _myUtility.getCurrentTime()));
            }
            finally
            {

            }












        }


        void do_paid_game_ranking()
        {

        }

        public MStoreManager(EnumSet.CATEGORY category) : base(category)
        {

        }
        public static MStoreManager Instance
        {
            get
            {
                return instance;
            }
        }

        //Below is scenario composition
        //Free Popular Game Ranking
        void compose_freegame_ranking()
        {
            Dictionary<string, object> item_testcase = new Dictionary<string, object>();
            item_testcase.Add(_keyList.k_test_scenario, "Microsoft Store실행 - 게임 - 무료인기 게임 ");

            Dictionary<string, object> assertion_dic = new Dictionary<string, object>();
            assertion_dic.Add(_keyList.k_assertion_name, "알림 센터");
            assertion_dic.Add(_keyList.k_assertion_type, Assertion_Type.name);
            assertion_dic.Add(_keyList.k_assertion_element_type, Assertion_Element_Type.button);
            assertion_dic.Add(_keyList.k_assertion_element_action_type, Assertion_Element_Action_Type.click); //해당 Element의 타입에 맞는 Action을 부여
            assertion_dic.Add(_keyList.k_assertion_value, Assertion_Value.exist_action); //target element의 id존재 여부를 찾고 있으면 Action수행
        }



    }
}
