using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        SpWebClient client = new SpWebClient();
        NameValueCollection values = new NameValueCollection();
        Encoding schoolEncoding = Encoding.GetEncoding("utf-8");
        string login_url = "https://course.fcu.edu.tw/Login.aspx";
        Random ran = new Random(Guid.NewGuid().GetHashCode());
        public Form1()
        {
            InitializeComponent();
            prepare();
        }

        void prepare()
        {
            
            string source = client.DownloadString(login_url, schoolEncoding);
            //產生驗證碼
            string code = ran.Next(9999).ToString("0000");

            //html分析
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(source);
            HtmlAgilityPack.HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//input[@type='hidden']");
            //爬取hidden資料 塞入postdata中
            foreach (HtmlAgilityPack.HtmlNode htmlnode in nodes)
            {
                values.Add(htmlnode.Attributes["name"].Value, htmlnode.Attributes["value"].Value);
            }
            values.Add("__EVENTTARGET", "ctl00$Login1$LoginButton");
            values.Add("ctl00$Login1$RadioButtonList1", "zh-tw");
            values.Add("ctl00$Login1$vcode", code);

            //將驗證碼塞入cookie
            Cookie check_code = new Cookie("CheckCode", code);
            check_code.Domain = "course.fcu.edu.tw";
            client.CookieContainer.Add(check_code);

        }

        private void login(object sender, EventArgs e)
        {
            //設定header
            client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/48.0.2564.116 Safari/537.36");
            client.Headers.Add("Origin", "http://service105.sds.fcu.edu.tw");
            client.Headers.Add("Referer", "http://service105.sds.fcu.edu.tw");
            client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            
            string source = "";

            //增加post資料
            values.Add("ctl00$Login1$UserName", account.Text);
            values.Add("ctl00$Login1$Password", password.Text);

            //登入網頁
            source = schoolEncoding.GetString(client.UploadValues(login_url, values));
            Form2 f = new Form2(account.Text,password.Text,client);
            f.Show();
            this.Hide();
        }
    }
}
