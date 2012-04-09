namespace PaliTranslator
{
    using System;

    public class BackStackItem
    {
        private int selectedIndex;
        private string userText;
        private string word;

        public BackStackItem(string userText, string word, int selectedIndex)
        {
            this.userText = userText;
            this.word = word;
            this.selectedIndex = selectedIndex;
        }

        public int SelectedIndex
        {
            get
            {
                return this.selectedIndex;
            }
            set
            {
                this.selectedIndex = value;
            }
        }

        public string UserText
        {
            get
            {
                return this.userText;
            }
            set
            {
                this.userText = value;
            }
        }

        public string Word
        {
            get
            {
                return this.word;
            }
            set
            {
                this.word = value;
            }
        }
    }
}

