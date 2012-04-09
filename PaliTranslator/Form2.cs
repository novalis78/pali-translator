using CST.Conversion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PaliTranslator
{
    [ComVisible(true)]
    public partial class Form2 : Form
    {
        private Stack<BackStackItem> backStack;
        public System.Windows.Forms.ComboBox cbDefinitionLanguage;
        private IContainer components = null;
        private bool dontLookup;
        private bool dontSelectFirst;
        private List<DictionaryWord> enWords;
        private List<DictionaryWord> hiWords;
        private System.ComponentModel.ComponentResourceManager manager;

        public Form2()
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
            this.Close();
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

        private void FormDictionary_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.Dispose();
                this.Close();
            }
            catch(System.Exception ex)
            {
            }
            finally{}
        }

        private void FormDictionary_Resize(object sender, EventArgs e)
        {
            this.ResizeWordsAndMeanings();
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
           // this.btnClose.Enabled = false;
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
            //this.btnClose.Enabled = true;
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
            //this.wbMeaning.Height = this.txtForBorder.Height - 4;
            this.txtForBorder.Width = (base.ClientRectangle.Width - this.txtForBorder.Location.X) - num2;
            //this.wbMeaning.Width = this.txtForBorder.Width - 4;
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

        private void translateBtn_Click(object sender, EventArgs e)
        {
            this.wordAnalysisList.Items.Clear();
            string inputText = paliText.Text;
            string outputText = "";
            string str2 = "";
            this.wbMeaning.DocumentText = "<head></head><body></body>";

            if(String.IsNullOrEmpty(inputText))
                return;

            string[] words = inputText.Split(' ');

            foreach (string item in words)
            {
                this.txtWord.Text = item;
                
                DictionaryWord word = null;
                string wordDef = item;
                this.backStack.Clear();
                this.LookupWord();
                if (this.lbWords.Items == null)
                    outputText += " --- ";
                else
                {
                    if (this.lbWords.Items.Count <= 0)
                        continue;
                    word = (DictionaryWord)this.lbWords.Items[0];
                    this.DisplayMeaning(word.Meaning);
                    if (item.EndsWith("ti"))
                        wordDef += " (VB) ";
                    else if (item.EndsWith("o"))
                        wordDef += " (N|NOM) ";
                    else if (item.EndsWith("aṃ"))
                        wordDef += " (N|ACC) ";
                    else if (item.EndsWith("esu"))
                        wordDef += " (N|LOC) ";
                    else if (item.EndsWith("tu"))
                        wordDef += " (VB|IMP) ";

                    this.wordAnalysisList.Items.Add(wordDef + " => " + word.Meaning);
                    outputText += word.Meaning + " ";
                    str2 += "<head><style>.interlinear_term {margin-top: 1ex; border-left: 1px solid grey; float: left; margin-bottom: 2ex;}</style></head><body></body><div class=\"interlinear_term\"><table><tbody><tr><td><br></td><td><br></td><td><br></td><td><br><b><term>" + item + "</term></b>";
                    str2 += "</td></tr></tbody></table><table><tbody><tr><td colspan=\"4\">" + word.Meaning + "</td></tr></tbody></table></div>";
                }
            }
            //translatedText.Text = outputText;
            this.wbMeaning.BringToFront();
            this.wbMeaning.Navigate("about:blank");
            HtmlDocument doc =  this.wbMeaning.Document;
            doc.Write(String.Empty);
            this.wbMeaning.DocumentText = str2;
           
        }

        private void wordAnalysisList_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            Font F = new  Font("Arial", 12, FontStyle.Bold);
            e.ItemHeight = TextRenderer.MeasureText(this.wordAnalysisList.Items[e.Index].ToString(), F).Height;
        }

        private void wordAnalysisList_DrawItem(object sender, DrawItemEventArgs e)
        {
            Font F = new Font("Arial", 12, FontStyle.Bold);
            e.DrawBackground();
            e.Graphics.DrawString(this.wordAnalysisList.Items[e.Index].ToString(), F, Brushes.Red, e.Bounds.X, e.Bounds.Y);
            e.DrawFocusRectangle();
        }


    }
}




