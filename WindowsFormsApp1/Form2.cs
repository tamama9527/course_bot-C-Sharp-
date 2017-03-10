using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            DataGridViewRowCollection rows = dataGridView1.Rows;

            for (int i = 0; i < 14; i++)
            {
                rows.Add(Convert.ToString(i + 1), "", "", "", "", "");
                dataGridView1.Rows[i].Resizable = DataGridViewTriState.False;
            }
            //rows.Add(new Object[] { 3214, 3214, 3214, 3214 ,3215 });
            //dataGridView1.Rows[0].HeaderCell.Value="1";
            //dataGridView1.Rows[0].Resizable = DataGridViewTriState.False;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

    }
}
