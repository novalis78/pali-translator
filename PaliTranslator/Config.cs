namespace PaliTranslator
{
    using System;

    [Serializable]
    public class Config
    {
        private static Config config;
        private string indexDirectory;
        private string refDirectory;
        private string xmlDirectory;
        private string xslDirectory;

        public string EnglishDictionaryDirectory
        {
            get
            {
                return "en";
            }
        }

        public string HindiDictionaryDirectory
        {
            get
            {
                return "hi";
            }
        }

        public string IndexDirectory
        {
            get
            {
                if ((this.indexDirectory == null) || (this.indexDirectory.Length == 0))
                {
                    this.indexDirectory = "Index";
                }
                return this.indexDirectory;
            }
            set
            {
                this.indexDirectory = value;
            }
        }

        public static Config Inst
        {
            get
            {
                if (config == null)
                {
                    config = new Config();
                }
                return config;
            }
        }

        public string PaliEnglishDictionaryFile
        {
            get
            {
                return "pali-english-dictionary.txt";
            }
        }

        public string PaliHindiDictionaryFile
        {
            get
            {
                return "pali-hindi-dictionary.txt";
            }
        }

        public string ReferenceDirectory
        {
            get
            {
                if ((this.refDirectory == null) || (this.refDirectory.Length == 0))
                {
                    this.refDirectory = "Reference";
                }
                return this.refDirectory;
            }
            set
            {
                this.refDirectory = value;
            }
        }

        public string XmlDirectory
        {
            get
            {
                if ((this.xmlDirectory == null) || (this.xmlDirectory.Length == 0))
                {
                    this.xmlDirectory = "Xml";
                }
                return this.xmlDirectory;
            }
            set
            {
                this.xmlDirectory = value;
            }
        }

        public string XslDirectory
        {
            get
            {
                if ((this.xslDirectory == null) || (this.xslDirectory.Length == 0))
                {
                    this.xslDirectory = "Xsl";
                }
                return this.xslDirectory;
            }
            set
            {
                this.xslDirectory = value;
            }
        }
    }
}

