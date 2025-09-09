// Services/ReservaService.cs
using System.Text;
using System.Collections.Generic;

namespace CinemaUcatec
{
    public sealed class ReservaService
    {
        private readonly Cinema _cinema;
        private readonly ListaDobleReservas _historial;

        public ReservaService(Cinema cinema, ListaDobleReservas historial)
        {
            _cinema = cinema; _historial = historial;
        }

        public Reserva Reservar(string salaId, int fila, int columna, string usuario)
        {
            var sala = _cinema.GetSala(salaId);
            var asiento = sala.GetAsiento(fila, columna);
            if (asiento.Estado == EstadoAsiento.Ocupado) throw new System.InvalidOperationException("Ese asiento ya está ocupado.");

            var r = new Reserva(salaId, fila, columna, usuario);
            asiento.Ocupar(r.Id);
            _historial.AgregarAlFinal(r);
            return r;
        }

        public void Cancelar(string salaId, int fila, int columna)
        {
            var sala = _cinema.GetSala(salaId);
            var asiento = sala.GetAsiento(fila, columna);
            asiento.Liberar();
        }

        // Mapa con letras A..J en cabeceras y laterales
        public string MapaAsientos(string salaId)
        {
            var sala = _cinema.GetSala(salaId);
            var sb = new StringBuilder();
            sb.AppendLine($"Sala {sala.Nombre} [{sala.Filas}x{sala.Columnas}]");

            // Cabecera columnas
            sb.Append("   ");
            for (int c = 0; c < sala.Columnas; c++) sb.Append($" {Config.IndiceALetra(c)} ");
            sb.AppendLine();

            for (int f = 0; f < sala.Filas; f++)
            {
                // Etiqueta fila
                sb.Append($" {Config.IndiceALetra(f)} ");
                for (int c = 0; c < sala.Columnas; c++)
                {
                    var a = sala.GetAsiento(f, c);
                    sb.Append(a.Estado == EstadoAsiento.Libre ? " L " : " X ");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public IEnumerable<Reserva> UltimasReservas(int cantidad)
            => _historial.RecorrerDesdeFin(cantidad);
    }
}
