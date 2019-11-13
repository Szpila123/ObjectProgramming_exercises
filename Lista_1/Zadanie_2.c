#include <stdlib.h>

typedef struct
{
	int up, down;
} Ulamki;

Ulamki* new_ulamek( int up, int down);
Ulamki* sum_new( Ulamki a, Ulamki b);
Ulamki* diff_new( Ulamki a, Ulamki b);
Ulamki* quo_new( Ulamki a, Ulamki b);
Ulamki* rat_new( Ulamki a, Ulamki b);
static void short_ulamek( Ulamki* a );

void sum_mod( Ulamki a, Ulamki* b);
void diff_mod( Ulamki a, Ulamki* b);
void quo_mod( Ulamki a, Ulamki* b);
void rat_mod( Ulamki a, Ulamki* b);

static void short_ulamek( Ulamki* a )
{
	for( int i = 2 ; i * i <= a->up ; i += (i == 2 ? 1 : 2) ) 
		while( a->up % i == 0 && a->down % i == 0 ){
			a->up /= i;
			a->down /= i;
		}
	if( a->down % a->up == 0 ){
		a->down /= a->up;
		a->up = 1;
	}
	return;
}
			
Ulamki* new_ulamek( int up, int down)
{
	Ulamki *new = malloc( sizeof( Ulamki ) );
	if( down < 0 ){
		up *= -1;
		down *= -1;
	}
	new->up = up;
	new->down = down;
	short_ulamek( new );
	return new;
}

void sum_mod( Ulamki a, Ulamki* b)
{
	int up, down;
	up = a.up * b->down + b->up * a.down;
	down = a.down * b->down;
	b->up = up;
	b->down = down;
	short_ulamek( b );
}

void diff_mod( Ulamki a, Ulamki* b)
{
	int up, down;
	up = a.up * b->down - b->up * a.up;
	down = a.down * b->down;
	b->up = up;
	b->down = down;
	short_ulamek( b );
}

void quo_mod( Ulamki a, Ulamki* b)
{
	int up, down;
	up = a.up * b->up;
	down = a.down * b->down;
	b->up = up;
	b->down = down;
	short_ulamek( b );
}

void rat_mod( Ulamki a, Ulamki* b )
{
	int up, down;
	up = a.up * b->down;
	down = a.down * b->up;
	b->up = up;
	b->down = down;
	short_ulamek( b );
}

Ulamki* sum_new( Ulamki a, Ulamki b)
{
	Ulamki *new = malloc( sizeof( Ulamki ) );
	sum_mod( a, &b );
	*new = b;
	return new;
}

Ulamki* diff_new( Ulamki a, Ulamki b)
{
	Ulamki *new = malloc( sizeof( Ulamki ) );
	diff_mod( a, &b );
	*new = b;
	return new;
}
		
Ulamki* quo_new( Ulamki a, Ulamki b)
{
	Ulamki *new = malloc( sizeof( Ulamki ) );
	quo_mod( a, &b );
	*new = b;
	return new;
}

Ulamki* rat_new( Ulamki a, Ulamki b)
{
	Ulamki *new = malloc( sizeof( Ulamki ) );
	rat_mod( a, &b );
	*new = b;
	return new;
}


