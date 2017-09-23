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
        SpWebClient client2 = new SpWebClient();
        string Username;
        string Password;
        SpWebClient apps = new SpWebClient();
        Encoding schoolEncoding = Encoding.GetEncoding("utf-8");
        string source;
        string url_last;
        string host = "";
        public Form2()
        {
            InitializeComponent();
        }
        public void get_course_table(String C_table)
        {
            string[] course_table = new string[6] {"", "", "", "", "", "" };

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(C_table);
            HtmlAgilityPack.HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//table[@id='ctl00_MainContent_TabContainer1_tabCourseSearch_wcCourseSearch_gvWishListTimeTable']//tr");
            //製作課表
            DataGridViewRowCollection rows = dataGridView1.Rows;

            for (int i = 1; i <= 14; i++)
            {
                
                HtmlAgilityPack.HtmlNode node = nodes[i];
                for (int j=1;j<=6;j++)
                {
                    if(node.ChildNodes[j].Attributes["class"].Value != "week" && node.ChildNodes[j].Attributes["class"].Value != "week w")
                        course_table[j - 1] = node.ChildNodes[j].InnerText;
                }
                rows.Add(course_table[0],course_table[1],course_table[2],course_table[3],course_table[4],course_table[5]);
                Array.Clear(course_table,0,course_table.Length);
                dataGridView1.Rows[i-1].Resizable = DataGridViewTriState.False;
                //Console.WriteLine("");

            }
        }
        public Form2(string username,string password,SpWebClient client)
        {
            client2 = client;
            Username = username;
            Password = password;
            InitializeComponent();
            string name = "";
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            client2.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            source = client2.DownloadString(client2.ResponseUri, schoolEncoding);
            doc.LoadHtml(source);

            host = client2.ResponseUri.ToString().Split('?')[0];
            HtmlAgilityPack.HtmlNodeCollection url_nodes = doc.DocumentNode.SelectNodes("//form[@name='aspnetForm']");
            url_last = host + url_nodes[0].Attributes["action"].Value;
            Console.WriteLine(url_last);

            HtmlAgilityPack.HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//span[@id='ctl00_MainContent_lblCredit']");
            //get 課表資料 after 要寫成時間自動化

            nodes = doc.DocumentNode.SelectNodes("//span[@id='ctl00_MainContent_TabContainer1_tabSelected_lblCredit']");
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
            get_course_table(source);

        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            NameValueCollection values = new NameValueCollection();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(source);
            HtmlAgilityPack.HtmlNodeCollection hidden_patten = doc.DocumentNode.SelectNodes("//input[@value][@type='hidden']");
            foreach (HtmlAgilityPack.HtmlNode patten in hidden_patten)
            {
                values.Add(patten.Attributes["name"].Value, patten.Attributes["value"].Value);
            }
            values.Add("ctl00$MainContent$TabContainer1$tabSelected$btnGetSub", "查詢");
            values.Remove("ctl00_MainContent_TabContainer1_ClientState");
            values.Add("ctl00_MainContent_TabContainer1_ClientState","{\"ActiveTabIndex\":1,\"TabState\":[true,true,true]}");
            values.Add("ctl00$MainContent$TabContainer1$tabSelected$tbSubID", code_box.Text);

            client2.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            source = schoolEncoding.GetString(client2.UploadValues(url_last, values));
            doc.LoadHtml(source);
            HtmlAgilityPack.HtmlNode course_data = doc.DocumentNode.SelectNodes("//table[@id='ctl00_MainContent_TabContainer1_tabSelected_gvToAdd']/tr")[1];
            class_text.Text = course_data.ChildNodes[3].InnerText;
            name_text.Text = course_data.ChildNodes[4].InnerText;
            status_text.Text = course_data.ChildNodes[5].InnerText;
            point_text.Text = course_data.ChildNodes[6].InnerText;
            time_text.Text = course_data.ChildNodes[7].InnerText;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Close();
        }

    }
}
