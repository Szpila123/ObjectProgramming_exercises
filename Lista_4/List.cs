using System;
using Zadanie_1;
using System.Collections;
namespace Lista{
	public class List<T>: ICollections<T>, IEnumerable where T: IComparable {
		private  Node<T> first, last;
	
		public List(){
			first = null;
			last = null;
		}

		public IEnumerator GetEnumerator(){ return new ListEnum<T>( first ); }
	
		public bool Add( T val){
			if( first  == null )
				first = last = new Node<T>( val, null, null);
			else if( first == last ){
				first = new Node<T>( val, null, last);
				last.prev = first;
			}
			else{
				Node<T> temp = first;
				first = new Node<T>( val, null, temp);
				temp.prev = first;
			}
			return true;
		}
				
	
		public void Add_end( T val ){
			if( last == null )
				last = first = new Node<T>( val, null, null );
			else if( first == last ){
				last = new Node<T>( val, first, null );
				first.next = last;
			}
			else{
				Node<T> temp = last;
				last = new Node<T>(val, temp, null );
				temp.next = last;
			}
		}
	
		public T Pop_beg(){
			if( first == null ) return default(T);
			T val = first.val;
			first = (first == last ? (last = null) :  first.next);
			return val;
		}
		
		public T Pop_end(){
			if( last == null ) return default(T);
			T val = last.val;
			last = (last == first ? (first = null) : last.prev);
			return val;
		}

		public void Remove( T val ){
			if( first == null ) return;
			while( first != null && (first.val).CompareTo( val ) == 0 ) first = first.next;
			if( first == null ) return;
			Node<T> temp = first;
			while( temp.next != null )
				while( temp.next != null && (temp.next).val.CompareTo( val ) == 0 )
					temp.next = (temp.next).next;	
			return;
		}
	
		public bool IfEmpty(){ return first == null; }
	}
	
	class Node<T>{
		public T val{ get;set; }
		public Node<T> next{get;set;}
		public Node<T> prev{get;set;}
		public Node( T val, Node<T> prev, Node<T> next){
			this.val = val;
			this.next = next;
			this.prev = prev;
		}
	}

	class ListEnum<T> : IEnumerator{
		Node<T> list, current;
		public ListEnum( Node<T> list ){ this.list = list; }
		public bool MoveNext(){
			if( this.current == null ) this.current = this.list;
			else this.current = this.current.next;
			return this.current != null;
		}
		public object Current{get{return current.val;}}
		public void Reset(){ this.current = this.list; }	
	}
}
