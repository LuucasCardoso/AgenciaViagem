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
    public partial class EmpresaAereaCRUD : UserControl
    {
        readonly static EmpresaAereaController controller = new EmpresaAereaController();
        public EmpresaAereaCRUD()
        {
            InitializeComponent();
            DataContext = new EmpresaAereaViewModel();
        }
        private void OnSave(object sender, RoutedEventArgs e)
        {
            EmpresaAereaViewModel evm = DataContext as EmpresaAereaViewModel;
            EmpresaAerea empresaAerea = new EmpresaAerea
            {
                EmpresaAereaId = evm.EmpresaAereaId,
                Nome = evm.Nome,
                Descricao = evm.Descricao
            };
            try
            {
                if (empresaAerea.Nome == null)
                {
                    throw new Exception("Favor, preencher o campo nome!");
                }
                if (empresaAerea.EmpresaAereaId == 0)
                {
                    controller.CadastrarEmpresaAerea(empresaAerea);
                }
                else
                {
                    controller.EditarEmpresaAerea(empresaAerea);
                }
                dgEmpresasAereas.DataContext = new EmpresaAereaViewModel();
                GridCadastrarEditarEmpresaAerea.Visibility = Visibility.Collapsed;
                GridListarEmpresaAerea.Visibility = Visibility.Visible;
                cadButton.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                lblMessageForm.Content = ex.Message;
            }
        }
        private void CallSave(object sender, RoutedEventArgs e)
        {
            lblMessageForm.Content = "";
            Button button = (Button)sender;
            if (button.Name == "cadButton")
            {
                DataContext = new EmpresaAereaViewModel();

            }
            else
            {
                EmpresaAerea ea = (EmpresaAerea)dgEmpresasAereas.CurrentItem;
                DataContext = new EmpresaAereaViewModel
                {
                    EmpresaAereaId = ea.EmpresaAereaId,
                    Nome = ea.Nome,
                    Descricao = ea.Descricao
                };
            }
            GridListarEmpresaAerea.Visibility = Visibility.Collapsed;
            cadButton.Visibility = Visibility.Collapsed;
            GridCadastrarEditarEmpresaAerea.Visibility = Visibility.Visible;
        }

        private void OnDelete(object sender, RoutedEventArgs e)
        {
            controller.ExcluirEmpresaAerea((EmpresaAerea)dgEmpresasAereas.CurrentItem);
            dgEmpresasAereas.DataContext = new EmpresaAereaViewModel();
        }

        private void SaveBack(object sender, RoutedEventArgs e)
        {
            GridCadastrarEditarEmpresaAerea.Visibility = Visibility.Collapsed;
            GridListarEmpresaAerea.Visibility = Visibility.Visible;
            cadButton.Visibility = Visibility.Visible;
        }
    }
}
