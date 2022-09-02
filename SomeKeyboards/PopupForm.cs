/*
 * Created by SharpDevelop.
 * User: operator
 * Date: 31/08/2022
 * Time: 13:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;
using System.Text.RegularExpressions; 

namespace SomeKeyboards
{
	/// <summary>
	/// Description of Form1.
	/// </summary>
	public partial class PopupForm : Form
	{
		public PopupForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Button1Click(object sender, EventArgs e)
		{	
			
			string [] personalStrArrayStr = textBox2.Text.Split(',');
			Boolean isOk = true;
			int numeroElement=-1;
			string ongoingStr="";
			foreach (string element in personalStrArrayStr) {
				numeroElement++;
				ongoingStr=element;
				if(element.Length>1) {
					//string c0 = Convert.ToInt32(element[0]).ToString("X");
					//string c1 = Convert.ToInt32(element[1]).ToString("X");
					//MessageBox.Show("Element [0]: " + c0 + " et [0]: "+ c1 +" length : " + element.Length);
					if (Convert.ToInt32(element[0])<0x1000 && Convert.ToInt32(element[1])<0x1000){
					  	isOk=false;
						break;  	
					}
				}
				if(element.Length>2 || element.Length<1){
					isOk=false;
					break;
				}
			}

			if(! isOk){
				MessageBox.Show("Characters must be separated by a comma, a single character between 2 commas. \n" + textBox2.Text + "\n Faulty element : \""+ ongoingStr +"\" at index: " + numeroElement , "Error" );
			}else{
				try{
			    	Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
					ConfigurationManager.AppSettings["title"]=textBox1.Text;
				    ConfigurationManager.AppSettings["keys"]=textBox2.Text;
				    config.AppSettings.Settings["title"].Value = textBox1.Text;
				    config.AppSettings.Settings["keys"].Value = textBox2.Text;
				    config.Save(ConfigurationSaveMode.Modified);
				}catch{}
				this.Close();
			}
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
