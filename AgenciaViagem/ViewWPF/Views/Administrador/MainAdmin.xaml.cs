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

namespace ViewWPF.Views.Administrador
{
    /// <summary>
    /// Interaction logic for Index.xaml
    /// </summary>
    public partial class MainAdmin : Window
    {
        public MainAdmin()
        {
            InitializeComponent();
            GridPrincipalAdm.Children.Add(new UsuarioList());
        }
        private void GridAdm_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ButtonFecharAdm_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void ListViewMenuAdm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenuAdm.SelectedIndex;
            MoveCursorMenuAdm(index);

            switch (index)
            {
                case 0:
                    GridPrincipalAdm.Children.Clear();
                    GridPrincipalAdm.Children.Add(new UsuarioList());
                    break;
                case 1:
                    GridPrincipalAdm.Children.Clear();
                    GridPrincipalAdm.Children.Add(new EmpresaAereaCadastro());
                    
                    break;
                case 3:
                    GridPrincipalAdm.Children.Clear();
                    GridPrincipalAdm.Children.Add(new QuartoList());
                    break;
                case 4:
                    GridPrincipalAdm.Children.Clear();
                    GridPrincipalAdm.Children.Add(new PacotesList());
                    break;
                case 5:
                    GridPrincipalAdm.Children.Clear();
                    GridPrincipalAdm.Children.Add(new EmpresaAereaCadastro());
                    break;
                default:
                    break;
            }

        }

        private void MoveCursorMenuAdm(int index)
        {
            TrainsitionigContetSlideAdm.OnApplyTemplate();
            GridCursorAdm.Margin = new Thickness(0, (10 + (60 * index)), 0, 0);
        }

        private void ButtonLogoutAdm_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Login login = new Login();
            login.Show();
        }
    }
}