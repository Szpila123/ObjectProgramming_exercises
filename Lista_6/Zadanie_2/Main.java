import java.io.*;

public class Main{
	static public void main( String[] args ){
		try{
			Buffor<String> buff = new Buffor<String>(3);
			String[] stuff = {"1","2","3","4","5","6","7","8","9","10"};
			Consument cons = new Consument( buff );	
			Producent prod = new Producent( buff, stuff );
			prod.start();
			cons.start();

			prod.join();
			cons.join();
		}
		catch( Exception e ){ System.out.println("Something went wrong!!!"); }
	}
}

class Buffor<T>{
	private T[] buffor;
	private int elements;
	private int start;

	public Buffor( int size ) throws WrongSize{
		if( size <= 0 ) throw new WrongSize();
		elements = 0;
		start = 0;
		buffor = (T[]) new Object[size];
	}

	public boolean Full(){
		if( elements >= buffor.length ) return true;
		return false;
	}

	public boolean Empty(){
		if( elements == 0 ) return true;
		return false;
	}

	public void Add( T val ) throws BufforFull{
		if( this.Full() ) throw new BufforFull();
		buffor[(start+elements)%buffor.length] = val;
		elements++;
	}

	public T Pop() throws BufforEmpty{
		if( this.Empty() ) throw new BufforEmpty();
		elements--;
		start = (start+1)%buffor.length;
		return buffor[start == 0 ?  buffor.length - 1 : start - 1];
	}
}

	
class Consument extends Thread{
	private Thread t;
	Buffor<String> buff;
	public Consument( Buffor<String> buff ){ 
		this.buff = buff;
	}
	public void run(){
		String merch = null;
		while( merch != "the_end" ){
			synchronized( buff ){
				try{
					merch = buff.Pop();
				}catch( BufforEmpty e ){merch = null;}
		 		if( merch != null )System.out.println(merch + "\n");
			}
		}
	}

	public void start(){
		if( t == null ){
			t = new Thread(this, "Consument");
			t.start();
		}
	}
}


class Producent extends Thread{
	private Thread t;
	private int index;
	public Buffor<String> buff;
	public String[] stuff;

	public Producent( Buffor<String> buff, String[] stuff ){
		this.buff = buff;
		this.stuff = stuff;
		index = 0;
	}

	public void run(){
		while( index <= stuff.length )
			synchronized( buff ){
				try{
					buff.Add( index == stuff.length  ?  "the_end" :  stuff[index] );
					index ++;
				}catch( BufforFull e ){};
			}
	}

	public void start(){
		if( t == null ){
			t = new Thread(this, "Producent");
			t.start();
		}
	}
}

class WrongSize extends Exception{
	public WrongSize(){ super(); }
}

class BufforFull extends Exception{
	public BufforFull(){ super(); }
}

class BufforEmpty extends Exception{
	public BufforEmpty(){ super(); }
}
	
