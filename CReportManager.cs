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


        public void reportTestInfo()
        {
            _currRow = _startRow;
            _currCol = _startCol;

            //_testInfoDic.Clear();
            string testTile = _form1.txtTestTitle.Text;
            _ws.Cells[_currRow, _currCol] = testTile;

            _currRow += 1;
            _currCol = _startCol;
        }

        public void savetofile(string fName)
        {
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
