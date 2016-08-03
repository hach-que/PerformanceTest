#include <time.h>
#include <stdio.h>

clock_t start, end;

int other_method() {
	return 1;
}

void main() {
	long long i, a;
	long ms = 0;
	long long v = 0;

	for (a = 0; a < 10; a++)
	{
		start = clock();

		for (i = 0; i < 600000000L; i++)
		{
			v += other_method();			
		}

		end = clock();
		ms += end - start;
	}

	printf("Force variable reference: %lld\n", v);
	printf("Milliseconds elapsed: %ld\n", ms / 10);
	
}