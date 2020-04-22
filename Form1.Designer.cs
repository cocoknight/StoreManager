namespace StoreManager
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabStoreHandler = new System.Windows.Forms.TabControl();
            this.tabTestInfo = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboSubclass = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grpTestResult = new System.Windows.Forms.GroupBox();
            this.ResultListView = new System.Windows.Forms.ListView();
            this.tabFreeGame = new System.Windows.Forms.TabPage();
            this.btnDeskTop = new System.Windows.Forms.Button();
            this.btnStoreSession = new System.Windows.Forms.Button();
            this.cmdRun = new System.Windows.Forms.Button();
            this.cmdUseCase = new System.Windows.Forms.Button();
            this.btnCategory = new System.Windows.Forms.Button();
            this.tabPaidGame = new System.Windows.Forms.TabPage();
            this.tabFreeApp = new System.Windows.Forms.TabPage();
            this.tabPaidApp = new System.Windows.Forms.TabPage();
            this.tabFreeApp_US = new System.Windows.Forms.TabPage();
            this.tabPaidApp_US = new System.Windows.Forms.TabPage();
            this.tabFreeGame_US = new System.Windows.Forms.TabPage();
            this.tabPaidGame_US = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.listView2 = new System.Windows.Forms.ListView();
            this.listView3 = new System.Windows.Forms.ListView();
            this.listView4 = new System.Windows.Forms.ListView();
            this.listView5 = new System.Windows.Forms.ListView();
            this.listView6 = new System.Windows.Forms.ListView();
            this.listView7 = new System.Windows.Forms.ListView();
            this.listView8 = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTestTitle = new System.Windows.Forms.TextBox();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.tabStoreHandler.SuspendLayout();
            this.tabTestInfo.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpTestResult.SuspendLayout();
            this.tabFreeGame.SuspendLayout();
            this.tabPaidGame.SuspendLayout();
            this.tabFreeApp.SuspendLayout();
            this.tabPaidApp.SuspendLayout();
            this.tabFreeApp_US.SuspendLayout();
            this.tabPaidApp_US.SuspendLayout();
            this.tabFreeGame_US.SuspendLayout();
            this.tabPaidGame_US.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabStoreHandler
            // 
            this.tabStoreHandler.Controls.Add(this.tabTestInfo);
            this.tabStoreHandler.Controls.Add(this.tabFreeApp);
            this.tabStoreHandler.Controls.Add(this.tabPaidApp);
            this.tabStoreHandler.Controls.Add(this.tabFreeGame);
            this.tabStoreHandler.Controls.Add(this.tabPaidGame);
            this.tabStoreHandler.Controls.Add(this.tabFreeApp_US);
            this.tabStoreHandler.Controls.Add(this.tabPaidApp_US);
            this.tabStoreHandler.Controls.Add(this.tabFreeGame_US);
            this.tabStoreHandler.Controls.Add(this.tabPaidGame_US);
            this.tabStoreHandler.Location = new System.Drawing.Point(58, 29);
            this.tabStoreHandler.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabStoreHandler.Name = "tabStoreHandler";
            this.tabStoreHandler.SelectedIndex = 0;
            this.tabStoreHandler.Size = new System.Drawing.Size(1072, 514);
            this.tabStoreHandler.TabIndex = 0;
            // 
            // tabTestInfo
            // 
            this.tabTestInfo.Controls.Add(this.groupBox2);
            this.tabTestInfo.Controls.Add(this.grpTestResult);
            this.tabTestInfo.Location = new System.Drawing.Point(4, 22);
            this.tabTestInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabTestInfo.Name = "tabTestInfo";
            this.tabTestInfo.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabTestInfo.Size = new System.Drawing.Size(1064, 488);
            this.tabTestInfo.TabIndex = 0;
            this.tabTestInfo.Text = "Test Information";
            this.tabTestInfo.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnRun);
            this.groupBox2.Controls.Add(this.btnReport);
            this.groupBox2.Controls.Add(this.txtTestTitle);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cboCategory);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cboSubclass);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(44, 5);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(987, 79);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Test Info";
            // 
            // cboCategory
            // 
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(86, 46);
            this.cboCategory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(144, 20);
            this.cboCategory.TabIndex = 1;
            this.cboCategory.SelectedIndexChanged += new System.EventHandler(this.CboCategory_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "대분류 : ";
            // 
            // cboSubclass
            // 
            this.cboSubclass.FormattingEnabled = true;
            this.cboSubclass.Location = new System.Drawing.Point(310, 46);
            this.cboSubclass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboSubclass.Name = "cboSubclass";
            this.cboSubclass.Size = new System.Drawing.Size(150, 20);
            this.cboSubclass.TabIndex = 3;
            this.cboSubclass.SelectedIndexChanged += new System.EventHandler(this.CboSubclass_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(251, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "소분류 : ";
            this.label2.Click += new System.EventHandler(this.Label2_Click);
            // 
            // grpTestResult
            // 
            this.grpTestResult.Controls.Add(this.ResultListView);
            this.grpTestResult.Location = new System.Drawing.Point(44, 89);
            this.grpTestResult.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpTestResult.Name = "grpTestResult";
            this.grpTestResult.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpTestResult.Size = new System.Drawing.Size(987, 384);
            this.grpTestResult.TabIndex = 4;
            this.grpTestResult.TabStop = false;
            this.grpTestResult.Text = "검색 결과";
            // 
            // ResultListView
            // 
            this.ResultListView.HideSelection = false;
            this.ResultListView.Location = new System.Drawing.Point(19, 18);
            this.ResultListView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ResultListView.Name = "ResultListView";
            this.ResultListView.Size = new System.Drawing.Size(946, 351);
            this.ResultListView.TabIndex = 0;
            this.ResultListView.UseCompatibleStateImageBehavior = false;
            // 
            // tabFreeGame
            // 
            this.tabFreeGame.Controls.Add(this.listView3);
            this.tabFreeGame.Location = new System.Drawing.Point(4, 22);
            this.tabFreeGame.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabFreeGame.Name = "tabFreeGame";
            this.tabFreeGame.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabFreeGame.Size = new System.Drawing.Size(1064, 488);
            this.tabFreeGame.TabIndex = 1;
            this.tabFreeGame.Text = "인기무료게임(KOR)";
            this.tabFreeGame.UseVisualStyleBackColor = true;
            // 
            // btnDeskTop
            // 
            this.btnDeskTop.Location = new System.Drawing.Point(496, 556);
            this.btnDeskTop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeskTop.Name = "btnDeskTop";
            this.btnDeskTop.Size = new System.Drawing.Size(168, 34);
            this.btnDeskTop.TabIndex = 19;
            this.btnDeskTop.Text = "Setup DeskTopSession";
            this.btnDeskTop.UseVisualStyleBackColor = true;
            this.btnDeskTop.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnStoreSession
            // 
            this.btnStoreSession.Location = new System.Drawing.Point(679, 556);
            this.btnStoreSession.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStoreSession.Name = "btnStoreSession";
            this.btnStoreSession.Size = new System.Drawing.Size(182, 34);
            this.btnStoreSession.TabIndex = 20;
            this.btnStoreSession.Text = "Setup StoreSession";
            this.btnStoreSession.UseVisualStyleBackColor = true;
            this.btnStoreSession.Click += new System.EventHandler(this.BtnStoreSession_Click);
            // 
            // cmdRun
            // 
            this.cmdRun.Location = new System.Drawing.Point(290, 556);
            this.cmdRun.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdRun.Name = "cmdRun";
            this.cmdRun.Size = new System.Drawing.Size(168, 34);
            this.cmdRun.TabIndex = 21;
            this.cmdRun.Text = "Run";
            this.cmdRun.UseVisualStyleBackColor = true;
            this.cmdRun.Click += new System.EventHandler(this.CmdRun_Click);
            // 
            // cmdUseCase
            // 
            this.cmdUseCase.Location = new System.Drawing.Point(58, 556);
            this.cmdUseCase.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmdUseCase.Name = "cmdUseCase";
            this.cmdUseCase.Size = new System.Drawing.Size(168, 34);
            this.cmdUseCase.TabIndex = 22;
            this.cmdUseCase.Text = "Usecase(Explicit Wait)";
            this.cmdUseCase.UseVisualStyleBackColor = true;
            this.cmdUseCase.Click += new System.EventHandler(this.cmdUseCase_Click);
            // 
            // btnCategory
            // 
            this.btnCategory.Location = new System.Drawing.Point(896, 556);
            this.btnCategory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCategory.Name = "btnCategory";
            this.btnCategory.Size = new System.Drawing.Size(182, 34);
            this.btnCategory.TabIndex = 23;
            this.btnCategory.Text = "Get Category";
            this.btnCategory.UseVisualStyleBackColor = true;
            this.btnCategory.Click += new System.EventHandler(this.BtnCategory_Click);
            // 
            // tabPaidGame
            // 
            this.tabPaidGame.Controls.Add(this.listView4);
            this.tabPaidGame.Location = new System.Drawing.Point(4, 22);
            this.tabPaidGame.Name = "tabPaidGame";
            this.tabPaidGame.Size = new System.Drawing.Size(1064, 488);
            this.tabPaidGame.TabIndex = 2;
            this.tabPaidGame.Text = "인기유료게임(KOR)";
            this.tabPaidGame.UseVisualStyleBackColor = true;
            // 
            // tabFreeApp
            // 
            this.tabFreeApp.Controls.Add(this.listView1);
            this.tabFreeApp.Location = new System.Drawing.Point(4, 22);
            this.tabFreeApp.Name = "tabFreeApp";
            this.tabFreeApp.Size = new System.Drawing.Size(1064, 488);
            this.tabFreeApp.TabIndex = 3;
            this.tabFreeApp.Text = "인기무료앱(KOR)";
            this.tabFreeApp.UseVisualStyleBackColor = true;
            // 
            // tabPaidApp
            // 
            this.tabPaidApp.Controls.Add(this.listView2);
            this.tabPaidApp.Location = new System.Drawing.Point(4, 22);
            this.tabPaidApp.Name = "tabPaidApp";
            this.tabPaidApp.Size = new System.Drawing.Size(1064, 488);
            this.tabPaidApp.TabIndex = 4;
            this.tabPaidApp.Text = "인기유료앱(KOR)";
            this.tabPaidApp.UseVisualStyleBackColor = true;
            // 
            // tabFreeApp_US
            // 
            this.tabFreeApp_US.Controls.Add(this.listView5);
            this.tabFreeApp_US.Location = new System.Drawing.Point(4, 22);
            this.tabFreeApp_US.Name = "tabFreeApp_US";
            this.tabFreeApp_US.Size = new System.Drawing.Size(1064, 488);
            this.tabFreeApp_US.TabIndex = 5;
            this.tabFreeApp_US.Text = "인기무료앱(US)";
            this.tabFreeApp_US.UseVisualStyleBackColor = true;
            // 
            // tabPaidApp_US
            // 
            this.tabPaidApp_US.Controls.Add(this.listView6);
            this.tabPaidApp_US.Location = new System.Drawing.Point(4, 22);
            this.tabPaidApp_US.Name = "tabPaidApp_US";
            this.tabPaidApp_US.Size = new System.Drawing.Size(1064, 488);
            this.tabPaidApp_US.TabIndex = 6;
            this.tabPaidApp_US.Text = "인기유료앱(US)";
            this.tabPaidApp_US.UseVisualStyleBackColor = true;
            // 
            // tabFreeGame_US
            // 
            this.tabFreeGame_US.Controls.Add(this.listView7);
            this.tabFreeGame_US.Location = new System.Drawing.Point(4, 22);
            this.tabFreeGame_US.Name = "tabFreeGame_US";
            this.tabFreeGame_US.Size = new System.Drawing.Size(1064, 488);
            this.tabFreeGame_US.TabIndex = 7;
            this.tabFreeGame_US.Text = "인기무료게임(US)";
            this.tabFreeGame_US.UseVisualStyleBackColor = true;
            // 
            // tabPaidGame_US
            // 
            this.tabPaidGame_US.Controls.Add(this.listView8);
            this.tabPaidGame_US.Location = new System.Drawing.Point(4, 22);
            this.tabPaidGame_US.Name = "tabPaidGame_US";
            this.tabPaidGame_US.Size = new System.Drawing.Size(1064, 488);
            this.tabPaidGame_US.TabIndex = 8;
            this.tabPaidGame_US.Text = "인기유료게임(US)";
            this.tabPaidGame_US.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(59, 69);
            this.listView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(946, 351);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // listView2
            // 
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(59, 69);
            this.listView2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(946, 351);
            this.listView2.TabIndex = 1;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // listView3
            // 
            this.listView3.HideSelection = false;
            this.listView3.Location = new System.Drawing.Point(59, 69);
            this.listView3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(946, 351);
            this.listView3.TabIndex = 1;
            this.listView3.UseCompatibleStateImageBehavior = false;
            // 
            // listView4
            // 
            this.listView4.HideSelection = false;
            this.listView4.Location = new System.Drawing.Point(59, 69);
            this.listView4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listView4.Name = "listView4";
            this.listView4.Size = new System.Drawing.Size(946, 351);
            this.listView4.TabIndex = 1;
            this.listView4.UseCompatibleStateImageBehavior = false;
            // 
            // listView5
            // 
            this.listView5.HideSelection = false;
            this.listView5.Location = new System.Drawing.Point(59, 69);
            this.listView5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listView5.Name = "listView5";
            this.listView5.Size = new System.Drawing.Size(946, 351);
            this.listView5.TabIndex = 1;
            this.listView5.UseCompatibleStateImageBehavior = false;
            // 
            // listView6
            // 
            this.listView6.HideSelection = false;
            this.listView6.Location = new System.Drawing.Point(59, 69);
            this.listView6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listView6.Name = "listView6";
            this.listView6.Size = new System.Drawing.Size(946, 351);
            this.listView6.TabIndex = 1;
            this.listView6.UseCompatibleStateImageBehavior = false;
            // 
            // listView7
            // 
            this.listView7.HideSelection = false;
            this.listView7.Location = new System.Drawing.Point(59, 69);
            this.listView7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listView7.Name = "listView7";
            this.listView7.Size = new System.Drawing.Size(946, 351);
            this.listView7.TabIndex = 1;
            this.listView7.UseCompatibleStateImageBehavior = false;
            // 
            // listView8
            // 
            this.listView8.HideSelection = false;
            this.listView8.Location = new System.Drawing.Point(59, 69);
            this.listView8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listView8.Name = "listView8";
            this.listView8.Size = new System.Drawing.Size(946, 351);
            this.listView8.TabIndex = 1;
            this.listView8.UseCompatibleStateImageBehavior = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "테스트 제목 : ";
            // 
            // txtTestTitle
            // 
            this.txtTestTitle.Location = new System.Drawing.Point(86, 17);
            this.txtTestTitle.Name = "txtTestTitle";
            this.txtTestTitle.Size = new System.Drawing.Size(619, 21);
            this.txtTestTitle.TabIndex = 5;
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(852, 33);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(102, 33);
            this.btnReport.TabIndex = 6;
            this.btnReport.Text = "Report";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(729, 33);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(102, 33);
            this.btnRun.TabIndex = 7;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(492, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "순위 : ";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(539, 46);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(166, 21);
            this.textBox2.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 616);
            this.Controls.Add(this.btnCategory);
            this.Controls.Add(this.cmdUseCase);
            this.Controls.Add(this.cmdRun);
            this.Controls.Add(this.btnStoreSession);
            this.Controls.Add(this.btnDeskTop);
            this.Controls.Add(this.tabStoreHandler);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Store Manager 1.0.0.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabStoreHandler.ResumeLayout(false);
            this.tabTestInfo.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpTestResult.ResumeLayout(false);
            this.tabFreeGame.ResumeLayout(false);
            this.tabPaidGame.ResumeLayout(false);
            this.tabFreeApp.ResumeLayout(false);
            this.tabPaidApp.ResumeLayout(false);
            this.tabFreeApp_US.ResumeLayout(false);
            this.tabPaidApp_US.ResumeLayout(false);
            this.tabFreeGame_US.ResumeLayout(false);
            this.tabPaidGame_US.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tabFreeGame;
        private System.Windows.Forms.ComboBox cboSubclass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDeskTop;
        private System.Windows.Forms.Button btnStoreSession;
        private System.Windows.Forms.Button cmdRun;
        private System.Windows.Forms.Button cmdUseCase;
        public System.Windows.Forms.GroupBox grpTestResult;
        public System.Windows.Forms.ListView ResultListView;
        public System.Windows.Forms.TabPage tabTestInfo;
        public System.Windows.Forms.TabControl tabStoreHandler;
        public System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCategory;
        private System.Windows.Forms.TabPage tabPaidGame;
        private System.Windows.Forms.TabPage tabFreeApp;
        private System.Windows.Forms.TabPage tabPaidApp;
        private System.Windows.Forms.TabPage tabFreeApp_US;
        private System.Windows.Forms.TabPage tabPaidApp_US;
        private System.Windows.Forms.TabPage tabFreeGame_US;
        private System.Windows.Forms.TabPage tabPaidGame_US;
        public System.Windows.Forms.ListView listView1;
        public System.Windows.Forms.ListView listView2;
        public System.Windows.Forms.ListView listView3;
        public System.Windows.Forms.ListView listView4;
        public System.Windows.Forms.ListView listView5;
        public System.Windows.Forms.ListView listView6;
        public System.Windows.Forms.ListView listView7;
        public System.Windows.Forms.ListView listView8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnReport;
        public System.Windows.Forms.TextBox txtTestTitle;
    }
}

