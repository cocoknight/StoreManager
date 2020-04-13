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
using System.Threading.Tasks;

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

            this.compose_freegame_ranking();
            this.operateTestScenario(_store_test_list);
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
