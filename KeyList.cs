using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager
{
    public sealed class KeyList
    {
        private static readonly KeyList instance = new KeyList();


        private KeyList()
        {
            System.Diagnostics.Debug.WriteLine(string.Format("KeyList Constructor(SingleTone)"));

            k_config_name = "k_config_name";
            k_config_vale = "k_config_value";
            k_worker_mode = "k_worker_mode";

            //related with appium key
            //public string platformName = "";
            //public string deviceName = "";
            //public string packageName = "";
            k_appium_platform_name = "k_appium_platform_name";
            k_appium_device_name = "k_appium_device_name";
            k_appium_app_id = "k_appium_app_id";

            k_sw_item_id = "k_sw_item_id";
            k_sw_item_name = "k_sw_item_name";
            k_sw_item_version = "k_sw_item_version";
            k_sw_item_category = "k_sw_item_category";
            k_sw_item_fix = "k_sw_item_fix";

            k_su_sw_item_id = "k_sw_sw_item_id";
            k_su_sw_item_name = "k_su_sw_item_name";
            k_su_sw_item_version = "k_su_sw_item_version";
            k_su_sw_item_category = "k_su_k_sw_item_category";
            k_su_sw_status = "k_su_sw_status";


            k_bom_check = "k_bom_check";

            k_item_bg_color = "k_item_bg_color";

            k_singlebom_os = "Operating System";


            //related with xml and excel I/O
            k_model = "MODEL";
            k_test_device_type = "TEST_DEVICE_TYPE";
            k_test_stage = "TEST STAGE";
            k_sw_rd = "SWEM";
            k_sqe_pl = "PL";
            k_sqe_sub_pl = "SUB PL";
            k_start_date = "START DATE";
            k_end_date = "END DATE";
            k_test_part = "TEST PART";
            k_tester = "TESTER";

            k_item_found = "k_item_found";

            //Related with UITAutomation
            k_test_result = "k_test_result";
            k_test_scenario = "k_test_scenario";
            k_test_step = "k_test_step";
            k_auto_event = "k_auto_event";
            k_check_assertion = "k_check_assertion";
            k_auto_event_name = "k_auto_event_name";
            k_auto_event_type = "k_auto_event_type";
            k_auto_event_default_value = "k_auto_event_default_value";
            k_auto_event_value = "k_auto_event_value";
            k_auto_event_value_offset = "k_auto_event_value_offset";
            k_auto_element_type = "k_auto_element_type";
            k_auto_element_action_type = "k_auto_element_action_type";


            k_assertion_name = "k_assertion_name";
            k_assertion_type = "k_assertion_type";
            k_assertion_value = "k_assertion_value";
            k_assertion_element_type = "k_assertion_element_type";
            k_assertion_element_action_type = "k_assertion_element_action_type";

            k_assertion_element_value = "k_assertion_element_value";

            k_test_status = "k_test_status";

            k_update_percent = "k_update_percent";
            k_update_mode = "k_update_mode";

            //Related with MS Store Automation
            k_store_category = "k_store_category";   //store대분류 (게임,엔터테인먼트,생산성,특가)
            k_store_subclass = "k_store_subclass";   //store소분류 (최다판매게임,무료인기게임,유료인기게임,새롭고 주목할 만한 PC게임 등..)
            k_store_app_name = "k_store_app_name";   //앱이름
            k_sotre_app_manufacture = "k_sotre_app_manufacture";  //앱 제작사
            k_store_app_category = "k_store_app_category";  //앱 유형(성격)
            k_store_app_grade = "k_store_app_grade"; //앱 평점
            k_store_app_review = "k_store_app_review"; //앱 평가 개수
        }

        public static KeyList Instance
        {
            get

            {
                return instance;
            }
        }


        public string k_store_category
        {
            get;
            //set;
        }

        public string k_store_subclass
        {
            get;
            //set;
        }

        public string k_store_app_name
        {
            get;
            //set;
        }

        public string k_sotre_app_manufacture
        {
            get;
            //set;
        }

        public string k_store_app_category
        {
            get;
            //set;
        }

        public string k_store_app_grade
        {
            get;
            //set;
        }

        public string k_store_app_review
        {
            get;
            //set;
        }






        public string k_test_result
        {
            get;
            //set;
        }

        public string k_test_scenario
        {
            get;
            //set;
        }

        public string k_test_step
        {
            get;
            //set;
        }

        public string k_auto_event
        {
            get;
            //set;
        }

        public string k_check_assertion
        {
            get;
            //set;
        }

        public string k_auto_event_name
        {
            get;
            //set;
        }

        public string k_auto_event_type
        {
            get;
            //set;
        }

        public string k_auto_event_default_value
        {
            get;
            //set;
        }

        public string k_auto_event_value
        {
            get;
            //set;
        }

        public string k_auto_event_value_offset
        {
            get;
            //set;
        }


        public string k_auto_element_type
        {
            get;
            //set;
        }

        public string k_auto_element_action_type
        {
            get;
        }

        public string k_assertion_name
        {
            get;
            //set;

        }

        public string k_assertion_type
        {
            get;
            //set;

        }

        public string k_assertion_element_type
        {
            get;
            //set;

        }

        public string k_assertion_element_value
        {
            get;
            //set;

        }

        public string k_assertion_element_action_type
        {
            get;
        }


        public string k_assertion_value
        {
            get;
            //set;

        }

        public string k_test_status
        {
            get;
            //set;

        }

        public string k_update_percent
        {
            get;
            //set;

        }

        public string k_update_mode
        {
            get;
            //set;

        }


        public string k_sw_item_id
        {
            get;
            //set;
        }

        public string k_sw_item_name
        {
            get;
            //set;
        }

        public string k_sw_item_version
        {
            get;
            //set;
        }

        public string k_sw_item_category
        {
            get;
            //set;
        }


        public string k_sw_item_fix
        {
            get;
            //set;
        }


        public string k_su_sw_item_id
        {
            get;
            //set;
        }

        public string k_su_sw_item_name
        {
            get;
            //set;
        }

        public string k_su_sw_item_version
        {
            get;
            //set;
        }

        public string k_su_sw_item_category
        {
            get;
            //set;
        }


        public string k_su_sw_status
        {
            get;
            //set;
        }



        public string k_config_name
        {
            get;
            //set;
        }




        public string k_config_vale
        {
            get;
            //set;
        }

        public string k_worker_mode
        {
            get;
        }

        public string k_appium_platform_name
        {
            get;
        }

        public string k_appium_device_name
        {
            get;
        }

        public string k_appium_app_id
        {
            get;
        }

        public string k_bom_check
        {
            get;
        }

        public string k_item_bg_color
        {
            get;
        }

        public string k_singlebom_os
        {
            get;
        }

        public string k_model
        {
            get;
        }

        public string k_test_stage
        {
            get;
        }

        public string k_sw_rd
        {
            get;
        }

        public string k_sqe_pl
        {
            get;
        }

        public string k_sqe_sub_pl
        {
            get;
        }

        public string k_start_date
        {
            get;
        }

        public string k_end_date
        {
            get;
        }

        public string k_test_part
        {
            get;
        }

        public string k_tester
        {
            get;
        }

        public string k_sku
        {
            get;
        }

        public string k_test_device_type
        {
            get;
        }

        public string k_item_found
        {
            get;
        }


    } //end of class
}
