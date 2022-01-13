Make: lex.l lex.y
	flex lex.l
	bison -d lex.y
	g++ lex.tab.c lex.yy.c -static-libgcc -static-libstdc++ -o ./CompilerExe/execute -lfl --exec-charset=cp932 -mno-clwb