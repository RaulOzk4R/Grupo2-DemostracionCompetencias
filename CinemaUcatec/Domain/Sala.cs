// Domain/Sala.cs
using System;
using System.Collections.Generic;

namespace CinemaUcatec
{
    public sealed class Sala
    {
        public string Id { get; }
        public string Nombre { get; }
        public int Filas { get; }
        public int Columnas { get; }
        private readonly Asiento[,] _asientos;

        public Sala(string id, string nombre, int filas, int columnas)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException("Id de sala requerido.");
            if (string.IsNullOrWhiteSpace(nombre)) throw new ArgumentException("Nombre de sala requerido.");
            if (filas <= 0 || columnas <= 0) throw new ArgumentException("Dimensiones inválidas.");

            Id = id.Trim();
            Nombre = nombre.Trim();
            Filas = filas; Columnas = columnas;
            _asientos = new Asiento[filas, columnas];
            for (int f = 0; f < filas; f++)
                for (int c = 0; c < columnas; c++)
                    _asientos[f, c] = new Asiento(f, c);
        }

        public Asiento GetAsiento(int fila, int columna)
        {
            if (fila < 0 || fila >= Filas || columna < 0 || columna >= Columnas)
                throw new IndexOutOfRangeException("Asiento fuera de rango.");
            return _asientos[fila, columna];
        }

        public IEnumerable<Asiento> EnumerarAsientos()
        {
            for (int f = 0; f < Filas; f++)
                for (int c = 0; c < Columnas; c++)
                    yield return _asientos[f, c];
        }
    }
}
