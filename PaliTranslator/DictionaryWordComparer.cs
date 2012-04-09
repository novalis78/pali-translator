namespace PaliTranslator
{
    using System;
    using System.Collections.Generic;

    public class DictionaryWordComparer : IComparer<DictionaryWord>
    {
        public int Compare(DictionaryWord dw1, DictionaryWord dw2)
        {
            int num = 0;
            string word = dw1.Word;
            string str2 = dw2.Word;
            while ((word.Length > num) && (str2.Length > num))
            {
                if (word[num] < str2[num])
                {
                    return -1;
                }
                if (word[num] > str2[num])
                {
                    return 1;
                }
                num++;
            }
            return (word.Length - str2.Length);
        }
    }
}

