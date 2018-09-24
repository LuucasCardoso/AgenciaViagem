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
    /// Interação lógica para HoteisListar.xam
    /// </summary>
    public partial class HotelCRUD : UserControl
    {
        readonly static CidadeController cidadeController = new CidadeController();
        readonly static HotelController hotelController = new HotelController();

        public HotelCRUD()
        {
            InitializeComponent();
            DataContext = new HotelViewModel();
        }

        private void OnSave(object sender, RoutedEventArgs e)
        {
            HotelViewModel hvm = DataContext as HotelViewModel;
            Hotel hotel = new Hotel
            {
                HotelId = hvm.HotelId,
                Nome = hvm.Nome,
                Descricao = hvm.Descricao,
                CidadeId = hvm.CidadeId
            };
            try
            {
                if (hotel.Nome == null)
                {
                    throw new Exception("Favor, preencher o campo Nome!");
                }
                if (hotel.Descricao == null)
                {
                    throw new Exception("Favor, preencher o campo Descrição!");
                }
                if (hotel.CidadeId == 0)
                {
                    throw new Exception("Favor, selecionar uma Cidade!");
                }
                if (hotel.HotelId == 0)
                {
                    hotelController.CadastrarHotel(hotel);
                }
                else
                {
                    hotelController.EditarHotel(hotel);
                }
                dgHoteis.DataContext = new HotelViewModel();
                GridCadastrarEditarHotel.Visibility = Visibility.Collapsed;
                GridListarHoteis.Visibility = Visibility.Visible;
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
                DataContext = new HotelViewModel();
            }
            else
            {
                Hotel h = (Hotel)dgHoteis.CurrentItem;
                DataContext = new Hotel
                {
                    HotelId = h.HotelId,
                    Nome = h.Nome,
                    Descricao = h.Descricao,
                    CidadeId = h.CidadeId
                };
            }
            GridListarHoteis.Visibility = Visibility.Collapsed;
            cadButton.Visibility = Visibility.Collapsed;
            GridCadastrarEditarHotel.Visibility = Visibility.Visible;
        }

        private void OnDelete(object sender, RoutedEventArgs e)
        {
            hotelController.ExcluirHotel((Hotel)dgHoteis.CurrentItem);
            dgHoteis.DataContext = new HotelViewModel();
        }

        private void SaveBack(object sender, RoutedEventArgs e)
        {
            GridCadastrarEditarHotel.Visibility = Visibility.Collapsed;
            GridListarHoteis.Visibility = Visibility.Visible;
            cadButton.Visibility = Visibility.Visible;
        }

        private void ChamaCidade(object sender, System.EventArgs e)
        {
            Hotel hotel = (Hotel)dgHoteis.CurrentItem;
            Cidade cidade = cidadeController.BuscarPorId(hotel.CidadeId);
            sender = cidade.Nome;
        }
    }
}
