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
            CourseTime time = new CourseTime();
            time.year = 105;
            time.smester = 2;
            string post_data = JsonConvert.SerializeObject(time);
            string apps_login = "https://apps.fcu.edu.tw/main/infologin.aspx";
            string course_data = "https://apps.fcu.edu.tw/main/S3202/S3202_timetable_new.aspx/GetCurriculum";
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            NameValueCollection values = new NameValueCollection();
            string source = "";
            apps.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
            apps.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            apps.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/48.0.2564.116 Safari/537.36");
            source = apps.DownloadString(apps_login, schoolEncoding);
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
            source = schoolEncoding.GetString(apps.UploadValues(apps_login, values));
            values.Clear();
            apps.Headers.Clear();
            apps.Headers.Add("Accept", "application/json, text/plain, */*");
            apps.Headers.Add("Content-Type", "application/json; charset=UTF-8");
            source = apps.UploadString(course_data, post_data);
            dynamic CourseData = JsonConvert.DeserializeObject(source);
            return CourseData;
            //for(int i=0;i<14;i++)
            //{
            //    if(i<CourseData.d.table.Count)
            //    {
            //        foreach (dynamic k in CourseData.d.table[i].courses)
            //        {
            //            Console.WriteLine(k.week);
            //            Console.WriteLine("-----------------------------");
            //        }
            //    }
            //}

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
            dynamic get_data = get_apps();
            //get_apps();
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
            this.Text = name;
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
    }
    public class CourseTime
    {
        public int year { get; set; }
        public int smester { get; set; }
    }
}
