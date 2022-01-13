/* A Bison parser, made by GNU Bison 3.0.4.  */

/* Bison implementation for Yacc-like parsers in C

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

/* C LALR(1) parser skeleton written by Richard Stallman, by
   simplifying the original so-called "semantic" parser.  */

/* All symbols defined below should begin with yy or YY, to avoid
   infringing on user name space.  This should be done even for local
   variables, as they might otherwise be expanded by user macros.
   There are some unavoidable exceptions within include files to
   define necessary library symbols; they are noted "INFRINGES ON
   USER NAME SPACE" below.  */

/* Identify Bison output.  */
#define YYBISON 1

/* Bison version.  */
#define YYBISON_VERSION "3.0.4"

/* Skeleton name.  */
#define YYSKELETON_NAME "yacc.c"

/* Pure parsers.  */
#define YYPURE 0

/* Push parsers.  */
#define YYPUSH 0

/* Pull parsers.  */
#define YYPULL 1




/* Copy the first part of user declarations.  */
#line 26 "lex.y" /* yacc.c:339  */

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
	FILE* log = fopen("Assets/StreamingAssets/Source/tmp/log.txt","w");
	int for_num = 0;

#line 92 "lex.tab.c" /* yacc.c:339  */

# ifndef YY_NULLPTR
#  if defined __cplusplus && 201103L <= __cplusplus
#   define YY_NULLPTR nullptr
#  else
#   define YY_NULLPTR 0
#  endif
# endif

/* Enabling verbose error messages.  */
#ifdef YYERROR_VERBOSE
# undef YYERROR_VERBOSE
# define YYERROR_VERBOSE 1
#else
# define YYERROR_VERBOSE 0
#endif

/* In a future release of Bison, this section will be replaced
   by #include "lex.tab.h".  */
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

/* Copy the second part of user declarations.  */

#line 217 "lex.tab.c" /* yacc.c:358  */

#ifdef short
# undef short
#endif

#ifdef YYTYPE_UINT8
typedef YYTYPE_UINT8 yytype_uint8;
#else
typedef unsigned char yytype_uint8;
#endif

#ifdef YYTYPE_INT8
typedef YYTYPE_INT8 yytype_int8;
#else
typedef signed char yytype_int8;
#endif

#ifdef YYTYPE_UINT16
typedef YYTYPE_UINT16 yytype_uint16;
#else
typedef unsigned short int yytype_uint16;
#endif

#ifdef YYTYPE_INT16
typedef YYTYPE_INT16 yytype_int16;
#else
typedef short int yytype_int16;
#endif

#ifndef YYSIZE_T
# ifdef __SIZE_TYPE__
#  define YYSIZE_T __SIZE_TYPE__
# elif defined size_t
#  define YYSIZE_T size_t
# elif ! defined YYSIZE_T
#  include <stddef.h> /* INFRINGES ON USER NAME SPACE */
#  define YYSIZE_T size_t
# else
#  define YYSIZE_T unsigned int
# endif
#endif

#define YYSIZE_MAXIMUM ((YYSIZE_T) -1)

#ifndef YY_
# if defined YYENABLE_NLS && YYENABLE_NLS
#  if ENABLE_NLS
#   include <libintl.h> /* INFRINGES ON USER NAME SPACE */
#   define YY_(Msgid) dgettext ("bison-runtime", Msgid)
#  endif
# endif
# ifndef YY_
#  define YY_(Msgid) Msgid
# endif
#endif

#ifndef YY_ATTRIBUTE
# if (defined __GNUC__                                               \
      && (2 < __GNUC__ || (__GNUC__ == 2 && 96 <= __GNUC_MINOR__)))  \
     || defined __SUNPRO_C && 0x5110 <= __SUNPRO_C
#  define YY_ATTRIBUTE(Spec) __attribute__(Spec)
# else
#  define YY_ATTRIBUTE(Spec) /* empty */
# endif
#endif

#ifndef YY_ATTRIBUTE_PURE
# define YY_ATTRIBUTE_PURE   YY_ATTRIBUTE ((__pure__))
#endif

#ifndef YY_ATTRIBUTE_UNUSED
# define YY_ATTRIBUTE_UNUSED YY_ATTRIBUTE ((__unused__))
#endif

#if !defined _Noreturn \
     && (!defined __STDC_VERSION__ || __STDC_VERSION__ < 201112)
# if defined _MSC_VER && 1200 <= _MSC_VER
#  define _Noreturn __declspec (noreturn)
# else
#  define _Noreturn YY_ATTRIBUTE ((__noreturn__))
# endif
#endif

/* Suppress unused-variable warnings by "using" E.  */
#if ! defined lint || defined __GNUC__
# define YYUSE(E) ((void) (E))
#else
# define YYUSE(E) /* empty */
#endif

#if defined __GNUC__ && 407 <= __GNUC__ * 100 + __GNUC_MINOR__
/* Suppress an incorrect diagnostic about yylval being uninitialized.  */
# define YY_IGNORE_MAYBE_UNINITIALIZED_BEGIN \
    _Pragma ("GCC diagnostic push") \
    _Pragma ("GCC diagnostic ignored \"-Wuninitialized\"")\
    _Pragma ("GCC diagnostic ignored \"-Wmaybe-uninitialized\"")
# define YY_IGNORE_MAYBE_UNINITIALIZED_END \
    _Pragma ("GCC diagnostic pop")
#else
# define YY_INITIAL_VALUE(Value) Value
#endif
#ifndef YY_IGNORE_MAYBE_UNINITIALIZED_BEGIN
# define YY_IGNORE_MAYBE_UNINITIALIZED_BEGIN
# define YY_IGNORE_MAYBE_UNINITIALIZED_END
#endif
#ifndef YY_INITIAL_VALUE
# define YY_INITIAL_VALUE(Value) /* Nothing. */
#endif


#if ! defined yyoverflow || YYERROR_VERBOSE

/* The parser invokes alloca or malloc; define the necessary symbols.  */

# ifdef YYSTACK_USE_ALLOCA
#  if YYSTACK_USE_ALLOCA
#   ifdef __GNUC__
#    define YYSTACK_ALLOC __builtin_alloca
#   elif defined __BUILTIN_VA_ARG_INCR
#    include <alloca.h> /* INFRINGES ON USER NAME SPACE */
#   elif defined _AIX
#    define YYSTACK_ALLOC __alloca
#   elif defined _MSC_VER
#    include <malloc.h> /* INFRINGES ON USER NAME SPACE */
#    define alloca _alloca
#   else
#    define YYSTACK_ALLOC alloca
#    if ! defined _ALLOCA_H && ! defined EXIT_SUCCESS
#     include <stdlib.h> /* INFRINGES ON USER NAME SPACE */
      /* Use EXIT_SUCCESS as a witness for stdlib.h.  */
#     ifndef EXIT_SUCCESS
#      define EXIT_SUCCESS 0
#     endif
#    endif
#   endif
#  endif
# endif

# ifdef YYSTACK_ALLOC
   /* Pacify GCC's 'empty if-body' warning.  */
#  define YYSTACK_FREE(Ptr) do { /* empty */; } while (0)
#  ifndef YYSTACK_ALLOC_MAXIMUM
    /* The OS might guarantee only one guard page at the bottom of the stack,
       and a page size can be as small as 4096 bytes.  So we cannot safely
       invoke alloca (N) if N exceeds 4096.  Use a slightly smaller number
       to allow for a few compiler-allocated temporary stack slots.  */
#   define YYSTACK_ALLOC_MAXIMUM 4032 /* reasonable circa 2006 */
#  endif
# else
#  define YYSTACK_ALLOC YYMALLOC
#  define YYSTACK_FREE YYFREE
#  ifndef YYSTACK_ALLOC_MAXIMUM
#   define YYSTACK_ALLOC_MAXIMUM YYSIZE_MAXIMUM
#  endif
#  if (defined __cplusplus && ! defined EXIT_SUCCESS \
       && ! ((defined YYMALLOC || defined malloc) \
             && (defined YYFREE || defined free)))
#   include <stdlib.h> /* INFRINGES ON USER NAME SPACE */
#   ifndef EXIT_SUCCESS
#    define EXIT_SUCCESS 0
#   endif
#  endif
#  ifndef YYMALLOC
#   define YYMALLOC malloc
#   if ! defined malloc && ! defined EXIT_SUCCESS
void *malloc (YYSIZE_T); /* INFRINGES ON USER NAME SPACE */
#   endif
#  endif
#  ifndef YYFREE
#   define YYFREE free
#   if ! defined free && ! defined EXIT_SUCCESS
void free (void *); /* INFRINGES ON USER NAME SPACE */
#   endif
#  endif
# endif
#endif /* ! defined yyoverflow || YYERROR_VERBOSE */


#if (! defined yyoverflow \
     && (! defined __cplusplus \
         || (defined YYSTYPE_IS_TRIVIAL && YYSTYPE_IS_TRIVIAL)))

/* A type that is properly aligned for any stack member.  */
union yyalloc
{
  yytype_int16 yyss_alloc;
  YYSTYPE yyvs_alloc;
};

/* The size of the maximum gap between one aligned stack and the next.  */
# define YYSTACK_GAP_MAXIMUM (sizeof (union yyalloc) - 1)

/* The size of an array large to enough to hold all stacks, each with
   N elements.  */
# define YYSTACK_BYTES(N) \
     ((N) * (sizeof (yytype_int16) + sizeof (YYSTYPE)) \
      + YYSTACK_GAP_MAXIMUM)

# define YYCOPY_NEEDED 1

/* Relocate STACK from its old location to the new one.  The
   local variables YYSIZE and YYSTACKSIZE give the old and new number of
   elements in the stack, and YYPTR gives the new location of the
   stack.  Advance YYPTR to a properly aligned location for the next
   stack.  */
# define YYSTACK_RELOCATE(Stack_alloc, Stack)                           \
    do                                                                  \
      {                                                                 \
        YYSIZE_T yynewbytes;                                            \
        YYCOPY (&yyptr->Stack_alloc, Stack, yysize);                    \
        Stack = &yyptr->Stack_alloc;                                    \
        yynewbytes = yystacksize * sizeof (*Stack) + YYSTACK_GAP_MAXIMUM; \
        yyptr += yynewbytes / sizeof (*yyptr);                          \
      }                                                                 \
    while (0)

#endif

#if defined YYCOPY_NEEDED && YYCOPY_NEEDED
/* Copy COUNT objects from SRC to DST.  The source and destination do
   not overlap.  */
# ifndef YYCOPY
#  if defined __GNUC__ && 1 < __GNUC__
#   define YYCOPY(Dst, Src, Count) \
      __builtin_memcpy (Dst, Src, (Count) * sizeof (*(Src)))
#  else
#   define YYCOPY(Dst, Src, Count)              \
      do                                        \
        {                                       \
          YYSIZE_T yyi;                         \
          for (yyi = 0; yyi < (Count); yyi++)   \
            (Dst)[yyi] = (Src)[yyi];            \
        }                                       \
      while (0)
#  endif
# endif
#endif /* !YYCOPY_NEEDED */

/* YYFINAL -- State number of the termination state.  */
#define YYFINAL  2
/* YYLAST -- Last index in YYTABLE.  */
#define YYLAST   671

/* YYNTOKENS -- Number of terminals.  */
#define YYNTOKENS  74
/* YYNNTS -- Number of nonterminals.  */
#define YYNNTS  46
/* YYNRULES -- Number of rules.  */
#define YYNRULES  195
/* YYNSTATES -- Number of states.  */
#define YYNSTATES  429

/* YYTRANSLATE[YYX] -- Symbol number corresponding to YYX as returned
   by yylex, with out-of-bounds checking.  */
#define YYUNDEFTOK  2
#define YYMAXUTOK   328

#define YYTRANSLATE(YYX)                                                \
  ((unsigned int) (YYX) <= YYMAXUTOK ? yytranslate[YYX] : YYUNDEFTOK)

/* YYTRANSLATE[TOKEN-NUM] -- Symbol number corresponding to TOKEN-NUM
   as returned by yylex, without out-of-bounds checking.  */
static const yytype_uint8 yytranslate[] =
{
       0,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     2,     2,     2,     2,
       2,     2,     2,     2,     2,     2,     1,     2,     3,     4,
       5,     6,     7,     8,     9,    10,    11,    12,    13,    14,
      15,    16,    17,    18,    19,    20,    21,    22,    23,    24,
      25,    26,    27,    28,    29,    30,    31,    32,    33,    34,
      35,    36,    37,    38,    39,    40,    41,    42,    43,    44,
      45,    46,    47,    48,    49,    50,    51,    52,    53,    54,
      55,    56,    57,    58,    59,    60,    61,    62,    63,    64,
      65,    66,    67,    68,    69,    70,    71,    72,    73
};

#if YYDEBUG
  /* YYRLINE[YYN] -- Source line where rule number YYN was defined.  */
static const yytype_uint16 yyrline[] =
{
       0,    86,    86,    88,    89,    90,    91,    92,    93,    94,
      95,    96,    97,   100,   103,   106,   107,   110,   111,   112,
     113,   114,   115,   118,   119,   120,   121,   122,   123,   124,
     125,   126,   127,   128,   129,   130,   131,   132,   135,   136,
     137,   140,   141,   142,   143,   144,   145,   146,   149,   150,
     153,   154,   155,   158,   159,   162,   163,   164,   165,   166,
     167,   168,   169,   170,   171,   172,   173,   174,   175,   176,
     179,   180,   181,   184,   185,   186,   187,   188,   189,   190,
     193,   196,   197,   200,   201,   202,   203,   204,   205,   206,
     207,   208,   209,   210,   211,   212,   213,   214,   215,   216,
     217,   218,   219,   220,   221,   222,   223,   224,   225,   226,
     227,   228,   229,   230,   231,   232,   233,   234,   235,   236,
     237,   238,   239,   240,   241,   242,   243,   244,   245,   246,
     247,   248,   249,   250,   251,   252,   253,   254,   255,   258,
     259,   262,   263,   266,   269,   272,   273,   276,   277,   278,
     279,   280,   281,   282,   283,   284,   285,   286,   287,   290,
     293,   296,   299,   300,   303,   304,   307,   310,   313,   316,
     319,   320,   323,   326,   329,   332,   335,   336,   338,   340,
     341,   342,   343,   344,   345,   346,   347,   348,   349,   352,
     355,   358,   361,   364,   365,   368
};
#endif

#if YYDEBUG || YYERROR_VERBOSE || 0
/* YYTNAME[SYMBOL-NUM] -- String name of the symbol SYMBOL-NUM.
   First, the terminals, then, starting at YYNTOKENS, nonterminals.  */
static const char *const yytname[] =
{
  "$end", "error", "$undefined", "NUMBER", "BOOLEAN", "STRING", "FLAGS",
  "VARIABLE", "OPEN", "CLOSE", "BLOCK_OPEN", "BLOCK_CLOSE", "COMMA",
  "COMMENT", "COLOR", "FIN", "IF", "BREAK", "CONTINUE", "FOR",
  "BLOCK_START_FIN", "CONVERSATION", "DEF", "FUNCTION_NAME",
  "NAME_BLOCK_OPEN", "NAME_BLOCK_CLOSE", "LD", "CL", "BG", "MOVIE", "LSP",
  "LSPH", "PRINT", "VSP", "CSP", "CSPN", "MSP", "BGMVOL", "QUAKE",
  "FOOTERREGIST", "DEFBUTTON", "BUTTON", "SELECT", "SELECTN",
  "CHANGESCENE", "TEXTDEF", "TEXTSPEED", "FOOTERON", "FOOTEROFF", "GOTO",
  "SAVE", "LOAD", "END", "BGM", "BGMSTOP", "SE", "DELAY", "RELEASE",
  "TEXTOFF", "TEXTON", "TEXTONN", "TEXTOFFN", "TEXTWRITE", "ADD", "SUB",
  "GT", "LT", "GE", "LE", "EQ", "ASSIGN", "MOD", "MUL", "DIV", "$accept",
  "statement", "flag_mark", "flag", "calculation", "calculate_value",
  "calculate_number", "number_var", "number", "calculate_string",
  "string_var", "string", "calculate_boolean", "boolean_var", "boolean",
  "color", "place", "command", "select_args", "function",
  "function_name_check", "function_name", "use_function", "args_push",
  "args_var", "args_number", "args_str", "args", "function_contents",
  "function_start", "function_end", "if_state", "if_boolean_var",
  "if_contents", "if_starts", "if_end", "for_state", "for_boolean",
  "for_contents", "sys_statement", "for_starts", "for_end", "continue_for",
  "break_for", "conversation", "name", YY_NULLPTR
};
#endif

# ifdef YYPRINT
/* YYTOKNUM[NUM] -- (External) token number corresponding to the
   (internal) symbol number NUM (which must be that of a token).  */
static const yytype_uint16 yytoknum[] =
{
       0,   256,   257,   258,   259,   260,   261,   262,   263,   264,
     265,   266,   267,   268,   269,   270,   271,   272,   273,   274,
     275,   276,   277,   278,   279,   280,   281,   282,   283,   284,
     285,   286,   287,   288,   289,   290,   291,   292,   293,   294,
     295,   296,   297,   298,   299,   300,   301,   302,   303,   304,
     305,   306,   307,   308,   309,   310,   311,   312,   313,   314,
     315,   316,   317,   318,   319,   320,   321,   322,   323,   324,
     325,   326,   327,   328
};
# endif

#define YYPACT_NINF -285

#define yypact_value_is_default(Yystate) \
  (!!((Yystate) == (-285)))

#define YYTABLE_NINF -1

#define yytable_value_is_error(Yytable_value) \
  0

  /* YYPACT[STATE-NUM] -- Index in YYTABLE of the portion describing
     STATE-NUM.  */
static const yytype_int16 yypact[] =
{
    -285,   423,  -285,  -285,   -62,    -3,  -285,    11,    26,  -285,
      20,  -285,    31,     3,     3,    23,    66,     3,     3,    28,
       3,     3,  -285,     3,    28,    28,    66,     3,     3,     3,
    -285,    66,     3,    28,  -285,  -285,    64,    66,    66,  -285,
      66,  -285,    66,    28,  -285,     3,     3,  -285,  -285,     3,
      81,   113,   134,   145,   114,   159,   160,   161,   162,   123,
      10,  -285,    91,   185,  -285,   190,   175,  -285,  -285,   196,
     197,  -285,   153,  -285,  -285,   214,   168,   229,  -285,   230,
     254,  -285,   -31,    61,  -285,   285,    -5,   294,  -285,   295,
    -285,   304,   306,   328,   329,   330,  -285,   335,  -285,  -285,
    -285,  -285,  -285,   337,   341,  -285,  -285,  -285,   344,  -285,
    -285,  -285,  -285,   212,  -285,  -285,  -285,  -285,  -285,  -285,
     -18,    53,  -285,  -285,    40,  -285,   168,  -285,  -285,   216,
     100,  -285,  -285,  -285,   259,   346,   129,  -285,    66,    28,
     269,    28,   140,    28,    66,    66,   107,   154,   183,   215,
     253,    29,    28,   256,   262,   264,   270,   272,    28,    28,
      28,    66,    28,    28,    66,    66,    66,    66,    66,  -285,
    -285,   194,    70,   213,   300,   250,   250,   250,   222,   297,
     305,   307,   321,   324,    15,   308,   327,   357,   366,   381,
     387,    61,    61,    61,    61,    61,    62,    91,   347,    75,
     358,   356,   359,   213,   364,  -285,  -285,   365,   369,   374,
    -285,    70,  -285,    70,  -285,    70,  -285,    70,  -285,    70,
    -285,  -285,  -285,    59,  -285,    59,  -285,    59,  -285,  -285,
    -285,  -285,  -285,   375,   380,   384,   385,   386,   388,  -285,
     390,  -285,  -285,   392,   250,   250,   250,   269,  -285,  -285,
    -285,  -285,  -285,    70,  -285,    70,  -285,    70,  -285,    70,
    -285,    70,    61,    61,    61,    61,    61,  -285,  -285,    70,
    -285,    70,  -285,    70,  -285,    70,  -285,    70,  -285,   323,
    -285,  -285,  -285,   393,   332,  -285,   368,  -285,  -285,    75,
      28,    28,    28,    28,    28,    28,    28,    28,    28,    28,
      28,    66,    28,    28,  -285,  -285,  -285,   378,   479,   185,
    -285,   391,   535,  -285,   395,  -285,  -285,  -285,   396,   398,
    -285,   401,   402,   404,   406,  -285,   408,   410,  -285,  -285,
     409,  -285,  -285,  -285,   411,   412,   413,   416,  -285,   417,
     418,   419,   420,   428,  -285,  -285,  -285,    28,    28,    28,
      28,    66,    66,    66,    28,   429,   479,  -285,  -285,  -285,
    -285,  -285,  -285,  -285,  -285,  -285,   106,   535,  -285,   436,
     475,   476,   477,   481,   487,   489,   492,  -285,  -285,   415,
    -285,  -285,  -285,    53,    53,    66,    28,    66,    64,    28,
      66,   528,   591,   116,  -285,  -285,  -285,   532,   533,  -285,
     537,  -285,  -285,  -285,  -285,    28,    66,    28,   591,   543,
     545,   548,  -285,    28,    66,    28,  -285,  -285,   587,    28,
     588,    28,   589,    28,   593,    28,   599,    66,  -285
};

  /* YYDEFACT[STATE-NUM] -- Default reduction number in state STATE-NUM.
     Performed when YYTABLE does not specify something else to do.  Zero
     means the default is an error.  */
static const yytype_uint8 yydefact[] =
{
       2,     0,     1,    13,     0,     0,    12,     0,     0,   193,
       0,   144,     0,     0,     0,     0,     0,     0,     0,     0,
       0,     0,   118,     0,     0,     0,     0,     0,     0,     0,
     105,     0,     0,     0,   127,   128,     0,     0,     0,   138,
       0,   109,     0,     0,   135,     0,     0,   113,   112,     0,
       0,     0,     0,     0,     0,     0,     0,     0,     0,     0,
       0,     3,     0,     0,   143,     0,     0,    81,    82,     0,
      94,    53,    50,    80,    52,    88,    51,    91,   100,     0,
       0,    41,    38,     0,    40,   136,    39,     0,   117,     0,
     120,     0,     0,     0,     0,     0,    95,     0,   126,    14,
     129,   133,   134,   108,   111,   131,   114,   115,     0,    11,
       5,     8,     9,     0,    10,     4,     6,     7,   194,    73,
      16,     0,    15,    17,    20,    18,    21,    19,    22,    70,
       0,    72,   169,    71,     0,     0,     0,   195,     0,     0,
       0,     0,     0,     0,     0,     0,     0,     0,     0,     0,
       0,     0,     0,     0,     0,     0,     0,     0,     0,     0,
       0,     0,     0,     0,     0,     0,     0,     0,     0,   159,
     146,     0,   160,   161,     0,   155,   153,   154,     0,     0,
       0,     0,     0,     0,     0,     0,     0,     0,     0,     0,
       0,     0,     0,     0,     0,     0,     0,     0,   163,     0,
       0,    85,    93,    49,    87,    48,    54,    90,     0,     0,
      25,    23,    28,    26,    37,    35,    31,    29,    34,    32,
      42,   137,    24,    43,    27,    44,    36,    47,    30,    46,
      33,    45,   116,     0,     0,     0,     0,     0,   139,   106,
       0,   107,   110,     0,   158,   156,   157,     0,   145,   152,
     150,   151,    65,    60,    66,    61,    67,    62,    68,    63,
      69,    64,     0,     0,     0,     0,     0,    74,    55,    75,
      56,    76,    57,    77,    58,    78,    59,    79,   172,     0,
     168,   178,   175,     0,     0,   166,     0,   142,   178,     0,
       0,     0,     0,     0,     0,     0,     0,     0,     0,     0,
       0,     0,     0,     0,   149,   147,   148,     0,     0,     0,
     162,     0,     0,   141,    84,    92,    86,    89,     0,     0,
     119,   121,     0,     0,     0,   140,     0,     0,   178,   173,
       0,   188,   192,   191,     0,     0,     0,     0,   170,     0,
       0,     0,     0,     0,   178,   167,   164,     0,     0,     0,
       0,     0,     0,     0,     0,     0,     0,   179,   181,   184,
     185,   180,   182,   186,   187,   183,     0,     0,    83,    97,
      99,   122,     0,   103,     0,     0,     0,   171,   189,     0,
     174,   178,   165,     0,     0,     0,     0,     0,     0,     0,
       0,     0,     0,     0,    96,    98,   123,     0,   102,   104,
       0,   132,   178,   190,   176,     0,     0,     0,     0,     0,
       0,     0,   177,     0,     0,     0,   130,   101,     0,     0,
       0,     0,     0,     0,     0,     0,   125,     0,   124
};

  /* YYPGOTO[NTERM-NUM].  */
static const yytype_int16 yypgoto[] =
{
    -285,  -285,  -285,   103,     2,  -285,   553,    -4,    57,   556,
     -15,   -51,   594,   350,   -58,   248,   334,   654,   355,  -285,
    -285,  -285,   656,  -170,   488,   490,   491,   376,   377,   372,
     296,   663,  -285,  -285,   389,   309,   666,  -285,  -285,  -284,
     290,   263,  -285,  -285,   669,  -285
};

  /* YYDEFGOTO[NTERM-NUM].  */
static const yytype_int16 yydefgoto[] =
{
      -1,     1,    50,   100,   334,   122,    84,    85,    86,    74,
     238,    76,   131,   132,   133,    77,    69,   335,   239,    53,
      65,    54,   336,   174,   175,   176,   177,   200,   287,   288,
     346,   337,   134,   280,   281,   338,   339,   283,   380,   308,
     381,   404,   340,   341,   342,    59
};

  /* YYTABLE[YYPACT[STATE-NUM]] -- What to do in state STATE-NUM.  If
     positive, shift that token.  If negative, reduce the rule whose
     number is the opposite.  If YYTABLE_NINF, syntax error.  */
static const yytype_uint16 yytable[] =
{
      75,    78,   128,    51,   312,   249,   250,   251,    60,   126,
      67,    92,    61,    81,   119,    71,    96,   120,   121,    62,
      90,    91,   101,   102,   220,   103,    68,   104,    71,    98,
      72,    81,   146,   147,    63,    82,    83,    73,   220,   105,
     148,   149,   150,    64,   356,   178,   147,   179,   180,   181,
     182,   183,    66,   148,   149,   150,    81,   119,   153,   154,
     367,   121,   173,   185,    81,   135,   155,   156,   157,    83,
      99,    71,   278,    72,   304,   305,   306,   279,   191,   192,
     262,   263,   264,   265,   266,   285,   193,   194,   195,   203,
     286,   206,   191,   192,    81,   119,   109,   392,   129,   121,
     193,   194,   195,   153,   154,   186,   187,   188,   189,   190,
      81,   155,   156,   157,   210,    83,   378,   124,   408,   130,
     173,   379,   113,   201,   173,   173,   173,   203,   110,   208,
     209,   194,   195,   191,   192,   202,   198,   204,   199,   207,
     151,   193,   194,   195,   118,    71,   235,   205,   221,   111,
     240,   241,   242,   243,   232,   233,   234,    81,   236,   237,
     112,   212,    83,   191,   192,   186,   187,   188,   189,   190,
     172,   193,   194,   195,   114,   115,   116,   117,   184,   191,
     192,   262,   263,   264,   265,   266,    81,   193,   194,   195,
     214,    83,     4,   173,   173,   173,   206,    81,   136,    71,
     137,   169,    83,   211,   213,   215,   217,   219,   138,   139,
     223,   225,   227,   229,   231,    81,   140,    71,    81,   169,
      83,   170,   216,    83,   171,    81,   141,    71,   172,   210,
      83,   142,   172,   172,   172,   211,   253,   255,   257,   259,
     261,   143,   144,   269,   271,   273,   275,   277,   223,   225,
     227,   229,   231,    81,   130,    71,    81,   169,    83,    81,
     218,    83,   171,   222,    83,    81,   145,    81,   196,   224,
      83,   226,    83,    81,    71,    81,   247,   228,    83,   230,
      83,   179,   180,   181,   182,   183,   314,   315,   316,   317,
     318,   319,   320,   321,   322,   323,   324,   152,   326,   327,
      81,   172,   172,   172,   252,    83,   158,   159,    81,   248,
      81,   343,   254,    83,   256,    83,   160,   267,   161,   269,
     271,   273,   275,   277,    81,   394,   395,    81,   258,    83,
      81,   260,    83,   278,   268,    83,   372,   373,   374,   198,
     162,   163,   164,   368,   369,   370,   371,   165,    70,   166,
     375,    79,    80,   167,    87,    88,   168,    89,   197,   284,
      81,    93,    94,    95,   270,    83,    97,   289,   290,    81,
     396,   291,   398,   272,    83,   401,   292,   293,   285,   106,
     107,   294,   397,   108,    81,   400,   295,   296,   274,    83,
      81,   410,   297,   328,   276,    83,   298,   299,   300,   417,
     301,   409,   302,   411,   303,   309,   344,   347,   348,   416,
     349,   418,   428,   350,   351,   420,   352,   422,   353,   424,
     354,   426,   355,     2,   357,   378,   358,   359,   360,     3,
       4,   361,   362,   363,   364,   365,     5,   366,     6,     7,
     393,   393,     8,    73,     9,    10,    11,    12,   383,    13,
      14,    15,    16,    17,    18,    19,    20,    21,    22,    23,
      24,    25,    26,    27,    28,    29,    30,    31,    32,    33,
      34,    35,    36,    37,    38,    39,    40,    41,    42,    43,
      44,    45,    46,    47,    48,    49,     4,   384,   385,   386,
     329,   399,   330,   387,   331,     7,   332,   333,     8,   388,
       9,   389,    11,    12,   390,    13,    14,    15,    16,    17,
      18,    19,    20,    21,    22,    23,    24,    25,    26,    27,
      28,    29,    30,    31,    32,    33,    34,    35,    36,    37,
      38,    39,    40,    41,    42,    43,    44,    45,    46,    47,
      48,    49,     4,   402,   405,   406,   345,   282,   330,   407,
     331,     7,   332,   333,     8,   413,     9,   414,    11,    12,
     415,    13,    14,    15,    16,    17,    18,    19,    20,    21,
      22,    23,    24,    25,    26,    27,    28,    29,    30,    31,
      32,    33,    34,    35,    36,    37,    38,    39,    40,    41,
      42,    43,    44,    45,    46,    47,    48,    49,     4,   419,
     421,   423,   403,   376,   330,   425,   331,     7,   332,   333,
       8,   427,     9,   123,    11,    12,   125,    13,    14,    15,
      16,    17,    18,    19,    20,    21,    22,    23,    24,    25,
      26,    27,    28,    29,    30,    31,    32,    33,    34,    35,
      36,    37,    38,    39,    40,    41,    42,    43,    44,    45,
      46,    47,    48,    49,   127,    52,   325,    55,   311,   244,
     310,   245,   246,   382,    56,   377,   313,    57,   307,   391,
      58,   412
};

static const yytype_uint16 yycheck[] =
{
      15,    16,    60,     1,   288,   175,   176,   177,    70,    60,
       7,    26,    15,     3,     4,     5,    31,     7,     8,     8,
      24,    25,    37,    38,     9,    40,    23,    42,     5,    33,
       7,     3,    63,    64,     8,     7,     8,    14,     9,    43,
      71,    72,    73,    23,   328,    63,    64,    65,    66,    67,
      68,    69,    21,    71,    72,    73,     3,     4,    63,    64,
     344,     8,   113,   121,     3,    63,    71,    72,    73,     8,
       6,     5,    10,     7,   244,   245,   246,    15,    63,    64,
      65,    66,    67,    68,    69,    10,    71,    72,    73,   140,
      15,   142,    63,    64,     3,     4,    15,   381,     7,     8,
      71,    72,    73,    63,    64,    65,    66,    67,    68,    69,
       3,    71,    72,    73,     7,     8,    10,    60,   402,    62,
     171,    15,     8,   138,   175,   176,   177,   178,    15,   144,
     145,    72,    73,    63,    64,   139,     7,   141,     9,   143,
      83,    71,    72,    73,    21,     5,   161,     7,   152,    15,
     165,   166,   167,   168,   158,   159,   160,     3,   162,   163,
      15,     7,     8,    63,    64,    65,    66,    67,    68,    69,
     113,    71,    72,    73,    15,    15,    15,    15,   121,    63,
      64,    65,    66,    67,    68,    69,     3,    71,    72,    73,
       7,     8,     7,   244,   245,   246,   247,     3,     8,     5,
      25,     7,     8,   146,   147,   148,   149,   150,    12,    12,
     153,   154,   155,   156,   157,     3,    63,     5,     3,     7,
       8,     9,     7,     8,    12,     3,    12,     5,   171,     7,
       8,    63,   175,   176,   177,   178,   179,   180,   181,   182,
     183,    12,    12,   186,   187,   188,   189,   190,   191,   192,
     193,   194,   195,     3,   197,     5,     3,     7,     8,     3,
       7,     8,    12,     7,     8,     3,    12,     3,     9,     7,
       8,     7,     8,     3,     5,     3,    63,     7,     8,     7,
       8,    65,    66,    67,    68,    69,   290,   291,   292,   293,
     294,   295,   296,   297,   298,   299,   300,    12,   302,   303,
       3,   244,   245,   246,     7,     8,    12,    12,     3,     9,
       3,   309,     7,     8,     7,     8,    12,     9,    12,   262,
     263,   264,   265,   266,     3,   383,   384,     3,     7,     8,
       3,     7,     8,    10,     7,     8,   351,   352,   353,     7,
      12,    12,    12,   347,   348,   349,   350,    12,    14,    12,
     354,    17,    18,    12,    20,    21,    12,    23,    12,    12,
       3,    27,    28,    29,     7,     8,    32,     9,    12,     3,
     385,    12,   387,     7,     8,   390,    12,    12,    10,    45,
      46,    12,   386,    49,     3,   389,    12,    12,     7,     8,
       3,   406,    12,    15,     7,     8,    12,    12,    12,   414,
      12,   405,    12,   407,    12,    12,    15,    12,    12,   413,
      12,   415,   427,    12,    12,   419,    12,   421,    12,   423,
      12,   425,    12,     0,    15,    10,    15,    15,    15,     6,
       7,    15,    15,    15,    15,    15,    13,     9,    15,    16,
     383,   384,    19,    14,    21,    22,    23,    24,    12,    26,
      27,    28,    29,    30,    31,    32,    33,    34,    35,    36,
      37,    38,    39,    40,    41,    42,    43,    44,    45,    46,
      47,    48,    49,    50,    51,    52,    53,    54,    55,    56,
      57,    58,    59,    60,    61,    62,     7,    12,    12,    12,
      11,   388,    13,    12,    15,    16,    17,    18,    19,    12,
      21,    12,    23,    24,    12,    26,    27,    28,    29,    30,
      31,    32,    33,    34,    35,    36,    37,    38,    39,    40,
      41,    42,    43,    44,    45,    46,    47,    48,    49,    50,
      51,    52,    53,    54,    55,    56,    57,    58,    59,    60,
      61,    62,     7,    15,    12,    12,    11,   197,    13,    12,
      15,    16,    17,    18,    19,    12,    21,    12,    23,    24,
      12,    26,    27,    28,    29,    30,    31,    32,    33,    34,
      35,    36,    37,    38,    39,    40,    41,    42,    43,    44,
      45,    46,    47,    48,    49,    50,    51,    52,    53,    54,
      55,    56,    57,    58,    59,    60,    61,    62,     7,    12,
      12,    12,    11,   355,    13,    12,    15,    16,    17,    18,
      19,    12,    21,    60,    23,    24,    60,    26,    27,    28,
      29,    30,    31,    32,    33,    34,    35,    36,    37,    38,
      39,    40,    41,    42,    43,    44,    45,    46,    47,    48,
      49,    50,    51,    52,    53,    54,    55,    56,    57,    58,
      59,    60,    61,    62,    60,     1,   301,     1,   286,   171,
     284,   171,   171,   367,     1,   356,   289,     1,   279,   379,
       1,   408
};

  /* YYSTOS[STATE-NUM] -- The (internal number of the) accessing
     symbol of state STATE-NUM.  */
static const yytype_uint8 yystos[] =
{
       0,    75,     0,     6,     7,    13,    15,    16,    19,    21,
      22,    23,    24,    26,    27,    28,    29,    30,    31,    32,
      33,    34,    35,    36,    37,    38,    39,    40,    41,    42,
      43,    44,    45,    46,    47,    48,    49,    50,    51,    52,
      53,    54,    55,    56,    57,    58,    59,    60,    61,    62,
      76,    78,    91,    93,    95,    96,   105,   110,   118,   119,
      70,    15,     8,     8,    23,    94,    21,     7,    23,    90,
      90,     5,     7,    14,    83,    84,    85,    89,    84,    90,
      90,     3,     7,     8,    80,    81,    82,    90,    90,    90,
      81,    81,    84,    90,    90,    90,    84,    90,    81,     6,
      77,    84,    84,    84,    84,    81,    90,    90,    90,    15,
      15,    15,    15,     8,    15,    15,    15,    15,    21,     4,
       7,     8,    79,    80,    82,    83,    85,    86,    88,     7,
      82,    86,    87,    88,   106,    78,     8,    25,    12,    12,
      63,    12,    63,    12,    12,    12,    63,    64,    71,    72,
      73,    82,    12,    63,    64,    71,    72,    73,    12,    12,
      12,    12,    12,    12,    12,    12,    12,    12,    12,     7,
       9,    12,    82,    85,    97,    98,    99,   100,    63,    65,
      66,    67,    68,    69,    82,    88,    65,    66,    67,    68,
      69,    63,    64,    71,    72,    73,     9,    12,     7,     9,
     101,    84,    81,    85,    81,     7,    85,    81,    84,    84,
       7,    82,     7,    82,     7,    82,     7,    82,     7,    82,
       9,    81,     7,    82,     7,    82,     7,    82,     7,    82,
       7,    82,    81,    81,    81,    84,    81,    81,    84,    92,
      84,    84,    84,    84,    98,    99,   100,    63,     9,    97,
      97,    97,     7,    82,     7,    82,     7,    82,     7,    82,
       7,    82,    65,    66,    67,    68,    69,     9,     7,    82,
       7,    82,     7,    82,     7,    82,     7,    82,    10,    15,
     107,   108,    87,   111,    12,    10,    15,   102,   103,     9,
      12,    12,    12,    12,    12,    12,    12,    12,    12,    12,
      12,    12,    12,    12,    97,    97,    97,   108,   113,    12,
     101,   103,   113,   102,    81,    81,    81,    81,    81,    81,
      81,    81,    81,    81,    81,    92,    81,    81,    15,    11,
      13,    15,    17,    18,    78,    91,    96,   105,   109,   110,
     116,   117,   118,    78,    15,    11,   104,    12,    12,    12,
      12,    12,    12,    12,    12,    12,   113,    15,    15,    15,
      15,    15,    15,    15,    15,    15,     9,   113,    81,    81,
      81,    81,    84,    84,    84,    81,    89,   109,    10,    15,
     112,   114,   104,    12,    12,    12,    12,    12,    12,    12,
      12,   114,   113,    82,    88,    88,    84,    81,    84,    77,
      81,    84,    15,    11,   115,    12,    12,    12,   113,    81,
      84,    81,   115,    12,    12,    12,    81,    84,    81,    12,
      81,    12,    81,    12,    81,    12,    81,    12,    84
};

  /* YYR1[YYN] -- Symbol number of symbol that rule YYN derives.  */
static const yytype_uint8 yyr1[] =
{
       0,    74,    75,    75,    75,    75,    75,    75,    75,    75,
      75,    75,    75,    76,    77,    78,    78,    79,    79,    79,
      79,    79,    79,    80,    80,    80,    80,    80,    80,    80,
      80,    80,    80,    80,    80,    80,    80,    80,    81,    81,
      81,    82,    82,    82,    82,    82,    82,    82,    83,    83,
      84,    84,    84,    85,    85,    86,    86,    86,    86,    86,
      86,    86,    86,    86,    86,    86,    86,    86,    86,    86,
      87,    87,    87,    88,    88,    88,    88,    88,    88,    88,
      89,    90,    90,    91,    91,    91,    91,    91,    91,    91,
      91,    91,    91,    91,    91,    91,    91,    91,    91,    91,
      91,    91,    91,    91,    91,    91,    91,    91,    91,    91,
      91,    91,    91,    91,    91,    91,    91,    91,    91,    91,
      91,    91,    91,    91,    91,    91,    91,    91,    91,    91,
      91,    91,    91,    91,    91,    91,    91,    91,    91,    92,
      92,    93,    93,    94,    95,    96,    96,    97,    97,    97,
      97,    97,    97,    97,    97,    97,    97,    97,    97,    98,
      99,   100,   101,   101,   102,   102,   103,   104,   105,   106,
     107,   107,   108,   109,   110,   111,   112,   112,   113,   113,
     113,   113,   113,   113,   113,   113,   113,   113,   113,   114,
     115,   116,   117,   118,   118,   119
};

  /* YYR2[YYN] -- Number of symbols on the right hand side of rule YYN.  */
static const yytype_uint8 yyr2[] =
{
       0,     2,     0,     3,     3,     3,     3,     3,     3,     3,
       3,     3,     2,     1,     1,     3,     3,     1,     1,     1,
       1,     1,     1,     3,     3,     3,     3,     3,     3,     3,
       3,     3,     3,     3,     3,     3,     3,     3,     1,     1,
       1,     1,     3,     3,     3,     3,     3,     3,     3,     3,
       1,     1,     1,     1,     3,     3,     3,     3,     3,     3,
       3,     3,     3,     3,     3,     3,     3,     3,     3,     3,
       1,     1,     1,     1,     3,     3,     3,     3,     3,     3,
       1,     1,     1,     8,     6,     4,     6,     4,     2,     6,
       4,     2,     6,     4,     2,     2,    10,     8,    10,     8,
       2,    14,    10,     8,    10,     1,     4,     4,     2,     1,
       4,     2,     1,     1,     2,     2,     4,     2,     1,     6,
       2,     6,     8,    10,    24,    22,     2,     1,     1,     2,
      14,     2,    10,     2,     2,     1,     2,     4,     1,     1,
       3,     6,     5,     1,     1,     4,     3,     3,     3,     3,
       2,     2,     2,     1,     1,     1,     2,     2,     2,     1,
       1,     1,     3,     1,     3,     5,     1,     1,     5,     1,
       3,     5,     1,     1,     9,     1,     3,     5,     0,     3,
       3,     3,     3,     3,     3,     3,     3,     3,     2,     1,
       1,     1,     1,     1,     2,     3
};


#define yyerrok         (yyerrstatus = 0)
#define yyclearin       (yychar = YYEMPTY)
#define YYEMPTY         (-2)
#define YYEOF           0

#define YYACCEPT        goto yyacceptlab
#define YYABORT         goto yyabortlab
#define YYERROR         goto yyerrorlab


#define YYRECOVERING()  (!!yyerrstatus)

#define YYBACKUP(Token, Value)                                  \
do                                                              \
  if (yychar == YYEMPTY)                                        \
    {                                                           \
      yychar = (Token);                                         \
      yylval = (Value);                                         \
      YYPOPSTACK (yylen);                                       \
      yystate = *yyssp;                                         \
      goto yybackup;                                            \
    }                                                           \
  else                                                          \
    {                                                           \
      yyerror (YY_("syntax error: cannot back up")); \
      YYERROR;                                                  \
    }                                                           \
while (0)

/* Error token number */
#define YYTERROR        1
#define YYERRCODE       256



/* Enable debugging if requested.  */
#if YYDEBUG

# ifndef YYFPRINTF
#  include <stdio.h> /* INFRINGES ON USER NAME SPACE */
#  define YYFPRINTF fprintf
# endif

# define YYDPRINTF(Args)                        \
do {                                            \
  if (yydebug)                                  \
    YYFPRINTF Args;                             \
} while (0)

/* This macro is provided for backward compatibility. */
#ifndef YY_LOCATION_PRINT
# define YY_LOCATION_PRINT(File, Loc) ((void) 0)
#endif


# define YY_SYMBOL_PRINT(Title, Type, Value, Location)                    \
do {                                                                      \
  if (yydebug)                                                            \
    {                                                                     \
      YYFPRINTF (stderr, "%s ", Title);                                   \
      yy_symbol_print (stderr,                                            \
                  Type, Value); \
      YYFPRINTF (stderr, "\n");                                           \
    }                                                                     \
} while (0)


/*----------------------------------------.
| Print this symbol's value on YYOUTPUT.  |
`----------------------------------------*/

static void
yy_symbol_value_print (FILE *yyoutput, int yytype, YYSTYPE const * const yyvaluep)
{
  FILE *yyo = yyoutput;
  YYUSE (yyo);
  if (!yyvaluep)
    return;
# ifdef YYPRINT
  if (yytype < YYNTOKENS)
    YYPRINT (yyoutput, yytoknum[yytype], *yyvaluep);
# endif
  YYUSE (yytype);
}


/*--------------------------------.
| Print this symbol on YYOUTPUT.  |
`--------------------------------*/

static void
yy_symbol_print (FILE *yyoutput, int yytype, YYSTYPE const * const yyvaluep)
{
  YYFPRINTF (yyoutput, "%s %s (",
             yytype < YYNTOKENS ? "token" : "nterm", yytname[yytype]);

  yy_symbol_value_print (yyoutput, yytype, yyvaluep);
  YYFPRINTF (yyoutput, ")");
}

/*------------------------------------------------------------------.
| yy_stack_print -- Print the state stack from its BOTTOM up to its |
| TOP (included).                                                   |
`------------------------------------------------------------------*/

static void
yy_stack_print (yytype_int16 *yybottom, yytype_int16 *yytop)
{
  YYFPRINTF (stderr, "Stack now");
  for (; yybottom <= yytop; yybottom++)
    {
      int yybot = *yybottom;
      YYFPRINTF (stderr, " %d", yybot);
    }
  YYFPRINTF (stderr, "\n");
}

# define YY_STACK_PRINT(Bottom, Top)                            \
do {                                                            \
  if (yydebug)                                                  \
    yy_stack_print ((Bottom), (Top));                           \
} while (0)


/*------------------------------------------------.
| Report that the YYRULE is going to be reduced.  |
`------------------------------------------------*/

static void
yy_reduce_print (yytype_int16 *yyssp, YYSTYPE *yyvsp, int yyrule)
{
  unsigned long int yylno = yyrline[yyrule];
  int yynrhs = yyr2[yyrule];
  int yyi;
  YYFPRINTF (stderr, "Reducing stack by rule %d (line %lu):\n",
             yyrule - 1, yylno);
  /* The symbols being reduced.  */
  for (yyi = 0; yyi < yynrhs; yyi++)
    {
      YYFPRINTF (stderr, "   $%d = ", yyi + 1);
      yy_symbol_print (stderr,
                       yystos[yyssp[yyi + 1 - yynrhs]],
                       &(yyvsp[(yyi + 1) - (yynrhs)])
                                              );
      YYFPRINTF (stderr, "\n");
    }
}

# define YY_REDUCE_PRINT(Rule)          \
do {                                    \
  if (yydebug)                          \
    yy_reduce_print (yyssp, yyvsp, Rule); \
} while (0)

/* Nonzero means print parse trace.  It is left uninitialized so that
   multiple parsers can coexist.  */
int yydebug;
#else /* !YYDEBUG */
# define YYDPRINTF(Args)
# define YY_SYMBOL_PRINT(Title, Type, Value, Location)
# define YY_STACK_PRINT(Bottom, Top)
# define YY_REDUCE_PRINT(Rule)
#endif /* !YYDEBUG */


/* YYINITDEPTH -- initial size of the parser's stacks.  */
#ifndef YYINITDEPTH
# define YYINITDEPTH 200
#endif

/* YYMAXDEPTH -- maximum size the stacks can grow to (effective only
   if the built-in stack extension method is used).

   Do not make this value too large; the results are undefined if
   YYSTACK_ALLOC_MAXIMUM < YYSTACK_BYTES (YYMAXDEPTH)
   evaluated with infinite-precision integer arithmetic.  */

#ifndef YYMAXDEPTH
# define YYMAXDEPTH 10000
#endif


#if YYERROR_VERBOSE

# ifndef yystrlen
#  if defined __GLIBC__ && defined _STRING_H
#   define yystrlen strlen
#  else
/* Return the length of YYSTR.  */
static YYSIZE_T
yystrlen (const char *yystr)
{
  YYSIZE_T yylen;
  for (yylen = 0; yystr[yylen]; yylen++)
    continue;
  return yylen;
}
#  endif
# endif

# ifndef yystpcpy
#  if defined __GLIBC__ && defined _STRING_H && defined _GNU_SOURCE
#   define yystpcpy stpcpy
#  else
/* Copy YYSRC to YYDEST, returning the address of the terminating '\0' in
   YYDEST.  */
static char *
yystpcpy (char *yydest, const char *yysrc)
{
  char *yyd = yydest;
  const char *yys = yysrc;

  while ((*yyd++ = *yys++) != '\0')
    continue;

  return yyd - 1;
}
#  endif
# endif

# ifndef yytnamerr
/* Copy to YYRES the contents of YYSTR after stripping away unnecessary
   quotes and backslashes, so that it's suitable for yyerror.  The
   heuristic is that double-quoting is unnecessary unless the string
   contains an apostrophe, a comma, or backslash (other than
   backslash-backslash).  YYSTR is taken from yytname.  If YYRES is
   null, do not copy; instead, return the length of what the result
   would have been.  */
static YYSIZE_T
yytnamerr (char *yyres, const char *yystr)
{
  if (*yystr == '"')
    {
      YYSIZE_T yyn = 0;
      char const *yyp = yystr;

      for (;;)
        switch (*++yyp)
          {
          case '\'':
          case ',':
            goto do_not_strip_quotes;

          case '\\':
            if (*++yyp != '\\')
              goto do_not_strip_quotes;
            /* Fall through.  */
          default:
            if (yyres)
              yyres[yyn] = *yyp;
            yyn++;
            break;

          case '"':
            if (yyres)
              yyres[yyn] = '\0';
            return yyn;
          }
    do_not_strip_quotes: ;
    }

  if (! yyres)
    return yystrlen (yystr);

  return yystpcpy (yyres, yystr) - yyres;
}
# endif

/* Copy into *YYMSG, which is of size *YYMSG_ALLOC, an error message
   about the unexpected token YYTOKEN for the state stack whose top is
   YYSSP.

   Return 0 if *YYMSG was successfully written.  Return 1 if *YYMSG is
   not large enough to hold the message.  In that case, also set
   *YYMSG_ALLOC to the required number of bytes.  Return 2 if the
   required number of bytes is too large to store.  */
static int
yysyntax_error (YYSIZE_T *yymsg_alloc, char **yymsg,
                yytype_int16 *yyssp, int yytoken)
{
  YYSIZE_T yysize0 = yytnamerr (YY_NULLPTR, yytname[yytoken]);
  YYSIZE_T yysize = yysize0;
  enum { YYERROR_VERBOSE_ARGS_MAXIMUM = 5 };
  /* Internationalized format string. */
  const char *yyformat = YY_NULLPTR;
  /* Arguments of yyformat. */
  char const *yyarg[YYERROR_VERBOSE_ARGS_MAXIMUM];
  /* Number of reported tokens (one for the "unexpected", one per
     "expected"). */
  int yycount = 0;

  /* There are many possibilities here to consider:
     - If this state is a consistent state with a default action, then
       the only way this function was invoked is if the default action
       is an error action.  In that case, don't check for expected
       tokens because there are none.
     - The only way there can be no lookahead present (in yychar) is if
       this state is a consistent state with a default action.  Thus,
       detecting the absence of a lookahead is sufficient to determine
       that there is no unexpected or expected token to report.  In that
       case, just report a simple "syntax error".
     - Don't assume there isn't a lookahead just because this state is a
       consistent state with a default action.  There might have been a
       previous inconsistent state, consistent state with a non-default
       action, or user semantic action that manipulated yychar.
     - Of course, the expected token list depends on states to have
       correct lookahead information, and it depends on the parser not
       to perform extra reductions after fetching a lookahead from the
       scanner and before detecting a syntax error.  Thus, state merging
       (from LALR or IELR) and default reductions corrupt the expected
       token list.  However, the list is correct for canonical LR with
       one exception: it will still contain any token that will not be
       accepted due to an error action in a later state.
  */
  if (yytoken != YYEMPTY)
    {
      int yyn = yypact[*yyssp];
      yyarg[yycount++] = yytname[yytoken];
      if (!yypact_value_is_default (yyn))
        {
          /* Start YYX at -YYN if negative to avoid negative indexes in
             YYCHECK.  In other words, skip the first -YYN actions for
             this state because they are default actions.  */
          int yyxbegin = yyn < 0 ? -yyn : 0;
          /* Stay within bounds of both yycheck and yytname.  */
          int yychecklim = YYLAST - yyn + 1;
          int yyxend = yychecklim < YYNTOKENS ? yychecklim : YYNTOKENS;
          int yyx;

          for (yyx = yyxbegin; yyx < yyxend; ++yyx)
            if (yycheck[yyx + yyn] == yyx && yyx != YYTERROR
                && !yytable_value_is_error (yytable[yyx + yyn]))
              {
                if (yycount == YYERROR_VERBOSE_ARGS_MAXIMUM)
                  {
                    yycount = 1;
                    yysize = yysize0;
                    break;
                  }
                yyarg[yycount++] = yytname[yyx];
                {
                  YYSIZE_T yysize1 = yysize + yytnamerr (YY_NULLPTR, yytname[yyx]);
                  if (! (yysize <= yysize1
                         && yysize1 <= YYSTACK_ALLOC_MAXIMUM))
                    return 2;
                  yysize = yysize1;
                }
              }
        }
    }

  switch (yycount)
    {
# define YYCASE_(N, S)                      \
      case N:                               \
        yyformat = S;                       \
      break
      YYCASE_(0, YY_("syntax error"));
      YYCASE_(1, YY_("syntax error, unexpected %s"));
      YYCASE_(2, YY_("syntax error, unexpected %s, expecting %s"));
      YYCASE_(3, YY_("syntax error, unexpected %s, expecting %s or %s"));
      YYCASE_(4, YY_("syntax error, unexpected %s, expecting %s or %s or %s"));
      YYCASE_(5, YY_("syntax error, unexpected %s, expecting %s or %s or %s or %s"));
# undef YYCASE_
    }

  {
    YYSIZE_T yysize1 = yysize + yystrlen (yyformat);
    if (! (yysize <= yysize1 && yysize1 <= YYSTACK_ALLOC_MAXIMUM))
      return 2;
    yysize = yysize1;
  }

  if (*yymsg_alloc < yysize)
    {
      *yymsg_alloc = 2 * yysize;
      if (! (yysize <= *yymsg_alloc
             && *yymsg_alloc <= YYSTACK_ALLOC_MAXIMUM))
        *yymsg_alloc = YYSTACK_ALLOC_MAXIMUM;
      return 1;
    }

  /* Avoid sprintf, as that infringes on the user's name space.
     Don't have undefined behavior even if the translation
     produced a string with the wrong number of "%s"s.  */
  {
    char *yyp = *yymsg;
    int yyi = 0;
    while ((*yyp = *yyformat) != '\0')
      if (*yyp == '%' && yyformat[1] == 's' && yyi < yycount)
        {
          yyp += yytnamerr (yyp, yyarg[yyi++]);
          yyformat += 2;
        }
      else
        {
          yyp++;
          yyformat++;
        }
  }
  return 0;
}
#endif /* YYERROR_VERBOSE */

/*-----------------------------------------------.
| Release the memory associated to this symbol.  |
`-----------------------------------------------*/

static void
yydestruct (const char *yymsg, int yytype, YYSTYPE *yyvaluep)
{
  YYUSE (yyvaluep);
  if (!yymsg)
    yymsg = "Deleting";
  YY_SYMBOL_PRINT (yymsg, yytype, yyvaluep, yylocationp);

  YY_IGNORE_MAYBE_UNINITIALIZED_BEGIN
  YYUSE (yytype);
  YY_IGNORE_MAYBE_UNINITIALIZED_END
}




/* The lookahead symbol.  */
int yychar;

/* The semantic value of the lookahead symbol.  */
YYSTYPE yylval;
/* Number of syntax errors so far.  */
int yynerrs;


/*----------.
| yyparse.  |
`----------*/

int
yyparse (void)
{
    int yystate;
    /* Number of tokens to shift before error messages enabled.  */
    int yyerrstatus;

    /* The stacks and their tools:
       'yyss': related to states.
       'yyvs': related to semantic values.

       Refer to the stacks through separate pointers, to allow yyoverflow
       to reallocate them elsewhere.  */

    /* The state stack.  */
    yytype_int16 yyssa[YYINITDEPTH];
    yytype_int16 *yyss;
    yytype_int16 *yyssp;

    /* The semantic value stack.  */
    YYSTYPE yyvsa[YYINITDEPTH];
    YYSTYPE *yyvs;
    YYSTYPE *yyvsp;

    YYSIZE_T yystacksize;

  int yyn;
  int yyresult;
  /* Lookahead token as an internal (translated) token number.  */
  int yytoken = 0;
  /* The variables used to return semantic value and location from the
     action routines.  */
  YYSTYPE yyval;

#if YYERROR_VERBOSE
  /* Buffer for error messages, and its allocated size.  */
  char yymsgbuf[128];
  char *yymsg = yymsgbuf;
  YYSIZE_T yymsg_alloc = sizeof yymsgbuf;
#endif

#define YYPOPSTACK(N)   (yyvsp -= (N), yyssp -= (N))

  /* The number of symbols on the RHS of the reduced rule.
     Keep to zero when no symbol should be popped.  */
  int yylen = 0;

  yyssp = yyss = yyssa;
  yyvsp = yyvs = yyvsa;
  yystacksize = YYINITDEPTH;

  YYDPRINTF ((stderr, "Starting parse\n"));

  yystate = 0;
  yyerrstatus = 0;
  yynerrs = 0;
  yychar = YYEMPTY; /* Cause a token to be read.  */
  goto yysetstate;

/*------------------------------------------------------------.
| yynewstate -- Push a new state, which is found in yystate.  |
`------------------------------------------------------------*/
 yynewstate:
  /* In all cases, when you get here, the value and location stacks
     have just been pushed.  So pushing a state here evens the stacks.  */
  yyssp++;

 yysetstate:
  *yyssp = yystate;

  if (yyss + yystacksize - 1 <= yyssp)
    {
      /* Get the current used size of the three stacks, in elements.  */
      YYSIZE_T yysize = yyssp - yyss + 1;

#ifdef yyoverflow
      {
        /* Give user a chance to reallocate the stack.  Use copies of
           these so that the &'s don't force the real ones into
           memory.  */
        YYSTYPE *yyvs1 = yyvs;
        yytype_int16 *yyss1 = yyss;

        /* Each stack pointer address is followed by the size of the
           data in use in that stack, in bytes.  This used to be a
           conditional around just the two extra args, but that might
           be undefined if yyoverflow is a macro.  */
        yyoverflow (YY_("memory exhausted"),
                    &yyss1, yysize * sizeof (*yyssp),
                    &yyvs1, yysize * sizeof (*yyvsp),
                    &yystacksize);

        yyss = yyss1;
        yyvs = yyvs1;
      }
#else /* no yyoverflow */
# ifndef YYSTACK_RELOCATE
      goto yyexhaustedlab;
# else
      /* Extend the stack our own way.  */
      if (YYMAXDEPTH <= yystacksize)
        goto yyexhaustedlab;
      yystacksize *= 2;
      if (YYMAXDEPTH < yystacksize)
        yystacksize = YYMAXDEPTH;

      {
        yytype_int16 *yyss1 = yyss;
        union yyalloc *yyptr =
          (union yyalloc *) YYSTACK_ALLOC (YYSTACK_BYTES (yystacksize));
        if (! yyptr)
          goto yyexhaustedlab;
        YYSTACK_RELOCATE (yyss_alloc, yyss);
        YYSTACK_RELOCATE (yyvs_alloc, yyvs);
#  undef YYSTACK_RELOCATE
        if (yyss1 != yyssa)
          YYSTACK_FREE (yyss1);
      }
# endif
#endif /* no yyoverflow */

      yyssp = yyss + yysize - 1;
      yyvsp = yyvs + yysize - 1;

      YYDPRINTF ((stderr, "Stack size increased to %lu\n",
                  (unsigned long int) yystacksize));

      if (yyss + yystacksize - 1 <= yyssp)
        YYABORT;
    }

  YYDPRINTF ((stderr, "Entering state %d\n", yystate));

  if (yystate == YYFINAL)
    YYACCEPT;

  goto yybackup;

/*-----------.
| yybackup.  |
`-----------*/
yybackup:

  /* Do appropriate processing given the current state.  Read a
     lookahead token if we need one and don't already have one.  */

  /* First try to decide what to do without reference to lookahead token.  */
  yyn = yypact[yystate];
  if (yypact_value_is_default (yyn))
    goto yydefault;

  /* Not known => get a lookahead token if don't already have one.  */

  /* YYCHAR is either YYEMPTY or YYEOF or a valid lookahead symbol.  */
  if (yychar == YYEMPTY)
    {
      YYDPRINTF ((stderr, "Reading a token: "));
      yychar = yylex ();
    }

  if (yychar <= YYEOF)
    {
      yychar = yytoken = YYEOF;
      YYDPRINTF ((stderr, "Now at end of input.\n"));
    }
  else
    {
      yytoken = YYTRANSLATE (yychar);
      YY_SYMBOL_PRINT ("Next token is", yytoken, &yylval, &yylloc);
    }

  /* If the proper action on seeing token YYTOKEN is to reduce or to
     detect an error, take that action.  */
  yyn += yytoken;
  if (yyn < 0 || YYLAST < yyn || yycheck[yyn] != yytoken)
    goto yydefault;
  yyn = yytable[yyn];
  if (yyn <= 0)
    {
      if (yytable_value_is_error (yyn))
        goto yyerrlab;
      yyn = -yyn;
      goto yyreduce;
    }

  /* Count tokens shifted since error; after three, turn off error
     status.  */
  if (yyerrstatus)
    yyerrstatus--;

  /* Shift the lookahead token.  */
  YY_SYMBOL_PRINT ("Shifting", yytoken, &yylval, &yylloc);

  /* Discard the shifted token.  */
  yychar = YYEMPTY;

  yystate = yyn;
  YY_IGNORE_MAYBE_UNINITIALIZED_BEGIN
  *++yyvsp = yylval;
  YY_IGNORE_MAYBE_UNINITIALIZED_END

  goto yynewstate;


/*-----------------------------------------------------------.
| yydefault -- do the default action for the current state.  |
`-----------------------------------------------------------*/
yydefault:
  yyn = yydefact[yystate];
  if (yyn == 0)
    goto yyerrlab;
  goto yyreduce;


/*-----------------------------.
| yyreduce -- Do a reduction.  |
`-----------------------------*/
yyreduce:
  /* yyn is the number of a rule to reduce with.  */
  yylen = yyr2[yyn];

  /* If YYLEN is nonzero, implement the default value of the action:
     '$$ = $1'.

     Otherwise, the following line sets YYVAL to garbage.
     This behavior is undocumented and Bison
     users should not rely upon it.  Assigning to YYVAL
     unconditionally makes the parser a bit smaller, and it avoids a
     GCC warning that YYVAL may be used uninitialized.  */
  yyval = yyvsp[1-yylen];


  YY_REDUCE_PRINT (yyn);
  switch (yyn)
    {
        case 13:
#line 100 "lex.y" /* yacc.c:1646  */
    {string flag_name = (yyvsp[0].str).substr(1); jump_list["__" + flag_name]=line_num;}
#line 1640 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 14:
#line 103 "lex.y" /* yacc.c:1646  */
    {(yyval.str) = "__" + (yyvsp[0].str).substr(1);}
#line 1646 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 15:
#line 106 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"LET vv %s %s\n",(yyvsp[-2].str).c_str(),(yyvsp[0].str).c_str()); line_num++;}
#line 1652 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 16:
#line 107 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"LET vv %s %s\n",(yyvsp[-2].str).c_str(),(yyvsp[0].str).c_str()); line_num++;}
#line 1658 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 17:
#line 110 "lex.y" /* yacc.c:1646  */
    {(yyval.str) = (yyvsp[0].str);}
#line 1664 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 18:
#line 111 "lex.y" /* yacc.c:1646  */
    {(yyval.str) = (yyvsp[0].str);}
#line 1670 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 19:
#line 112 "lex.y" /* yacc.c:1646  */
    {(yyval.str) = (yyvsp[0].str);}
#line 1676 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 20:
#line 113 "lex.y" /* yacc.c:1646  */
    {(yyval.str) = (yyvsp[0].str);}
#line 1682 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 21:
#line 114 "lex.y" /* yacc.c:1646  */
    {(yyval.str) = (yyvsp[0].str);}
#line 1688 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 22:
#line 115 "lex.y" /* yacc.c:1646  */
    {(yyval.str) = (yyvsp[0].str);}
#line 1694 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 23:
#line 118 "lex.y" /* yacc.c:1646  */
    { int now = line_num; (yyval.str) = "_" + to_string(now); fprintf(script_file,"ADD vvv %s %s %s\n",	(yyvsp[-2].str).c_str(),		(yyvsp[0].str).c_str(),	(yyval.str).c_str()); line_num++; }
#line 1700 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 24:
#line 119 "lex.y" /* yacc.c:1646  */
    { int now = line_num; (yyval.str) = "_" + to_string(now); fprintf(script_file,"ADD vvv %s %s %s\n",	(yyvsp[-2].str).c_str(),		(yyvsp[0].str).c_str(),	(yyval.str).c_str()); line_num++; }
#line 1706 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 25:
#line 120 "lex.y" /* yacc.c:1646  */
    { int now = line_num; (yyval.str) = "_" + to_string(now); fprintf(script_file,"ADD vvv %s %s %s\n",	(yyvsp[-2].str).c_str(),		(yyvsp[0].str).c_str(),	(yyval.str).c_str()); line_num++; }
#line 1712 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 26:
#line 121 "lex.y" /* yacc.c:1646  */
    { int now = line_num; (yyval.str) = "_" + to_string(now); fprintf(script_file,"SUB vvv %s %s %s\n",	(yyvsp[-2].str).c_str(),		(yyvsp[0].str).c_str(),	(yyval.str).c_str()); line_num++; }
#line 1718 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 27:
#line 122 "lex.y" /* yacc.c:1646  */
    { int now = line_num; (yyval.str) = "_" + to_string(now); fprintf(script_file,"SUB vvv %s %s %s\n",	(yyvsp[-2].str).c_str(),		(yyvsp[0].str).c_str(),	(yyval.str).c_str()); line_num++; }
#line 1724 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 28:
#line 123 "lex.y" /* yacc.c:1646  */
    { int now = line_num; (yyval.str) = "_" + to_string(now); fprintf(script_file,"SUB vvv %s %s %s\n",	(yyvsp[-2].str).c_str(),		(yyvsp[0].str).c_str(),	(yyval.str).c_str()); line_num++; }
#line 1730 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 29:
#line 124 "lex.y" /* yacc.c:1646  */
    { int now = line_num; (yyval.str) = "_" + to_string(now); fprintf(script_file,"MUL vvv %s %s %s\n",	(yyvsp[-2].str).c_str(),		(yyvsp[0].str).c_str(),	(yyval.str).c_str()); line_num++; }
#line 1736 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 30:
#line 125 "lex.y" /* yacc.c:1646  */
    { int now = line_num; (yyval.str) = "_" + to_string(now); fprintf(script_file,"MUL vvv %s %s %s\n",	(yyvsp[-2].str).c_str(),		(yyvsp[0].str).c_str(),	(yyval.str).c_str()); line_num++; }
#line 1742 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 31:
#line 126 "lex.y" /* yacc.c:1646  */
    { int now = line_num; (yyval.str) = "_" + to_string(now); fprintf(script_file,"MUL vvv %s %s %s\n",	(yyvsp[-2].str).c_str(),		(yyvsp[0].str).c_str(),	(yyval.str).c_str()); line_num++; }
#line 1748 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 32:
#line 127 "lex.y" /* yacc.c:1646  */
    { int now = line_num; (yyval.str) = "_" + to_string(now); fprintf(script_file,"DIV vvv %s %s %s\n",	(yyvsp[-2].str).c_str(),		(yyvsp[0].str).c_str(),	(yyval.str).c_str()); line_num++; }
#line 1754 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 33:
#line 128 "lex.y" /* yacc.c:1646  */
    { int now = line_num; (yyval.str) = "_" + to_string(now); fprintf(script_file,"DIV vvv %s %s %s\n",	(yyvsp[-2].str).c_str(),		(yyvsp[0].str).c_str(),	(yyval.str).c_str()); line_num++; }
#line 1760 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 34:
#line 129 "lex.y" /* yacc.c:1646  */
    { int now = line_num; (yyval.str) = "_" + to_string(now); fprintf(script_file,"DIV vvv %s %s %s\n",	(yyvsp[-2].str).c_str(),		(yyvsp[0].str).c_str(),	(yyval.str).c_str()); line_num++; }
#line 1766 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 35:
#line 130 "lex.y" /* yacc.c:1646  */
    { int now = line_num; (yyval.str) = "_" + to_string(now); fprintf(script_file,"MOD vvv %s %s %s\n",	(yyvsp[-2].str).c_str(),		(yyvsp[0].str).c_str(),	(yyval.str).c_str()); line_num++; }
#line 1772 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 36:
#line 131 "lex.y" /* yacc.c:1646  */
    { int now = line_num; (yyval.str) = "_" + to_string(now); fprintf(script_file,"MOD vvv %s %s %s\n",	(yyvsp[-2].str).c_str(),		(yyvsp[0].str).c_str(),	(yyval.str).c_str()); line_num++; }
#line 1778 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 37:
#line 132 "lex.y" /* yacc.c:1646  */
    { int now = line_num; (yyval.str) = "_" + to_string(now); fprintf(script_file,"MOD vvv %s %s %s\n",	(yyvsp[-2].str).c_str(),		(yyvsp[0].str).c_str(),	(yyval.str).c_str()); line_num++; }
#line 1784 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 38:
#line 135 "lex.y" /* yacc.c:1646  */
    { (yyval.str) = (yyvsp[0].str);}
#line 1790 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 39:
#line 136 "lex.y" /* yacc.c:1646  */
    { (yyval.str) = (yyvsp[0].str);}
#line 1796 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 40:
#line 137 "lex.y" /* yacc.c:1646  */
    { (yyval.str) = (yyvsp[0].str);}
#line 1802 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 41:
#line 140 "lex.y" /* yacc.c:1646  */
    { int now = line_num; (yyval.str) = "_" + to_string(now); fprintf(script_file,"LET vn %s %d\n",(yyval.str).c_str(),(yyvsp[0].num)); line_num++; }
#line 1808 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 42:
#line 141 "lex.y" /* yacc.c:1646  */
    { (yyval.str) = (yyvsp[-1].str); }
#line 1814 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 43:
#line 142 "lex.y" /* yacc.c:1646  */
    { int now = line_num; (yyval.str) = "_" + to_string(now); fprintf(script_file,"ADD vvv %s %s %s\n",	(yyvsp[-2].str).c_str(),		(yyvsp[0].str).c_str(),	(yyval.str).c_str()); line_num++; }
#line 1820 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 44:
#line 143 "lex.y" /* yacc.c:1646  */
    { int now = line_num; (yyval.str) = "_" + to_string(now); fprintf(script_file,"SUB vvv %s %s %s\n",	(yyvsp[-2].str).c_str(),		(yyvsp[0].str).c_str(),	(yyval.str).c_str()); line_num++; }
#line 1826 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 45:
#line 144 "lex.y" /* yacc.c:1646  */
    { int now = line_num; (yyval.str) = "_" + to_string(now); fprintf(script_file,"MUL vvv %s %s %s\n",	(yyvsp[-2].str).c_str(),		(yyvsp[0].str).c_str(),	(yyval.str).c_str()); line_num++; }
#line 1832 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 46:
#line 145 "lex.y" /* yacc.c:1646  */
    { int now = line_num; (yyval.str) = "_" + to_string(now); fprintf(script_file,"DIV vvv %s %s %s\n",	(yyvsp[-2].str).c_str(),		(yyvsp[0].str).c_str(),	(yyval.str).c_str()); line_num++; }
#line 1838 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 47:
#line 146 "lex.y" /* yacc.c:1646  */
    { int now = line_num; (yyval.str) = "_" + to_string(now); fprintf(script_file,"MOD vvv %s %s %s\n",  (yyvsp[-2].str).c_str(),     (yyvsp[0].str).c_str(), (yyval.str).c_str()); line_num++; }
#line 1844 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 48:
#line 149 "lex.y" /* yacc.c:1646  */
    { int now = line_num; (yyval.str) = "_" + to_string(now); fprintf(script_file,"ADD vvv %s %s %s\n",	(yyvsp[-2].str).c_str(),		(yyvsp[0].str).c_str(),	(yyval.str).c_str()); line_num++; }
#line 1850 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 49:
#line 150 "lex.y" /* yacc.c:1646  */
    { int now = line_num; (yyval.str) = "_" + to_string(now); fprintf(script_file,"ADD vvv %s %s %s\n",	(yyvsp[-2].str).c_str(),		(yyvsp[0].str).c_str(),	(yyval.str).c_str()); line_num++; }
#line 1856 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 50:
#line 153 "lex.y" /* yacc.c:1646  */
    {(yyval.str) = (yyvsp[0].str);}
#line 1862 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 51:
#line 154 "lex.y" /* yacc.c:1646  */
    {(yyval.str) = (yyvsp[0].str);}
#line 1868 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 52:
#line 155 "lex.y" /* yacc.c:1646  */
    {(yyval.str) = (yyvsp[0].str);}
#line 1874 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 53:
#line 158 "lex.y" /* yacc.c:1646  */
    { int now = line_num; (yyval.str) = "_" + to_string(now); fprintf(script_file,"LET vs %s %s\n",(yyval.str).c_str(),(yyvsp[0].str).c_str()); line_num++; }
#line 1880 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 54:
#line 159 "lex.y" /* yacc.c:1646  */
    { int now = line_num; (yyval.str) = "_" + to_string(now); fprintf(script_file,"ADD vvv %s %s %s\n",	(yyvsp[-2].str).c_str(),		(yyvsp[0].str).c_str(),	(yyval.str).c_str()); line_num++; }
#line 1886 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 55:
#line 162 "lex.y" /* yacc.c:1646  */
    { int now = line_num; (yyval.str) = "_" + to_string(now); fprintf(script_file,"GT vvv %s %s %s\n",(yyvsp[-2].str).c_str(),(yyvsp[0].str).c_str(),(yyval.str).c_str());line_num++;}
#line 1892 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 56:
#line 163 "lex.y" /* yacc.c:1646  */
    { int now = line_num; (yyval.str) = "_" + to_string(now); fprintf(script_file,"LT vvv %s %s %s\n",(yyvsp[-2].str).c_str(),(yyvsp[0].str).c_str(),(yyval.str).c_str());line_num++;}
#line 1898 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 57:
#line 164 "lex.y" /* yacc.c:1646  */
    { int now = line_num; (yyval.str) = "_" + to_string(now); fprintf(script_file,"GE vvv %s %s %s\n",(yyvsp[-2].str).c_str(),(yyvsp[0].str).c_str(),(yyval.str).c_str());line_num++;}
#line 1904 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 58:
#line 165 "lex.y" /* yacc.c:1646  */
    { int now = line_num; (yyval.str) = "_" + to_string(now); fprintf(script_file,"LE vvv %s %s %s\n",(yyvsp[-2].str).c_str(),(yyvsp[0].str).c_str(),(yyval.str).c_str());line_num++;}
#line 1910 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 59:
#line 166 "lex.y" /* yacc.c:1646  */
    { int now = line_num; (yyval.str) = "_" + to_string(now); fprintf(script_file,"EQ vvv %s %s %s\n",(yyvsp[-2].str).c_str(),(yyvsp[0].str).c_str(),(yyval.str).c_str());line_num++;}
#line 1916 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 60:
#line 167 "lex.y" /* yacc.c:1646  */
    { int now = line_num; (yyval.str) = "_" + to_string(now); fprintf(script_file,"GT vvv %s %s %s\n",(yyvsp[-2].str).c_str(),(yyvsp[0].str).c_str(),(yyval.str).c_str());line_num++;}
#line 1922 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 61:
#line 168 "lex.y" /* yacc.c:1646  */
    { int now = line_num; (yyval.str) = "_" + to_string(now); fprintf(script_file,"LT vvv %s %s %s\n",(yyvsp[-2].str).c_str(),(yyvsp[0].str).c_str(),(yyval.str).c_str());line_num++;}
#line 1928 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 62:
#line 169 "lex.y" /* yacc.c:1646  */
    { int now = line_num; (yyval.str) = "_" + to_string(now); fprintf(script_file,"GE vvv %s %s %s\n",(yyvsp[-2].str).c_str(),(yyvsp[0].str).c_str(),(yyval.str).c_str());line_num++;}
#line 1934 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 63:
#line 170 "lex.y" /* yacc.c:1646  */
    { int now = line_num; (yyval.str) = "_" + to_string(now); fprintf(script_file,"LE vvv %s %s %s\n",(yyvsp[-2].str).c_str(),(yyvsp[0].str).c_str(),(yyval.str).c_str());line_num++;}
#line 1940 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 64:
#line 171 "lex.y" /* yacc.c:1646  */
    { int now = line_num; (yyval.str) = "_" + to_string(now); fprintf(script_file,"EQ vvv %s %s %s\n",(yyvsp[-2].str).c_str(),(yyvsp[0].str).c_str(),(yyval.str).c_str());line_num++;}
#line 1946 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 65:
#line 172 "lex.y" /* yacc.c:1646  */
    { int now = line_num; (yyval.str) = "_" + to_string(now); fprintf(script_file,"GT vvv %s %s %s\n",(yyvsp[-2].str).c_str(),(yyvsp[0].str).c_str(),(yyval.str).c_str());line_num++;}
#line 1952 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 66:
#line 173 "lex.y" /* yacc.c:1646  */
    { int now = line_num; (yyval.str) = "_" + to_string(now); fprintf(script_file,"LT vvv %s %s %s\n",(yyvsp[-2].str).c_str(),(yyvsp[0].str).c_str(),(yyval.str).c_str());line_num++;}
#line 1958 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 67:
#line 174 "lex.y" /* yacc.c:1646  */
    { int now = line_num; (yyval.str) = "_" + to_string(now); fprintf(script_file,"GE vvv %s %s %s\n",(yyvsp[-2].str).c_str(),(yyvsp[0].str).c_str(),(yyval.str).c_str());line_num++;}
#line 1964 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 68:
#line 175 "lex.y" /* yacc.c:1646  */
    { int now = line_num; (yyval.str) = "_" + to_string(now); fprintf(script_file,"LE vvv %s %s %s\n",(yyvsp[-2].str).c_str(),(yyvsp[0].str).c_str(),(yyval.str).c_str());line_num++;}
#line 1970 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 69:
#line 176 "lex.y" /* yacc.c:1646  */
    { int now = line_num; (yyval.str) = "_" + to_string(now); fprintf(script_file,"EQ vvv %s %s %s\n",(yyvsp[-2].str).c_str(),(yyvsp[0].str).c_str(),(yyval.str).c_str());line_num++;}
#line 1976 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 70:
#line 179 "lex.y" /* yacc.c:1646  */
    {(yyval.str) = (yyvsp[0].str);}
#line 1982 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 71:
#line 180 "lex.y" /* yacc.c:1646  */
    {(yyval.str) = (yyvsp[0].str);}
#line 1988 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 72:
#line 181 "lex.y" /* yacc.c:1646  */
    {(yyval.str) = (yyvsp[0].str);}
#line 1994 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 73:
#line 184 "lex.y" /* yacc.c:1646  */
    { int now = line_num; (yyval.str) = "_" + to_string(now); fprintf(script_file,"LET vb %s %d\n",(yyval.str).c_str(),(yyvsp[0].boolean)); line_num++;}
#line 2000 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 74:
#line 185 "lex.y" /* yacc.c:1646  */
    {(yyval.str) = (yyvsp[-1].str);}
#line 2006 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 75:
#line 186 "lex.y" /* yacc.c:1646  */
    { int now = line_num; (yyval.str) = "_" + to_string(now); fprintf(script_file,"GT vvv %s %s %s\n",(yyvsp[-2].str).c_str(),(yyvsp[0].str).c_str(),(yyval.str).c_str());line_num++;}
#line 2012 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 76:
#line 187 "lex.y" /* yacc.c:1646  */
    { int now = line_num; (yyval.str) = "_" + to_string(now); fprintf(script_file,"LT vvv %s %s %s\n",(yyvsp[-2].str).c_str(),(yyvsp[0].str).c_str(),(yyval.str).c_str());line_num++;}
#line 2018 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 77:
#line 188 "lex.y" /* yacc.c:1646  */
    { int now = line_num; (yyval.str) = "_" + to_string(now); fprintf(script_file,"GE vvv %s %s %s\n",(yyvsp[-2].str).c_str(),(yyvsp[0].str).c_str(),(yyval.str).c_str());line_num++;}
#line 2024 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 78:
#line 189 "lex.y" /* yacc.c:1646  */
    { int now = line_num; (yyval.str) = "_" + to_string(now); fprintf(script_file,"LE vvv %s %s %s\n",(yyvsp[-2].str).c_str(),(yyvsp[0].str).c_str(),(yyval.str).c_str());line_num++;}
#line 2030 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 79:
#line 190 "lex.y" /* yacc.c:1646  */
    { int now = line_num; (yyval.str) = "_" + to_string(now); fprintf(script_file,"EQ vvv %s %s %s\n",(yyvsp[-2].str).c_str(),(yyvsp[0].str).c_str(),(yyval.str).c_str());line_num++;}
#line 2036 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 80:
#line 193 "lex.y" /* yacc.c:1646  */
    {(yyval.str) = (yyvsp[0].str);}
#line 2042 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 81:
#line 196 "lex.y" /* yacc.c:1646  */
    {(yyval.str) = (yyvsp[0].str);}
#line 2048 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 82:
#line 197 "lex.y" /* yacc.c:1646  */
    { (yyval.str) =(yyvsp[0].str); }
#line 2054 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 83:
#line 200 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"LD psnn %s %s %s %s\n",(yyvsp[-6].str).c_str(),(yyvsp[-4].str).c_str(),(yyvsp[-2].str).c_str(),(yyvsp[0].str).c_str());line_num++;}
#line 2060 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 84:
#line 201 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"LD psn %s %s %s\n",(yyvsp[-4].str).c_str(),(yyvsp[-2].str).c_str(),(yyvsp[0].str).c_str());line_num++;}
#line 2066 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 85:
#line 202 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"LD ps %s %s\n",(yyvsp[-2].str).c_str(),(yyvsp[0].str).c_str());line_num++;}
#line 2072 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 86:
#line 203 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"BG snn %s %s %s\n",(yyvsp[-4].str).c_str(),(yyvsp[-2].str).c_str(),(yyvsp[0].str).c_str());line_num++;}
#line 2078 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 87:
#line 204 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"BG sn %s %s\n",(yyvsp[-2].str).c_str(),(yyvsp[0].str).c_str());line_num++;}
#line 2084 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 88:
#line 205 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"BG s %s\n",(yyvsp[0].str).c_str());line_num++;}
#line 2090 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 89:
#line 206 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"BG cnn %s %s %s\n",(yyvsp[-4].str).c_str(),(yyvsp[-2].str).c_str(),(yyvsp[0].str).c_str()); line_num++;}
#line 2096 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 90:
#line 207 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"BG cn %s %s\n",(yyvsp[-2].str).c_str(),(yyvsp[0].str).c_str());line_num++;}
#line 2102 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 91:
#line 208 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"BG c %s\n",(yyvsp[0].str).c_str());line_num++;}
#line 2108 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 92:
#line 209 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"CL pnn %s %s %s\n",(yyvsp[-4].str).c_str(),(yyvsp[-2].str).c_str(),(yyvsp[0].str).c_str());line_num++;}
#line 2114 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 93:
#line 210 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"CL pn %s %s\n",(yyvsp[-2].str).c_str(),(yyvsp[0].str).c_str());line_num++;}
#line 2120 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 94:
#line 211 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"CL p %s\n",(yyvsp[0].str).c_str());line_num++;}
#line 2126 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 95:
#line 212 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"CHANGESCENE s %s\n",(yyvsp[0].str).c_str());line_num++;}
#line 2132 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 96:
#line 213 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"LSP ssnnb %s %s %s %s %s\n",(yyvsp[-8].str).c_str(),(yyvsp[-6].str).c_str(),(yyvsp[-4].str).c_str(),(yyvsp[-2].str).c_str(),(yyvsp[0].str).c_str());line_num++;}
#line 2138 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 97:
#line 214 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"LSP ssnn %s %s %s %s\n",(yyvsp[-6].str).c_str(),(yyvsp[-4].str).c_str(),(yyvsp[-2].str).c_str(),(yyvsp[0].str).c_str());line_num++;}
#line 2144 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 98:
#line 215 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"LSPH ssnnb %s %s %s %s %s\n",(yyvsp[-8].str).c_str(),(yyvsp[-6].str).c_str(),(yyvsp[-4].str).c_str(),(yyvsp[-2].str).c_str(),(yyvsp[0].str).c_str());line_num++;}
#line 2150 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 99:
#line 216 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"LSPH ssnn %s %s %s %s\n",(yyvsp[-6].str).c_str(),(yyvsp[-4].str).c_str(),(yyvsp[-2].str).c_str(),(yyvsp[0].str).c_str());line_num++;}
#line 2156 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 100:
#line 217 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"MOVIE s %s\n",(yyvsp[0].str).c_str());line_num++;}
#line 2162 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 101:
#line 218 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"DEFBUTTON snnssss %s %s %s %s %s %s %s\n",(yyvsp[-12].str).c_str(),(yyvsp[-10].str).c_str(),(yyvsp[-8].str).c_str(),(yyvsp[-6].str).c_str(),(yyvsp[-4].str).c_str(),(yyvsp[-2].str).c_str(),(yyvsp[0].str).c_str());line_num++;}
#line 2168 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 102:
#line 219 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"DEFBUTTON snnss %s %s %s %s %s\n",(yyvsp[-8].str).c_str(),(yyvsp[-6].str).c_str(),(yyvsp[-4].str).c_str(),(yyvsp[-2].str).c_str(),(yyvsp[0].str).c_str());line_num++;}
#line 2174 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 103:
#line 220 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"DEFBUTTON snns %s %s %s %s\n",(yyvsp[-6].str).c_str(),(yyvsp[-4].str).c_str(),(yyvsp[-2].str).c_str(),(yyvsp[0].str).c_str());line_num++;}
#line 2180 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 104:
#line 221 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"BUTTON pnnsn %s %s %s %s %s\n",(yyvsp[-8].str).c_str(),(yyvsp[-6].str).c_str(),(yyvsp[-4].str).c_str(),(yyvsp[-2].str).c_str(),(yyvsp[0].str).c_str());line_num++;}
#line 2186 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 105:
#line 222 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"SELECT\n");line_num++;}
#line 2192 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 106:
#line 223 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"SELECT vs %s %s\n",(yyvsp[-2].str).c_str(),(yyvsp[0].str).c_str());line_num++;}
#line 2198 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 107:
#line 224 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"BGM ss %s %s\n",(yyvsp[-2].str).c_str(),(yyvsp[0].str).c_str());line_num++;}
#line 2204 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 108:
#line 225 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"BGM s %s\n",(yyvsp[0].str).c_str());line_num++;}
#line 2210 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 109:
#line 226 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"BGMSTOP\n");line_num++;}
#line 2216 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 110:
#line 227 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"SE ss %s %s\n",(yyvsp[-2].str).c_str(),(yyvsp[0].str).c_str());line_num++;}
#line 2222 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 111:
#line 228 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"SE s %s\n",(yyvsp[0].str).c_str());line_num++;}
#line 2228 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 112:
#line 229 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"TEXTOFF\n");line_num++;}
#line 2234 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 113:
#line 230 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"TEXTON\n");line_num++;}
#line 2240 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 114:
#line 231 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"TEXTOFF p %s\n",(yyvsp[0].str).c_str());line_num++;}
#line 2246 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 115:
#line 232 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"TEXTON p %s\n",(yyvsp[0].str).c_str());line_num++;}
#line 2252 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 116:
#line 233 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"VSP sn %s %s\n",(yyvsp[-2].str).c_str(),(yyvsp[0].str).c_str());line_num++;}
#line 2258 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 117:
#line 234 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"CSP s %s\n",(yyvsp[0].str).c_str());line_num++;}
#line 2264 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 118:
#line 235 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"CSP\n");line_num++;}
#line 2270 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 119:
#line 236 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"MSP snn %s %s %s\n",(yyvsp[-4].str).c_str(),(yyvsp[-2].str).c_str(),(yyvsp[0].str).c_str());line_num++;}
#line 2276 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 120:
#line 237 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"BGMVOL n %s\n",(yyvsp[0].str).c_str());line_num++;}
#line 2282 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 121:
#line 238 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"QUAKE nnn %s %s %s\n",(yyvsp[-4].str).c_str(),(yyvsp[-2].str).c_str(),(yyvsp[0].str).c_str());line_num++;}
#line 2288 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 122:
#line 239 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"QUAKE nnnn %s %s %s %s\n",(yyvsp[-6].str).c_str(),(yyvsp[-4].str).c_str(),(yyvsp[-2].str).c_str(),(yyvsp[0].str).c_str());line_num++;}
#line 2294 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 123:
#line 240 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"QUAKE nnnnn %s %s %s %s %s\n",(yyvsp[-8].str).c_str(),(yyvsp[-6].str).c_str(),(yyvsp[-4].str).c_str(),(yyvsp[-2].str).c_str(),(yyvsp[0].str).c_str());line_num++;}
#line 2300 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 124:
#line 241 "lex.y" /* yacc.c:1646  */
    {fprintf(script_file,"TEXTDEF ssnnnnnnnnns %s %s %s %s %s %s %s %s %s %s %s %s\n",(yyvsp[-22].str).c_str(),(yyvsp[-20].str).c_str(),(yyvsp[-18].str).c_str(),(yyvsp[-16].str).c_str(),(yyvsp[-14].str).c_str(),(yyvsp[-12].str).c_str(),(yyvsp[-10].str).c_str(),(yyvsp[-8].str).c_str(),(yyvsp[-6].str).c_str(),(yyvsp[-4].str).c_str(),(yyvsp[-2].str).c_str(),(yyvsp[0].str).c_str());line_num++;}
#line 2306 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 125:
#line 242 "lex.y" /* yacc.c:1646  */
    {fprintf(script_file,"TEXTDEF ssnnnnnnnnn %s %s %s %s %s %s %s %s %s %s %s\n",(yyvsp[-20].str).c_str(),(yyvsp[-18].str).c_str(),(yyvsp[-16].str).c_str(),(yyvsp[-14].str).c_str(),(yyvsp[-12].str).c_str(),(yyvsp[-10].str).c_str(),(yyvsp[-8].str).c_str(),(yyvsp[-6].str).c_str(),(yyvsp[-4].str).c_str(),(yyvsp[-2].str).c_str(),(yyvsp[0].str).c_str());line_num++;}
#line 2312 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 126:
#line 243 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"TEXTSPEED n %s\n",(yyvsp[0].str).c_str());line_num++;}
#line 2318 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 127:
#line 244 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"FOOTERON\n");line_num++;}
#line 2324 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 128:
#line 245 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"FOOTEROFF\n");line_num++;}
#line 2330 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 129:
#line 246 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"GOTO n %s\n",(yyvsp[0].str).c_str());line_num++;}
#line 2336 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 130:
#line 247 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"FOOTERREGIST ssnsnnn %s %s %s %s %s %s %s\n",(yyvsp[-12].str).c_str(),(yyvsp[-10].str).c_str(),(yyvsp[-8].str).c_str(),(yyvsp[-6].str).c_str(),(yyvsp[-4].str).c_str(),(yyvsp[-2].str).c_str(),(yyvsp[0].str).c_str());line_num++;}
#line 2342 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 131:
#line 248 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"DELAY n %s\n",(yyvsp[0].str).c_str());line_num++;}
#line 2348 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 132:
#line 249 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"TEXTWRITE vsnss %s %s %s %s %s\n",(yyvsp[-8].str).c_str(),(yyvsp[-6].str).c_str(),(yyvsp[-4].str).c_str(),(yyvsp[-2].str).c_str(),(yyvsp[0].str).c_str());line_num++;}
#line 2354 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 133:
#line 250 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"SAVE s %s\n",(yyvsp[0].str).c_str());line_num++;}
#line 2360 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 134:
#line 251 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"LOAD s %s\n",(yyvsp[0].str).c_str());line_num++;}
#line 2366 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 135:
#line 252 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"RELEASE\n");line_num++;}
#line 2372 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 136:
#line 253 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"PRINT n %s\n",(yyvsp[0].str).c_str());line_num++;}
#line 2378 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 137:
#line 254 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"PRINT nn %s %s\n",(yyvsp[-2].str).c_str(),(yyvsp[0].str).c_str());line_num++;}
#line 2384 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 138:
#line 255 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"END\n");line_num++;}
#line 2390 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 139:
#line 258 "lex.y" /* yacc.c:1646  */
    {(yyval.str) = (yyvsp[0].str);}
#line 2396 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 140:
#line 259 "lex.y" /* yacc.c:1646  */
    {(yyval.str) = (yyvsp[-2].str) + ' ' + (yyvsp[0].str);}
#line 2402 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 141:
#line 262 "lex.y" /* yacc.c:1646  */
    {}
#line 2408 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 142:
#line 263 "lex.y" /* yacc.c:1646  */
    {}
#line 2414 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 143:
#line 266 "lex.y" /* yacc.c:1646  */
    {jump_list["__"+(yyvsp[0].str)] = line_num;}
#line 2420 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 144:
#line 269 "lex.y" /* yacc.c:1646  */
    {now_function_name = (yyvsp[0].str);}
#line 2426 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 145:
#line 272 "lex.y" /* yacc.c:1646  */
    {}
#line 2432 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 146:
#line 273 "lex.y" /* yacc.c:1646  */
    {fprintf(script_file,"FUNCTION\n");line_num++;fprintf(script_file,"GOTO n __%s\n",now_function_name.c_str());line_num++;}
#line 2438 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 147:
#line 276 "lex.y" /* yacc.c:1646  */
    {}
#line 2444 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 148:
#line 277 "lex.y" /* yacc.c:1646  */
    {}
#line 2450 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 149:
#line 278 "lex.y" /* yacc.c:1646  */
    {}
#line 2456 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 150:
#line 279 "lex.y" /* yacc.c:1646  */
    {}
#line 2462 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 151:
#line 280 "lex.y" /* yacc.c:1646  */
    {}
#line 2468 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 152:
#line 281 "lex.y" /* yacc.c:1646  */
    {}
#line 2474 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 153:
#line 282 "lex.y" /* yacc.c:1646  */
    {fprintf(script_file,"FUNCTION\n");line_num++;fprintf(script_file,"GOTO n __%s\n",now_function_name.c_str());line_num++;}
#line 2480 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 154:
#line 283 "lex.y" /* yacc.c:1646  */
    {fprintf(script_file,"FUNCTION\n");line_num++;fprintf(script_file,"GOTO n __%s\n",now_function_name.c_str());line_num++;}
#line 2486 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 155:
#line 284 "lex.y" /* yacc.c:1646  */
    {fprintf(script_file,"FUNCTION\n");line_num++;fprintf(script_file,"GOTO n __%s\n",now_function_name.c_str());line_num++;}
#line 2492 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 156:
#line 285 "lex.y" /* yacc.c:1646  */
    {fprintf(script_file,"FUNCTION\n");line_num++;fprintf(script_file,"GOTO n __%s\n",now_function_name.c_str());line_num++;}
#line 2498 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 157:
#line 286 "lex.y" /* yacc.c:1646  */
    {fprintf(script_file,"FUNCTION\n");line_num++;fprintf(script_file,"GOTO n __%s\n",now_function_name.c_str());line_num++;}
#line 2504 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 158:
#line 287 "lex.y" /* yacc.c:1646  */
    {fprintf(script_file,"FUNCTION\n");line_num++;fprintf(script_file,"GOTO n __%s\n",now_function_name.c_str());line_num++;}
#line 2510 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 159:
#line 290 "lex.y" /* yacc.c:1646  */
    {fprintf(script_file,"PUSH v %s\n",(yyvsp[0].str).c_str());line_num++;}
#line 2516 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 160:
#line 293 "lex.y" /* yacc.c:1646  */
    {fprintf(script_file,"PUSH v %s\n",(yyvsp[0].str).c_str());line_num++;}
#line 2522 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 161:
#line 296 "lex.y" /* yacc.c:1646  */
    {fprintf(script_file,"PUSH v %s\n",(yyvsp[0].str).c_str());line_num++;}
#line 2528 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 162:
#line 299 "lex.y" /* yacc.c:1646  */
    {fprintf(script_file,"POP v %s\n",(yyvsp[-2].str).c_str());line_num++;}
#line 2534 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 163:
#line 300 "lex.y" /* yacc.c:1646  */
    {fprintf(script_file,"POP v %s\n",(yyvsp[0].str).c_str());line_num++;}
#line 2540 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 164:
#line 303 "lex.y" /* yacc.c:1646  */
    {}
#line 2546 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 165:
#line 304 "lex.y" /* yacc.c:1646  */
    {}
#line 2552 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 166:
#line 307 "lex.y" /* yacc.c:1646  */
    {}
#line 2558 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 167:
#line 310 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"RETURN\n");line_num++;}
#line 2564 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 168:
#line 313 "lex.y" /* yacc.c:1646  */
    {}
#line 2570 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 169:
#line 316 "lex.y" /* yacc.c:1646  */
    { (yyval.str) = (yyvsp[0].str); fprintf(script_file,"NOTCOMPARE vn %s __%d\n",(yyvsp[0].str).c_str(),line_num);indent_block.push(line_num); line_num++;}
#line 2576 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 170:
#line 319 "lex.y" /* yacc.c:1646  */
    {}
#line 2582 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 171:
#line 320 "lex.y" /* yacc.c:1646  */
    {}
#line 2588 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 172:
#line 323 "lex.y" /* yacc.c:1646  */
    {}
#line 2594 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 173:
#line 326 "lex.y" /* yacc.c:1646  */
    {jump_list["__" + to_string(indent_block.top())]=line_num;indent_block.pop();}
#line 2600 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 174:
#line 329 "lex.y" /* yacc.c:1646  */
    {}
#line 2606 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 175:
#line 332 "lex.y" /* yacc.c:1646  */
    { for_num++;fprintf(script_file,"NOTCOMPARE vn %s __for_break%d\n",(yyvsp[0].str).c_str(),for_num);indent_block.push(line_num); line_num++;}
#line 2612 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 176:
#line 335 "lex.y" /* yacc.c:1646  */
    {}
#line 2618 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 177:
#line 336 "lex.y" /* yacc.c:1646  */
    {}
#line 2624 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 189:
#line 352 "lex.y" /* yacc.c:1646  */
    {}
#line 2630 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 190:
#line 355 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"GOTO n %d\n",indent_block.top()-1);indent_block.pop(); line_num++;jump_list["__for_break" + to_string(for_num)]=line_num;jump_list["__for_continue" + to_string(for_num)]=line_num-1;}
#line 2636 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 191:
#line 358 "lex.y" /* yacc.c:1646  */
    {fprintf(script_file,"GOTO n __for_continue%d\n",for_num);line_num++;}
#line 2642 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 192:
#line 361 "lex.y" /* yacc.c:1646  */
    {fprintf(script_file,"GOTO n __for_break%d\n",for_num);line_num++;}
#line 2648 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 193:
#line 364 "lex.y" /* yacc.c:1646  */
    { fprintf(script_file,"MAINTEXT s %s\n",(yyvsp[0].str).c_str()); line_num++;}
#line 2654 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 194:
#line 365 "lex.y" /* yacc.c:1646  */
    {fprintf(script_file,"MAINTEXT ss %s %s\n",(yyvsp[-1].str).c_str(),(yyvsp[0].str).c_str()); line_num++;}
#line 2660 "lex.tab.c" /* yacc.c:1646  */
    break;

  case 195:
#line 368 "lex.y" /* yacc.c:1646  */
    {(yyval.str)=(yyvsp[-1].str);}
#line 2666 "lex.tab.c" /* yacc.c:1646  */
    break;


#line 2670 "lex.tab.c" /* yacc.c:1646  */
      default: break;
    }
  /* User semantic actions sometimes alter yychar, and that requires
     that yytoken be updated with the new translation.  We take the
     approach of translating immediately before every use of yytoken.
     One alternative is translating here after every semantic action,
     but that translation would be missed if the semantic action invokes
     YYABORT, YYACCEPT, or YYERROR immediately after altering yychar or
     if it invokes YYBACKUP.  In the case of YYABORT or YYACCEPT, an
     incorrect destructor might then be invoked immediately.  In the
     case of YYERROR or YYBACKUP, subsequent parser actions might lead
     to an incorrect destructor call or verbose syntax error message
     before the lookahead is translated.  */
  YY_SYMBOL_PRINT ("-> $$ =", yyr1[yyn], &yyval, &yyloc);

  YYPOPSTACK (yylen);
  yylen = 0;
  YY_STACK_PRINT (yyss, yyssp);

  *++yyvsp = yyval;

  /* Now 'shift' the result of the reduction.  Determine what state
     that goes to, based on the state we popped back to and the rule
     number reduced by.  */

  yyn = yyr1[yyn];

  yystate = yypgoto[yyn - YYNTOKENS] + *yyssp;
  if (0 <= yystate && yystate <= YYLAST && yycheck[yystate] == *yyssp)
    yystate = yytable[yystate];
  else
    yystate = yydefgoto[yyn - YYNTOKENS];

  goto yynewstate;


/*--------------------------------------.
| yyerrlab -- here on detecting error.  |
`--------------------------------------*/
yyerrlab:
  /* Make sure we have latest lookahead translation.  See comments at
     user semantic actions for why this is necessary.  */
  yytoken = yychar == YYEMPTY ? YYEMPTY : YYTRANSLATE (yychar);

  /* If not already recovering from an error, report this error.  */
  if (!yyerrstatus)
    {
      ++yynerrs;
#if ! YYERROR_VERBOSE
      yyerror (YY_("syntax error"));
#else
# define YYSYNTAX_ERROR yysyntax_error (&yymsg_alloc, &yymsg, \
                                        yyssp, yytoken)
      {
        char const *yymsgp = YY_("syntax error");
        int yysyntax_error_status;
        yysyntax_error_status = YYSYNTAX_ERROR;
        if (yysyntax_error_status == 0)
          yymsgp = yymsg;
        else if (yysyntax_error_status == 1)
          {
            if (yymsg != yymsgbuf)
              YYSTACK_FREE (yymsg);
            yymsg = (char *) YYSTACK_ALLOC (yymsg_alloc);
            if (!yymsg)
              {
                yymsg = yymsgbuf;
                yymsg_alloc = sizeof yymsgbuf;
                yysyntax_error_status = 2;
              }
            else
              {
                yysyntax_error_status = YYSYNTAX_ERROR;
                yymsgp = yymsg;
              }
          }
        yyerror (yymsgp);
        if (yysyntax_error_status == 2)
          goto yyexhaustedlab;
      }
# undef YYSYNTAX_ERROR
#endif
    }



  if (yyerrstatus == 3)
    {
      /* If just tried and failed to reuse lookahead token after an
         error, discard it.  */

      if (yychar <= YYEOF)
        {
          /* Return failure if at end of input.  */
          if (yychar == YYEOF)
            YYABORT;
        }
      else
        {
          yydestruct ("Error: discarding",
                      yytoken, &yylval);
          yychar = YYEMPTY;
        }
    }

  /* Else will try to reuse lookahead token after shifting the error
     token.  */
  goto yyerrlab1;


/*---------------------------------------------------.
| yyerrorlab -- error raised explicitly by YYERROR.  |
`---------------------------------------------------*/
yyerrorlab:

  /* Pacify compilers like GCC when the user code never invokes
     YYERROR and the label yyerrorlab therefore never appears in user
     code.  */
  if (/*CONSTCOND*/ 0)
     goto yyerrorlab;

  /* Do not reclaim the symbols of the rule whose action triggered
     this YYERROR.  */
  YYPOPSTACK (yylen);
  yylen = 0;
  YY_STACK_PRINT (yyss, yyssp);
  yystate = *yyssp;
  goto yyerrlab1;


/*-------------------------------------------------------------.
| yyerrlab1 -- common code for both syntax error and YYERROR.  |
`-------------------------------------------------------------*/
yyerrlab1:
  yyerrstatus = 3;      /* Each real token shifted decrements this.  */

  for (;;)
    {
      yyn = yypact[yystate];
      if (!yypact_value_is_default (yyn))
        {
          yyn += YYTERROR;
          if (0 <= yyn && yyn <= YYLAST && yycheck[yyn] == YYTERROR)
            {
              yyn = yytable[yyn];
              if (0 < yyn)
                break;
            }
        }

      /* Pop the current state because it cannot handle the error token.  */
      if (yyssp == yyss)
        YYABORT;


      yydestruct ("Error: popping",
                  yystos[yystate], yyvsp);
      YYPOPSTACK (1);
      yystate = *yyssp;
      YY_STACK_PRINT (yyss, yyssp);
    }

  YY_IGNORE_MAYBE_UNINITIALIZED_BEGIN
  *++yyvsp = yylval;
  YY_IGNORE_MAYBE_UNINITIALIZED_END


  /* Shift the error token.  */
  YY_SYMBOL_PRINT ("Shifting", yystos[yyn], yyvsp, yylsp);

  yystate = yyn;
  goto yynewstate;


/*-------------------------------------.
| yyacceptlab -- YYACCEPT comes here.  |
`-------------------------------------*/
yyacceptlab:
  yyresult = 0;
  goto yyreturn;

/*-----------------------------------.
| yyabortlab -- YYABORT comes here.  |
`-----------------------------------*/
yyabortlab:
  yyresult = 1;
  goto yyreturn;

#if !defined yyoverflow || YYERROR_VERBOSE
/*-------------------------------------------------.
| yyexhaustedlab -- memory exhaustion comes here.  |
`-------------------------------------------------*/
yyexhaustedlab:
  yyerror (YY_("memory exhausted"));
  yyresult = 2;
  /* Fall through.  */
#endif

yyreturn:
  if (yychar != YYEMPTY)
    {
      /* Make sure we have latest lookahead translation.  See comments at
         user semantic actions for why this is necessary.  */
      yytoken = YYTRANSLATE (yychar);
      yydestruct ("Cleanup: discarding lookahead",
                  yytoken, &yylval);
    }
  /* Do not reclaim the symbols of the rule whose action triggered
     this YYABORT or YYACCEPT.  */
  YYPOPSTACK (yylen);
  YY_STACK_PRINT (yyss, yyssp);
  while (yyssp != yyss)
    {
      yydestruct ("Cleanup: popping",
                  yystos[*yyssp], yyvsp);
      YYPOPSTACK (1);
    }
#ifndef yyoverflow
  if (yyss != yyssa)
    YYSTACK_FREE (yyss);
#endif
#if YYERROR_VERBOSE
  if (yymsg != yymsgbuf)
    YYSTACK_FREE (yymsg);
#endif
  return yyresult;
}
#line 370 "lex.y" /* yacc.c:1906  */


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
		fprintf(log,"%s\t%d\n",keys[i].c_str(),jump_list[keys[i]]);
		std::cout << keys[i] << "\t" << jump_list[keys[i]]  <<std::endl;
		data = regex_replace(data,regex(keys[i]),to_string(jump_list[keys[i]]));
	}
	for(int i=0;i<data.length();i++){
		fprintf(finalize_file,"%c",data[i]);
	}
	fclose(finalize_file);
	fclose(log);
	return 0;
}
void yyerror(const char *s){
	printf("EEK, parser error %s",s);
}
int isatty(int a){
	return 0;
}
