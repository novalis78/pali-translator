namespace PaliTranslator
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class MruList : List<MruListItem>
    {
        private int maxItems;

        public void Add(MruListItem item)
        {
            base.Remove(item);
            base.Add(item);
            while (base.Count > this.MaxItems)
            {
                base.RemoveAt(0);
            }
        }

        public int MaxItems
        {
            get
            {
                if (this.maxItems <= 1)
                {
                    return 5;
                }
                return this.maxItems;
            }
            set
            {
                this.maxItems = value;
            }
        }
    }
}

