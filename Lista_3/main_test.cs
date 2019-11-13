using System;
using Zadanie_1;
using Zadanie_2;

class Class_main{
	public static void Main(){
		Zadanie_1.List<int> a = new Zadanie_1.List<int>();
		Zadanie_1.List<char> b = new Zadanie_1.List<char>();

		//Zadanie 1 proste testy
			//Podpinanie 1szego elementu z dwoch stron
		a.Add_beg( 1 );
		b.Add_end( 'a' );
		Console.WriteLine( "{0} {1}", a.Pop_end(), b.Pop_beg() );

			//Popowanie elementow i usuwanie z pustej listy
		for( int i = 0 ; i < 10 ; a.Add_beg( i ), i++ );

		for( int i = 0 ; i < 10 ; i++ ) Console.WriteLine( "End: {0} Beg: {1}", a.Pop_end(), a.Pop_beg() );
			//Czy pusta
		Console.WriteLine( "Pusta? {0}", a.IfEmpty() );

		//Zadanie 2 proste testy
			//Zapisywanie i szukanie
		Zadanie_2.Dict< int, string > slowa = new Zadanie_2.Dict < int, string >();
		slowa.Add( 1, "A" );
		slowa.Add( 23, "Maslo" );
		Console.WriteLine( "{0}", slowa.Find(23) );

			//Szukanie nieistniejacego elementu
		Console.WriteLine( "{0}", slowa.Find( 292 ) );

			//Usuwanie elementu	
		slowa.Remove( 1 );
		Console.WriteLine( "{0}", slowa.Find( 1 ) );
			//Usuniecie nie spowodowalo bledu
		Console.WriteLine( "{0}", slowa.Find( 23 ) );

		return;
	}
}
