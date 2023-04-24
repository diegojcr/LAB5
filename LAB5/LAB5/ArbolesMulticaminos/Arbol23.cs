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

		public Nodo23 raiz { get; set; }

		public Carros valor { get; set; }

		

		public void Insertar(Carros valor)
		{
			Nodo23 nuevonodo = new Nodo23();
			nuevonodo.valor = valor;
			if (raiz == null)
			{
				raiz = nuevonodo;
			}

			else
			{
				InsertarPlaca(raiz, valor);
			}
		}

		public void eliminarnodohoja(Carros valor)
		{

			Nodo23 nuevonodo = new Nodo23();
			nuevonodo.valor = valor;
			if (nuevonodo == null)
			{
				return;
			}

			eliminarplacahoja(raiz, valor);


		}

		public void eliminarnodounhijo(Carros valor)
		{
			Nodo23 nuevonodo = new Nodo23();
			nuevonodo.valor = valor;
			if (raiz == null)
			{
				return;
			}

		}



		public Nodo23 InsertarPlaca(Nodo23 nodo, Carros valor)
		{

			if (nodo.valor2== null)
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
					InsertarPlaca(nodo.HijoIzquierdo, valor);
				}

				else if (string.Compare(valor.placa, nodo.valor.placa) > nodo.valor2)
				{
					InsertarPlaca(nodo.HijoDerecho, valor);
				}

				else
				{
					InsertarPlaca(nodo.HijoMedio, valor);
				}

			}

			if (nodo.valor2 != null)
			{
				Nodo23 nuevonodo= new Nodo23();
				nuevonodo.HijoIzquierdo = nodo.HijoMedio;
				nuevonodo.HijoDerecho= nodo.HijoDerecho;

				if (nuevonodo.HijoIzquierdo!= null)
				{
					nuevonodo.HijoIzquierdo.Padre = nuevonodo;
				}
				if(nuevonodo.HijoDerecho != null)
				{
					nuevonodo.HijoDerecho.Padre= nuevonodo;
				}
				nodo.valor2 = null;
				if(nodo.Padre == null)
				{
					nodo.Padre = new Nodo23();
					raiz = nodo.Padre;
				}

				InsertarPlaca(nodo.Padre, valor); 
					

				
				


			}

			return null;
			
				
			

		}

		public void eliminarplacahoja(Nodo23 nodo, Carros valor)
		{
			if(nodo == null)
			{
				return;
			}

			if (string.Compare(valor.placa, nodo.valor.placa) > nodo.valor1)
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

			if (nodo.HijoIzquierdo == null && nodo.HijoMedio == null && nodo.HijoDerecho== null)
			{
				if (nodo.Padre == null)
				{
					raiz = null;
				}
				else if (nodo.Padre.HijoIzquierdo == nodo)
				{
					nodo.Padre.HijoIzquierdo = null;
				}
				else if(nodo.Padre.HijoMedio == nodo)
				{
					nodo.Padre.HijoMedio = null;
				}
				else
				{
					nodo.Padre.HijoDerecho = null;
				}

				nodo = null;
			}
		}

		public void eliminarplacaunhijo(Nodo23 nodo, Carros valor)
		{
			if (nodo == null)
			{
				return;
			}

			if (string.Compare(valor.placa, nodo.valor.placa) < nodo.valor1)
			{
				nodo.HijoIzquierdo = eliminarplacaunhijo(nodo.HijoIzquierdo, valor);
				
			}


		}

		

	}
}
