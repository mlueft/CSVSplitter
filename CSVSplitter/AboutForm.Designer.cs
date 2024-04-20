namespace CSVSplitter
{
	partial class AboutForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button button_close;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblVersion;
		private System.Windows.Forms.Label lable_info;
		private System.Windows.Forms.LinkLabel lblLink;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.button_close = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lable_info = new System.Windows.Forms.Label();
            this.lblLink = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // button_close
            // 
            this.button_close.Location = new System.Drawing.Point(9, 219);
            this.button_close.Margin = new System.Windows.Forms.Padding(2);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(284, 46);
            this.button_close.TabIndex = 0;
            this.button_close.Text = "close";
            this.button_close.UseVisualStyleBackColor = true;
            this.button_close.Click += new System.EventHandler(this.Button1Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "CSVSplit+";
            // 
            // lblVersion
            // 
            this.lblVersion.Location = new System.Drawing.Point(100, 13);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(194, 19);
            this.lblVersion.TabIndex = 2;
            this.lblVersion.Text = "label2";
            // 
            // lable_info
            // 
            this.lable_info.Location = new System.Drawing.Point(11, 47);
            this.lable_info.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lable_info.Name = "lable_info";
            this.lable_info.Size = new System.Drawing.Size(282, 170);
            this.lable_info.TabIndex = 3;
            this.lable_info.Text = "lable_info";
            // 
            // lblLink
            // 
            this.lblLink.Location = new System.Drawing.Point(169, 198);
            this.lblLink.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLink.Name = "lblLink";
            this.lblLink.Size = new System.Drawing.Size(122, 19);
            this.lblLink.TabIndex = 5;
            this.lblLink.TabStop = true;
            this.lblLink.Text = "CSVSplitter+ on github";
            this.lblLink.Click += new System.EventHandler(this.LblLinkClick);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 275);
            this.Controls.Add(this.lblLink);
            this.Controls.Add(this.lable_info);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_close);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::CSVSplitter.i18n.titlebar_icon;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "window_title_about";
            this.ResumeLayout(false);

		}
	}
}
