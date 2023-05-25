/*
 * Created by SharpDevelop.
 * User: ddy
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
			
			//info: personal tab is the last tab
			var mytabs = new[] { tabPage1, tabPage2, tabPage3, tabPage4, tabPage5, tabPage6, tabPage7, tabPage8, tabPage9, tabPage10, tabPage11 };
			tabControl1.Controls.AddRange(mytabs);
			
			for (int i = 0; i < mytabs.Length; ++i) {
				mytabs[i].AutoScroll = true;
				mytabs[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				mytabs[i].Location = new System.Drawing.Point(4, 27);
				mytabs[i].Name = "";
				mytabs[i].Padding = new System.Windows.Forms.Padding(3);
				mytabs[i].Size = new System.Drawing.Size(1119, 366);
				mytabs[i].TabIndex = 10;
				mytabs[i].Text = "";
				mytabs[i].ForeColor = Color.FromArgb(0, 0, 255);
				if (i==mytabs.Length -1) {
					//for personal tab  
					mytabs[i].Click += new System.EventHandler(this.TabPageLastOneClick);
				}
			}
			
			tabPage1.Text="Ascii";
			tabPage2.Text="Occidental";
			tabPage3.Text="Accented letters";
			tabPage4.Text="Greek";
			tabPage5.Text="Cyrillic";
			tabPage6.Text="Arabic";
			tabPage7.Text="Korean";
			tabPage8.Text="Maths";
			tabPage9.Text="Emoji";
			tabPage10.Text="Phonetic";
			
			AddButtons(pnlButtonsSp, cmdsSpStrArray, btnArraySP, 9, 3, new int[] { 0 } );
			AddButtons(pnlNumButtons, numStrArray, btnNumArray, 3, 1, new int[] { 0 } );
			AddButtons(tabPage1, asciiStrArray, btnArrayAscii, 26, 1, new int[] { 62 } );
			AddButtons(tabPage2, occidentalStrArray, btnArrayOccidental, 26, 1, new int[] { 30,60 } );
			AddButtons(tabPage3, accentedStrArray, btnArrayAccented, 26, 1, new int[] { 91} );
			AddButtons(tabPage4, greekStrArray, btnArrayGreek, 26, 1, new int[] { 24 } );
			AddButtons(tabPage5, cyrillicStrArray, btnArrayCyrillic, 26, 1, new int[] { 33 });
			AddButtons(tabPage6, arabicStrArray, btnArrayArabic, 26, 1, new int[] { 13,29,48,54 } );
			AddButtons(tabPage7, koreanStrArray, btnArrayKorean, 26, 1, new int[] { 19,40,56,72,88,104 });
			AddButtons(tabPage8, mathsStrArray, btnArrayMaths, 25, 1, new int[] { 0 } );
			AddButtons(tabPage9, emojiStrArray, btnArrayEmoji, 25, 1, new int[] { 0 } );
			AddButtons(tabPage10, phoneticfrStrArray, btnArrayphoneticfr, 20, 1.2, new int[] { 12,16,19,36,41,43 } );
			
			  
			//add buttons to the last tab (personal tab) from config.app
			try{
				string [] personalStrArrayStr = ConfigurationManager.AppSettings["keys"].Split(',');
				System.Windows.Forms.Button[] btnArrayPersonal = new System.Windows.Forms.Button[personalStrArrayStr.Length];
				AddButtons( mytabs[mytabs.Length-1], personalStrArrayStr, btnArrayPersonal, 12, 2, new int[] { 0 } );
				mytabs[mytabs.Length-1].Text = ConfigurationManager.AppSettings["title"];
			}
			catch{
				//do nothing today
			}
			
			RoundBorder(buttonEnter,5);
			RoundBorder(buttonSpace,5);
			try{
				tabControl1.SelectedIndex = Convert.ToInt16(ConfigurationManager.AppSettings["tabToSelect"]);
			}catch{}

			try{
				string [] hiddenTabsArrayStr =  ConfigurationManager.AppSettings["hiddenTabs"].Split(',');
				int[] myArr = Array.ConvertAll(hiddenTabsArrayStr, n => int.Parse(n.Replace(" ","")));
				foreach(var item in myArr){
					if (item>0 && item<10) tabControl1.TabPages.Remove(mytabs[item]);
				}
				//tabControl1.TabPages.Remove(tabPage6);//por uma pessoa
				//tabControl1.TabPages.Remove(mytabs[6]);//por uma pessoa
			}catch{}			

			
		}
		
		TabPage tabPage1 = new TabPage("tabPage1");
		TabPage tabPage2 = new TabPage("tabPage2");
		TabPage tabPage3 = new TabPage("tabPage3");
		TabPage tabPage4 = new TabPage("tabPage4");
		TabPage tabPage5 = new TabPage("tabPage5");
		TabPage tabPage6 = new TabPage("tabPage6");
		TabPage tabPage7 = new TabPage("tabPage7");
		TabPage tabPage8 = new TabPage("tabPage8");
		TabPage tabPage9 = new TabPage("tabPage9");
		TabPage tabPage10 = new TabPage("tabPage10");
		//personal tab
		TabPage tabPage11 = new TabPage("tabPage11");

		static string[] cmdsSpStrArray = {"{F1}","{F2}","{F3}","{F4}","{F5}","{F6}","{F7}","{F8}","{BACKSPACE}","{F9}","{F10}","{F11}","{F12}","{F13}","{F14}","{F15}","{F16}","{DEL}","{BREAK}","{CAPSLOCK}","{INS}","{END}","{ENTER}","{SCROLLLOCK}","{HOME}","{UP}","{ESC}","{NUMLOCK}","{PGDN}","{PGUP}","{PRTSC}","{LEFT}","{RIGHT}","{TAB}","{DOWN}"};
		static string[] numStrArray = {"0","1","2","3","4","5","6","7","8","9","+","-","*","/",".",","};
		static string[] asciiStrArray = {"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z","a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z","0","1","2","3","4","5","6","7","8","9","@",".",",","!","?","\"","'","(",")","#","$","€","%","&","*","+","-","/",":",";","<","=",">","[","\\","]","^","_","{","|","}","~","¡","¢","£","¤","¥","¦","§","¨","©","ª","«","¬","®","¯","°","±","²","³","´","¶","·","¸","¹","º","»","¼","½","¾","¿","«","»","“","”","—","–","…"};
		static string[] occidentalStrArray = {"À","Á","Â","Ã","Æ","Å","Ä","Ç","È","É","Ê","Ë","Î","Ï","Í","Ñ","Ó","Ô","Õ","Ö","Œ","Ù","Ú","Û","Ü","Ÿ","ẞ","Š","Ž","Ø","à","á","â","ã","æ","å","ä","ç","è","é","ê","ë","î","ï","í","ñ","ó","ô","õ","ö","œ","ù","ú","û","ü","ÿ","ß","š","ž","ø","¿"};
		static string[] accentedStrArray = {"Á","Ă","Â","Æ","À","Ā","Ą","Å","Ã","Ä","Ć","Č","Ç","Ĉ","Ċ","Ď","Đ","É","Ě","Ê","Ė","È","Ē","Ę","Ë","Ŋ","Ð","Ğ","Ģ","Ĝ","Ġ","Ĥ","Ħ","İ","" ,"Î","Ì","Ī","Į","Ĩ","Ï","Ĵ","Ķ","ĸ","Ĺ","Ľ","Ļ","Ŀ","Ł","Ń","Ň","Ņ","Ñ","" ,"Ó","Ô","Ő","Œ","Ò","Ō","Ø","Õ","Ö","Ŕ","Ř","Ŗ","Ś","Š","Ş","Ŝ","Ť","Ţ","þ","Ŧ","Ú","Ŭ","Û","Ű","Ù","Ū","Ų","Ů","Ũ","Ü","Ŵ","Ý","Ŷ","Ÿ","Ź","Ž","Ż","á","ă","â","æ","à","ā","ą","å","ã","ä","ć","č","ç","ĉ","ċ","ď","đ","é","ě","ê","ė","è","ē","ę","ë","ŋ","ð","ğ","" ,"ĝ","ġ","ĥ","ħ","i","í","î","ì","ī","į","ĩ","ï","ĵ","ķ","", "ĺ","ľ","ļ","ŀ","ł","ń","ň","ņ","ñ","ŉ","ó","ô","ő","œ","ò","ō","ø","õ","ö","ŕ","ř","ŗ","ś","š","ş","ŝ","ť","ţ","Þ","ŧ","ú","ŭ","û","ű","ù","ū","ų","ů","ũ","ü","ŵ","ý","ŷ","ÿ","ź","ž","ż","","Ã","ã","Ñ","ñ","Õ","õ","Ỹ","ỹ","Ũ","ũ","Ĩ","ĩ","Ẽ","ẽ","G̃","g̃"};
		static string[] greekStrArray = {"Α","Β","Γ","Δ","Ε","Ζ","Η","Θ","Ι","Κ","Λ","Μ","Ν","Ξ","Ο","Π","Ρ","Σ","Τ","Υ","Φ","Χ","Ψ","Ω","α","β","γ","δ","ε","ζ","η","θ","ι","κ","λ","μ","ν","ξ","ο","π","ρ","σ","τ","υ","φ","χ","ψ","ω"};
		static string[] nocyrillicStrArray = {"Ё","Й","Ц","У","К","Е","Н","Г","Ш","Щ","З","Х","Ъ","Ф","Ы","В","А","П","Р","О","Л","Д","Ж","Э","Я","Ч","С","М","И","Т","Ь","Б","Ю","ё","й","ц","у","к","е","н","г","ш","щ","з","х","ъ","ф","ы","в","а","п","р","о","л","д","ж","э","я","ч","с","м","и","т","ь","б","ю"};
		static string[] cyrillicStrArray = {"А","Б","В","Г","Д","Е","Ё","Ж","З","И","Й","К","Л","М","Н","О","П","Р","С","Т","У","Ф","Х","Ц","Ч","Ш","Щ","","","","Э","Ю","Я","а","б","в","г","д","е","ё","ж","з","и","й","к","л","м","н","о","п","р","с","т","у","ф","х","ц","ч","ш","щ","ъ","ы","ь","э","ю","я"};
		static string[] arabicStrArray = {"\u0634","\u0633","\u0632","\u0631","\u0630","\u062F","\u062E","\u062D","\u062C","\u062B","\u062A","\u0628","\u0627","\u0621","\u064A","\u0648","\u0647","\u0646","\u0645","\u0644","\u0643","\u0642","\u0641","\u063A","\u0639","\u0638","\u0637","\u0636","\u0635","\u0649","\u0626","\u0624","\u0629","\u0625","\u0623","\u0671","\u0622","\u064E","\u064B","\u064F","\u064C","\u0651","\u0652","\u0650","\u064D","\u0670","\u0656","\u0657","\u061F","!","\u061B",".","\u060C","\u0640","\u0660","\u0661","\u0662","\u0663","\u0664","\u0665","\u0666","\u0667","\u0668","\u0669","\u066C","\u066B","\u066A"};
		static string[] mathsStrArray = {"⋅",".","°","µ","<",">","≤","≥","⩽","⩾","⋕","=","~","≈","≃","≍","≅","≠","≡","±","∓","−","+","∗","×","⨯","÷","⁄","∕","/","\\","∖","%","٪","‰","‱","¼","¾","½","↉","⅓","⅔","⅕","⅖","⅗","⅘","⅙","⅚","⅛","⅜","⅝","⅞","⅑","⅒","⅟","¹","²","³","º","ª","′","″","∀","∏","⅀","∑","℄","∁","℃","ℂ","ƒ","℉","ℱ","Ⅎ","ⅎ","ℰ","ℊ","ℋ","ℌ","ℎ","ℏ","ℑ","K","ℒ","ℓ","⅊","∂","ⅇ","ℳ","ℕ","ℴ","℘","ℚ","ℝ","ℛ","ℜ","℥","ℤ","√","∞","¬","∩","∫","∬","∭","∮","∯","∰","Π","ℿ","℔","π","ℼ","ϖ","Ω","℧","ø","∅","⊗","⨂","⊕","⨁","∘","∠","⦜","∝","∪","∼","⊥","∆","∇","(",")","⟩","⟨","⟫","⟪","{","}","[","]","⟦","⟧","⌊","⌋","⌈","⌉","⟬","⟭","⟮","⟯","⦃","⦄","⦅","⦆","⦇","⦈","⦉","⦊","⦋","⦌","⦍","⦎","⦏","⦐","⦑","⦒","⦓","⦔","⦕","⦖","⦗","⦘","∥","∦","∣","⋉","⋊","≀","⋔","#","∃","∄","∴","∵","⋮","⋰","⋱","∎","□","◊","∤","≔","≜","⟀","⟁","⟂","⟃","⟄","⟅","⟆","⟇","⟈","⟉","⟊","⟋","⟌","⟍","⟎","⟏","⟐","⟑","⟒","⟓","⟔","⟕","⟖","⟗","⟘","⟙","⟚","⟛","⟜","⟝","⟞","⟟","⟠","⟡","⟢","⟣","⟤","⟥","⦀","⦁","⦂","⦙","⦚","⦛","⦝","⦞","⦟","⦠","⦡","⦢","⦣","⦤","⦥","⦦","⦧","⦨","⦩","⦪","⦫","⦬","⦭","⦮","⦯","⦰","⦱","⦲","⦳","⦴","⦵","⦶","⦷","⦸","⦹","⦺","⦻","⦼","⦽","⦾","⦿","⧀","⧁","⧂","⧃","⧄","⧅","⧆","⧇","⧈","⧉","⧊","⧋","⧌","⧍","⧎","⧏","⧐","⧑","⧒","⧓","⧔","⧕","⧖","⧗","⧘","⧙","⧚","⧛","⧜","⧝","⧞","⧟","⧠","⧡","⧢","⧣","⧤","⧥","⧦","⧧","⧨","⧩","⧪","⧫","⧬","⧭","⧮","⧯","⧰","⧱","⧲","⧳","⧴","⧵","⧶","⧷","⧸","⧹","⧺","⧻","⧼","⧽","⧾","⧿","⨀","⨃","⨄","⨅","⨆","⨇","⨈","⨉","⨊","⨋","⨌","⨍","⨎","⨏","⨐","⨑","⨒","⨓","⨔","⨕","⨖","⨗","⨘","⨙","⨚","⨛","⨜","⨝","⨞","⨟","⨠","⨡","⨢","⨣","⨤","⨥","⨦","⨧","⨨","⨩","⨪","⨫","⨬","⨭","⨮","⨰","⨱","⨲","⨳","⨴","⨵","⨶","⨷","⨸","⨹","⨺","⨻","⨼","⨽","⨾","⨿"};
		static string[] chiffresStrArray = {"0","1","2","3","4","5","6","7","8","9","۰","۱","۲","۳","۴","۵","۶","۷","۸","۹","٠","١","٢","٣","٤","٥","٦","٧","٨","٩","০","১","২","৩","৪","৫","৬","৭","৮","৯","०","१","२","३","४","५","६","७","८","९"};
		static string[] koreanStrArray = {"ㄱ","ㄲ","ㄴ","ㄷ","ㄸ","ㄹ","ㅁ","ㅂ","ㅃ","ㅅ","ㅆ","ㅇ","ㅈ","ㅉ","ㅊ","ㅋ","ㅌ","ㅍ","ㅎ","ㅏ","ㅐ","ㅑ","ㅒ","ㅓ","ㅔ","ㅕ","ㅖ","ㅗ","ㅘ","ㅙ","ㅚ","ㅛ","ㅜ","ㅝ","ㅞ","ㅟ","ㅠ","ㅡ","ㅢ","ㅣ","아","악","안","알","암","압","앙","앞","애","액","앵","야","얀","약","양","얘","어","억","언","얼","엄","업","엉","에","여","역","연","열","염","엽","영","예","오","옥","온","올","옴","옹","와","완","왈","왕","왜","외","왼","요","욕","용","우","욱","운","울","움","웅","워","원","월","위","유","육","윤","율","융","윷","으","은","을","음","읍","응","의","이","익","인","일","임","입","잉","잎"};
		static string[] emojiStrArray = {"😁","😂","😃","😄","😅","😆","😉","😊","😋","😌","😍","😏","😒","😓","😔","😖","😘","😚","😜","😝","😞","😠","😡","😢","😣","😤","😥","😨","😩","😪","😫","😭","😰","😱","😲","😳","😵","😷","😸","😹","😺","😻","😼","😽","😾","😿","🙀","🙅","🙆","🙇","🙈","🙉","🙊","🙋","🙌","🙍","🙎","🙏","✂","✅","✈","✉","✊","✋","✌","✏","✒","✔","✖","✨","✳","✴","❄","❇","❌","❎","❓","❔","❕","❗","❤","➕","➖","➗","➡","➰","🚀","🚃","🚄","🚅","🚇","🚉","🚌","🚏","🚑","🚒","🚓","🚕","🚗","🚙","🚚","🚢","🚤","🚥","🚧","🚨","🚩","🚪","🚫","🚬","🚭","🚲","🚶","🚹","🚺","🚻","🚼","🚽","🚾","🛀","Ⓜ","🅰","🅱","🅾","🅿","🆎","🆑","🆒","🆓","🆔","🆕","🆖","🆗","🆘","🆙","🆚","🈁","🈂","🈚","🈯","🈲","🈳","🈴","🈵","🈶","🈷","🈸","🈹","🈺","🉐","🉑","©","®","‼","⁉","#⃣","8⃣","9⃣","7⃣","0⃣","6⃣","5⃣","4⃣","3⃣","2⃣","1⃣","™","ℹ","↔","↕","↖","↗","↘","↙","↩","↪","⌚","⌛","⏩","⏪","⏫","⏬","⏰","⏳","▪","▫","▶","◀","◻","◼","◽","◾","☀","☁","☎","☑","☔","☕","☝","☺","♈","♉","♊","♋","♌","♍","♎","♏","♐","♑","♒","♓","♠","♣","♥","♦","♨","♻","♿","⚓","⚠","⚡","⚪","⚫","⚽","⚾","⛄","⛅","⛎","⛔","⛪","⛲","⛳","⛵","⛺","⛽","⤴","⤵","⬅","⬆","⬇","⬛","⬜","⭐","⭕","〰","〽","㊗","㊙","🀄","🃏","🌀","🌁","🌂","🌃","🌄","🌅","🌆","🌇","🌈","🌉","🌊","🌋","🌌","🌏","🌑","🌓","🌔","🌕","🌙","🌛","🌟","🌠","🌰","🌱","🌴","🌵","🌷","🌸","🌹","🌺","🌻","🌼","🌽","🌾","🌿","🍀","🍁","🍂","🍃","🍄","🍅","🍆","🍇","🍈","🍉","🍊","🍌","🍍","🍎","🍏","🍑","🍒","🍓","🍔","🍕","🍖","🍗","🍘","🍙","🍚","🍛","🍜","🍝","🍞","🍟","🍠","🍡","🍢","🍣","🍤","🍥","🍦","🍧","🍨","🍩","🍪","🍫","🍬","🍭","🍮","🍯","🍰","🍱","🍲","🍳","🍴","🍵","🍶","🍷","🍸","🍹","🍺","🍻","🎀","🎁","🎂","🎃","🎄","🎅","🎆","🎇","🎈","🎉","🎊","🎋","🎌","🎍","🎎","🎏","🎐","🎑","🎒","🎓","🎠","🎡","🎢","🎣","🎤","🎥","🎦","🎧","🎨","🎩","🎪","🎫","🎬","🎭","🎮","🎯","🎰","🎱","🎲","🎳","🎴","🎵","🎶","🎷","🎸","🎹","🎺","🎻","🎼","🎽","🎾","🎿","🏀","🏁","🏂","🏃","🏄","🏆","🏈","🏊","🏠","🏡","🏢","🏣","🏥","🏦","🏧","🏨","🏩","🏪","🏫","🏬","🏭","🏮","🏯","🏰","🐌","🐍","🐎","🐑","🐒","🐔","🐗","🐘","🐙","🐚","🐛","🐜","🐝","🐞","🐟","🐠","🐡","🐢","🐣","🐤","🐥","🐦","🐧","🐨","🐩","🐫","🐬","🐭","🐮","🐯","🐰","🐱","🐲","🐳","🐴","🐵","🐶","🐷","🐸","🐹","🐺","🐻","🐼","🐽","🐾","👀","👂","👃","👄","👅","👆","👇","👈","👉","👊","👋","👌","👍","👎","👏","👐","👑","👒","👓","👔","👕","👖","👗","👘","👙","👚","👛","👜","👝","👞","👟","👠","👡","👢","👣","👤","👦","👧","👨","👩","👪","👫","👮","👯","👰","👱","👲","👳","👴","👵","👶","👷","👸","👹","👺","👻","👼","👽","👾","👿","💀","💁","💂","💃","💄","💅","💆","💇","💈","💉","💊","💋","💌","💍","💎","💏","💐","💑","💒","💓","💔","💕","💖","💗","💘","💙","💚","💛","💜","💝","💞","💟","💠","💡","💢","💣","💤","💥","💦","💧","💨","💩","💪","💫","💬","💮","💯","💰","💱","💲","💳","💴","💵","💸","💹","💺","💻","💼","💽","💾","💿","📀","📁","📂","📃","📄","📅","📆","📇","📈","📉","📊","📋","📌","📍","📎","📏","📐","📑","📒","📓","📔","📕","📖","📗","📘","📙","📚","📛","📜","📝","📞","📟","📠","📡","📢","📣","📤","📥","📦","📧","📨","📩","📪","📫","📮","📰","📱","📲","📳","📴","📶","📷","📹","📺","📻","📼","🔃","🔊","🔋","🔌","🔍","🔎","🔏","🔐","🔑","🔒","🔓","🔔","🔖","🔗","🔘","🔙","🔚","🔛","🔜","🔝","🔞","🔟","🔠","🔡","🔢","🔣","🔤","🔥","🔦","🔧","🔨","🔩","🔪","🔫","🔮","🔯","🔰","🔱","🔲","🔳","🔴","🔵","🔶","🔷","🔸","🔹","🔺","🔻","🔼","🔽","🕐","🕑","🕒","🕓","🕔","🕕","🕖","🕗","🕘","🕙","🕚","🕛","🗻","🗼","🗽","🗾","🗿","😀","😇","😈","😎","😐","😑","😕","😗","😙","😛","😟","😦","😧","😬","😮","😯","😴","😶","🚁","🚂","🚆","🚈","🚊","🚍","🚎","🚐","🚔","🚖","🚘","🚛","🚜","🚝","🚞","🚟","🚠","🚡","🚣","🚦","🚮","🚯","🚰","🚱","🚳","🚴","🚵","🚷","🚸","🚿","🛁","🛂","🛃","🛄","🛅","🌍","🌎","🌐","🌒","🌖","🌗","🌘","🌚","🌜","🌝","🌞","🌲","🌳","🍋","🍐","🍼","🏇","🏉","🏤","🐀","🐁","🐂","🐃","🐄","🐅","🐆","🐇","🐈","🐉","🐊","🐋","🐏","🐐","🐓","🐕","🐖","🐪","👥","👬","👭","💭","💶","💷","📬","📭","📯","📵","🔀","🔁","🔂","🔄","🔅","🔆","🔇","🔉","🔕","🔬","🔭","🕜","🕝","🕞","🕟","🕠","🕡","🕢","🕣","🕤","🕥","🕦","🕧"};
		static string[] phoneticfrStrArray = {"a","ɑ","ɔ","e","ə","ɛ","i","o","ø","œ","u","y","ɑ̃","ɔ̃","ɛ̃","œ̃","ɥ","j","w","b","d","f","ɡ","k","l","m","n","ɲ","p","ʁ","s","ʃ","t","v","z","ʒ","ŋ","h","x","tʃ","dʒ","[","]"};

		
		System.Windows.Forms.Button[] btnArraySP = new System.Windows.Forms.Button[cmdsSpStrArray.Length];
		System.Windows.Forms.Button[] btnNumArray = new System.Windows.Forms.Button[numStrArray.Length];
		System.Windows.Forms.Button[] btnArrayAscii = new System.Windows.Forms.Button[asciiStrArray.Length];
		System.Windows.Forms.Button[] btnArrayOccidental = new System.Windows.Forms.Button[occidentalStrArray.Length];
		System.Windows.Forms.Button[] btnArrayAccented = new System.Windows.Forms.Button[accentedStrArray.Length];
		System.Windows.Forms.Button[] btnArrayGreek = new System.Windows.Forms.Button[greekStrArray.Length];
		System.Windows.Forms.Button[] btnArrayCyrillic = new System.Windows.Forms.Button[cyrillicStrArray.Length];
		System.Windows.Forms.Button[] btnArrayArabic = new System.Windows.Forms.Button[arabicStrArray.Length];
		System.Windows.Forms.Button[] btnArrayMaths = new System.Windows.Forms.Button[mathsStrArray.Length];
		System.Windows.Forms.Button[] btnArrayKorean = new System.Windows.Forms.Button[koreanStrArray.Length];
		System.Windows.Forms.Button[] btnArrayEmoji = new System.Windows.Forms.Button[emojiStrArray.Length];
		System.Windows.Forms.Button[] btnArrayphoneticfr = new System.Windows.Forms.Button[phoneticfrStrArray.Length];
		
		private void ClickButton(Object sender, System.EventArgs e) {
			Button button = sender as Button;
			string ch = button.Text;
			if (ch == "+" || ch == "(" || ch == ")" || ch == "{" || ch == "}" || ch == "^" || ch == "~" || ch == "µ" || ch == "%") SendKeys.Send("{" + ch + "}");
			else{
				SendKeys.SendWait(button.Text);
			}
		}

		
		//Inheritance:     Object    MarshalByRefObject    Component    Control    ScrollableControl    Panel    TabPage
		//is why we can use: System.Windows.Forms.Panel pnl for Panel and also for TabPage
		private void AddButtons(System.Windows.Forms.Panel pnl, string[] StrArray, System.Windows.Forms.Button[] btn, int nbCols, double widthMultiple,int[] crlf ) {
			int spacing = 1;
			int xPos = spacing;
			int yPos = 0;
			int shiftCell=0;
			int indexCrlf=0;
			int nbButtons = StrArray.Length;
			for (int i = 0; i < nbButtons; i++) {
				btn[i] = new System.Windows.Forms.Button();
				btn[i].UseMnemonic = false;
				btn[i].Width = Convert.ToInt32(31 * widthMultiple); // Width of button
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
		
		private void ButtonEnterClick(object sender, EventArgs e) {
			SendKeys.SendWait("{ENTER}");
		}
		
		private void ButtonSpaceClick(object sender, EventArgs e) {
			SendKeys.SendWait(" ");
		}

		private static void RoundBorder(Control frm, int CornerRadius)
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
		
		private void TabPageLastOneClick(object sender, EventArgs e)
		{
			string personalStr = ConfigurationManager.AppSettings["keys"];
			string titleStr = ConfigurationManager.AppSettings["title"];
			PopupForm popup = new PopupForm();
			popup.textBox1.Text=titleStr;
			popup.textBox2.Text=personalStr;
			DialogResult dialogresult = popup.ShowDialog();
			
			string [] personalStrArrayStr = ConfigurationManager.AppSettings["keys"].Split(',');
			System.Windows.Forms.Button[] btnArrayPersonal = new System.Windows.Forms.Button[personalStrArrayStr.Length];
			var tp = sender as TabPage;
			int tabCount = tabControl1.TabPages.Count;
			//var tt=tabControl1.TabPages[tp.TabIndex-1];
			var tt=tabControl1.TabPages[tabCount-1];
            tt.Controls.Clear();

			//AddButtons( mytabs[mytabs.Length-1], personalStrArrayStr, btnArrayPersonal, 12, 2, new int[] { 0 } );
			AddButtons(tt, personalStrArrayStr, btnArrayPersonal, 12, 2, new int[] { 0 } );
			tt.Text = ConfigurationManager.AppSettings["title"];

		}
		
		private void  MainForm_FormClosing(object sender, FormClosingEventArgs e){
			try{
				if (tabControl1.SelectedIndex != Convert.ToInt16(ConfigurationManager.AppSettings["tabToSelect"])){
					Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
					config.AppSettings.Settings["tabToSelect"].
						Value = tabControl1.SelectedIndex.ToString();
					config.Save(ConfigurationSaveMode.Modified);
				}
			}catch{}
		}
	}
}