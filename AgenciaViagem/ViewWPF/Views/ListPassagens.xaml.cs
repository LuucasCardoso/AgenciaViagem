using Controllers;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace ViewWPF.Views
{
    /// <summary>
    /// Interação lógica para ListPassagens.xam
    /// </summary>
    public partial class ListPassagens : UserControl
    {
        Timer timer = new Timer(3000);

        readonly static PassagemController controller = new PassagemController();

        public ListPassagens()
        {
            InitializeComponent();
            DataContext = new PassagemViewModel();

        }        

        private void AdicionarReservaPassagem(object sender, RoutedEventArgs e)
        {
            PassagemViewModel pvm = DataContext as PassagemViewModel;
            Random r = new Random();
            pvm.Preco = r.Next(800,3000);
            pvm.UsuarioId = 2;
            try
            {
                if (dtDataEmbarque.SelectedDate == null)
                {
                    throw new Exception("Favor preencher Data Embarque!");
                }
                if (dtDataVolta.SelectedDate == null)
                {
                    throw new Exception("Favor preencher Data Volta!");
                }
                Passagem passagem = new Passagem
                {
                    PassagemId = pvm.PassagemId,
                    CidadeOrigem = pvm.CidadeOrigem,
                    CidadeDestino = pvm.CidadeDestino,
                    DataEmbarque = (DateTime)dtDataEmbarque.SelectedDate,
                    DataVolta = (DateTime)dtDataVolta.SelectedDate,
                    Preco = pvm.Preco,
                    UsuarioId = pvm.UsuarioId,
                    EmpresaAereaId = pvm.EmpresaAereaId
                };
                try
                {
                    if (passagem.EmpresaAereaId == 0)
                    {
                        throw new Exception("Favor preencher Empresa Aerea!");
                    }
                    if (passagem.CidadeOrigem == null)
                    {
                        throw new Exception("Favor preencher Cidade Origem!");
                    }
                    if (passagem.CidadeDestino == null)
                    {
                        throw new Exception("Favor preencher Cidade Destino!");
                    }
                    controller.CadastrarPassagem(passagem);
                    lblMessage.Foreground = Brushes.Green;
                    lblMessage.Content = "Passagem Reservada!";
                    timer.Elapsed += LimpaLabel;
                    timer.AutoReset = false;
                    timer.Start();
                }
                catch (Exception ex)
                {
                    lblMessage.Foreground = Brushes.Red;
                    lblMessage.Content = ex.Message;
                    timer.Elapsed += LimpaLabel;
                    timer.AutoReset = false;
                    timer.Start();
                }

            }
            catch (Exception ex)
            {
                lblMessage.Foreground = Brushes.Red;
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
