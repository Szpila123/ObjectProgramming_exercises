#ifndef _zadanie_1_h
#define _zadanie_1_h

typedef struct
{
	int typfig;
	struct point { float x, y; } pnts[4];
	float dist[4];
} Figura;

float pole( Figura *f );
void Przesun( Figura *f, float x, float y );
float sumapol( Figura *f, int size );
Figura* initfig();

#endif
