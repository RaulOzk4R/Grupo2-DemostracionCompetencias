using System;

namespace CinemaUcatec
{
    public class SistemaReservas
    {
        private ListaReservas listaReservas;
        private Sala[] salas;

        public SistemaReservas()
        {
            listaReservas = new ListaReservas();
            salas = new Sala[2]; // Ejemplo: 2 salas
            salas[0] = new Sala(1, 5, 5);
            salas[1] = new Sala(2, 6, 6);
        }

        public void MenuPrincipal()
        {
            int opcion;
            do
            {
                Console.WriteLine("\n--- Sistema de Reservas Cinema Ucatec ---");
                Console.WriteLine("1. Reservar asiento");
                Console.WriteLine("2. Cancelar reserva");
                Console.WriteLine("3. Mostrar asientos libres");
                Console.WriteLine("4. Mostrar reservas");
                Console.WriteLine("5. Salir");
                Console.WriteLine("6. Ordenar reservas por usuario");
                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1: Reservar(); break;
                    case 2: Cancelar(); break;
                    case 3: MostrarAsientos(); break;
                    case 4: listaReservas.MostrarReservas(); break;
                    case 6: listaReservas.OrdenarPorUsuario();
                         Console.WriteLine("✅ Reservas ordenadas por nombre de usuario.");
                        listaReservas.MostrarReservas();
                    break;
                }

            } while (opcion != 5);
        }

        private void Reservar()
        {
            Console.Write("Ingrese sala (1 o 2): ");
            int sala = int.Parse(Console.ReadLine()) - 1;
            Console.Write("Fila: ");
            int fila = int.Parse(Console.ReadLine());
            Console.Write("Columna: ");
            int columna = int.Parse(Console.ReadLine());
            Console.Write("Nombre del usuario: ");
            string usuario = Console.ReadLine();

            if (salas[sala].Reservar(fila, columna))
            {
                listaReservas.AgregarReserva(usuario, sala + 1, fila, columna);
                Console.WriteLine("✅ Reserva realizada con éxito.");
            }
            else
            {
                Console.WriteLine("⚠️ El asiento ya está ocupado.");
            }
        }

        private void Cancelar()
        {
            Console.Write("Ingrese sala (1 o 2): ");
            int sala = int.Parse(Console.ReadLine()) - 1;
            Console.Write("Fila: ");
            int fila = int.Parse(Console.ReadLine());
            Console.Write("Columna: ");
            int columna = int.Parse(Console.ReadLine());
            Console.Write("Nombre del usuario: ");
            string usuario = Console.ReadLine();

            if (salas[sala].Cancelar(fila, columna))
            {
                listaReservas.CancelarReserva(usuario, sala + 1, fila, columna);
                Console.WriteLine("✅ Reserva cancelada.");
            }
            else
            {
                Console.WriteLine("⚠️ Ese asiento no estaba reservado.");
            }
        }

        private void MostrarAsientos()
        {
            Console.Write("Ingrese sala (1 o 2): ");
            int sala = int.Parse(Console.ReadLine()) - 1;
            salas[sala].MostrarAsientos();
        }
    }
}