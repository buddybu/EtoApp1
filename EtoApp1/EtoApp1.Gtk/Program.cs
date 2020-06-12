using System;
using Eto.Forms;

namespace EtoApp1.Gtk
{
    class MainClass
    {
        [STAThread]
        public static void Main(string[] args)
        {
            new Application(Eto.Platforms.Gtk).Run(new MainForm());
        }
    }
}
