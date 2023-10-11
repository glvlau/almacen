using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace almacen
{
    class ExtraerDatos{

       static public Dictionary<string, Dictionary<int,int>> Diccionario(string ruta) {
           Dictionary<string, Dictionary<int, int>> stock = new Dictionary<string, Dictionary<int, int>>();

           using (StreamReader stocks = new StreamReader(ruta))
           {
               string line;
               while ((line = stocks.ReadLine()) != null)
               {
                   string[] partes = line.Split(';');

                   if (partes.Length == 2)
                   {
                       string clave = partes[0];
                       int valor1, valor2;

                       if (int.TryParse(partes[1], out valor1) && int.TryParse(partes[2], out valor2))
                       {
                           Dictionary<int, int> diccionarioInterno = new Dictionary<int, int>
                        {
                            { valor1, valor2 }
                        };

                           stock[clave] = diccionarioInterno;
                       }
                   }
               }
           }
           return stock;
        }
    }
}
