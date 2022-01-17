/* A Bison parser, made by GNU Bison 3.0.4.  */

/* Bison interface for Yacc-like parsers in C

   Copyright (C) 1984, 1989-1990, 2000-2015 Free Software Foundation, Inc.

   This program is free software: you can redistribute it and/or modify
   it under the terms of the GNU General Public License as published by
   the Free Software Foundation, either version 3 of the License, or
   (at your option) any later version.

   This program is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
   GNU General Public License for more details.

   You should have received a copy of the GNU General Public License
   along with this program.  If not, see <http://www.gnu.org/licenses/>.  */

/* As a special exception, you may create a larger work that contains
   part or all of the Bison parser skeleton and distribute that work
   under terms of your choice, so long as that work isn't itself a
   parser generator using the skeleton or a modified version thereof
   as a parser skeleton.  Alternatively, if you modify or redistribute
   the parser skeleton itself, you may (at your option) remove this
   special exception, which will cause the skeleton and the resulting
   Bison output files to be licensed under the GNU General Public
   License without this special exception.

   This special exception was added by the Free Software Foundation in
   version 2.2 of Bison.  */

#ifndef YY_YY_LEX_TAB_H_INCLUDED
# define YY_YY_LEX_TAB_H_INCLUDED
/* Debug traces.  */
#ifndef YYDEBUG
# define YYDEBUG 0
#endif
#if YYDEBUG
extern int yydebug;
#endif

/* Token type.  */
#ifndef YYTOKENTYPE
# define YYTOKENTYPE
  enum yytokentype
  {
    NUMBER = 258,
    BOOLEAN = 259,
    STRING = 260,
    FLAGS = 261,
    VARIABLE = 262,
    OPEN = 263,
    CLOSE = 264,
    BLOCK_OPEN = 265,
    BLOCK_CLOSE = 266,
    COMMA = 267,
    COMMENT = 268,
    COLOR = 269,
    FIN = 270,
    IF = 271,
    BREAK = 272,
    CONTINUE = 273,
    FOR = 274,
    BLOCK_START_FIN = 275,
    CONVERSATION = 276,
    DEF = 277,
    FUNCTION_NAME = 278,
    NAME_BLOCK_OPEN = 279,
    NAME_BLOCK_CLOSE = 280,
    LD = 281,
    CL = 282,
    BG = 283,
    MOVIE = 284,
    LSP = 285,
    LSPH = 286,
    PRINT = 287,
    VSP = 288,
    CSP = 289,
    CSPN = 290,
    MSP = 291,
    BGMVOL = 292,
    QUAKE = 293,
    FOOTERREGIST = 294,
    DEFBUTTON = 295,
    BUTTON = 296,
    SELECT = 297,
    SELECTN = 298,
    CHANGESCENE = 299,
    TEXTDEF = 300,
    TEXTSPEED = 301,
    FOOTERON = 302,
    FOOTEROFF = 303,
    GOTO = 304,
    SAVE = 305,
    LOAD = 306,
    END = 307,
    BGM = 308,
    BGMSTOP = 309,
    SE = 310,
    DELAY = 311,
    RELEASE = 312,
    TEXTOFF = 313,
    TEXTON = 314,
    TEXTONN = 315,
    TEXTOFFN = 316,
    TEXTWRITE = 317,
    ADD = 318,
    SUB = 319,
    GT = 320,
    LT = 321,
    GE = 322,
    LE = 323,
    EQ = 324,
    ASSIGN = 325,
    MOD = 326,
    MUL = 327,
    DIV = 328
  };
#endif

/* Value type.  */
#if ! defined YYSTYPE && ! defined YYSTYPE_IS_DECLARED
typedef  struct TYPE  YYSTYPE;
# define YYSTYPE_IS_TRIVIAL 1
# define YYSTYPE_IS_DECLARED 1
#endif


extern YYSTYPE yylval;

int yyparse (void);

#endif /* !YY_YY_LEX_TAB_H_INCLUDED  */
