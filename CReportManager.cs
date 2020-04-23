/*********************************************************************************************************-- 
    
    Copyright (c) 2020, YongMin Kim. All rights reserved. 
    This file is licenced under a Creative Commons license: 
    http://creativecommons.org/licenses/by/2.5/ 

    *Description : This is main module for Store Automation
                  - Game Ranking, Application Ranking, etc
    2020-04-22: Make a report manager
  
--***********************************************************************************************************/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.ComponentModel;
using Microsoft.Office.Interop.Excel;
using System.IO;
using System.Windows.Forms;

namespace StoreManager
{
    //class CReportManager
    //{
    //}
    


    class CReportManager
    {
        private static readonly CReportManager instance = new CReportManager();
        public Form1 _form1;
        public System.ComponentModel.BackgroundWorker worker;
        public KeyList _keyList;


        protected Microsoft.Office.Interop.Excel.Application _app;
        protected Workbook _wb;
        protected Worksheet _ws;

        protected int _startRow;
        protected int _startCol;
        protected int _currRow;
        protected int _currCol;


        public Dictionary<string, string> _testInfoDic;
        public List<string> _testInfoColumnList;



        private CReportManager()
        {
            System.Diagnostics.Debug.WriteLine(string.Format("CReportManager Constructor(SingleTone)"));
            _keyList = KeyList.Instance;
            _testInfoDic = new Dictionary<string, string>();
            _testInfoColumnList = new List<string>();

            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);


            _startRow = 1;
            _startCol = 2; //B열부터 시작.

        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {

            Dictionary<string, string> argument = e.Argument as Dictionary<string, string>;
            string operation = argument[_keyList.k_worker_mode];
            string fName = argument[_keyList.k_test_result_name];

            System.Diagnostics.Debug.WriteLine(string.Format("Work Mode:{0}", operation));

            try
            {
                switch (operation)
                {
                    case "STORE_AUTOMATION_REPORT":
                        {
                            System.Diagnostics.Debug.WriteLine(string.Format("Run STORE_AUTOMATION_REPORT"));
                            this.reportTestResult(fName);

                            break;
                        }
                    default:
                        break;
                }

            }
            catch (Exception ex)
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

        public static CReportManager Instance
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


        public void reportTestResult(string fileName)
        {
            try
            {
                _app = new Microsoft.Office.Interop.Excel.Application();
                _wb = _app.Workbooks.Add(XlSheetType.xlWorksheet);
                _ws = (Worksheet)_app.ActiveSheet;
               this.reportTestInfo();
               this.reportFreeGame_ko();
               this.reportPaidApp_ko();
               
                //this.reportBOMTest_Result();
               this.savetofile(fileName);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("Full Stacktrace: {0}", ex.ToString()));
            }
            finally
            {
                //TOAN : 02/04/2020
                _wb.Close();
                _app.Quit();
            }
        }

        public void reportFreeGame_ko()
        {
            _currRow += 1;
            _currCol = _startCol;

            //k_store_category = "k_store_category";   //store대분류 (게임,엔터테인먼트,생산성,특가)
            //k_store_subclass = "k_store_subclass";   //store소분류 (최다판매게임,무료인기게임,유료인기게임,새롭고 주목할 만한 PC게임 등..)
            //k_store_app_name = "k_store_app_name";   //앱이름
            //k_sotre_app_manufacture = "k_sotre_app_manufacture";  //앱 제작사
            //k_store_app_category = "k_store_app_category";  //앱 유형(성격)
            //k_store_app_grade = "k_store_app_grade"; //앱 평점
            //k_store_app_review = "k_store_app_review"; //앱 평가 개수

            if (_form1.grpTestResult.Controls.ContainsKey("ResultListView"))
            {
                ListView BOMListView = (ListView)_form1.grpTestResult.Controls["ResultListView"];

                foreach (System.Windows.Forms.ListViewItem item in BOMListView.Items)
                {
                    _ws.Cells[_currRow, _startCol] = item.SubItems[0].Text;
                    _ws.Cells[_currRow, _startCol + 1] = item.SubItems[1].Text;
                    _ws.Cells[_currRow, _startCol + 2] = item.SubItems[2].Text;
                    _ws.Cells[_currRow, _startCol + 3] = item.SubItems[3].Text;
                    _ws.Cells[_currRow, _startCol + 4] = item.SubItems[4].Text;
                    _ws.Cells[_currRow, _startCol + 5] = item.SubItems[5].Text;
                    _ws.Cells[_currRow, _startCol + 6] = item.SubItems[6].Text;

                    _currRow += 1;
                }

            }




        }
        public void reportPaidGame_ko()
        {

            

        }

        public void reportFreeApp_ko()
        {

        }

        public void reportPaidApp_ko()
        {

        }


        public void reportFreeGame_us()
        {

        }
        public void reportPaidGame_us()
        {

        }

        public void reportFreeApp_us()
        {

        }

        public void reportPaidApp_us()
        {

        }


        public void reportTestInfo()
        {
            _currRow = _startRow;
            _currCol = _startCol;

            //_testInfoDic.Clear();
            string testTile = _form1.txtTestTitle.Text;
            _ws.Cells[_currRow, _currCol] = testTile;

            _currRow += 1;
            _currCol = _startCol;

            //k_store_category = "k_store_category";   //store대분류 (게임,엔터테인먼트,생산성,특가)
            //k_store_subclass = "k_store_subclass";   //store소분류 (최다판매게임,무료인기게임,유료인기게임,새롭고 주목할 만한 PC게임 등..)
            //k_store_app_name = "k_store_app_name";   //앱이름
            //k_sotre_app_manufacture = "k_sotre_app_manufacture";  //앱 제작사
            //k_store_app_category = "k_store_app_category";  //앱 유형(성격)
            //k_store_app_grade = "k_store_app_grade"; //앱 평점
            //k_store_app_review = "k_store_app_review"; //앱 평가 개수

            _ws.Cells[_currRow, _startCol] = "대분류";
            _ws.Cells[_currRow, _startCol + 1] = "분류";
            _ws.Cells[_currRow, _startCol + 2] = "앱이름";
            _ws.Cells[_currRow, _startCol + 3] = "제작사";
            _ws.Cells[_currRow, _startCol + 4] = "앱카테고리";
            _ws.Cells[_currRow, _startCol + 5] = "평점";
            _ws.Cells[_currRow, _startCol + 6] = "평가갯수";

         
        }

        public void savetofile(string fName)
        {

            //Range range = _ws.get_Range((object)_ws.Cells[_currRow, _currCol], (object)_ws.Cells[_currRow, _separatorWidth]);
            //Report Title을 제외하고 나머지 영역에 Border처리를 해야 한다.
            var rngAll = _ws.UsedRange;


            rngAll.Select();
            rngAll.Borders.LineStyle = 1;
            rngAll.Borders.ColorIndex = 1;
            rngAll.Font.Size = 10;
            _ws.Columns.AutoFit();

            //var fileName = @dirName + @"\report.xlsx";

            if (File.Exists(fName))
            {
                File.Delete(fName);
            }

            _wb.SaveAs(fName, XlFileFormat.xlWorkbookDefault,
                   Type.Missing,
                   Type.Missing,
                   true,
                   false,
                   /*XlSaveAsAccessMode.xlNoChange*/XlSaveAsAccessMode.xlExclusive,
                   XlSaveConflictResolution.xlLocalSessionChanges,
                   Type.Missing,
                   Type.Missing);

            System.Windows.Forms.MessageBox.Show("Your data has been suceesfully exported.",
                           "Message",
                           System.Windows.Forms.MessageBoxButtons.OK,
                           System.Windows.Forms.MessageBoxIcon.Information);
        }
    }
}
