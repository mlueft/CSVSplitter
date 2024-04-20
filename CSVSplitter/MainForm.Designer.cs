
namespace CSVSplitter
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label_inputfile;
		private System.Windows.Forms.TextBox txtInputFile;
		private System.Windows.Forms.Button btnSelectFile;
		private System.Windows.Forms.TextBox txtSplitAfter;
		private System.Windows.Forms.Label label_split_after;
		private System.Windows.Forms.CheckBox checkbox_source_has_header;
		private System.Windows.Forms.CheckBox checkbox_add_header_to_split_files;
		private System.Windows.Forms.Button button_do_split;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.GroupBox label_split_options;
		private System.Windows.Forms.TextBox txtRegex;
		private System.Windows.Forms.RadioButton radio_split_after;
		private System.Windows.Forms.RadioButton radio_split_before;
		private System.Windows.Forms.CheckBox checkbox_use_advanced_options;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem menu_file;
		private System.Windows.Forms.ToolStripMenuItem menu_quit;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem menu_help;
		private System.Windows.Forms.ToolStripMenuItem menu_about;
		private System.Windows.Forms.Label label_copyright;
		
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label_inputfile = new System.Windows.Forms.Label();
            this.txtInputFile = new System.Windows.Forms.TextBox();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.txtSplitAfter = new System.Windows.Forms.TextBox();
            this.label_split_after = new System.Windows.Forms.Label();
            this.checkbox_source_has_header = new System.Windows.Forms.CheckBox();
            this.checkbox_add_header_to_split_files = new System.Windows.Forms.CheckBox();
            this.button_do_split = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label_split_options = new System.Windows.Forms.GroupBox();
            this.txtRegex = new System.Windows.Forms.TextBox();
            this.radio_split_after = new System.Windows.Forms.RadioButton();
            this.radio_split_before = new System.Windows.Forms.RadioButton();
            this.checkbox_use_advanced_options = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menu_file = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_quit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_help = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_about = new System.Windows.Forms.ToolStripMenuItem();
            this.label_copyright = new System.Windows.Forms.Label();
            this.label_input_options = new System.Windows.Forms.GroupBox();
            this.txtSourceLineDelimiter = new System.Windows.Forms.TextBox();
            this.label_input_line_delimiter = new System.Windows.Forms.Label();
            this.txtSourceFieldDelimiter = new System.Windows.Forms.TextBox();
            this.label_input_field_delimiter = new System.Windows.Forms.Label();
            this.txtSourceTextDelimiter = new System.Windows.Forms.TextBox();
            this.label_input_text_delimiter = new System.Windows.Forms.Label();
            this.label_output_options = new System.Windows.Forms.GroupBox();
            this.txtTargetLineDelimiter = new System.Windows.Forms.TextBox();
            this.label_output_line_delimiter = new System.Windows.Forms.Label();
            this.txtTargetFieldDelimiter = new System.Windows.Forms.TextBox();
            this.label_output_field_delimiter = new System.Windows.Forms.Label();
            this.txtTargetTextDelimiter = new System.Windows.Forms.TextBox();
            this.label_output_text_delimiter = new System.Windows.Forms.Label();
            this.label_column_options = new System.Windows.Forms.GroupBox();
            this.label_export_header = new System.Windows.Forms.Label();
            this.txtHeader = new System.Windows.Forms.TextBox();
            this.radio_header_names = new System.Windows.Forms.RadioButton();
            this.radio_header_indices = new System.Windows.Forms.RadioButton();
            this.label_source_prefix = new System.Windows.Forms.Label();
            this.checkbox_target_prefix = new System.Windows.Forms.CheckBox();
            this.txtSourcePrefix = new System.Windows.Forms.TextBox();
            this.label_prefix = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label_split_options.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.label_input_options.SuspendLayout();
            this.label_output_options.SuspendLayout();
            this.label_column_options.SuspendLayout();
            this.label_prefix.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_inputfile
            // 
            resources.ApplyResources(this.label_inputfile, "label_inputfile");
            this.label_inputfile.Name = "label_inputfile";
            // 
            // txtInputFile
            // 
            this.txtInputFile.AllowDrop = true;
            resources.ApplyResources(this.txtInputFile, "txtInputFile");
            this.txtInputFile.Name = "txtInputFile";
            this.txtInputFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.TxtInputFileDragDrop);
            this.txtInputFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.TxtInputFileDragEnter);
            // 
            // btnSelectFile
            // 
            resources.ApplyResources(this.btnSelectFile, "btnSelectFile");
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.BtnSelectFileClick);
            // 
            // txtSplitAfter
            // 
            resources.ApplyResources(this.txtSplitAfter, "txtSplitAfter");
            this.txtSplitAfter.Name = "txtSplitAfter";
            // 
            // label_split_after
            // 
            resources.ApplyResources(this.label_split_after, "label_split_after");
            this.label_split_after.Name = "label_split_after";
            // 
            // checkbox_source_has_header
            // 
            this.checkbox_source_has_header.Checked = true;
            this.checkbox_source_has_header.CheckState = System.Windows.Forms.CheckState.Checked;
            resources.ApplyResources(this.checkbox_source_has_header, "checkbox_source_has_header");
            this.checkbox_source_has_header.Name = "checkbox_source_has_header";
            this.checkbox_source_has_header.UseVisualStyleBackColor = true;
            this.checkbox_source_has_header.CheckedChanged += new System.EventHandler(this.CheckSourceContainsHeaderCheckedChanged);
            // 
            // checkbox_add_header_to_split_files
            // 
            this.checkbox_add_header_to_split_files.Checked = true;
            this.checkbox_add_header_to_split_files.CheckState = System.Windows.Forms.CheckState.Checked;
            resources.ApplyResources(this.checkbox_add_header_to_split_files, "checkbox_add_header_to_split_files");
            this.checkbox_add_header_to_split_files.Name = "checkbox_add_header_to_split_files";
            this.checkbox_add_header_to_split_files.UseVisualStyleBackColor = true;
            this.checkbox_add_header_to_split_files.CheckedChanged += new System.EventHandler(this.CheckAddHeaderToSplitFilesCheckedChanged);
            // 
            // button_do_split
            // 
            this.button_do_split.BackColor = System.Drawing.Color.LightGreen;
            resources.ApplyResources(this.button_do_split, "button_do_split");
            this.button_do_split.Name = "button_do_split";
            this.button_do_split.UseVisualStyleBackColor = false;
            this.button_do_split.Click += new System.EventHandler(this.BtnGoClick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label_split_options
            // 
            this.label_split_options.BackColor = System.Drawing.SystemColors.Control;
            this.label_split_options.Controls.Add(this.txtRegex);
            this.label_split_options.Controls.Add(this.radio_split_after);
            this.label_split_options.Controls.Add(this.radio_split_before);
            this.label_split_options.Controls.Add(this.checkbox_use_advanced_options);
            this.label_split_options.Controls.Add(this.label_split_after);
            this.label_split_options.Controls.Add(this.txtSplitAfter);
            resources.ApplyResources(this.label_split_options, "label_split_options");
            this.label_split_options.Name = "label_split_options";
            this.label_split_options.TabStop = false;
            // 
            // txtRegex
            // 
            resources.ApplyResources(this.txtRegex, "txtRegex");
            this.txtRegex.Name = "txtRegex";
            this.txtRegex.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtRegexKeyUp);
            // 
            // radio_split_after
            // 
            this.radio_split_after.Checked = true;
            resources.ApplyResources(this.radio_split_after, "radio_split_after");
            this.radio_split_after.Name = "radio_split_after";
            this.radio_split_after.TabStop = true;
            this.radio_split_after.UseVisualStyleBackColor = true;
            this.radio_split_after.CheckedChanged += new System.EventHandler(this.RdoBeforeCheckedChanged);
            // 
            // radio_split_before
            // 
            resources.ApplyResources(this.radio_split_before, "radio_split_before");
            this.radio_split_before.Name = "radio_split_before";
            this.radio_split_before.UseVisualStyleBackColor = true;
            this.radio_split_before.CheckedChanged += new System.EventHandler(this.RdoBeforeCheckedChanged);
            // 
            // checkbox_use_advanced_options
            // 
            resources.ApplyResources(this.checkbox_use_advanced_options, "checkbox_use_advanced_options");
            this.checkbox_use_advanced_options.Name = "checkbox_use_advanced_options";
            this.checkbox_use_advanced_options.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_file,
            this.toolStripMenuItem1});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // menu_file
            // 
            this.menu_file.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_quit});
            this.menu_file.Name = "menu_file";
            resources.ApplyResources(this.menu_file, "menu_file");
            // 
            // menu_quit
            // 
            this.menu_quit.Name = "menu_quit";
            resources.ApplyResources(this.menu_quit, "menu_quit");
            this.menu_quit.Click += new System.EventHandler(this.BeendenToolStripMenuItemClick);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_help,
            this.menu_about});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // menu_help
            // 
            this.menu_help.Name = "menu_help";
            resources.ApplyResources(this.menu_help, "menu_help");
            this.menu_help.Click += new System.EventHandler(this.Menu_helpClick);
            // 
            // menu_about
            // 
            this.menu_about.Name = "menu_about";
            resources.ApplyResources(this.menu_about, "menu_about");
            this.menu_about.Click += new System.EventHandler(this.BtnHelpClick);
            // 
            // label_copyright
            // 
            resources.ApplyResources(this.label_copyright, "label_copyright");
            this.label_copyright.Name = "label_copyright";
            // 
            // label_input_options
            // 
            this.label_input_options.BackColor = System.Drawing.SystemColors.Control;
            this.label_input_options.Controls.Add(this.txtSourceLineDelimiter);
            this.label_input_options.Controls.Add(this.label_input_line_delimiter);
            this.label_input_options.Controls.Add(this.txtSourceFieldDelimiter);
            this.label_input_options.Controls.Add(this.label_input_field_delimiter);
            this.label_input_options.Controls.Add(this.txtSourceTextDelimiter);
            this.label_input_options.Controls.Add(this.checkbox_source_has_header);
            this.label_input_options.Controls.Add(this.label_input_text_delimiter);
            resources.ApplyResources(this.label_input_options, "label_input_options");
            this.label_input_options.Name = "label_input_options";
            this.label_input_options.TabStop = false;
            // 
            // txtSourceLineDelimiter
            // 
            this.txtSourceLineDelimiter.AllowDrop = true;
            resources.ApplyResources(this.txtSourceLineDelimiter, "txtSourceLineDelimiter");
            this.txtSourceLineDelimiter.Name = "txtSourceLineDelimiter";
            // 
            // label_input_line_delimiter
            // 
            resources.ApplyResources(this.label_input_line_delimiter, "label_input_line_delimiter");
            this.label_input_line_delimiter.Name = "label_input_line_delimiter";
            // 
            // txtSourceFieldDelimiter
            // 
            this.txtSourceFieldDelimiter.AllowDrop = true;
            resources.ApplyResources(this.txtSourceFieldDelimiter, "txtSourceFieldDelimiter");
            this.txtSourceFieldDelimiter.Name = "txtSourceFieldDelimiter";
            // 
            // label_input_field_delimiter
            // 
            resources.ApplyResources(this.label_input_field_delimiter, "label_input_field_delimiter");
            this.label_input_field_delimiter.Name = "label_input_field_delimiter";
            // 
            // txtSourceTextDelimiter
            // 
            this.txtSourceTextDelimiter.AllowDrop = true;
            resources.ApplyResources(this.txtSourceTextDelimiter, "txtSourceTextDelimiter");
            this.txtSourceTextDelimiter.Name = "txtSourceTextDelimiter";
            // 
            // label_input_text_delimiter
            // 
            resources.ApplyResources(this.label_input_text_delimiter, "label_input_text_delimiter");
            this.label_input_text_delimiter.Name = "label_input_text_delimiter";
            // 
            // label_output_options
            // 
            this.label_output_options.BackColor = System.Drawing.SystemColors.Control;
            this.label_output_options.Controls.Add(this.txtTargetLineDelimiter);
            this.label_output_options.Controls.Add(this.label_output_line_delimiter);
            this.label_output_options.Controls.Add(this.txtTargetFieldDelimiter);
            this.label_output_options.Controls.Add(this.label_output_field_delimiter);
            this.label_output_options.Controls.Add(this.txtTargetTextDelimiter);
            this.label_output_options.Controls.Add(this.checkbox_add_header_to_split_files);
            this.label_output_options.Controls.Add(this.label_output_text_delimiter);
            resources.ApplyResources(this.label_output_options, "label_output_options");
            this.label_output_options.Name = "label_output_options";
            this.label_output_options.TabStop = false;
            // 
            // txtTargetLineDelimiter
            // 
            this.txtTargetLineDelimiter.AllowDrop = true;
            resources.ApplyResources(this.txtTargetLineDelimiter, "txtTargetLineDelimiter");
            this.txtTargetLineDelimiter.Name = "txtTargetLineDelimiter";
            // 
            // label_output_line_delimiter
            // 
            resources.ApplyResources(this.label_output_line_delimiter, "label_output_line_delimiter");
            this.label_output_line_delimiter.Name = "label_output_line_delimiter";
            // 
            // txtTargetFieldDelimiter
            // 
            this.txtTargetFieldDelimiter.AllowDrop = true;
            resources.ApplyResources(this.txtTargetFieldDelimiter, "txtTargetFieldDelimiter");
            this.txtTargetFieldDelimiter.Name = "txtTargetFieldDelimiter";
            // 
            // label_output_field_delimiter
            // 
            resources.ApplyResources(this.label_output_field_delimiter, "label_output_field_delimiter");
            this.label_output_field_delimiter.Name = "label_output_field_delimiter";
            // 
            // txtTargetTextDelimiter
            // 
            this.txtTargetTextDelimiter.AllowDrop = true;
            resources.ApplyResources(this.txtTargetTextDelimiter, "txtTargetTextDelimiter");
            this.txtTargetTextDelimiter.Name = "txtTargetTextDelimiter";
            // 
            // label_output_text_delimiter
            // 
            resources.ApplyResources(this.label_output_text_delimiter, "label_output_text_delimiter");
            this.label_output_text_delimiter.Name = "label_output_text_delimiter";
            // 
            // label_column_options
            // 
            this.label_column_options.BackColor = System.Drawing.SystemColors.Control;
            this.label_column_options.Controls.Add(this.label_export_header);
            this.label_column_options.Controls.Add(this.txtHeader);
            this.label_column_options.Controls.Add(this.radio_header_names);
            this.label_column_options.Controls.Add(this.radio_header_indices);
            resources.ApplyResources(this.label_column_options, "label_column_options");
            this.label_column_options.Name = "label_column_options";
            this.label_column_options.TabStop = false;
            // 
            // label_export_header
            // 
            resources.ApplyResources(this.label_export_header, "label_export_header");
            this.label_export_header.Name = "label_export_header";
            // 
            // txtHeader
            // 
            resources.ApplyResources(this.txtHeader, "txtHeader");
            this.txtHeader.Name = "txtHeader";
            // 
            // radio_header_names
            // 
            this.radio_header_names.Checked = true;
            resources.ApplyResources(this.radio_header_names, "radio_header_names");
            this.radio_header_names.Name = "radio_header_names";
            this.radio_header_names.TabStop = true;
            this.radio_header_names.UseVisualStyleBackColor = true;
            // 
            // radio_header_indices
            // 
            resources.ApplyResources(this.radio_header_indices, "radio_header_indices");
            this.radio_header_indices.Name = "radio_header_indices";
            this.radio_header_indices.UseVisualStyleBackColor = true;
            // 
            // label_source_prefix
            // 
            resources.ApplyResources(this.label_source_prefix, "label_source_prefix");
            this.label_source_prefix.Name = "label_source_prefix";
            // 
            // checkbox_target_prefix
            // 
            resources.ApplyResources(this.checkbox_target_prefix, "checkbox_target_prefix");
            this.checkbox_target_prefix.Name = "checkbox_target_prefix";
            this.checkbox_target_prefix.UseVisualStyleBackColor = true;
            // 
            // txtSourcePrefix
            // 
            this.txtSourcePrefix.AllowDrop = true;
            resources.ApplyResources(this.txtSourcePrefix, "txtSourcePrefix");
            this.txtSourcePrefix.Name = "txtSourcePrefix";
            // 
            // label_prefix
            // 
            this.label_prefix.BackColor = System.Drawing.SystemColors.Control;
            this.label_prefix.Controls.Add(this.txtSourcePrefix);
            this.label_prefix.Controls.Add(this.checkbox_target_prefix);
            this.label_prefix.Controls.Add(this.label_source_prefix);
            resources.ApplyResources(this.label_prefix, "label_prefix");
            this.label_prefix.Name = "label_prefix";
            this.label_prefix.TabStop = false;
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label_input_options);
            this.panel1.Controls.Add(this.label_prefix);
            this.panel1.Controls.Add(this.label_split_options);
            this.panel1.Controls.Add(this.label_column_options);
            this.panel1.Controls.Add(this.label_output_options);
            this.panel1.Name = "panel1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtOutput);
            this.panel2.Controls.Add(this.button_do_split);
            this.panel2.Controls.Add(this.label_copyright);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // txtOutput
            // 
            this.txtOutput.BackColor = System.Drawing.Color.Black;
            this.txtOutput.ForeColor = System.Drawing.Color.WhiteSmoke;
            resources.ApplyResources(this.txtOutput, "txtOutput");
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label_inputfile);
            this.panel3.Controls.Add(this.btnSelectFile);
            this.panel3.Controls.Add(this.txtInputFile);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.label_split_options.ResumeLayout(false);
            this.label_split_options.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.label_input_options.ResumeLayout(false);
            this.label_input_options.PerformLayout();
            this.label_output_options.ResumeLayout(false);
            this.label_output_options.PerformLayout();
            this.label_column_options.ResumeLayout(false);
            this.label_column_options.PerformLayout();
            this.label_prefix.ResumeLayout(false);
            this.label_prefix.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private System.Windows.Forms.GroupBox label_input_options;
        private System.Windows.Forms.TextBox txtSourceLineDelimiter;
        private System.Windows.Forms.Label label_input_line_delimiter;
        private System.Windows.Forms.TextBox txtSourceFieldDelimiter;
        private System.Windows.Forms.Label label_input_field_delimiter;
        private System.Windows.Forms.TextBox txtSourceTextDelimiter;
        private System.Windows.Forms.Label label_input_text_delimiter;
        private System.Windows.Forms.GroupBox label_output_options;
        private System.Windows.Forms.TextBox txtTargetLineDelimiter;
        private System.Windows.Forms.Label label_output_line_delimiter;
        private System.Windows.Forms.TextBox txtTargetFieldDelimiter;
        private System.Windows.Forms.Label label_output_field_delimiter;
        private System.Windows.Forms.TextBox txtTargetTextDelimiter;
        private System.Windows.Forms.Label label_output_text_delimiter;
        private System.Windows.Forms.GroupBox label_column_options;
        private System.Windows.Forms.TextBox txtHeader;
        private System.Windows.Forms.RadioButton radio_header_names;
        private System.Windows.Forms.RadioButton radio_header_indices;
        private System.Windows.Forms.Label label_export_header;
        private System.Windows.Forms.Label label_source_prefix;
        private System.Windows.Forms.CheckBox checkbox_target_prefix;
        private System.Windows.Forms.TextBox txtSourcePrefix;
        private System.Windows.Forms.GroupBox label_prefix;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtOutput;
    }
}
