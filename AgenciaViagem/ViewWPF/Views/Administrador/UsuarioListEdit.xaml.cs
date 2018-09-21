using Controllers;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViewWPF.ViewModels;

namespace ViewWPF.Views.Administrador
{
    /// <summary>
    /// Interação lógica para UsuarioListar.xam
    /// </summary>
    public partial class UsuarioListEdit : UserControl
    {
        readonly static UsuarioController controller = new UsuarioController();

        public UsuarioListEdit()
        {
            InitializeComponent();
            DataContext = new UsuarioViewModel();

        }
        private void OnUpdate(object sender, RoutedEventArgs e)
        {
            foreach (Usuario item in dgUsuarios.Items)
            {
                controller.EditarUsuario(item);
                lblMessage.Content = "Usuários Atualizados!";
            }
            Timer timer = new Timer(3000);
            timer.Elapsed += LimpaLabel;
            timer.AutoReset = false;
            timer.Start();

        }

        private void LimpaLabel(object sender, ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                lblMessage.Content = "";
            });
        }
        private void LimpaLabelCadastro(object sender, ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                lblMessageCadastroUsuario.Content = "";
            });
        }
        private void OnCreate(object sender, RoutedEventArgs e)
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
                Administrador = cvm.Administrador,
                Ativo = true
            };
            try
            {
                if (usuario.Nome == null || usuario.Nome.Length < 3)
                {
                    throw new Exception("Nome deve ter no mínimo 3 caracteres!");
                }
                if(usuario.User == null || usuario.User.Length < 4)
                {
                    throw new Exception("Usuário deve ter no mínimo 4 caracteres!");
                }
                if (usuario.Cpf == null || usuario.Cpf.Length != 11)
                {
                    throw new Exception("CPF deve ter 11 dígitos!");
                }
                if (usuario.Email == null || usuario.Email.Length < 4)
                {
                    throw new Exception("Email deve ter no mínimo 4 caracteres!");
                }
                if (usuario.Telefone == null || usuario.Telefone.Length < 12)
                {
                    throw new Exception("Telefone com código do país e regional!");
                }
                if(usuario.Password == null || usuario.Password.Length < 4)
                {
                    throw new Exception("Senha deve ter no mínimo 4 caracteres!");
                }

                controller.CadastrarUsuario(usuario);
                GridCadastroUsuario.Visibility = Visibility.Collapsed;
                GridListarEditarUsuario.Visibility = Visibility.Visible;
                dgUsuarios.DataContext = new UsuarioViewModel();
            }
            catch (Exception ex)
            {
                lblMessageCadastroUsuario.Content = ex.Message;
                Timer timer = new Timer(3000);
                timer.Elapsed += LimpaLabelCadastro;
                timer.AutoReset = false;
                timer.Start();
            }
        }
        private void CallCreate(object sender, RoutedEventArgs e)
        {
            GridListarEditarUsuario.Visibility = Visibility.Collapsed;
            GridCadastroUsuario.Visibility = Visibility.Visible;
        }
        private void CreateBack(object sender, RoutedEventArgs e)
        {
            GridCadastroUsuario.Visibility = Visibility.Collapsed;
            GridListarEditarUsuario.Visibility = Visibility.Visible;
        }
    }
}
