using Controllers;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ViewWPF.ViewModels
{
    class ReservaHotelViewModel : INotifyPropertyChanged
    {
        readonly ReservaHotelController controllerReservaHotel = new ReservaHotelController();
        readonly HotelController controllerHotel = new HotelController();
        readonly UsuarioController controllerUsuario = new UsuarioController();

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public ReservaHotelViewModel()
        {
            ReservasHotel = new ObservableCollection<ReservaHotel>(controllerReservaHotel.ListarReservasHotel());
            foreach(var rh in ReservasHotel)
            {
                rh._Hotel = controllerHotel.BuscarPorId(rh.HotelId);
                rh._Usuario = controllerUsuario.BuscarPorId(rh.UsuarioId);
            }
        }

        private ObservableCollection<ReservaHotel> reservasHotel;

        public ObservableCollection<ReservaHotel>  ReservasHotel
        {
            get { return reservasHotel; }
            set { reservasHotel = value; }
        }


        private int reservaHotelId;

        public int ReservaHotelId
        {
            get { return reservaHotelId; }
            set { reservaHotelId = value; }
        }

        private DateTime checkIn;

        public DateTime CheckIn
        {
            get { return checkIn; }
            set { checkIn = value; }
        }

        private DateTime checkOut;

        public DateTime CheckOut
        {
            get { return checkOut; }
            set { checkOut = value; }
        }

        private DateTime dataReserva;

        public DateTime DataReserva
        {
            get { return dataReserva; }
            set { dataReserva = value; }
        }

        private int usuarioId;

        public int UsuarioId
        {
            get { return usuarioId; }
            set { usuarioId = value; }
        }

        private int hotelId;

        public int HotelId
        {
            get { return hotelId; }
            set { hotelId = value; }
        }

        private Hotel _hotel;

        public Hotel _Hotel
        {
            get { return _hotel; }
            set { _hotel = value; }
        }

        private Usuario _usuario;

        public Usuario _Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }


    }
}
