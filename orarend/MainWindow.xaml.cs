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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace orarend
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// <
    public partial class MainWindow : Window
    {
    

      

        public MainWindow()
        {
            InitializeComponent();
            betöltés();
        }


        public void betöltés()
        {
           
            osztalyokbox.Items.Add("12A");
			osztalyokbox.Items.Add("12B");
			osztalyokbox.Items.Add("12C");
            osztalyokbox.SelectedIndex = 0;

	
		}

        public void Button_Click(object sender, RoutedEventArgs e)
        {

            Orarend orarend = new Orarend(osztalyokbox.SelectedItem.ToString());
            orarend.Show();
        }
   
	
        
    }
}
