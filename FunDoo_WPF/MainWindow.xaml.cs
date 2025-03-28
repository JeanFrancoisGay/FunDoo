using FunDoo_WPF.ViewModels;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FunDoo_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ToDoViewModel vm;

        public MainWindow()
        {
            InitializeComponent();
            vm = new ToDoViewModel();
            base.DataContext = vm;
        }
    }
}