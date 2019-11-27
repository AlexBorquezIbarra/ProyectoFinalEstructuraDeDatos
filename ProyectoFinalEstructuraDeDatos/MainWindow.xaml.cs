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
using System.Collections.ObjectModel;

namespace ProyectoFinalEstructuraDeDatos
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Elemento> Elementos = new ObservableCollection<Elemento>();
        public MainWindow()
        {
            InitializeComponent();
            Elementos.Add(new Elemento("Baby Blue", "2019", "terror", "0", "Dross", "Por su traduccion M****a Azul", "5"));
            Elementos.Add(new Elemento("ah shit, here we go again", "2015", "accion", "0", "Andrea Sazueta", "Primera mision roba una bici", "4"));
            Elementos.Add(new Elemento("Las Caguamas Locas", "2016", "comedia", "3", "Osbaldo Beltran.", "Los 3 buchones en busca de alcohol", "3"));
            lsNombreAño.ItemsSource = Elementos;
        }

        private void LsNombreAnno_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            grdInterfaz.Children.Add(new VisualizarElemento());
            grdInterfaz.Visibility = Visibility.Visible;
            btnGuardarElemento.Visibility = Visibility.Hidden;
            btnCancelar.Visibility = Visibility.Visible;
            btnNuevoElemento.Visibility = Visibility.Hidden;
            btnHabilitarEdicion.Visibility = Visibility.Visible;
            btnEliminarElemento.Visibility = Visibility.Visible;

            /*if(((NuevoElemento)(grdInterfaz.Children[0])).rdbPeliculaNuevoElemento.IsChecked == true)
            {
                ((VisualizarElemento)(grdInterfaz.Children[0])).lblPeliculaVisualizar.Visibility = Visibility.Visible;
            }

            if (((NuevoElemento)(grdInterfaz.Children[0])).rdbSerieNuevoElemento.IsChecked == true)
            {
                ((VisualizarElemento)(grdInterfaz.Children[0])).lblSerieVisualizar.Visibility = Visibility.Visible;
            }*/


            ((VisualizarElemento)(grdInterfaz.Children[0])).txtTituloVizualizar.Text = Elementos[lsNombreAño.SelectedIndex].Titulo;
            ((VisualizarElemento)(grdInterfaz.Children[0])).txtAnnoVizualizar.Text = Elementos[lsNombreAño.SelectedIndex].Año;
            ((VisualizarElemento)(grdInterfaz.Children[0])).txtGeneroVizualizar.Text = Elementos[lsNombreAño.SelectedIndex].Genero;
            ((VisualizarElemento)(grdInterfaz.Children[0])).txtTemporadasVizualizar.Text = Elementos[lsNombreAño.SelectedIndex].Temporada;
            ((VisualizarElemento)(grdInterfaz.Children[0])).txtProductorVizualizar.Text = Elementos[lsNombreAño.SelectedIndex].Productor;
            ((VisualizarElemento)(grdInterfaz.Children[0])).txtDescripcionVizualizar.Text = Elementos[lsNombreAño.SelectedIndex].Descripcion;
        }

        private void BtnNuevoElemento_Click(object sender, RoutedEventArgs e)
        {
            grdInterfaz.Children.Add(new NuevoElemento());
            grdInterfaz.Visibility = Visibility.Visible;
            btnGuardarElemento.Visibility = Visibility.Visible;
            btnCancelar.Visibility = Visibility.Visible;
            btnNuevoElemento.Visibility = Visibility.Hidden;
            btnOrdenarAZ.Visibility = Visibility.Hidden;
            btnOrdenarZA.Visibility = Visibility.Hidden;
            btnAñoUp.Visibility = Visibility.Hidden;
            btnAñoDown.Visibility = Visibility.Hidden;
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            grdInterfaz.Children.Clear();
            grdInterfaz.Visibility = Visibility.Hidden;
            btnGuardarElemento.Visibility = Visibility.Hidden;
            btnCancelar.Visibility = Visibility.Hidden;
            btnHabilitarEdicion.Visibility = Visibility.Hidden;
            btnEliminarElemento.Visibility = Visibility.Hidden;
            btnActualizarElemento.Visibility = Visibility.Hidden;
            btnNuevoElemento.Visibility = Visibility.Visible;
            btnOrdenarAZ.Visibility = Visibility.Visible;
            btnOrdenarZA.Visibility = Visibility.Visible;
            btnAñoUp.Visibility = Visibility.Visible;
            btnAñoDown.Visibility = Visibility.Visible;
        }

        private void BtnOrdenarAZ_Click(object sender, RoutedEventArgs e)
        {
            bool aux;
            do
            {
                aux = false;
                for (int i = 0; i < (Elementos.Count - 1); i++)
                {
                    if (string.Compare(Elementos[i].Titulo, Elementos[i + 1].Titulo) > 0)
                    {
                        var temp = Elementos[i];
                        Elementos[i] = Elementos[i + 1];
                        Elementos[i + 1] = temp;
                        aux = true;
                    }
                }
            } while (aux == true);
        }

        private void BtnOrdenarZA_Click(object sender, RoutedEventArgs e)
        {
            bool aux;
            do
            {
                aux = false;
                for (int i = 0; i < (Elementos.Count - 1); i++)
                {
                    if (string.Compare(Elementos[i].Titulo, Elementos[i + 1].Titulo) < 0)
                    {
                        var temp = Elementos[i];
                        Elementos[i] = Elementos[i + 1];
                        Elementos[i + 1] = temp;
                        aux = true;
                    }
                }
            } while (aux == true);
        }

        private void BtnAñoUp_Click(object sender, RoutedEventArgs e)
        {
            int gap, i, j;
            gap = Elementos.Count / 2;
            while (gap > 0)
            {
                for (i = 0; i < Elementos.Count; i++)
                {
                    if (gap + i < Elementos.Count && int.Parse(Elementos[i].Año) < int.Parse(Elementos[gap + i].Año))
                    {
                        var temp = Elementos[i];
                        Elementos[i] = Elementos[gap + i];
                        Elementos[gap + i] = temp;
                    }
                }
                gap--;
            }
        }

        private void BtnAñoDown_Click(object sender, RoutedEventArgs e)
        {
            int gap, i, j;
            gap = Elementos.Count / 2;
            while (gap > 0)
            {
                for (i = 0; i < Elementos.Count; i++)
                {
                    if (gap + i < Elementos.Count && int.Parse(Elementos[i].Año) > int.Parse(Elementos[gap + i].Año))
                    {
                        var temp = Elementos[i];
                        Elementos[i] = Elementos[gap + i];
                        Elementos[gap + i] = temp;
                    }
                }
                gap--;
            }
        }

        private void BtnGuardarElemento_Click(object sender, RoutedEventArgs e)
        {
            grdInterfaz.Visibility = Visibility.Hidden;
            btnGuardarElemento.Visibility = Visibility.Hidden;
            btnCancelar.Visibility = Visibility.Hidden;
            btnHabilitarEdicion.Visibility = Visibility.Hidden;
            btnEliminarElemento.Visibility = Visibility.Hidden;
            btnActualizarElemento.Visibility = Visibility.Hidden;
            btnNuevoElemento.Visibility = Visibility.Visible;
            btnOrdenarAZ.Visibility = Visibility.Visible;
            btnOrdenarZA.Visibility = Visibility.Visible;
            btnAñoUp.Visibility = Visibility.Visible;
            btnAñoDown.Visibility = Visibility.Visible;

            ((NuevoElemento)(grdInterfaz.Children[0])).lblPelicula.Visibility = Visibility.Hidden;
            ((NuevoElemento)(grdInterfaz.Children[0])).lblSerie.Visibility = Visibility.Hidden;
            ((NuevoElemento)(grdInterfaz.Children[0])).rdbPelicula.Visibility = Visibility.Visible;
            ((NuevoElemento)(grdInterfaz.Children[0])).rdbSerie.Visibility = Visibility.Visible;
            ((NuevoElemento)(grdInterfaz.Children[0])).lblTipoNuevoElemento.Visibility = Visibility.Visible;

            Elementos.Add(new Elemento(((NuevoElemento)(grdInterfaz.Children[0])).txtTituloNuevoElemento.Text, ((NuevoElemento)(grdInterfaz.Children[0])).txtAnnoNuevoElemento.Text, ((NuevoElemento)(grdInterfaz.Children[0])).txtGeneroNuevoElemento.Text, ((NuevoElemento)(grdInterfaz.Children[0])).txtTemporadasNuevoElemento.Text, ((NuevoElemento)(grdInterfaz.Children[0])).txtProductorNuevoElemento.Text, ((NuevoElemento)(grdInterfaz.Children[0])).txtDescripcionNuevoElemento.Text, ((NuevoElemento)(grdInterfaz.Children[0])).txtRatingNuevoElemento.Text));
            ((NuevoElemento)(grdInterfaz.Children[0])).txtTituloNuevoElemento.Text = "";
            ((NuevoElemento)(grdInterfaz.Children[0])).txtAñoNuevoElemento.Text = "";
            ((NuevoElemento)(grdInterfaz.Children[0])).txtGeneroNuevoElemento.Text = "";
            ((NuevoElemento)(grdInterfaz.Children[0])).txtTemporadasNuevoElemento.Text = "";
            ((NuevoElemento)(grdInterfaz.Children[0])).txtTemporadasNuevoElemento.Text = "";
            ((NuevoElemento)(grdInterfaz.Children[0])).txtDescripcionNuevoElemento.Text = "";
            ((NuevoElemento)(grdInterfaz.Children[0])).txtRatingNuevoElemento.Text = "";
            grdInterfaz.Children.Clear();
        }
    }
}
