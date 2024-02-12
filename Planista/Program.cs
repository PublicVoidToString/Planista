using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization.Configuration;

namespace Planista
{
    public static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Engine.AssignHours(0);
            ///
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Engine.LoadClasses(); //Adds classes, must be between SetCompatibleTextRendereing to avoid error, and before Run so it has time to load
            Data.menu = new MainMenu();
            Application.Run(Data.menu);
            //*/
        }
    }//END OF PROGRAM
}
