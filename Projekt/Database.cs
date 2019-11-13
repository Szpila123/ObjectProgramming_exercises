using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
namespace Database{
	public class DBConnection{
		private MySqlConnection connection;
		private string server;
		private string database;
		private string uid;
		private string password;

		public DBConnection(/*string uid, string passwd*/)
		{
			server = "localhost";
			database = "movies";
			uid = "bartosz"; //To do uid and passwd
			password = "qweasd";
			string connectionString;
			connectionString = "SERVER=" + server + ";" + "DATABASE=" +
				database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

			connection = new MySqlConnection( connectionString );
		}

		private bool OpenConnection()
		{
			try
			{
				connection.Open();
				return true;
			}
			catch(MySqlException ex)
			{
				switch( ex.Number )
				{
					case 0:
						Console.WriteLine("Cannot connect to server");
					break;
					case 1045:
						Console.WriteLine("Invalid username/password, please try again");
					break;
				}
				return false;

			}
		}

		private bool CloseConnection()
		{
			try
			{
				connection.Close();
				return true;
			}
			catch( MySqlException ex )
			{
				Console.WriteLine( ex.Message );
				return false;
			}
		}

		public void Insert( string table, Entry.Entry obj )
		{
			string query = "INSERT INTO " + table + " (";

			foreach( var prop in obj.GetType().GetProperties() )
				query += prop.Name + ",";

			query = query.Substring( 0, query.LastIndexOf(',') );
			query += ") VALUES (";

			foreach( var prop in obj.GetType().GetProperties() )
				query += "\'" + prop.GetValue( obj, null ) + "\',";

			query = query.Substring( 0, query.LastIndexOf(',') );
			query += ")";

			if( this.OpenConnection() == true )
			{
				MySqlCommand cmd = new MySqlCommand( query, connection );
				cmd.ExecuteNonQuery();
				this.CloseConnection();
			}
		}

		public void Update( string table, Entry.Entry obj )
		{
			string query = "UPDATE " + table + " SET ";

			foreach( var prop in obj.GetType().GetProperties() )
				if( prop.Name != "Id" )
					query += prop.Name + "=\'" + prop.GetValue( obj, null ) + "\',";

			query = query.Substring( 0, query.LastIndexOf(',') );
			query += " WHERE Id=" + obj.Id;


			if( this.OpenConnection() == true )
			{
				MySqlCommand cmd = new MySqlCommand( query, connection );
				cmd.ExecuteNonQuery();
				this.CloseConnection();
			}
		}

		public void Delete( string table, Entry.Entry obj )
		{
			string query = "DELETE FROM " + table + " WHERE id=" + obj.Id;

			if( this.OpenConnection() == true )
			{
				MySqlCommand cmd = new MySqlCommand( query, connection );
				cmd.ExecuteNonQuery();
				this.CloseConnection();
			}
		}


		public T[] Select<T>( string table ) where T : new()
		{
			string query = "SELECT * FROM " + table;

			T[] DBObjTab = new T[ this.Count(table) ];

			if( this.OpenConnection() == true ){
				MySqlCommand cmd = new MySqlCommand( query, connection );
				MySqlDataReader dataReader = cmd.ExecuteReader();

				for( int i = 0 ; dataReader.Read() ; i++ )
				{
					DBObjTab[i] = new T();
					foreach( var prop in typeof(T).GetProperties() )
						prop.SetValue( DBObjTab[i], Convert.ChangeType( dataReader[ prop.Name ], prop.PropertyType) );
				}

				dataReader.Close();
				this.CloseConnection();
				return DBObjTab;
			}
			else return null;
		}

		public int Count( string table )
		{
			string query = "SELECT Count(*) FROM " + table;
			int Count = -1;

			if( this.OpenConnection() == true )
			{
				MySqlCommand cmd = new MySqlCommand( query, connection );
				Count = int.Parse( cmd.ExecuteScalar()+"" );
				this.CloseConnection();
			}
			return Count;
		}
	}
}
