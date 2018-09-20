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
    class EmpresaAereaViewModel : INotifyPropertyChanged
    {
        readonly EmpresaAereaController controller = new EmpresaAereaController();
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<EmpresaAerea> empresasAereas;
                
        public ObservableCollection<EmpresaAerea> EmpresasAereas
        {
            get { return empresasAereas; }
            set {
                empresasAereas = value;
                NotifyPropertyChanged();
            }
        }

        public EmpresaAereaViewModel()
        {
            EmpresasAereas = new ObservableCollection<EmpresaAerea>(controller.ListarEmpresasAereas());
        }


        private int empresaAereaId;

        public int EmpresaAereaId
        {
            get { return empresaAereaId; }
            set {
                empresaAereaId = value;
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
            set
            {
                descricao = value;
                NotifyPropertyChanged();
            }
        }
    }
}
