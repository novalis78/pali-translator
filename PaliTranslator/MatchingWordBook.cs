namespace PaliTranslator
{
    //using PaliTranslator.Conversion;
    using System;
    using CST.Conversion;

    [Serializable]
    public class MatchingWordBook
    {
        private CST.Book book;
        private int count;

        public virtual MatchingWordBook Copy()
        {
            MatchingWordBook book = new MatchingWordBook();
            book.Book = this.Book;
            book.Count = this.Count;
            return book;
        }

        public override bool Equals(object obj)
        {
            return ((obj is MatchingWordBook) && (this.book.Index == ((MatchingWordBook) obj).book.Index));
        }

        public override int GetHashCode()
        {
            return this.book.Index;
        }

        public override string ToString()
        {
            string str = this.Book.ShortNavPath.Replace("/", " / ");
            return ScriptConverter.Convert(Latn2Deva.Convert(this.Count.ToString()) + " - " + str, Script.Devanagari, AppState.Inst.CurrentScript, true);
        }

        public CST.Book Book
        {
            get
            {
                return this.book;
            }
            set
            {
                this.book = value;
            }
        }

        public virtual int Count
        {
            get
            {
                return this.count;
            }
            set
            {
                this.count = value;
            }
        }
    }
}

