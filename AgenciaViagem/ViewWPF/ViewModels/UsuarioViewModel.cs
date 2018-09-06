using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ViewWPF.ViewModels
{
    class UsuarioViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


        private int usuarioId;
        public int UsuarioId
        {
            get { return usuarioId; }
            set
            {
                usuarioId = value;
                NotifyPropertyChanged();
            }
        }
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                NotifyPropertyChanged();
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                NotifyPropertyChanged();
            }
        }
        private string user;
        public string User
        {
            get { return user; }
            set
            {
                user = value;
                NotifyPropertyChanged();
            }
        }
        private string nome;
        public string Nome
        {
            get { return nome; }
            set
            {
                nome = value;
                NotifyPropertyChanged();
            }
        }
        private string cpf;
        public string Cpf
        {
            get { return cpf; }
            set
            {
                cpf = value;
                NotifyPropertyChanged();
            }
        }
        private string telefone;
        public string Telefone
        {
            get { return telefone; }
            set
            {
                telefone = value;
                NotifyPropertyChanged();
            }
        }
        private bool administrador;
        public bool Administrador
        {
            get { return administrador; }
            set
            {
                administrador = value;
                NotifyPropertyChanged();
            }
        }
        private bool ativo;
        public bool Ativo
        {
            get { return ativo; }
            set
            {
                ativo = value;
                NotifyPropertyChanged();
            }
        }
    }
}
