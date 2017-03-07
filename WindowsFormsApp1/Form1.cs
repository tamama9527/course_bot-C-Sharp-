using System;
using System.Collections.Generic;
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
        Encoding schoolEncoding = Encoding.GetEncoding("utf-8");
        string login_url = "https://course.fcu.edu.tw/Login.aspx";
        public Form1()
        {
            InitializeComponent();
            
            string source=client.DownloadString(login_url, schoolEncoding);
            //Console.WriteLine(source);
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(source);
            Console.WriteLine(source);
            HtmlAgilityPack.HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//input");
            foreach (HtmlAgilityPack.HtmlNode htmlnode in nodes)
            {
                Console.WriteLine(htmlnode.Attributes["name"].Value);
            }
          

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine(account.Text);
            Console.WriteLine(password.Text);
            Form2 f = new Form2();
            f.FormClosed += new FormClosedEventHandler(Form2_FormClosed);
            f.Show();
            this.Hide();
        }
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
    }
}
