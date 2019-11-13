import java.util.*;

abstract public class Wyrazenie{
	public abstract int oblicz( Hashtable<Character, Integer> table);
}

class Liczba extends Wyrazenie{
	private int number;
	private boolean variable;
	public Liczba( int num ){ number = num; variable = false; }
	public Liczba( char character ){ number = (int) character; variable = true; }
	public int oblicz( Hashtable< Character , Integer> table){ return variable ? table.get( (char) number) : number ; }
}

class Operator extends Wyrazenie{
	private char operator;
	private Wyrazenie left, right;
	public Operator( char oper, Wyrazenie left, Wyrazenie right ) throws UnknownOperator{
		if( oper != '+' && oper != '-' && oper != '*' && oper != '/' ) throw new UnknownOperator();
		operator = oper;
		this.left = left;
		this.right = right;
	}
	public int oblicz( Hashtable<Character, Integer> table ){
		switch( operator ){
			case '+':
				return left.oblicz( table ) + right.oblicz( table );
			case '-':
				return left.oblicz( table ) - right.oblicz( table );
			case '*':
				return left.oblicz( table ) * right.oblicz( table );
			case '/':
				return left.oblicz( table ) / right.oblicz( table );
		}
		return 0;
	}
}
