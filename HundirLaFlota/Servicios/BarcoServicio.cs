using HundirLaFlota.DTOs;
using HundirLaFlota.DTOs.Enums;
using System;
using System.Collections.Generic;

namespace HundirLaFlota.Servicios
{
    public class BarcoServicio
    {
        public List<Barco> GenerarBarcos(int tableroSize, int numeroBarcos)
        {
            List<Barco> barcos = new List<Barco>();

            for (int i = 0; i < numeroBarcos; i++)
            {
                switch (i)
                {
                    case 0:
                        GenerarBarco(barcos, tableroSize, 2);
                        break;
                    case 1:
                    case 2:
                        GenerarBarco(barcos, tableroSize, 3);
                        break;
                    case 3:
                    case 4:
                        GenerarBarco(barcos, tableroSize, 4);
                        break;
                    case 5:
                        GenerarBarco(barcos, tableroSize, 5);
                        break;
                    default:
                        throw new NotImplementedException("El número máximo de barcos es 5");
                }
            }
            return barcos;

        }


        private void GenerarBarco(List<Barco> barcos, int tableroSize, int barcosize)
        {
            (int, int, Direccion) posiciones = GenerarRandomPosition(tableroSize);

            Barco barco = new Barco(posiciones.Item1, posiciones.Item2, (SizeBarco)barcosize, posiciones.Item3);


            if (barco.Colisiona(barcos) || FueraDeLosLimites(posiciones.Item1, posiciones.Item2, (SizeBarco)barcosize, tableroSize))
            {
                GenerarBarco(barcos, tableroSize, barcosize);
            }
            else
            {
                barcos.Add(barco);
                return;
            }


        }

        private (int, int, Direccion) GenerarRandomPosition(int tableroSize)
        {
            Random rand = new Random();
            Direccion direccion = (Direccion)rand.Next(2);
            var x = rand.Next(tableroSize - 1);
            var y = rand.Next(tableroSize - 1);
            return (x, y, direccion);

        }

        private bool FueraDeLosLimites(int x, int y, SizeBarco sizeBarco, int tablerosize)
        {
            return Limite(x) || Limite(y);

            bool Limite(int posicion)
            {
                return posicion + (int)sizeBarco >= tablerosize;
            }
        }

    }
}
