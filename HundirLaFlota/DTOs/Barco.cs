using HundirLaFlota.DTOs.Enums;
using System.Collections.Generic;
using System.Linq;

namespace HundirLaFlota.DTOs
{
    public class Barco
    {
        public readonly int PositionX;
        public readonly int PositionY;
        public readonly SizeBarco Size;
        private readonly Direccion _direccion;
        public IReadOnlyCollection<(int, int)> Posiciones => PosicionesReservadas();

        public Barco(int x, int y, SizeBarco size, Direccion direccion)
        {
            PositionX = x;
            PositionY = y;
            Size = size;//-1 porque la primera posicion son x,y
            _direccion = direccion;

        }

        public bool BarcoGolpeado(int x, int y)
        {
            return Posiciones.Any(a => a.Item1 == x && a.Item2 == y);
        }

        private IReadOnlyCollection<(int, int)> PosicionesReservadas()
        {
            List<(int, int)> posiciones = new List<(int, int)>();
            posiciones.Add((PositionX, PositionY));
            int virtualX = PositionX;
            int virtualY = PositionY;
            for (int i = 0; i < ((int)Size)-1; i++)
            {
                if (_direccion == Direccion.Horizontal)
                    virtualX++;
                else
                    virtualY++;

                posiciones.Add((virtualX, virtualY));
            }

            return posiciones;
        }
    }

    public static class BarcoUtils
    {

        public static bool Colisiona(this Barco barco, List<Barco> barcos)
        {
            if (barcos.Count == 0)
                return false;

            foreach (Barco b in barcos)
            {
                foreach ((int, int) posicion in barco.Posiciones)
                {
                    if (b.Posiciones.Any(x => x.Item1 == posicion.Item1 && x.Item2 == posicion.Item2))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

    }
}
