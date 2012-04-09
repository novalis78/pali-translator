namespace PaliTranslator
{
    //using PaliTranslator.Conversion;
    using System;
    using CST.Conversion;

    public class DictionaryWord
    {
        private string meaning;
        private string word;

        public DictionaryWord(string word, string meaning)
        {
            this.word = word;
            this.meaning = meaning;
        }

        public override string ToString()
        {
            return ScriptConverter.Convert(this.Word, Script.Ipe, AppState.Inst.CurrentScript);
        }

        public string Meaning
        {
            get
            {
                return this.meaning;
            }
            set
            {
                this.meaning = value;
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

