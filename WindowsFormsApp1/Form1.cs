﻿using Newtonsoft.Json;
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
        public User user;
        public Form1()
        {
            InitializeComponent();
            first();
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
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            //設定header
            client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/48.0.2564.116 Safari/537.36");
            client.Headers.Add("Origin", "http://service105.sds.fcu.edu.tw");
            client.Headers.Add("Referer", "http://service105.sds.fcu.edu.tw");
            client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            
            string source = "";

            //增加post資料
            values["ctl00$Login1$UserName"] = account.Text;
            values["ctl00$Login1$Password"] = password.Text;

            //登入網頁
            source = schoolEncoding.GetString(client.UploadValues(login_url, values));
            doc.LoadHtml(source);
            HtmlAgilityPack.HtmlNode cant_login = doc.DocumentNode.SelectSingleNode("/span[@class='msg B1']");
            Console.WriteLine(source);
            Console.WriteLine(values);
            if (cant_login != null)
            {
                MessageBox.Show(doc.DocumentNode.SelectSingleNode("/span[@class='msg B1']").InnerText);
            }
            else if (Convert.ToString(client.ResponseUri) != "https://course.fcu.edu.tw/Login.aspx") {
                this.Hide();
                Form2 f = new Form2(account.Text, password.Text, client, user);
                f.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("帳號或密碼錯誤");
            }
            
        }
        void first()
        {
            try
            {   // Open the text file using a stream reader.
                using (StreamReader r = new StreamReader("config.json"))
                {
                    string json = r.ReadToEnd();
                    user = JsonConvert.DeserializeObject<User>(json);

                    if (user.Rember == true)
                    {
                        account.Text = user.account;
                        password.Text = user.passwd;
                        checkBox1.Checked = true;
                    }
                    foreach (string s in user.firstchoose)
                    {
                        Console.WriteLine(s);
                    }
                    checkBox1.Checked = true;
                    r.Close();

                }

            }
            catch (Exception)
            {
                user = new User();
            }
            
        }
        

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            user.account = account.Text;
            user.passwd = password.Text;
            if (checkBox1.Checked == true)
            {
                user.Rember = true;
                using (StreamWriter outputFile = new StreamWriter(@"config.json"))
                {
                    string json = JsonConvert.SerializeObject(user, Formatting.Indented);
                    outputFile.Write(json);
                    outputFile.Close();
                }
            }
            else
            {
                user.Rember = false;
                User userT = new User();
                using (StreamWriter outputFile = new StreamWriter(@"config.json"))
                {
                    string json = JsonConvert.SerializeObject(userT, Formatting.Indented);
                    outputFile.Write(json);
                    outputFile.Close();
                }
            }
        }
    }
}
public class User
{
    public string account { get; set; }
    public string passwd { get; set; }
    public bool Rember { get; set; }
    public List<string> firstchoose { get; set; }
}