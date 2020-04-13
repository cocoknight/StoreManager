using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager
{
    class EnumSet
    {
        public enum CATEGORY
        {
            STORE_GAME = 0,
            STORE_ENTERTAINMENT,
            STORE_PRODUCTIVITY,
            STORE_ETC
        }

        public enum GAME_SUBCLASS
        {

        }

        public enum ENTERTAINMENT_SUBCLASS
        {

        }

        public enum STORE_PRODUCTIVITY_SUBCLASS
        {
        }


        public enum ActionMode
        {
            STORE_AUTOMATION_TEST,
            TEST_MAX
        }
    }
}
