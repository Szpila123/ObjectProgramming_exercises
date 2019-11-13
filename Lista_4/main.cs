using System;
using Dictionary;
using Lista;
using Zadanie_1;
using Zadanie_2;

class Class_Main{
	public static void Main(){
		ICollections<int>[] Tab = new ICollections<int>[10];
		Tab[0] = new Lista.List<int>();
		Tab[1] = new Dictionary.Dict<int, string>();
		Tab[0].Add(12);
		Tab[1].Add(33);

		Zadanie_2.PrimeCollection a = new Zadanie_2.PrimeCollection();
		Console.WriteLine("{0}", 318175%5);
		int nth_p = 1;
		foreach(int x in a){
			Console.WriteLine( "{0} {1}", nth_p, x );
			nth_p++;
		}
	}
}
		
