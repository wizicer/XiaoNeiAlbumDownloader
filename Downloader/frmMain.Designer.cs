namespace Downloader
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.webLoginer = new System.Windows.Forms.WebBrowser();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEMail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.panLogin = new System.Windows.Forms.Panel();
            this.chkAutoLogin = new System.Windows.Forms.CheckBox();
            this.panButtons = new System.Windows.Forms.Panel();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.lstAlbum = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.colName = new System.Windows.Forms.ColumnHeader();
            this.colNumber = new System.Windows.Forms.ColumnHeader();
            this.colDescription = new System.Windows.Forms.ColumnHeader();
            this.colCreationDate = new System.Windows.Forms.ColumnHeader();
            this.colUpdateDate = new System.Windows.Forms.ColumnHeader();
            this.colAddress = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.mnuAlbum = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAlbumRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAlbumClear = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAlbumExport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPasteList = new System.Windows.Forms.ToolStripMenuItem();
            this.lstPhoto = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.mnuPhoto = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuPhotoRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPhotoClear = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPhotoExport = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.panFriends = new System.Windows.Forms.Panel();
            this.btnGetAlbum = new System.Windows.Forms.Button();
            this.btnGetFriends = new System.Windows.Forms.Button();
            this.cmbUserID = new System.Windows.Forms.ComboBox();
            this.barLoadFriends = new System.Windows.Forms.ProgressBar();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLinkTianYou = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLinkIcer = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLinkWizicer = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLinkSZWH8 = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnBatchGather = new System.Windows.Forms.Button();
            this.btnGetFromClipboard = new System.Windows.Forms.Button();
            this.btnBatchDownload = new System.Windows.Forms.Button();
            this.btnSelectSavePath = new System.Windows.Forms.Button();
            this.btnGetHome = new System.Windows.Forms.Button();
            this.lblLoadingStatus = new System.Windows.Forms.Label();
            this.panLogin.SuspendLayout();
            this.panButtons.SuspendLayout();
            this.mnuAlbum.SuspendLayout();
            this.mnuPhoto.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.panFriends.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // webLoginer
            // 
            this.webLoginer.Location = new System.Drawing.Point(252, 51);
            this.webLoginer.MinimumSize = new System.Drawing.Size(20, 20);
            this.webLoginer.Name = "webLoginer";
            this.webLoginer.Size = new System.Drawing.Size(483, 385);
            this.webLoginer.TabIndex = 0;
            this.webLoginer.Visible = false;
            this.webLoginer.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webLoginer_DocumentCompleted);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "用户名：";
            // 
            // txtEMail
            // 
            this.txtEMail.Location = new System.Drawing.Point(62, 7);
            this.txtEMail.Name = "txtEMail";
            this.txtEMail.Size = new System.Drawing.Size(143, 21);
            this.txtEMail.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "密  码：";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(62, 36);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(143, 21);
            this.txtPassword.TabIndex = 5;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(211, 5);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(41, 42);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "登录";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // panLogin
            // 
            this.panLogin.Controls.Add(this.chkAutoLogin);
            this.panLogin.Controls.Add(this.label1);
            this.panLogin.Controls.Add(this.btnLogin);
            this.panLogin.Controls.Add(this.txtEMail);
            this.panLogin.Controls.Add(this.txtPassword);
            this.panLogin.Controls.Add(this.label2);
            this.panLogin.Location = new System.Drawing.Point(12, 12);
            this.panLogin.Name = "panLogin";
            this.panLogin.Size = new System.Drawing.Size(257, 63);
            this.panLogin.TabIndex = 7;
            // 
            // chkAutoLogin
            // 
            this.chkAutoLogin.AutoSize = true;
            this.chkAutoLogin.Location = new System.Drawing.Point(207, 47);
            this.chkAutoLogin.Name = "chkAutoLogin";
            this.chkAutoLogin.Size = new System.Drawing.Size(48, 16);
            this.chkAutoLogin.TabIndex = 7;
            this.chkAutoLogin.Text = "记住";
            this.chkAutoLogin.UseVisualStyleBackColor = true;
            // 
            // panButtons
            // 
            this.panButtons.Controls.Add(this.txtUserID);
            this.panButtons.Controls.Add(this.button1);
            this.panButtons.Location = new System.Drawing.Point(17, 6);
            this.panButtons.Name = "panButtons";
            this.panButtons.Size = new System.Drawing.Size(142, 63);
            this.panButtons.TabIndex = 8;
            this.panButtons.Visible = false;
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(3, 3);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(100, 21);
            this.txtUserID.TabIndex = 2;
            this.txtUserID.Text = "226113032";
            // 
            // lstAlbum
            // 
            this.lstAlbum.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.colName,
            this.colNumber,
            this.colDescription,
            this.colCreationDate,
            this.colUpdateDate,
            this.colAddress,
            this.columnHeader4,
            this.columnHeader6});
            this.lstAlbum.ContextMenuStrip = this.mnuAlbum;
            this.lstAlbum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstAlbum.FullRowSelect = true;
            this.lstAlbum.GridLines = true;
            this.lstAlbum.Location = new System.Drawing.Point(0, 0);
            this.lstAlbum.Name = "lstAlbum";
            this.lstAlbum.Size = new System.Drawing.Size(723, 175);
            this.lstAlbum.TabIndex = 9;
            this.lstAlbum.UseCompatibleStateImageBehavior = false;
            this.lstAlbum.View = System.Windows.Forms.View.Details;
            this.lstAlbum.DoubleClick += new System.EventHandler(this.lstAlbum_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            // 
            // colName
            // 
            this.colName.Text = "名称";
            this.colName.Width = 91;
            // 
            // colNumber
            // 
            this.colNumber.Text = "数量";
            this.colNumber.Width = 46;
            // 
            // colDescription
            // 
            this.colDescription.Text = "描述";
            this.colDescription.Width = 230;
            // 
            // colCreationDate
            // 
            this.colCreationDate.Text = "创建日期";
            this.colCreationDate.Width = 85;
            // 
            // colUpdateDate
            // 
            this.colUpdateDate.Text = "更新日期";
            this.colUpdateDate.Width = 80;
            // 
            // colAddress
            // 
            this.colAddress.Text = "地址";
            this.colAddress.Width = 0;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "状态";
            this.columnHeader4.Width = 43;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "拥有者";
            this.columnHeader6.Width = 0;
            // 
            // mnuAlbum
            // 
            this.mnuAlbum.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAlbumRemove,
            this.mnuAlbumClear,
            this.mnuAlbumExport,
            this.mnuPasteList});
            this.mnuAlbum.Name = "mnuAlbum";
            this.mnuAlbum.Size = new System.Drawing.Size(137, 92);
            // 
            // mnuAlbumRemove
            // 
            this.mnuAlbumRemove.Name = "mnuAlbumRemove";
            this.mnuAlbumRemove.Size = new System.Drawing.Size(136, 22);
            this.mnuAlbumRemove.Text = "移除(&R)";
            this.mnuAlbumRemove.Click += new System.EventHandler(this.mnuAlbumRemove_Click);
            // 
            // mnuAlbumClear
            // 
            this.mnuAlbumClear.Name = "mnuAlbumClear";
            this.mnuAlbumClear.Size = new System.Drawing.Size(136, 22);
            this.mnuAlbumClear.Text = "清空(&C)";
            this.mnuAlbumClear.Click += new System.EventHandler(this.mnuAlbumClear_Click);
            // 
            // mnuAlbumExport
            // 
            this.mnuAlbumExport.Name = "mnuAlbumExport";
            this.mnuAlbumExport.Size = new System.Drawing.Size(136, 22);
            this.mnuAlbumExport.Text = "导出(&E)";
            this.mnuAlbumExport.Click += new System.EventHandler(this.mnuAlbumExport_Click);
            // 
            // mnuPasteList
            // 
            this.mnuPasteList.Name = "mnuPasteList";
            this.mnuPasteList.Size = new System.Drawing.Size(136, 22);
            this.mnuPasteList.Text = "粘贴列表(&P)";
            this.mnuPasteList.Click += new System.EventHandler(this.mnuPasteList_Click);
            // 
            // lstPhoto
            // 
            this.lstPhoto.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader5,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader7});
            this.lstPhoto.ContextMenuStrip = this.mnuPhoto;
            this.lstPhoto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstPhoto.FullRowSelect = true;
            this.lstPhoto.GridLines = true;
            this.lstPhoto.Location = new System.Drawing.Point(0, 0);
            this.lstPhoto.Name = "lstPhoto";
            this.lstPhoto.Size = new System.Drawing.Size(723, 176);
            this.lstPhoto.TabIndex = 10;
            this.lstPhoto.UseCompatibleStateImageBehavior = false;
            this.lstPhoto.View = System.Windows.Forms.View.Details;
            this.lstPhoto.DoubleClick += new System.EventHandler(this.lstPhoto_DoubleClick);
            this.lstPhoto.Click += new System.EventHandler(this.lstPhoto_Click);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "";
            this.columnHeader2.Width = 48;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "缩略图地址";
            this.columnHeader3.Width = 0;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "地址";
            this.columnHeader5.Width = 0;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "描述";
            this.columnHeader8.Width = 280;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "浏览数";
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "评论数";
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "上传时间";
            this.columnHeader11.Width = 110;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "相对路径";
            this.columnHeader7.Width = 0;
            // 
            // mnuPhoto
            // 
            this.mnuPhoto.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPhotoRemove,
            this.mnuPhotoClear,
            this.mnuPhotoExport});
            this.mnuPhoto.Name = "mnuPhoto";
            this.mnuPhoto.Size = new System.Drawing.Size(113, 70);
            // 
            // mnuPhotoRemove
            // 
            this.mnuPhotoRemove.Name = "mnuPhotoRemove";
            this.mnuPhotoRemove.Size = new System.Drawing.Size(112, 22);
            this.mnuPhotoRemove.Text = "移除(&R)";
            this.mnuPhotoRemove.Click += new System.EventHandler(this.mnuPhotoRemove_Click);
            // 
            // mnuPhotoClear
            // 
            this.mnuPhotoClear.Name = "mnuPhotoClear";
            this.mnuPhotoClear.Size = new System.Drawing.Size(112, 22);
            this.mnuPhotoClear.Text = "清空(&C)";
            this.mnuPhotoClear.Click += new System.EventHandler(this.mnuPhotoClear_Click);
            // 
            // mnuPhotoExport
            // 
            this.mnuPhotoExport.Name = "mnuPhotoExport";
            this.mnuPhotoExport.Size = new System.Drawing.Size(112, 22);
            this.mnuPhotoExport.Text = "导出(&E)";
            this.mnuPhotoExport.Click += new System.EventHandler(this.mnuPhotoExport_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 81);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lstAlbum);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.picPreview);
            this.splitContainer1.Panel2.Controls.Add(this.lstPhoto);
            this.splitContainer1.Size = new System.Drawing.Size(723, 355);
            this.splitContainer1.SplitterDistance = 175;
            this.splitContainer1.TabIndex = 11;
            // 
            // picPreview
            // 
            this.picPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.picPreview.Location = new System.Drawing.Point(620, 50);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(100, 132);
            this.picPreview.TabIndex = 12;
            this.picPreview.TabStop = false;
            this.picPreview.Visible = false;
            // 
            // panFriends
            // 
            this.panFriends.Controls.Add(this.btnGetAlbum);
            this.panFriends.Controls.Add(this.btnGetFriends);
            this.panFriends.Controls.Add(this.cmbUserID);
            this.panFriends.Controls.Add(this.barLoadFriends);
            this.panFriends.Location = new System.Drawing.Point(275, 12);
            this.panFriends.Name = "panFriends";
            this.panFriends.Size = new System.Drawing.Size(184, 63);
            this.panFriends.TabIndex = 12;
            // 
            // btnGetAlbum
            // 
            this.btnGetAlbum.Location = new System.Drawing.Point(3, 28);
            this.btnGetAlbum.Name = "btnGetAlbum";
            this.btnGetAlbum.Size = new System.Drawing.Size(175, 23);
            this.btnGetAlbum.TabIndex = 2;
            this.btnGetAlbum.Text = "获取相册";
            this.btnGetAlbum.UseVisualStyleBackColor = true;
            this.btnGetAlbum.Click += new System.EventHandler(this.btnGetAlbum_Click);
            // 
            // btnGetFriends
            // 
            this.btnGetFriends.Location = new System.Drawing.Point(99, 28);
            this.btnGetFriends.Name = "btnGetFriends";
            this.btnGetFriends.Size = new System.Drawing.Size(79, 23);
            this.btnGetFriends.TabIndex = 1;
            this.btnGetFriends.Text = "获取好友";
            this.btnGetFriends.UseVisualStyleBackColor = true;
            this.btnGetFriends.Visible = false;
            this.btnGetFriends.Click += new System.EventHandler(this.btnGetFriends_Click);
            // 
            // cmbUserID
            // 
            this.cmbUserID.FormattingEnabled = true;
            this.cmbUserID.Location = new System.Drawing.Point(3, 3);
            this.cmbUserID.Name = "cmbUserID";
            this.cmbUserID.Size = new System.Drawing.Size(175, 20);
            this.cmbUserID.TabIndex = 0;
            // 
            // barLoadFriends
            // 
            this.barLoadFriends.Location = new System.Drawing.Point(99, 28);
            this.barLoadFriends.Name = "barLoadFriends";
            this.barLoadFriends.Size = new System.Drawing.Size(79, 23);
            this.barLoadFriends.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.barLoadFriends.TabIndex = 3;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblLinkTianYou,
            this.lblLinkIcer,
            this.lblLinkWizicer,
            this.lblLinkSZWH8});
            this.statusStrip1.Location = new System.Drawing.Point(0, 439);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(747, 22);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(503, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "就绪";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLinkTianYou
            // 
            this.lblLinkTianYou.ForeColor = System.Drawing.Color.Blue;
            this.lblLinkTianYou.IsLink = true;
            this.lblLinkTianYou.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblLinkTianYou.Name = "lblLinkTianYou";
            this.lblLinkTianYou.Size = new System.Drawing.Size(65, 17);
            this.lblLinkTianYou.Text = "天佑工作室";
            this.lblLinkTianYou.Click += new System.EventHandler(this.lblLinkTianYou_Click);
            // 
            // lblLinkIcer
            // 
            this.lblLinkIcer.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.lblLinkIcer.IsLink = true;
            this.lblLinkIcer.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblLinkIcer.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.lblLinkIcer.Name = "lblLinkIcer";
            this.lblLinkIcer.Size = new System.Drawing.Size(95, 17);
            this.lblLinkIcer.Text = "冰河魔法师 出品";
            this.lblLinkIcer.Click += new System.EventHandler(this.lblLinkIcer_Click);
            // 
            // lblLinkWizicer
            // 
            this.lblLinkWizicer.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblLinkWizicer.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.lblLinkWizicer.IsLink = true;
            this.lblLinkWizicer.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblLinkWizicer.Name = "lblLinkWizicer";
            this.lblLinkWizicer.Size = new System.Drawing.Size(69, 17);
            this.lblLinkWizicer.Text = "[冰灵圣域]";
            this.lblLinkWizicer.Click += new System.EventHandler(this.lblLinkWizicer_Click);
            // 
            // lblLinkSZWH8
            // 
            this.lblLinkSZWH8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.lblLinkSZWH8.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Top | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblLinkSZWH8.IsLink = true;
            this.lblLinkSZWH8.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblLinkSZWH8.LinkColor = System.Drawing.Color.Red;
            this.lblLinkSZWH8.Name = "lblLinkSZWH8";
            this.lblLinkSZWH8.Size = new System.Drawing.Size(69, 17);
            this.lblLinkSZWH8.Text = "山寨文化吧";
            this.lblLinkSZWH8.Visible = false;
            this.lblLinkSZWH8.Click += new System.EventHandler(this.lblLinkSZWH8_Click);
            // 
            // btnBatchGather
            // 
            this.btnBatchGather.Location = new System.Drawing.Point(356, -5);
            this.btnBatchGather.Name = "btnBatchGather";
            this.btnBatchGather.Size = new System.Drawing.Size(130, 23);
            this.btnBatchGather.TabIndex = 16;
            this.btnBatchGather.Text = "批量获取";
            this.btnBatchGather.UseVisualStyleBackColor = true;
            this.btnBatchGather.Visible = false;
            this.btnBatchGather.Click += new System.EventHandler(this.btnBatchGather_Click);
            // 
            // btnGetFromClipboard
            // 
            this.btnGetFromClipboard.Location = new System.Drawing.Point(601, 12);
            this.btnGetFromClipboard.Name = "btnGetFromClipboard";
            this.btnGetFromClipboard.Size = new System.Drawing.Size(119, 24);
            this.btnGetFromClipboard.TabIndex = 17;
            this.btnGetFromClipboard.Text = "从剪贴板中获取";
            this.btnGetFromClipboard.UseVisualStyleBackColor = true;
            this.btnGetFromClipboard.Click += new System.EventHandler(this.btnGetFromClipboard_Click);
            // 
            // btnBatchDownload
            // 
            this.btnBatchDownload.Location = new System.Drawing.Point(465, 42);
            this.btnBatchDownload.Name = "btnBatchDownload";
            this.btnBatchDownload.Size = new System.Drawing.Size(130, 23);
            this.btnBatchDownload.TabIndex = 18;
            this.btnBatchDownload.Text = "批量下载";
            this.btnBatchDownload.UseVisualStyleBackColor = true;
            this.btnBatchDownload.Click += new System.EventHandler(this.btnBatchDownload_Click);
            // 
            // btnSelectSavePath
            // 
            this.btnSelectSavePath.Location = new System.Drawing.Point(601, 42);
            this.btnSelectSavePath.Name = "btnSelectSavePath";
            this.btnSelectSavePath.Size = new System.Drawing.Size(119, 24);
            this.btnSelectSavePath.TabIndex = 19;
            this.btnSelectSavePath.Text = "选择保存目录";
            this.btnSelectSavePath.UseVisualStyleBackColor = true;
            this.btnSelectSavePath.Click += new System.EventHandler(this.btnSelectSavePath_Click);
            // 
            // btnGetHome
            // 
            this.btnGetHome.Enabled = false;
            this.btnGetHome.Location = new System.Drawing.Point(465, 13);
            this.btnGetHome.Name = "btnGetHome";
            this.btnGetHome.Size = new System.Drawing.Size(130, 23);
            this.btnGetHome.TabIndex = 20;
            this.btnGetHome.Text = "获取首页共享相册";
            this.btnGetHome.UseVisualStyleBackColor = true;
            this.btnGetHome.Click += new System.EventHandler(this.btnGetHome_Click);
            // 
            // lblLoadingStatus
            // 
            this.lblLoadingStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLoadingStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLoadingStatus.Font = new System.Drawing.Font("SimSun", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLoadingStatus.ForeColor = System.Drawing.Color.Blue;
            this.lblLoadingStatus.Location = new System.Drawing.Point(2, 201);
            this.lblLoadingStatus.Name = "lblLoadingStatus";
            this.lblLoadingStatus.Size = new System.Drawing.Size(745, 55);
            this.lblLoadingStatus.TabIndex = 21;
            this.lblLoadingStatus.Text = "正在载入";
            this.lblLoadingStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 461);
            this.Controls.Add(this.lblLoadingStatus);
            this.Controls.Add(this.btnGetHome);
            this.Controls.Add(this.btnBatchDownload);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panFriends);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panLogin);
            this.Controls.Add(this.panButtons);
            this.Controls.Add(this.btnGetFromClipboard);
            this.Controls.Add(this.btnBatchGather);
            this.Controls.Add(this.btnSelectSavePath);
            this.Controls.Add(this.webLoginer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "校内相册批量下载器 V1.11 Build 0512";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panLogin.ResumeLayout(false);
            this.panLogin.PerformLayout();
            this.panButtons.ResumeLayout(false);
            this.panButtons.PerformLayout();
            this.mnuAlbum.ResumeLayout(false);
            this.mnuPhoto.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.panFriends.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webLoginer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEMail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Panel panLogin;
        private System.Windows.Forms.Panel panButtons;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.ListView lstAlbum;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colNumber;
        private System.Windows.Forms.ColumnHeader colDescription;
        private System.Windows.Forms.ColumnHeader colCreationDate;
        private System.Windows.Forms.ColumnHeader colUpdateDate;
        private System.Windows.Forms.ColumnHeader colAddress;
        private System.Windows.Forms.ListView lstPhoto;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.Panel panFriends;
        private System.Windows.Forms.Button btnGetAlbum;
        private System.Windows.Forms.Button btnGetFriends;
        private System.Windows.Forms.ComboBox cmbUserID;
        private System.Windows.Forms.ProgressBar barLoadFriends;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblLinkIcer;
        private System.Windows.Forms.ToolStripStatusLabel lblLinkTianYou;
        private System.Windows.Forms.ContextMenuStrip mnuAlbum;
        private System.Windows.Forms.ToolStripMenuItem mnuAlbumRemove;
        private System.Windows.Forms.ToolStripMenuItem mnuAlbumClear;
        private System.Windows.Forms.ContextMenuStrip mnuPhoto;
        private System.Windows.Forms.ToolStripMenuItem mnuPhotoRemove;
        private System.Windows.Forms.ToolStripMenuItem mnuPhotoClear;
        private System.Windows.Forms.ToolStripMenuItem mnuPhotoExport;
        private System.Windows.Forms.Button btnBatchGather;
        private System.Windows.Forms.ToolStripStatusLabel lblLinkWizicer;
        private System.Windows.Forms.Button btnGetFromClipboard;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btnBatchDownload;
        private System.Windows.Forms.Button btnSelectSavePath;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Button btnGetHome;
        private System.Windows.Forms.ToolStripMenuItem mnuAlbumExport;
        private System.Windows.Forms.ToolStripMenuItem mnuPasteList;
        private System.Windows.Forms.ToolStripStatusLabel lblLinkSZWH8;
        private System.Windows.Forms.Label lblLoadingStatus;
        private System.Windows.Forms.CheckBox chkAutoLogin;
    }
}

