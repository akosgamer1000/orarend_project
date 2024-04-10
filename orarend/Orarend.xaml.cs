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

        public string Valasztas { get; set; }

        Osztaly A = new Osztaly("12A", new List<Nap>());
        Osztaly B = new Osztaly("12B", new List<Nap>());
        Osztaly C = new Osztaly("12C", new List<Nap>());
        utility utility = new utility();
      
        private string Choice;
        Grid grid = new Grid
        {
            Height = 300,
            Width = 600,

        };

        public Orarend(string choice) : base()
		{
			InitializeComponent();
            Choice = choice;
            Betöltés();
			GridBetoltes();
            OrarendBetoltese();
		}


      

      

        public void Betöltés()
        {
            A.OraszamMegadas();
            B.OraszamMegadas();
            C.OraszamMegadas();
            utility.váltás(A, B, C);
        }

        void GridBetoltes()
        {
         

            for (int i = 0; i < 8; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());

            }
            for (int j = 0; j < 5; j++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }

         


            Content = grid;
        }

        void OrarendBetoltese()
        {
            int columnCount = 5;
           

            switch (Choice)
            {
                case "12A":
                    
                    foreach (Nap k in A.Orarend)
                    {

                        foreach (var t in k.Orak)
                        {
                            TextBlock tb = new TextBlock
                            {
                                Text = t.TantargyNev
                            };
                            int rowIndex = grid.Children.Count / columnCount;
                            int columnIndex = grid.Children.Count % columnCount;
                         
                            Grid.SetRow(tb, rowIndex);
                            Grid.SetColumn(tb, columnIndex);
                            Border border = new Border();
                            border.BorderBrush = Brushes.Black; 
                            border.BorderThickness = new Thickness(1);
                            border.Child = tb;
                            Grid.SetRow(border, rowIndex);
                            Grid.SetColumn(border, columnIndex);
                            grid.Children.Add(border);

                        }
                    }
                    break;
                case "12B":

                    foreach (Nap k in B.Orarend)
                    {

                        foreach (var t in k.Orak)
                        {
                            TextBlock tb = new TextBlock
                            {
                                Text = t.TantargyNev
                            };
                            int rowIndex = grid.Children.Count / columnCount;
                            int columnIndex = grid.Children.Count % columnCount;
                            Grid.SetRow(tb, rowIndex);
                            Grid.SetColumn(tb, columnIndex);
                            Border border = new Border();
                            border.BorderBrush = Brushes.Black;
                            border.BorderThickness = new Thickness(1);
                            border.Child = tb;
                            Grid.SetRow(border, rowIndex);
                            Grid.SetColumn(border, columnIndex);
                            grid.Children.Add(border);
                        }
                    }
                    break;

                case "12C":

                    foreach (Nap k in C.Orarend)
                    {

                        foreach (var t in k.Orak)
                        {
                            TextBlock tb = new TextBlock
                            {
                                Text = t.TantargyNev
                            };
                            int rowIndex = grid.Children.Count / columnCount;
                            int columnIndex = grid.Children.Count % columnCount;
                            Grid.SetRow(tb, rowIndex);
                            Grid.SetColumn(tb, columnIndex);
                            Border border = new Border();
                            border.BorderBrush = Brushes.Black;
                            border.BorderThickness = new Thickness(1);
                            border.Child = tb;
                            Grid.SetRow(border, rowIndex);
                            Grid.SetColumn(border, columnIndex);
                            grid.Children.Add(border);
                        }
                    }
                    break;

                default:
                    break;
            }
             

           
        }

    }
}
