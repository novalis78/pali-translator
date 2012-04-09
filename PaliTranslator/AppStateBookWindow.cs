namespace PaliTranslator
{
    using CST.Conversion;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;

    [Serializable]
    public class AppStateBookWindow
    {
        private int bookIndex;
        private Script bookScript;
        private Point location;
        private MatchingMultiWordBook mmwb;
        private bool showFootnotes;
        private bool showTerms;
        private System.Drawing.Size size;
        private List<string> terms;
        private FormWindowState windowState;

        public int BookIndex
        {
            get
            {
                return this.bookIndex;
            }
            set
            {
                this.bookIndex = value;
            }
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

        public MatchingMultiWordBook Mmwb
        {
            get
            {
                return this.mmwb;
            }
            set
            {
                this.mmwb = value;
            }
        }

        public bool ShowFootnotes
        {
            get
            {
                return this.showFootnotes;
            }
            set
            {
                this.showFootnotes = value;
            }
        }

        public bool ShowTerms
        {
            get
            {
                return this.showTerms;
            }
            set
            {
                this.showTerms = value;
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

        public List<string> Terms
        {
            get
            {
                return this.terms;
            }
            set
            {
                this.terms = value;
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

