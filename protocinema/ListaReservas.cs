using System;

namespace CinemaUcatec
{
    public class ListaReservas
    {
        private Nodo inicio;
        private Nodo fin;

        public ListaReservas()
        {
            inicio = null;
            fin = null;
        }

        public void AgregarReserva(string usuario, int sala, int fila, int columna)
        {
            Nodo nuevo = new Nodo(usuario, sala, fila, columna);

            if (inicio == null)
            {
                inicio = nuevo;
                fin = nuevo;
            }
            else
            {
                fin.Siguiente = nuevo;
                nuevo.Anterior = fin;
                fin = nuevo;
            }
        }

        public void CancelarReserva(string usuario, int sala, int fila, int columna)
        {
            Nodo actual = inicio;
            while (actual != null)
            {
                if (actual.Usuario == usuario && actual.Sala == sala &&
                    actual.Fila == fila && actual.Columna == columna)
                {
                    if (actual.Anterior != null)
                        actual.Anterior.Siguiente = actual.Siguiente;
                    else
                        inicio = actual.Siguiente;

                    if (actual.Siguiente != null)
                        actual.Siguiente.Anterior = actual.Anterior;
                    else
                        fin = actual.Anterior;

                    return;
                }
                actual = actual.Siguiente;
            }
        }

        public void MostrarReservas()
        {
            Nodo actual = inicio;
            while (actual != null)
            {
                Console.WriteLine($"Usuario: {actual.Usuario} | Sala: {actual.Sala} | Asiento: ({actual.Fila},{actual.Columna})");
                actual = actual.Siguiente;
            }
        }
        public void OrdenarPorUsuario()
{
    if (inicio == null) return;

    bool cambiado;
    do
    {
        cambiado = false;
        Nodo actual = inicio;

        while (actual.Siguiente != null)
        {
            // Comparar usuarios alfabéticamente
            if (string.Compare(actual.Usuario, actual.Siguiente.Usuario, StringComparison.OrdinalIgnoreCase) > 0)
            {
                // Intercambiar datos de nodos (sin cambiar punteros)
                string tempUsuario = actual.Usuario;
                int tempSala = actual.Sala;
                int tempFila = actual.Fila;
                int tempColumna = actual.Columna;

                actual.Usuario = actual.Siguiente.Usuario;
                actual.Sala = actual.Siguiente.Sala;
                actual.Fila = actual.Siguiente.Fila;
                actual.Columna = actual.Siguiente.Columna;

                actual.Siguiente.Usuario = tempUsuario;
                actual.Siguiente.Sala = tempSala;
                actual.Siguiente.Fila = tempFila;
                actual.Siguiente.Columna = tempColumna;

                cambiado = true;
            }
            actual = actual.Siguiente;
        }

        } while (cambiado);
    }
    }
}