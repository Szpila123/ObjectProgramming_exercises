public class Main{
	public static void main( String[] args ){
		List list = new List<Rank>();
		try{
			list.Add( new Rank("C","C","szeregowy") );
			list.Add( new Rank("A","A","general") );
			list.Add( new Rank("B","B","pulkownik") );
			System.out.println( ((Rank)list.Check()).GetSurname() );
		}catch( BadRank e ){}
		catch( EmptyList e ){}
	}
}

		
		
