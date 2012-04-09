namespace PaliTranslator
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class MatchingMultiWordBook : MatchingWordBook
    {
        private SortedDictionary<int, WordPosition> wordPositions;

        public MatchingMultiWordBook()
        {
            this.WordPositions = new SortedDictionary<int, WordPosition>();
        }

        public override int Count
        {
            get
            {
                int num = 0;
                foreach (WordPosition position in this.WordPositions.Values)
                {
                    if (position.IsFirstTerm)
                    {
                        num++;
                    }
                }
                return num;
            }
        }

        public SortedDictionary<int, WordPosition> WordPositions
        {
            get
            {
                return this.wordPositions;
            }
            set
            {
                this.wordPositions = value;
            }
        }
    }
}

