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
    /// Interaction logic for EmpresaAereaListar.xaml
    /// </summary>
    public partial class EmpresaAereaListar : UserControl
    {
        readonly static EmpresaAereaController controller = new EmpresaAereaController();
        public EmpresaAereaListar()
        {
            InitializeComponent();
            DataContext = new EmpresaAereaViewModel();
        }
        private void OnCreate(object sender, RoutedEventArgs e)
        {
            EmpresaAereaViewModel cvm = DataContext as EmpresaAereaViewModel;
            EmpresaAerea empresaAerea = new EmpresaAerea
            {
                Nome = cvm.Nome,
                Descricao = cvm.Descricao
            };
            try
            {
                if (empresaAerea.Nome == null)
                {
                    throw new Exception("Favor, preencher o campo nome!");
                }
                controller.CadastrarEmpresaAerea(empresaAerea);
                dgEmpresasAereas.DataContext = new EmpresaAereaViewModel();
                GridCadastrarEmpresaAerea.Visibility = Visibility.Collapsed;
                GridListarEmpresaAerea.Visibility = Visibility.Visible;
                cadButton.Visibility = Visibility.Visible;
                txtBoxCadNomeEmpresa.Text = "";
                txtBoxCadDescricaoEmpresa.Text = "";
            }
            catch(Exception ex)
            {
                lblMessageCad.Content = ex.Message;
            }
        }
        private void CallCreate(object sender, RoutedEventArgs e)
        {
            DataContext = new EmpresaAereaViewModel();
            GridListarEmpresaAerea.Visibility = Visibility.Collapsed;
            cadButton.Visibility = Visibility.Collapsed;
            GridCadastrarEmpresaAerea.Visibility = Visibility.Visible;
        }
        private void CallUpdate(object sender, RoutedEventArgs e)
        {
            EmpresaAerea ea = (EmpresaAerea)dgEmpresasAereas.CurrentItem;
            EmpresaAereaViewModel evm = new EmpresaAereaViewModel();
            evm.EmpresaAereaId = ea.EmpresaAereaId;
            evm.Nome = ea.Nome;
            evm.Descricao = ea.Descricao;
            DataContext = evm;
            GridListarEmpresaAerea.Visibility = Visibility.Collapsed;
            cadButton.Visibility = Visibility.Collapsed;
            GridEditarEmpresaAerea.Visibility = Visibility.Visible;
        }

        private void OnUpdate(object sender, RoutedEventArgs e)
        {
            txtBoxEditDescricaoEmpresa.Focus();
            txtBoxEditNomeEmpresa.Focus();
            txtBoxEditDescricaoEmpresa.Focus();
            EmpresaAereaViewModel evm = DataContext as EmpresaAereaViewModel;
            EmpresaAerea empresaAerea = new EmpresaAerea
            {
                EmpresaAereaId = evm.EmpresaAereaId,
                Nome = evm.Nome,
                Descricao = evm.Descricao
            };
            controller.EditarEmpresaAerea(empresaAerea);
            dgEmpresasAereas.DataContext = new EmpresaAereaViewModel();
            GridEditarEmpresaAerea.Visibility = Visibility.Collapsed;
            GridListarEmpresaAerea.Visibility = Visibility.Visible;
            cadButton.Visibility = Visibility.Visible;
        }

        private void OnDelete(object sender, RoutedEventArgs e)
        {
            controller.ExcluirEmpresaAerea((EmpresaAerea)dgEmpresasAereas.CurrentItem);
            dgEmpresasAereas.DataContext = new EmpresaAereaViewModel();
            GridEditarEmpresaAerea.Visibility = Visibility.Collapsed;
            GridListarEmpresaAerea.Visibility = Visibility.Visible;
            cadButton.Visibility = Visibility.Visible;
        }

        private void CreateBack(object sender, RoutedEventArgs e)
        {
            GridCadastrarEmpresaAerea.Visibility = Visibility.Collapsed;
            GridListarEmpresaAerea.Visibility = Visibility.Visible;
            cadButton.Visibility = Visibility.Visible;
        }

        private void EditBack(object sender, RoutedEventArgs e)
        {
            GridEditarEmpresaAerea.Visibility = Visibility.Collapsed;
            GridListarEmpresaAerea.Visibility = Visibility.Visible;
            cadButton.Visibility = Visibility.Visible;
        }
    }
}
