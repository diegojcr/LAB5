using LAB5.Models;

namespace LAB5.ArbolesMulticaminos
{
	public class Nodo23
	{
		private int value;

		public Nodo23 HijoIzquierdo { get; set; }
		
		public Nodo23 HijoDerecho { get; set; }

		public Nodo23 HijoMedio { get; set; }

		

		public Carros valor { get; set; }

		public int valor1 { get; set; }

		public int? valor2 { get; set; }

		public Nodo23 Padre { get; set; }

		public Nodo23(Carros valor)
		{
			this.valor = valor;
            valor1 = Convert.ToInt32(valor.placa);
            valor2 = null;
            HijoIzquierdo = null;
            HijoDerecho = null;
            HijoDerecho = null;
        }

		public Nodo23(int value)
		{
			this.value = value;
		}
	}
	
		

		

		

		


	
}
