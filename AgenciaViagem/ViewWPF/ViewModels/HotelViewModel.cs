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
    class HotelViewModel : INotifyPropertyChanged
    {
        readonly HotelController controllerHotel = new HotelController();
        readonly CidadeController controllerCidade = new CidadeController();
        readonly PaisController controllerPais = new PaisController();
        readonly EstadoController controllerEstado = new EstadoController();

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public HotelViewModel()
        {
            Hoteis = new ObservableCollection<Hotel>(controllerHotel.ListarHoteis());
            Paises = new ObservableCollection<Pais>(controllerPais.ListarPaises());
            foreach(var hotel in Hoteis)
            {
                _Cidade = controllerCidade.BuscarPorId(hotel.CidadeId);
                _Cidade._Estado = controllerEstado.BuscarPorId(_Cidade.EstadoId);
                _Cidade._Estado._Pais = controllerPais.BuscarPorId(_Cidade._Estado.PaisId);
                hotel._Cidade = _Cidade;
            }
        }

        private ObservableCollection<Pais> paises;

        public ObservableCollection<Pais> Paises
        {
            get { return paises; }
            set { paises = value; }
        }


        private ObservableCollection<Cidade> cidades;

        public ObservableCollection<Cidade> Cidades
        {
            get { return cidades; }
            set
            {
                cidades = value;
                NotifyPropertyChanged();
            }
        }

        private ObservableCollection<Hotel> hoteis;

        public ObservableCollection<Hotel> Hoteis
        {
            get { return hoteis; }
            set
            {
                hoteis = value;
                NotifyPropertyChanged();
            }
        }


        private int hotelId;

        public int HotelId
        {
            get { return hotelId; }
            set {
                hotelId = value;
                NotifyPropertyChanged();
            }
        }

        private string nome;

        public string Nome
        {
            get { return nome; }
            set {
                nome = value;
                NotifyPropertyChanged();
            }
        }

        private string descricao;

        public string Descricao
        {
            get { return descricao; }
            set {
                descricao = value;
                NotifyPropertyChanged();
            }
        }

        private int cidadeId;

        public int CidadeId
        {
            get { return cidadeId; }
            set
            {
                cidadeId = value;
                NotifyPropertyChanged();
            }
        }

        private Cidade _cidade;

        public Cidade _Cidade
        {
            get { return _cidade; }
            set { _cidade = value; }
        }

    }
}
