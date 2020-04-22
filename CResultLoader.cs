using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager
{
    //class CResultLoader
    //{

    //}

    class CResultLoader
    {
        private static readonly CResultLoader instance = new CResultLoader();
        public Form1 _form1;


        private CResultLoader()
        {
            System.Diagnostics.Debug.WriteLine(string.Format("CResultLoader Constructor(SingleTone)"));
        }

        public static CResultLoader Instance
        {
            get
            {
                return instance;
            }
        }

        public void connectUI(Form1 conn)
        {
            _form1 = conn;
        }


    }
}
