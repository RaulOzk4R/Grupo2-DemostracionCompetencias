// DataStructures/ListaDobleReservas.cs
using System.Collections.Generic;

namespace CinemaUcatec
{
    public sealed class ListaDobleReservas
    {
        public NodoReserva? Cabeza { get; private set; }
        public NodoReserva? Cola { get; private set; }
        public int Conteo { get; private set; }

        public void AgregarAlFinal(Reserva r)
        {
            var nodo = new NodoReserva(r);
            if (Cola == null) { Cabeza = Cola = nodo; }
            else { Cola.Siguiente = nodo; nodo.Anterior = Cola; Cola = nodo; }
            Conteo++;
        }

        public IEnumerable<Reserva> RecorrerDesdeInicio()
        {
            for (var n = Cabeza; n != null; n = n.Siguiente) yield return n.Valor;
        }

        public IEnumerable<Reserva> RecorrerDesdeFin(int max = int.MaxValue)
        {
            int k = 0;
            for (var n = Cola; n != null && k < max; n = n.Anterior, k++) yield return n.Valor;
        }
    }
}
