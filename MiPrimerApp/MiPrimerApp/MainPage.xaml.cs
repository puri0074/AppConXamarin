using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MiPrimerApp
{
    public partial class MainPage : ContentPage
    {
        double numeroActual = 0;
        string operacionActual = "";
        bool seDebeLimpiar = false;

        public MainPage()
        {
            InitializeComponent();
        }

        // Manejador de eventos para los botones de los números
        private void Numero_Clicked(object sender, EventArgs e)
        {
            if (seDebeLimpiar)
            {
                ResultadoLabel.Text = "0";
                seDebeLimpiar = false;
            }

            Button button = (Button)sender;
            string numeroPresionado = button.Text;

            if (ResultadoLabel.Text == "0")
            {
                ResultadoLabel.Text = numeroPresionado;
            }
            else
            {
                ResultadoLabel.Text += numeroPresionado;
            }
        }

        // Manejador de eventos para los botones de las operaciones
        private void Operacion_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operacionActual = button.Text;

            if (!string.IsNullOrEmpty(ResultadoLabel.Text))
            {
                numeroActual = double.Parse(ResultadoLabel.Text);
                seDebeLimpiar = true;
            }
        }

        // Manejador de eventos para el botón de limpiar
        private void Limpiar_Clicked(object sender, EventArgs e)
        {
            ResultadoLabel.Text = "0";
            numeroActual = 0;
            operacionActual = "";
            seDebeLimpiar = false;
        }

        // Manejador de eventos para el botón de igual
        private void Igual_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(operacionActual) && !seDebeLimpiar)
            {
                double resultado = 0;
                double segundoNumero = double.Parse(ResultadoLabel.Text);

                switch (operacionActual)
                {
                    case "+":
                        resultado = numeroActual + segundoNumero;
                        break;
                    case "-":
                        resultado = numeroActual - segundoNumero;
                        break;
                    case "*":
                        resultado = numeroActual * segundoNumero;
                        break;
                    case "/":
                        if (segundoNumero != 0)
                            resultado = numeroActual / segundoNumero;
                        else
                            DisplayAlert("Error", "No se puede dividir entre cero", "Aceptar");
                        break;
                }

                ResultadoLabel.Text = resultado.ToString();
                seDebeLimpiar = true;
            }
        }
    }
}
