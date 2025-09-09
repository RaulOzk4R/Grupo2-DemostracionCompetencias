// Domain/Reserva.cs
using System;

namespace CinemaUcatec
{
    public sealed class Reserva
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string SalaId { get; }
        public int Fila { get; }
        public int Columna { get; }
        public string UsuarioNombre { get; }
        public DateTime FechaHora { get; } = DateTime.Now;

        public Reserva(string salaId, int fila, int columna, string usuarioNombre)
        {
            SalaId = salaId; Fila = fila; Columna = columna; UsuarioNombre = usuarioNombre;
        }

        public override string ToString()
            => $"{FechaHora:yyyy-MM-dd HH:mm} | Sala={SalaId} | ({Config.IndiceALetra(Fila)},{Config.IndiceALetra(Columna)}) | Usuario={UsuarioNombre} | Id={Id}";
    }
}
