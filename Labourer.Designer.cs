namespace JustRipe2018
{
    partial class Labourer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Labourer));
            this.tabLabourer = new System.Windows.Forms.TabControl();
            this.tabTimetableLabourer = new System.Windows.Forms.TabPage();
            this.btnLogoutLabourer = new System.Windows.Forms.Button();
            this.btnMFriday = new System.Windows.Forms.Button();
            this.btnMThursday = new System.Windows.Forms.Button();
            this.btnMWednesday = new System.Windows.Forms.Button();
            this.btnMTuesday = new System.Windows.Forms.Button();
            this.btnMMonday = new System.Windows.Forms.Button();
            this.DataViewDailyL = new System.Windows.Forms.DataGridView();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.tabLabourer.SuspendLayout();
            this.tabTimetableLabourer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataViewDailyL)).BeginInit();
            this.SuspendLayout();
            // 
            // tabLabourer
            // 
            this.tabLabourer.Controls.Add(this.tabTimetableLabourer);
            this.tabLabourer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabLabourer.Location = new System.Drawing.Point(0, 0);
            this.tabLabourer.Name = "tabLabourer";
            this.tabLabourer.SelectedIndex = 0;
            this.tabLabourer.Size = new System.Drawing.Size(910, 720);
            this.tabLabourer.TabIndex = 0;
            // 
            // tabTimetableLabourer
            // 
            this.tabTimetableLabourer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabTimetableLabourer.BackgroundImage")));
            this.tabTimetableLabourer.Controls.Add(this.btnMFriday);
            this.tabTimetableLabourer.Controls.Add(this.btnMThursday);
            this.tabTimetableLabourer.Controls.Add(this.btnMWednesday);
            this.tabTimetableLabourer.Controls.Add(this.btnMTuesday);
            this.tabTimetableLabourer.Controls.Add(this.btnMMonday);
            this.tabTimetableLabourer.Controls.Add(this.DataViewDailyL);
            this.tabTimetableLabourer.Controls.Add(this.dateTimePicker2);
            this.tabTimetableLabourer.Controls.Add(this.btnLogoutLabourer);
            this.tabTimetableLabourer.Location = new System.Drawing.Point(4, 29);
            this.tabTimetableLabourer.Name = "tabTimetableLabourer";
            this.tabTimetableLabourer.Padding = new System.Windows.Forms.Padding(3);
            this.tabTimetableLabourer.Size = new System.Drawing.Size(902, 687);
            this.tabTimetableLabourer.TabIndex = 0;
            this.tabTimetableLabourer.Text = "Timetable";
            this.tabTimetableLabourer.UseVisualStyleBackColor = true;
            // 
            // btnLogoutLabourer
            // 
            this.btnLogoutLabourer.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnLogoutLabourer.Location = new System.Drawing.Point(782, 16);
            this.btnLogoutLabourer.Name = "btnLogoutLabourer";
            this.btnLogoutLabourer.Size = new System.Drawing.Size(89, 29);
            this.btnLogoutLabourer.TabIndex = 7;
            this.btnLogoutLabourer.TabStop = false;
            this.btnLogoutLabourer.Text = "LOGOUT";
            this.btnLogoutLabourer.UseVisualStyleBackColor = false;
            this.btnLogoutLabourer.Click += new System.EventHandler(this.btnLogoutLabourer_Click);
            // 
            // btnMFriday
            // 
            this.btnMFriday.Location = new System.Drawing.Point(31, 224);
            this.btnMFriday.Margin = new System.Windows.Forms.Padding(2);
            this.btnMFriday.Name = "btnMFriday";
            this.btnMFriday.Size = new System.Drawing.Size(102, 37);
            this.btnMFriday.TabIndex = 74;
            this.btnMFriday.Text = "Friday";
            this.btnMFriday.UseVisualStyleBackColor = true;
            this.btnMFriday.Click += new System.EventHandler(this.btnMFriday_Click);
            // 
            // btnMThursday
            // 
            this.btnMThursday.Location = new System.Drawing.Point(31, 182);
            this.btnMThursday.Margin = new System.Windows.Forms.Padding(2);
            this.btnMThursday.Name = "btnMThursday";
            this.btnMThursday.Size = new System.Drawing.Size(102, 37);
            this.btnMThursday.TabIndex = 73;
            this.btnMThursday.Text = "Thursday";
            this.btnMThursday.UseVisualStyleBackColor = true;
            this.btnMThursday.Click += new System.EventHandler(this.btnMThursday_Click);
            // 
            // btnMWednesday
            // 
            this.btnMWednesday.Location = new System.Drawing.Point(31, 140);
            this.btnMWednesday.Margin = new System.Windows.Forms.Padding(2);
            this.btnMWednesday.Name = "btnMWednesday";
            this.btnMWednesday.Size = new System.Drawing.Size(102, 37);
            this.btnMWednesday.TabIndex = 72;
            this.btnMWednesday.Text = "Wednesday";
            this.btnMWednesday.UseVisualStyleBackColor = true;
            this.btnMWednesday.Click += new System.EventHandler(this.btnMWednesday_Click);
            // 
            // btnMTuesday
            // 
            this.btnMTuesday.Location = new System.Drawing.Point(31, 97);
            this.btnMTuesday.Margin = new System.Windows.Forms.Padding(2);
            this.btnMTuesday.Name = "btnMTuesday";
            this.btnMTuesday.Size = new System.Drawing.Size(102, 37);
            this.btnMTuesday.TabIndex = 71;
            this.btnMTuesday.Text = "Tuesday";
            this.btnMTuesday.UseVisualStyleBackColor = true;
            this.btnMTuesday.Click += new System.EventHandler(this.btnMTuesday_Click);
            // 
            // btnMMonday
            // 
            this.btnMMonday.Location = new System.Drawing.Point(31, 55);
            this.btnMMonday.Margin = new System.Windows.Forms.Padding(2);
            this.btnMMonday.Name = "btnMMonday";
            this.btnMMonday.Size = new System.Drawing.Size(102, 37);
            this.btnMMonday.TabIndex = 70;
            this.btnMMonday.Text = "Monday";
            this.btnMMonday.UseVisualStyleBackColor = true;
            this.btnMMonday.Click += new System.EventHandler(this.btnMMonday_Click);
            // 
            // DataViewDailyL
            // 
            this.DataViewDailyL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataViewDailyL.Location = new System.Drawing.Point(137, 54);
            this.DataViewDailyL.Margin = new System.Windows.Forms.Padding(2);
            this.DataViewDailyL.Name = "DataViewDailyL";
            this.DataViewDailyL.RowTemplate.Height = 24;
            this.DataViewDailyL.Size = new System.Drawing.Size(578, 445);
            this.DataViewDailyL.TabIndex = 69;
            this.DataViewDailyL.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataViewDailyL_CellContentClick);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(132, 23);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(204, 26);
            this.dateTimePicker2.TabIndex = 68;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // Labourer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tan;
            this.ClientSize = new System.Drawing.Size(900, 552);
            this.Controls.Add(this.tabLabourer);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Labourer";
            this.Text = "JustRipe2018 - Labourer";
            this.Load += new System.EventHandler(this.Labourer_Load);
            this.tabLabourer.ResumeLayout(false);
            this.tabTimetableLabourer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataViewDailyL)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabLabourer;
        private System.Windows.Forms.TabPage tabTimetableLabourer;
        private System.Windows.Forms.Button btnLogoutLabourer;
        private System.Windows.Forms.Button btnMFriday;
        private System.Windows.Forms.Button btnMThursday;
        private System.Windows.Forms.Button btnMWednesday;
        private System.Windows.Forms.Button btnMTuesday;
        private System.Windows.Forms.Button btnMMonday;
        private System.Windows.Forms.DataGridView DataViewDailyL;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
    }
}