make_all: Zadanie_2.dll Zadanie_1.dll 
	mcs -r:Zadanie_1.dll -r:Zadanie_2.dll main_test.cs

Zadanie_1.dll: Zadanie_1.cs
	mcs -t:library Zadanie_1.cs

Zadanie_2.dll: Zadanie_2.cs
	mcs -t:library Zadanie_2.cs


