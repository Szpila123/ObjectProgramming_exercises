using System;

class IntStream{
	protected int num;
	protected bool end;

	virtual public int next(){
		if( end ) return 0;
		this.num += 1;
		if( num < 0 ) end = true;
		return num - 1;
	}
	virtual public bool eos(){ return this.end; }
	public void reset(){ num = 0 ; end = false; }
	public IntStream(){ num = 0; end = false;  }
}



class PrimeStream : IntStream{
	override public int next(){
		if( end ) return 0;
		if( num == 2 ){
			num += 1;
			return 2;
		}

		for( int i = 2 ; num > 0 ; num += 2){
			for( ; i * i <= num ; i++ )
				if( num % i == 0 ) break;
			if( i * i > num ){
				num += 2 ;
				return num - 2;
			}
			i = 2;
		}

		end = true;
		return -1;
	}
	public PrimeStream(){ end = false; num = 2; }
}



class RandomStream : IntStream{
	private Random r;
	override public bool eos(){ return false; }
	override public int next(){ return r.Next( 0, ~( 1 << (sizeof( int ) * 8 - 1 ) ) ); }
	public RandomStream(){ r = new Random(); }
}
	
class RandomWordStream {
	private PrimeStream ps;
	private RandomStream rs;
	public string next(){ 
		string str = "";
		for( int i = ps.next() - 1 ; i >= 0 ; i-- )
			str += (char) ( rs.next() % 24 + 'a');
		return str;
	}
	public RandomWordStream(){ ps = new PrimeStream(); rs = new RandomStream(); }
}

class Zadanie_1{
	public static void Main(){
		PrimeStream ps = new PrimeStream();
		RandomStream rs = new RandomStream();
		RandomWordStream rws = new RandomWordStream();
		for( int i = 0 ; i < 10 ; i ++ )
			Console.WriteLine( "{0} {1}", ps.next(), rws.next() );
		Console.WriteLine( "{0}", rs.next() );
		return;
	}
}
