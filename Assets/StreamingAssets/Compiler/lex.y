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
	#include <iostream>
	#include <cstdio>
	#include <fstream>
	#include <string>
	#include <map>
	#include <stack>
	#include <regex>
	#include "parser.h"
	using namespace std;
	
	extern int yylex();
	extern int yyparse();
	
	void yyerror(const char *s);
	int line_num = 0;
	string now_function_name = "";
	map<string,int> var_num;
	map<string,int> jump_list;
	stack<int> indent_block;
	string function_name = "";
	FILE* script_file = fopen("Assets/StreamingAssets/Source/tmp/tmp.txt","w");
	FILE* logfile = fopen("Assets/StreamingAssets/Source/tmp/log.txt","w");
	int for_num = 0;
%}

%define api.value.type { struct TYPE }

%token NUMBER BOOLEAN STRING
%token FLAGS
%token VARIABLE
%token OPEN
%token CLOSE
%token BLOCK_OPEN
%token BLOCK_CLOSE
%token COMMA
%token COMMENT
%token COLOR
%token FIN
%token IF BREAK CONTINUE
%token FOR
%token BLOCK_START_FIN
%token CONVERSATION
%token DEF
%token FUNCTION_NAME
%token NAME_BLOCK_OPEN NAME_BLOCK_CLOSE
%token LD CL BG MOVIE LSP LSPH PRINT VSP CSP CSPN MSP BGMVOL QUAKE FOOTERREGIST
%token DEFBUTTON BUTTON SELECT SELECTN CHANGESCENE TEXTDEF TEXTSPEED FOOTERON FOOTEROFF GOTO SAVE LOAD END
%token BGM BGMSTOP SE DELAY RELEASE
%token TEXTOFF TEXTON TEXTONN TEXTOFFN TEXTWRITE

%left ADD SUB GT LT GE LE EQ ASSIGN MOD
%left MUL DIV
%type<num> NUMBER
%type<str> STRING VARIABLE string if_boolean_var CONVERSATION number FUNCTION_NAME name color COLOR place boolean FLAGS flag select_args calculate_value number_var string_var boolean_var calculate_number calculate_string calculate_boolean
%type<boolean> BOOLEAN

%start statement

%%
statement
	: /* empty */
	| statement COMMENT FIN
	| statement if_state FIN
	| statement calculation FIN
	| statement for_state FIN
	| statement conversation FIN
	| statement command FIN
	| statement function FIN
	| statement use_function FIN
	| statement flag_mark FIN
	| statement FIN
	;
flag_mark
	: FLAGS {string flag_name = $1.substr(1); jump_list["__" + flag_name]=line_num;}
	;
flag
	: FLAGS {$$ = "__" + $1.substr(1);}
	;
calculation
	: VARIABLE ASSIGN calculate_value			{ fprintf(script_file,"LET vv %s %s\n",$1.c_str(),$3.c_str()); line_num++;}
	| VARIABLE ASSIGN VARIABLE						{ fprintf(script_file,"LET vv %s %s\n",$1.c_str(),$3.c_str()); line_num++;}
	;
calculate_value
	: calculate_number {$$ = $1;}
	| calculate_string {$$ = $1;}
	| calculate_boolean {$$ = $1;}
	| number			{$$ = $1;}
	| string {$$ = $1;}
	| boolean {$$ = $1;}
	;
calculate_number
	: VARIABLE ADD number { int now = line_num; $$ = "_" + to_string(now); fprintf(script_file,"ADD vvv %s %s %s\n",	$1.c_str(),		$3.c_str(),	$$.c_str()); line_num++; }
	| number ADD VARIABLE { int now = line_num; $$ = "_" + to_string(now); fprintf(script_file,"ADD vvv %s %s %s\n",	$1.c_str(),		$3.c_str(),	$$.c_str()); line_num++; }
	| VARIABLE ADD VARIABLE { int now = line_num; $$ = "_" + to_string(now); fprintf(script_file,"ADD vvv %s %s %s\n",	$1.c_str(),		$3.c_str(),	$$.c_str()); line_num++; }
	| VARIABLE SUB number { int now = line_num; $$ = "_" + to_string(now); fprintf(script_file,"SUB vvv %s %s %s\n",	$1.c_str(),		$3.c_str(),	$$.c_str()); line_num++; }
	| number SUB VARIABLE { int now = line_num; $$ = "_" + to_string(now); fprintf(script_file,"SUB vvv %s %s %s\n",	$1.c_str(),		$3.c_str(),	$$.c_str()); line_num++; }
	| VARIABLE SUB VARIABLE { int now = line_num; $$ = "_" + to_string(now); fprintf(script_file,"SUB vvv %s %s %s\n",	$1.c_str(),		$3.c_str(),	$$.c_str()); line_num++; }
	| VARIABLE MUL number { int now = line_num; $$ = "_" + to_string(now); fprintf(script_file,"MUL vvv %s %s %s\n",	$1.c_str(),		$3.c_str(),	$$.c_str()); line_num++; }
	| number MUL VARIABLE { int now = line_num; $$ = "_" + to_string(now); fprintf(script_file,"MUL vvv %s %s %s\n",	$1.c_str(),		$3.c_str(),	$$.c_str()); line_num++; }
	| VARIABLE MUL VARIABLE { int now = line_num; $$ = "_" + to_string(now); fprintf(script_file,"MUL vvv %s %s %s\n",	$1.c_str(),		$3.c_str(),	$$.c_str()); line_num++; }
	| VARIABLE DIV number { int now = line_num; $$ = "_" + to_string(now); fprintf(script_file,"DIV vvv %s %s %s\n",	$1.c_str(),		$3.c_str(),	$$.c_str()); line_num++; }
	| number DIV VARIABLE { int now = line_num; $$ = "_" + to_string(now); fprintf(script_file,"DIV vvv %s %s %s\n",	$1.c_str(),		$3.c_str(),	$$.c_str()); line_num++; }
	| VARIABLE DIV VARIABLE { int now = line_num; $$ = "_" + to_string(now); fprintf(script_file,"DIV vvv %s %s %s\n",	$1.c_str(),		$3.c_str(),	$$.c_str()); line_num++; }
	| VARIABLE MOD number { int now = line_num; $$ = "_" + to_string(now); fprintf(script_file,"MOD vvv %s %s %s\n",	$1.c_str(),		$3.c_str(),	$$.c_str()); line_num++; }
	| number MOD VARIABLE { int now = line_num; $$ = "_" + to_string(now); fprintf(script_file,"MOD vvv %s %s %s\n",	$1.c_str(),		$3.c_str(),	$$.c_str()); line_num++; }
	| VARIABLE MOD VARIABLE { int now = line_num; $$ = "_" + to_string(now); fprintf(script_file,"MOD vvv %s %s %s\n",	$1.c_str(),		$3.c_str(),	$$.c_str()); line_num++; }
	;
number_var
	: VARIABLE				{ $$ = $1;}
	| number				{ $$ = $1;}
	| calculate_number		{ $$ = $1;}
	;
number
	: NUMBER				{ int now = line_num; $$ = "_" + to_string(now); fprintf(script_file,"LET vn %s %d\n",$$.c_str(),$1); line_num++; }
	| OPEN number CLOSE 	{ $$ = $2; }
	| number ADD number		{ int now = line_num; $$ = "_" + to_string(now); fprintf(script_file,"ADD vvv %s %s %s\n",	$1.c_str(),		$3.c_str(),	$$.c_str()); line_num++; }
	| number SUB number   	{ int now = line_num; $$ = "_" + to_string(now); fprintf(script_file,"SUB vvv %s %s %s\n",	$1.c_str(),		$3.c_str(),	$$.c_str()); line_num++; }
	| number DIV number   	{ int now = line_num; $$ = "_" + to_string(now); fprintf(script_file,"MUL vvv %s %s %s\n",	$1.c_str(),		$3.c_str(),	$$.c_str()); line_num++; }
	| number MUL number   	{ int now = line_num; $$ = "_" + to_string(now); fprintf(script_file,"DIV vvv %s %s %s\n",	$1.c_str(),		$3.c_str(),	$$.c_str()); line_num++; }
	| number MOD number   	{ int now = line_num; $$ = "_" + to_string(now); fprintf(script_file,"MOD vvv %s %s %s\n",  $1.c_str(),     $3.c_str(), $$.c_str()); line_num++; }
	;
calculate_string
	: string ADD VARIABLE		{ int now = line_num; $$ = "_" + to_string(now); fprintf(script_file,"ADD vvv %s %s %s\n",	$1.c_str(),		$3.c_str(),	$$.c_str()); line_num++; }
	| VARIABLE ADD string		{ int now = line_num; $$ = "_" + to_string(now); fprintf(script_file,"ADD vvv %s %s %s\n",	$1.c_str(),		$3.c_str(),	$$.c_str()); line_num++; }
	;
string_var
	: VARIABLE			{$$ = $1;}
	| string			{$$ = $1;}
	| calculate_string	{$$ = $1;}
	;
string
	: STRING				{ int now = line_num; $$ = "_" + to_string(now); fprintf(script_file,"LET vs %s %s\n",$$.c_str(),$1.c_str()); line_num++; }
	| string ADD string		{ int now = line_num; $$ = "_" + to_string(now); fprintf(script_file,"ADD vvv %s %s %s\n",	$1.c_str(),		$3.c_str(),	$$.c_str()); line_num++; }
	;
calculate_boolean
	: number GT VARIABLE 		{ int now = line_num; $$ = "_" + to_string(now); fprintf(script_file,"GT vvv %s %s %s\n",$1.c_str(),$3.c_str(),$$.c_str());line_num++;}
	| number LT VARIABLE 		{ int now = line_num; $$ = "_" + to_string(now); fprintf(script_file,"LT vvv %s %s %s\n",$1.c_str(),$3.c_str(),$$.c_str());line_num++;}
	| number GE VARIABLE 		{ int now = line_num; $$ = "_" + to_string(now); fprintf(script_file,"GE vvv %s %s %s\n",$1.c_str(),$3.c_str(),$$.c_str());line_num++;}
	| number LE VARIABLE 		{ int now = line_num; $$ = "_" + to_string(now); fprintf(script_file,"LE vvv %s %s %s\n",$1.c_str(),$3.c_str(),$$.c_str());line_num++;}
	| number EQ VARIABLE 		{ int now = line_num; $$ = "_" + to_string(now); fprintf(script_file,"EQ vvv %s %s %s\n",$1.c_str(),$3.c_str(),$$.c_str());line_num++;}	
	| VARIABLE GT number 		{ int now = line_num; $$ = "_" + to_string(now); fprintf(script_file,"GT vvv %s %s %s\n",$1.c_str(),$3.c_str(),$$.c_str());line_num++;}
	| VARIABLE LT number 		{ int now = line_num; $$ = "_" + to_string(now); fprintf(script_file,"LT vvv %s %s %s\n",$1.c_str(),$3.c_str(),$$.c_str());line_num++;}
	| VARIABLE GE number 		{ int now = line_num; $$ = "_" + to_string(now); fprintf(script_file,"GE vvv %s %s %s\n",$1.c_str(),$3.c_str(),$$.c_str());line_num++;}
	| VARIABLE LE number 		{ int now = line_num; $$ = "_" + to_string(now); fprintf(script_file,"LE vvv %s %s %s\n",$1.c_str(),$3.c_str(),$$.c_str());line_num++;}
	| VARIABLE EQ number 		{ int now = line_num; $$ = "_" + to_string(now); fprintf(script_file,"EQ vvv %s %s %s\n",$1.c_str(),$3.c_str(),$$.c_str());line_num++;}	
	| VARIABLE GT VARIABLE 		{ int now = line_num; $$ = "_" + to_string(now); fprintf(script_file,"GT vvv %s %s %s\n",$1.c_str(),$3.c_str(),$$.c_str());line_num++;}
	| VARIABLE LT VARIABLE 		{ int now = line_num; $$ = "_" + to_string(now); fprintf(script_file,"LT vvv %s %s %s\n",$1.c_str(),$3.c_str(),$$.c_str());line_num++;}
	| VARIABLE GE VARIABLE 		{ int now = line_num; $$ = "_" + to_string(now); fprintf(script_file,"GE vvv %s %s %s\n",$1.c_str(),$3.c_str(),$$.c_str());line_num++;}
	| VARIABLE LE VARIABLE 		{ int now = line_num; $$ = "_" + to_string(now); fprintf(script_file,"LE vvv %s %s %s\n",$1.c_str(),$3.c_str(),$$.c_str());line_num++;}
	| VARIABLE EQ VARIABLE 		{ int now = line_num; $$ = "_" + to_string(now); fprintf(script_file,"EQ vvv %s %s %s\n",$1.c_str(),$3.c_str(),$$.c_str());line_num++;}	
	;
boolean_var
	: VARIABLE					{$$ = $1;}
	| boolean					{$$ = $1;}
	| calculate_boolean			{$$ = $1;}
	;
boolean
	: BOOLEAN				{ int now = line_num; $$ = "_" + to_string(now); fprintf(script_file,"LET vb %s %d\n",$$.c_str(),$1); line_num++;}
	| OPEN boolean CLOSE	{$$ = $2;}
	| number GT number 		{ int now = line_num; $$ = "_" + to_string(now); fprintf(script_file,"GT vvv %s %s %s\n",$1.c_str(),$3.c_str(),$$.c_str());line_num++;}
	| number LT number 		{ int now = line_num; $$ = "_" + to_string(now); fprintf(script_file,"LT vvv %s %s %s\n",$1.c_str(),$3.c_str(),$$.c_str());line_num++;}
	| number GE number 		{ int now = line_num; $$ = "_" + to_string(now); fprintf(script_file,"GE vvv %s %s %s\n",$1.c_str(),$3.c_str(),$$.c_str());line_num++;}
	| number LE number 		{ int now = line_num; $$ = "_" + to_string(now); fprintf(script_file,"LE vvv %s %s %s\n",$1.c_str(),$3.c_str(),$$.c_str());line_num++;}
	| number EQ number 		{ int now = line_num; $$ = "_" + to_string(now); fprintf(script_file,"EQ vvv %s %s %s\n",$1.c_str(),$3.c_str(),$$.c_str());line_num++;}
	;
color
	: COLOR {$$ = $1;}
	;
place
	: VARIABLE {$$ = $1;}
	| FUNCTION_NAME { $$ =$1; }
	;
command
	: LD place COMMA string_var COMMA number_var COMMA number_var														{ fprintf(script_file,"LD psnn %s %s %s %s\n",$2.c_str(),$4.c_str(),$6.c_str(),$8.c_str());line_num++;}
	| LD place COMMA string_var COMMA number_var																	{ fprintf(script_file,"LD psn %s %s %s\n",$2.c_str(),$4.c_str(),$6.c_str());line_num++;}
	| LD place COMMA string_var																					{ fprintf(script_file,"LD ps %s %s\n",$2.c_str(),$4.c_str());line_num++;}
	| BG string_var COMMA number_var COMMA number_var																	{ fprintf(script_file,"BG snn %s %s %s\n",$2.c_str(),$4.c_str(),$6.c_str());line_num++;}
	| BG string_var COMMA number_var																				{ fprintf(script_file,"BG sn %s %s\n",$2.c_str(),$4.c_str());line_num++;}
	| BG string_var																								{ fprintf(script_file,"BG s %s\n",$2.c_str());line_num++;}
	| BG color COMMA number_var COMMA number_var																	{ fprintf(script_file,"BG cnn %s %s %s\n",$2.c_str(),$4.c_str(),$6.c_str()); line_num++;}
	| BG color COMMA number_var																					{ fprintf(script_file,"BG cn %s %s\n",$2.c_str(),$4.c_str());line_num++;}
	| BG color																								{ fprintf(script_file,"BG c %s\n",$2.c_str());line_num++;}
	| CL place COMMA number_var COMMA number_var																	{ fprintf(script_file,"CL pnn %s %s %s\n",$2.c_str(),$4.c_str(),$6.c_str());line_num++;}
	| CL place COMMA number_var																					{ fprintf(script_file,"CL pn %s %s\n",$2.c_str(),$4.c_str());line_num++;}
	| CL place																								{ fprintf(script_file,"CL p %s\n",$2.c_str());line_num++;}
	| CHANGESCENE string_var																					{ fprintf(script_file,"CHANGESCENE s %s\n",$2.c_str());line_num++;}
	| LSP place COMMA string_var COMMA number_var COMMA number_var COMMA boolean										{ fprintf(script_file,"LSP ssnnb %s %s %s %s %s\n",$2.c_str(),$4.c_str(),$6.c_str(),$8.c_str(),$10.c_str());line_num++;}
	| LSP place COMMA string_var COMMA number_var COMMA number_var														{ fprintf(script_file,"LSP ssnn %s %s %s %s\n",$2.c_str(),$4.c_str(),$6.c_str(),$8.c_str());line_num++;}
	| LSPH place COMMA string_var COMMA number_var COMMA number_var COMMA boolean										{ fprintf(script_file,"LSPH ssnnb %s %s %s %s %s\n",$2.c_str(),$4.c_str(),$6.c_str(),$8.c_str(),$10.c_str());line_num++;}	
	| LSPH place COMMA string_var COMMA number_var COMMA number_var														{ fprintf(script_file,"LSPH ssnn %s %s %s %s\n",$2.c_str(),$4.c_str(),$6.c_str(),$8.c_str());line_num++;}
	| MOVIE string_var																							{ fprintf(script_file,"MOVIE s %s\n",$2.c_str());line_num++;}
	| DEFBUTTON place COMMA number_var COMMA number_var COMMA string_var COMMA string_var COMMA string_var COMMA string_var			{ fprintf(script_file,"DEFBUTTON snnssss %s %s %s %s %s %s %s\n",$2.c_str(),$4.c_str(),$6.c_str(),$8.c_str(),$10.c_str(),$12.c_str(),$14.c_str());line_num++;}
	| DEFBUTTON place COMMA number_var COMMA number_var COMMA string_var COMMA string_var									{ fprintf(script_file,"DEFBUTTON snnss %s %s %s %s %s\n",$2.c_str(),$4.c_str(),$6.c_str(),$8.c_str(),$10.c_str());line_num++;}	
	| DEFBUTTON place COMMA number_var COMMA number_var COMMA string_var												{ fprintf(script_file,"DEFBUTTON snns %s %s %s %s\n",$2.c_str(),$4.c_str(),$6.c_str(),$8.c_str());line_num++;}
	| BUTTON place COMMA number_var COMMA number_var COMMA string_var COMMA flag 										{ fprintf(script_file,"BUTTON pnnsn %s %s %s %s %s\n",$2.c_str(),$4.c_str(),$6.c_str(),$8.c_str(),$10.c_str());line_num++;}
	| SELECTN																								{ fprintf(script_file,"SELECT\n");line_num++;}
	| SELECT place COMMA select_args																		{ fprintf(script_file,"SELECT vs %s %s\n",$2.c_str(),$4.c_str());line_num++;}
	| BGM string_var COMMA string_var																				{ fprintf(script_file,"BGM ss %s %s\n",$2.c_str(),$4.c_str());line_num++;}
	| BGM string_var																							{ fprintf(script_file,"BGM s %s\n",$2.c_str());line_num++;}
	| BGMSTOP																								{ fprintf(script_file,"BGMSTOP\n");line_num++;}
	| SE string_var COMMA string_var																				{ fprintf(script_file,"SE ss %s %s\n",$2.c_str(),$4.c_str());line_num++;}
	| SE string_var																								{ fprintf(script_file,"SE s %s\n",$2.c_str());line_num++;}
	| TEXTOFFN																								{ fprintf(script_file,"TEXTOFF\n");line_num++;}
	| TEXTONN																								{ fprintf(script_file,"TEXTON\n");line_num++;}
	| TEXTOFF place																							{ fprintf(script_file,"TEXTOFF p %s\n",$2.c_str());line_num++;}
	| TEXTON place																							{ fprintf(script_file,"TEXTON p %s\n",$2.c_str());line_num++;}
	| VSP place COMMA number_var																				{ fprintf(script_file,"VSP sn %s %s\n",$2.c_str(),$4.c_str());line_num++;}
	| CSP place																								{ fprintf(script_file,"CSP s %s\n",$2.c_str());line_num++;}
	| CSPN																									{ fprintf(script_file,"CSP\n");line_num++;}
	| MSP place COMMA number_var COMMA number_var																	{ fprintf(script_file,"MSP snn %s %s %s\n",$2.c_str(),$4.c_str(),$6.c_str());line_num++;}
	| BGMVOL number_var 																						{ fprintf(script_file,"BGMVOL n %s\n",$2.c_str());line_num++;}
	| QUAKE number_var COMMA number_var COMMA number_var																{ fprintf(script_file,"QUAKE nnn %s %s %s\n",$2.c_str(),$4.c_str(),$6.c_str());line_num++;}
	| QUAKE number_var COMMA number_var COMMA number_var COMMA number_var 													{ fprintf(script_file,"QUAKE nnnn %s %s %s %s\n",$2.c_str(),$4.c_str(),$6.c_str(),$8.c_str());line_num++;}
	| QUAKE number_var COMMA number_var COMMA number_var COMMA number_var COMMA string_var 										{ fprintf(script_file,"QUAKE nnnnn %s %s %s %s %s\n",$2.c_str(),$4.c_str(),$6.c_str(),$8.c_str(),$10.c_str());line_num++;}
	| TEXTDEF place COMMA string_var COMMA number_var COMMA number_var COMMA number_var COMMA number_var COMMA number_var COMMA number_var COMMA number_var COMMA number_var COMMA number_var COMMA string_var{fprintf(script_file,"TEXTDEF ssnnnnnnnnns %s %s %s %s %s %s %s %s %s %s %s %s\n",$2.c_str(),$4.c_str(),$6.c_str(),$8.c_str(),$10.c_str(),$12.c_str(),$14.c_str(),$16.c_str(),$18.c_str(),$20.c_str(),$22.c_str(),$24.c_str());line_num++;}
	| TEXTDEF place COMMA string_var COMMA number_var COMMA number_var COMMA number_var COMMA number_var COMMA number_var COMMA number_var COMMA number_var COMMA number_var COMMA number_var{fprintf(script_file,"TEXTDEF ssnnnnnnnnn %s %s %s %s %s %s %s %s %s %s %s\n",$2.c_str(),$4.c_str(),$6.c_str(),$8.c_str(),$10.c_str(),$12.c_str(),$14.c_str(),$16.c_str(),$18.c_str(),$20.c_str(),$22.c_str());line_num++;}
	| TEXTSPEED number_var																						{ fprintf(script_file,"TEXTSPEED n %s\n",$2.c_str());line_num++;}
	| FOOTERON																								{ fprintf(script_file,"FOOTERON\n");line_num++;}
	| FOOTEROFF																								{ fprintf(script_file,"FOOTEROFF\n");line_num++;}
	| GOTO flag																								{ fprintf(script_file,"GOTO n %s\n",$2.c_str());line_num++;}
	| FOOTERREGIST string_var COMMA string_var COMMA number_var COMMA string_var COMMA number_var COMMA number_var COMMA number_var		{ fprintf(script_file,"FOOTERREGIST ssnsnnn %s %s %s %s %s %s %s\n",$2.c_str(),$4.c_str(),$6.c_str(),$8.c_str(),$10.c_str(),$12.c_str(),$14.c_str());line_num++;}
	| DELAY number_var																							{ fprintf(script_file,"DELAY n %s\n",$2.c_str());line_num++;}
	| TEXTWRITE place COMMA string_var COMMA number_var COMMA color COMMA string_var									{ fprintf(script_file,"TEXTWRITE vsnss %s %s %s %s %s\n",$2.c_str(),$4.c_str(),$6.c_str(),$8.c_str(),$10.c_str());line_num++;}
	| SAVE string_var																							{ fprintf(script_file,"SAVE s %s\n",$2.c_str());line_num++;}
	| LOAD string_var																							{ fprintf(script_file,"LOAD s %s\n",$2.c_str());line_num++;}
	| RELEASE																								{ fprintf(script_file,"RELEASE\n");line_num++;}
	| PRINT number_var																							{ fprintf(script_file,"PRINT n %s\n",$2.c_str());line_num++;}
	| PRINT number_var COMMA number_var																				{ fprintf(script_file,"PRINT nn %s %s\n",$2.c_str(),$4.c_str());line_num++;}
	| END																											{ fprintf(script_file,"END\n");line_num++;}
	;
select_args
	: string_var				{$$ = $1;}
	| string_var COMMA select_args 	{$$ = $1 + ' ' + $3;}
	;
function
	: DEF function_name_check OPEN args CLOSE function_contents {}
	| DEF function_name_check OPEN CLOSE function_contents{}
	;
function_name_check
	: FUNCTION_NAME {jump_list["__"+$1] = line_num;}
	;
function_name
	: FUNCTION_NAME {now_function_name = $1;}
	;
use_function
	: function_name OPEN args_push CLOSE {}
	| function_name OPEN CLOSE {fprintf(script_file,"FUNCTION\n");line_num++;fprintf(script_file,"GOTO n __%s\n",now_function_name.c_str());line_num++;}
	;
args_push
	: COMMA args_number args_push {}
	| COMMA args_str args_push {}
	| COMMA args_var args_push {}
	| args_number args_push {}
	| args_str args_push {}
	| args_var args_push {}
	| args_number{fprintf(script_file,"FUNCTION\n");line_num++;fprintf(script_file,"GOTO n __%s\n",now_function_name.c_str());line_num++;}
	| args_str{fprintf(script_file,"FUNCTION\n");line_num++;fprintf(script_file,"GOTO n __%s\n",now_function_name.c_str());line_num++;}
	| args_var{fprintf(script_file,"FUNCTION\n");line_num++;fprintf(script_file,"GOTO n __%s\n",now_function_name.c_str());line_num++;}
	| COMMA args_number {fprintf(script_file,"FUNCTION\n");line_num++;fprintf(script_file,"GOTO n __%s\n",now_function_name.c_str());line_num++;}
	| COMMA args_str {fprintf(script_file,"FUNCTION\n");line_num++;fprintf(script_file,"GOTO n __%s\n",now_function_name.c_str());line_num++;}
	| COMMA args_var {fprintf(script_file,"FUNCTION\n");line_num++;fprintf(script_file,"GOTO n __%s\n",now_function_name.c_str());line_num++;}
	;
args_var
	: VARIABLE {fprintf(script_file,"PUSH v %s\n",$1.c_str());line_num++;}
	;
args_number
	: number  {fprintf(script_file,"PUSH v %s\n",$1.c_str());line_num++;}
	;
args_str
	: string {fprintf(script_file,"PUSH v %s\n",$1.c_str());line_num++;}
	;
args
	: VARIABLE COMMA args {fprintf(script_file,"POP v %s\n",$1.c_str());line_num++;}
	| VARIABLE {fprintf(script_file,"POP v %s\n",$1.c_str());line_num++;}
	;
function_contents
	: function_start sys_statement function_end {}
	| FIN function_start FIN sys_statement function_end {}
	;
function_start
	: BLOCK_OPEN {}
	;
function_end
	: BLOCK_CLOSE { fprintf(script_file,"RETURN\n");line_num++;}
	;
if_state
	: IF OPEN if_boolean_var CLOSE if_contents {}
	;
if_boolean_var
	: boolean_var { $$ = $1; fprintf(script_file,"NOTCOMPARE vn %s __%d\n",$1.c_str(),line_num);indent_block.push(line_num); line_num++;}
	;
if_contents
	: if_starts sys_statement if_end {}
	| FIN if_starts FIN sys_statement if_end {}
	;
if_starts
	: BLOCK_OPEN {}
	;
if_end
	: BLOCK_CLOSE {jump_list["__" + to_string(indent_block.top())]=line_num;indent_block.pop();}
	;
for_state
	: FOR OPEN calculation COMMA for_boolean COMMA calculation CLOSE for_contents {}
	;
for_boolean
	: boolean_var { for_num++;fprintf(script_file,"NOTCOMPARE vn %s __for_break%d\n",$1.c_str(),for_num);indent_block.push(line_num); line_num++;}
	;
for_contents
	: for_starts sys_statement for_end {}
	| FIN for_starts FIN sys_statement for_end {}
	;
sys_statement
	: /* empty */
	| sys_statement COMMENT FIN
	| sys_statement if_state FIN
	| sys_statement calculation FIN
	| sys_statement for_state FIN
	| sys_statement conversation FIN
	| sys_statement command FIN
	| sys_statement use_function FIN
	| sys_statement continue_for FIN
	| sys_statement break_for FIN
	| sys_statement FIN
	;
for_starts
	: BLOCK_OPEN {}
	;
for_end
	: BLOCK_CLOSE { fprintf(script_file,"GOTO n %d\n",indent_block.top()-1);indent_block.pop(); line_num++;jump_list["__for_break" + to_string(for_num)]=line_num;jump_list["__for_continue" + to_string(for_num)]=line_num-1;}
	;
continue_for
	: CONTINUE {fprintf(script_file,"GOTO n __for_continue%d\n",for_num);line_num++;}
	;
break_for
	: BREAK {fprintf(script_file,"GOTO n __for_break%d\n",for_num);line_num++;}
	;
conversation
	: CONVERSATION { fprintf(script_file,"MAINTEXT s %s\n",$1.c_str()); line_num++;}
	| name CONVERSATION {fprintf(script_file,"MAINTEXT ss %s %s\n",$1.c_str(),$2.c_str()); line_num++;}
	;
name
	: NAME_BLOCK_OPEN CONVERSATION NAME_BLOCK_CLOSE {$$=$2;}
	;
%%

int main(){
	yyparse();
	fclose(script_file);
	script_file = fopen("Assets/StreamingAssets/Source/tmp/tmp.txt","r");
	FILE* finalize_file = fopen("Assets/StreamingAssets/Source/Script/script.txt","w");
	char str[256];
	string data = "";
	while(fgets(str,256,script_file) != NULL){
		data += str;
	}
	fclose(script_file);
	vector<string>keys;
	for(auto itr = jump_list.rbegin(); itr != jump_list.rend();++itr){
		keys.push_back(itr->first);
	}
	sort(keys.begin(),keys.end(),
		[] (string &s1, string &s2){ return s1.size() > s2.size();});
	for(int i=0;i<keys.size();i++){
		fprintf(logfile,"%s\t%d\n",keys[i].c_str(),jump_list[keys[i]]);
		std::cout << keys[i] << "\t" << jump_list[keys[i]]  <<std::endl;
		data = regex_replace(data,regex(keys[i]),to_string(jump_list[keys[i]]));
	}
	for(int i=0;i<data.length();i++){
		fprintf(finalize_file,"%c",data[i]);
	}
	fclose(finalize_file);
	fclose(logfile);
	return 0;
}
void yyerror(const char *s){
	printf("EEK, parser error %s",s);
}
int isatty(int a){
	return 0;
}