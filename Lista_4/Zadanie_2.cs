using System;
using System.Collections;

namespace Zadanie_2{
	public class PrimeCollection : IEnumerable{
		public PrimeCollection(){}
		public IEnumerator GetEnumerator(){ return new PrimeEnum( 2 ); }
	}

	class PrimeEnum : IEnumerator{
		private int first;
		private int current;
		public PrimeEnum( int first ){ this.first = first; this.current = 0; }
		public bool MoveNext(){
			if( this.current == 0 ) this.current = this.first;
			else this.current = NextPrime( this.current );
			return this.current > 0 && this.current < 1000000000;
		}
		public void Reset(){ current = 0; }
		public object Current{get{ return current;}}
		static int NextPrime( int num ){
			if( num == 2 ) return 3;
			bool found = false;
			do{
				num+=2;
				found = true;
				for( int i = 3 ; i * i <= num ; i += 2){
					if( num % i == 0 ){
						found = false;
						break;
					}
				}
			}while( (num > 0) && num < 1000000000 && !found );
			return num;
		}
	}
}
				 


	
