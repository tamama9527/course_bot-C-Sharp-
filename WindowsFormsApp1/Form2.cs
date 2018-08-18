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
using System.IO;
using System.Threading;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public User user = new User();
        public bool run;
        public SpWebClient client2 = new SpWebClient();
        string Username;
        string Password;
        public Encoding schoolEncoding = Encoding.GetEncoding("utf-8");
        public string source;
        public string url_last;
        public string host = "";
        string temp_code;
        bool flag;
        public List<string> already =new List<string>();
        int number;
        public DataGridViewRowCollection rows;
        public Form2()
        {
            InitializeComponent();
        }
        public void get_course_table(String c_table)
        {
            string[] course_table = new string[6] {"", "", "", "", "", "" };
            rows = dataGridView1.Rows;
            rows.Clear();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(c_table);
            HtmlAgilityPack.HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//table[@id='ctl00_MainContent_TabContainer1_tabCourseSearch_wcCourseSearch_gvWishListTimeTable']//tr");
            //製作課表
            for (int i = 1; i <= 14; i++)
            {
                HtmlAgilityPack.HtmlNode node = nodes[i];

                for (int j=1;j<=6;j++)
                {
                    if(node.ChildNodes[j].Attributes["class"].Value != "week" && node.ChildNodes[j].Attributes["class"].Value != "week w")
                    {
                        course_table[j - 1] = node.ChildNodes[j].InnerText;
                    }
                    
                }
                rows.Add(course_table[0],course_table[1],course_table[2],course_table[3],course_table[4],course_table[5]);
                Array.Clear(course_table,0,course_table.Length);
                rows[i-1].Resizable = DataGridViewTriState.False;
            }
        }
        public Form2(string username, string password, SpWebClient client, User user1)
        {
            using (StreamReader r = new StreamReader("config.json"))
            {
                string json = r.ReadToEnd();
                user = JsonConvert.DeserializeObject<User>(json);
                r.Close();
            }
            client2 = client;
            Username = username;
            Password = password;
            InitializeComponent();
            string name = "";
            logger.Enabled = false;
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            client2.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            source = client2.DownloadString(client2.ResponseUri, schoolEncoding);
            doc.LoadHtml(source);

            host = client2.ResponseUri.ToString().Split('?')[0];
            HtmlAgilityPack.HtmlNodeCollection url_nodes = doc.DocumentNode.SelectNodes("//form[@name='aspnetForm']");

            url_last = host + url_nodes[0].Attributes["action"].Value;

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
            HtmlAgilityPack.HtmlNode course_data;
            try
            {
                flag = true;
                course_data = doc.DocumentNode.SelectNodes("//table[@id='ctl00_MainContent_TabContainer1_tabSelected_gvToAdd']/tr")[1];
            }
            catch (Exception)
            {
                flag = false;
                course_data = doc.DocumentNode.SelectNodes("//table[@id='ctl00_MainContent_TabContainer1_tabSelected_gvToDel']/tr")[1];
            }
            class_text.Text = course_data.ChildNodes[3].InnerText;
            name_text.Text = course_data.ChildNodes[4].InnerText;
            status_text.Text = course_data.ChildNodes[5].InnerText;
            point_text.Text = course_data.ChildNodes[6].InnerText;
            time_text.Text = course_data.ChildNodes[7].InnerText;
        }
        private void error_logout()
        {
            this.Close();
            Form1 f = new Form1();
            f.Show();
            this.Close();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.ShowDialog();
            this.Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (code_box.Text != "")
            {
                if (user.firstchoose == null)
                {
                    user.firstchoose = new List<string>();
                    user.firstchoose.Add(code_box.Text);
                    MessageBox.Show(code_box.Text + "已成功加入搶課名單內");
                }
                else if(!user.firstchoose.Contains(code_box.Text, StringComparer.OrdinalIgnoreCase))
                {
                    if (flag)
                    {
                        user.firstchoose.Add(code_box.Text);
                        MessageBox.Show(code_box.Text + "已成功加入搶課名單內");
                    }
                    else
                    {
                        MessageBox.Show(code_box.Text + " 你已經擁有此課程");
                    }
                }
                else
                {
                    MessageBox.Show("此課程已在搶課名單內");
                }
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (code_box.Text != "")
            {
                if (user.firstchoose.Contains(code_box.Text, StringComparer.OrdinalIgnoreCase))
                {
                    user.firstchoose.Remove(code_box.Text);
                    MessageBox.Show(code_box.Text + "已成功移除搶課名單內");
                }
                else
                {
                    MessageBox.Show("此課程已不在搶課名單內");
                }
            }
        }

        private void startget_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(get_class);
            run = true;
            SearchButton.Enabled = false;
            thread.Start();
            using (StreamWriter outputFile = new StreamWriter(@"config.json"))
            {
                string json = JsonConvert.SerializeObject(user, Formatting.Indented);
                outputFile.Write(json);
                outputFile.Close();
            }
        }

        private void stopget_Click(object sender, EventArgs e)
        {
            using (StreamWriter outputFile = new StreamWriter(@"config.json"))
            {
                string json = JsonConvert.SerializeObject(user, Formatting.Indented);
                outputFile.Write(json);
                outputFile.Close();
            }
            run = false;
            SearchButton.Enabled = true;
        }

        private void UpdateUI()
        {
            get_course_table(source);
        }

        private void list_updateUI()
        {
            logger.AppendText(DateTime.Now.ToString("HH:mm:ss tt 課程代碼:")+temp_code + "剩餘人數:" + Convert.ToString(number)+"\n");
        }

        public void get_class()
        {
            NameValueCollection values = new NameValueCollection();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            HtmlAgilityPack.HtmlNodeCollection hidden_patten;
            while (run)
            {
                foreach (string code in user.firstchoose.ToArray())
                {
                    temp_code = code;
                    doc.LoadHtml(source);
                    hidden_patten = doc.DocumentNode.SelectNodes("//input[@value][@type='hidden']");
                    foreach (HtmlAgilityPack.HtmlNode patten in hidden_patten)
                    {
                        values.Add(patten.Attributes["name"].Value, patten.Attributes["value"].Value);
                    }
                    values.Add("ctl00$MainContent$TabContainer1$tabSelected$btnGetSub", "查詢");
                    values.Remove("ctl00_MainContent_TabContainer1_ClientState");
                    values.Add("ctl00_MainContent_TabContainer1_ClientState", "{\"ActiveTabIndex\":2,\"TabState\":[true,true,true]}");
                    values.Add("ctl00$MainContent$TabContainer1$tabSelected$tbSubID", code);

                    client2.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                    source = schoolEncoding.GetString(client2.UploadValues(url_last, values));
                    values.Clear();
                    doc.LoadHtml(source);
                    hidden_patten = doc.DocumentNode.SelectNodes("//input[@value][@type='hidden']");
                    foreach (HtmlAgilityPack.HtmlNode patten in hidden_patten)
                    {
                        values.Add(patten.Attributes["name"].Value, patten.Attributes["value"].Value);
                    }
                    values.Remove("ctl00_MainContent_TabContainer1_ClientState");
                    values.Add("ctl00_MainContent_TabContainer1_ClientState", "{\"ActiveTabIndex\":2,\"TabState\":[true,true,true]}");
                    values.Remove("ctl00$MainContent$TabContainer1$tabSelected$btnGetSub");
                    values.Remove("ctl00$MainContent$TabContainer1$tabSelected$tbSubID");
                    values.Remove("ctl00_ToolkitScriptManager1_HiddenField");
                    values.Add("__EVENTTARGET", "ctl00$MainContent$TabContainer1$tabSelected$gvToAdd");
                    values.Add("__EVENTARGUMENT", "selquota$0");
                    values.Add("ctl00$MainContent$TabContainer1$tabCourseSearch$wcCourseSearch$ddlSpecificSubjects", "1");
                    client2.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                    client2.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
                    client2.Headers.Remove("Origin");
                    source = schoolEncoding.GetString(client2.UploadValues(url_last, values));
                    values.Clear();
                    doc.LoadHtml(source);
                    HtmlAgilityPack.HtmlNode temp = doc.DocumentNode.SelectSingleNode("//script[not(@*)]");
                    Regex reg = new Regex(@"\d+");
                    MethodInvoker mi;
                    try
                    {
                        number = Convert.ToInt16(reg.Match(temp.InnerText).Value);
                    }
                    catch (Exception)
                    {
                        number = 0;
                    }
                    mi = new MethodInvoker(this.list_updateUI);
                    this.BeginInvoke(mi, null);
                    if (number > 0)
                    {
                        hidden_patten = doc.DocumentNode.SelectNodes("//input[@value][@type='hidden']");
                        foreach (HtmlAgilityPack.HtmlNode patten in hidden_patten)
                        {
                            values.Add(patten.Attributes["name"].Value, patten.Attributes["value"].Value);
                        }
                        values.Remove("ctl00_MainContent_TabContainer1_ClientState");
                        values.Add("ctl00_MainContent_TabContainer1_ClientState", "{\"ActiveTabIndex\":1,\"TabState\":[true,true,true]}");
                        values.Remove("ctl00$MainContent$TabContainer1$tabSelected$btnGetSub");
                        values.Remove("ctl00$MainContent$TabContainer1$tabSelected$tbSubID");
                        values.Remove("ctl00_ToolkitScriptManager1_HiddenField");
                        values.Add("__EVENTTARGET", "ctl00$MainContent$TabContainer1$tabSelected$gvToAdd");
                        values.Add("__EVENTARGUMENT", "addCourse$0");
                        values.Add("ctl00$MainContent$TabContainer1$tabCourseSearch$wcCourseSearch$ddlSpecificSubjects", "1");
                        client2.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                        client2.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
                        client2.Headers.Remove("Origin");
                        source = schoolEncoding.GetString(client2.UploadValues(url_last, values));
                        values.Clear();
                        doc.LoadHtml(source);
                        temp = doc.DocumentNode.SelectSingleNode("//*[@id='ctl00_MainContent_TabContainer1_tabSelected_lblMsgBlock']/span");
                        if (temp != null)
                        {
                            if (temp.InnerText == "加選成功")
                            {
                                user.firstchoose.Remove(code);
                                mi = new MethodInvoker(this.UpdateUI);
                                this.BeginInvoke(mi, null);
                            }
                                
                        }
                    }
                    source = client2.DownloadString(client2.ResponseUri, schoolEncoding);
                    Console.WriteLine(source);
                }
                if (user.firstchoose.Count == 0)
                {
                    SearchButton.Enabled = true;
                    break;
                } 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
