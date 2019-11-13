using System;
namespace Zadanie_1{
	public class List<T>{
		private  Node<T> first, last;
	
		public List(){
			first = null;
			last = null;
		}
	
		public void Add_beg( T val){
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
		}
				
	
		public void Add_end( T val){
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
	
}
