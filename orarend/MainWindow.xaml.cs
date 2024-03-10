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
        
        List<Osztaly> osz = new List<Osztaly>();
        Osztaly A = new Osztaly("12A", new List<Nap>( ));
        Osztaly B = new Osztaly("12B", new List<Nap>());
        Osztaly C = new Osztaly("12C", new List<Nap>());
        utility utility = new utility();
      
        public MainWindow()
        {
            InitializeComponent();
            betöltés();
        }
        public void betöltés()
        {
            A.OraszamMegadas();
            B.OraszamMegadas();
            C.OraszamMegadas();
            utility.feltöltés(A);
            utility.feltöltés(B);
            utility.feltöltés(C);
            Console.WriteLine("A");
            foreach (Nap k in A.Orarend)
            {
                
                foreach (var t in k.Orak)
                {
                    
                    Console.WriteLine(t);
                }
                Console.WriteLine("______");
            }
            Console.WriteLine("B");
            foreach (Nap k in B.Orarend)
            {

                foreach (var t in k.Orak)
                {

                    Console.WriteLine(t);
                }
                Console.WriteLine("______");
            }
            Console.WriteLine("c");
            foreach (Nap k in C.Orarend)
            {

                foreach (var t in k.Orak)
                {

                    Console.WriteLine(t);
                }
                Console.WriteLine("______");
            }
        }
        
    }
}
