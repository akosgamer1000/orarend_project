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
            Choice = choice;
			InitializeComponent();
            Betöltés();
			GridBetoltes();
            OrarendBetoltese();
            IdopontEsNapokJelzese();
		}


      

      

        public void Betöltés()
        {
            A.OraszamMegadas();
            B.OraszamMegadas();
            C.OraszamMegadas();
            utility.feltöltés(A);
            utility.feltöltés(B);
            utility.feltöltés(C);
        }

        void GridBetoltes()
        {
         

            for (int i = 0; i < 8; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());

            }
            for (int j = 0; j < 6; j++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            Grid.SetRow(grid, 1);
            MainGrid.Children.Add(grid);
            osztalyNev.Text = Choice;
            
           

        }

        void IdopontEsNapokJelzese()
        {

            List<string> ids = new List<string>
            {
                "Hétfő",
                "Kedd",
                "Szerda",
                "Csütörtök",
                "Péntek"
            };
            for (int i = 0; i < 5;i++)
            {
				TextBlock tb = new TextBlock()
				{
					TextAlignment = TextAlignment.Center,
					VerticalAlignment = VerticalAlignment.Center
				};
				tb.Inlines.Add(new Bold(new Run(ids[i])));

				int rowIndex = 0;

				int columnIndex = i+1;
				Grid.SetRow(tb, rowIndex);
				Grid.SetColumn(tb, columnIndex);
				Border border = new Border
				{
					BorderBrush = Brushes.Black,
					BorderThickness = new Thickness(1),
					Child = tb
				};
				Grid.SetRow(border, rowIndex);
				Grid.SetColumn(border, columnIndex);
				grid.Children.Add(border);
			}

            List<string> orak = new List<string>
            {
                "8.00-8.45",
                "8.55-9.40",
                "9.55-10.40",
                "10.50-11.35",
                "11.45-12.30",
                "12.50-13.35",
                "13.45-14.30",
                "14.35-15.10"
            };
            for (int i = 0; i < 5; i++)
            {
                TextBlock tb = new TextBlock()
                {
                    TextAlignment = TextAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };
                tb.Inlines.Add(new Bold(new Run(orak[i])));

                int rowIndex = i+1;

                int columnIndex = 0;
                Grid.SetRow(tb, rowIndex);
                Grid.SetColumn(tb, columnIndex);
                Border border = new Border
                {
                    BorderBrush = Brushes.Black,
                    BorderThickness = new Thickness(1),
                    Child = tb
                };
                Grid.SetRow(border, rowIndex);
                Grid.SetColumn(border, columnIndex);
                grid.Children.Add(border);
            }


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
                                TextAlignment = TextAlignment.Center,
                                VerticalAlignment = VerticalAlignment.Center,
                                Text = t.TantargyNev
                            };

                            int clickCount = 0;
                            tb.MouseLeftButtonDown += (sender, e) =>
                            {
                                clickCount++;
                                switch (clickCount)
                                {
                                    case 1:
                                        tb.Text = t.Terem.Name;
                                        break;
                                    case 2:
                                        tb.Text = t.Tanar;
                                        break;
                                    case 3:
                                        tb.Text = t.TantargyNev;
                                        clickCount = 0;
                                        break;
                                }
                            };


                            int rowIndex = grid.Children.Count / columnCount + 1;
                            int columnIndex = grid.Children.Count % columnCount + 1;
                            Grid.SetRow(tb, rowIndex);
                            Grid.SetColumn(tb, columnIndex);

                            Border border = new Border
                            {
                                BorderBrush = Brushes.Black,
                                BorderThickness = new Thickness(1),
                                Child = tb
                            };
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
                                TextAlignment = TextAlignment.Center,
                                VerticalAlignment = VerticalAlignment.Center,
                                Text = t.TantargyNev
                            };

                            int clickCount = 0;

                            tb.MouseLeftButtonDown += (sender, e) =>
                            {
                                clickCount++;   
                                switch (clickCount)
                                {
                                    case 1:
                                        tb.Text = t.Terem.Name;
                                        break;
                                    case 2:
                                        tb.Text = t.Tanar;
                                        break;
                                    case 3:
                                        tb.Text = t.TantargyNev;
                                        clickCount = 0;
                                        break;
                                }
                            };


                            int rowIndex = grid.Children.Count / columnCount + 1;
                            int columnIndex = grid.Children.Count % columnCount + 1;
                            Grid.SetRow(tb, rowIndex);
                            Grid.SetColumn(tb, columnIndex);

                            Border border = new Border
                            {
                                BorderBrush = Brushes.Black,
                                BorderThickness = new Thickness(1),
                                Child = tb
                            };
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
                                TextAlignment = TextAlignment.Center,
                                VerticalAlignment = VerticalAlignment.Center,
                                Text = t.TantargyNev
                            };

                            int clickCount = 0;
                            tb.MouseLeftButtonDown += (sender, e) =>
                            {
                                clickCount++;
                                switch (clickCount)
                                {
                                    case 1:
                                        tb.Text = t.Terem.Name;
                                        break;
                                    case 2:
                                        tb.Text = t.Tanar;
                                        break;
                                    case 3:
                                        tb.Text = t.TantargyNev;
                                        clickCount = 0;
                                        break;
                                }
                            };


                            int rowIndex = grid.Children.Count / columnCount + 1;
                            int columnIndex = grid.Children.Count % columnCount + 1;
                            Grid.SetRow(tb, rowIndex);
                            Grid.SetColumn(tb, columnIndex);

                            Border border = new Border
                            {
                                BorderBrush = Brushes.Black,
                                BorderThickness = new Thickness(1),
                                Child = tb
                            };
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
