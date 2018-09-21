using Controllers;
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
            List<Usuario> lista = new List<Usuario>();
            foreach(var item in dgUsuarios.Items)
            {
                lista.Add((Usuario)item);
            }
            UsuarioViewModel uvm = DataContext as UsuarioViewModel;
            foreach(var item in lista)
            {
                uvm.UsuarioId = item.UsuarioId;
                uvm.Nome = item.Nome;
                uvm.User = item.User;
                uvm.Telefone = item.Telefone;
                uvm.Email = item.Email;
                uvm.Cpf = item.Cpf;
                uvm.Ativo = item.Ativo;
                uvm.Administrador = item.Administrador;
                uvm.Password = item.Password;
                Usuario usuarioDB = new Usuario
                {
                    UsuarioId = uvm.UsuarioId,
                    Nome = uvm.Nome,
                    User = uvm.User,
                    Telefone = uvm.Telefone,
                    Email = uvm.Email,
                    Cpf = uvm.Cpf,
                    Password = uvm.Password,
                    Administrador = uvm.Administrador,
                    Ativo = uvm.Ativo
                };
                controller.EditarUsuario(usuarioDB);
            DataContext = new UsuarioViewModel();
            }
            dgUsuarios.DataContext = new UsuarioViewModel();
        }
    }
}