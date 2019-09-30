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

namespace ControlesDeUsuario
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            grdParametrosFigura.Children.Clear();
            switch(cbfigura.SelectedIndex)
            {
                case 0:
                    grdParametrosFigura.Children.Add(new ParametrosCirculo());
                        break;
                case 1:
                    grdParametrosFigura.Children.Add(new ParametrosTriangulo());
                    break;
                case 2:
                    grdParametrosFigura.Children.Add(new ParametrosRectangulo());
                    break;
                case 3:
                    grdParametrosFigura.Children.Add(new ParametrosPentagono());
                    break;
                case 4:
                    grdParametrosFigura.Children.Add(new ParametrosCuadarado());
                    break;
                case 5:
                    grdParametrosFigura.Children.Add(new ParametrosTrapecio());
                    break;
               
                default:
                    break;
            }
        }

        private void BtnCalcularÁrea_Click(object sender, RoutedEventArgs e)
        {
            double area = 0.0;
            switch (cbfigura.SelectedIndex)
            {
                case 0: //Círculo
                    double radio = double.Parse(((ParametrosCirculo)(grdParametrosFigura.Children[0])).Radio.Text);
                    area = Math.PI * (radio * radio);
                    break;
                case 1: //Triángulo
                    double Base = double.Parse(((ParametrosTriangulo)(grdParametrosFigura.Children[0])).BaseT.Text);
                    double Altura = double.Parse(((ParametrosTriangulo)(grdParametrosFigura.Children[0])).AlturaT.Text);
                    area = (Base * Altura) / 2;
                    break;
                case 2: //Cuadrado
                    double lado = double.Parse(((ParametrosCuadarado)(grdParametrosFigura.Children[0])).Lado.Text);
                    area = (lado * lado);
                    break;
                case 3: //Rectángulo
                    double BaseRec = double.Parse(((ParametrosRectangulo)(grdParametrosFigura.Children[0])).BaseR.Text);
                    double AlturaRec = double.Parse(((ParametrosRectangulo)(grdParametrosFigura.Children[0])).AlturaR.Text);
                    area = (BaseRec * AlturaRec);
                    break;
                case 4: //Trapecio
                    double BaseMenor = double.Parse(((ParametrosTrapecio)(grdParametrosFigura.Children[0])).BaseMenor.Text);
                    double BaseMayor = double.Parse(((ParametrosTrapecio)(grdParametrosFigura.Children[0])).BaseMayor.Text);
                    double AlturaTra = double.Parse(((ParametrosTrapecio)(grdParametrosFigura.Children[0])).AlturaTr.Text);

                    area = ((BaseMenor + BaseMayor) * AlturaTra) / 2;
                    break;
                case 5: //Pentagono
                    grdParametrosFigura.Children.Add(new ParametrosPentagono());
                    double perimetro = double.Parse(((ParametrosPentagono)(grdParametrosFigura.Children[0])).Perimetro.Text);
                    double apotema = double.Parse(((ParametrosPentagono)(grdParametrosFigura.Children[0])).Apotema.Text);

                    area = ((perimetro * apotema) / 2);
                    break;
                default:
                    break;
            }
            txtresultado.Text = area.ToString();
        }
    }
}

