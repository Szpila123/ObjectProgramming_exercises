#include <math.h>
#include <stdlib.h>
#include <stdio.h>
#define PI 3.14159265


typedef struct 
{
	int typfig;
	struct point { float x, y; } pnts[4];
	float dist[4];
} Figura;

float pole( Figura *f );
void Przesun( Figura *f, float x, float y);
float sumapol( Figura *f, int size );
Figura* initfig();
static int isSqOk( Figura *f );
static int isTrOk( Figura *f );
static int isCrOk( Figura *f );
static float CountDist( struct point a, struct point b );

float pole( Figura *f )
{
	switch( f->typfig )
	{
		case 1: return f->dist[0] * f->dist[0]; 
		case 2: return sqrt( f->dist[3] * (f->dist[3] - f->dist[0])
				* (f->dist[3] - f->dist[1]) * (f->dist[3] - f->dist[2]) ); 
		case 3:	return f->dist[0] * f->dist[0] * PI;
		default: return -1;
	}
}

void Przesun( Figura *f, float x, float y)
{
	int i = 0;
	if( f->typfig < 3 ) i = 4 - f->typfig;
	for( ; i >= 0 ; i -- )
	{
		f->pnts[i].x += x;
		f->pnts[i].y += y;
	}
	return;
}


float sumapol( Figura *f, int size )
{
	float sum = 0;
	for( int i = 1 ; i < size ; i++ )
		sum += pole( &(f[i]) );
	return sum;
}

Figura* initfig()
{
	Figura *f = malloc( sizeof( Figura ) );
	if( f == NULL ) return NULL;

	f->typfig = 0;
	printf( "Enter your figure type: 1-sq, 2-tr, 3-cr\n" );
	while( f->typfig > 3 || f->typfig < 1 ) scanf( "%d" , &(f->typfig) );
	
	switch( f->typfig )
	{
		case 1:
			do{
				printf("Enter sq points\n");
				for( int i = 0 ; i < 4 ; i ++ )
					scanf( "%f%f", &(f->pnts[i].x), &(f->pnts[i].y) );
			}
			while( !isSqOk( f ) );

			f->dist[0] = CountDist( f->pnts[0], f->pnts[1] );

			for( int i = 1 ; i < 4 ; i ++ ) f->dist[i] = f->dist[0];
		break;

		case 2:
			do{
				printf("Enter tr points\n");
				for( int i = 0 ; i < 3 ; i ++ )
					scanf( "%f%f", &(f->pnts[i].x), &(f->pnts[i].y) );
			}
			while( !isTrOk( f ) );
			f->dist[3] = 0;	
			for( int i = 0 ; i < 3 ; i++ ){
				f->dist[i] = CountDist( f->pnts[i], f->pnts[(i+1)%3] );	
				f->dist[3] += f->dist[i];
			}
			f->dist[3] /= 2;
		break;

		case 3:
			do{
				printf("Enter cr middle point and radious\n");
				scanf( "%f%f", &(f->pnts[0].x), &(f->pnts[0].y) );
				scanf( "%f", &(f->dist[0]) );
			}
			while( !isCrOk( f ) );
		break;
		default:
		break;
	}
	return f;
}

static int isSqOk( Figura *f )
{
	for( int i = 0 ; i < 3 ; i++ )
		for( int j = i + 1 ; j < 4 ; j ++ )
			if( f->pnts[i].x == f->pnts[j].x && f->pnts[i].y == f->pnts[j].y ) return 0;

	float dist = CountDist( f->pnts[0], f->pnts[1] );
	for( int i = 1 ; i < 4 ; i ++ )
		if( CountDist( f->pnts[i], f->pnts[(i+1)%4] ) != dist ) return 0;
		

	return 1;
}

static int isTrOk( Figura *f )
{
	for( int i = 0 ; i < 2 ; i++ )
		for( int j = i + 1 ; j < 3 ; j ++ )
			if( f->pnts[i].x == f->pnts[j].x && f->pnts[i].y == f->pnts[j].y )
				return 0;

	float a = CountDist( f->pnts[0], f->pnts[1] ),
		b = CountDist( f->pnts[1], f->pnts[2] ),
		c = CountDist( f->pnts[2], f->pnts[3] );
	
	if( a+b<=c || b+c<=a || a+c<=b ) return 0;

	return 1;
}

static int isCrOk( Figura *f )
{
	if( f->dist[0] <= 0 ) return 0;
	return 1;
}

static float CountDist( struct point a, struct point b )
{
	float dist;
	dist = ( a.x - b.x ) * ( a.x - b.x ) + ( a.y - b.y ) * ( a.y - b.y );
	dist = sqrt( dist );
	return dist;
}
