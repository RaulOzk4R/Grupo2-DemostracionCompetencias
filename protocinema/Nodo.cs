namespace CinemaUcatec
{
    public class Nodo
    {
        public string Usuario { get; set; }
        public int Sala { get; set; }
        public int Fila { get; set; }
        public int Columna { get; set; }
        public Nodo Anterior { get; set; }
        public Nodo Siguiente { get; set; }

        public Nodo(string usuario, int sala, int fila, int columna)
        {
            Usuario = usuario;
            Sala = sala;
            Fila = fila;
            Columna = columna;
            Anterior = null;
            Siguiente = null;
        }
    }
}