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
    public partial class ReservaHotelListar : UserControl
    {
        readonly static ReservaHotelController controller = new ReservaHotelController();

        public ReservaHotelListar()
        {
            InitializeComponent();
            DataContext = new ReservaHotelViewModel();
        }
        public void OnDelete(object sender, RoutedEventArgs e)
        {
            controller.ExcluirReservaHotel((ReservaHotel)dgReservas.CurrentItem);
            dgReservas.DataContext = new ReservaHotelViewModel();
        }

    }
}
