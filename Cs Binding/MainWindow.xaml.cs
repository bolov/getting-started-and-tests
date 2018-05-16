using System;
using System.Collections.Generic;
using System.Diagnostics;
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


/*
 * (1) object created in code
 * (2) object created in XAML resources
 */

namespace Cs_Binding
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// source for (1) object created in code
        /// must be a property (as oposed to a field) for the binding to work
        /// </summary>
        public Person Person1 { get; set; } = new Person("Nobody1");

        /// <summary>
        /// reference to (2) object created in XAML resources
        /// </summary>
        private Person Person2;


        /// <summary>
        /// reference to (3) object created in XAML context
        /// </summary>
        private Person Person3;

        public MainWindow()
        {

            // needed for (1)
            this.DataContext = this;

            InitializeComponent();

            // (2) get the object in XAML resources
            Person2 = FindResource("Person2") as Person;

            // (3) get the object in XAML context
            Person3 = (FindName("Person3Text") as TextBlock).DataContext as Person;

            ConsoleAllocator.ShowIfDebug();

            TextWriterTraceListener myWriter = new TextWriterTraceListener(System.Console.Out);
            Debug.Listeners.Add(myWriter);
        }

        // (1)
        private void Change1ButtonClick(object sender, RoutedEventArgs e)
        {
            string txt = String.Format("Person1 {0}", RandomString(3));

            Person1.PersonName = txt;
        }


        // (2)
        private void Change2ButtonClick(object sender, RoutedEventArgs e)
        {
            string txt = String.Format("Person2 {0}", RandomString(3));

            Person2.PersonName = txt;
        }

        // (3)
        private void Change3ButtonClick(object sender, RoutedEventArgs e)
        {
            string txt = String.Format("Person3 {0}", RandomString(3));

            Person3.PersonName = txt;
        }

        private string RandomString(int length)
        {
            string s = "";
            Random r = new Random();

            for (int i = 0; i < length; ++i)
            {
                s += (char)('a' + r.Next('z' - 'a'));
            }
            return s;
        }

    }
}
