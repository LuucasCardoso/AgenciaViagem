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

namespace ViewWPF.Views
{
    /// <summary>
    /// Interação lógica para ListCarrinho.xam
    /// </summary>
    public partial class ListCarrinho : UserControl
    {
        public ListCarrinho()
        {
            InitializeComponent();

            var compras = new[]{
                 new {Compra = "Gol", Categoria = "Passagem", Preco = "R$ 550,00"},
                 new {Compra = "Hotel ***", Categoria = "Hotel", Preco = "R$ 900,00"},
            };

            DataGridCompras.ItemsSource = compras;
        }

        private void Atualizar_Click(object sender, RoutedEventArgs e)
        {
            GridCompras.Visibility = Visibility.Hidden;
            GridListCompras.Visibility = Visibility.Visible;
        }

        private void ComprarMais_Click(object sender, RoutedEventArgs e)
        {
            GridPrincipal.Children.Clear();
            GridPrincipal.Children.Add(new ListPassagens());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Cartao.Text))
            {
                SucessoCompra.Visibility = Visibility.Hidden;
                ErroCompra.Visibility = Visibility.Visible;
            }
            else
            {
                SucessoCompra.Visibility = Visibility.Visible;
                ErroCompra.Visibility = Visibility.Hidden;
            }
        }
        
    }
}
