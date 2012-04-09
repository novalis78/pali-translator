namespace PaliTranslator
{
    using CST.Conversion;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    [ComVisible(true)]
    public class Form1 : Form
    {
        private Stack<BackStackItem> backStack;
        private Button btnClose;
        public System.Windows.Forms.ComboBox cbDefinitionLanguage;
        private IContainer components = null;
        private bool dontLookup;
        private bool dontSelectFirst;
        private List<DictionaryWord> enWords;
        private List<DictionaryWord> hiWords;
        private System.Windows.Forms.Label lblDefinitionLanguage;
        private System.Windows.Forms.Label lblMeaning;
        private System.Windows.Forms.Label lblWord;
        private System.Windows.Forms.Label lblWords;
        public System.Windows.Forms.ListBox lbWords;
        public System.Windows.Forms.TextBox txtForBorder;
        public System.Windows.Forms.TextBox txtWord;
        private System.Windows.Forms.WebBrowser wbMeaning;
        private System.ComponentModel.ComponentResourceManager manager;

        public Form1()
        {
            string searchedWord = "";
            this.InitializeComponent();
            this.wbMeaning.ObjectForScripting = this;
            this.wbMeaning.BringToFront();
            this.backStack = new Stack<BackStackItem>();
            this.DontLookup = true;
            if (this.cbDefinitionLanguage.SelectedIndex < 0)
            {
                this.cbDefinitionLanguage.SelectedIndex = 0;
            }
            this.DontLookup = false;
            if ((searchedWord != null) && (searchedWord.Length > 0))
            {
                this.txtWord.Text = searchedWord.ToLower();
            }
            this.ResizeWordsAndMeanings();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            base.Hide();
            AppState.Inst.DictionaryShown = false;
        }

        private void cbDefinitionLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.backStack.Clear();
            if (!this.DontLookup)
            {
                this.LookupWord();
            }
        }

        public void ChangeScript()
        {
            this.ReloadListBoxItems(this.lbWords);
            this.lbWords.Font = Fonts.GetListBoxFont(AppState.Inst.CurrentScript);
            this.ResizeWordsAndMeanings();
        }

        private void ClearResults()
        {
            this.lbWords.Items.Clear();
        }

        private int CountCommonStartLetters(string str1, string str2)
        {
            if ((((str1 == null) || (str1.Length == 0)) || (str2 == null)) || (str2.Length == 0))
            {
                return 0;
            }
            int num = (str1.Length < str2.Length) ? str1.Length : str2.Length;
            int num2 = 0;
            num2 = 0;
            while (num2 < num)
            {
                if (str1[num2] != str2[num2])
                {
                    return num2;
                }
                num2++;
            }
            return num2;
        }

        public void DisplayMeaning(string meaning)
        {
            string str = "";
            if (this.cbDefinitionLanguage.SelectedIndex == 0)
            {
                str = "body { font-family:Tahoma; font-size:9.75pt; border-top:0; }";
            }
            else if (this.cbDefinitionLanguage.SelectedIndex == 1)
            {
                str = "body { font-family:CDAC-GISTSurekh; font-size:11pt; border-top:0; };";
            }
            meaning = Regex.Replace(meaning, "<see>(.+?)</see>", "<a onclick=\"window.external.SeeAlso('$1')\" href=\"#\">$1</a>");
            string str2 = "<html><head><style type=\"text/css\">" + str + "</style></head><body><p>" + meaning + "</p>";
            if (this.backStack.Count > 0)
            {
                string str3 = ScriptConverter.Convert(this.backStack.Peek().Word, Script.Ipe, AppState.Inst.CurrentScript);
                string str4 = str2;
                str2 = str4 + "<p>Back to <a onclick=\"window.external.SeeAlsoBack('" + str3 + "')\" href=\"#\">" + str3 + "</a></p>";
            }
            str2 = str2 + "</body></html>";
            this.wbMeaning.DocumentText = str2;
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (this.components != null))
        //    {
        //        this.components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        private void FormDictionary_FormClosing(object sender, FormClosingEventArgs e)
        {
            base.Hide();
            if (e.CloseReason == CloseReason.UserClosing)
            {
                AppState.Inst.DictionaryShown = false;
                e.Cancel = true;
            }
        }

        private void FormDictionary_Resize(object sender, EventArgs e)
        {
            this.ResizeWordsAndMeanings();
        }

        private void InitializeComponent()
        {
            manager = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblWord = new System.Windows.Forms.Label();
            this.txtWord = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.lbWords = new System.Windows.Forms.ListBox();
            this.lblWords = new System.Windows.Forms.Label();
            this.lblMeaning = new System.Windows.Forms.Label();
            this.wbMeaning = new System.Windows.Forms.WebBrowser();
            this.txtForBorder = new System.Windows.Forms.TextBox();
            this.lblDefinitionLanguage = new System.Windows.Forms.Label();
            this.cbDefinitionLanguage = new System.Windows.Forms.ComboBox();
            base.SuspendLayout();
            manager.ApplyResources(this.lblWord, "lblWord");
            this.lblWord.Name = "lblWord";
            manager.ApplyResources(this.txtWord, "txtWord");
            this.txtWord.Name = "txtWord";
            this.txtWord.KeyPress += new KeyPressEventHandler(this.txtWord_KeyPress);
            this.txtWord.TextChanged += new System.EventHandler(this.txtWord_TextChanged);
            manager.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.lbWords.FormattingEnabled = true;
            manager.ApplyResources(this.lbWords, "lbWords");
            this.lbWords.Name = "lbWords";
            this.lbWords.SelectedIndexChanged += new System.EventHandler(this.lbWords_SelectedIndexChanged);
            manager.ApplyResources(this.lblWords, "lblWords");
            this.lblWords.Name = "lblWords";
            manager.ApplyResources(this.lblMeaning, "lblMeaning");
            this.lblMeaning.Name = "lblMeaning";
            manager.ApplyResources(this.wbMeaning, "wbMeaning");
            this.wbMeaning.MinimumSize = new Size(20, 20);
            this.wbMeaning.Name = "wbMeaning";
            manager.ApplyResources(this.txtForBorder, "txtForBorder");
            this.txtForBorder.Name = "txtForBorder";
            manager.ApplyResources(this.lblDefinitionLanguage, "lblDefinitionLanguage");
            this.lblDefinitionLanguage.Name = "lblDefinitionLanguage";
            this.cbDefinitionLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDefinitionLanguage.FormattingEnabled = true;
            this.cbDefinitionLanguage.Items.AddRange(new object[] { manager.GetString("cbDefinitionLanguage.Items"), manager.GetString("cbDefinitionLanguage.Items1") });
            manager.ApplyResources(this.cbDefinitionLanguage, "cbDefinitionLanguage");
            this.cbDefinitionLanguage.Name = "cbDefinitionLanguage";
            this.cbDefinitionLanguage.SelectedIndexChanged += new System.EventHandler(this.cbDefinitionLanguage_SelectedIndexChanged);
            manager.ApplyResources(this, "$this");
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.Controls.Add(this.cbDefinitionLanguage);
            base.Controls.Add(this.lblDefinitionLanguage);
            base.Controls.Add(this.txtForBorder);
            base.Controls.Add(this.wbMeaning);
            base.Controls.Add(this.lblMeaning);
            base.Controls.Add(this.lblWords);
            base.Controls.Add(this.lbWords);
            base.Controls.Add(this.btnClose);
            base.Controls.Add(this.txtWord);
            base.Controls.Add(this.lblWord);
            base.Name = "FormDictionary";
            base.ShowIcon = false;
            base.ShowInTaskbar = false;
            base.Resize += new System.EventHandler(this.FormDictionary_Resize);
            base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDictionary_FormClosing);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void lbWords_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lbWords.SelectedIndex > 0)
            {
                this.backStack.Clear();
            }
            DictionaryWord word = (DictionaryWord)this.lbWords.Items[this.lbWords.SelectedIndex];
            this.DisplayMeaning(word.Meaning);
        }

        private void LoadEnglishDictionary()
        {
            this.enWords = new List<DictionaryWord>();
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            try
            {
                FileInfo[] files = new DirectoryInfo(Config.Inst.ReferenceDirectory + Path.DirectorySeparatorChar + Config.Inst.EnglishDictionaryDirectory).GetFiles();
                foreach (FileInfo info2 in files)
                {
                    string str;
                    bool flag;
                    StreamReader reader = new StreamReader(info2.FullName);
                    goto Label_0123;
                Label_0068:
                    str = reader.ReadLine();
                    if (str == null)
                    {
                        goto Label_012B;
                    }
                    string str2 = reader.ReadLine();
                    if (str2 == null)
                    {
                        goto Label_012B;
                    }
                    if ((((str != null) && (str.Length != 0)) && (str2 != null)) && (str2.Length != 0))
                    {
                        str = Any2Ipe.Convert(str);
                        if (dictionary.ContainsKey(str))
                        {
                            string str3 = dictionary[str];
                            str3 = str3 + "</p><hr/<p>" + str2;
                            dictionary.Remove(str);
                            dictionary.Add(str, str3);
                        }
                        else
                        {
                            dictionary.Add(str, str2);
                        }
                    }
                Label_0123:
                    flag = true;
                    goto Label_0068;
                Label_012B:
                    reader.Close();
                }
                foreach (string str in dictionary.Keys)
                {
                    this.enWords.Add(new DictionaryWord(str, dictionary[str]));
                }
                this.enWords.Sort(new DictionaryWordComparer());
            }
            catch (Exception exception)
            {
                this.enWords = null;
                MessageBox.Show("Error reading Pali-English dictionary: " + exception.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }


        private void LoadHindiDictionary()
        {
            this.hiWords = new List<DictionaryWord>();
            try
            {
                string str;
                bool flag;
                StreamReader reader = new StreamReader(Config.Inst.ReferenceDirectory + Path.DirectorySeparatorChar + Config.Inst.PaliHindiDictionaryFile);
                goto Label_00A0;
            Label_0038:
                str = reader.ReadLine();
                if (str == null)
                {
                    goto Label_00A4;
                }
                string meaning = reader.ReadLine();
                if (meaning == null)
                {
                    goto Label_00A4;
                }
                if ((((str != null) && (str.Length != 0)) && (meaning != null)) && (meaning.Length != 0))
                {
                    str = Any2Ipe.Convert(str);
                    this.hiWords.Add(new DictionaryWord(str, meaning));
                }
            Label_00A0:
                flag = true;
                goto Label_0038;
            Label_00A4:
                this.hiWords.Sort(new DictionaryWordComparer());
                reader.Close();
            }
            catch (Exception)
            {
                this.hiWords = null;
                MessageBox.Show("Error", "Error reading Pali-Hindi dictionary", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        public void LookupWord()
        {
            this.btnClose.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;
            this.lbWords.Font = Fonts.GetListBoxFont(AppState.Inst.CurrentScript);
            this.ClearResults();
            if ((this.enWords == null) && (this.cbDefinitionLanguage.SelectedIndex == 0))
            {
                this.LoadEnglishDictionary();
            }
            if ((this.hiWords == null) && (this.cbDefinitionLanguage.SelectedIndex == 1))
            {
                this.LoadHindiDictionary();
            }
            this.Search();
            Cursor.Current = Cursors.Default;
            this.btnClose.Enabled = true;
        }

        private void ReloadListBoxItems(ListBox listBox)
        {
            if (listBox.Items.Count > 0)
            {
                int num;
                object[] destination = new object[listBox.Items.Count];
                listBox.Items.CopyTo(destination, 0);
                int[] numArray = new int[listBox.SelectedIndices.Count];
                listBox.SelectedIndices.CopyTo(numArray, 0);
                listBox.Items.Clear();
                for (num = 0; num < destination.Length; num++)
                {
                    listBox.Items.Add(destination[num]);
                }
                for (num = 0; num < numArray.Length; num++)
                {
                    listBox.SetSelected(numArray[num], true);
                }
            }
        }

        private void ResizeWordsAndMeanings()
        {
            int num = 20;
            int num2 = 20;
            this.lbWords.Height = (base.ClientRectangle.Height - this.lbWords.Location.Y) - num;
            this.txtForBorder.Height = this.lbWords.Height;
            this.wbMeaning.Height = this.txtForBorder.Height - 4;
            this.txtForBorder.Width = (base.ClientRectangle.Width - this.txtForBorder.Location.X) - num2;
            this.wbMeaning.Width = this.txtForBorder.Width - 4;
        }

        private void Search()
        {
            List<DictionaryWord> enWords = null;
            if (this.cbDefinitionLanguage.SelectedIndex == 0)
            {
                enWords = this.enWords;
            }
            else if (this.cbDefinitionLanguage.SelectedIndex == 1)
            {
                enWords = this.hiWords;
            }
            if (enWords != null)
            {
                string text = this.txtWord.Text;
                if ((text == null) || (text.Length == 0))
                {
                    this.DisplayMeaning("");
                }
                else
                {
                    text = Any2Ipe.Convert(text);
                    int num = enWords.BinarySearch(new DictionaryWord(text, ""), new DictionaryWordComparer());
                    if (num < 0)
                    {
                        num = ~num;
                        int num2 = num;
                        DictionaryWord word = null;
                        DictionaryWord word2 = null;
                        int num3 = 0;
                        int num4 = 0;
                        if (((num - 1) >= 0) && ((num - 1) < enWords.Count))
                        {
                            word = enWords[num - 1];
                            num3 = this.CountCommonStartLetters(text, word.Word);
                        }
                        if ((num >= 0) && (num < enWords.Count))
                        {
                            word2 = enWords[num];
                            num4 = this.CountCommonStartLetters(text, word2.Word);
                        }

                        if ((num3 >= num4) && (num3 > 0))
                        {
                            Stack<DictionaryWord> stack = new Stack<DictionaryWord>();
                            num--;
                            DictionaryWord item = null;
                            while ((num >= 0) && (num < enWords.Count))
                            {
                                item = enWords[num];
                                if (this.CountCommonStartLetters(text, item.Word) != num3)
                                {
                                    break;
                                }
                                stack.Push(item);
                                num--;
                            }
                            while (stack.Count > 0)
                            {
                                item = stack.Pop();
                                this.lbWords.Items.Add(item);
                            }
                        }
                        if ((num4 >= num3) && (num4 > 0))
                        {
                            for (num = num2; num < enWords.Count; num++)
                            {
                                if (this.CountCommonStartLetters(enWords[num].Word, text) != num4)
                                {
                                    break;
                                }
                                this.lbWords.Items.Add(enWords[num]);
                            }
                        }
                        if (this.lbWords.Items.Count == 0)
                        {
                            this.DisplayMeaning("");
                        }
                        else if (!((this.lbWords.Items.Count <= 0) || this.DontSelectFirst))
                        {
                            this.lbWords.SelectedIndex = 0;
                        }
                    }
                    else
                    {
                        this.lbWords.Items.Add(enWords[num]);
                        num++;
                        while (num < enWords.Count)
                        {
                            if (!enWords[num].Word.StartsWith(text))
                            {
                                break;
                            }
                            this.lbWords.Items.Add(enWords[num]);
                            num++;
                        }
                        if (!((this.lbWords.Items.Count <= 0) || this.DontSelectFirst))
                        {
                            this.lbWords.SelectedIndex = 0;
                        }
                    }
                }
            }
        }

        public void SeeAlso(string word)
        {
            this.backStack.Push(new BackStackItem(this.txtWord.Text, ((DictionaryWord)this.lbWords.Items[this.lbWords.SelectedIndex]).Word, this.lbWords.SelectedIndex));
            this.txtWord.Text = word;
        }

        public void SeeAlsoBack(string word)
        {
            BackStackItem item = this.backStack.Pop();
            this.txtWord.Text = item.UserText;
            if (item.SelectedIndex < this.lbWords.Items.Count)
            {
                this.lbWords.SelectedIndex = item.SelectedIndex;
            }
        }

        public void SetSearchedWord(string searchedWord)
        {
            this.txtWord.Text = searchedWord.ToLower();
        }

        private void txtWord_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.backStack.Clear();
        }

        private void txtWord_TextChanged(object sender, EventArgs e)
        {
            if (this.txtWord.Text.Length > 0)
            {
                Script script = Any2Deva.GetScript(this.txtWord.Text[0]);
                this.txtWord.Font = Fonts.GetControlFont(script);
            }
            if (this.txtWord.SelectionLength > 0)
            {
                this.txtWord.SelectionLength = 0;
            }
            if (!this.DontLookup)
            {
                this.LookupWord();
            }
        }

        public bool DontLookup
        {
            get
            {
                return this.dontLookup;
            }
            set
            {
                this.dontLookup = value;
            }
        }

        public bool DontSelectFirst
        {
            get
            {
                return this.dontSelectFirst;
            }
            set
            {
                this.dontSelectFirst = value;
            }
        }
    }
}

