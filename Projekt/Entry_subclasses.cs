	using System;
	using Entry_exceptions;

	//Non-Entry classes (mostly attributes of main classes in this module, idk yet whats the best way to hide them)
namespace Entry_subclasses
{
	public class Person_Name
	{
		private string name;
		private string surname;

		public Person_Name( string name )
		{
			if( name == "" || name.IndexOf(' ') == -1 ) //Need to cover more exceptions, create a module with the class that will implement methods for dealiing with strings
				throw new Name_empty("name or surname attribute left empty");
			Name = name.Substring( 0, name.IndexOf(' ') );
			Surname = name.Substring( name.IndexOf(' ') + 1);
		}

		public string Name // need to cover more exceptions in the future
		{
			get{ return name; }
			set{
				if( value == "" ) throw new Name_empty("name attribute cannot be empty");
				name = value;
			}
		}

		public string Surname //same as above
		{
			get{ return surname; }
			set{
				if( value == "" ) throw new Name_empty("surname attribute cannot be empty");
				surname = value;
			}
		}
	}

	public class TypeCode
	{ //The idea is to create a bitset that will specify the 'type' of the Entry object ( action, fantasy etc. )
		private bool[] types;
		private int code;
		public TypeCode( int code ){
			//if (bad)
			//throw new Bad_type("This is not implemented yet...");
			//complete this later
			this.code = code;
		}
		public int GetCode(){ return code; }
		public bool[] GetTypes(){ return types; }
		//public string Type(){ return ""; }
	}
}
