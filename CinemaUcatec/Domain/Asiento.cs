// Domain/Asiento.cs
using System;

namespace CinemaUcatec
{
    public sealed class Asiento
    {
        public int Fila { get; }
        public int Columna { get; }
        public EstadoAsiento Estado { get; private set; } = EstadoAsiento.Libre;
        public Guid? ReservaId { get; private set; }

        public Asiento(int fila, int columna)
        {
            Fila = fila; Columna = columna;
        }

        public void Ocupar(Guid reservaId)
        {
            if (Estado == EstadoAsiento.Ocupado) throw new InvalidOperationException("El asiento ya está ocupado.");
            Estado = EstadoAsiento.Ocupado;
            ReservaId = reservaId;
        }

        public void Liberar()
        {
            if (Estado == EstadoAsiento.Libre) throw new InvalidOperationException("El asiento ya está libre.");
            Estado = EstadoAsiento.Libre;
            ReservaId = null;
        }
    }
}
