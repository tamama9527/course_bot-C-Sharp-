using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.already_point = new System.Windows.Forms.Label();
            this.label_already_point = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.time_text = new System.Windows.Forms.Label();
            this.status_text = new System.Windows.Forms.Label();
            this.point_text = new System.Windows.Forms.Label();
            this.name_text = new System.Windows.Forms.Label();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.course_time = new System.Windows.Forms.Label();
            this.course_status = new System.Windows.Forms.Label();
            this.course_point = new System.Windows.Forms.Label();
            this.course_name = new System.Windows.Forms.Label();
            this.SearchButton = new System.Windows.Forms.Button();
            this.code_box = new System.Windows.Forms.TextBox();
            this.label_course_code = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.course = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.week1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.week2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.week3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.week4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.week5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.course_class = new System.Windows.Forms.Label();
            this.class_text = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(437, 362);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 32);
            this.button1.TabIndex = 0;
            this.button1.Text = "登出";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.already_point);
            this.groupBox1.Controls.Add(this.label_already_point);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(191, 94);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "個人資料";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(103, 65);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(82, 23);
            this.button4.TabIndex = 15;
            this.button4.Text = "停止搶課";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 65);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(91, 23);
            this.button3.TabIndex = 14;
            this.button3.Text = "開始搶課";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // already_point
            // 
            this.already_point.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.already_point.Location = new System.Drawing.Point(103, 27);
            this.already_point.Name = "already_point";
            this.already_point.Size = new System.Drawing.Size(54, 24);
            this.already_point.TabIndex = 3;
            // 
            // label_already_point
            // 
            this.label_already_point.AutoSize = true;
            this.label_already_point.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_already_point.Location = new System.Drawing.Point(6, 27);
            this.label_already_point.Name = "label_already_point";
            this.label_already_point.Size = new System.Drawing.Size(91, 24);
            this.label_already_point.TabIndex = 2;
            this.label_already_point.Text = "已選學分:";
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(437, 12);
            this.listView1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(294, 344);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.class_text);
            this.groupBox2.Controls.Add(this.course_class);
            this.groupBox2.Controls.Add(this.time_text);
            this.groupBox2.Controls.Add(this.status_text);
            this.groupBox2.Controls.Add(this.point_text);
            this.groupBox2.Controls.Add(this.name_text);
            this.groupBox2.Controls.Add(this.RemoveButton);
            this.groupBox2.Controls.Add(this.AddButton);
            this.groupBox2.Controls.Add(this.course_time);
            this.groupBox2.Controls.Add(this.course_status);
            this.groupBox2.Controls.Add(this.course_point);
            this.groupBox2.Controls.Add(this.course_name);
            this.groupBox2.Controls.Add(this.SearchButton);
            this.groupBox2.Controls.Add(this.code_box);
            this.groupBox2.Controls.Add(this.label_course_code);
            this.groupBox2.Location = new System.Drawing.Point(12, 112);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(191, 279);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "課程檢索";
            // 
            // time_text
            // 
            this.time_text.AutoSize = true;
            this.time_text.Location = new System.Drawing.Point(8, 218);
            this.time_text.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.time_text.Name = "time_text";
            this.time_text.Size = new System.Drawing.Size(0, 12);
            this.time_text.TabIndex = 13;
            // 
            // status_text
            // 
            this.status_text.AutoSize = true;
            this.status_text.Location = new System.Drawing.Point(56, 163);
            this.status_text.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.status_text.Name = "status_text";
            this.status_text.Size = new System.Drawing.Size(0, 12);
            this.status_text.TabIndex = 12;
            // 
            // point_text
            // 
            this.point_text.AutoSize = true;
            this.point_text.Location = new System.Drawing.Point(44, 131);
            this.point_text.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.point_text.Name = "point_text";
            this.point_text.Size = new System.Drawing.Size(0, 12);
            this.point_text.TabIndex = 11;
            // 
            // name_text
            // 
            this.name_text.AutoSize = true;
            this.name_text.Location = new System.Drawing.Point(68, 67);
            this.name_text.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.name_text.Name = "name_text";
            this.name_text.Size = new System.Drawing.Size(0, 12);
            this.name_text.TabIndex = 10;
            // 
            // RemoveButton
            // 
            this.RemoveButton.Location = new System.Drawing.Point(103, 250);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(82, 23);
            this.RemoveButton.TabIndex = 9;
            this.RemoveButton.Text = "移除搶課";
            this.RemoveButton.UseVisualStyleBackColor = true;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(6, 250);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(91, 23);
            this.AddButton.TabIndex = 8;
            this.AddButton.Text = "加入搶課";
            this.AddButton.UseVisualStyleBackColor = true;
            // 
            // course_time
            // 
            this.course_time.AutoSize = true;
            this.course_time.Location = new System.Drawing.Point(8, 195);
            this.course_time.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.course_time.Name = "course_time";
            this.course_time.Size = new System.Drawing.Size(158, 12);
            this.course_time.TabIndex = 6;
            this.course_time.Text = "上課時間/上課教室/授課教師:";
            // 
            // course_status
            // 
            this.course_status.AutoSize = true;
            this.course_status.Location = new System.Drawing.Point(6, 163);
            this.course_status.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.course_status.Name = "course_status";
            this.course_status.Size = new System.Drawing.Size(44, 12);
            this.course_status.TabIndex = 5;
            this.course_status.Text = "必選修:";
            // 
            // course_point
            // 
            this.course_point.AutoSize = true;
            this.course_point.Location = new System.Drawing.Point(6, 131);
            this.course_point.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.course_point.Name = "course_point";
            this.course_point.Size = new System.Drawing.Size(32, 12);
            this.course_point.TabIndex = 4;
            this.course_point.Text = "學分:";
            // 
            // course_name
            // 
            this.course_name.AutoSize = true;
            this.course_name.Location = new System.Drawing.Point(8, 67);
            this.course_name.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.course_name.Name = "course_name";
            this.course_name.Size = new System.Drawing.Size(56, 12);
            this.course_name.TabIndex = 3;
            this.course_name.Text = "科目名稱:";
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(123, 16);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(62, 27);
            this.SearchButton.TabIndex = 2;
            this.SearchButton.Text = "搜尋";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // code_box
            // 
            this.code_box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.code_box.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.code_box.Location = new System.Drawing.Point(65, 15);
            this.code_box.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.code_box.MaxLength = 4;
            this.code_box.Name = "code_box";
            this.code_box.Size = new System.Drawing.Size(45, 29);
            this.code_box.TabIndex = 1;
            this.code_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.code_box.WordWrap = false;
            // 
            // label_course_code
            // 
            this.label_course_code.AutoSize = true;
            this.label_course_code.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_course_code.Location = new System.Drawing.Point(6, 18);
            this.label_course_code.Name = "label_course_code";
            this.label_course_code.Size = new System.Drawing.Size(53, 24);
            this.label_course_code.TabIndex = 0;
            this.label_course_code.Text = "代碼:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(588, 362);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(145, 32);
            this.button2.TabIndex = 5;
            this.button2.Text = "結束";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.course,
            this.week1,
            this.week2,
            this.week3,
            this.week4,
            this.week5});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 18);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(203, 358);
            this.dataGridView1.TabIndex = 0;
            // 
            // course
            // 
            this.course.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.course.FillWeight = 21.3198F;
            this.course.HeaderText = " ";
            this.course.Name = "course";
            this.course.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // week1
            // 
            this.week1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.week1.FillWeight = 25.73604F;
            this.week1.HeaderText = "一";
            this.week1.Name = "week1";
            this.week1.ReadOnly = true;
            this.week1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.week1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // week2
            // 
            this.week2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.week2.FillWeight = 25.73604F;
            this.week2.HeaderText = "二";
            this.week2.Name = "week2";
            this.week2.ReadOnly = true;
            this.week2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.week2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // week3
            // 
            this.week3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.week3.FillWeight = 25.73604F;
            this.week3.HeaderText = "三";
            this.week3.Name = "week3";
            this.week3.ReadOnly = true;
            this.week3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.week3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // week4
            // 
            this.week4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.week4.FillWeight = 25.73604F;
            this.week4.HeaderText = "四";
            this.week4.Name = "week4";
            this.week4.ReadOnly = true;
            this.week4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.week4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // week5
            // 
            this.week5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.week5.FillWeight = 25.73604F;
            this.week5.HeaderText = "五";
            this.week5.Name = "week5";
            this.week5.ReadOnly = true;
            this.week5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.week5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Location = new System.Drawing.Point(209, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(209, 379);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "課表";
            // 
            // course_class
            // 
            this.course_class.AutoSize = true;
            this.course_class.Location = new System.Drawing.Point(8, 99);
            this.course_class.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.course_class.Name = "course_class";
            this.course_class.Size = new System.Drawing.Size(56, 12);
            this.course_class.TabIndex = 14;
            this.course_class.Text = "開課班級:";
            // 
            // class_text
            // 
            this.class_text.AutoSize = true;
            this.class_text.Location = new System.Drawing.Point(68, 99);
            this.class_text.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.class_text.Name = "class_text";
            this.class_text.Size = new System.Drawing.Size(0, 12);
            this.class_text.TabIndex = 15;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 400);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Text = "Form2";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_already_point;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label already_point;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox code_box;
        private System.Windows.Forms.Label label_course_code;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox3;
        private DataGridViewTextBoxColumn course;
        private DataGridViewTextBoxColumn week1;
        private DataGridViewTextBoxColumn week2;
        private DataGridViewTextBoxColumn week3;
        private DataGridViewTextBoxColumn week4;
        private DataGridViewTextBoxColumn week5;
        private Button RemoveButton;
        private Button AddButton;
        private Label course_time;
        private Label course_status;
        private Label course_point;
        private Label course_name;
        private Label name_text;
        private Label point_text;
        private Label status_text;
        private Label time_text;
        private Button button4;
        private Button button3;
        private Label course_class;
        private Label class_text;
    }
}