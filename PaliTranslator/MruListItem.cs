namespace PaliTranslator
{
    using CST.Conversion;
    using System;
    using CST;

    [Serializable]
    public class MruListItem : IEquatable<MruListItem>
    {
        private Script bookScript;
        private int index;

        public MruListItem(int index, Script script)
        {
            this.index = index;
            this.bookScript = script;
        }

        public bool Equals(MruListItem other)
        {
            return ((other.bookScript == this.bookScript) && (other.index == this.index));
        }

        public override string ToString()
        {
            return ScriptConverter.Convert(Books.Inst[this.index].LongNavPath.Replace("/", " / "), Script.Devanagari, Fonts.GetWindowsSafeScript(this.BookScript), true);
        }

        public Script BookScript
        {
            get
            {
                return this.bookScript;
            }
            set
            {
                this.bookScript = value;
            }
        }

        public int Index
        {
            get
            {
                return this.index;
            }
            set
            {
                this.index = value;
            }
        }
    }
}

