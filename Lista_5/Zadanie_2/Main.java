import java.util.*;

public class Main{
	public static void main( String[] args ){
		Hashtable<Character,Integer> Slownik = new Hashtable<Character,Integer>();

		Slownik.put('x',7);
		try{
			Wyrazenie a = new Operator( '+', new Liczba('x'), new Liczba(30) ); 
			Wyrazenie b = new Operator( '-', new Liczba(49), a );
			System.out.println( a.oblicz( Slownik ) );
			System.out.println( b.oblicz( Slownik ) );
		}catch( UnknownOperator e){}
	}
}
