using System;
using System.Collections.Generic;
using System.Linq;

namespace HundirLaFlota.DTOs
{
    public class Tablero
    {
        private readonly int _altura;
        private readonly int _anchura;
        private readonly int[,] _mapa;
        private IReadOnlyCollection<Barco> Barcos;
        public int[,] Mapa => _mapa;
        public int Altura => _altura;
        public int Anchura => _anchura;

        public Tablero(int size, IReadOnlyCollection<Barco> barcos)
        {
            _altura = size;
            _anchura = size;
            Barcos = barcos;
            _mapa = new int[_altura, _anchura];
            foreach (Barco barco in barcos)
            {
                foreach (var p in barco.Posiciones)
                {
                    _mapa[p.Item1, p.Item2] = 1;
                }
            }

        }

        /// <summary>
        /// Coge la lsita de barcos del mapa.
        /// por ejemplo si tenemos dos barcos de tamaño 3 devuelve.
        /// 3,2
        /// </summary>
        public IReadOnlyCollection<(int, int)> GetBarcos()
        {
            return Barcos.GroupBy(a => a.Size).Select(a => ((int)a.Key, a.ToList().Count)).ToList().AsReadOnly();
        }

        public bool GolpearBarco(int x, int y)
        {
            return Barcos.Any(a => a.BarcoGolpeado(x, y));
        }

    }


    public static class TableroUtils
    {
        public static void DibujarTablero(this Tablero tablero)
        {
            for (int y = 0; y < tablero.Altura; y++)
            {
                for (int x = 0; x < tablero.Anchura; x++)
                {
                    CambiarColor(tablero.Mapa[x, y]);

                    Console.Write($"{tablero.Mapa[x, y]}");
                }
                Console.Write("\n");
            }

            void CambiarColor(int valor)
            {
                Console.ResetColor();
                if (valor == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
            }
        }
    }

}
