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
            this.tabLabourer.SuspendLayout();
            this.tabTimetableLabourer.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabLabourer
            // 
            this.tabLabourer.Controls.Add(this.tabTimetableLabourer);
            this.tabLabourer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabLabourer.Location = new System.Drawing.Point(0, 0);
            this.tabLabourer.Margin = new System.Windows.Forms.Padding(6);
            this.tabLabourer.Name = "tabLabourer";
            this.tabLabourer.SelectedIndex = 0;
            this.tabLabourer.Size = new System.Drawing.Size(1820, 1385);
            this.tabLabourer.TabIndex = 0;
            // 
            // tabTimetableLabourer
            // 
            this.tabTimetableLabourer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabTimetableLabourer.BackgroundImage")));
            this.tabTimetableLabourer.Controls.Add(this.btnLogoutLabourer);
            this.tabTimetableLabourer.Location = new System.Drawing.Point(8, 51);
            this.tabTimetableLabourer.Margin = new System.Windows.Forms.Padding(6);
            this.tabTimetableLabourer.Name = "tabTimetableLabourer";
            this.tabTimetableLabourer.Padding = new System.Windows.Forms.Padding(6);
            this.tabTimetableLabourer.Size = new System.Drawing.Size(1804, 1326);
            this.tabTimetableLabourer.TabIndex = 0;
            this.tabTimetableLabourer.Text = "Timetable";
            this.tabTimetableLabourer.UseVisualStyleBackColor = true;
            // 
            // btnLogoutLabourer
            // 
            this.btnLogoutLabourer.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnLogoutLabourer.Location = new System.Drawing.Point(1565, 31);
            this.btnLogoutLabourer.Margin = new System.Windows.Forms.Padding(6);
            this.btnLogoutLabourer.Name = "btnLogoutLabourer";
            this.btnLogoutLabourer.Size = new System.Drawing.Size(178, 56);
            this.btnLogoutLabourer.TabIndex = 7;
            this.btnLogoutLabourer.TabStop = false;
            this.btnLogoutLabourer.Text = "LOGOUT";
            this.btnLogoutLabourer.UseVisualStyleBackColor = false;
            this.btnLogoutLabourer.Click += new System.EventHandler(this.btnLogoutLabourer_Click);
            // 
            // Labourer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tan;
            this.ClientSize = new System.Drawing.Size(1800, 1310);
            this.Controls.Add(this.tabLabourer);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "Labourer";
            this.Text = "JustRipe2018 - Labourer";
            this.Load += new System.EventHandler(this.Labourer_Load);
            this.tabLabourer.ResumeLayout(false);
            this.tabTimetableLabourer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabLabourer;
        private System.Windows.Forms.TabPage tabTimetableLabourer;
        private System.Windows.Forms.Button btnLogoutLabourer;
    }
}