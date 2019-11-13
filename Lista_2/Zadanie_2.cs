using System;

class Array{
	private List_node start, end, pos;

	private List_node GetNode( int index ){
		if( index > this.last() || index < this.first() ) return null;
		int ds = Math.Abs( index - start.GetIndex() ),
			de = Math.Abs( index - end.GetIndex() ),
			dp = Math.Abs( index - pos.GetIndex() );

		List_node closest;
		if( ds < de )	closest = ds < dp ? start : pos;
		else closest = de < dp ? end : pos;
		while( closest.GetIndex() < index ) closest = closest.GetNext();
		while( closest.GetIndex() > index ) closest = closest.GetPrev();
		pos = closest;
		return closest;
	}

	public void set( int index, int val ){
		List_node node = this.GetNode( index );
		if( node == null ) return;
		node.val = val;
		return;
	}

	public int get( int index ){
		List_node node = this.GetNode( index );
		if( node == null ) return 0;
		return node.val;
	}

	public void resize( int first, int last ){
		if( first > last ) return;
		List_node temp;
		while( start.GetIndex() > first ){
			temp = new List_node( start.GetIndex() - 1, 0, null, start );
			start.SetPrev( temp );
			start = temp;
		}
		while( end.GetIndex() < last ){
			temp = new List_node( end.GetIndex() + 1, 0, end, null);
			end.SetNext( temp );
			end = temp;
		}
		while( start.GetIndex() < first ){
			start = start.GetNext();
			start.SetPrev( null );
		}
		while( end.GetIndex() > last ){
			end = end.GetPrev();
			end.SetNext( null );
		}
		pos = start;
		return;
	}
	public Array( int first, int last ){
		if( first <= last ){
			List_node temp;
			start = new List_node( first, 0, null, null );
			pos = start;
			for( int i = first + 1 ; i <= last ; i ++ ){
				temp = new List_node( i, 0, pos, null );
				pos.SetNext( temp );
				pos = temp;
			}
			end = pos;
		}
		else{
			start = null;
			end = null;
		}
	}
	public int getsize(){ return end.GetIndex() - start.GetIndex() + 1; }
	public int first(){ return start.GetIndex(); }
	public int last(){ return end.GetIndex(); }
	
}
class List_node{
	private	int index;
	private List_node next, prev;
	public int val;
	public List_node( int index, int val, List_node prev, List_node next ){
		this.index = index;
		this.val = val;
		this.prev = prev;
		this.next = next;
	}
	public List_node GetPrev(){ return prev; }
	public List_node GetNext(){ return next; }
	public void SetNext( List_node next ){ this.next = next; } 
	public void SetPrev( List_node prev ){ this.prev = prev; }
	public int GetIndex(){ return index; }
}

	
class Zadanie_2{
	public static void Main(){
		Array a1 = new Array( 0, 10 );
		Array a2 = new Array( 0, 10 );
		Array a3 = new Array( 0, 10 );
		for( int i = 0 ; i <= 10 ; i ++ ){
			a1.set( i, i );
			a2.set( i, 10 - i );
			a3.set( i, a1.get(i) + a2.get(i) );
		}
		a3.resize( -10, 10 );
		for( int i = -10 ; i <= 10 ; i ++ ) Console.WriteLine("{0}", a3.get( i ) );
		return;
	}
}
