using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Diagnostics;

namespace CSVSplitter{
	
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form{
		
		public MainForm(){
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
            
			fillGUI();
			
		}
		
		void BtnSelectFileClick(object sender, EventArgs e){
			openFileDialog1.ShowDialog();
			txtInputFile.Text = openFileDialog1.FileName;
		}

		void BtnGoClick(object sender, EventArgs e){
	
			disabkeGUI();

			try
			{

				if (!Splitter.checkInputfile(txtInputFile.Text))
					MessageBox.Show("Please choose a valid input file.");


				string p = "";

				p += " --inputFile \"" + txtInputFile.Text + "\"";

				try
				{
					p += " --lineNumber " + Convert.ToUInt64(txtSplitAfter.Text).ToString();
				}
				catch (Exception)
				{
					p += " --lineNumber 100000";
				}

				p += " --sourceHeader "+ checkbox_source_has_header.Checked.ToString();

				p += " --targetHeader "+ checkbox_add_header_to_split_files.Checked.ToString();

				if (checkbox_use_advanced_options.Checked && txtRegex.Text.Trim().Length > 0)
				{
					if (radio_split_before.Checked)
					{
						p += " --splitBefore " + txtRegex.Text;
					}
					else if (radio_split_after.Checked)
					{
						p += " --splitAfter " + txtRegex.Text;
					}
				}


				p += " --sourceTextDelimiter \"" + txtSourceTextDelimiter.Text + "\"";
				p += " --sourceLineDelimiter \"" + txtSourceLineDelimiter.Text + "\"";
				p += " --sourceFieldDelimiter \"" + txtSourceFieldDelimiter.Text + "\"";
				try
                {
					p += " --sourcePrefix " + Convert.ToUInt64(txtSourcePrefix.Text).ToString();
				}
                catch( Exception)
                {
					p += " --sourcePrefix 0";
				}


				p += " --targetTextDelimiter \"" + txtTargetTextDelimiter.Text + "\"";
				p += " --targetLineDelimiter \"" + txtTargetLineDelimiter.Text + "\"";
				p += " --targetFieldDelimiter \"" + txtTargetFieldDelimiter.Text + "\"";
				p += " --targetPrefix " + checkbox_target_prefix.Checked.ToString();

				if (radio_header_indices.Checked)
                {
                    p += " --indices i";
				}
                else if (radio_header_names.Checked)
                {
                    p += " --indices h";
				}

                if (txtHeader.Text.Trim().Length > 0)
					p += " --exportHeader \"" + txtHeader.Text + "\"";

				txtOutput.Text = "CSVSplitter_cli.exe " + p + "\r\n";

				Process proc = new Process();
				proc.StartInfo.FileName = "CSVSplitter_cli.exe";
				proc.StartInfo.UseShellExecute = false;
				proc.StartInfo.RedirectStandardOutput = true;
				proc.StartInfo.CreateNoWindow = true;
				proc.StartInfo.Arguments = p;
				proc.Start();
				txtOutput.Text += proc.StandardOutput.ReadToEnd();
				proc.WaitForExit();

				if( proc.ExitCode == 0)
				{
					MessageBox.Show( i18n.exit_ok );
				}
				else
				{
					MessageBox.Show( i18n.exit_error );
				}
				

			}
			catch(Exception err ){

                MessageBox.Show( "Something went wrong:" + err.Message );

            }

            enableGUI();
		}

		void TxtInputFileDragDrop(object sender, DragEventArgs e){
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
			if(files != null && files.Length != 0){
			    txtInputFile.Text = files[0];
			}
		}
		
		void TxtInputFileDragEnter(object sender, DragEventArgs e){
			if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true){
		        e.Effect = DragDropEffects.All;
		    } 
		}
		
		void CheckAddHeaderToSplitFilesCheckedChanged(object sender, EventArgs e){
			if(checkbox_add_header_to_split_files.Checked)
				checkbox_source_has_header.Checked = true;
		}
		
		void CheckSourceContainsHeaderCheckedChanged(object sender, EventArgs e){
			if(!checkbox_source_has_header.Checked)
				checkbox_add_header_to_split_files.Checked = false;
		}
		
		void BtnHelpClick(object sender, EventArgs e)
		{
			Form dlg = new AboutForm();
			dlg.ShowDialog();
			
		}
		
		void BeendenToolStripMenuItemClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		void RdoBeforeCheckedChanged(object sender, EventArgs e)
		{
			checkbox_use_advanced_options.Checked = true;
		}
		
		void TxtRegexKeyUp(object sender, KeyEventArgs e)
		{
			checkbox_use_advanced_options.Checked = true;
		}

		void disabkeGUI(){
			menuStrip1.Enabled = false;
			txtInputFile.Enabled = false;
			btnSelectFile.Enabled = false;
			txtSplitAfter.Enabled = false;
			checkbox_source_has_header.Enabled = false;
			checkbox_add_header_to_split_files.Enabled = false;
			checkbox_use_advanced_options.Enabled = false;
			radio_split_before.Enabled = false;
			radio_split_after.Enabled = false;
			txtRegex.Enabled = false;
			button_do_split.Enabled = false;
		}
		
		void enableGUI(){
			menuStrip1.Enabled = true;
			txtInputFile.Enabled = true;
			btnSelectFile.Enabled = true;
			txtSplitAfter.Enabled = true;
			checkbox_source_has_header.Enabled = true;
			checkbox_add_header_to_split_files.Enabled = true;
			checkbox_use_advanced_options.Enabled = true;
			radio_split_before.Enabled = true;
			radio_split_after.Enabled = true;
			txtRegex.Enabled = true;
			button_do_split.Enabled = true;
		}
	
		private void fillGUI(){
			
			//Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
			//Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("de");
			
			

			label_inputfile.Text = i18n.label_inputfile;
			label_split_after.Text = i18n.label_split_after;
			checkbox_source_has_header.Text = i18n.checkbox_source_has_header;
			checkbox_add_header_to_split_files.Text = i18n.checkbox_add_header_to_split_files;
			label_split_options.Text = i18n.label_split_options;
			checkbox_use_advanced_options.Text = i18n.checkbox_use_advanced_options;
			radio_split_before.Text = i18n.radio_split_before;
			radio_split_after.Text = i18n.radio_split_after;
			menu_file.Text = i18n.menu_file;
			menu_quit.Text = i18n.menu_quit;
			menu_help.Text = i18n.menu_help;
			menu_about.Text =i18n.menu_about;
			button_do_split.Text = i18n.button_do_split;

            label_input_options.Text = i18n.label_input_options;
            label_input_text_delimiter.Text = i18n.label_input_text_delimiter;
            label_input_field_delimiter.Text = i18n.label_input_field_delimiter;
            label_input_line_delimiter.Text = i18n.label_input_line_delimiter;
            label_output_options.Text = i18n.label_output_options;
            label_output_text_delimiter.Text = i18n.label_output_text_delimiter;
            label_output_field_delimiter.Text = i18n.label_output_field_delimiter;
            label_output_line_delimiter.Text = i18n.label_output_line_delimiter;
            label_column_options.Text = i18n.label_column_options;
            radio_header_indices.Text = i18n.radio_header_indices;
            radio_header_names.Text = i18n.radio_header_names;
            label_export_header.Text = i18n.label_export_header;

            label_prefix.Text = i18n.label_prefix;
            label_source_prefix.Text = i18n.label_source_prefix;
            checkbox_target_prefix.Text = i18n.checkbox_target_prefix;

            label_copyright.Text = Data.copyright;
			Icon = (Icon)i18n.titlebar_icon;
			/**/
		}

		void Menu_helpClick(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://github.com/mlueft/CSVSplitter");
		}

    }
}
