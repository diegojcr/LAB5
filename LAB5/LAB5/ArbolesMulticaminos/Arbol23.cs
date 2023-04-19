using LAB5.Models;
using LAB5.ArbolesMulticaminos;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Components.Forms;
using System.Reflection.Metadata.Ecma335;

namespace LAB5.ArbolesMulticaminos
{
	public class Arbol23
	{

		public Nodo23 raiz { get; set; }

		

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

		

	}
}
