/*
 * Created by SharpDevelop.
 * User: operator
 * Date: 22/04/2022
 * Time: 14:44
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Configuration;

namespace SomeKeyboards {
  /// <summary>
  /// Description of MainForm.
  /// </summary>
  public partial class MainForm: Form {
    public MainForm() {
      //
      // The InitializeComponent() call is required for Windows Forms designer support.
      //
      InitializeComponent();
      //
      // TODO: Add constructor code after the InitializeComponent() call.
      //
      this.FormClosing += new FormClosingEventHandler(this.MainForm_FormClosing);
      
      this.Size = new Size(this.MaximumSize.Width,this.MinimumSize.Height);
      this.TopMost = true;
      
      
      tabPage1.Text="Ascii";
      tabPage2.Text="Occidental";
      tabPage3.Text="Greek";
      tabPage4.Text="Cyrillic";
      tabPage5.Text="Arabic";
      tabPage6.Text="Korean";
      tabPage7.Text="Maths";
      tabPage8.Text="Emoji";
      
      AddButtons(pnlButtonsSp, cmdsSpStrArray, btnArraySP, 9, 3, new int[] { 0 } );
      AddButtons(pnlNumButtons, numStrArray, btnNumArray, 3, 1, new int[] { 0 } );
      AddButtons(tabPage1, asciiStrArray, btnArrayAscii, 26, 1, new int[] { 62 } );
      AddButtons(tabPage2, occidentalStrArray, btnArrayOccidental, 26, 1, new int[] { 28 } );
      AddButtons(tabPage3, greekStrArray, btnArrayGreek, 26, 1, new int[] { 24 } );
      AddButtons(tabPage4, cyrillicStrArray, btnArrayCyrillic, 26, 1, new int[] { 33 });  
      AddButtons(tabPage5, arabicStrArray, btnArrayArabic, 26, 1, new int[] { 13,29,48,54 } );
      AddButtons(tabPage6, koreanStrArray, btnArrayKorean, 26, 1, new int[] { 19,40,56,72,88,104 });      
      AddButtons(tabPage7, mathsStrArray, btnArrayMaths, 25, 1, new int[] { 0 } );        
      AddButtons(tabPage8, emojiStrArray, btnArrayEmoji, 25, 1, new int[] { 0 } );  
      
      try{
	      string [] personalStrArrayStr = ConfigurationManager.AppSettings["keys"].Split(',');
	      System.Windows.Forms.Button[] btnArrayPersonal = new System.Windows.Forms.Button[personalStrArrayStr.Length];
	      AddButtons(tabPage9, personalStrArrayStr, btnArrayPersonal, 25, 1, new int[] { 0 } );
	      tabPage9.Text = ConfigurationManager.AppSettings["title"];
      }
      catch{
      	//do nothing today
      }
      
      RoundBorder(buttonEnter,5);
      RoundBorder(buttonSpace,5);
      try{
      	tabControl1.SelectedIndex = Convert.ToInt16(ConfigurationManager.AppSettings["tabToSelect"]);
      }catch{}
    }
    static string[] cmdsSpStrArray = {"{F1}","{F2}","{F3}","{F4}","{F5}","{F6}","{F7}","{F8}","{BACKSPACE}","{F9}","{F10}","{F11}","{F12}","{F13}","{F14}","{F15}","{F16}","{DEL}","{BREAK}","{CAPSLOCK}","{INS}","{END}","{ENTER}","{SCROLLLOCK}","{HOME}","{UP}","{ESC}","{NUMLOCK}","{PGDN}","{PGUP}","{PRTSC}","{LEFT}","{RIGHT}","{TAB}","{DOWN}"};
    static string[] numStrArray = {"0","1","2","3","4","5","6","7","8","9","+","-","*","/",".",","};
    static string[] asciiStrArray = {"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z","a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z","0","1","2","3","4","5","6","7","8","9","@",".",",","!","?","\"","'","(",")","#","$","%","&","*","+","-","/",":",";","<","=",">","[","\\","]","^","_","{","|","}","~","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","???","???","???","???","???"};
	static string[] occidentalStrArray = {"??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","???","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??"};
	static string[] greekStrArray = {"??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??"};
	static string[] cyrillicStrArray    = {"??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??"};
	static string[] arabicStrArray = {"\u0634","\u0633","\u0632","\u0631","\u0630","\u062F","\u062E","\u062D","\u062C","\u062B","\u062A","\u0628","\u0627","\u0621","\u064A","\u0648","\u0647","\u0646","\u0645","\u0644","\u0643","\u0642","\u0641","\u063A","\u0639","\u0638","\u0637","\u0636","\u0635","\u0649","\u0626","\u0624","\u0629","\u0625","\u0623","\u0671","\u0622","\u064E","\u064B","\u064F","\u064C","\u0651","\u0652","\u0650","\u064D","\u0670","\u0656","\u0657","\u061F","!","\u061B",".","\u060C","\u0640","\u0660","\u0661","\u0662","\u0663","\u0664","\u0665","\u0666","\u0667","\u0668","\u0669","\u066C","\u066B","\u066A"};
	static string[] mathsStrArray = {"???",".","??","??","<",">","???","???","???","???","???","=","~","???","???","???","???","???","???","??","???","???","+","???","??","???","??","???","???","/","\\","???","%","??","???","???","??","??","??","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","??","??","??","??","??","???","???","???","???","???","???","???","???","???","???","??","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","??","???","???","???","???","???","???","???","??","???","???","??","???","??","???","???","??","???","???","???","???","???","???","???","???","???","???","???","???","???","???","(",")","???","???","???","???","{","}","[","]","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","#","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???"};
	static string[] chiffresStrArray = {"0","1","2","3","4","5","6","7","8","9","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","??","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???"};
	static string[] koreanStrArray = {"???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???"};
	static string[] emojiStrArray = {"????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","???","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","??","??","???","???","#???","8???","9???","7???","0???","6???","5???","4???","3???","2???","1???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","???","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????","????"};

    System.Windows.Forms.Button[] btnArraySP = new System.Windows.Forms.Button[cmdsSpStrArray.Length];
    System.Windows.Forms.Button[] btnNumArray = new System.Windows.Forms.Button[numStrArray.Length];
    System.Windows.Forms.Button[] btnArrayAscii = new System.Windows.Forms.Button[asciiStrArray.Length];
    System.Windows.Forms.Button[] btnArrayOccidental = new System.Windows.Forms.Button[occidentalStrArray.Length];
    System.Windows.Forms.Button[] btnArrayGreek = new System.Windows.Forms.Button[greekStrArray.Length];
    System.Windows.Forms.Button[] btnArrayCyrillic = new System.Windows.Forms.Button[cyrillicStrArray.Length];
    System.Windows.Forms.Button[] btnArrayArabic = new System.Windows.Forms.Button[arabicStrArray.Length];
    System.Windows.Forms.Button[] btnArrayMaths = new System.Windows.Forms.Button[mathsStrArray.Length];
    System.Windows.Forms.Button[] btnArrayKorean = new System.Windows.Forms.Button[koreanStrArray.Length];
    System.Windows.Forms.Button[] btnArrayEmoji = new System.Windows.Forms.Button[emojiStrArray.Length];
    
    public void ClickButton(Object sender, System.EventArgs e) {
      Button button = sender as Button;
      string ch = button.Text;
      if (ch == "+" || ch == "(" || ch == ")" || ch == "{" || ch == "}" || ch == "^" || ch == "~" || ch == "??" || ch == "%") SendKeys.Send("{" + ch + "}");
      else{
      	SendKeys.SendWait(button.Text);
      }
    }

    
    //Inheritance:     Object    MarshalByRefObject    Component    Control    ScrollableControl    Panel    TabPage
    //is why we can use: System.Windows.Forms.Panel pnl for Panel and also for TabPage
    private void AddButtons(System.Windows.Forms.Panel pnl, string[] StrArray, System.Windows.Forms.Button[] btn, int nbCols, int widthMultiple,int[] crlf ) {
      int spacing = 1;
      int xPos = spacing;
      int yPos = 0;
      int shiftCell=0;
      int indexCrlf=0;
      int nbButtons = StrArray.Length;
      for (int i = 0; i < nbButtons; i++) {
        btn[i] = new System.Windows.Forms.Button();
        btn[i].UseMnemonic = false;
        btn[i].Width = 31 * widthMultiple; // Width of button
        btn[i].Height = 31; // Height of button
        if (i > 0 && ((i+shiftCell) % nbCols == 0 || i==crlf[indexCrlf])) {
          xPos = spacing;
          yPos += btn[i].Height + spacing;
          if (i==crlf[indexCrlf]) {
          	shiftCell=nbCols-crlf[indexCrlf];
          	if (indexCrlf<crlf.Length-1) indexCrlf++;
          }
        }
        // Location of button:
        btn[i].Left = xPos;
        btn[i].Top = yPos;
        
        xPos = xPos + btn[i].Width + spacing;
        btn[i].Text =StrArray[i];
		pnl.Controls.Add(btn[i]);
		btn[i].Click += new System.EventHandler(ClickButton);
		RoundBorder(btn[i],8);
      }

    }

    protected override CreateParams CreateParams {
      get {
        CreateParams param = base.CreateParams;
        param.ExStyle |= 0x08000000;
        return param;
      }
    }
    
    void ButtonEnterClick(object sender, EventArgs e) {
      SendKeys.SendWait("{ENTER}");
    }
    
    void ButtonSpaceClick(object sender, EventArgs e) {
      SendKeys.SendWait(" ");
    }

     public static void RoundBorder(Control frm, int CornerRadius)
    {
        Rectangle Bounds = new Rectangle(0, 0, frm.Width, frm.Height);
        System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
        path.AddArc(Bounds.X, Bounds.Y, CornerRadius, CornerRadius, 180, 90);
        path.AddArc(Bounds.X + Bounds.Width - CornerRadius, Bounds.Y, CornerRadius, CornerRadius, 270, 90);
        path.AddArc(Bounds.X + Bounds.Width - CornerRadius, Bounds.Y + Bounds.Height - CornerRadius, CornerRadius-1, CornerRadius-1, 0, 90);
        path.AddArc(Bounds.X, Bounds.Y + Bounds.Height - CornerRadius, CornerRadius, CornerRadius, 90, 90);
        path.CloseAllFigures();
        frm.Region = new Region(path);
        frm.Show();
    }
		void Button1Click(object sender, EventArgs e)
		{
		    PopupForm popup = new PopupForm();
		    DialogResult dialogresult = popup.ShowDialog();
		    if (dialogresult == DialogResult.OK)
		    {
		        //Console.WriteLine("You clicked OK");

		    }
		    else if (dialogresult == DialogResult.Cancel)
		    {
		        //Console.WriteLine("You clicked either Cancel or X button in the top right corner");
		    }
		    popup.Dispose();
		}
		void TabPage9Click(object sender, EventArgs e)
		{
			string personalStr = ConfigurationManager.AppSettings["keys"];
			string titleStr = ConfigurationManager.AppSettings["title"];
			PopupForm popup = new PopupForm();
			popup.textBox1.Text=titleStr;
			popup.textBox2.Text=personalStr;
			DialogResult dialogresult = popup.ShowDialog();
			
			string [] personalStrArrayStr = ConfigurationManager.AppSettings["keys"].Split(',');
			System.Windows.Forms.Button[] btnArrayPersonal = new System.Windows.Forms.Button[personalStrArrayStr.Length];
	      	AddButtons(tabPage9, personalStrArrayStr, btnArrayPersonal, 23, 1, new int[] { 0 } );
	      	tabPage9.Text = ConfigurationManager.AppSettings["title"];
		}

		private void  MainForm_FormClosing(object sender, FormClosingEventArgs e){
		    //if (MessageBox.Show("Close?", "Close main form", MessageBoxButtons.YesNo) == DialogResult.No){
		    //    e.Cancel = true;
		    //}
			try{
      			Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
      			config.AppSettings.Settings["tabToSelect"].Value = tabControl1.SelectedIndex.ToString();
		    	config.Save(ConfigurationSaveMode.Modified);
      		}catch{}

		}
		
  }
}