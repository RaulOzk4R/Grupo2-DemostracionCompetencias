namespace CinemaUcatec
{
    public class Sala
    {
        public int NumeroSala { get; set; }
        public bool[,] Asientos { get; set; }

        public Sala(int numeroSala, int filas, int columnas)
        {
            NumeroSala = numeroSala;
            Asientos = new bool[filas, columnas];
        }

        public bool Reservar(int fila, int columna)
        {
            if (!Asientos[fila, columna])
            {
                Asientos[fila, columna] = true;
                return true;
            }
            return false;
        }

        public bool Cancelar(int fila, int columna)
        {
            if (Asientos[fila, columna])
            {
                Asientos[fila, columna] = false;
                return true;
            }
            return false;
        }

        public void MostrarAsientos()
        {
            for (int i = 0; i < Asientos.GetLength(0); i++)
            {
                for (int j = 0; j < Asientos.GetLength(1); j++)
                {
                    Console.Write(Asientos[i, j] ? "[X] " : "[ ] ");
                }
                Console.WriteLine();
            }
        }
    }
}