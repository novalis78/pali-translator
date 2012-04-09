namespace PaliTranslator
{
    using System;

    [Serializable]
    public class WordPosition : IComparable<WordPosition>
    {
        private int endOffset;
        private bool isFirstTerm;
        private int position;
        private int positionIndex;
        private int startOffset;
        protected string word;
        private int wordIndex;

        public WordPosition(int wordIndex, int position, int positionIndex, bool isFirstTerm)
        {
            this.wordIndex = wordIndex;
            this.position = position;
            this.positionIndex = positionIndex;
            this.isFirstTerm = isFirstTerm;
        }

        public int CompareTo(WordPosition wp)
        {
            return (this.Position - wp.Position);
        }

        public int EndOffset
        {
            get
            {
                return this.endOffset;
            }
            set
            {
                this.endOffset = value;
            }
        }

        public bool IsFirstTerm
        {
            get
            {
                return this.isFirstTerm;
            }
            set
            {
                this.isFirstTerm = value;
            }
        }

        public int Position
        {
            get
            {
                return this.position;
            }
            set
            {
                this.position = value;
            }
        }

        public int PositionIndex
        {
            get
            {
                return this.positionIndex;
            }
            set
            {
                this.positionIndex = value;
            }
        }

        public int StartOffset
        {
            get
            {
                return this.startOffset;
            }
            set
            {
                this.startOffset = value;
            }
        }

        public virtual string Word
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

        public int WordIndex
        {
            get
            {
                return this.wordIndex;
            }
            set
            {
                this.wordIndex = value;
            }
        }
    }
}

