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
        public void OnUpdate(object sender, RoutedEventArgs e)
        {
            foreach (Usuario item in dgUsuarios.Items)
            {
                controller.EditarUsuario(item);
                lblMessage.Content = "Usuários Atualizados!";
            }
            Timer timer = new Timer(3000);
            timer.Elapsed += limpaLabel;
            timer.AutoReset = false;
            timer.Start();

        }

        private void limpaLabel(object sender, ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                lblMessage.Content = "";
            });
        }
    }
}