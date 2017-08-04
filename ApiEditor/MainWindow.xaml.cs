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

namespace ApiEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnCreateParameter(object sender, RoutedEventArgs e)
        {

        }

        private void OnCreateSingleService(object sender, RoutedEventArgs e)
        {

        }

        private void OnCreatePagedService(object sender, RoutedEventArgs e)
        {

        }

        private void OnParameterChanged(object sender,RoutedEventArgs e)
        {
            this.parameterInterface.Text = "I" + operation.Text + "Service" + " SetParameter" + this.parmeterName + "(string " + this.parmeterName + ");";
        }
    }
}
