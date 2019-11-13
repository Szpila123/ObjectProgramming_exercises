#ifndef _Zadanie_2_h
#define _Zadanie_2_h

typedef struct
{
	int up, down;
} Ulamki;

Ulamki* new_ulamek( int up, int down);
Ulamki* sum_new( Ulamki a, Ulamki b);
Ulamki* diff_new( Ulamki a, Ulamki b);
Ulamki* quo_new( Ulamki a, Ulamki b);
Ulamki* rat_new( Ulamki a, Ulamki b);

void sum_mod( Ulamki a, Ulamki* b);
void diff_mod( Ulamki a, Ulamki* b);
void quo_mod( Ulamki a, Ulamki* b);
void rat_mod( Ulamki a, Ulamki* b);

#endif
