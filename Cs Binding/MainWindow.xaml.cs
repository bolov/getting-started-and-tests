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
 * Most online turorials create an object in xaml
 * This shows how to bind to an object created in the code
 *
 * https://stackoverflow.com/questions/19981966/wpf-xaml-binding-to-object-created-in-code-behind
 */

namespace Cs_Binding
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Source of the binding
        /// must be a property (as oposed to a field) for the binding to work
        /// </summary>
        public Person Person1 { get; set; } = new Person("Nobody1");

        public MainWindow()
        {
            this.DataContext = this;

            InitializeComponent();

            ConsoleAllocator.ShowIfDebug();

            TextWriterTraceListener myWriter = new TextWriterTraceListener(System.Console.Out);
            Debug.Listeners.Add(myWriter);

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

        private void Change1Button(object sender, RoutedEventArgs e)
        {
            string txt = String.Format("Person1 {0}", RandomString(3));

            Person1.PersonName = txt;

            Debug.WriteLine(Person1.PersonName);
        }
    }
}
