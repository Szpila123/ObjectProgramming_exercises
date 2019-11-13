import java.io.*;

public class Main{
	static public void main( String[] args ){
		List list = new List();
		List load;
		for( int i = 2 ; i < 100 ; i += 2 ) list.Add( i );

		try{
			FileOutputStream fileOut = new FileOutputStream( "./data.ser" );
			ObjectOutputStream out = new ObjectOutputStream(fileOut);
			out.writeObject( list );
			out.close();
			fileOut.close();

			System.out.printf("Object saved, starting loading\n");
			
			FileInputStream fileIn = new FileInputStream("./data.ser");
			ObjectInputStream in = new ObjectInputStream(fileIn);
			load = (List) in.readObject();
			in.close();
			fileIn.close();
		}catch(IOException i){
			i.printStackTrace();
			return;
		}catch(ClassNotFoundException c){
			System.out.println("Employee class not found");
			c.printStackTrace();
			return;
		}
		load.Print();
		return;
	}
}




class List implements java.io.Serializable{
	Node first;
	public List(){ first = null; }
	public void Add( int val ){
		if( first == null ) first = new Node( val, null );
		else first = new Node( val, first);
	}
	public int Read() throws EmptyList{
		if( first == null ) throw new EmptyList();
		return first.val;
	}
	public int Pop() throws EmptyList{
		if( first == null ) throw new EmptyList();
		int val = first.val;
		first = first.next;
		return val;
	}
	public void Print(){
		Node temp = first;
		while( temp != null ){
			System.out.println( temp.val );
			temp = temp.next;
		}
		System.out.println( "\n" );
	}
}

class Node implements java.io.Serializable{
	public Node next;
	public int val;
	public Node( int val, Node next ){ this.val = val; this.next = next; }
}

class EmptyList extends Exception{
	public EmptyList(){ super(); }
}
