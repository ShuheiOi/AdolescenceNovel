flex lex.l
bison -d lex.y
g++ lex.tab.c lex.yy.c -o ./CompilerExe/execute -lfl
