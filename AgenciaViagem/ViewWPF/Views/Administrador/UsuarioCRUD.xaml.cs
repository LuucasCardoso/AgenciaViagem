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
    public partial class UsuarioCRUD : UserControl
    {
        readonly static UsuarioController controller = new UsuarioController();


        public UsuarioCRUD()
        {
            InitializeComponent();
            DataContext = new UsuarioViewModel();

        }
        private void OnSave(object sender, RoutedEventArgs e)
        {
            Timer timer = new Timer(3000);
            UsuarioViewModel uvm = DataContext as UsuarioViewModel;
            Usuario usuario = new Usuario
            {
                UsuarioId = uvm.UsuarioId,
                Nome = uvm.Nome,
                Email = uvm.Email,
                Password = uvm.Password,
                User = uvm.User,
                Cpf = uvm.Cpf,
                Telefone = uvm.Telefone,
                Administrador = uvm.Administrador,
                Ativo = true
            };
            try
            {
                if (usuario.Nome == null || usuario.Nome.Length < 3)
                {
                    throw new Exception("Nome deve ter no mínimo 3 caracteres!");
                }
                if (usuario.User == null || usuario.User.Length < 4)
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
                if (usuario.Password == null || usuario.Password.Length < 4)
                {
                    throw new Exception("Senha deve ter no mínimo 4 caracteres!");
                }
                if (usuario.UsuarioId == 0)
                {
                    controller.CadastrarUsuario(usuario);
                    lblMessage.Content = "Usuário Criado!";
                }
                else
                {
                    controller.EditarUsuario(usuario);
                    lblMessage.Content = "Usuário Atualizado!";
                }
                timer.Elapsed += LimpaLabel;
                timer.AutoReset = false;
                timer.Start();
                dgUsuarios.DataContext = new UsuarioViewModel();
                GridCadastroEditUsuario.Visibility = Visibility.Collapsed;
                GridListarUsuario.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                lblMessageCadastroUsuario.Content = ex.Message;
                lblMessageCadastroUsuario.Visibility = Visibility.Visible;
            }
        }
    
        private void LimpaLabel(object sender, ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                lblMessage.Content = "";
                lblMessageCadastroUsuario.Content = "";
            });
        }

        private void CallSave(object sender, RoutedEventArgs e)
        {
            lblMessageCadastroUsuario.Visibility = Visibility.Collapsed;
            Button button = (Button)sender;
            if (button.Name == "cadButton")
            {
                DataContext = new UsuarioViewModel();
            }
            else
            {
                Usuario u = (Usuario)dgUsuarios.CurrentItem;
                DataContext = new UsuarioViewModel
                {
                    UsuarioId = u.UsuarioId,
                    Nome = u.Nome,
                    Email = u.Email,
                    Password = u.Password,
                    User = u.User,
                    Cpf = u.Cpf,
                    Telefone = u.Telefone,
                    Administrador = u.Administrador,
                    Ativo = u.Ativo
                };
            }
            GridListarUsuario.Visibility = Visibility.Collapsed;
            GridCadastroEditUsuario.Visibility = Visibility.Visible;
        }
        private void SaveBack(object sender, RoutedEventArgs e)
        {
            GridCadastroEditUsuario.Visibility = Visibility.Collapsed;
            GridListarUsuario.Visibility = Visibility.Visible;
        }
    }
}
