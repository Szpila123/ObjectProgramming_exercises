using System;

namespace Zadanie_1{
	public interface ICollections<T>{
		bool Add( T elem );
		void Remove( T elem );
	}
}

