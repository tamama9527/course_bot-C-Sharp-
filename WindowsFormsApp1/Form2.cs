using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections.Specialized;
using Newtonsoft.Json;
namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        string Username;
        string Password;
        SpWebClient client2 = new SpWebClient();
        SpWebClient apps = new SpWebClient();
        Encoding schoolEncoding = Encoding.GetEncoding("utf-8");
        public Form2()
        {
            InitializeComponent();
        }
        public object get_apps()
        {
            //把class資料轉成json格式
            CourseTime time = new CourseTime();
            time.year = 105;
            time.smester = 2;
            string post_data = JsonConvert.SerializeObject(time);

            //基本網址 跟一些初始化
            string apps_login = "https://apps.fcu.edu.tw/main/infologin.aspx";
            string course_data = "https://apps.fcu.edu.tw/main/S3202/S3202_timetable_new.aspx/GetCurriculum";
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            NameValueCollection values = new NameValueCollection();
            string source = "";

            //增加headers
            apps.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
            apps.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            apps.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/48.0.2564.116 Safari/537.36");

            //先get apps登入頁面
            source = apps.DownloadString(apps_login, schoolEncoding);
            //分析input
            doc.LoadHtml(source);
            HtmlAgilityPack.HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//input[@type='hidden']");
            foreach(HtmlAgilityPack.HtmlNode node in nodes)
            {
                if (node.Attributes["value"].Value != "")
                {
                    values.Add(node.Attributes["name"].Value, node.Attributes["value"].Value);
                }
            }
            values.Add("txtUserName", Username);
            values.Add("txtPassword", Password);
            values.Add("OKButton", "login");
            //登入apps
            source = schoolEncoding.GetString(apps.UploadValues(apps_login, values));

            //增加json的headers
            apps.Headers.Clear();
            apps.Headers.Add("Accept", "application/json, text/plain, */*");
            apps.Headers.Add("Content-Type", "application/json; charset=UTF-8");

            //get 課表json
            source = apps.UploadString(course_data, post_data);

            //將json包成object 回傳
            dynamic CourseData = JsonConvert.DeserializeObject(source);
            return CourseData;
        }
        public Form2(string username,string password,SpWebClient client)
        {
            Username = username;
            Password = password;
            InitializeComponent();
            string name = "";
            client2 = client;
            string[] course_table = new string[5] { "","","","",""};

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            string source = client2.DownloadString(client2.ResponseUri, schoolEncoding);
            doc.LoadHtml(source);
            HtmlAgilityPack.HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//span[@id='ctl00_MainContent_lblCredit']");

            //get 課表資料 after 要寫成時間自動化
            dynamic get_data = get_apps();

            nodes = doc.DocumentNode.SelectNodes("//span[@id='ctl00_MainContent_lblCredit']");
            //找學分
            foreach (HtmlAgilityPack.HtmlNode node in nodes)
            {
                already_point.Text = node.InnerText.Substring(6);
            }
            //找名字
            nodes = doc.DocumentNode.SelectNodes("//span[@id='ctl00_userInfo1_lblName']");
            name += nodes[0].InnerText;
            name += " (";
            nodes = doc.DocumentNode.SelectNodes("//span[@id='ctl00_userInfo1_lblStuID']");
            name += nodes[0].InnerText;
            name += ")";

            //設定標題
            this.Text = name;

            //製作課表
            DataGridViewRowCollection rows = dataGridView1.Rows;
            for (int i = 0; i < 14; i++)
            {
                if (i < get_data.d.table.Count)
                {
                    foreach (dynamic k in get_data.d.table[i].courses)
                    {
                        if (k.week < 6)
                        {
                            course_table[k.week-1] = k.selcode;
                        }
                    }
                    rows.Add(Convert.ToString(i + 1), course_table[0], course_table[1], course_table[2], course_table[3], course_table[4]);
                    for(int j=0;j<5;j++)
                    {
                        course_table[j] = "";
                    }
                }
                else
                {
                    rows.Add(Convert.ToString(i + 1), "", "", "", "", "");
                }
                //設定課表不能由使用者拉大小
                dataGridView1.Rows[i].Resizable = DataGridViewTriState.False;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Console.WriteLine(client2.DownloadString(client2.ResponseUri, schoolEncoding));
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Close();
        }
    }
    //課表時間
    public class CourseTime
    {
        public int year { get; set; }
        public int smester { get; set; }
    }
}
