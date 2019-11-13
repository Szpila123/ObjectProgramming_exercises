using System;
namespace Entry_exceptions{
	public class Name_exception : Exception{
		public Name_exception(){}
		public Name_exception(string message) : base(message){}
		public Name_exception(string message, Exception inner) : base( message, inner ){}
	}

	public class Name_empty : Name_exception{
		public Name_empty(){}
		public Name_empty(string message) : base(message){}
		public Name_empty(string message, Exception inner) : base( message, inner ){}
	}

	public class Bad_type : Exception{
		public Bad_type(){}
		public Bad_type(string message) : base(message){}
		public Bad_type(string message, Exception inner) : base( message, inner ){}
	}
}
		
