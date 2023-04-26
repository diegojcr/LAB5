using LAB5.Models;
using LAB5.ArbolesMulticaminos;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Components.Forms;
using System.Reflection.Metadata.Ecma335;
using Microsoft.Extensions.Options;

namespace LAB5.ArbolesMulticaminos
{
	public class Arbol23
	{

		public static List<Nodo23> lsd = new List<Nodo23>();
        static List<Carros> list = new List<Carros>();

        public static Nodo23 raiz { get; set; }

		public void Eliminar(Nodo23 nodo, Carros valor)
		{
			if (nodo.HijoIzquierdo == null && nodo.HijoMedio == null && nodo.HijoDerecho == null)
			{
				if (raiz == null)
				{
					return;
				}

				eliminarplacahoja(raiz, valor);

			}
			else if (nodo.HijoIzquierdo != null && nodo.HijoMedio == null && nodo.HijoDerecho == null || nodo.HijoIzquierdo == null && nodo.HijoMedio != null && nodo.HijoDerecho == null || nodo.HijoIzquierdo == null && nodo.HijoMedio == null && nodo.HijoDerecho != null)
			{
				if (raiz == null)
				{
					return;
				}

				raiz = eliminarplacahijo(raiz, valor);

			}

			else if (nodo.HijoIzquierdo != null && nodo.HijoMedio != null && nodo.HijoDerecho == null || nodo.HijoIzquierdo != null && nodo.HijoMedio == null && nodo.HijoDerecho != null || nodo.HijoIzquierdo == null && nodo.HijoMedio != null && nodo.HijoDerecho != null || nodo.HijoIzquierdo != null && nodo.HijoMedio != null && nodo.HijoDerecho != null)
			{
				raiz = eliminarplaca23hijos(raiz, valor);
			}
		}

		public static void insertar(Carros valor)
		{
            list.Add(valor);
            /*if (raiz == null)
            {
                raiz = new Nodo23(valor);
                return;
            }

            InsertarPlaca(raiz, valor);*/
        }
		

		public static Nodo23 InsertarPlaca(Nodo23 nodo, Carros valor)
		{

        if (nodo == null)
        {
            if (string.Compare(valor.placa, nodo.valor.placa) < nodo.valor1)
            {
                nodo.valor2 = nodo.valor1;
                nodo.valor1 = Convert.ToInt32(valor.placa);

            }
            else
            {
                nodo.valor2 = Convert.ToInt32(valor.placa);
            }

            return nodo;
        }
        else
        {
            if (string.Compare(valor.placa, nodo.valor.placa) < nodo.valor1)
            {
                nodo.HijoIzquierdo = InsertarPlaca(nodo.HijoIzquierdo, valor);
            }
            else if (string.Compare(valor.placa, nodo.valor.placa) > nodo.valor2)
            {
                nodo.HijoDerecho = InsertarPlaca(nodo.HijoDerecho, valor);
            }

            else
            {
                nodo.HijoMedio = InsertarPlaca(nodo.HijoMedio, valor);
            }

            if (nodo.HijoIzquierdo != null && nodo.HijoMedio != null && nodo.HijoDerecho != null)
            {
                Nodo23 nuevonodo = new Nodo23(nodo.valor2.Value);
                nuevonodo.HijoIzquierdo = nodo.HijoIzquierdo;
                nuevonodo.HijoMedio = nodo.HijoMedio;
                nuevonodo.HijoDerecho = nodo.HijoDerecho;
                nuevonodo.HijoIzquierdo.Padre = nuevonodo;
                nuevonodo.HijoMedio.Padre = nuevonodo;
                nuevonodo.HijoDerecho.Padre = nuevonodo;
                nodo = nuevonodo;

            }

            return nodo;
        }


    }

		public Nodo23 eliminarplacahoja(Nodo23 nodo, Carros valor)
		{
			if (nodo == null)
			{
				return null;
			}

			if (string.Compare(valor.placa, nodo.valor.placa) < nodo.valor1)
			{
				eliminarplacahoja(nodo.HijoIzquierdo, valor);
			}
			else if (nodo.valor2 == null || string.Compare(valor.placa, nodo.valor.placa) < nodo.valor2)
			{
				eliminarplacahoja(nodo.HijoMedio, valor);
			}
			else
			{
				eliminarplacahoja(nodo.HijoDerecho, valor);
			}

			if (nodo.HijoIzquierdo == null && nodo.HijoMedio == null && nodo.HijoDerecho == null)
			{
				if (nodo.Padre == null)
				{
					raiz = null;
				}
				else if (nodo.Padre.HijoIzquierdo == nodo)
				{
					nodo.Padre.HijoIzquierdo = null;
				}
				else if (nodo.Padre.HijoMedio == nodo)
				{
					nodo.Padre.HijoMedio = null;
				}
				else
				{
					nodo.Padre.HijoDerecho = null;
				}

				nodo = null;

			}

			return null;
		}

		public Nodo23 eliminarplacahijo(Nodo23 nodo, Carros valor)
		{
			if (string.Compare(valor.placa, nodo.valor.placa) < nodo.valor1)
			{
				nodo.HijoIzquierdo = eliminarplacahijo(nodo.HijoIzquierdo, valor);
				return nodo;
			}

			else if (string.Compare(valor.placa, nodo.valor.placa) > nodo.valor1 && nodo.valor2 == null)
			{
				nodo.HijoDerecho = eliminarplacahijo(nodo.HijoMedio, valor);
				return nodo;
			}

			else if (string.Compare(valor.placa, nodo.valor.placa) > nodo.valor2)
			{
				nodo.HijoMedio = eliminarplacahijo(nodo.HijoMedio, valor);
				return nodo;
			}

			if (nodo.HijoIzquierdo != null && nodo.HijoMedio == null && nodo.HijoDerecho == null)
			{
				if (nodo.HijoIzquierdo.valor2 != null)
				{
					nodo.valor1 = nodo.HijoIzquierdo.valor2.Value;
					nodo.HijoIzquierdo.valor2 = null;
				}
				else
				{
					nodo.valor1 = nodo.HijoIzquierdo.valor2.Value;
					nodo.HijoIzquierdo = null;

				}
				return nodo;
			}

			else if (nodo.HijoMedio != null && nodo.HijoIzquierdo == null && nodo.HijoDerecho == null)
			{
				if (nodo.HijoMedio.valor2 != null)
				{
					nodo.valor1 = nodo.HijoMedio.valor2.Value;
					nodo.HijoMedio.valor2 = null;
				}
				else
				{
					nodo.valor1 = nodo.HijoMedio.valor1;
					nodo.HijoMedio = null;
				}

				return nodo;
			}

			else if (nodo.HijoDerecho != null && nodo.HijoIzquierdo == null && nodo.HijoMedio == null)
			{
				if (nodo.HijoDerecho.valor2 != null)
				{
					nodo.valor1 = nodo.HijoDerecho.valor1;
					nodo.valor2 = nodo.HijoDerecho.valor2.Value;
					nodo.HijoDerecho.valor2 = null;
				}
				else
				{
					nodo.valor1 = nodo.HijoDerecho.valor1;
					nodo.HijoDerecho = null;
				}

				return nodo;
			}

			return nodo;
		}

		public Nodo23 eliminarplaca23hijos(Nodo23 nodo, Carros valor)
		{
			if (nodo == null)
			{
				return null;
			}

			if (string.Compare(valor.placa, nodo.valor.placa) < nodo.valor1)
			{
				nodo.HijoIzquierdo = eliminarplaca23hijos(nodo.HijoIzquierdo, valor);

			}

			else if (nodo.valor2 == null || string.Compare(valor.placa, nodo.valor.placa) < nodo.valor2)
			{
				nodo.HijoMedio = eliminarplaca23hijos(nodo.HijoMedio, valor);
			}
			
			else if(string.Compare(valor.placa, nodo.valor.placa) > nodo.valor2)
			{
				nodo.HijoDerecho = eliminarplaca23hijos(nodo.HijoDerecho, valor);
			}

			else
			{
				if(nodo.HijoIzquierdo == null && nodo.HijoMedio == null && nodo.HijoDerecho== null)
				{
					return null;
				}
				else if(nodo.HijoIzquierdo == null || nodo.HijoMedio == null || nodo.HijoDerecho == null)
				{
					if (nodo.HijoIzquierdo!= null)
					{
						return nodo.HijoIzquierdo;
					}
					else if (nodo.HijoMedio != null)
					{
						return nodo.HijoMedio;
					}
					else
					{
						return nodo.HijoDerecho;
					}
				}
				else
				{
					int sucesor = encontrarsucesor(nodo.HijoMedio);
					nodo.valor1 = sucesor;
					sucesor = Convert.ToInt32(valor);
					nodo.HijoMedio = eliminarplaca23hijos(nodo.HijoMedio, valor);
				}
			}

			return nodo;
		}



		public int encontrarsucesor(Nodo23 nodo)
		{
			while (nodo.HijoIzquierdo!= null)
			{
				nodo = nodo.HijoIzquierdo;
			}

			return Convert.ToInt32(nodo);
		}
        
        public static List<Carros> Salida()
		{
			
			
			//list.Add(carr);
			//Recorrido(raiz, list);
			return list;
		}

		public static void edit(Carros carr)
		{
			list.Remove(carr);
			insertar(carr);
		}

		public static void delet(Carros carr)
		{
			list.Remove(carr);
		}

		private void Recorrido(Nodo23 nodo, List<Carros> list)
		{
			if(nodo == null)
			{
				return;
			}

			Recorrido(nodo.HijoIzquierdo, list);

			list.Add(nodo.valor);

			if(nodo.valor != null)
			{
				Recorrido(nodo.HijoMedio, list);
				list.Add(nodo.valor);
			}

			Recorrido(nodo.HijoDerecho, list);
		}


	}
}
