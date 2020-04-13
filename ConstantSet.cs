using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager
{
   
        static class Event_Type
        {
            public const string name = "t_name";
            public const string classname = "t_classname";
            public const string tagname = "t_tagname";
            public const string automation_id = "t_automation_id";
            public const string xpath = "t_xpath";
            public const string button = "t_button";
        }

        static class Event_Default_Value
        {
            public const string select = "v_select";
            public const string unselect = "v_unselect";
        }


        static class Element_Type
        {
            public const string button = "e_button";
            public const string editbox = "e_editbox";
            public const string slider = "e_slider";
            public const string scrollwrapper = "e_scrollwrapper";
        }

        static class Element_Action_Type
        {

            public const string click = "a_click";
            public const string context_click = "a_context_click"; //mouse right click
        }

        static class Assertion_Type
        {
            //Related with FindElement
            public const string name = "t_name";
            public const string classname = "t_classname";
            public const string tagname = "t_tagname";
            public const string automation_id = "t_automation_id";
            public const string xpath = "t_xpath";

            //public const string button = "t_button";

            //Related with FindElements(1개이상의 대상을 추출할 경우), FindElemets계열을 사용
            public const string name_s = "t_name_s";
            public const string classname_s = "t_classname_s";
            public const string tagname_s = "t_tagname_s";
            public const string automation_id_s = "t_automation_id_s";
            public const string xpath_s = "t_xpath_s";
        }

        static class Assertion_Element_Type
        {
            public const string button = "e_button";
            public const string editbox = "e_editbox";
            public const string slider = "e_slider";
            public const string scrollwrapper = "e_scrollwrapper";
        }

        static class Assertion_Element_Action_Type
        {
            public const string click = "a_click";
            public const string context_click = "a_context_click"; //mouse right click
        }


        static class Assertion_Value
        {
            public const string exist = "v_existence";
            public const string nonexistence = "v_nonexistence";
            public const string exist_reset = "v_exist_reset";
            public const string select = "v_select";
            public const string unselect = "v_unselect";
            public const string select_reset = "v_select_reset";   //assertion완료 후 명시적으로 alarm center를 재실행 하기 위함.
            public const string exist_action = "v_exist_action";
            public const string exist_action_reset = "v_exist_action_reset";
            public const string exist_menu = "v_exist_menu";
        }
    
}
