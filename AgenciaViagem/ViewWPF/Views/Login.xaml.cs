using Controllers;
using Models.DAL;
using Models.Entities;
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
using ViewWPF.ViewModels;
using ViewWPF.Views.Administrador;

namespace ViewWPF.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        readonly static UsuarioController controller = new UsuarioController();

        public Login()
        {
            InitializeComponent();
            DataContext = new UsuarioViewModel();
            cadeado.Source = new BitmapImage(new Uri(@"/Assets/login.png", UriKind.Relative));
        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ButtonFechar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonLogin1_Click(object sender, RoutedEventArgs e)
        {
            UsuarioViewModel uvm = DataContext as UsuarioViewModel;
            uvm.Password = campoPass.Password;
            lblError.Content = "";
            lblError.SetCurrentValue(ForegroundProperty, Brushes.Red);
            if (controller.AutenticarUsuario(uvm.User, uvm.Password))
            {
                Usuario user = controller.BuscarUsuarioPorNome(uvm.User);
                if (user.Administrador)
                {
                    MainAdmin admin = new MainAdmin();
                    this.Visibility = Visibility.Hidden;
                    admin.Show();
                }
                else
                {
                    MainWindow objMainWindow = new MainWindow();
                    this.Visibility = Visibility.Hidden;
                    objMainWindow.Show();
                }
            }
            else
            {
                lblError.Content = "Usuário/Senha incorreto(s) ou Usuário Desativado!";
            }
            
        }

        private void ButtonCadastrar_Click(object sender, RoutedEventArgs e)
        {
            Cadastro objCadastro = new Cadastro();
            this.Visibility = Visibility.Hidden;
            objCadastro.Show();
        }
    }
}
