using HundirLaFlota.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace HundirLaFlota.Servicios
{
    public class AtaqueServicio
    {

        private readonly Tablero _tablero;
        private List<(int, bool)> barcosHundidos { get; set; }
        private int[,] PosicionesAtacadas { get; set; }

        public AtaqueServicio(Tablero tablero)
        {
            _tablero = tablero;
            PosicionesAtacadas = new int[_tablero.Anchura, _tablero.Altura];

        }

        /// <summary>
        /// Algoritmo para calcular la forma mas rapida de detectar todos los barcos en _tablero.Mapa
        /// </summary>
        public void Atacar()
        {
            var test = true;   
        }
    }
}
