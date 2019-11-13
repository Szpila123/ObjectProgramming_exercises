CS =mcs
lib=-r:
to_lib=-t:library

main.exe: Dict.dll List.dll Zadanie_2.dll main.cs Zadanie_1.dll
	$(CS) $(lib)Zadanie_1.dll $(lib)Dict.dll $(lib)List.dll $(lib)Zadanie_2.dll main.cs

Dict.dll: Dict.cs Zadanie_1.dll
	$(CS) $(lib)Zadanie_1.dll $(to_lib) Dict.cs

List.dll: List.cs Zadanie_1.dll
	$(CS) $(lib)Zadanie_1.dll $(to_lib) List.cs

Zadanie_1.dll: Zadanie_1.cs 
	$(CS) $(to_lib) Zadanie_1.cs

Zadanie_2.dll: Zadanie_2.cs
	$(CS) $(to_lib) Zadanie_2.cs
	
	

