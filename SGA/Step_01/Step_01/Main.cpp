//초반에는 외울게 많다
//# : 전처리 지시문 => 컴파일러가 가장 먼저 읽어와서 처리한다.
//include : <헤더파일> 안에 정의된 내용들을 참조한다.
//컴파일러가 중요한 이유 : 오류가 났을때 오류를 대략적으로 알려준다.
//컴파일러는 main을 찾아가서 실행하고 종료된다.
#include <stdio.h> //stdio : standard+input+output : printf_s() 함수를 호출하기 위함.


//main(진입점) : 꼭 하나만 작성이 되어야한다. (2개 이상시 진입점이 모호하다고 컴파일러에서 에러가 발생한다.)
//int : 반환형태(integer : 정수)
//(void) : 전달할 값을 받지않는다


int main(void)
{

	//"Hello World!!"라는 문자열을 printf_s라는 함수에 적용시켜 콘솔창에 "Hello World!!"를 출력(분석해서 올리기)
	printf_s("Hello World!!");

	//[;] 세미콜론 : 코드의 끝을 알려주는 마침표 역할
	



	return 0;
}
