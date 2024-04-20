/*
 * Created by SharpDevelop.
 * User: work
 * Date: 06.07.2016
 * Time: 22:04
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace CSVSplitter
{
	/// <summary>
	/// Description of AboutForm.
	/// </summary>
	public partial class AboutForm : Form{
		
		public AboutForm(){
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			fillGUI();
			
		}
		
		void Button1Click(object sender, EventArgs e){
			this.Close();
		}
		
		void LblLinkClick(object sender, EventArgs e){
			System.Diagnostics.Process.Start("https://github.com/mlueft/CSVSplitter");
		}
		
		private void fillGUI(){
			
			ResourceManager rm = new ResourceManager("CSVSplitter.i18n", Assembly.GetExecutingAssembly());
			ResourceSet res = rm.GetResourceSet(CultureInfo.CreateSpecificCulture("de-DE"),true, true);
			    
			lblVersion.Text = "v "+ Data.version +" ("+ Data.releaseDate +")";
			
			button_close.Text = i18n.button_close;
			lable_info.Text = i18n.label_info;
			this.Text = i18n.window_title_about;
			
			Icon = (Icon)i18n.titlebar_icon;
		}


	}
}
