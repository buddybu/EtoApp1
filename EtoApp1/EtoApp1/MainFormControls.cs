using Eto.Forms;
using System;
using System.Collections.Generic;
using System.Text;

namespace EtoApp1
{
    public static class MainFormControls
    {
        public static ComboBox cbPrinterModel = new ComboBox { Items = { "Cube3", "Ekocycle", "CubePro" } };
        public static ComboBox cbFirmwareVersion = new ComboBox { Items = { "V1.14B", "V1.05", "V1.87" } };
        public static ComboBox cbMinFirmwareVersion = new ComboBox { Items = { "V1.14B", "V1.05", "V1.87" } };
    }
}
