﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace dEVEOre
{
    static class Program
    {
        // Naming and Versioning
        public static String    PROGRAM_NAME = "dEVEOre";
        public static int       PROGRAM_VERSION = 1;
        public static int       PROGRAM_VERSION_NEWFEATURE = 0;
        public static int       PROGRAM_VERSION_BUG = 1;

        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
