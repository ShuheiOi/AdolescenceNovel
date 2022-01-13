/*
MIT License

Copyright (c) 2022 ShuheiOi

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

 */

%{
	#include<string>
	#include<regex>
	#include<stdlib.h>
	#include"parser.h"
	#include"lex.tab.h"
	FILE* var_file = fopen("Assets/StreamingAssets/Source/Script/var.txt","w");
	char* replace(char* str){
		int length = sizeof(str);
		char* ret = (char*)malloc(sizeof(char)*length);
		int count = 0;
		for(int i=0;i<length;i++){
			if(str[i] == ' ' || str[i] == '\t' || str[i] == '\n')continue;
			ret[count++] += str[i];
		}
		return ret;
	}
	string replace_str(string str){
		int length = str.length();
		for(int i = 0;i<length;i++){
			if(str[0] == ' ' || str[0] == '\t' || str[0] == '\n'){
				str = str.erase(0,1);
			}else{
				break;
			}
		}
		return str;
	}
%}

%option noyywrap

skip [[:blank:]]*
command_space " "

%%
{skip}[\n]				{fprintf(var_file,"finish %s\n",yytext);return(FIN);}
[\n]?					{fprintf(var_file,"finish %s\n",yytext);return(BLOCK_START_FIN);}

{skip}[a-z] {
		yylval.str = yytext;
		yylval.str = replace_str(yylval.str);
		fprintf(var_file,"variable %s\n",yylval.str.c_str());
		return(VARIABLE);
	};
{skip}[A-Z] {
		yylval.str = yytext;
		yylval.str = replace_str(yylval.str);
		return(FUNCTION_NAME);
	};
{skip}"+"{skip}			{yytext = replace(yytext);fprintf(var_file,"plus %s\n",yytext); return(ADD);};
{skip}"-"{skip}			{yytext = replace(yytext); return(SUB);};
{skip}"*"{skip}			{yytext = replace(yytext); return(MUL);};
{skip}"/"{skip}			{yytext = replace(yytext); return(DIV);};
{skip}"="{skip}			{fprintf(var_file,"assign %s\n",yytext);yytext = replace(yytext); return(ASSIGN);};
{skip}"%"{skip}			{yytext = replace(yytext); return(MOD);};

{skip}"("{skip}			{fprintf(var_file,"kakos %s\n",yytext); yytext = replace(yytext); return(OPEN);};
{skip}")"{skip}			{fprintf(var_file,"kakof %s\n",yytext);yytext = replace(yytext); return(CLOSE);};

{skip}"{"{skip}			{yytext = replace(yytext); return(BLOCK_OPEN);};
{skip}"}"{skip}			{yytext = replace(yytext); return(BLOCK_CLOSE);};

{skip}"["{skip}			{yytext = replace(yytext); return(NAME_BLOCK_OPEN);};
{skip}"]"{skip}			{yytext = replace(yytext); return(NAME_BLOCK_CLOSE);};

{skip}","{skip}			{fprintf(var_file,"kako %s\n",yytext);yytext = replace(yytext); return(COMMA);};

{skip}">"{skip}			{yytext = replace(yytext); return(GT);};
{skip}"<"{skip}			{yytext = replace(yytext); return(LT);};
{skip}">="{skip}		{yytext = replace(yytext); return(GE);};
{skip}"<="{skip}		{yytext = replace(yytext); return(LE);};
{skip}"=="{skip}		{yytext = replace(yytext); return(EQ);};

{skip}"if"{skip}							{fprintf(var_file,"variable %s\n",yytext);return(IF);};
{skip}"for"{skip}							return(FOR);
{skip}"break"{skip}							return(BREAK);
{skip}"continue"{skip}						return(CONTINUE);

{skip}"def"{command_space}{skip}			return(DEF);

{skip}"ld"{command_space}{skip}				return(LD);
{skip}"cl"{command_space}{skip}				return(CL);
{skip}"bg"{command_space}{skip}				return(BG);
{skip}"lsph"{command_space}{skip}			return(LSPH);
{skip}"lsp"{command_space}{skip}			return(LSP);
{skip}"movie"{command_space}{skip}			return(MOVIE);
{skip}"print"{command_space}{skip}			return(PRINT);
{skip}"vsp"{command_space}{skip}			return(VSP);
{skip}"csp"{command_space}{skip}			return(CSP);
{skip}"csp"{skip}							return(CSPN);
{skip}"msp"{command_space}{skip}			return(MSP);
{skip}"bgmvol"{command_space}{skip}			return(BGMVOL);
{skip}"quake"{command_space}{skip}			return(QUAKE);
{skip}"footerregist"{command_space}{skip}	return(FOOTERREGIST);


{skip}"defbutton"{command_space}{skip}		return(DEFBUTTON);
{skip}"button"{command_space}{skip}			return(BUTTON);
{skip}"changescene"{command_space}{skip}	return(CHANGESCENE);
{skip}"textdef"{command_space}{skip}		return(TEXTDEF);
{skip}"textspeed"{command_space}{skip}		return(TEXTSPEED);
{skip}"footeron"{skip}						return(FOOTERON);
{skip}"footeroff"{skip}						return(FOOTEROFF);
{skip}"select"{command_space}{skip}			return(SELECT);
{skip}"select"{skip}						return(SELECTN);
{skip}"texton"{command_space}{skip}			return(TEXTON);
{skip}"textoff"{command_space}{skip}		return(TEXTOFF);
{skip}"textoff"{skip}						return(TEXTOFFN);
{skip}"texton"{skip}						return(TEXTONN);
{skip}"goto"{command_space}{skip}			return(GOTO);
{skip}"save"{command_space}{skip}			return(SAVE);
{skip}"load"{command_space}{skip}			return(LOAD);
{skip}"end"{skip}							return(END);

{skip}"bgm"{command_space}{skip}			return(BGM);
{skip}"bgmstop"{skip}						return(BGMSTOP);
{skip}"se"{command_space}{skip}				return(SE);
{skip}"delay"{command_space}{skip}			return(DELAY);
{skip}"textwrite"{command_space}{skip}		return(TEXTWRITE);
{skip}"release"{skip}						return(RELEASE);


-?[[:digit:]]+ {
		fprintf(var_file,"suti %s\n",yytext);
		if(yytext[0] != '-'){
			yylval.num = atoi(yytext);
		}else{
			string minus_num = "";
			for(int i=1;i<yyleng;i++){
				minus_num += yytext[i];
			}
			yylval.num = -atoi(minus_num.c_str());
		}
		return(NUMBER);
	};
["true"|"false"] {
		if(yytext[0] == 't'){
			yylval.boolean = true;
		}else{
			yylval.boolean = false;
		}
		return BOOLEAN;
	};
	
\"([^\\"]+|\\\"[^\\"]*\\\")*\" {
		yylval.str = "";
		int i=0;
		for(;i<yyleng-2;i++){
			if(yytext[i+1]==' '){
				yylval.str+='\\';
			}
			yylval.str += yytext[i+1];
		}
		return(STRING);
	};

{skip};[^\n]* {
		return(COMMENT);
	};
{skip}[a-z][a-zA-Z_0-9]+ {
		yylval.str = yytext;
		yylval.str = replace_str(yylval.str);
		fprintf(var_file,"variable2 %s\n",yylval.str.c_str());
		return(VARIABLE);
	};
{skip}[A-Z][a-zA-Z_0-9]+ {
		yylval.str = yytext;
		yylval.str = replace_str(yylval.str);
		return(FUNCTION_NAME);
};


#[0-1A-F]{6} {
		yylval.str=yytext;
		return(COLOR);
	};
{skip}[^\x01-\xA0][^\x01-\x26^\x2A-\x2E^\x3A-\x3F^\x5B-\x5E^\x60]* {
		yylval.str = yytext;
		yylval.str = replace_str(yylval.str);
		return(CONVERSATION); };
"*"[a-zA-Z0-9_]+ {
		yylval.str = yytext;
		return(FLAGS);
	};
%%