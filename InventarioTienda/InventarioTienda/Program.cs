using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace InventarioTienda
{
    class producto
    {
        public int Stock { get; set; }
        public double Precio { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, producto> inventario = new Dictionary<string, producto>();
            string nombre;
            bool exit = false;
            Console.WriteLine("|================================================|");
            Console.WriteLine("|Bienvenido al sistema de inventario de la tienda|");
            Console.WriteLine("|================================================|\n");
            while (!exit)
            {
                Console.WriteLine("Indique la accion que quiere realizar");
                Console.WriteLine("=====================================");
                Console.WriteLine("1. Agregar producto");
                Console.WriteLine("2. Actualizar stock");
                Console.WriteLine("3. Consultar inventario");
                Console.WriteLine("4. Salir de la aplicacion\n");
                int respuesta = Convert.ToInt16(Console.ReadLine());

                switch (respuesta)
                {
                    case 1:
                        Console.WriteLine();
                        Console.WriteLine("Ingrese el nombre del producto en su defecto escriba (volver)\n");
                        nombre = Console.ReadLine().ToLower();
                        while (nombre != "volver")
                        {
                            Console.WriteLine("Ingrese el stock inicial\n");
                            int stock = Convert.ToInt16(Console.ReadLine());
                            Console.WriteLine();
                            Console.WriteLine("Ingrese el precio del producto\n");
                            double precio = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine();
                            inventario[nombre] = new producto { Stock = stock, Precio = precio };
                            Console.WriteLine("Producto Agregado\n");
                            Console.WriteLine("Ingrese otro poroducto en su defecto escriba (volver)\n");
                            nombre = Console.ReadLine();
                            Console.WriteLine();
                        }
                        break;
                    case 2:
                        Console.WriteLine();
                        Console.WriteLine("Ingrese el produto que quiere actualizar en su defecto escriba (volver)\n");
                        nombre = Console.ReadLine().ToLower();
                        Console.WriteLine();
                        while (nombre != "volver")
                        {
                            if (inventario.ContainsKey(nombre))
                            {
                                Console.WriteLine("Ingrese el nuevo stock\n");
                                int stock = Convert.ToInt16(Console.ReadLine());
                                Console.WriteLine();
                                inventario[nombre].Stock = stock;
                                Console.WriteLine("Stock actualizado\n");
                            }
                            else
                            {
                                try
                                {
                                    Console.WriteLine("El producto no existe");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    {

                                    }
                                }
                            }
                            Console.WriteLine("Ingrese otro producto en su defecto escriba (volver)\n");
                            nombre = Console.ReadLine();
                            Console.WriteLine();
                        }
                        break;
                    case 3:
                        Console.WriteLine();
                        Console.WriteLine("Inventario: \n");
                        foreach (var item in inventario)
                        {
                            Console.WriteLine($"Producto: {item.Key}, Stock: {item.Value.Stock}, Precio: {item.Value.Precio}");
                        }
                        Console.WriteLine();
                        break;
                    case 4:
                        Console.WriteLine();
                        Console.WriteLine("Saliendo de la aplicacion...");
                        exit = true;
                        break;
                }
            }
        }
    }
}
