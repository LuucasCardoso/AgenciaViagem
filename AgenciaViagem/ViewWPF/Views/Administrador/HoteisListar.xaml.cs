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
    public partial class HoteisListar : UserControl
    {
        readonly static HoteisController controller = new HoteisController();
        public HoteisListar()
        {
            InitializeComponent();
            DataContext = new HotelViewModel();
        }

        private void OnCreate(object sender, RoutedEventArgs e)
        {
            HotelViewModel cvm = DataContext as HotelViewModel;
            Hotel hotel = new Hotel
            {
                Nome = cvm.Nome,
                Descricao = cvm.Descricao
            };
            controller.CadastrarHotel(hotel);
            dgHoteis.DataContext = new HotelViewModel();
            GridCadastrarHotel.Visibility = Visibility.Collapsed;
            GridListarHoteis.Visibility = Visibility.Visible;
            cadButton.Visibility = Visibility.Visible;
            txtBoxCadNomeHotel.Text = "";
            txtBoxCadDescricaoHotel.Text = "";
        }
        private void CallCreate(object sender, RoutedEventArgs e)
        {
            txtBoxCadNomeHotel.Text = "";
            txtBoxCadDescricaoHotel.Text = "";
            GridListarHoteis.Visibility = Visibility.Collapsed;
            cadButton.Visibility = Visibility.Collapsed;
            GridCadastrarHotel.Visibility = Visibility.Visible;
        }
        private void CallUpdate(object sender, RoutedEventArgs e)
        {
            Hotel hotel = (Hotel)dgHoteis.CurrentItem;
            DataContext = new HotelViewModel{ HotelId = hotel.HotelId };
            GridListarHoteis.Visibility = Visibility.Collapsed;
            cadButton.Visibility = Visibility.Collapsed;
            GridEditarHoteis.Visibility = Visibility.Visible;
            txtBoxEditNomeHotel.Text = hotel.Nome;
            txtBoxEditDescricaoHotel.Text = hotel.Descricao;
        }

        private void OnUpdate(object sender, RoutedEventArgs e)
        {
            txtBoxEditDescricaoHotel.Focus();
            txtBoxEditNomeHotel.Focus();
            txtBoxEditDescricaoHotel.Focus();
            HotelViewModel evm = DataContext as HotelViewModel;
            Hotel hotel = new Hotel
            {
                HotelId = evm.HotelId,
                Nome = evm.Nome,
                Descricao = evm.Descricao
            };
            controller.EditarHotel(hotel);
            dgHoteis.DataContext = new HotelViewModel();
            GridEditarHoteis.Visibility = Visibility.Collapsed;
            GridListarHoteis.Visibility = Visibility.Visible;
            cadButton.Visibility = Visibility.Visible;
        }

        private void OnDelete(object sender, RoutedEventArgs e)
        {
            controller.ExcluirHoteis((Hotel)dgHoteis.CurrentItem);
            dgHoteis.DataContext = new HotelViewModel();
            GridEditarHoteis.Visibility = Visibility.Collapsed;
            GridListarHoteis.Visibility = Visibility.Visible;
            cadButton.Visibility = Visibility.Visible;
        }

        private void CreateBack(object sender, RoutedEventArgs e)
        {
            GridCadastrarHotel.Visibility = Visibility.Collapsed;
            GridListarHoteis.Visibility = Visibility.Visible;
            cadButton.Visibility = Visibility.Visible;
        }

        private void EditBack(object sender, RoutedEventArgs e)
        {
            GridEditarHoteis.Visibility = Visibility.Collapsed;
            GridListarHoteis.Visibility = Visibility.Visible;
            cadButton.Visibility = Visibility.Visible;
        }

    }
}
