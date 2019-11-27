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

namespace ProyectoFinalEstructuraDeDatos
{
    /// <summary>
    /// Lógica de interacción para NuevoElemento.xaml
    /// </summary>
    public partial class NuevoElemento : Page
    {
        public NuevoElemento()
        {
            InitializeComponent();
        }

        private void RdbSerie_Checked(object sender, RoutedEventArgs e)
        {
            lblPelicula.Visibility = Visibility.Hidden;
            lblSerie.Visibility = Visibility.Visible;
            rdbPelicula.Visibility = Visibility.Hidden;
            rdbSerie.Visibility = Visibility.Hidden;
            lblTipoNuevoElemento.Visibility = Visibility.Hidden;
        }

        private void RdbPelicula_Checked(object sender, RoutedEventArgs e)
        {
            lblPelicula.Visibility = Visibility.Visible;
            lblSerie.Visibility = Visibility.Hidden;
            rdbPelicula.Visibility = Visibility.Hidden;
            rdbSerie.Visibility = Visibility.Hidden;
            lblTipoNuevoElemento.Visibility = Visibility.Hidden;
        }
    }
}
