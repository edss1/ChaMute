#include <stdio.h>

void Output(char* _str, int _age); //함수 전방선언에 대해 정리
int Sum(int a, int b);

int main(void)
{

	//if문 정리
	//scanf_s 정리



	Output((char*)"Hello World!!", Sum(1, 2));


	return 0;
}

void Output(char* _str, int _age)// 함수 매개변수에 대해 정리
{
	//void 반환형 : return을 사용해도 상관은 없지만 값이 없어야한다.
	printf_s("%s %d", _str, _age);
}


int Sum(int a, int b)
{
	return a + b;
}