using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace orarend
{
	/// <summary>
	/// Interaction logic for Orarend.xaml
	/// </summary>
	public partial class Orarend : Window
	{
		public Orarend()
		{
			InitializeComponent();
			GridBetoltes();
		}
		void GridBetoltes()
		{
			grid.ShowGridLines = true;
		for (int i = 0; i < 5; i++) 
			{
				grid.RowDefinitions.Add(new RowDefinition());
			
			}
			for (int j = 0; j < 8; j++)
			{
				grid.ColumnDefinitions.Add(new ColumnDefinition());
			}
		}
		
	}
}
