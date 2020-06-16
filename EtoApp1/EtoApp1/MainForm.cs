using Eto.Forms;
using Eto.Drawing;
using System.Collections.ObjectModel;

namespace EtoApp1
{

    class tempPOCO
	{
		public string currentTemp;
		public string count;
		public string newTemp;
	};

	public partial class MainForm : Form
    {
        public MainForm()
        {
			ClientSize = new Size(800, 525);
			Title = "Cube3Editor";


			var printerModel = new TableLayout
			{
				Spacing = new Size(5, 5), // space between each cell
				Padding = new Padding(10, 10, 10, 10), // space around the table's sides
				Rows =
				{
					new TableRow(
						new TableCell( new Label {Text="Printer Model:", TextAlignment=TextAlignment.Right }, true),
						new TableCell(MainFormControls.cbPrinterModel, true)
						),
					new TableRow(
						new TableCell( new Label {Text="Firmware:", TextAlignment=TextAlignment.Right }, true),
						new TableCell(MainFormControls.cbFirmwareVersion, true)
						),
					new TableRow(
						new TableCell( new Label {Text="MinFirmware:", TextAlignment=TextAlignment.Right }, true),
						new TableCell(MainFormControls.cbMinFirmwareVersion, true)
						),
					//new TableRow { ScaleHeight = true }
				}
			};

			var leftExtruder = new TableLayout
			{
				Spacing = new Size(5, 5), // space between each cell
				Padding = new Padding(10, 10, 10, 10), // space around the table's sides
				Rows =
				{
					new TableRow(
						new TableCell( new Label {Text="Material Type:", TextAlignment=TextAlignment.Right }, true),
						new TableCell(new ComboBox(), true)
						),
					new TableRow(
						new TableCell( new Label {Text="Material Color:", TextAlignment=TextAlignment.Right }, true),
						new TableCell(new ComboBox(), true)
						),
					new TableRow(
						new TableCell( new CheckBox {Checked=false, Text="Sidewalks" }, true),
						new TableCell(new CheckBox {Checked=false, Text="Support"}, true)
						),
					//new TableRow { ScaleHeight = true }
				}
			};

			var rightExtruder = new TableLayout
			{
				Spacing = new Size(5, 5), // space between each cell
				Padding = new Padding(10, 10, 10, 10), // space around the table's sides
				Rows =
				{
					new TableRow(
						new TableCell( new Label {Text="Material Type:", TextAlignment=TextAlignment.Right}, true),
						new TableCell(new ComboBox(), true)
						),
					new TableRow(
						new TableCell( new Label {Text="Material Color:", TextAlignment=TextAlignment.Right }, true),
						new TableCell(new ComboBox(), true)
						),
					new TableRow(
						new TableCell( new CheckBox {Checked=false, Text="Sidewalks" }, true),
						new TableCell(new CheckBox {Checked=false, Text="Support"}, true)
						),
					new TableRow { ScaleHeight = true }
				}
			};

			var midExtruder = new TableLayout
			{
				Spacing = new Size(5, 5), // space between each cell
				Padding = new Padding(10, 10, 10, 10), // space around the table's sides
				Rows =
				{
					new TableRow(
						new TableCell( new Label {Text="Material Type:", TextAlignment=TextAlignment.Right}, true),
						new TableCell(new ComboBox(), true)
						),
					new TableRow(
						new TableCell( new Label {Text="Material Color:", TextAlignment=TextAlignment.Right }, true),
						new TableCell(new ComboBox(), true)
						),
					new TableRow(
						new TableCell( new CheckBox {Checked=false, Text="Sidewalks" }, true),
						new TableCell(new CheckBox {Checked=false, Text="Support"}, true)
						),
					//new TableRow { ScaleHeight = true }
				}
			};

			var leftTempGrid = CreateTempGrid();
			var leftTempUpdateBtn = new Button { Text = "Update" };
			var leftTempTable = new TableLayout
			{
				Spacing = new Size(5, 5), // space between each cell
				Padding = new Padding(10, 10, 10, 10), // space around the table's sides
				Rows =
				{
					new TableRow(
						new TableCell(leftTempGrid, true)),
					new TableRow(
						new TableCell(leftTempUpdateBtn)),
					new TableRow{ScaleHeight = true}
				}
			};

			var rightTempGrid = CreateTempGrid();
			var rightTempUpdateBtn = new Button { Text = "Update" };
			var rightTempTable = new TableLayout
			{
				Spacing = new Size(5, 5), // space between each cell
				Padding = new Padding(10, 10, 10, 10), // space around the table's sides
				Rows =
				{
					new TableRow(
						new TableCell(rightTempGrid, true)),
					new TableRow(
						new TableCell(rightTempUpdateBtn)),
					new TableRow{ScaleHeight = true}
				}
			};

			var leftTempGroup = new GroupBox { Text = "Left Extruder", Content = leftTempTable};
			var rightTempGroup = new GroupBox { Text = "Right Extruder", Content = rightTempTable };

			var tempTable = new TableLayout
			{
				Spacing = new Size(5, 5), // space between each cell
				Padding = new Padding(10, 10, 10, 10), // space around the table's sides
				Rows =
				{
					new TableRow(
						new TableCell(leftTempGroup, true),
						new TableCell(rightTempGroup, true)),
					new TableRow{ScaleHeight=true}

				}
			};

			var tempTab = new TabPage
			{
				Text = "Temperature Control",
				Content = tempTable
			};

			var extrusionTab = new TabPage
			{
				Text = "Extrusion Control"
			};

			var retractionTab = new TabPage
			{
				Text = "Retraction Control"
			};

			var tabs = new TabControl();
			tabs.Pages.Add(tempTab);
			tabs.Pages.Add(extrusionTab);
			tabs.Pages.Add(retractionTab);

			var leftSide = new TableLayout
			{
				Spacing = new Size(5, 5), // space between each cell
				Padding = new Padding(10, 10, 10, 10), // space around the table's sides
				Rows =
                {
					new TableRow( 
						new TableCell (
							new GroupBox {Content = printerModel } 
							)
						),
					new TableRow(
						new TableCell (
							new GroupBox {Content = leftExtruder, Text = "Left Extruder (E1)" }
							)
						),
					new TableRow(
						new TableCell (
							new GroupBox {Content = midExtruder, Text = "Mid Extruder (E3)" }
							)
						),
					new TableRow(
						new TableCell (
							new GroupBox {Content = rightExtruder, Text = "Right Extruder (E2)"}
							)
						),
				}

			};
			var editorLayout = new DynamicLayout
			{
				Size = new Size(5, 5),
				Rows =
				{
					new DynamicRow(leftSide, tabs),
				},
			};


			Content = editorLayout;
		}

        private GridView CreateTempGrid()
        {
			GridView gv = new GridView { DataStore = new ObservableCollection<tempPOCO>() };
			gv.Columns.Add(new GridColumn
			{
				DataCell = new TextBoxCell
				{
					Binding = Binding.Property<tempPOCO, string>(r => r.currentTemp),
				},
				HeaderText = "Temp"
			});
			gv.Columns.Add(new GridColumn
			{
				DataCell = new TextBoxCell
				{
					Binding = Binding.Property<tempPOCO, string>(r => r.count),
				},
				HeaderText = "Count"
			});
			gv.Columns.Add(new GridColumn
			{
				DataCell = new TextBoxCell
				{
					Binding = Binding.Property<tempPOCO, string>(r => r.newTemp),
				},
				HeaderText = "Modifier"
			});

			return gv;
		}
    }

}
