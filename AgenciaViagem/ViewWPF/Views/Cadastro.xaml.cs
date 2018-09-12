using Controllers;
using Models.Entities;
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
using System.Windows.Shapes;
using ViewWPF.ViewModels;

namespace ViewWPF.Views
{
    /// <summary>
    /// Lógica interna para Cadastro.xaml
    /// </summary>
    public partial class Cadastro : Window
    {
        public Cadastro()
        {
            InitializeComponent();
            DataContext = new UsuarioViewModel();
        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ButtonFechar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonCadastrar_Click(object sender, RoutedEventArgs e)
        {
            UsuarioViewModel cvm = DataContext as UsuarioViewModel;
            cvm.Password = passBox.Password;
            UsuarioController controller = new UsuarioController();
            Usuario usuario = new Usuario
            {
                Nome = cvm.Nome,
                Email = cvm.Email,
                Password = cvm.Password,
                User = cvm.User,
                Cpf = cvm.Cpf,
                Telefone = cvm.Telefone,
                Administrador = false,
                Ativo = true
            };
            controller.CadastroUsuario(usuario);
            Login objLogin= new Login();
            this.Visibility = Visibility.Hidden;
            objLogin.Show();
            objLogin.lblError.SetCurrentValue(ForegroundProperty, Brushes.Green);
            objLogin.lblError.Content = "Usuario criado com Sucesso!";
        }
    }
}
