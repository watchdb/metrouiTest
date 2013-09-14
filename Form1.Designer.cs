using MetroFramework.Controls;
using System.IO;
namespace MetroUITest
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (!debug && Directory.Exists(TempleteFileDir))
            {
                Directory.Delete(TempleteFileDir, true);
            }          

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.exportDataBtn = new MetroFramework.Controls.MetroButton();
            this.tabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.tabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.button1 = new MetroFramework.Controls.MetroButton();
            this.exportBeginDate = new System.Windows.Forms.DateTimePicker();
            this.exportEndDate = new System.Windows.Forms.DateTimePicker();
            this.toLabel = new MetroFramework.Controls.MetroLabel();
            this.exportLastDaysLbl = new MetroFramework.Controls.MetroLabel();
            this.progressBar1 = new MetroFramework.Controls.MetroProgressSpinner();
            this.importDataBtn = new MetroFramework.Controls.MetroButton();
            this.tabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.configTestBtn = new MetroFramework.Controls.MetroButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ftpDirTxt = new System.Windows.Forms.TextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.ftpPasswordTxt = new System.Windows.Forms.TextBox();
            this.ftpPasswordLbl = new MetroFramework.Controls.MetroLabel();
            this.ftpUserTxt = new System.Windows.Forms.TextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.ftpIpTxt = new System.Windows.Forms.TextBox();
            this.ftpIPLbl = new MetroFramework.Controls.MetroLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dbPasswordTxt = new System.Windows.Forms.TextBox();
            this.dbPasswordLbl = new MetroFramework.Controls.MetroLabel();
            this.dbUserTxt = new System.Windows.Forms.TextBox();
            this.dbUserLbl = new MetroFramework.Controls.MetroLabel();
            this.dbSidTxt = new System.Windows.Forms.TextBox();
            this.dbSidLbl = new MetroFramework.Controls.MetroLabel();
            this.oracleConnection1 = new System.Data.OracleClient.OracleConnection();
            this.systemWarnLbl = new MetroFramework.Controls.MetroLabel();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // exportDataBtn
            // 
            this.exportDataBtn.Highlight = false;
            this.exportDataBtn.Location = new System.Drawing.Point(357, 217);
            this.exportDataBtn.Name = "exportDataBtn";
            this.exportDataBtn.Size = new System.Drawing.Size(75, 23);
            this.exportDataBtn.Style = MetroFramework.MetroColorStyle.Blue;
            this.exportDataBtn.StyleManager = null;
            this.exportDataBtn.TabIndex = 0;
            this.exportDataBtn.Text = "导出";
            this.exportDataBtn.Theme = MetroFramework.MetroThemeStyle.Light;
            this.exportDataBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.CustomBackground = false;
            this.tabControl1.FontSize = MetroFramework.MetroTabControlSize.Medium;
            this.tabControl1.FontWeight = MetroFramework.MetroTabControlWeight.Light;
            this.tabControl1.Location = new System.Drawing.Point(20, 70);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(493, 313);
            this.tabControl1.Style = MetroFramework.MetroColorStyle.Blue;
            this.tabControl1.StyleManager = null;
            this.tabControl1.TabIndex = 0;
            this.tabControl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tabControl1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tabControl1.UseStyleColors = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.systemWarnLbl);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.exportBeginDate);
            this.tabPage1.Controls.Add(this.exportEndDate);
            this.tabPage1.Controls.Add(this.toLabel);
            this.tabPage1.Controls.Add(this.exportLastDaysLbl);
            this.tabPage1.Controls.Add(this.progressBar1);
            this.tabPage1.Controls.Add(this.importDataBtn);
            this.tabPage1.Controls.Add(this.exportDataBtn);
            this.tabPage1.CustomBackground = false;
            this.tabPage1.HorizontalScrollbar = false;
            this.tabPage1.HorizontalScrollbarBarColor = true;
            this.tabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.tabPage1.HorizontalScrollbarSize = 10;
            this.tabPage1.Location = new System.Drawing.Point(4, 36);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(485, 273);
            this.tabPage1.Style = MetroFramework.MetroColorStyle.Blue;
            this.tabPage1.StyleManager = null;
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "开始";
            this.tabPage1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.VerticalScrollbar = false;
            this.tabPage1.VerticalScrollbarBarColor = true;
            this.tabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.tabPage1.VerticalScrollbarSize = 10;
            // 
            // button1
            // 
            this.button1.Highlight = false;
            this.button1.Location = new System.Drawing.Point(358, 115);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.Style = MetroFramework.MetroColorStyle.Blue;
            this.button1.StyleManager = null;
            this.button1.TabIndex = 108;
            this.button1.Text = "测试";
            this.button1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // exportBeginDate
            // 
            this.exportBeginDate.CustomFormat = "yyyy-MM-dd";
            this.exportBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.exportBeginDate.Location = new System.Drawing.Point(93, 19);
            this.exportBeginDate.Name = "exportBeginDate";
            this.exportBeginDate.Size = new System.Drawing.Size(99, 21);
            this.exportBeginDate.TabIndex = 107;
            // 
            // exportEndDate
            // 
            this.exportEndDate.CustomFormat = "yyyy-MM-dd";
            this.exportEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.exportEndDate.Location = new System.Drawing.Point(224, 19);
            this.exportEndDate.Name = "exportEndDate";
            this.exportEndDate.Size = new System.Drawing.Size(98, 21);
            this.exportEndDate.TabIndex = 105;
            // 
            // toLabel
            // 
            this.toLabel.AutoSize = true;
            this.toLabel.CustomBackground = false;
            this.toLabel.CustomForeColor = false;
            this.toLabel.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.toLabel.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.toLabel.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.toLabel.Location = new System.Drawing.Point(197, 19);
            this.toLabel.Name = "toLabel";
            this.toLabel.Size = new System.Drawing.Size(23, 19);
            this.toLabel.Style = MetroFramework.MetroColorStyle.Blue;
            this.toLabel.StyleManager = null;
            this.toLabel.TabIndex = 104;
            this.toLabel.Text = "至";
            this.toLabel.Theme = MetroFramework.MetroThemeStyle.Light;
            this.toLabel.UseStyleColors = false;
            // 
            // exportLastDaysLbl
            // 
            this.exportLastDaysLbl.AutoSize = true;
            this.exportLastDaysLbl.CustomBackground = false;
            this.exportLastDaysLbl.CustomForeColor = false;
            this.exportLastDaysLbl.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.exportLastDaysLbl.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.exportLastDaysLbl.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.exportLastDaysLbl.Location = new System.Drawing.Point(7, 19);
            this.exportLastDaysLbl.Name = "exportLastDaysLbl";
            this.exportLastDaysLbl.Size = new System.Drawing.Size(93, 19);
            this.exportLastDaysLbl.Style = MetroFramework.MetroColorStyle.Blue;
            this.exportLastDaysLbl.StyleManager = null;
            this.exportLastDaysLbl.TabIndex = 2;
            this.exportLastDaysLbl.Text = "导出的日期：";
            this.exportLastDaysLbl.Theme = MetroFramework.MetroThemeStyle.Light;
            this.exportLastDaysLbl.UseStyleColors = false;
            // 
            // progressBar1
            // 
            this.progressBar1.CustomBackground = false;
            this.progressBar1.Location = new System.Drawing.Point(441, 217);
            this.progressBar1.Maximum = 100;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(23, 23);
            this.progressBar1.Speed = 1.5F;
            this.progressBar1.Style = MetroFramework.MetroColorStyle.Blue;
            this.progressBar1.StyleManager = null;
            this.progressBar1.TabIndex = 100;
            this.progressBar1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.progressBar1.Value = 40;
            // 
            // importDataBtn
            // 
            this.importDataBtn.Highlight = false;
            this.importDataBtn.Location = new System.Drawing.Point(357, 217);
            this.importDataBtn.Name = "importDataBtn";
            this.importDataBtn.Size = new System.Drawing.Size(75, 23);
            this.importDataBtn.Style = MetroFramework.MetroColorStyle.Blue;
            this.importDataBtn.StyleManager = null;
            this.importDataBtn.TabIndex = 101;
            this.importDataBtn.Text = "导入";
            this.importDataBtn.Theme = MetroFramework.MetroThemeStyle.Light;
            this.importDataBtn.Click += new System.EventHandler(this.importDataBtn_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.configTestBtn);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.CustomBackground = false;
            this.tabPage2.HorizontalScrollbar = false;
            this.tabPage2.HorizontalScrollbarBarColor = true;
            this.tabPage2.HorizontalScrollbarHighlightOnWheel = false;
            this.tabPage2.HorizontalScrollbarSize = 10;
            this.tabPage2.Location = new System.Drawing.Point(4, 36);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(485, 273);
            this.tabPage2.Style = MetroFramework.MetroColorStyle.Blue;
            this.tabPage2.StyleManager = null;
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "选项";
            this.tabPage2.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.VerticalScrollbar = false;
            this.tabPage2.VerticalScrollbarBarColor = true;
            this.tabPage2.VerticalScrollbarHighlightOnWheel = false;
            this.tabPage2.VerticalScrollbarSize = 10;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.metroLabel3);
            this.groupBox3.Location = new System.Drawing.Point(6, 165);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(204, 86);
            this.groupBox3.TabIndex = 110;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "导出配置";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(77, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(95, 21);
            this.textBox1.TabIndex = 12;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.CustomBackground = false;
            this.metroLabel3.CustomForeColor = false;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.metroLabel3.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel3.Location = new System.Drawing.Point(13, 24);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(51, 19);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel3.StyleManager = null;
            this.metroLabel3.TabIndex = 11;
            this.metroLabel3.Text = "天数：";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel3.UseStyleColors = false;
            // 
            // configTestBtn
            // 
            this.configTestBtn.Highlight = false;
            this.configTestBtn.Location = new System.Drawing.Point(407, 228);
            this.configTestBtn.Name = "configTestBtn";
            this.configTestBtn.Size = new System.Drawing.Size(61, 23);
            this.configTestBtn.Style = MetroFramework.MetroColorStyle.Blue;
            this.configTestBtn.StyleManager = null;
            this.configTestBtn.TabIndex = 109;
            this.configTestBtn.Text = "配置自检";
            this.configTestBtn.Theme = MetroFramework.MetroThemeStyle.Light;
            this.configTestBtn.Click += new System.EventHandler(this.configTestBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ftpDirTxt);
            this.groupBox1.Controls.Add(this.metroLabel2);
            this.groupBox1.Controls.Add(this.ftpPasswordTxt);
            this.groupBox1.Controls.Add(this.ftpPasswordLbl);
            this.groupBox1.Controls.Add(this.ftpUserTxt);
            this.groupBox1.Controls.Add(this.metroLabel1);
            this.groupBox1.Controls.Add(this.ftpIpTxt);
            this.groupBox1.Controls.Add(this.ftpIPLbl);
            this.groupBox1.Location = new System.Drawing.Point(250, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(218, 168);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FTP配置信息";
            // 
            // ftpDirTxt
            // 
            this.ftpDirTxt.Enabled = false;
            this.ftpDirTxt.Location = new System.Drawing.Point(81, 131);
            this.ftpDirTxt.Name = "ftpDirTxt";
            this.ftpDirTxt.Size = new System.Drawing.Size(120, 21);
            this.ftpDirTxt.TabIndex = 10;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.CustomBackground = false;
            this.metroLabel2.CustomForeColor = false;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.metroLabel2.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel2.Location = new System.Drawing.Point(9, 131);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(51, 19);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel2.StyleManager = null;
            this.metroLabel2.TabIndex = 9;
            this.metroLabel2.Text = "目录：";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel2.UseStyleColors = false;
            // 
            // ftpPasswordTxt
            // 
            this.ftpPasswordTxt.Enabled = false;
            this.ftpPasswordTxt.Location = new System.Drawing.Point(81, 95);
            this.ftpPasswordTxt.Name = "ftpPasswordTxt";
            this.ftpPasswordTxt.PasswordChar = '*';
            this.ftpPasswordTxt.Size = new System.Drawing.Size(120, 21);
            this.ftpPasswordTxt.TabIndex = 8;
            // 
            // ftpPasswordLbl
            // 
            this.ftpPasswordLbl.AutoSize = true;
            this.ftpPasswordLbl.CustomBackground = false;
            this.ftpPasswordLbl.CustomForeColor = false;
            this.ftpPasswordLbl.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.ftpPasswordLbl.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.ftpPasswordLbl.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.ftpPasswordLbl.Location = new System.Drawing.Point(9, 95);
            this.ftpPasswordLbl.Name = "ftpPasswordLbl";
            this.ftpPasswordLbl.Size = new System.Drawing.Size(55, 19);
            this.ftpPasswordLbl.Style = MetroFramework.MetroColorStyle.Blue;
            this.ftpPasswordLbl.StyleManager = null;
            this.ftpPasswordLbl.TabIndex = 7;
            this.ftpPasswordLbl.Text = "密码 ：";
            this.ftpPasswordLbl.Theme = MetroFramework.MetroThemeStyle.Light;
            this.ftpPasswordLbl.UseStyleColors = false;
            // 
            // ftpUserTxt
            // 
            this.ftpUserTxt.Enabled = false;
            this.ftpUserTxt.Location = new System.Drawing.Point(81, 61);
            this.ftpUserTxt.Name = "ftpUserTxt";
            this.ftpUserTxt.Size = new System.Drawing.Size(120, 21);
            this.ftpUserTxt.TabIndex = 6;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.CustomBackground = false;
            this.metroLabel1.CustomForeColor = false;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.metroLabel1.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.metroLabel1.Location = new System.Drawing.Point(6, 61);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(69, 19);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel1.StyleManager = null;
            this.metroLabel1.TabIndex = 5;
            this.metroLabel1.Text = "用户名 ：";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel1.UseStyleColors = false;
            // 
            // ftpIpTxt
            // 
            this.ftpIpTxt.Enabled = false;
            this.ftpIpTxt.Location = new System.Drawing.Point(81, 26);
            this.ftpIpTxt.Name = "ftpIpTxt";
            this.ftpIpTxt.Size = new System.Drawing.Size(120, 21);
            this.ftpIpTxt.TabIndex = 4;
            // 
            // ftpIPLbl
            // 
            this.ftpIPLbl.AutoSize = true;
            this.ftpIPLbl.CustomBackground = false;
            this.ftpIPLbl.CustomForeColor = false;
            this.ftpIPLbl.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.ftpIPLbl.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.ftpIPLbl.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.ftpIPLbl.Location = new System.Drawing.Point(9, 26);
            this.ftpIPLbl.Name = "ftpIPLbl";
            this.ftpIPLbl.Size = new System.Drawing.Size(66, 19);
            this.ftpIPLbl.Style = MetroFramework.MetroColorStyle.Blue;
            this.ftpIPLbl.StyleManager = null;
            this.ftpIPLbl.TabIndex = 3;
            this.ftpIPLbl.Text = "IP 地址：";
            this.ftpIPLbl.Theme = MetroFramework.MetroThemeStyle.Light;
            this.ftpIPLbl.UseStyleColors = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dbPasswordTxt);
            this.groupBox2.Controls.Add(this.dbPasswordLbl);
            this.groupBox2.Controls.Add(this.dbUserTxt);
            this.groupBox2.Controls.Add(this.dbUserLbl);
            this.groupBox2.Controls.Add(this.dbSidTxt);
            this.groupBox2.Controls.Add(this.dbSidLbl);
            this.groupBox2.Location = new System.Drawing.Point(6, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(204, 135);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "数据库配置";
            // 
            // dbPasswordTxt
            // 
            this.dbPasswordTxt.Enabled = false;
            this.dbPasswordTxt.Location = new System.Drawing.Point(77, 97);
            this.dbPasswordTxt.Name = "dbPasswordTxt";
            this.dbPasswordTxt.PasswordChar = '*';
            this.dbPasswordTxt.Size = new System.Drawing.Size(95, 21);
            this.dbPasswordTxt.TabIndex = 10;
            // 
            // dbPasswordLbl
            // 
            this.dbPasswordLbl.AutoSize = true;
            this.dbPasswordLbl.CustomBackground = false;
            this.dbPasswordLbl.CustomForeColor = false;
            this.dbPasswordLbl.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.dbPasswordLbl.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.dbPasswordLbl.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.dbPasswordLbl.Location = new System.Drawing.Point(6, 97);
            this.dbPasswordLbl.Name = "dbPasswordLbl";
            this.dbPasswordLbl.Size = new System.Drawing.Size(67, 19);
            this.dbPasswordLbl.Style = MetroFramework.MetroColorStyle.Blue;
            this.dbPasswordLbl.StyleManager = null;
            this.dbPasswordLbl.TabIndex = 9;
            this.dbPasswordLbl.Text = "密    码：";
            this.dbPasswordLbl.Theme = MetroFramework.MetroThemeStyle.Light;
            this.dbPasswordLbl.UseStyleColors = false;
            // 
            // dbUserTxt
            // 
            this.dbUserTxt.Enabled = false;
            this.dbUserTxt.Location = new System.Drawing.Point(77, 61);
            this.dbUserTxt.Name = "dbUserTxt";
            this.dbUserTxt.Size = new System.Drawing.Size(95, 21);
            this.dbUserTxt.TabIndex = 8;
            // 
            // dbUserLbl
            // 
            this.dbUserLbl.AutoSize = true;
            this.dbUserLbl.CustomBackground = false;
            this.dbUserLbl.CustomForeColor = false;
            this.dbUserLbl.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.dbUserLbl.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.dbUserLbl.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.dbUserLbl.Location = new System.Drawing.Point(6, 63);
            this.dbUserLbl.Name = "dbUserLbl";
            this.dbUserLbl.Size = new System.Drawing.Size(65, 19);
            this.dbUserLbl.Style = MetroFramework.MetroColorStyle.Blue;
            this.dbUserLbl.StyleManager = null;
            this.dbUserLbl.TabIndex = 7;
            this.dbUserLbl.Text = "用户名：";
            this.dbUserLbl.Theme = MetroFramework.MetroThemeStyle.Light;
            this.dbUserLbl.UseStyleColors = false;
            // 
            // dbSidTxt
            // 
            this.dbSidTxt.Enabled = false;
            this.dbSidTxt.Location = new System.Drawing.Point(77, 26);
            this.dbSidTxt.Name = "dbSidTxt";
            this.dbSidTxt.Size = new System.Drawing.Size(95, 21);
            this.dbSidTxt.TabIndex = 6;
            // 
            // dbSidLbl
            // 
            this.dbSidLbl.AutoSize = true;
            this.dbSidLbl.CustomBackground = false;
            this.dbSidLbl.CustomForeColor = false;
            this.dbSidLbl.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.dbSidLbl.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.dbSidLbl.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.dbSidLbl.Location = new System.Drawing.Point(6, 28);
            this.dbSidLbl.Name = "dbSidLbl";
            this.dbSidLbl.Size = new System.Drawing.Size(79, 19);
            this.dbSidLbl.Style = MetroFramework.MetroColorStyle.Blue;
            this.dbSidLbl.StyleManager = null;
            this.dbSidLbl.TabIndex = 5;
            this.dbSidLbl.Text = "数据库名：";
            this.dbSidLbl.Theme = MetroFramework.MetroThemeStyle.Light;
            this.dbSidLbl.UseStyleColors = false;
            // 
            // systemWarnLbl
            // 
            this.systemWarnLbl.AutoSize = true;
            this.systemWarnLbl.CustomBackground = false;
            this.systemWarnLbl.CustomForeColor = false;
            this.systemWarnLbl.FontSize = MetroFramework.MetroLabelSize.Medium;
            this.systemWarnLbl.FontWeight = MetroFramework.MetroLabelWeight.Light;
            this.systemWarnLbl.LabelMode = MetroFramework.Controls.MetroLabelMode.Default;
            this.systemWarnLbl.Location = new System.Drawing.Point(126, 111);
            this.systemWarnLbl.Name = "systemWarnLbl";
            this.systemWarnLbl.Size = new System.Drawing.Size(163, 19);
            this.systemWarnLbl.Style = MetroFramework.MetroColorStyle.Blue;
            this.systemWarnLbl.StyleManager = null;
            this.systemWarnLbl.TabIndex = 109;
            this.systemWarnLbl.Text = "系统运行中，请勿操作！";
            this.systemWarnLbl.Theme = MetroFramework.MetroThemeStyle.Light;
            this.systemWarnLbl.UseStyleColors = false;
            this.systemWarnLbl.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 399);
            this.Controls.Add(this.tabControl1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Resizable = false;
            this.Text = "ZJS Data Export";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroButton exportDataBtn;
        private MetroTabControl tabControl1;
        private MetroTabPage tabPage1;
        private MetroTabPage tabPage2;
        private System.Data.OracleClient.OracleConnection oracleConnection1;
        private MetroLabel exportLastDaysLbl;
        private MetroProgressSpinner progressBar1;
        private MetroButton importDataBtn;
        private System.Windows.Forms.DateTimePicker exportEndDate;
        private MetroLabel toLabel;
        private System.Windows.Forms.DateTimePicker exportBeginDate;
        private MetroButton button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox ftpIpTxt;
        private MetroLabel ftpIPLbl;
        private System.Windows.Forms.TextBox ftpPasswordTxt;
        private MetroLabel ftpPasswordLbl;
        private System.Windows.Forms.TextBox ftpUserTxt;
        private MetroLabel metroLabel1;
        private System.Windows.Forms.TextBox ftpDirTxt;
        private MetroLabel metroLabel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox dbPasswordTxt;
        private MetroLabel dbPasswordLbl;
        private System.Windows.Forms.TextBox dbUserTxt;
        private MetroLabel dbUserLbl;
        private System.Windows.Forms.TextBox dbSidTxt;
        private MetroLabel dbSidLbl;
        private MetroButton configTestBtn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox1;
        private MetroLabel metroLabel3;
        private MetroLabel systemWarnLbl;
    }
}

