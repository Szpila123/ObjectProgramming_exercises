#include "Zadanie_1.h"
#include "Zadanie_2.h"
#include <stdio.h>
#include <stdlib.h>

int main()
{
	Figura *f = initfig();
	printf( "Pole figury %f\n", pole( f ) );
	free( f );
	Ulamki *a = new_ulamek( 2, 4 ), *b = new_ulamek( 3, 4 );
	Ulamki *c = sum_new( *a, *b );
	printf( "%d/%d\n", c->up, c->down );
	rat_mod( *a, b );
	printf( "%d/%d\n", b->up, b->down );
	return 0;
}
