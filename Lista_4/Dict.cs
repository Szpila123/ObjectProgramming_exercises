using System;
using Zadanie_1;
namespace Dictionary{
	public class Dict<K,V>:ICollections<K> where K : IComparable<K>{
		private Elem <K,V> start;

		public Dict() { start = null; }
		public bool Add( K key ){ return this.Add( key, default(V) ); }
		public bool Add( K key, V val ){
			if(start == null)
				start = new Elem < K, V > (key, val, null );
			else{
				Elem < K, V > temp = start;
				while( temp.next != null && temp.key.CompareTo( key ) == 0 ) temp = temp.next;
				if( temp.key.CompareTo( key ) == 0 ) return false;
				temp.next = new Elem < K, V >( key, val, null );
			}
			return true;
		}

		public V Find( K key ){
			Elem < K, V > temp = start;
			while( temp != null && temp.key.CompareTo( key ) != 0 ) temp = temp.next;
			if( temp == null ) return default( V );
			else return temp.val;
		}

		public void Remove( K key ){
			Elem < K, V > shadow, search; 

			if( start != null && start.key.CompareTo( key )  == 0 ){
				start = start.next;
				return;
			}

			search = start;
			while( search.key.CompareTo( key ) != 0 && search.next != null ){
				shadow = search;
				search = search.next;
			}
			if( search.key.CompareTo( key ) == 0  ) shadow.next = search.next;
		}

		public bool IfEmpty(){ return start == null; }
	}
	class Elem <K,V>{
		public K key {get;set;}  
		public V val {get;set;}
		public Elem <K,V> next {get;set;}

		public Elem( K key, V val, Elem <K,V> next ){
			this.val = val;
			this.key = key;
		}
	}
}

