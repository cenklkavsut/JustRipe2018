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
            this.tabLabourer.SuspendLayout();
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
            this.tabTimetableLabourer.Location = new System.Drawing.Point(4, 29);
            this.tabTimetableLabourer.Name = "tabTimetableLabourer";
            this.tabTimetableLabourer.Padding = new System.Windows.Forms.Padding(3);
            this.tabTimetableLabourer.Size = new System.Drawing.Size(902, 687);
            this.tabTimetableLabourer.TabIndex = 0;
            this.tabTimetableLabourer.Text = "Timetable";
            this.tabTimetableLabourer.UseVisualStyleBackColor = true;
            // 
            // Labourer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tan;
            this.ClientSize = new System.Drawing.Size(900, 681);
            this.Controls.Add(this.tabLabourer);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Labourer";
            this.Text = "JustRipe2018 - Labourer";
            this.tabLabourer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabLabourer;
        private System.Windows.Forms.TabPage tabTimetableLabourer;
    }
}