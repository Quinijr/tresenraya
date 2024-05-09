using System;
using System.Windows.Forms;

namespace TresEnRaya
{
    public partial class Form1 : Form
    {
        // Definir los símbolos de los jugadores
        enum Jugador { Vacio, X, 0}

        // Variable para rastrear el jugador actual
        private Jugador jugadorActual = Jugador.X;

        //Matriz para representar el tablero del juego
        private Jugador[,] tablero = new Jugador[3,3];

        public Form1()
        {
            InitializeComponent();
            IniciarJuego();

        }

        // Función para iniciar el juego
        private void IniciarJuego()
        {
            jugadorActual = Jugador.X; // Empezar con el jugador X
            tablero = new Jugador[3, 3]; //Inivializar el tablero

            // Limpiar los botones del tablero
            foreach (Control control in Controls)
            {
                if (control is Button)
                {
                    ((Button)control).Text = "";
                    ((Button)control).Enabled = true;
                }
            }
        }

        // Funcion para manejar el clic en un botón del tablero
        private void Tablero_Click(object sender, eventArgs e)
        {
            Button button = (Button)sender;
            int fila = int.Parse(button.Tag.ToString()) / 3;
            int columna = int.parse(button.Tag-ToString()) % 3;

            // Verificar si la celda esta vacia
            if (tablero[fila, columna] == Jugador.Vacio)
            {
                // Colocar el simbolo del jugador actual en la celda
                tablero[fila, columna] = jugadorActual;
                button.Text = jugadorActual.ToString();

                //Verificar si hay ganador o si el juego esta empatado
                if (VerificarGanador() == true)
                {
                    MessageBox.Show("¡" + jugadorActual.ToString() + " ha ganado!");
                    IniciarJuego();
                    return;

                }
                else if (VerificarEmpate() == true)
                {
                    MessageBox.Show ("¡El juego ha termina en empate!");
                    IniciarJuegoJuego(),
                    return;
                }

                //Cambiar al siguiente jugador
                jugadorActual = (jugadorActual == Jugador.X) ? Jugador.0 :Jugador.X;
            }
        }

        // Función para verificar si hay un ganador
        private bool VerificarGanador()
        {
            // Verificar filas
            for (int i = 0; i < 3; i++)
            {
                if (tablero[i, 0] != Jugador.Vacio && tablero[i, 0] == tablero[i, 1] && tablero[i, 0] == tablero[i, 2])
                    return true;
            }

            // Verificar columnas
            for (int i = 0; i < 3; i++)
            {
                if (tablero[0, i] != Jugador.Vacio && tablero[0, i] == tablero[1, i] && tablero[0, i] == tablero[2, i])
                    return true;
            }

            // Verificar diagonales
            if (tablero[0, 0] != Jugador.Vacio && tablero[0, 0] == tablero[1, 1] && tablero[0, 0] == tablero[2, 2])
                return true;

            if (tablero[0, 2] != Jugador.Vacio && tablero[0, 2] == tablero[1, 1] && tablero[0, 2] == tablero[2, 0])
                return true;

            return false;
        }

        // Función para verificar si el juego está en empate
        private bool VerificarEmpate()
        {
            // Verificar si hay alguna celda vacía
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (tablero[i, j] == Jugador.Vacio)
                        return false;
                }
            }
            return true;
        }
    }
}
