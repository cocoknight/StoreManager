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
            this.button1 = new System.Windows.Forms.Button();
            this.txtEndDate = new System.Windows.Forms.TextBox();
            this.txtStartDate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboSubclass = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grpTestResult = new System.Windows.Forms.GroupBox();
            this.ResultListView = new System.Windows.Forms.ListView();
            this.tabTestResult = new System.Windows.Forms.TabPage();
            this.btnDeskTop = new System.Windows.Forms.Button();
            this.btnStoreSession = new System.Windows.Forms.Button();
            this.cmdRun = new System.Windows.Forms.Button();
            this.cmdUseCase = new System.Windows.Forms.Button();
            this.tabStoreHandler.SuspendLayout();
            this.tabTestInfo.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpTestResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabStoreHandler
            // 
            this.tabStoreHandler.Controls.Add(this.tabTestInfo);
            this.tabStoreHandler.Controls.Add(this.tabTestResult);
            this.tabStoreHandler.Location = new System.Drawing.Point(54, 29);
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
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.txtEndDate);
            this.groupBox2.Controls.Add(this.txtStartDate);
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
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(774, 24);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 20);
            this.button1.TabIndex = 12;
            this.button1.Text = "Calendar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // txtEndDate
            // 
            this.txtEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtEndDate.Location = new System.Drawing.Point(668, 26);
            this.txtEndDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Size = new System.Drawing.Size(78, 21);
            this.txtEndDate.TabIndex = 11;
            this.txtEndDate.TextChanged += new System.EventHandler(this.TxtEndDate_TextChanged);
            // 
            // txtStartDate
            // 
            this.txtStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtStartDate.Location = new System.Drawing.Point(564, 26);
            this.txtStartDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.Size = new System.Drawing.Size(78, 21);
            this.txtStartDate.TabIndex = 10;
            this.txtStartDate.TextChanged += new System.EventHandler(this.TxtStartDate_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(490, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Schedult : ";
            this.label3.Click += new System.EventHandler(this.Label3_Click);
            // 
            // cboCategory
            // 
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(81, 27);
            this.cboCategory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(144, 20);
            this.cboCategory.TabIndex = 1;
            this.cboCategory.SelectedIndexChanged += new System.EventHandler(this.CboCategory_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "대분류 : ";
            // 
            // cboSubclass
            // 
            this.cboSubclass.FormattingEnabled = true;
            this.cboSubclass.Location = new System.Drawing.Point(296, 28);
            this.cboSubclass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboSubclass.Name = "cboSubclass";
            this.cboSubclass.Size = new System.Drawing.Size(150, 20);
            this.cboSubclass.TabIndex = 3;
            this.cboSubclass.SelectedIndexChanged += new System.EventHandler(this.CboSubclass_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(242, 31);
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
            // tabTestResult
            // 
            this.tabTestResult.Location = new System.Drawing.Point(4, 22);
            this.tabTestResult.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabTestResult.Name = "tabTestResult";
            this.tabTestResult.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabTestResult.Size = new System.Drawing.Size(985, 488);
            this.tabTestResult.TabIndex = 1;
            this.tabTestResult.Text = "testResult";
            this.tabTestResult.UseVisualStyleBackColor = true;
            // 
            // btnDeskTop
            // 
            this.btnDeskTop.Location = new System.Drawing.Point(496, 556);
            this.btnDeskTop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeskTop.Name = "btnDeskTop";
            this.btnDeskTop.Size = new System.Drawing.Size(168, 18);
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
            this.btnStoreSession.Size = new System.Drawing.Size(130, 18);
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
            this.cmdRun.Size = new System.Drawing.Size(168, 18);
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
            this.cmdUseCase.Size = new System.Drawing.Size(168, 18);
            this.cmdUseCase.TabIndex = 22;
            this.cmdUseCase.Text = "Usecase(Explicit Wait)";
            this.cmdUseCase.UseVisualStyleBackColor = true;
            this.cmdUseCase.Click += new System.EventHandler(this.cmdUseCase_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1165, 585);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabStoreHandler;
        private System.Windows.Forms.TabPage tabTestInfo;
        private System.Windows.Forms.TabPage tabTestResult;
        private System.Windows.Forms.ComboBox cboSubclass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDeskTop;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox txtEndDate;
        public System.Windows.Forms.TextBox txtStartDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grpTestResult;
        private System.Windows.Forms.ListView ResultListView;
        private System.Windows.Forms.Button btnStoreSession;
        private System.Windows.Forms.Button cmdRun;
        private System.Windows.Forms.Button cmdUseCase;
    }
}

