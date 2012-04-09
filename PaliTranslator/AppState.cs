namespace PaliTranslator
{
    using CST.Conversion;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Windows.Forms;

    [Serializable]
    public class AppState
    {
        private static AppState appState;
        private List<AppStateBookWindow> bookWindows;
        private Script currentScript = Script.Latin;
        private int dictionaryLanguageIndex;
        private Point dictionaryLocation;
        private bool dictionaryShown;
        private System.Drawing.Size dictionarySize;
        private string dictionaryUserText;
        private int dictionaryWordSelected;
        private static string fileName = "app-state.dat";
        private string interfaceLanguage;
        private Point location;
        private PaliTranslator.MruList mruList;
        private bool searchAbhi;
        private bool searchAll;
        private bool searchAttha;
        private int searchBookCollSelected;
        private int searchBookSelected;
        private int searchContextDistance;
        private Point searchFormLocation;
        private bool searchFormShown;
        private bool searchMula;
        private bool searchOtherTexts;
        private bool searchSutta;
        private string searchTerms;
        private bool searchTika;
        private int searchUse;
        private bool searchVinaya;
        private int[] searchWordsSelected;
        private Point selectFormLocation;
        private BitArray selectFormNodeStates;
        private bool selectFormShown;
        private System.Drawing.Size selectFormSize;
        private System.Drawing.Size size;
        private FormWindowState windowState;

        public static void Deserialize()
        {
            if (File.Exists(fileName))
            {
                FileInfo info = new FileInfo(fileName);
                if (info.Length == 0L)
                {
                    File.Delete(fileName);
                }
                else
                {
                    FileStream serializationStream = new FileStream(fileName, FileMode.Open);
                    try
                    {
                        try
                        {
                            BinaryFormatter formatter = new BinaryFormatter();
                            appState = (AppState) formatter.Deserialize(serializationStream);
                        }
                        catch (SerializationException exception)
                        {
                            Console.WriteLine("Failed to deserialize. Reason: " + exception.Message);
                            throw;
                        }
                    }
                    finally
                    {
                        serializationStream.Close();
                    }
                }
            }
        }

        public static void Serialize()
        {
            FileStream serializationStream = new FileStream(fileName, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                try
                {
                    formatter.Serialize(serializationStream, appState);
                }
                catch (SerializationException exception)
                {
                    Console.WriteLine("Failed to serialize. Reason: " + exception.Message);
                    throw;
                }
            }
            finally
            {
                serializationStream.Close();
            }
        }

        public List<AppStateBookWindow> BookWindows
        {
            get
            {
                return this.bookWindows;
            }
            set
            {
                this.bookWindows = value;
            }
        }

        public Script CurrentScript
        {
            get
            {
                return this.currentScript;
            }
            set
            {
                this.currentScript = value;
            }
        }

        public int DictionaryLanguageIndex
        {
            get
            {
                return this.dictionaryLanguageIndex;
            }
            set
            {
                this.dictionaryLanguageIndex = value;
            }
        }

        public Point DictionaryLocation
        {
            get
            {
                return this.dictionaryLocation;
            }
            set
            {
                this.dictionaryLocation = value;
            }
        }

        public bool DictionaryShown
        {
            get
            {
                return this.dictionaryShown;
            }
            set
            {
                this.dictionaryShown = value;
            }
        }

        public System.Drawing.Size DictionarySize
        {
            get
            {
                return this.dictionarySize;
            }
            set
            {
                this.dictionarySize = value;
            }
        }

        public string DictionaryUserText
        {
            get
            {
                return this.dictionaryUserText;
            }
            set
            {
                this.dictionaryUserText = value;
            }
        }

        public int DictionaryWordSelected
        {
            get
            {
                return this.dictionaryWordSelected;
            }
            set
            {
                this.dictionaryWordSelected = value;
            }
        }

        public static AppState Inst
        {
            get
            {
                if (appState == null)
                {
                    appState = new AppState();
                }
                return appState;
            }
        }

        public string InterfaceLanguage
        {
            get
            {
                return this.interfaceLanguage;
            }
            set
            {
                this.interfaceLanguage = value;
            }
        }

        public Point Location
        {
            get
            {
                return this.location;
            }
            set
            {
                this.location = value;
            }
        }

        public PaliTranslator.MruList MruList
        {
            get
            {
                if (this.mruList == null)
                {
                    this.mruList = new PaliTranslator.MruList();
                }
                return this.mruList;
            }
            set
            {
                this.mruList = value;
            }
        }

        public bool SearchAbhi
        {
            get
            {
                return this.searchAbhi;
            }
            set
            {
                this.searchAbhi = value;
            }
        }

        public bool SearchAll
        {
            get
            {
                return this.searchAll;
            }
            set
            {
                this.searchAll = value;
            }
        }

        public bool SearchAttha
        {
            get
            {
                return this.searchAttha;
            }
            set
            {
                this.searchAttha = value;
            }
        }

        public int SearchBookCollSelected
        {
            get
            {
                return this.searchBookCollSelected;
            }
            set
            {
                this.searchBookCollSelected = value;
            }
        }

        public int SearchBookSelected
        {
            get
            {
                return this.searchBookSelected;
            }
            set
            {
                this.searchBookSelected = value;
            }
        }

        public int SearchContextDistance
        {
            get
            {
                return this.searchContextDistance;
            }
            set
            {
                this.searchContextDistance = value;
            }
        }

        public Point SearchFormLocation
        {
            get
            {
                return this.searchFormLocation;
            }
            set
            {
                this.searchFormLocation = value;
            }
        }

        public bool SearchFormShown
        {
            get
            {
                return this.searchFormShown;
            }
            set
            {
                this.searchFormShown = value;
            }
        }

        public bool SearchMula
        {
            get
            {
                return this.searchMula;
            }
            set
            {
                this.searchMula = value;
            }
        }

        public bool SearchOtherTexts
        {
            get
            {
                return this.searchOtherTexts;
            }
            set
            {
                this.searchOtherTexts = value;
            }
        }

        public bool SearchSutta
        {
            get
            {
                return this.searchSutta;
            }
            set
            {
                this.searchSutta = value;
            }
        }

        public string SearchTerms
        {
            get
            {
                return this.searchTerms;
            }
            set
            {
                this.searchTerms = value;
            }
        }

        public bool SearchTika
        {
            get
            {
                return this.searchTika;
            }
            set
            {
                this.searchTika = value;
            }
        }

        public int SearchUse
        {
            get
            {
                return this.searchUse;
            }
            set
            {
                this.searchUse = value;
            }
        }

        public bool SearchVinaya
        {
            get
            {
                return this.searchVinaya;
            }
            set
            {
                this.searchVinaya = value;
            }
        }

        public int[] SearchWordsSelected
        {
            get
            {
                return this.searchWordsSelected;
            }
            set
            {
                this.searchWordsSelected = value;
            }
        }

        public Point SelectFormLocation
        {
            get
            {
                return this.selectFormLocation;
            }
            set
            {
                this.selectFormLocation = value;
            }
        }

        public BitArray SelectFormNodeStates
        {
            get
            {
                return this.selectFormNodeStates;
            }
            set
            {
                this.selectFormNodeStates = value;
            }
        }

        public bool SelectFormShown
        {
            get
            {
                return this.selectFormShown;
            }
            set
            {
                this.selectFormShown = value;
            }
        }

        public System.Drawing.Size SelectFormSize
        {
            get
            {
                return this.selectFormSize;
            }
            set
            {
                this.selectFormSize = value;
            }
        }

        public System.Drawing.Size Size
        {
            get
            {
                return this.size;
            }
            set
            {
                this.size = value;
            }
        }

        public FormWindowState WindowState
        {
            get
            {
                return this.windowState;
            }
            set
            {
                this.windowState = value;
            }
        }
    }
}

