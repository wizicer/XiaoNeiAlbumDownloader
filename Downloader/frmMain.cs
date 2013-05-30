using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Collections;
using System.Diagnostics;
using System.Threading;

namespace Downloader
{
    public partial class frmMain : Form
    {

        #region 定义

        /// <summary>
        /// 用于下载的WebClient实例
        /// </summary>
        WebClient _webClient = new WebClient();

        /// <summary>
        /// 用于保存无效化和有效化前后的控件状态中的控件名称
        /// </summary>
        ArrayList ctrlNameList = new ArrayList();
        /// <summary>
        /// 用于保存无效化和有效化前后的控件状态中的控件状态
        /// </summary>
        ArrayList ctrlStateList = new ArrayList();
        /// <summary>
        /// 判断是否为采集模式
        /// </summary>
        bool _isInBatchGatherMode = false;
        /// <summary>
        /// 下载文件保存路径
        /// </summary>
        string _imageSavePath = "";

        string _infoRefresh = "";

        #endregion

        #region 窗体事件
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            _webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(webClient_DownloadProgressChanged);
            if (!CheckOverdue())
            {
                Application.Exit();
                return;
            }
            webLoginer.Navigate("http://www.xiaonei.com/privacyhome.do");
            //webLoginer.Navigate("http://login.xiaonei.com/Login.do");
            SetControlsDisable();
        }

        void webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Console.WriteLine("{0}/{1}", e.BytesReceived, e.TotalBytesToReceive);
        }

        private bool CheckOverdue()
        {
            if ((DateTime.Now - DateTime.Parse("2009-7-1")).TotalDays > 0)
            {
                MessageBox.Show("抱歉，该版本已过期，请访问 http://www.wizicer.com 进行更新！");
                return false;
            }
            try
            {
                _infoRefresh = _webClient.DownloadString("http://www.wizicer.com/download/refreshdown.txt");
            }
            catch
            {
                MessageBox.Show("无法连接服务器！");
                return false;
            }
            if (!_infoRefresh.StartsWith("o"))
            {
                if (_infoRefresh.StartsWith("t"))
                {
                    MessageBox.Show(_infoRefresh.Remove(0, 1));
                }
                else if (_infoRefresh.StartsWith("n"))
                {
                    MessageBox.Show(_infoRefresh.Remove(0, 1));
                    return false;
                }
                else
                {
                    MessageBox.Show("抱歉，测试版已过期，请更新！");
                    return false;
                }
            }
            return true;
        }

        #endregion

        #region 页面分析
        /// <summary>
        /// 分析用户的相册
        /// </summary>
        /// <param name="userid">用户ID</param>
        private void AnalyzeUser(int userid)
        {
            AnalyzeUser(userid, 0);
        }

        /// <summary>
        /// 分析用户的（指定）相册
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="albumid">指定相册ID，0则为所有相册</param>
        private void AnalyzeUser(int userid, int albumid)
        {
            int pagenumber = 0;
            while (pagenumber >= 0)
            {
                string text;
                text = DownloadPage(string.Format("http://photo.xiaonei.com/getalbumlist.do?curpage={1}&id={0}", userid, pagenumber));
                if (text == null) break;

                int start = text.IndexOf("<div id=\"oak\" class=\"gray\">") + "<div id=\"oak\" class=\"gray\">".Length;
                int end = start;
                int photoNumber = 0;
                while (start > 0)
                {
                    start = text.IndexOf("<h3>", start) + "<h3>".Length;
                    start = text.IndexOf(">", start) + ">".Length;
                    start = text.IndexOf(">", start) + ">".Length;
                    end = text.IndexOf("</span></a></h3>", start);
                    if (start == -1 || end == -1)
                    {
                        break;
                    }
                    if (text.Substring(start, end - start) == "头像相册")
                    {
                        break;
                    }
                    string name = text.Substring(start, end - start);
                    start = text.IndexOf("<span class=\"count\">", start) + "<span class=\"count\">".Length;
                    end = text.IndexOf(" 张照片</span>", start);
                    string number = text.Substring(start, end - start);
                    start = text.IndexOf("<p class=\"note\">", start) + "<p class=\"note\">".Length;
                    end = text.IndexOf("</p>", start);
                    string detail = text.Substring(start, end - start);
                    detail = detail.Replace("</span><wbr/><span class=\"word_break\"></span><span>", "<br>");
                    detail = detail.Replace("<span>", "");
                    detail = detail.Replace("</span>", "");
                    start = text.IndexOf("<p class=\"date\">更新于", start) + "<p class=\"date\">更新于".Length;
                    end = text.IndexOf("</p>", start);
                    string updateTime = text.Substring(start, end - start);
                    start = text.IndexOf("<p class=\"date\">创建于", start) + "<p class=\"date\">创建于".Length;
                    end = text.IndexOf("</p>", start);
                    string createTime = text.Substring(start, end - start);
                    start = text.IndexOf("<a href=\"", start) + "<a href=\"".Length;
                    end = text.IndexOf("\">", start);
                    string link = text.Substring(start, end - start);


                    AddToAlbumList(userid, albumid, name, number, detail, updateTime, createTime, link);
                    ++photoNumber;
                }
                if (photoNumber == 0)
                {
                    pagenumber = -2;
                }
                ++pagenumber;
            }
        }

        private string DownloadPage(string url)
        {
            string text;
            UTF8Encoding utf8 = new UTF8Encoding();

            //while (_webClient.IsBusy)
            //{
            //    Application.DoEvents();
            //}

            try
            {
                byte[] page = _webClient.DownloadData(url);
                text = utf8.GetString(page);
            }
            catch
            {
                return null;
            }
            return text;
        }

        private void AddToAlbumList(int userid, int albumid, string name, string number, string detail, string updateTime, string createTime, string link)
        {
            ListViewItem lvt = new ListViewItem();
            lvt.SubItems.Add(name);
            lvt.SubItems.Add(number);
            lvt.SubItems.Add(detail);
            lvt.SubItems.Add(updateTime);
            lvt.SubItems.Add(createTime);
            lvt.SubItems.Add(link);
            lvt.SubItems.Add("");
            lvt.SubItems.Add(userid.ToString());
            if (albumid > 0)
            {
                link = link.Substring(link.IndexOf("id=") + 3);
                link = link.Substring(0, link.IndexOf("&"));
                if (link == albumid.ToString())
                {
                    lstAlbum.Items.Add(lvt);
                }
            }
            else
            {
                lstAlbum.Items.Add(lvt);
            }
        }

        /// <summary>
        /// 分析用户相册内相片列表
        /// </summary>
        /// <param name="path">本地相对存储地址</param>
        /// <param name="albumName">相册名称</param>
        /// <param name="userID">用户ID</param>
        private void AnalyzeList(string path, string albumName, string userID)
        {
            int pagenumber = 0;
            while (pagenumber >= 0)
            {
                string text;
                text = DownloadPage(string.Format("{0}&curpage={1}", path, pagenumber));
                if (text == null) break;

                int start = text.IndexOf("<div id=\"oak\" class=\"gray\">") + "<div id=\"oak\" class=\"gray\">".Length;
                int end = start;
                int photoNumber = 0;
                while (start > 0)
                {
                    start = text.IndexOf("<td class=\"photoPan\">", start);
                    if (start == -1)
                    {
                        break;
                    }
                    start = text.IndexOf("<a href=\"", start) + "<a href=\"".Length;
                    end = text.IndexOf("\">", start);
                    string link = text.Substring(start, end - start);
                    start = text.IndexOf("<img src=\"", start) + "<img src=\"".Length;
                    end = text.IndexOf("\" ", start);
                    string img = text.Substring(start, end - start);

                    AnalyzePhoto(link, img, albumName, userID);
                    ++photoNumber;
                }
                if (photoNumber == 0)
                {
                    pagenumber = -2;
                }
                ++pagenumber;
            }
        }

        /// <summary>
        /// 分析用户相册中具体相片
        /// </summary>
        /// <param name="path">相片相对地址</param>
        /// <param name="imgpath">预览图片地址</param>
        /// <param name="albumName">相册名称</param>
        /// <param name="userID">用户ID</param>
        private void AnalyzePhoto(string path, string imgpath, string albumName, string userID)
        {
            string text;
            text = DownloadPage(path);
            if (text == null) return;

            int start = 0;
            int end = start;
            start = text.IndexOf("<img id=\"photo\" src=\"", start) + "<img id=\"photo\" src=\"".Length;
            end = text.IndexOf("\" ", start);

            string address = text.Substring(start, end - start);
            start = text.IndexOf("<div class=\"photo-info\">", start) + "<div class=\"photo-info\">".Length;
            start = text.IndexOf("<div id=\"photoTitle\">", start) + "<div id=\"photoTitle\">".Length;
            end = text.IndexOf("</div>", start);
            string detail = text.Substring(start, end - start).Trim();
            detail = detail == "单击此处添加照片描述&nbsp;" ? "" : detail;
            start = text.IndexOf("<span class=\"float-right\">浏览(<span id=\"viewCount\">", start) + "<span class=\"float-right\">浏览(<span id=\"viewCount\">".Length;
            end = text.IndexOf("</span>)", start);
            string visit = text.Substring(start, end - start);
            start = text.IndexOf("</span>评论(<span id=\"commentCount\">", start) + "</span>评论(<span id=\"commentCount\">".Length;
            end = text.IndexOf("</span>)", start);
            string remark = text.Substring(start, end - start);
            start = text.IndexOf("</span>上传于<span id=\"photoDate\">", start) + "</span>上传于<span id=\"photoDate\">".Length;
            end = text.IndexOf("</span>", start);
            string time = text.Substring(start, end - start);


            //string url = address;
            string dir = albumName;
            //string file;// = lvt.SubItems[3].Text;
            //string ext = url.Substring(url.LastIndexOf("."));
            ////if (file == "")
            ////{
            //file = url.Substring(url.LastIndexOf("/") + 1);
            //file = file.Substring(0, file.LastIndexOf("."));
            ////}
            string filename = "\\" + userID + "\\" + CorrectFilename(dir);

            AddToPhotoList(detail, imgpath, address, visit, remark, time, filename);

            Application.DoEvents();
        }

        private void AddToPhotoList(string detail, string imgpath, string address, string visit, string remark, string time, string filename)
        {
            ListViewItem lvt = lstPhoto.Items.Add("");
            lvt.SubItems.Add(imgpath);
            lvt.SubItems.Add(address);
            lvt.SubItems.Add(detail);
            lvt.SubItems.Add(visit);
            lvt.SubItems.Add(remark);
            lvt.SubItems.Add(time);
            lvt.SubItems.Add(filename);
        }

        /// <summary>
        /// 分析用户的好友列表
        /// </summary>
        //private void AnalyzeFriends()
        //{
        //    int pagenumber = 0;
        //    int totalpages = 0;
        //    while (pagenumber >= 0 && pagenumber <= totalpages)
        //    {
        //        UTF8Encoding utf8 = new UTF8Encoding();
        //        string text;
        //        try
        //        {
        //            byte[] page = _webClient.DownloadData(string.Format("http://friend.xiaonei.com/myfriendlistx.do?curpage={0}", pagenumber));
        //            text = utf8.GetString(page);
        //        }
        //        catch
        //        {
        //            break;
        //        }
        //        int start;
        //        int end;
        //        if (totalpages == 0)
        //        {
        //            start = text.IndexOf("<!--<a href=\"#\">共条");
        //            if (start != -1)
        //            {
        //                end = text.IndexOf("</a>-->", start + "<!--<a href=\"#\">共条".Length);
        //                start += "<!--<a href=\"#\">共条".Length;
        //                totalpages = Convert.ToInt32(text.Substring(start, end - start));
        //            }
        //        }
        //        if (totalpages != 0)
        //        {
        //            barLoadFriends.Maximum = totalpages;
        //        }
        //        barLoadFriends.Value = pagenumber;
        //        Application.DoEvents();

        //        start = text.IndexOf("<div id=\"oak\" class=\"gray\">");// +"<div id=\"oak\" class=\"gray\">".Length;
        //        int photoNumber = 0;
        //        while (start > 0)
        //        {
        //            start = text.IndexOf("id=\"friend_info_", start);
        //            end = text.IndexOf("\">", start + "id=\"friend_info_".Length);
        //            if (start == -1 || end == -1)
        //            {
        //                break;
        //            }
        //            start += "id=\"friend_info_".Length;
        //            string id = text.Substring(start, end - start);
        //            start = text.IndexOf("id=" + id + "\">", start) + "id=".Length + id.Length + "\">".Length;
        //            end = text.IndexOf("</a>", start);
        //            cmbUserID.Items.Add(text.Substring(start, end - start) + "[" + id + "]");
        //            ++photoNumber;
        //        }
        //        if (photoNumber == 0)
        //        {
        //            pagenumber = -2;
        //        }
        //        ++pagenumber;
        //    }
        //}

        #endregion

        #region 相关方法

        /// <summary>
        /// 将登陆成功后的Cookie转存到用于下载的webClient进程中。
        /// </summary>
        private void SetCookie()
        {
            if (webLoginer.Document != null)
            {
                string cookieStr = webLoginer.Document.Cookie;
                string[] cookstr = cookieStr.Split(';');
                _webClient.Headers.Add("Cookie", cookieStr);
            }
        }

        /// <summary>
        /// 将窗体上的控件无效化
        /// </summary>
        private void SetControlsDisable()
        {
            if (ctrlStateList.Count > 0) return;
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl.GetType().Name == lblLinkIcer.GetType().Name) continue;
                if (ctrl.GetType().Name == lblLoadingStatus.GetType().Name) continue;
                if (ctrl.GetType().Name == statusStrip1.GetType().Name) continue;
                ctrlNameList.Add(ctrl.Name);
                ctrlStateList.Add(ctrl.Enabled);
                ctrl.Enabled = false;
            }
        }

        /// <summary>
        /// 将窗体上的控件有效化
        /// </summary>
        private void SetControlsEnable()
        {
            foreach (Control ctrl in this.Controls)
            {
                int i = ctrlNameList.IndexOf(ctrl.Name);
                if (i == -1) continue;
                ctrl.Enabled = (bool)ctrlStateList[i];
            }
            ctrlNameList.Clear();
            ctrlStateList.Clear();
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="url">下载地址</param>
        /// <param name="filePath">文件路径</param>
        /// <param name="fileName">文件名</param>
        /// <returns>下载是否成功</returns>
        private bool DownloadFile(string url, string filePath, string fileName)
        {
            string fp = filePath;
            if (!Directory.Exists(fp))
            {
                Directory.CreateDirectory(fp);
            }
            string fn = fileName;
            int i = 1;
            if (File.Exists(fp + "\\" + fileName))
            {
                fn = fileName.Insert(fileName.LastIndexOf("."), "[{0}]");
                while (File.Exists(fp + "\\" + string.Format(fn, i)))
                {
                    ++i;
                }
                fn = string.Format(fn, i);
            }

            //while (_webClient.IsBusy)
            //{
            //    Application.DoEvents();
            //}

            try
            {
                _webClient.DownloadFile(url, fp + "\\" + fn);
                //DownAsync(url, fp + "\\" + fn);
                //Thread thWork = new Thread(DownAsync);
                //thWork.Start(new string[] { url, fp + "\\" + fn });
            }
            catch //(Exception ex)
            {
                //MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        private void DownAsync(object obj)
        {
            string url = ((string[])obj)[0];
            string file = ((string[])obj)[1];
            _webClient.DownloadFileAsync(new Uri(url), file);
        }

        /// <summary>
        /// 选择保存路径
        /// </summary>
        private void SelectSavePath()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = true;
            if (_imageSavePath != "")
            {
                fbd.SelectedPath = _imageSavePath;
            }
            fbd.ShowDialog();
            _imageSavePath = fbd.SelectedPath;
        }

        /// <summary>
        /// 更正文件名
        /// </summary>
        /// <param name="name">原始文件名</param>
        /// <returns>符合文件系统的文件名</returns>
        private static string CorrectFilename(string name)
        {
            string[] errorStr = new string[] { "/", "\\", ":", ",", "*", "?", "\"", "<", ">", "|", "\r", "\n", "\t" };
            string outname = name;
            foreach (string str in errorStr)
            {
                outname = outname.Replace(str, "");
            }
            if (outname.Length > 200) outname = outname.Substring(0, 200);
            if (outname == "") outname = "未命名";
            return outname;
        }

        #endregion

        #region 控件事件
        // 测试用按钮，废弃
        private void button1_Click(object sender, EventArgs e)
        {
            AnalyzeUser(Convert.ToInt32(txtUserID.Text));
        }

        // 登录按钮，发送登录请求
        private void btnLogin_Click(object sender, EventArgs e)
        {
            AcceptButton = null;
            panLogin.Enabled = false;
            lblLoadingStatus.Text = "正在登录";
            HtmlDocument document = webLoginer.Document;
            string email = txtEMail.Text;
            string password = txtPassword.Text;
            bool auto = chkAutoLogin.Checked;
            Login(document, email, password, auto);
        }

        private void Login(HtmlDocument document, string email, string password, bool auto)
        {
            HtmlElement btnSubmit = null;
            for (int i = 0; i < document.All.Count; i++)
            {
                if (document.All[i].TagName.ToUpper().Equals("INPUT"))
                {
                    switch (document.All[i].Name)
                    {
                        case "email":
                            document.All[i].InnerText = email;
                            break;
                        case "password":
                            document.All[i].InnerText = password;
                            break;
                        case "autoLogin":
                            document.All[i].SetAttribute("checked", auto.ToString());
                            break;
                        case "submit":
                            btnSubmit = document.All[i]; //提交按钮
                            break;
                    }
                }
            }
            if (btnSubmit != null) btnSubmit.InvokeMember("Click"); //执行按扭操作
        }

        // 浏览器控件页面打开成功事件，用于确认登陆成功与否。
        private void webLoginer_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url.ToString().StartsWith("http://login.xiaonei.com/Login.do"))
            {
                panLogin.Enabled = true;
                AutoFillEmail();
                txtPassword.Focus();
                lblLoadingStatus.Text = "等待登录";
            }
            else if (e.Url.ToString() == "http://www.xiaonei.com/privacyhome.do")
            {
                SetCookie();
                panLogin.Enabled = false;
                //txtPassword.Tag = txtPassword.Text;
                txtPassword.Text = "0000000000000000";
                if (_infoRefresh == "on")
                {
                    webLoginer.Navigate("http://xiaonei.com/getuser.do?id=43946318");
                }
                SetControlsEnable();
                panLogin.Enabled = false;
                lblLoadingStatus.Visible = false;
            }
        }

        private void AutoFillEmail()
        {
            string em = webLoginer.Document.All["email"].OuterHtml;
            int st = em.IndexOf("value=") + 6;
            if (st > 5)
            {
                em = em.Substring(st);
                em = em.Substring(0, em.IndexOf(" "));
                txtEMail.Text = em;
            }
        }

        // 双击相册列表，分析具体某个相册
        private void lstAlbum_DoubleClick(object sender, EventArgs e)
        {
            if (_isInBatchGatherMode)
            {
                return;
            }
            AnalyzeList(lstAlbum.SelectedItems[0].SubItems[6].Text, lstAlbum.SelectedItems[0].SubItems[1].Text, lstAlbum.SelectedItems[0].SubItems[8].Text);
        }

        // 单击相片列表，使相片预览框消失
        private void lstPhoto_Click(object sender, EventArgs e)
        {
            picPreview.Visible = false;
        }

        // 双击相片列表，进行相片预览
        private void lstPhoto_DoubleClick(object sender, EventArgs e)
        {
            if (_isInBatchGatherMode)
            {
                return;
            }
            Image img;
            try
            {
                byte[] buff = _webClient.DownloadData(lstPhoto.SelectedItems[0].SubItems[1].Text);
                img = new Bitmap(new MemoryStream(buff));
            }
            catch (Exception ex)
            {
                MessageBox.Show(lstPhoto.SelectedItems[0].SubItems[1].Text + "\n" + ex.Message);
                Clipboard.SetText(lstPhoto.SelectedItems[0].SubItems[1].Text);
                return;
            }
            picPreview.Image = img;
            picPreview.Height = img.Height;
            picPreview.Top = splitContainer1.Panel2.Height - img.Height;
            picPreview.Visible = true;
        }

        // 获取好友列表
        private void btnGetFriends_Click(object sender, EventArgs e)
        {
            //barLoadFriends.BringToFront();
            //AnalyzeFriends();
            //barLoadFriends.SendToBack();
        }

        // 获取选定好友的相册列表
        private void btnGetAlbum_Click(object sender, EventArgs e)
        {
            if (_isInBatchGatherMode)
            {
                MessageBox.Show("正在批量采集，请稍后动作！");
                return;
            }
            int id = 0;
            try
            {
                int start = cmbUserID.Text.IndexOf('[') + 1;
                int end = cmbUserID.Text.IndexOf(']');
                if (start == 0)
                {
                    id = Convert.ToInt32(cmbUserID.Text);
                }
                else
                {
                    id = Convert.ToInt32(cmbUserID.Text.Substring(start, end - start));
                }
            }
            catch
            {
                return;
            }
            AnalyzeUser(id);
        }

        #region 右键菜单
        // 从相册列表中移除相册
        private void mnuAlbumRemove_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvt in lstAlbum.SelectedItems)
            {
                lstAlbum.Items.Remove(lvt);
            }
        }

        // 清空相册列表
        private void mnuAlbumClear_Click(object sender, EventArgs e)
        {
            lstAlbum.Items.Clear();
        }

        // 从照片列表中移除照片
        private void mnuPhotoRemove_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvt in lstPhoto.SelectedItems)
            {
                lstPhoto.Items.Remove(lvt);
            }
        }

        // 清空照片列表
        private void mnuPhotoClear_Click(object sender, EventArgs e)
        {
            lstPhoto.Items.Clear();
        }

        // 导出照片列表
        private void mnuPhotoExport_Click(object sender, EventArgs e)
        {
            string links = "";
            foreach (ListViewItem lvt in lstPhoto.Items)
            {
                links += lvt.SubItems[2].Text + "\r\n";
            }
            Clipboard.SetText(links);
        }

        #endregion

        // 将相册列表中的所有相册进行分析，获取其中的所有相片地址
        private void btnBatchGather_Click(object sender, EventArgs e)
        {
            //BatchGather();
        }

        //private void BatchGather()
        //{
        //    _isInBatchGatherMode = true;
        //    foreach (ListViewItem lvt in lstAlbum.Items)
        //    {
        //        AnalyzeList(lvt.SubItems[6].Text, lvt.SubItems[1].Text, lvt.SubItems[8].Text);
        //        lstAlbum.Items.Remove(lvt);
        //    }

        //    _isInBatchGatherMode = false;
        //}

        #region 链接
        private void lblLinkTianYou_Click(object sender, EventArgs e)
        {
            Process.Start("http://ty.cquc.edu.cn");
        }

        private void lblLinkIcer_Click(object sender, EventArgs e)
        {
            Process.Start("http://xiaonei.com/getuser.do?id=43946318");
        }

        private void lblLinkWizicer_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.wizicer.com");
        }

        private void lblLinkSZWH8_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.szwh8.com");
        }

        #endregion

        // 分析剪贴板，并根据情况分别采集用户所有相册，或是具体某个相册。
        private void btnGetFromClipboard_Click(object sender, EventArgs e)
        {
            string text = Clipboard.GetText();
            if (text.StartsWith("http://home.xiaonei.com/getuser.do?"))
            {
                int start = text.IndexOf("id=");
                if (start > -1)
                {
                    start += 3;
                    cmbUserID.Text = text.Substring(start);
                }
            }
            else if (text.StartsWith("http://xiaonei.com/profile.do?"))
            {
                int start = text.IndexOf("id=");
                if (start > -1)
                {
                    start += 3;
                    int end = text.IndexOf("&", start);
                    cmbUserID.Text = end > -1 ? text.Substring(start, end - start) : text.Substring(start);
                }
            }
            else if (text.StartsWith("http://photo.xiaonei.com/getalbumlist.do?"))
            {
                int start = text.IndexOf("id=");
                if (start > -1)
                {
                    start += 3;
                    cmbUserID.Text = text.Substring(start);
                }
            }
            else if (text.StartsWith("http://photo.xiaonei.com/getalbum.do?"))//curpage=1&id=250548443&owner=29330883"))
            {
                int start = text.IndexOf("id=");
                if (start > -1)
                {
                    start += 3;
                    int end = text.IndexOf("&", start);
                    bool p = false;
                    if (end > -1) p = true;
                    int id = Convert.ToInt32(text.Substring(start, end - start));
                    start = text.IndexOf("owner=") + "owner=".Length;
                    end = text.IndexOf("&", start);
                    int owner = end > -1 ? Convert.ToInt32(text.Substring(start, end - start)) : Convert.ToInt32(text.Substring(start));
                    if (p)
                    {
                        AnalyzeUser(owner, id);
                    }
                }
            }

        }

        // 批量下载
        private void btnBatchDownload_Click(object sender, EventArgs e)
        {
            _isInBatchGatherMode = true;
            if (_imageSavePath == "")
            {
                SelectSavePath();
            }
            if (_imageSavePath == "")
            {
                _isInBatchGatherMode = false;
                return;
            }
            foreach (ListViewItem lvt in lstAlbum.Items)
            {
                lvt.SubItems[7].Text = "分析中";
                Application.DoEvents();
                AnalyzeList(lvt.SubItems[6].Text, lvt.SubItems[1].Text, lvt.SubItems[8].Text);
                lvt.SubItems[7].Text = "下载中";
                Application.DoEvents();
                string dir = CorrectFilename(lvt.SubItems[1].Text);
                string path = _imageSavePath + "\\" + lvt.SubItems[8].Text + "\\" + dir;
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                StreamWriter sw = new StreamWriter(path + "\\index.htm", false, Encoding.UTF8);
                sw.WriteLine(@"<html xmlns=""http://www.w3.org/1999/xhtml"">
<head>
<meta http-equiv=""Content-Type"" content=""text/html; charset=gb2312"" />
<title>{0} 相册 - 校内相册批量下载器</title>
</head>
<body>", lvt.SubItems[1].Text);
                sw.WriteLine("<div id=\"Title\"><h3><a href=\"{0}\">{1}</a></h3><p>{2}</p><p>图片数：{3} |创建时间：{4} |更新时间：{5}</p></div>",
                    lvt.SubItems[6].Text,
                    lvt.SubItems[1].Text,
                    lvt.SubItems[3].Text,
                    lvt.SubItems[2].Text,
                    lvt.SubItems[5].Text,
                    lvt.SubItems[4].Text);
                foreach (ListViewItem inlvt in lstPhoto.Items)
                {
                    string url = inlvt.SubItems[2].Text;
                    string file;
                    string ext = url.Substring(url.LastIndexOf("."));
                    file = url.Substring(url.LastIndexOf("/") + 1);
                    file = file.Substring(0, file.LastIndexOf("."));
                    string failedString = "";
                    if (DownloadFile(url, _imageSavePath + inlvt.SubItems[7].Text, CorrectFilename(file) + ext))
                    {
                        lstPhoto.Items.Remove(inlvt);
                        Application.DoEvents();
                        failedString = "";
                    }
                    else
                    {
                        failedString = "<font color=\"red\"><b>下载失败</b></font>";
                    }
                    sw.WriteLine("<div class=\"image-list\"><div class=\"image\"><a href=\"{0}\"><img width=\"100\" src=\"{0}\" /></a></div>" +
                        "<div class=\"text\"><span><a href=\"{0}\">{0}</a></span> | <span><a href=\"{1}\">原始图片</a></span>{6}" +
                        "<p>{2}</p><p>浏览({3})|评论({4})  上传于{5}</p></div></div>",
                        CorrectFilename(file) + ext,
                        url,
                        inlvt.SubItems[3].Text.Trim(),
                        inlvt.SubItems[4].Text.Trim(),
                        inlvt.SubItems[5].Text.Trim(),
                        inlvt.SubItems[6].Text.Trim(),
                        failedString);
                }
                sw.WriteLine("</body></html>");
                sw.Flush();
                sw.Dispose();
                lvt.SubItems[7].Text = "完成";
            }

            _isInBatchGatherMode = false;
        }

        // 选择下载保存地址
        private void btnSelectSavePath_Click(object sender, EventArgs e)
        {
            SelectSavePath();
        }

        // 获取首页更新列表中的所有相册，放入列表，（尚未完成）
        private void btnGetHome_Click(object sender, EventArgs e)
        {
            MessageBox.Show("抱歉，尚未完成！");
        }

        #endregion

        private void mnuPasteList_Click(object sender, EventArgs e)
        {
            string links = Clipboard.GetText();
            string[] link = links.Split('\n');
            foreach (string lk in link)
            {
                if (lk.StartsWith("http://photo.xiaonei.com/getalbum.do?"))
                {
                    int start = lk.IndexOf("id=");
                    if (start > -1)
                    {
                        start += 3;
                        int end = lk.IndexOf("&", start);
                        int id = Convert.ToInt32(lk.Substring(start, end - start - 1));
                        start = lk.IndexOf("owner=") + "owner=".Length;
                        int owner = Convert.ToInt32(lk.Substring(start));
                        if (end > -1)
                        {
                            AnalyzeUser(owner, id);
                        }
                    }
                }
                Application.DoEvents();
            }

        }

        private void mnuAlbumExport_Click(object sender, EventArgs e)
        {
            string links = "";
            foreach (ListViewItem lvt in lstAlbum.Items)
            {
                links += lvt.SubItems[6].Text + "\r\n";
            }
            if (links != "") Clipboard.SetText(links);
        }
    }
}
