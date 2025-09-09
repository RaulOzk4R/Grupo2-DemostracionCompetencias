// Core/Cinema.cs
using System.Collections.Generic;

namespace CinemaUcatec
{
    public sealed class Cinema
    {
        private readonly Dictionary<string, Sala> _salas = new();
        public IReadOnlyDictionary<string, Sala> Salas => _salas;

        public void AgregarSala(Sala sala)
        {
            if (_salas.ContainsKey(sala.Id)) throw new System.InvalidOperationException("Ya existe una sala con ese Id.");
            _salas.Add(sala.Id, sala);
        }

        public Sala GetSala(string salaId)
        {
            if (!_salas.TryGetValue(salaId, out var sala))
                throw new System.Collections.Generic.KeyNotFoundException("Sala no encontrada.");
            return sala;
        }

        public IEnumerable<Sala> ListarSalas() => _salas.Values;
    }
}
