// DataStructures/NodoReserva.cs
namespace CinemaUcatec
{
    public sealed class NodoReserva
    {
        public Reserva Valor { get; }
        public NodoReserva? Anterior { get; set; }
        public NodoReserva? Siguiente { get; set; }
        public NodoReserva(Reserva valor) { Valor = valor; }
    }
}
