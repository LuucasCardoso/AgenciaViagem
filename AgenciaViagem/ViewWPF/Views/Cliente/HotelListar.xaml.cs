using Controllers;
using Models.DAL;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ViewWPF.Views.Cliente
{
    /// <summary>
    /// Interação lógica para ListHoteis.xam
    /// </summary>
    public partial class HotelListar : UserControl
    {
        Timer timer = new Timer(3000);
        readonly static CidadeController cidadeController = new CidadeController();
        readonly static EstadoController estadoController = new EstadoController();
        readonly static HotelController hotelController = new HotelController();
        readonly static ReservaHotelController reservaHotelController = new ReservaHotelController();

        public HotelListar()
        {
            InitializeComponent();
            DataContext = new HotelViewModel();
        }

        private void FiltrarHotéis(object sender, RoutedEventArgs e)
        {
            Cidade cidade = (Cidade)cmbBoxlistCidadeHotel.SelectedItem;
            ObservableCollection<Hotel> hoteis = new ObservableCollection<Hotel>(hotelController.ListarHoteis());
            ObservableCollection<Hotel> listaFiltrada = new ObservableCollection<Hotel>();
            if (cidade != null)
            {
                foreach (Hotel h in hoteis)
                {
                    if (h.CidadeId == cidade.CidadeId)
                    {
                        listaFiltrada.Add(h);
                    }
                }
                dgHoteis.DataContext = new HotelViewModel(listaFiltrada);
            }
            else
            {
                dgHoteis.DataContext = new HotelViewModel();
            }
        }

        private void ChamaEstado(object sender, System.EventArgs e)
        {
            if (cmbBoxlistPaisHotel.SelectedItem != null)
            {
                Pais pais = (Pais)cmbBoxlistPaisHotel.SelectedItem;
                cmbBoxlistEstadoHotel.ItemsSource = new ObservableCollection<Estado>(estadoController.ListarEstadosPorPais(pais.PaisId));
            }
            else
            {
                cmbBoxlistEstadoHotel.SelectedItem = null;
            }
        }

        private void ChamaCidade(object sender, System.EventArgs e)
        {
            if (cmbBoxlistEstadoHotel.SelectedItem != null)
            {
                Estado estado = (Estado)cmbBoxlistEstadoHotel.SelectedItem;
                cmbBoxlistCidadeHotel.ItemsSource = new ObservableCollection<Cidade>(cidadeController.ListarCidadesPorEstado(estado.EstadoId));
            }
            else
            {
                cmbBoxlistCidadeHotel.SelectedValue = null;
            }
        }

        private void LimparFiltro(object sender, System.EventArgs e)
        {
            dgHoteis.DataContext = new HotelViewModel();
            cmbBoxlistCidadeHotel.SelectedItem = null;
            cmbBoxlistEstadoHotel.SelectedItem = null;
            cmbBoxlistPaisHotel.SelectedItem = null;
        }

        private void AdicionarReservaHotel(object sender, RoutedEventArgs e)
        {
            ReservaHotelViewModel rhvm = new ReservaHotelViewModel();
            Hotel hotel = (Hotel)dgHoteis.CurrentItem;
            rhvm.CheckIn = (DateTime)dtCheckIn.SelectedDate;
            rhvm.CheckOut = (DateTime)dtCheckOut.SelectedDate;
            rhvm.HotelId = hotel.HotelId;
            rhvm.DataReserva = DateTime.Now;
            rhvm.UsuarioId = 2;
            ReservaHotel reserva = new ReservaHotel
            {
                ReservaHotelId = rhvm.ReservaHotelId,
                CheckIn = rhvm.CheckIn,
                CheckOut = rhvm.CheckOut,
                DataReserva = rhvm.DataReserva,
                UsuarioId = rhvm.UsuarioId,
                HotelId = rhvm.HotelId
            };
            try
            {
                if(reserva.CheckIn == null)
                {
                    throw new Exception("Favor preencher Check In!");
                }
                if (reserva.CheckOut == null)
                {
                    throw new Exception("Favor preencher Check In!");
                }
                if (reserva.HotelId == 0)
                {
                    throw new Exception("Favor preencher Hotel!");
                }
                if (reserva.UsuarioId == 0)
                {
                    throw new Exception("Favor preencher Usuario!");
                }
                reservaHotelController.CadastrarReservaHotel(reserva);
                lblMessage.Content = "Hotel Reservado!";
                timer.Elapsed += LimpaLabel;
                timer.AutoReset = false;
                timer.Start();
            }
            catch (Exception ex)
            {
                lblMessage.Content = ex.Message;
                timer.Elapsed += LimpaLabel;
                timer.AutoReset = false;
                timer.Start();
            }
        }

        private void LimpaLabel(object sender, ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                lblMessage.Content = "";
            });
        }

    }
}
