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
    class PassagemViewModel : INotifyPropertyChanged
    {
        readonly PassagemController passagemController = new PassagemController();
        readonly EmpresaAereaController empresaAereaController = new EmpresaAereaController();
        readonly UsuarioController usuarioController = new UsuarioController();
        readonly CidadeController cidadeController = new CidadeController();

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public PassagemViewModel()
        {
            Cidades = new ObservableCollection<Cidade>(cidadeController.ListarCidades());
            EmpresasAereas = new ObservableCollection<EmpresaAerea>(empresaAereaController.ListarEmpresasAereas());
            Passagens = new ObservableCollection<Passagem>(passagemController.ListarPassagens());
            foreach(var p in Passagens)
            {
                p._EmpresaAerea = empresaAereaController.BuscarPorId(p.EmpresaAereaId);
                p._Usuario = usuarioController.BuscarPorId(p.UsuarioId);
            }
        }

        private ObservableCollection<ReservaHotel> reservasHotel;

        public ObservableCollection<ReservaHotel>  ReservasHotel
        {
            get { return reservasHotel; }
            set { reservasHotel = value; }
        }

        private ObservableCollection<EmpresaAerea> empresasAereas;

        public ObservableCollection<EmpresaAerea> EmpresasAereas
        {
            get { return empresasAereas; }
            set { empresasAereas = value; }
        }


        private ObservableCollection<Cidade> cidades;

        public ObservableCollection<Cidade> Cidades
        {
            get { return cidades; }
            set { cidades = value; }
        }


        private ObservableCollection<Passagem> passagens;

        public ObservableCollection<Passagem> Passagens
        {
            get { return passagens; }
            set { passagens = value; }
        }


        private int passagemId;

        public int PassagemId
        {
            get { return passagemId; }
            set { passagemId = value; }
        }

        private DateTime dataEmbarque;

        public DateTime DataEmbarque
        {
            get { return dataEmbarque; }
            set { dataEmbarque = value; }
        }

        private DateTime dataVolta;

        public DateTime DataVolta
        {
            get { return dataVolta; }
            set { dataVolta = value; }
        }

        private string cidadeOrigem;

        public string CidadeOrigem
        {
            get { return cidadeOrigem; }
            set { cidadeOrigem = value; }
        }

        private string cidadeDestino;

        public string CidadeDestino
        {
            get { return cidadeDestino; }
            set { cidadeDestino = value; }
        }

        private decimal preco;

        public decimal Preco
        {
            get { return preco; }
            set { preco = value; }
        }

        private int empresaAereaId;

        public int EmpresaAereaId
        {
            get { return empresaAereaId; }
            set { empresaAereaId = value; }
        }

        private int usuarioId;

        public int UsuarioId
        {
            get { return usuarioId; }
            set { usuarioId = value; }
        }

        private EmpresaAerea _empresaAerea;

        public EmpresaAerea _EmpresaAerea
        {
            get { return _empresaAerea; }
            set { _empresaAerea = value; }
        }



        private Usuario _usuario;

        public Usuario _Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }


    }
}
