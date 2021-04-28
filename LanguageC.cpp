#include <stdio.h>


int number1;
int number2;


int Sum(int a, int b); //함수 전방선언


int main(void)
{
	
	printf_s("덧셈을 시작합니다.\n덧셈할 숫자를 입력해주세요");
	printf_s("");
	scanf_s(number1);

		
	//if문 정리
	//scanf_s 정리



	


	return 0;
}



int Sum(int a, int b)
{
	return a + b;
}