public class Rank implements Comparable{
	private int rank_id;
	private String name, surname, rank;
	public Rank(String name, String surname, String rank ) throws BadRank{
		this.name = name;
		this.surname = surname;
		switch( rank ){
			case "szeregowy":
				rank_id = 1;
				break;
			case "pulkownik":
				rank_id = 2;
				break;
			case "general":
				rank_id = 3;
				break;
			default:
				throw new BadRank();
		}
	}
	public int compareTo( Object obj ){
		Rank value = (Rank) obj;
		if( value.rank_id > rank_id ) return -1;
		else if( value.rank_id == rank_id ) return 0;
		else return 1;
	}
	public String GetSurname(){ return surname; }
}
		

