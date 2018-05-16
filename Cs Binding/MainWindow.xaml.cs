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
        public Person ThePerson { get; set; } = new Person("Nobody");

        private int n = 0;

        public MainWindow()
        {
            this.DataContext = this;

            InitializeComponent();

            ConsoleAllocator.ShowIfDebug();

            TextWriterTraceListener myWriter = new TextWriterTraceListener(System.Console.Out);
            Debug.Listeners.Add(myWriter);

        }

        private void ChangeButtonClick(object sender, RoutedEventArgs e)
        {
            string txt = String.Format("Person {0}", n);
            ++n;

            ThePerson.PersonName = txt;

            Debug.WriteLine(ThePerson.PersonName);
        }
    }
}
