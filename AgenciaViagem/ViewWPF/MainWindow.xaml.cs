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
using ViewWPF.Views.Cliente;

namespace ViewWPF.Views
{
    /// <summary>
    /// Interaction logic for Index.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GridPrincipal.Children.Add(new UserControlInicio());
        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void ButtonFechar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Dispose()
        {
            throw new NotImplementedException();
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            MoveCursorMenu(index);

            switch (index)
            {
                case 0:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new UserControlInicio());
                    break;
                case 1:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new ListPassagens());
                    break;
                case 2:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new HotelListar());
                    break;
                case 3:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new PacotesList());
                    break;
                case 4:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new ListCarrinho());
                    break;
                    
                default:
                    break;
                }

        }

        private void MoveCursorMenu(int index)
        {
            TrainsitionigContetSlide.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, (10 + (60 * index)), 0, 0);
        }

        private void ButtonLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Login login = new Login();
            login.Show();
        }

        
    }
}
