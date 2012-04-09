using System.Windows.Forms;
using System.Drawing;
using NishBox;
namespace PaliTranslator
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        //private System.ComponentModel.IContainer components = null;

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
            this.cbDefinitionLanguage = new System.Windows.Forms.ComboBox();
            this.paliText = new System.Windows.Forms.TextBox();
            this.translatedText = new System.Windows.Forms.TextBox();
            this.translateBtn = new System.Windows.Forms.Button();
            this.wordAnalysisList = new NishBox.MultiLineListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.wbMeaning = new System.Windows.Forms.WebBrowser();
            this.txtForBorder = new System.Windows.Forms.TextBox();
            this.lblMeaning = new System.Windows.Forms.Label();
            this.lblWords = new System.Windows.Forms.Label();
            this.lbWords = new System.Windows.Forms.ListBox();
            this.txtWord = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbDefinitionLanguage
            // 
            this.cbDefinitionLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDefinitionLanguage.FormattingEnabled = true;
            this.cbDefinitionLanguage.Items.AddRange(new object[] {
            "English",
            "Hindi"});
            this.cbDefinitionLanguage.Location = new System.Drawing.Point(450, 219);
            this.cbDefinitionLanguage.Name = "cbDefinitionLanguage";
            this.cbDefinitionLanguage.Size = new System.Drawing.Size(152, 21);
            this.cbDefinitionLanguage.TabIndex = 2;
            this.cbDefinitionLanguage.Visible = false;
            this.cbDefinitionLanguage.SelectedIndexChanged += new System.EventHandler(this.cbDefinitionLanguage_SelectedIndexChanged);
            // 
            // paliText
            // 
            this.paliText.Dock = System.Windows.Forms.DockStyle.Top;
            this.paliText.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paliText.Location = new System.Drawing.Point(0, 0);
            this.paliText.Multiline = true;
            this.paliText.Name = "paliText";
            this.paliText.Size = new System.Drawing.Size(624, 166);
            this.paliText.TabIndex = 11;
            // 
            // translatedText
            // 
            this.translatedText.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.translatedText.Location = new System.Drawing.Point(516, 311);
            this.translatedText.Multiline = true;
            this.translatedText.Name = "translatedText";
            this.translatedText.Size = new System.Drawing.Size(91, 42);
            this.translatedText.TabIndex = 12;
            this.translatedText.Visible = false;
            // 
            // translateBtn
            // 
            this.translateBtn.Location = new System.Drawing.Point(439, 6);
            this.translateBtn.Name = "translateBtn";
            this.translateBtn.Size = new System.Drawing.Size(173, 38);
            this.translateBtn.TabIndex = 13;
            this.translateBtn.Text = "Translate";
            this.translateBtn.UseVisualStyleBackColor = true;
            this.translateBtn.Click += new System.EventHandler(this.translateBtn_Click);
            // 
            // wordAnalysisList
            // 
            this.wordAnalysisList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.wordAnalysisList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.wordAnalysisList.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wordAnalysisList.FormattingEnabled = true;
            this.wordAnalysisList.ItemHeight = 16;
            this.wordAnalysisList.Location = new System.Drawing.Point(0, 374);
            this.wordAnalysisList.Name = "wordAnalysisList";
            this.wordAnalysisList.ScrollAlwaysVisible = true;
            this.wordAnalysisList.Size = new System.Drawing.Size(624, 164);
            this.wordAnalysisList.TabIndex = 14;
            this.wordAnalysisList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.wordAnalysisList_DrawItem);
            this.wordAnalysisList.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.wordAnalysisList_MeasureItem);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(501, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Enter source text here";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(16, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Translated Text:";
            // 
            // wbMeaning
            // 
            this.wbMeaning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbMeaning.Location = new System.Drawing.Point(0, 0);
            this.wbMeaning.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbMeaning.Name = "wbMeaning";
            this.wbMeaning.Size = new System.Drawing.Size(624, 538);
            this.wbMeaning.TabIndex = 8;
            // 
            // txtForBorder
            // 
            this.txtForBorder.Location = new System.Drawing.Point(330, 420);
            this.txtForBorder.Multiline = true;
            this.txtForBorder.Name = "txtForBorder";
            this.txtForBorder.Size = new System.Drawing.Size(274, 108);
            this.txtForBorder.TabIndex = 9;
            this.txtForBorder.Visible = false;
            // 
            // lblMeaning
            // 
            this.lblMeaning.AutoSize = true;
            this.lblMeaning.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblMeaning.Location = new System.Drawing.Point(329, 402);
            this.lblMeaning.Name = "lblMeaning";
            this.lblMeaning.Size = new System.Drawing.Size(51, 13);
            this.lblMeaning.TabIndex = 7;
            this.lblMeaning.Text = "Meaning:";
            this.lblMeaning.Visible = false;
            // 
            // lblWords
            // 
            this.lblWords.AutoSize = true;
            this.lblWords.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblWords.Location = new System.Drawing.Point(16, 403);
            this.lblWords.Name = "lblWords";
            this.lblWords.Size = new System.Drawing.Size(41, 13);
            this.lblWords.TabIndex = 5;
            this.lblWords.Text = "Words:";
            this.lblWords.Visible = false;
            // 
            // lbWords
            // 
            this.lbWords.FormattingEnabled = true;
            this.lbWords.Location = new System.Drawing.Point(19, 420);
            this.lbWords.Name = "lbWords";
            this.lbWords.Size = new System.Drawing.Size(274, 108);
            this.lbWords.TabIndex = 4;
            this.lbWords.Visible = false;
            this.lbWords.SelectedIndexChanged += new System.EventHandler(this.lbWords_SelectedIndexChanged);
            // 
            // txtWord
            // 
            this.txtWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtWord.Location = new System.Drawing.Point(16, 359);
            this.txtWord.Name = "txtWord";
            this.txtWord.Size = new System.Drawing.Size(277, 22);
            this.txtWord.TabIndex = 1;
            this.txtWord.Visible = false;
            this.txtWord.TextChanged += new System.EventHandler(this.txtWord_TextChanged);
            this.txtWord.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWord_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(525, 385);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Word Analysis:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.translateBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 166);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(624, 47);
            this.panel1.TabIndex = 18;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 371);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(624, 3);
            this.splitter1.TabIndex = 19;
            this.splitter1.TabStop = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 538);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.wordAnalysisList);
            this.Controls.Add(this.translatedText);
            this.Controls.Add(this.paliText);
            this.Controls.Add(this.cbDefinitionLanguage);
            this.Controls.Add(this.txtForBorder);
            this.Controls.Add(this.wbMeaning);
            this.Controls.Add(this.lblMeaning);
            this.Controls.Add(this.lblWords);
            this.Controls.Add(this.lbWords);
            this.Controls.Add(this.txtWord);
            this.MinimumSize = new System.Drawing.Size(632, 362);
            this.Name = "Form2";
            this.Text = "PaliTranslator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDictionary_FormClosing);
            this.Resize += new System.EventHandler(this.FormDictionary_Resize);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox paliText;
        private TextBox translatedText;
        private Button translateBtn;
        private MultiLineListBox wordAnalysisList;
        private Label label1;
        private Label label2;
        private WebBrowser wbMeaning;
        public TextBox txtForBorder;
        private Label lblMeaning;
        private Label lblWords;
        public ListBox lbWords;
        public TextBox txtWord;
        private Label label3;
        private Panel panel1;
        private Splitter splitter1;
    }
}