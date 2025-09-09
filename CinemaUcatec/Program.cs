// Program.cs
using System;

namespace CinemaUcatec
{
    public static class Program
    {
        static Cinema cinema = new();
        static ListaDobleReservas historial = new();
        static ReservaService svc = new(cinema, historial);

        public static void Main()
        {
            // Inicializamos EXACTAMENTE 3 salas de 10x10 (A..J x A..J)
            InicializarSalasFijas();

            bool salir = false;
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("=== Sistema de Reservas - Cinema UCATEC ===");
                Console.WriteLine("1) Listar salas");
                Console.WriteLine("2) Ver mapa de asientos");
                Console.WriteLine("3) Reservar asiento");
                Console.WriteLine("4) Cancelar reserva");
                Console.WriteLine("5) Ver ultimas reservas");
                Console.WriteLine("0) Salir");
                Console.Write("Opcion: ");
                var op = Console.ReadLine();

                try
                {
                    switch (op)
                    {
                        case "1": ListarSalas(); break;
                        case "2": VerMapa(); break;
                        case "3": Reservar(); break;
                        case "4": Cancelar(); break;
                        case "5": VerUltimas(); break;
                        case "0": salir = true; break;
                        default: Msg("Opción inválida."); break;
                    }
                }
                catch (Exception ex)
                {
                    Msg("⚠️ Error: " + ex.Message);
                }
            }
        }

        static void InicializarSalasFijas()
        {
            // 3 salas fijas S1, S2, S3 con 10x10 (A..J)
            cinema.AgregarSala(new Sala("S1", "Sala 1", Config.Filas, Config.Columnas));
            cinema.AgregarSala(new Sala("S2", "Sala 2", Config.Filas, Config.Columnas));
            cinema.AgregarSala(new Sala("S3", "Sala 3", Config.Filas, Config.Columnas));
        }

        static void ListarSalas()
        {
            Console.WriteLine("\nSalas registradas:");
            foreach (var s in cinema.ListarSalas())
                Console.WriteLine($"- {s.Id}: {s.Nombre} ({s.Filas}x{s.Columnas}) [A..J]");
            Pausa();
        }

        static void VerMapa()
        {
            var salaId = ElegirSala();
            Console.WriteLine();
            Console.WriteLine(svc.MapaAsientos(salaId));
            Pausa();
        }

        static void Reservar()
        {
            var salaId = ElegirSala();
            // Mostrar mapa automáticamente antes de pedir asiento
            Console.WriteLine();
            Console.WriteLine(svc.MapaAsientos(salaId));

            char filaLetra = LeerLetra("Fila (A-J)");
            char colLetra = LeerLetra("Columna (A-J)");

            int fila = Config.LetraAFilaIndice(filaLetra);
            int col  = Config.LetraAColIndice(colLetra);

            Console.Write("Nombre de usuario: ");
            var user = Console.ReadLine() ?? "Usuario";

            var r = svc.Reservar(salaId, fila, col, user);
            Msg($"✅ Reserva creada: {r}");
        }

        static void Cancelar()
        {
            var salaId = ElegirSala();
            // Mostrar mapa automáticamente antes de pedir asiento a cancelar
            Console.WriteLine();
            Console.WriteLine(svc.MapaAsientos(salaId));

            char filaLetra = LeerLetra("Fila (A-J)");
            char colLetra  = LeerLetra("Columna (A-J)");

            int fila = Config.LetraAFilaIndice(filaLetra);
            int col  = Config.LetraAColIndice(colLetra);

            svc.Cancelar(salaId, fila, col);
            Msg("✅ Reserva cancelada (asiento liberado).");
        }

        static void VerUltimas()
        {
            int n = LeerEntero("¿Cuántas mostrar? (ej. 10)");
            Console.WriteLine();
            foreach (var r in svc.UltimasReservas(n))
                Console.WriteLine(r);
            Pausa();
        }

        // ==== Helpers ====
        static int LeerEntero(string etiqueta)
        {
            while (true)
            {
                Console.Write($"{etiqueta}: ");
                if (int.TryParse(Console.ReadLine(), out int v))
                    return v;
                Console.WriteLine("Valor inválido. Intenta de nuevo.");
            }
        }

        static string ElegirSala()
        {
            while (true)
            {
                Console.Write("Id de sala (S1/S2/S3): ");
                var id = (Console.ReadLine() ?? "").Trim().ToUpperInvariant();
                if (id == "S1" || id == "S2" || id == "S3") return id;
                Console.WriteLine("Id inválido. Usa S1, S2 o S3.");
            }
        }

        static char LeerLetra(string etiqueta)
        {
            while (true)
            {
                Console.Write($"{etiqueta}: ");
                var txt = (Console.ReadLine() ?? "").Trim().ToUpperInvariant();
                if (txt.Length == 1 && txt[0] >= Config.LetraMin && txt[0] <= Config.LetraMax)
                    return txt[0];
                Console.WriteLine($"Entrada inválida. Debe ser una letra entre {Config.LetraMin} y {Config.LetraMax}.");
            }
        }

        static void Msg(string txt)
        {
            Console.WriteLine("\n" + txt);
            Pausa();
        }

        static void Pausa()
        {
            Console.WriteLine("\nPresiona ENTER para continuar...");
            Console.ReadLine();
        }
    }
}

