using System;
using Entry_subclasses;

namespace Entry
{
	abstract public class Entry
	{
		protected int id;
		public int Id{ get{ return id; } set{ id = value;} }

		protected string title;
		public string Title{ get{ return title; } set{ title = value; } }

		protected Entry_subclasses.TypeCode type;
		public int Type{ get{ return type.GetCode(); } set{ type = new Entry_subclasses.TypeCode( value ); } }

		protected int release_date;
		public int ReleaseDate{ get{return release_date; } set{ release_date = value; } }

		protected Entry( int id, string title, int typecode, int release_date )
		{
			Id = id;
			Title = title;
			Type = typecode;
			ReleaseDate = release_date;
		}
		protected Entry(){}
	}

	abstract public class WatchableObject : Entry
	{
		protected Person_Name director;
		public string Director{ get{ return director.Name + " " + director.Surname; } set{ director = new Person_Name(value); } }

		protected string producent;
		public string Producent{ get{ return producent; } set{ producent = value; } }

		protected uint duration;
		public uint Duration{ get{ return duration; } set{ duration = value; } }

		protected WatchableObject( int id, string title, int typecode, int release_date, string director, string producent, uint duration ) :
			base( id, title, typecode, release_date )
			{
				Director =  director;
				Producent = producent;
				Duration = duration;
			}
		protected WatchableObject(){}
	}

	public class Movie : WatchableObject
	{
		public Movie( int id, string title, int typecode, int release_date, string director, string producent, uint duration ) :
			base(  id, title, typecode, release_date, director, producent, duration ){}
		public Movie(){}
	}

	public class Episode : WatchableObject
	{
		private int series_id;
		public int Series_Id{ get{ return series_id; } set{ series_id = value; } }

		private string series;
		public string Series{ get{ return series; } set{ series = value; } }

		private uint season;
		public uint Season{ get{ return season; } set{ season = value; } }

		private uint number;
		public uint Number{ get{ return number; } set{ number = value; } }

		public Episode( int id, string title, int typecode, int release_date, string director, string producent, uint duration, string series, uint season, int series_id ) :
			base( id, title, typecode, release_date, director, producent, duration )
			{
				Series = series;
				Season = season;
				Number = number;
				Series_Id = series_id;
			}
		public Episode(){}
	}

	public class Series : Entry
	{
		private uint seasons;
		public uint Seasons{ get{ return seasons; } set{ seasons = value; }}

		public Series( int id, string title, int type, int release_date, uint seasons ) : base( id, title, type, release_date )
		{
			Seasons = seasons;
		}
		public Series(){}
	}
}
