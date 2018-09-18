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
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Window
    {
        public Page1()
        {
            InitializeComponent();
            DataContext = new EmpresaAereaViewModel();
        }

        private void cadEmpresaAerea_Click(object sender, RoutedEventArgs e)
        {
            EmpresaAereaViewModel cvm = DataContext as EmpresaAereaViewModel;
            EmpresaAereaController controller = new EmpresaAereaController();
            EmpresaAerea empresaAerea = new EmpresaAerea
            {
                Nome = cvm.Nome,
                Descricao = cvm.Descricao
            };
            controller.CadastrarEmpresaAerea(empresaAerea);
            lblMensagem.Content = "Empresa Aérea cadastrada com sucesso!";
        }
    }
}
