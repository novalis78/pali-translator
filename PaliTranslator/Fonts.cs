namespace PaliTranslator
{
    using CST.Conversion;
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    public static class Fonts
    {
        private static Dictionary<Script, float> controlFontSizes = new Dictionary<Script, float>();
        private static Dictionary<Script, string> faces = new Dictionary<Script, string>();
        private static CST.WindowsVersion windowsVersion;

        static Fonts()
        {
            faces[Script.Bengali] = "Vrinda";
            controlFontSizes[Script.Bengali] = 14f;
            faces[Script.Cyrillic] = "Doulos SIL";
            controlFontSizes[Script.Cyrillic] = 10f;
            faces[Script.Devanagari] = "CDAC-GISTSurekh";
            controlFontSizes[Script.Devanagari] = 10f;
            faces[Script.Gujarati] = "Shruti";
            faces[Script.Gurmukhi] = "Raavi";
            faces[Script.Kannada] = "Tunga";
            faces[Script.Khmer] = "Khmer Mondulkiri U OT ls";
            controlFontSizes[Script.Khmer] = 15f;
            faces[Script.Latin] = "Microsoft Sans Serif";
            faces[Script.Malayalam] = "Kartika";
            faces[Script.Myanmar] = "Myanmar1";
            controlFontSizes[Script.Myanmar] = 12f;
            faces[Script.Sinhala] = "KaputaUnicode";
            controlFontSizes[Script.Sinhala] = 13f;
            faces[Script.Telugu] = "Gautami";
            faces[Script.Thai] = "Microsoft Sans Serif";
            faces[Script.Tibetan] = "Tibetan Machine Uni";
            controlFontSizes[Script.Tibetan] = 12f;
        }

        public static Font GetControlFont(Script script)
        {
            string familyName = "Microsoft Sans Serif";
            if (faces.ContainsKey(script))
            {
                familyName = faces[script];
            }
            float emSize = 9.75f;
            if (controlFontSizes.ContainsKey(script))
            {
                emSize = controlFontSizes[script];
            }
            return new Font(familyName, emSize);
        }

        public static Font GetListBoxFont(Script script)
        {
            return GetControlFont(script);
        }

        public static Script GetWindowsSafeScript(Script script)
        {
            if (WindowsVersion == CST.WindowsVersion.XP)
            {
                if (((((script == Script.Bengali) || (script == Script.Cyrillic)) || ((script == Script.Khmer) || (script == Script.Myanmar))) || (script == Script.Sinhala)) || (script == Script.Tibetan))
                {
                    return Script.Latin;
                }
                return script;
            }
            return script;
        }

        private static CST.WindowsVersion GetWindowsVersion()
        {
            CST.WindowsVersion unknown = CST.WindowsVersion.Unknown;
            Version version = Environment.OSVersion.Version;
            if (version.Major < 5)
            {
                return CST.WindowsVersion.PreXP;
            }
            if (version.Major == 5)
            {
                if (version.Minor == 0)
                {
                    return CST.WindowsVersion.PreXP;
                }
                return CST.WindowsVersion.XP;
            }
            if (version.Major == 6)
            {
                if (version.Minor == 0)
                {
                    return CST.WindowsVersion.Vista;
                }
                return CST.WindowsVersion.PostVista;
            }
            if (version.Major > 6)
            {
                unknown = CST.WindowsVersion.PostVista;
            }
            return unknown;
        }

        public static CST.WindowsVersion WindowsVersion
        {
            get
            {
                if (windowsVersion == CST.WindowsVersion.Unknown)
                {
                    windowsVersion = GetWindowsVersion();
                }
                return windowsVersion;
            }
        }
    }
}

