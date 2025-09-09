// Core/Config.cs
using System;

namespace CinemaUcatec
{
    public static class Config
    {
        public const int NumeroSalas = 3;
        public const int Filas = 10;      
        public const int Columnas = 10;   
        public const char LetraMin = 'A';
        public const char LetraMax = 'J';

        public static int LetraAFilaIndice(char letra)
        {
            letra = char.ToUpperInvariant(letra);
            if (letra < LetraMin || letra > LetraMax)
                throw new ArgumentOutOfRangeException(nameof(letra), $"Letra fuera de rango ({LetraMin}-{LetraMax}).");
            return letra - LetraMin;
        }

        public static int LetraAColIndice(char letra)
        {
            // Simétrico: columnas también A..J
            return LetraAFilaIndice(letra);
        }

        public static char IndiceALetra(int idx)
        {
            if (idx < 0 || idx >= Filas) throw new ArgumentOutOfRangeException(nameof(idx));
            return (char)(LetraMin + idx);
        }
    }
}
