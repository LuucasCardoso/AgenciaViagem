using Models.DAL;
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

namespace ViewWPF.Views.Cliente
{
    /// <summary>
    /// Interação lógica para ListHoteis.xam
    /// </summary>
    public partial class HotelListar : UserControl
    {
        public HotelListar()
        {
            InitializeComponent();
            DataContext = new List<Pais>();
            Contexto db = new Contexto();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GridInferior.Visibility = Visibility.Visible;
        }

    }
}
