public class List<E extends Comparable>{ 
	private  Node<E> start;

	List(){	start = null; }
	public void Add( E value ){
		if( start == null ) start = new Node( value );
		else{	
			Node<E> temp = start;
			if( start.value.compareTo(value) < 0){
				start = new Node<E>(value, temp);
				return;	
			}
			while( temp.next != null && temp.next.value.compareTo(value) < 0 ) temp = temp.next;
			temp.next = new Node<E>(value, temp.next );
		}
	}

	public E Check() throws EmptyList{
		if( start != null ) return start.value;
		else throw new EmptyList();
	}

	public E Pop() throws EmptyList{
		if( start != null ){
			E temp = start.value;
			start = start.next;
			return temp;
		}
		else throw new EmptyList();
	}
}

class Node<E extends Comparable>{
	public Node<E> next;
	public E value;
	Node( E value ){ this.value = value; next = null; }
	Node( E value , Node<E> next ){ this.value = value; this.next = next; }
}
