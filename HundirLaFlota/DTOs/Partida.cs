using System;
using System.Collections.Generic;
using System.Text;

namespace HundirLaFlota.DTOs
{
    public class Partida
    {
        public readonly Tablero Tablero;
        public readonly List<EstadoBarco> Barcos;



    }

    public class EstadoBarco
    {
        private bool _activo { get; set; }
        public Barco Barco { get; set; }
        public int[,] Golpes { get; set; }
        public bool IsHundido => !_activo;

        public EstadoBarco(Barco barco)
        {
            Barco = barco;
            _activo = false;
            Golpes = new int[(int)barco.Size, (int)barco.Size];
        }

    }
}
