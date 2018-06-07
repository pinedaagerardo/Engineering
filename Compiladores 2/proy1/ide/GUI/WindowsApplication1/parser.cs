
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;
using WindowsApplication1;
using System.Windows.Forms;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF                          =   0, // (EOF)
        SYMBOL_ERROR                        =   1, // (Error)
        SYMBOL_WHITESPACE                   =   2, // (Whitespace)
        SYMBOL_COMMENTEND                   =   3, // (Comment End)
        SYMBOL_COMMENTLINE                  =   4, // (Comment Line)
        SYMBOL_COMMENTSTART                 =   5, // (Comment Start)
        SYMBOL_MINUS                        =   6, // '-'
        SYMBOL_MINUSMINUS                   =   7, // --
        SYMBOL_EXCLAMEQ                     =   8, // '!='
        SYMBOL_PERCENT                      =   9, // '%'
        SYMBOL_PERCENTEQ                    =  10, // '%='
        SYMBOL_AMPAMP                       =  11, // '&&'
        SYMBOL_LPARAN                       =  12, // '('
        SYMBOL_RPARAN                       =  13, // ')'
        SYMBOL_TIMES                        =  14, // '*'
        SYMBOL_TIMESEQ                      =  15, // '*='
        SYMBOL_COMMA                        =  16, // ','
        SYMBOL_DOT                          =  17, // '.'
        SYMBOL_DIV                          =  18, // '/'
        SYMBOL_DIVEQ                        =  19, // '/='
        SYMBOL_COLON                        =  20, // ':'
        SYMBOL_SEMI                         =  21, // ';'
        SYMBOL_QUESTION                     =  22, // '?'
        SYMBOL_LBRACKET                     =  23, // '['
        SYMBOL_RBRACKET                     =  24, // ']'
        SYMBOL_LBRACE                       =  25, // '{'
        SYMBOL_PIPEPIPE                     =  26, // '||'
        SYMBOL_RBRACE                       =  27, // '}'
        SYMBOL_PLUS                         =  28, // '+'
        SYMBOL_PLUSPLUS                     =  29, // '++'
        SYMBOL_PLUSEQ                       =  30, // '+='
        SYMBOL_LT                           =  31, // '<'
        SYMBOL_LTEQ                         =  32, // '<='
        SYMBOL_EQ                           =  33, // '='
        SYMBOL_MINUSEQ                      =  34, // '-='
        SYMBOL_EQEQ                         =  35, // '=='
        SYMBOL_GT                           =  36, // '>'
        SYMBOL_GTEQ                         =  37, // '>='
        SYMBOL_ABSTRACT                     =  38, // abstract
        SYMBOL_BOOL                         =  39, // Bool
        SYMBOL_BOOLEAN                      =  40, // boolean
        SYMBOL_BREAK                        =  41, // break
        SYMBOL_BUTTONGROUP                  =  42, // ButtonGroup
        SYMBOL_BYTE                         =  43, // byte
        SYMBOL_CASE                         =  44, // case
        SYMBOL_CATCH                        =  45, // catch
        SYMBOL_CHAR                         =  46, // char
        SYMBOL_CHARINDIRECTO                =  47, // CharIndirecto
        SYMBOL_CLASS                        =  48, // class
        SYMBOL_CONTINUE                     =  49, // continue
        SYMBOL_DEFAULT                      =  50, // default
        SYMBOL_DO                           =  51, // do
        SYMBOL_DOUBLE                       =  52, // double
        SYMBOL_ELSE                         =  53, // else
        SYMBOL_EXPRNULL                     =  54, // ExprNull
        SYMBOL_EXTENDS                      =  55, // extends
        SYMBOL_FINAL                        =  56, // final
        SYMBOL_FINALLY                      =  57, // finally
        SYMBOL_FLOAT                        =  58, // float
        SYMBOL_FOR                          =  59, // for
        SYMBOL_HEXESCAPECHAR                =  60, // HexEscapeChar
        SYMBOL_ID                           =  61, // Id
        SYMBOL_IF                           =  62, // if
        SYMBOL_IMPLEMENTS                   =  63, // implements
        SYMBOL_IMPORT                       =  64, // import
        SYMBOL_INSTANCEOF                   =  65, // instanceof
        SYMBOL_INT                          =  66, // int
        SYMBOL_INTERFACE                    =  67, // interface
        SYMBOL_JBUTTON                      =  68, // JButton
        SYMBOL_JCHECKBOX                    =  69, // JCheckBox
        SYMBOL_JCOMBOBOX                    =  70, // JComboBox
        SYMBOL_JFILECHOOSER                 =  71, // JFileChooser
        SYMBOL_JLABEL                       =  72, // JLabel
        SYMBOL_JPANEL                       =  73, // JPanel
        SYMBOL_JPASSWORDFIELD               =  74, // JPasswordField
        SYMBOL_JRADIOBUTTON                 =  75, // JRadioButton
        SYMBOL_JTABLE                       =  76, // JTable
        SYMBOL_JTEXTAREA                    =  77, // JTextArea
        SYMBOL_JTEXTFIELD                   =  78, // JTextField
        SYMBOL_JTREE                        =  79, // JTree
        SYMBOL_LONG                         =  80, // long
        SYMBOL_NATIVE                       =  81, // native
        SYMBOL_NEW                          =  82, // new
        SYMBOL_NUM                          =  83, // Num
        SYMBOL_NUMCERO                      =  84, // NumCero
        SYMBOL_NUMFLOAT                     =  85, // NumFloat
        SYMBOL_NUMFLOATEXP                  =  86, // NumFloatExp
        SYMBOL_NUMHEX                       =  87, // NumHex
        SYMBOL_NUMOCTAL                     =  88, // NumOctal
        SYMBOL_OCTALESCAPECHAR              =  89, // OctalEscapeChar
        SYMBOL_PACKAGE                      =  90, // package
        SYMBOL_PRIVATE                      =  91, // private
        SYMBOL_PROTECTED                    =  92, // protected
        SYMBOL_PUBLIC                       =  93, // public
        SYMBOL_RETURN                       =  94, // return
        SYMBOL_SHORT                        =  95, // short
        SYMBOL_STATIC                       =  96, // static
        SYMBOL_STESCAPECHAR                 =  97, // StEscapeChar
        SYMBOL_STRING                       =  98, // String
        SYMBOL_SUPER                        =  99, // super
        SYMBOL_SWITCH                       = 100, // switch
        SYMBOL_SYNCHRONIZED                 = 101, // synchronized
        SYMBOL_THIS                         = 102, // this
        SYMBOL_THROW                        = 103, // throw
        SYMBOL_THROWS                       = 104, // throws
        SYMBOL_TRANSIENT                    = 105, // transient
        SYMBOL_TRY                          = 106, // try
        SYMBOL_VOID                         = 107, // void
        SYMBOL_VOLATILE                     = 108, // volatile
        SYMBOL_WHILE                        = 109, // while
        SYMBOL_ACCESOARRAY                  = 110, // <AccesoArray>
        SYMBOL_ACCESOCAMPO                  = 111, // <AccesoCampo>
        SYMBOL_ADDEXPRESION                 = 112, // <AddExpresion>
        SYMBOL_ANDCONDICIONALEXPRESION      = 113, // <AndCondicionalExpresion>
        SYMBOL_ARRAYINI                     = 114, // <ArrayIni>
        SYMBOL_BLOCK                        = 115, // <Block>
        SYMBOL_BLOCKSENTENCIA               = 116, // <BlockSentencia>
        SYMBOL_BLOCKSENTENCIAS              = 117, // <BlockSentencias>
        SYMBOL_BREAKSENTENCIA               = 118, // <BreakSentencia>
        SYMBOL_CABECERAMETODO               = 119, // <CabeceraMetodo>
        SYMBOL_CARACTER                     = 120, // <Caracter>
        SYMBOL_CASTEXPRESION                = 121, // <CastExpresion>
        SYMBOL_CATCHES                      = 122, // <Catches>
        SYMBOL_CONSTRUCTORDECLARATOR        = 123, // <ConstructorDeclarator>
        SYMBOL_CONTINUESENTENCIA            = 124, // <ContinueSentencia>
        SYMBOL_CORCHETES                    = 125, // <Corchetes>
        SYMBOL_CREACIONARRAY                = 126, // <CreacionArray>
        SYMBOL_CREACIONINSTANCIA            = 127, // <CreacionInstancia>
        SYMBOL_CUERPOCLASE                  = 128, // <CuerpoClase>
        SYMBOL_CUERPOCONSTRUCTOR            = 129, // <CuerpoConstructor>
        SYMBOL_CUERPOINTERFAZ               = 130, // <CuerpoInterfaz>
        SYMBOL_CUERPOMETODO                 = 131, // <CuerpoMetodo>
        SYMBOL_DECLARACIONCAMPO             = 132, // <DeclaracionCampo>
        SYMBOL_DECLARACIONCLASE             = 133, // <DeclaracionClase>
        SYMBOL_DECLARACIONCONSTRUCTOR       = 134, // <DeclaracionConstructor>
        SYMBOL_DECLARACIONCUERPOCLASE       = 135, // <DeclaracionCuerpoClase>
        SYMBOL_DECLARACIONESCUERPOCLASE     = 136, // <DeclaracionesCuerpoClase>
        SYMBOL_DECLARACIONESIMPORT          = 137, // <DeclaracionesImport>
        SYMBOL_DECLARACIONESMIEMBROINTERFAZ = 138, // <DeclaracionesMiembroInterfaz>
        SYMBOL_DECLARACIONESTIPO            = 139, // <DeclaracionesTipo>
        SYMBOL_DECLARACIONIMPORT            = 140, // <DeclaracionImport>
        SYMBOL_DECLARACIONINTERFAZ          = 141, // <DeclaracionInterfaz>
        SYMBOL_DECLARACIONMETODOABSTRACTO   = 142, // <DeclaracionMetodoAbstracto>
        SYMBOL_DECLARACIONMIEMBROCLASE      = 143, // <DeclaracionMiembroClase>
        SYMBOL_DECLARACIONMIEMBROINTERFAZ   = 144, // <DeclaracionMiembroInterfaz>
        SYMBOL_DECLARACIONTIPO              = 145, // <DeclaracionTipo>
        SYMBOL_DECLARADORESVARIABLE         = 146, // <DeclaradoresVariable>
        SYMBOL_DECLARADORMETODO             = 147, // <DeclaradorMetodo>
        SYMBOL_DECLARADORVARIABLE           = 148, // <DeclaradorVariable>
        SYMBOL_DECLARADORVARIABLEID         = 149, // <DeclaradorVariableId>
        SYMBOL_EXPRCORCHETES                = 150, // <ExprCorchetes>
        SYMBOL_EXPRESIONASIGNA              = 151, // <ExpresionAsigna>
        SYMBOL_EXPRESIONCOMPARAR            = 152, // <ExpresionComparar>
        SYMBOL_EXPRESIONCONDICIONAL         = 153, // <ExpresionCondicional>
        SYMBOL_EXPRESIONIGUAL               = 154, // <ExpresionIgual>
        SYMBOL_EXPRSCORCHETES               = 155, // <ExprsCorchetes>
        SYMBOL_EXTENDSINTERFACES            = 156, // <ExtendsInterfaces>
        SYMBOL_FLOAT2                       = 157, // <float>
        SYMBOL_FORACTUALIZAR                = 158, // <ForActualizar>
        SYMBOL_FORSENTENCIA                 = 159, // <ForSentencia>
        SYMBOL_FORSENTENCIAIFEXTENDIDO      = 160, // <ForSentenciaIfExtendido>
        SYMBOL_GRUPOSSWITCH                 = 161, // <GruposSwitch>
        SYMBOL_INICIALIZARFOR               = 162, // <InicializarFor>
        SYMBOL_INT2                         = 163, // <Int>
        SYMBOL_INVOCACIONMETODO             = 164, // <InvocacionMetodo>
        SYMBOL_INVOEXPLICITACONSTRUCTOR     = 165, // <InvoExplicitaConstructor>
        SYMBOL_LEFTSIDE                     = 166, // <LeftSide>
        SYMBOL_LISTAARGUMENTO               = 167, // <ListaArgumento>
        SYMBOL_LISTADOSENTENCIAEXPRESION    = 168, // <ListadoSentenciaExpresion>
        SYMBOL_LISTAINTERFACES              = 169, // <ListaInterfaces>
        SYMBOL_LISTATIPOCLASE               = 170, // <ListaTipoClase>
        SYMBOL_LITERAL                      = 171, // <Literal>
        SYMBOL_MODIFICADOR                  = 172, // <Modificador>
        SYMBOL_MULTEXPRESION                = 173, // <MultExpresion>
        SYMBOL_NOMBRE                       = 174, // <Nombre>
        SYMBOL_NOMBRECLASIFICADO            = 175, // <NombreClasificado>
        SYMBOL_NOMBRESIMPLE                 = 176, // <NombreSimple>
        SYMBOL_NUMDECIMAL                   = 177, // <numdecimal>
        SYMBOL_OPERADORASIGNACION           = 178, // <OperadorAsignacion>
        SYMBOL_ORCONDICIONALEXPRESION       = 179, // <OrCondicionalExpresion>
        SYMBOL_PARAMLIST                    = 180, // <ParamList>
        SYMBOL_POSFIJOEXPRESION             = 181, // <PosfijoExpresion>
        SYMBOL_PRIMARY                      = 182, // <Primary>
        SYMBOL_PRIMARYNONEWARRAY            = 183, // <PrimaryNoNewArray>
        SYMBOL_PROGRAM                      = 184, // <Program>
        SYMBOL_RETURNSENTENCIA              = 185, // <ReturnSentencia>
        SYMBOL_SENTENCIA                    = 186, // <Sentencia>
        SYMBOL_SENTENCIAEXPRESION           = 187, // <SentenciaExpresion>
        SYMBOL_SENTENCIAIFEXTENDIDO         = 188, // <SentenciaIfExtendido>
        SYMBOL_SENTENCIASINSUBSENTENCIA     = 189, // <SentenciaSinSubsentencia>
        SYMBOL_SWITCHBLOCK                  = 190, // <SwitchBlock>
        SYMBOL_SWITCHLABEL                  = 191, // <SwitchLabel>
        SYMBOL_SWITCHLABELS                 = 192, // <SwitchLabels>
        SYMBOL_THROWS2                      = 193, // <Throws>
        SYMBOL_TIPO                         = 194, // <Tipo>
        SYMBOL_TIPOARRAY                    = 195, // <TipoArray>
        SYMBOL_TIPOFLOTANTE                 = 196, // <TipoFlotante>
        SYMBOL_TIPOINT                      = 197, // <TipoInt>
        SYMBOL_TIPONUMERICO                 = 198, // <TipoNumerico>
        SYMBOL_TIPOPRIMITIVO                = 199, // <TipoPrimitivo>
        SYMBOL_TIPOREFERENCIA               = 200, // <TipoReferencia>
        SYMBOL_TIPOSJAVA                    = 201, // <TiposJava>
        SYMBOL_TRYSENTENCIA                 = 202, // <TrySentencia>
        SYMBOL_UNARIOEXPRESION              = 203, // <UnarioExpresion>
        SYMBOL_UNARIOEXPRESIONOTRA          = 204, // <UnarioExpresionOtra>
        SYMBOL_VARIABLEINI                  = 205, // <VariableIni>
        SYMBOL_VARIABLEINIS                 = 206  // <VariableInis>
    };

    enum RuleConstants : int
    {
        RULE_PROGRAM_PACKAGE_SEMI                                 =   0, // <Program> ::= package <Nombre> ';' <DeclaracionesImport> <DeclaracionesTipo>
        RULE_PROGRAM_PACKAGE_SEMI2                                =   1, // <Program> ::= package <Nombre> ';' <DeclaracionesImport>
        RULE_PROGRAM_PACKAGE_SEMI3                                =   2, // <Program> ::= package <Nombre> ';' <DeclaracionesTipo>
        RULE_PROGRAM_PACKAGE_SEMI4                                =   3, // <Program> ::= package <Nombre> ';'
        RULE_PROGRAM                                              =   4, // <Program> ::= <DeclaracionesImport> <DeclaracionesTipo>
        RULE_PROGRAM2                                             =   5, // <Program> ::= <DeclaracionesImport>
        RULE_PROGRAM3                                             =   6, // <Program> ::= <DeclaracionesTipo>
        RULE_PROGRAM4                                             =   7, // <Program> ::= 
        RULE_DECLARACIONESIMPORT                                  =   8, // <DeclaracionesImport> ::= <DeclaracionImport>
        RULE_DECLARACIONESIMPORT2                                 =   9, // <DeclaracionesImport> ::= <DeclaracionesImport> <DeclaracionImport>
        RULE_DECLARACIONESTIPO                                    =  10, // <DeclaracionesTipo> ::= <DeclaracionTipo>
        RULE_DECLARACIONESTIPO2                                   =  11, // <DeclaracionesTipo> ::= <DeclaracionesTipo> <DeclaracionTipo>
        RULE_DECLARACIONIMPORT_IMPORT_SEMI                        =  12, // <DeclaracionImport> ::= import <Nombre> ';'
        RULE_DECLARACIONIMPORT_IMPORT_DOT_TIMES_SEMI              =  13, // <DeclaracionImport> ::= import <Nombre> '.' '*' ';'
        RULE_DECLARACIONTIPO                                      =  14, // <DeclaracionTipo> ::= <DeclaracionClase>
        RULE_DECLARACIONTIPO2                                     =  15, // <DeclaracionTipo> ::= <DeclaracionInterfaz>
        RULE_MODIFICADOR_PUBLIC                                   =  16, // <Modificador> ::= public
        RULE_MODIFICADOR_PROTECTED                                =  17, // <Modificador> ::= protected
        RULE_MODIFICADOR_PRIVATE                                  =  18, // <Modificador> ::= private
        RULE_MODIFICADOR_STATIC                                   =  19, // <Modificador> ::= static
        RULE_MODIFICADOR_ABSTRACT                                 =  20, // <Modificador> ::= abstract
        RULE_MODIFICADOR_FINAL                                    =  21, // <Modificador> ::= final
        RULE_MODIFICADOR_NATIVE                                   =  22, // <Modificador> ::= native
        RULE_MODIFICADOR_SYNCHRONIZED                             =  23, // <Modificador> ::= synchronized
        RULE_MODIFICADOR_TRANSIENT                                =  24, // <Modificador> ::= transient
        RULE_MODIFICADOR_VOLATILE                                 =  25, // <Modificador> ::= volatile
        RULE_DECLARACIONCLASE_CLASS_ID_EXTENDS_IMPLEMENTS         =  26, // <DeclaracionClase> ::= <Modificador> class Id extends <Nombre> implements <ListaInterfaces> <CuerpoClase>
        RULE_DECLARACIONCLASE_CLASS_ID_EXTENDS                    =  27, // <DeclaracionClase> ::= <Modificador> class Id extends <Nombre> <CuerpoClase>
        RULE_DECLARACIONCLASE_CLASS_ID_IMPLEMENTS                 =  28, // <DeclaracionClase> ::= <Modificador> class Id implements <ListaInterfaces> <CuerpoClase>
        RULE_DECLARACIONCLASE_CLASS_ID                            =  29, // <DeclaracionClase> ::= <Modificador> class Id <CuerpoClase>
        RULE_DECLARACIONCLASE_CLASS_ID_EXTENDS_IMPLEMENTS2        =  30, // <DeclaracionClase> ::= class Id extends <Nombre> implements <ListaInterfaces> <CuerpoClase>
        RULE_DECLARACIONCLASE_CLASS_ID_EXTENDS2                   =  31, // <DeclaracionClase> ::= class Id extends <Nombre> <CuerpoClase>
        RULE_DECLARACIONCLASE_CLASS_ID_IMPLEMENTS2                =  32, // <DeclaracionClase> ::= class Id implements <ListaInterfaces> <CuerpoClase>
        RULE_DECLARACIONCLASE_CLASS_ID2                           =  33, // <DeclaracionClase> ::= class Id <CuerpoClase>
        RULE_LISTAINTERFACES                                      =  34, // <ListaInterfaces> ::= <Nombre>
        RULE_LISTAINTERFACES_COMMA                                =  35, // <ListaInterfaces> ::= <ListaInterfaces> ',' <Nombre>
        RULE_CUERPOCLASE_LBRACE_RBRACE                            =  36, // <CuerpoClase> ::= '{' <DeclaracionesCuerpoClase> '}'
        RULE_CUERPOCLASE_LBRACE_RBRACE2                           =  37, // <CuerpoClase> ::= '{' '}'
        RULE_DECLARACIONESCUERPOCLASE                             =  38, // <DeclaracionesCuerpoClase> ::= <DeclaracionCuerpoClase>
        RULE_DECLARACIONESCUERPOCLASE2                            =  39, // <DeclaracionesCuerpoClase> ::= <DeclaracionesCuerpoClase> <DeclaracionCuerpoClase>
        RULE_DECLARACIONCUERPOCLASE                               =  40, // <DeclaracionCuerpoClase> ::= <DeclaracionMiembroClase>
        RULE_DECLARACIONCUERPOCLASE_STATIC                        =  41, // <DeclaracionCuerpoClase> ::= static <Block>
        RULE_DECLARACIONCUERPOCLASE2                              =  42, // <DeclaracionCuerpoClase> ::= <DeclaracionConstructor>
        RULE_DECLARACIONMIEMBROCLASE                              =  43, // <DeclaracionMiembroClase> ::= <DeclaracionCampo>
        RULE_DECLARACIONMIEMBROCLASE2                             =  44, // <DeclaracionMiembroClase> ::= <CabeceraMetodo> <CuerpoMetodo>
        RULE_DECLARACIONCAMPO_SEMI                                =  45, // <DeclaracionCampo> ::= <Modificador> <Tipo> <DeclaradoresVariable> ';'
        RULE_DECLARACIONCAMPO_SEMI2                               =  46, // <DeclaracionCampo> ::= <Tipo> <DeclaradoresVariable> ';'
        RULE_DECLARADORESVARIABLE                                 =  47, // <DeclaradoresVariable> ::= <DeclaradorVariable>
        RULE_DECLARADORESVARIABLE_COMMA                           =  48, // <DeclaradoresVariable> ::= <DeclaradoresVariable> ',' <DeclaradorVariable>
        RULE_DECLARADORVARIABLE                                   =  49, // <DeclaradorVariable> ::= <DeclaradorVariableId>
        RULE_DECLARADORVARIABLE_EQ                                =  50, // <DeclaradorVariable> ::= <DeclaradorVariableId> '=' <VariableIni>
        RULE_DECLARADORVARIABLEID_ID                              =  51, // <DeclaradorVariableId> ::= Id
        RULE_DECLARADORVARIABLEID_LBRACKET_RBRACKET               =  52, // <DeclaradorVariableId> ::= <DeclaradorVariableId> '[' ']'
        RULE_VARIABLEINI                                          =  53, // <VariableIni> ::= <ExpresionAsigna>
        RULE_VARIABLEINI2                                         =  54, // <VariableIni> ::= <ArrayIni>
        RULE_CABECERAMETODO                                       =  55, // <CabeceraMetodo> ::= <Modificador> <Tipo> <DeclaradorMetodo> <Throws>
        RULE_CABECERAMETODO2                                      =  56, // <CabeceraMetodo> ::= <Modificador> <Tipo> <DeclaradorMetodo>
        RULE_CABECERAMETODO3                                      =  57, // <CabeceraMetodo> ::= <Tipo> <DeclaradorMetodo> <Throws>
        RULE_CABECERAMETODO4                                      =  58, // <CabeceraMetodo> ::= <Tipo> <DeclaradorMetodo>
        RULE_CABECERAMETODO_VOID                                  =  59, // <CabeceraMetodo> ::= <Modificador> void <DeclaradorMetodo> <Throws>
        RULE_CABECERAMETODO_VOID2                                 =  60, // <CabeceraMetodo> ::= <Modificador> void <DeclaradorMetodo>
        RULE_CABECERAMETODO_VOID3                                 =  61, // <CabeceraMetodo> ::= void <DeclaradorMetodo> <Throws>
        RULE_CABECERAMETODO_VOID4                                 =  62, // <CabeceraMetodo> ::= void <DeclaradorMetodo>
        RULE_DECLARADORMETODO_ID_LPARAN_RPARAN                    =  63, // <DeclaradorMetodo> ::= Id '(' <ParamList> ')'
        RULE_DECLARADORMETODO_ID_LPARAN_RPARAN2                   =  64, // <DeclaradorMetodo> ::= Id '(' ')'
        RULE_DECLARADORMETODO_LBRACKET_RBRACKET                   =  65, // <DeclaradorMetodo> ::= <DeclaradorMetodo> '[' ']'
        RULE_PARAMLIST                                            =  66, // <ParamList> ::= <Tipo> <DeclaradorVariableId>
        RULE_PARAMLIST_COMMA                                      =  67, // <ParamList> ::= <ParamList> ',' <Tipo> <DeclaradorVariableId>
        RULE_CARACTER_CHARINDIRECTO                               =  68, // <Caracter> ::= CharIndirecto
        RULE_CARACTER_STESCAPECHAR                                =  69, // <Caracter> ::= StEscapeChar
        RULE_CARACTER_OCTALESCAPECHAR                             =  70, // <Caracter> ::= OctalEscapeChar
        RULE_CARACTER_HEXESCAPECHAR                               =  71, // <Caracter> ::= HexEscapeChar
        RULE_NUMDECIMAL_NUMCERO                                   =  72, // <numdecimal> ::= NumCero
        RULE_NUMDECIMAL_NUM                                       =  73, // <numdecimal> ::= Num
        RULE_FLOAT_NUMFLOAT                                       =  74, // <float> ::= NumFloat
        RULE_FLOAT_NUMFLOATEXP                                    =  75, // <float> ::= NumFloatExp
        RULE_INT                                                  =  76, // <Int> ::= <numdecimal>
        RULE_INT_NUMHEX                                           =  77, // <Int> ::= NumHex
        RULE_INT_NUMOCTAL                                         =  78, // <Int> ::= NumOctal
        RULE_LITERAL                                              =  79, // <Literal> ::= <Int>
        RULE_LITERAL2                                             =  80, // <Literal> ::= <float>
        RULE_LITERAL_BOOL                                         =  81, // <Literal> ::= Bool
        RULE_LITERAL3                                             =  82, // <Literal> ::= <Caracter>
        RULE_LITERAL_STRING                                       =  83, // <Literal> ::= String
        RULE_LITERAL_EXPRNULL                                     =  84, // <Literal> ::= ExprNull
        RULE_TIPO                                                 =  85, // <Tipo> ::= <TipoPrimitivo>
        RULE_TIPO2                                                =  86, // <Tipo> ::= <TipoReferencia>
        RULE_TIPO3                                                =  87, // <Tipo> ::= <TiposJava>
        RULE_TIPOSJAVA_JLABEL                                     =  88, // <TiposJava> ::= JLabel
        RULE_TIPOSJAVA_JBUTTON                                    =  89, // <TiposJava> ::= JButton
        RULE_TIPOSJAVA_JCHECKBOX                                  =  90, // <TiposJava> ::= JCheckBox
        RULE_TIPOSJAVA_JRADIOBUTTON                               =  91, // <TiposJava> ::= JRadioButton
        RULE_TIPOSJAVA_BUTTONGROUP                                =  92, // <TiposJava> ::= ButtonGroup
        RULE_TIPOSJAVA_JCOMBOBOX                                  =  93, // <TiposJava> ::= JComboBox
        RULE_TIPOSJAVA_JTEXTFIELD                                 =  94, // <TiposJava> ::= JTextField
        RULE_TIPOSJAVA_JTEXTAREA                                  =  95, // <TiposJava> ::= JTextArea
        RULE_TIPOSJAVA_JPASSWORDFIELD                             =  96, // <TiposJava> ::= JPasswordField
        RULE_TIPOSJAVA_JTREE                                      =  97, // <TiposJava> ::= JTree
        RULE_TIPOSJAVA_JTABLE                                     =  98, // <TiposJava> ::= JTable
        RULE_TIPOSJAVA_JPANEL                                     =  99, // <TiposJava> ::= JPanel
        RULE_TIPOSJAVA_JFILECHOOSER                               = 100, // <TiposJava> ::= JFileChooser
        RULE_TIPOPRIMITIVO                                        = 101, // <TipoPrimitivo> ::= <TipoNumerico>
        RULE_TIPOPRIMITIVO_BOOLEAN                                = 102, // <TipoPrimitivo> ::= boolean
        RULE_TIPONUMERICO                                         = 103, // <TipoNumerico> ::= <TipoInt>
        RULE_TIPONUMERICO2                                        = 104, // <TipoNumerico> ::= <TipoFlotante>
        RULE_TIPOINT_BYTE                                         = 105, // <TipoInt> ::= byte
        RULE_TIPOINT_SHORT                                        = 106, // <TipoInt> ::= short
        RULE_TIPOINT_INT                                          = 107, // <TipoInt> ::= int
        RULE_TIPOINT_LONG                                         = 108, // <TipoInt> ::= long
        RULE_TIPOINT_CHAR                                         = 109, // <TipoInt> ::= char
        RULE_TIPOFLOTANTE_FLOAT                                   = 110, // <TipoFlotante> ::= float
        RULE_TIPOFLOTANTE_DOUBLE                                  = 111, // <TipoFlotante> ::= double
        RULE_TIPOREFERENCIA                                       = 112, // <TipoReferencia> ::= <Nombre>
        RULE_TIPOREFERENCIA2                                      = 113, // <TipoReferencia> ::= <TipoArray>
        RULE_TIPOARRAY_LBRACKET_RBRACKET                          = 114, // <TipoArray> ::= <TipoPrimitivo> '[' ']'
        RULE_TIPOARRAY_LBRACKET_RBRACKET2                         = 115, // <TipoArray> ::= <Nombre> '[' ']'
        RULE_TIPOARRAY_LBRACKET_RBRACKET3                         = 116, // <TipoArray> ::= <TipoArray> '[' ']'
        RULE_NOMBRE                                               = 117, // <Nombre> ::= <NombreSimple>
        RULE_NOMBRE2                                              = 118, // <Nombre> ::= <NombreClasificado>
        RULE_NOMBRESIMPLE_ID                                      = 119, // <NombreSimple> ::= Id
        RULE_NOMBRECLASIFICADO_DOT_ID                             = 120, // <NombreClasificado> ::= <Nombre> '.' Id
        RULE_THROWS_THROWS                                        = 121, // <Throws> ::= throws <ListaTipoClase>
        RULE_LISTATIPOCLASE                                       = 122, // <ListaTipoClase> ::= <Nombre>
        RULE_LISTATIPOCLASE_COMMA                                 = 123, // <ListaTipoClase> ::= <ListaTipoClase> ',' <Nombre>
        RULE_CUERPOMETODO                                         = 124, // <CuerpoMetodo> ::= <Block>
        RULE_CUERPOMETODO_SEMI                                    = 125, // <CuerpoMetodo> ::= ';'
        RULE_DECLARACIONCONSTRUCTOR                               = 126, // <DeclaracionConstructor> ::= <Modificador> <ConstructorDeclarator> <Throws> <CuerpoConstructor>
        RULE_DECLARACIONCONSTRUCTOR2                              = 127, // <DeclaracionConstructor> ::= <Modificador> <ConstructorDeclarator> <CuerpoConstructor>
        RULE_DECLARACIONCONSTRUCTOR3                              = 128, // <DeclaracionConstructor> ::= <ConstructorDeclarator> <Throws> <CuerpoConstructor>
        RULE_DECLARACIONCONSTRUCTOR4                              = 129, // <DeclaracionConstructor> ::= <ConstructorDeclarator> <CuerpoConstructor>
        RULE_CONSTRUCTORDECLARATOR_LPARAN_RPARAN                  = 130, // <ConstructorDeclarator> ::= <NombreSimple> '(' <ParamList> ')'
        RULE_CONSTRUCTORDECLARATOR_LPARAN_RPARAN2                 = 131, // <ConstructorDeclarator> ::= <NombreSimple> '(' ')'
        RULE_CUERPOCONSTRUCTOR_LBRACE_RBRACE                      = 132, // <CuerpoConstructor> ::= '{' <InvoExplicitaConstructor> <BlockSentencias> '}'
        RULE_CUERPOCONSTRUCTOR_LBRACE_RBRACE2                     = 133, // <CuerpoConstructor> ::= '{' <InvoExplicitaConstructor> '}'
        RULE_CUERPOCONSTRUCTOR_LBRACE_RBRACE3                     = 134, // <CuerpoConstructor> ::= '{' <BlockSentencias> '}'
        RULE_CUERPOCONSTRUCTOR_LBRACE_RBRACE4                     = 135, // <CuerpoConstructor> ::= '{' '}'
        RULE_INVOEXPLICITACONSTRUCTOR_THIS_LPARAN_RPARAN_SEMI     = 136, // <InvoExplicitaConstructor> ::= this '(' <ListaArgumento> ')' ';'
        RULE_INVOEXPLICITACONSTRUCTOR_THIS_LPARAN_RPARAN_SEMI2    = 137, // <InvoExplicitaConstructor> ::= this '(' ')' ';'
        RULE_INVOEXPLICITACONSTRUCTOR_SUPER_LPARAN_RPARAN_SEMI    = 138, // <InvoExplicitaConstructor> ::= super '(' <ListaArgumento> ')' ';'
        RULE_INVOEXPLICITACONSTRUCTOR_SUPER_LPARAN_RPARAN_SEMI2   = 139, // <InvoExplicitaConstructor> ::= super '(' ')' ';'
        RULE_DECLARACIONINTERFAZ_INTERFACE_ID                     = 140, // <DeclaracionInterfaz> ::= <Modificador> interface Id <ExtendsInterfaces> <CuerpoInterfaz>
        RULE_DECLARACIONINTERFAZ_INTERFACE_ID2                    = 141, // <DeclaracionInterfaz> ::= <Modificador> interface Id <CuerpoInterfaz>
        RULE_DECLARACIONINTERFAZ_INTERFACE_ID3                    = 142, // <DeclaracionInterfaz> ::= interface Id <ExtendsInterfaces> <CuerpoInterfaz>
        RULE_DECLARACIONINTERFAZ_INTERFACE_ID4                    = 143, // <DeclaracionInterfaz> ::= interface Id <CuerpoInterfaz>
        RULE_EXTENDSINTERFACES_EXTENDS                            = 144, // <ExtendsInterfaces> ::= extends <Nombre>
        RULE_EXTENDSINTERFACES_COMMA                              = 145, // <ExtendsInterfaces> ::= <ExtendsInterfaces> ',' <Nombre>
        RULE_CUERPOINTERFAZ_LBRACE_RBRACE                         = 146, // <CuerpoInterfaz> ::= '{' <DeclaracionesMiembroInterfaz> '}'
        RULE_CUERPOINTERFAZ_LBRACE_RBRACE2                        = 147, // <CuerpoInterfaz> ::= '{' '}'
        RULE_DECLARACIONESMIEMBROINTERFAZ                         = 148, // <DeclaracionesMiembroInterfaz> ::= <DeclaracionMiembroInterfaz>
        RULE_DECLARACIONESMIEMBROINTERFAZ2                        = 149, // <DeclaracionesMiembroInterfaz> ::= <DeclaracionesMiembroInterfaz> <DeclaracionMiembroInterfaz>
        RULE_DECLARACIONMIEMBROINTERFAZ                           = 150, // <DeclaracionMiembroInterfaz> ::= <DeclaracionCampo>
        RULE_DECLARACIONMIEMBROINTERFAZ2                          = 151, // <DeclaracionMiembroInterfaz> ::= <DeclaracionMetodoAbstracto>
        RULE_DECLARACIONMETODOABSTRACTO_SEMI                      = 152, // <DeclaracionMetodoAbstracto> ::= <CabeceraMetodo> ';'
        RULE_ARRAYINI_LBRACE_COMMA_RBRACE                         = 153, // <ArrayIni> ::= '{' <VariableInis> ',' '}'
        RULE_ARRAYINI_LBRACE_RBRACE                               = 154, // <ArrayIni> ::= '{' <VariableInis> '}'
        RULE_ARRAYINI_LBRACE_COMMA_RBRACE2                        = 155, // <ArrayIni> ::= '{' ',' '}'
        RULE_ARRAYINI_LBRACE_RBRACE2                              = 156, // <ArrayIni> ::= '{' '}'
        RULE_VARIABLEINIS                                         = 157, // <VariableInis> ::= <VariableIni>
        RULE_VARIABLEINIS_COMMA                                   = 158, // <VariableInis> ::= <VariableInis> ',' <VariableIni>
        RULE_BLOCK_LBRACE_RBRACE                                  = 159, // <Block> ::= '{' <BlockSentencias> '}'
        RULE_BLOCK_LBRACE_RBRACE2                                 = 160, // <Block> ::= '{' '}'
        RULE_BLOCKSENTENCIAS                                      = 161, // <BlockSentencias> ::= <BlockSentencia>
        RULE_BLOCKSENTENCIAS2                                     = 162, // <BlockSentencias> ::= <BlockSentencias> <BlockSentencia>
        RULE_BLOCKSENTENCIA_SEMI                                  = 163, // <BlockSentencia> ::= <Tipo> <DeclaradoresVariable> ';'
        RULE_BLOCKSENTENCIA                                       = 164, // <BlockSentencia> ::= <Sentencia>
        RULE_SENTENCIA                                            = 165, // <Sentencia> ::= <SentenciaSinSubsentencia>
        RULE_SENTENCIA_ID_COLON                                   = 166, // <Sentencia> ::= Id ':' <Sentencia>
        RULE_SENTENCIA_IF_LPARAN_RPARAN                           = 167, // <Sentencia> ::= if '(' <ExpresionAsigna> ')' <Sentencia>
        RULE_SENTENCIA_IF_LPARAN_RPARAN_ELSE                      = 168, // <Sentencia> ::= if '(' <ExpresionAsigna> ')' <SentenciaIfExtendido> else <Sentencia>
        RULE_SENTENCIA_WHILE_LPARAN_RPARAN                        = 169, // <Sentencia> ::= while '(' <ExpresionAsigna> ')' <Sentencia>
        RULE_SENTENCIA2                                           = 170, // <Sentencia> ::= <ForSentencia>
        RULE_SENTENCIAIFEXTENDIDO                                 = 171, // <SentenciaIfExtendido> ::= <SentenciaSinSubsentencia>
        RULE_SENTENCIAIFEXTENDIDO_ID_COLON                        = 172, // <SentenciaIfExtendido> ::= Id ':' <SentenciaIfExtendido>
        RULE_SENTENCIAIFEXTENDIDO_IF_LPARAN_RPARAN_ELSE           = 173, // <SentenciaIfExtendido> ::= if '(' <ExpresionAsigna> ')' <SentenciaIfExtendido> else <SentenciaIfExtendido>
        RULE_SENTENCIAIFEXTENDIDO_WHILE_LPARAN_RPARAN             = 174, // <SentenciaIfExtendido> ::= while '(' <ExpresionAsigna> ')' <SentenciaIfExtendido>
        RULE_SENTENCIAIFEXTENDIDO2                                = 175, // <SentenciaIfExtendido> ::= <ForSentenciaIfExtendido>
        RULE_SENTENCIASINSUBSENTENCIA                             = 176, // <SentenciaSinSubsentencia> ::= <Block>
        RULE_SENTENCIASINSUBSENTENCIA_SEMI                        = 177, // <SentenciaSinSubsentencia> ::= ';'
        RULE_SENTENCIASINSUBSENTENCIA_SEMI2                       = 178, // <SentenciaSinSubsentencia> ::= <SentenciaExpresion> ';'
        RULE_SENTENCIASINSUBSENTENCIA_SWITCH_LPARAN_RPARAN        = 179, // <SentenciaSinSubsentencia> ::= switch '(' <ExpresionAsigna> ')' <SwitchBlock>
        RULE_SENTENCIASINSUBSENTENCIA_DO_WHILE_LPARAN_RPARAN_SEMI = 180, // <SentenciaSinSubsentencia> ::= do <Sentencia> while '(' <ExpresionAsigna> ')' ';'
        RULE_SENTENCIASINSUBSENTENCIA2                            = 181, // <SentenciaSinSubsentencia> ::= <BreakSentencia>
        RULE_SENTENCIASINSUBSENTENCIA3                            = 182, // <SentenciaSinSubsentencia> ::= <ContinueSentencia>
        RULE_SENTENCIASINSUBSENTENCIA4                            = 183, // <SentenciaSinSubsentencia> ::= <ReturnSentencia>
        RULE_SENTENCIASINSUBSENTENCIA_SYNCHRONIZED_LPARAN_RPARAN  = 184, // <SentenciaSinSubsentencia> ::= synchronized '(' <ExpresionAsigna> ')' <Block>
        RULE_SENTENCIASINSUBSENTENCIA_THROW_SEMI                  = 185, // <SentenciaSinSubsentencia> ::= throw <ExpresionAsigna> ';'
        RULE_SENTENCIASINSUBSENTENCIA5                            = 186, // <SentenciaSinSubsentencia> ::= <TrySentencia>
        RULE_SENTENCIAEXPRESION                                   = 187, // <SentenciaExpresion> ::= <LeftSide> <OperadorAsignacion> <ExpresionAsigna>
        RULE_SENTENCIAEXPRESION_PLUSPLUS                          = 188, // <SentenciaExpresion> ::= '++' <UnarioExpresion>
        RULE_SENTENCIAEXPRESION_MINUSMINUS                        = 189, // <SentenciaExpresion> ::= -- <UnarioExpresion>
        RULE_SENTENCIAEXPRESION_PLUSPLUS2                         = 190, // <SentenciaExpresion> ::= <PosfijoExpresion> '++'
        RULE_SENTENCIAEXPRESION_MINUSMINUS2                       = 191, // <SentenciaExpresion> ::= <PosfijoExpresion> --
        RULE_SENTENCIAEXPRESION2                                  = 192, // <SentenciaExpresion> ::= <InvocacionMetodo>
        RULE_SENTENCIAEXPRESION3                                  = 193, // <SentenciaExpresion> ::= <CreacionInstancia>
        RULE_SWITCHBLOCK_LBRACE_RBRACE                            = 194, // <SwitchBlock> ::= '{' <GruposSwitch> <SwitchLabels> '}'
        RULE_SWITCHBLOCK_LBRACE_RBRACE2                           = 195, // <SwitchBlock> ::= '{' <GruposSwitch> '}'
        RULE_SWITCHBLOCK_LBRACE_RBRACE3                           = 196, // <SwitchBlock> ::= '{' <SwitchLabels> '}'
        RULE_SWITCHBLOCK_LBRACE_RBRACE4                           = 197, // <SwitchBlock> ::= '{' '}'
        RULE_GRUPOSSWITCH                                         = 198, // <GruposSwitch> ::= <SwitchLabels> <BlockSentencias>
        RULE_GRUPOSSWITCH2                                        = 199, // <GruposSwitch> ::= <GruposSwitch> <SwitchLabels> <BlockSentencias>
        RULE_SWITCHLABELS                                         = 200, // <SwitchLabels> ::= <SwitchLabel>
        RULE_SWITCHLABELS2                                        = 201, // <SwitchLabels> ::= <SwitchLabels> <SwitchLabel>
        RULE_SWITCHLABEL_CASE_COLON                               = 202, // <SwitchLabel> ::= case <ExpresionAsigna> ':'
        RULE_SWITCHLABEL_DEFAULT_COLON                            = 203, // <SwitchLabel> ::= default ':'
        RULE_FORSENTENCIA_FOR_LPARAN_SEMI_SEMI_RPARAN             = 204, // <ForSentencia> ::= for '(' <InicializarFor> ';' <ExpresionAsigna> ';' <ForActualizar> ')' <Sentencia>
        RULE_FORSENTENCIA_FOR_LPARAN_SEMI_SEMI_RPARAN2            = 205, // <ForSentencia> ::= for '(' <InicializarFor> ';' <ExpresionAsigna> ';' ')' <Sentencia>
        RULE_FORSENTENCIA_FOR_LPARAN_SEMI_SEMI_RPARAN3            = 206, // <ForSentencia> ::= for '(' <InicializarFor> ';' ';' <ForActualizar> ')' <Sentencia>
        RULE_FORSENTENCIA_FOR_LPARAN_SEMI_SEMI_RPARAN4            = 207, // <ForSentencia> ::= for '(' <InicializarFor> ';' ';' ')' <Sentencia>
        RULE_FORSENTENCIA_FOR_LPARAN_SEMI_SEMI_RPARAN5            = 208, // <ForSentencia> ::= for '(' ';' <ExpresionAsigna> ';' <ForActualizar> ')' <Sentencia>
        RULE_FORSENTENCIA_FOR_LPARAN_SEMI_SEMI_RPARAN6            = 209, // <ForSentencia> ::= for '(' ';' <ExpresionAsigna> ';' ')' <Sentencia>
        RULE_FORSENTENCIA_FOR_LPARAN_SEMI_SEMI_RPARAN7            = 210, // <ForSentencia> ::= for '(' ';' ';' <ForActualizar> ')' <Sentencia>
        RULE_FORSENTENCIA_FOR_LPARAN_SEMI_SEMI_RPARAN8            = 211, // <ForSentencia> ::= for '(' ';' ';' ')' <Sentencia>
        RULE_FORSENTENCIAIFEXTENDIDO_FOR_LPARAN_SEMI_SEMI_RPARAN  = 212, // <ForSentenciaIfExtendido> ::= for '(' <InicializarFor> ';' <ExpresionAsigna> ';' <ForActualizar> ')' <SentenciaIfExtendido>
        RULE_FORSENTENCIAIFEXTENDIDO_FOR_LPARAN_SEMI_SEMI_RPARAN2 = 213, // <ForSentenciaIfExtendido> ::= for '(' <InicializarFor> ';' <ExpresionAsigna> ';' ')' <SentenciaIfExtendido>
        RULE_FORSENTENCIAIFEXTENDIDO_FOR_LPARAN_SEMI_SEMI_RPARAN3 = 214, // <ForSentenciaIfExtendido> ::= for '(' <InicializarFor> ';' ';' <ForActualizar> ')' <SentenciaIfExtendido>
        RULE_FORSENTENCIAIFEXTENDIDO_FOR_LPARAN_SEMI_SEMI_RPARAN4 = 215, // <ForSentenciaIfExtendido> ::= for '(' <InicializarFor> ';' ';' ')' <SentenciaIfExtendido>
        RULE_FORSENTENCIAIFEXTENDIDO_FOR_LPARAN_SEMI_SEMI_RPARAN5 = 216, // <ForSentenciaIfExtendido> ::= for '(' ';' <ExpresionAsigna> ';' <ForActualizar> ')' <SentenciaIfExtendido>
        RULE_FORSENTENCIAIFEXTENDIDO_FOR_LPARAN_SEMI_SEMI_RPARAN6 = 217, // <ForSentenciaIfExtendido> ::= for '(' ';' <ExpresionAsigna> ';' ')' <SentenciaIfExtendido>
        RULE_FORSENTENCIAIFEXTENDIDO_FOR_LPARAN_SEMI_SEMI_RPARAN7 = 218, // <ForSentenciaIfExtendido> ::= for '(' ';' ';' <ForActualizar> ')' <SentenciaIfExtendido>
        RULE_FORSENTENCIAIFEXTENDIDO_FOR_LPARAN_SEMI_SEMI_RPARAN8 = 219, // <ForSentenciaIfExtendido> ::= for '(' ';' ';' ')' <SentenciaIfExtendido>
        RULE_INICIALIZARFOR                                       = 220, // <InicializarFor> ::= <ListadoSentenciaExpresion>
        RULE_INICIALIZARFOR2                                      = 221, // <InicializarFor> ::= <Tipo> <DeclaradoresVariable>
        RULE_FORACTUALIZAR                                        = 222, // <ForActualizar> ::= <ListadoSentenciaExpresion>
        RULE_LISTADOSENTENCIAEXPRESION                            = 223, // <ListadoSentenciaExpresion> ::= <SentenciaExpresion>
        RULE_LISTADOSENTENCIAEXPRESION_COMMA                      = 224, // <ListadoSentenciaExpresion> ::= <ListadoSentenciaExpresion> ',' <SentenciaExpresion>
        RULE_PRIMARY                                              = 225, // <Primary> ::= <PrimaryNoNewArray>
        RULE_PRIMARY2                                             = 226, // <Primary> ::= <CreacionArray>
        RULE_PRIMARYNONEWARRAY                                    = 227, // <PrimaryNoNewArray> ::= <Literal>
        RULE_PRIMARYNONEWARRAY_THIS                               = 228, // <PrimaryNoNewArray> ::= this
        RULE_PRIMARYNONEWARRAY_LPARAN_RPARAN                      = 229, // <PrimaryNoNewArray> ::= '(' <ExpresionAsigna> ')'
        RULE_PRIMARYNONEWARRAY2                                   = 230, // <PrimaryNoNewArray> ::= <CreacionInstancia>
        RULE_PRIMARYNONEWARRAY3                                   = 231, // <PrimaryNoNewArray> ::= <AccesoCampo>
        RULE_PRIMARYNONEWARRAY4                                   = 232, // <PrimaryNoNewArray> ::= <InvocacionMetodo>
        RULE_PRIMARYNONEWARRAY5                                   = 233, // <PrimaryNoNewArray> ::= <AccesoArray>
        RULE_CREACIONINSTANCIA_NEW_LPARAN_RPARAN                  = 234, // <CreacionInstancia> ::= new <Nombre> '(' <ListaArgumento> ')'
        RULE_CREACIONINSTANCIA_NEW_LPARAN_RPARAN2                 = 235, // <CreacionInstancia> ::= new <Nombre> '(' ')'
        RULE_LISTAARGUMENTO                                       = 236, // <ListaArgumento> ::= <ExpresionAsigna>
        RULE_LISTAARGUMENTO_COMMA                                 = 237, // <ListaArgumento> ::= <ListaArgumento> ',' <ExpresionAsigna>
        RULE_CREACIONARRAY_NEW                                    = 238, // <CreacionArray> ::= new <TipoPrimitivo> <ExprsCorchetes> <Corchetes>
        RULE_CREACIONARRAY_NEW2                                   = 239, // <CreacionArray> ::= new <TipoPrimitivo> <ExprsCorchetes>
        RULE_CREACIONARRAY_NEW3                                   = 240, // <CreacionArray> ::= new <Nombre> <ExprsCorchetes> <Corchetes>
        RULE_CREACIONARRAY_NEW4                                   = 241, // <CreacionArray> ::= new <Nombre> <ExprsCorchetes>
        RULE_EXPRSCORCHETES                                       = 242, // <ExprsCorchetes> ::= <ExprCorchetes>
        RULE_EXPRSCORCHETES2                                      = 243, // <ExprsCorchetes> ::= <ExprsCorchetes> <ExprCorchetes>
        RULE_EXPRCORCHETES_LBRACKET_RBRACKET                      = 244, // <ExprCorchetes> ::= '[' <ExpresionAsigna> ']'
        RULE_CORCHETES_LBRACKET_RBRACKET                          = 245, // <Corchetes> ::= '[' ']'
        RULE_CORCHETES_LBRACKET_RBRACKET2                         = 246, // <Corchetes> ::= <Corchetes> '[' ']'
        RULE_ACCESOCAMPO_DOT_ID                                   = 247, // <AccesoCampo> ::= <Primary> '.' Id
        RULE_ACCESOCAMPO_SUPER_DOT_ID                             = 248, // <AccesoCampo> ::= super '.' Id
        RULE_INVOCACIONMETODO_LPARAN_RPARAN                       = 249, // <InvocacionMetodo> ::= <Nombre> '(' <ListaArgumento> ')'
        RULE_INVOCACIONMETODO_LPARAN_RPARAN2                      = 250, // <InvocacionMetodo> ::= <Nombre> '(' ')'
        RULE_INVOCACIONMETODO_DOT_ID_LPARAN_RPARAN                = 251, // <InvocacionMetodo> ::= <Primary> '.' Id '(' <ListaArgumento> ')'
        RULE_INVOCACIONMETODO_DOT_ID_LPARAN_RPARAN2               = 252, // <InvocacionMetodo> ::= <Primary> '.' Id '(' ')'
        RULE_INVOCACIONMETODO_SUPER_DOT_ID_LPARAN_RPARAN          = 253, // <InvocacionMetodo> ::= super '.' Id '(' <ListaArgumento> ')'
        RULE_INVOCACIONMETODO_SUPER_DOT_ID_LPARAN_RPARAN2         = 254, // <InvocacionMetodo> ::= super '.' Id '(' ')'
        RULE_ACCESOARRAY_LBRACKET_RBRACKET                        = 255, // <AccesoArray> ::= <Nombre> '[' <ExpresionAsigna> ']'
        RULE_ACCESOARRAY_LBRACKET_RBRACKET2                       = 256, // <AccesoArray> ::= <PrimaryNoNewArray> '[' <ExpresionAsigna> ']'
        RULE_CASTEXPRESION_LPARAN_RPARAN                          = 257, // <CastExpresion> ::= '(' <TipoPrimitivo> <Corchetes> ')' <UnarioExpresion>
        RULE_CASTEXPRESION_LPARAN_RPARAN2                         = 258, // <CastExpresion> ::= '(' <TipoPrimitivo> ')' <UnarioExpresion>
        RULE_CASTEXPRESION_LPARAN_RPARAN3                         = 259, // <CastExpresion> ::= '(' <ExpresionAsigna> ')' <UnarioExpresionOtra>
        RULE_CASTEXPRESION_LPARAN_RPARAN4                         = 260, // <CastExpresion> ::= '(' <Nombre> <Corchetes> ')' <UnarioExpresionOtra>
        RULE_MULTEXPRESION                                        = 261, // <MultExpresion> ::= <UnarioExpresion>
        RULE_MULTEXPRESION_TIMES                                  = 262, // <MultExpresion> ::= <MultExpresion> '*' <UnarioExpresion>
        RULE_MULTEXPRESION_DIV                                    = 263, // <MultExpresion> ::= <MultExpresion> '/' <UnarioExpresion>
        RULE_MULTEXPRESION_PERCENT                                = 264, // <MultExpresion> ::= <MultExpresion> '%' <UnarioExpresion>
        RULE_ADDEXPRESION                                         = 265, // <AddExpresion> ::= <MultExpresion>
        RULE_ADDEXPRESION_PLUS                                    = 266, // <AddExpresion> ::= <AddExpresion> '+' <MultExpresion>
        RULE_ADDEXPRESION_MINUS                                   = 267, // <AddExpresion> ::= <AddExpresion> '-' <MultExpresion>
        RULE_EXPRESIONCOMPARAR                                    = 268, // <ExpresionComparar> ::= <AddExpresion>
        RULE_EXPRESIONCOMPARAR_LT                                 = 269, // <ExpresionComparar> ::= <ExpresionComparar> '<' <AddExpresion>
        RULE_EXPRESIONCOMPARAR_GT                                 = 270, // <ExpresionComparar> ::= <ExpresionComparar> '>' <AddExpresion>
        RULE_EXPRESIONCOMPARAR_LTEQ                               = 271, // <ExpresionComparar> ::= <ExpresionComparar> '<=' <AddExpresion>
        RULE_EXPRESIONCOMPARAR_GTEQ                               = 272, // <ExpresionComparar> ::= <ExpresionComparar> '>=' <AddExpresion>
        RULE_EXPRESIONCOMPARAR_INSTANCEOF                         = 273, // <ExpresionComparar> ::= <ExpresionComparar> instanceof <TipoReferencia>
        RULE_EXPRESIONIGUAL                                       = 274, // <ExpresionIgual> ::= <ExpresionComparar>
        RULE_EXPRESIONIGUAL_EQEQ                                  = 275, // <ExpresionIgual> ::= <ExpresionIgual> '==' <ExpresionComparar>
        RULE_EXPRESIONIGUAL_EXCLAMEQ                              = 276, // <ExpresionIgual> ::= <ExpresionIgual> '!=' <ExpresionComparar>
        RULE_ANDCONDICIONALEXPRESION                              = 277, // <AndCondicionalExpresion> ::= <ExpresionIgual>
        RULE_ANDCONDICIONALEXPRESION_AMPAMP                       = 278, // <AndCondicionalExpresion> ::= <AndCondicionalExpresion> '&&' <ExpresionIgual>
        RULE_ORCONDICIONALEXPRESION                               = 279, // <OrCondicionalExpresion> ::= <AndCondicionalExpresion>
        RULE_ORCONDICIONALEXPRESION_PIPEPIPE                      = 280, // <OrCondicionalExpresion> ::= <OrCondicionalExpresion> '||' <AndCondicionalExpresion>
        RULE_EXPRESIONCONDICIONAL                                 = 281, // <ExpresionCondicional> ::= <OrCondicionalExpresion>
        RULE_EXPRESIONCONDICIONAL_QUESTION_COLON                  = 282, // <ExpresionCondicional> ::= <OrCondicionalExpresion> '?' <ExpresionAsigna> ':' <ExpresionCondicional>
        RULE_POSFIJOEXPRESION                                     = 283, // <PosfijoExpresion> ::= <Primary>
        RULE_POSFIJOEXPRESION2                                    = 284, // <PosfijoExpresion> ::= <Nombre>
        RULE_POSFIJOEXPRESION_PLUSPLUS                            = 285, // <PosfijoExpresion> ::= <PosfijoExpresion> '++'
        RULE_POSFIJOEXPRESION_MINUSMINUS                          = 286, // <PosfijoExpresion> ::= <PosfijoExpresion> --
        RULE_UNARIOEXPRESION_PLUSPLUS                             = 287, // <UnarioExpresion> ::= '++' <UnarioExpresion>
        RULE_UNARIOEXPRESION_MINUSMINUS                           = 288, // <UnarioExpresion> ::= -- <UnarioExpresion>
        RULE_UNARIOEXPRESION_PLUS                                 = 289, // <UnarioExpresion> ::= '+' <UnarioExpresion>
        RULE_UNARIOEXPRESION_MINUS                                = 290, // <UnarioExpresion> ::= '-' <UnarioExpresion>
        RULE_UNARIOEXPRESION                                      = 291, // <UnarioExpresion> ::= <UnarioExpresionOtra>
        RULE_UNARIOEXPRESIONOTRA                                  = 292, // <UnarioExpresionOtra> ::= <PosfijoExpresion>
        RULE_UNARIOEXPRESIONOTRA2                                 = 293, // <UnarioExpresionOtra> ::= <CastExpresion>
        RULE_EXPRESIONASIGNA                                      = 294, // <ExpresionAsigna> ::= <ExpresionCondicional>
        RULE_EXPRESIONASIGNA2                                     = 295, // <ExpresionAsigna> ::= <LeftSide> <OperadorAsignacion> <ExpresionAsigna>
        RULE_LEFTSIDE                                             = 296, // <LeftSide> ::= <Nombre>
        RULE_LEFTSIDE2                                            = 297, // <LeftSide> ::= <AccesoCampo>
        RULE_LEFTSIDE3                                            = 298, // <LeftSide> ::= <AccesoArray>
        RULE_OPERADORASIGNACION_EQ                                = 299, // <OperadorAsignacion> ::= '='
        RULE_OPERADORASIGNACION_TIMESEQ                           = 300, // <OperadorAsignacion> ::= '*='
        RULE_OPERADORASIGNACION_DIVEQ                             = 301, // <OperadorAsignacion> ::= '/='
        RULE_OPERADORASIGNACION_PERCENTEQ                         = 302, // <OperadorAsignacion> ::= '%='
        RULE_OPERADORASIGNACION_PLUSEQ                            = 303, // <OperadorAsignacion> ::= '+='
        RULE_OPERADORASIGNACION_MINUSEQ                           = 304, // <OperadorAsignacion> ::= '-='
        RULE_CONTINUESENTENCIA_CONTINUE_ID_SEMI                   = 305, // <ContinueSentencia> ::= continue Id ';'
        RULE_CONTINUESENTENCIA_CONTINUE_SEMI                      = 306, // <ContinueSentencia> ::= continue ';'
        RULE_RETURNSENTENCIA_RETURN_SEMI                          = 307, // <ReturnSentencia> ::= return <ExpresionAsigna> ';'
        RULE_RETURNSENTENCIA_RETURN_SEMI2                         = 308, // <ReturnSentencia> ::= return ';'
        RULE_TRYSENTENCIA_TRY                                     = 309, // <TrySentencia> ::= try <Block> <Catches>
        RULE_TRYSENTENCIA_TRY_FINALLY                             = 310, // <TrySentencia> ::= try <Block> <Catches> finally <Block>
        RULE_TRYSENTENCIA_TRY_FINALLY2                            = 311, // <TrySentencia> ::= try <Block> finally <Block>
        RULE_CATCHES_CATCH_LPARAN_RPARAN                          = 312, // <Catches> ::= catch '(' <Tipo> <DeclaradorVariableId> ')' <Block>
        RULE_CATCHES_CATCH_LPARAN_RPARAN2                         = 313, // <Catches> ::= <Catches> catch '(' <Tipo> <DeclaradorVariableId> ')' <Block>
        RULE_BREAKSENTENCIA_BREAK_ID_SEMI                         = 314, // <BreakSentencia> ::= break Id ';'
        RULE_BREAKSENTENCIA_BREAK_SEMI                            = 315  // <BreakSentencia> ::= break ';'
    };

    public class MyParser
    {
        private LALRParser parser;
        public int vuelta = 0;
        TablaSimbolos tabla = new TablaSimbolos();
        
        public MyParser(string filename)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnReduce += new LALRParser.ReduceHandler(ReduceEvent);
            parser.OnTokenRead += new LALRParser.TokenReadHandler(TokenReadEvent);
            parser.OnAccept += new LALRParser.AcceptHandler(AcceptEvent);
            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
        }

        public void Parse(string source)
        {
            for (vuelta = 0; vuelta < 4; vuelta++)
            {
                parser.Parse(source);
            }
        }

        private void TokenReadEvent(LALRParser parser, TokenReadEventArgs args)
        {
            try
            {
                args.Token.UserObject = CreateObject(args.Token);
            }
            catch (Exception e)
            {
                args.Continue = false;
                MessageBox.Show("Error: " + e.Message);
            }
        }

        private Object CreateObject(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //(Whitespace)
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_COMMENTEND :
                //(Comment End)
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_COMMENTLINE :
                //(Comment Line)
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_COMMENTSTART :
                //(Comment Start)
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_MINUSMINUS :
                //--
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_EXCLAMEQ :
                //'!='
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_PERCENT :
                //'%'
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_PERCENTEQ :
                //'%='
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_AMPAMP :
                //'&&'
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_LPARAN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_RPARAN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_TIMESEQ :
                //'*='
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_COMMA :
                //','
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_DOT :
                //'.'
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_DIVEQ :
                //'/='
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_COLON :
                //':'
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_SEMI :
                //';'
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_QUESTION :
                //'?'
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_LBRACKET :
                //'['
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_RBRACKET :
                //']'
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_LBRACE :
                //'{'
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_PIPEPIPE :
                //'||'
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_RBRACE :
                //'}'
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_PLUSPLUS :
                //'++'
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_PLUSEQ :
                //'+='
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_LTEQ :
                //'<='
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_MINUSEQ :
                //'-='
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_EQEQ :
                //'=='
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_GTEQ :
                //'>='
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_ABSTRACT :
                //abstract
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_BOOL :
                //Bool
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_BOOLEAN :
                //boolean
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_BREAK :
                //break
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_BUTTONGROUP :
                //ButtonGroup
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_BYTE :
                //byte
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_CASE :
                //case
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_CATCH :
                //catch
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_CHAR :
                //char
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_CHARINDIRECTO :
                //CharIndirecto
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_CLASS :
                //class
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_CONTINUE :
                //continue
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_DEFAULT :
                //default
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_DO :
                //do
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_DOUBLE :
                //double
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_ELSE :
                //else
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_EXPRNULL :
                //ExprNull
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_EXTENDS :
                //extends
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_FINAL :
                //final
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_FINALLY :
                //finally
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_FLOAT :
                //float
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_FOR :
                //for
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_HEXESCAPECHAR :
                //HexEscapeChar
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_ID :
                //Id
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_IF :
                //if
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_IMPLEMENTS :
                //implements
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_IMPORT :
                //import
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_INSTANCEOF :
                //instanceof
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_INT :
                //int
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_INTERFACE :
                //interface
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_JBUTTON :
                //JButton
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_JCHECKBOX :
                //JCheckBox
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_JCOMBOBOX :
                //JComboBox
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_JFILECHOOSER :
                //JFileChooser
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_JLABEL :
                //JLabel
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_JPANEL :
                //JPanel
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_JPASSWORDFIELD :
                //JPasswordField
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_JRADIOBUTTON :
                //JRadioButton
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_JTABLE :
                //JTable
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_JTEXTAREA :
                //JTextArea
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_JTEXTFIELD :
                //JTextField
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_JTREE :
                //JTree
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_LONG :
                //long
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_NATIVE :
                //native
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_NEW :
                //new
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_NUM :
                //Num
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_NUMCERO :
                //NumCero
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_NUMFLOAT :
                //NumFloat
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_NUMFLOATEXP :
                //NumFloatExp
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_NUMHEX :
                //NumHex
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_NUMOCTAL :
                //NumOctal
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_OCTALESCAPECHAR :
                //OctalEscapeChar
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_PACKAGE :
                //package
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_PRIVATE :
                //private
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_PROTECTED :
                //protected
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_PUBLIC :
                //public
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_RETURN :
                //return
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_SHORT :
                //short
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_STATIC :
                //static
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_STESCAPECHAR :
                //StEscapeChar
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_STRING :
                //String
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_SUPER :
                //super
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_SWITCH :
                //switch
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_SYNCHRONIZED :
                //synchronized
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_THIS :
                //this
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_THROW :
                //throw
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_THROWS :
                //throws
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_TRANSIENT :
                //transient
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_TRY :
                //try
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_VOID :
                //void
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_VOLATILE :
                //volatile
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_WHILE :
                //while
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_ACCESOARRAY :
                //<AccesoArray>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_ACCESOCAMPO :
                //<AccesoCampo>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_ADDEXPRESION :
                //<AddExpresion>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_ANDCONDICIONALEXPRESION :
                //<AndCondicionalExpresion>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_ARRAYINI :
                //<ArrayIni>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_BLOCK :
                //<Block>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_BLOCKSENTENCIA :
                //<BlockSentencia>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_BLOCKSENTENCIAS :
                //<BlockSentencias>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_BREAKSENTENCIA :
                //<BreakSentencia>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_CABECERAMETODO :
                //<CabeceraMetodo>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_CARACTER :
                //<Caracter>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_CASTEXPRESION :
                //<CastExpresion>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_CATCHES :
                //<Catches>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_CONSTRUCTORDECLARATOR :
                //<ConstructorDeclarator>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_CONTINUESENTENCIA :
                //<ContinueSentencia>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_CORCHETES :
                //<Corchetes>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_CREACIONARRAY :
                //<CreacionArray>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_CREACIONINSTANCIA :
                //<CreacionInstancia>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_CUERPOCLASE :
                //<CuerpoClase>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_CUERPOCONSTRUCTOR :
                //<CuerpoConstructor>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_CUERPOINTERFAZ :
                //<CuerpoInterfaz>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_CUERPOMETODO :
                //<CuerpoMetodo>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_DECLARACIONCAMPO :
                //<DeclaracionCampo>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_DECLARACIONCLASE :
                //<DeclaracionClase>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_DECLARACIONCONSTRUCTOR :
                //<DeclaracionConstructor>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_DECLARACIONCUERPOCLASE :
                //<DeclaracionCuerpoClase>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_DECLARACIONESCUERPOCLASE :
                //<DeclaracionesCuerpoClase>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_DECLARACIONESIMPORT :
                //<DeclaracionesImport>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_DECLARACIONESMIEMBROINTERFAZ :
                //<DeclaracionesMiembroInterfaz>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_DECLARACIONESTIPO :
                //<DeclaracionesTipo>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_DECLARACIONIMPORT :
                //<DeclaracionImport>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_DECLARACIONINTERFAZ :
                //<DeclaracionInterfaz>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_DECLARACIONMETODOABSTRACTO :
                //<DeclaracionMetodoAbstracto>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_DECLARACIONMIEMBROCLASE :
                //<DeclaracionMiembroClase>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_DECLARACIONMIEMBROINTERFAZ :
                //<DeclaracionMiembroInterfaz>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_DECLARACIONTIPO :
                //<DeclaracionTipo>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_DECLARADORESVARIABLE :
                //<DeclaradoresVariable>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_DECLARADORMETODO :
                //<DeclaradorMetodo>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_DECLARADORVARIABLE :
                //<DeclaradorVariable>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_DECLARADORVARIABLEID :
                //<DeclaradorVariableId>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_EXPRCORCHETES :
                //<ExprCorchetes>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_EXPRESIONASIGNA :
                //<ExpresionAsigna>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_EXPRESIONCOMPARAR :
                //<ExpresionComparar>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_EXPRESIONCONDICIONAL :
                //<ExpresionCondicional>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_EXPRESIONIGUAL :
                //<ExpresionIgual>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_EXPRSCORCHETES :
                //<ExprsCorchetes>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_EXTENDSINTERFACES :
                //<ExtendsInterfaces>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_FLOAT2 :
                //<float>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_FORACTUALIZAR :
                //<ForActualizar>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_FORSENTENCIA :
                //<ForSentencia>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_FORSENTENCIAIFEXTENDIDO :
                //<ForSentenciaIfExtendido>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_GRUPOSSWITCH :
                //<GruposSwitch>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_INICIALIZARFOR :
                //<InicializarFor>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_INT2 :
                //<Int>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_INVOCACIONMETODO :
                //<InvocacionMetodo>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_INVOEXPLICITACONSTRUCTOR :
                //<InvoExplicitaConstructor>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_LEFTSIDE :
                //<LeftSide>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_LISTAARGUMENTO :
                //<ListaArgumento>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_LISTADOSENTENCIAEXPRESION :
                //<ListadoSentenciaExpresion>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_LISTAINTERFACES :
                //<ListaInterfaces>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_LISTATIPOCLASE :
                //<ListaTipoClase>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_LITERAL :
                //<Literal>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_MODIFICADOR :
                //<Modificador>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_MULTEXPRESION :
                //<MultExpresion>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_NOMBRE :
                //<Nombre>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_NOMBRECLASIFICADO :
                //<NombreClasificado>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_NOMBRESIMPLE :
                //<NombreSimple>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_NUMDECIMAL :
                //<numdecimal>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_OPERADORASIGNACION :
                //<OperadorAsignacion>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_ORCONDICIONALEXPRESION :
                //<OrCondicionalExpresion>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_PARAMLIST :
                //<ParamList>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_POSFIJOEXPRESION :
                //<PosfijoExpresion>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_PRIMARY :
                //<Primary>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_PRIMARYNONEWARRAY :
                //<PrimaryNoNewArray>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_PROGRAM :
                //<Program>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_RETURNSENTENCIA :
                //<ReturnSentencia>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_SENTENCIA :
                //<Sentencia>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_SENTENCIAEXPRESION :
                //<SentenciaExpresion>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_SENTENCIAIFEXTENDIDO :
                //<SentenciaIfExtendido>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_SENTENCIASINSUBSENTENCIA :
                //<SentenciaSinSubsentencia>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_SWITCHBLOCK :
                //<SwitchBlock>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_SWITCHLABEL :
                //<SwitchLabel>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_SWITCHLABELS :
                //<SwitchLabels>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_THROWS2 :
                //<Throws>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_TIPO :
                //<Tipo>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_TIPOARRAY :
                //<TipoArray>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_TIPOFLOTANTE :
                //<TipoFlotante>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_TIPOINT :
                //<TipoInt>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_TIPONUMERICO :
                //<TipoNumerico>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_TIPOPRIMITIVO :
                //<TipoPrimitivo>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_TIPOREFERENCIA :
                //<TipoReferencia>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_TIPOSJAVA :
                //<TiposJava>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_TRYSENTENCIA :
                //<TrySentencia>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_UNARIOEXPRESION :
                //<UnarioExpresion>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_UNARIOEXPRESIONOTRA :
                //<UnarioExpresionOtra>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_VARIABLEINI :
                //<VariableIni>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

                case (int)SymbolConstants.SYMBOL_VARIABLEINIS :
                //<VariableInis>
                //todo: Create a new object that corresponds to the symbol
                    return token.Text;

            }
            throw new SymbolException("Unknown symbol");
        }

        private void ReduceEvent(LALRParser parser, ReduceEventArgs args)
        {
            try
            {
                args.Token.UserObject = CreateObject(args.Token);
            }
            catch (Exception e)
            {
                args.Continue = false;
                MessageBox.Show("Error: " + e.Message);
            }
        }

        public static Object CreateObject(NonterminalToken token)
        {
            string[] lista;
            int tipo_pos = 0;
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PROGRAM_PACKAGE_SEMI :
                //<Program> ::= package <Nombre> ';' <DeclaracionesImport> <DeclaracionesTipo>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_PROGRAM_PACKAGE_SEMI2 :
                //<Program> ::= package <Nombre> ';' <DeclaracionesImport>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_PROGRAM_PACKAGE_SEMI3 :
                //<Program> ::= package <Nombre> ';' <DeclaracionesTipo>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_PROGRAM_PACKAGE_SEMI4 :
                //<Program> ::= package <Nombre> ';'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_PROGRAM :
                //<Program> ::= <DeclaracionesImport> <DeclaracionesTipo>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_PROGRAM2 :
                //<Program> ::= <DeclaracionesImport>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_PROGRAM3 :
                //<Program> ::= <DeclaracionesTipo>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_PROGRAM4 :
                //<Program> ::= 
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_DECLARACIONESIMPORT :
                //<DeclaracionesImport> ::= <DeclaracionImport>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_DECLARACIONESIMPORT2 :
                //<DeclaracionesImport> ::= <DeclaracionesImport> <DeclaracionImport>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_DECLARACIONESTIPO :
                //<DeclaracionesTipo> ::= <DeclaracionTipo>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_DECLARACIONESTIPO2 :
                //<DeclaracionesTipo> ::= <DeclaracionesTipo> <DeclaracionTipo>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_DECLARACIONIMPORT_IMPORT_SEMI :
                //<DeclaracionImport> ::= import <Nombre> ';'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_DECLARACIONIMPORT_IMPORT_DOT_TIMES_SEMI :
                //<DeclaracionImport> ::= import <Nombre> '.' '*' ';'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_DECLARACIONTIPO :
                //<DeclaracionTipo> ::= <DeclaracionClase>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_DECLARACIONTIPO2 :
                //<DeclaracionTipo> ::= <DeclaracionInterfaz>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_MODIFICADOR_PUBLIC :
                //<Modificador> ::= public
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_MODIFICADOR_PROTECTED :
                //<Modificador> ::= protected
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_MODIFICADOR_PRIVATE :
                //<Modificador> ::= private
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_MODIFICADOR_STATIC :
                //<Modificador> ::= static
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_MODIFICADOR_ABSTRACT :
                //<Modificador> ::= abstract
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_MODIFICADOR_FINAL :
                //<Modificador> ::= final
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_MODIFICADOR_NATIVE :
                //<Modificador> ::= native
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_MODIFICADOR_SYNCHRONIZED :
                //<Modificador> ::= synchronized
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_MODIFICADOR_TRANSIENT :
                //<Modificador> ::= transient
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_MODIFICADOR_VOLATILE :
                //<Modificador> ::= volatile
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_DECLARACIONCLASE_CLASS_ID_EXTENDS_IMPLEMENTS :
                //<DeclaracionClase> ::= <Modificador> class Id extends <Nombre> implements <ListaInterfaces> <CuerpoClase>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_DECLARACIONCLASE_CLASS_ID_EXTENDS :
                //<DeclaracionClase> ::= <Modificador> class Id extends <Nombre> <CuerpoClase>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_DECLARACIONCLASE_CLASS_ID_IMPLEMENTS :
                //<DeclaracionClase> ::= <Modificador> class Id implements <ListaInterfaces> <CuerpoClase>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_DECLARACIONCLASE_CLASS_ID :
                //<DeclaracionClase> ::= <Modificador> class Id <CuerpoClase>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_DECLARACIONCLASE_CLASS_ID_EXTENDS_IMPLEMENTS2 :
                //<DeclaracionClase> ::= class Id extends <Nombre> implements <ListaInterfaces> <CuerpoClase>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_DECLARACIONCLASE_CLASS_ID_EXTENDS2 :
                //<DeclaracionClase> ::= class Id extends <Nombre> <CuerpoClase>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_DECLARACIONCLASE_CLASS_ID_IMPLEMENTS2 :
                //<DeclaracionClase> ::= class Id implements <ListaInterfaces> <CuerpoClase>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_DECLARACIONCLASE_CLASS_ID2 :
                //<DeclaracionClase> ::= class Id <CuerpoClase>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LISTAINTERFACES :
                //<ListaInterfaces> ::= <Nombre>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LISTAINTERFACES_COMMA :
                //<ListaInterfaces> ::= <ListaInterfaces> ',' <Nombre>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CUERPOCLASE_LBRACE_RBRACE :
                //<CuerpoClase> ::= '{' <DeclaracionesCuerpoClase> '}'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CUERPOCLASE_LBRACE_RBRACE2 :
                //<CuerpoClase> ::= '{' '}'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_DECLARACIONESCUERPOCLASE :
                //<DeclaracionesCuerpoClase> ::= <DeclaracionCuerpoClase>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_DECLARACIONESCUERPOCLASE2 :
                //<DeclaracionesCuerpoClase> ::= <DeclaracionesCuerpoClase> <DeclaracionCuerpoClase>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_DECLARACIONCUERPOCLASE :
                //<DeclaracionCuerpoClase> ::= <DeclaracionMiembroClase>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_DECLARACIONCUERPOCLASE_STATIC :
                //<DeclaracionCuerpoClase> ::= static <Block>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_DECLARACIONCUERPOCLASE2 :
                //<DeclaracionCuerpoClase> ::= <DeclaracionConstructor>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_DECLARACIONMIEMBROCLASE :
                //<DeclaracionMiembroClase> ::= <DeclaracionCampo>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_DECLARACIONMIEMBROCLASE2 :
                //<DeclaracionMiembroClase> ::= <CabeceraMetodo> <CuerpoMetodo>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_DECLARACIONCAMPO_SEMI :
                //<DeclaracionCampo> ::= <Modificador> <Tipo> <DeclaradoresVariable> ';'
                    lista = token.Tokens[2].UserObject.ToString().Trim().Split(new char[]{','});
                    tipo_pos = this.tabla.convertPos(token.Tokens[1].UserObject.ToString());
                    for (int i = 0; i < lista.Length; i++)
                    {
                        this.tabla.addItem(lista[i].ToString(), tipo_pos);
                    }
                return null;

                case (int)RuleConstants.RULE_DECLARACIONCAMPO_SEMI2 :
                //<DeclaracionCampo> ::= <Tipo> <DeclaradoresVariable> ';'
                    lista = token.Tokens[1].UserObject.ToString().Trim().Split(new char[] { ',' });
                    tipo_pos = this.tabla.convertPos(token.Tokens[0].UserObject.ToString());
                    for (int i = 0; i < lista.Length; i++)
                    {
                        this.tabla.addItem(lista[i].ToString(), tipo_pos);
                    }
                return null;

                case (int)RuleConstants.RULE_DECLARADORESVARIABLE :
                //<DeclaradoresVariable> ::= <DeclaradorVariable>
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_DECLARADORESVARIABLE_COMMA :
                //<DeclaradoresVariable> ::= <DeclaradoresVariable> ',' <DeclaradorVariable>
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString() + "," + token.Tokens[2].UserObject.ToString();

                case (int)RuleConstants.RULE_DECLARADORVARIABLE :
                //<DeclaradorVariable> ::= <DeclaradorVariableId>
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_DECLARADORVARIABLE_EQ :
                //<DeclaradorVariable> ::= <DeclaradorVariableId> '=' <VariableIni>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_DECLARADORVARIABLEID_ID :
                //<DeclaradorVariableId> ::= Id
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_DECLARADORVARIABLEID_LBRACKET_RBRACKET :
                //<DeclaradorVariableId> ::= <DeclaradorVariableId> '[' ']'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_VARIABLEINI :
                //<VariableIni> ::= <ExpresionAsigna>
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_VARIABLEINI2 :
                //<VariableIni> ::= <ArrayIni>
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_CABECERAMETODO :
                //<CabeceraMetodo> ::= <Modificador> <Tipo> <DeclaradorMetodo> <Throws>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CABECERAMETODO2 :
                //<CabeceraMetodo> ::= <Modificador> <Tipo> <DeclaradorMetodo>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CABECERAMETODO3 :
                //<CabeceraMetodo> ::= <Tipo> <DeclaradorMetodo> <Throws>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CABECERAMETODO4 :
                //<CabeceraMetodo> ::= <Tipo> <DeclaradorMetodo>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CABECERAMETODO_VOID :
                //<CabeceraMetodo> ::= <Modificador> void <DeclaradorMetodo> <Throws>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CABECERAMETODO_VOID2 :
                //<CabeceraMetodo> ::= <Modificador> void <DeclaradorMetodo>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CABECERAMETODO_VOID3 :
                //<CabeceraMetodo> ::= void <DeclaradorMetodo> <Throws>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CABECERAMETODO_VOID4 :
                //<CabeceraMetodo> ::= void <DeclaradorMetodo>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_DECLARADORMETODO_ID_LPARAN_RPARAN :
                //<DeclaradorMetodo> ::= Id '(' <ParamList> ')'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_DECLARADORMETODO_ID_LPARAN_RPARAN2 :
                //<DeclaradorMetodo> ::= Id '(' ')'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_DECLARADORMETODO_LBRACKET_RBRACKET :
                //<DeclaradorMetodo> ::= <DeclaradorMetodo> '[' ']'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_PARAMLIST :
                //<ParamList> ::= <Tipo> <DeclaradorVariableId>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_PARAMLIST_COMMA :
                //<ParamList> ::= <ParamList> ',' <Tipo> <DeclaradorVariableId>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CARACTER_CHARINDIRECTO :
                //<Caracter> ::= CharIndirecto
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_CARACTER_STESCAPECHAR :
                //<Caracter> ::= StEscapeChar
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_CARACTER_OCTALESCAPECHAR :
                //<Caracter> ::= OctalEscapeChar
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_CARACTER_HEXESCAPECHAR :
                //<Caracter> ::= HexEscapeChar
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_NUMDECIMAL_NUMCERO :
                //<numdecimal> ::= NumCero
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_NUMDECIMAL_NUM :
                //<numdecimal> ::= Num
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_FLOAT_NUMFLOAT :
                //<float> ::= NumFloat
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_FLOAT_NUMFLOATEXP :
                //<float> ::= NumFloatExp
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_INT :
                //<Int> ::= <numdecimal>
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_INT_NUMHEX :
                //<Int> ::= NumHex
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_INT_NUMOCTAL :
                //<Int> ::= NumOctal
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_LITERAL :
                //<Literal> ::= <Int>
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_LITERAL2 :
                //<Literal> ::= <float>
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_LITERAL_BOOL :
                //<Literal> ::= Bool
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_LITERAL3 :
                //<Literal> ::= <Caracter>
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_LITERAL_STRING :
                //<Literal> ::= String
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_LITERAL_EXPRNULL :
                //<Literal> ::= ExprNull
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_TIPO :
                //<Tipo> ::= <TipoPrimitivo>
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_TIPO2 :
                //<Tipo> ::= <TipoReferencia>
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_TIPO3 :
                //<Tipo> ::= <TiposJava>
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_TIPOSJAVA_JLABEL :
                //<TiposJava> ::= JLabel
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_TIPOSJAVA_JBUTTON :
                //<TiposJava> ::= JButton
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_TIPOSJAVA_JCHECKBOX :
                //<TiposJava> ::= JCheckBox
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_TIPOSJAVA_JRADIOBUTTON :
                //<TiposJava> ::= JRadioButton
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_TIPOSJAVA_BUTTONGROUP :
                //<TiposJava> ::= ButtonGroup
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_TIPOSJAVA_JCOMBOBOX :
                //<TiposJava> ::= JComboBox
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_TIPOSJAVA_JTEXTFIELD :
                //<TiposJava> ::= JTextField
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_TIPOSJAVA_JTEXTAREA :
                //<TiposJava> ::= JTextArea
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_TIPOSJAVA_JPASSWORDFIELD :
                //<TiposJava> ::= JPasswordField
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_TIPOSJAVA_JTREE :
                //<TiposJava> ::= JTree
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_TIPOSJAVA_JTABLE :
                //<TiposJava> ::= JTable
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_TIPOSJAVA_JPANEL :
                //<TiposJava> ::= JPanel
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_TIPOSJAVA_JFILECHOOSER :
                //<TiposJava> ::= JFileChooser
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_TIPOPRIMITIVO :
                //<TipoPrimitivo> ::= <TipoNumerico>
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_TIPOPRIMITIVO_BOOLEAN :
                //<TipoPrimitivo> ::= boolean
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_TIPONUMERICO :
                //<TipoNumerico> ::= <TipoInt>
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_TIPONUMERICO2 :
                //<TipoNumerico> ::= <TipoFlotante>
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_TIPOINT_BYTE :
                //<TipoInt> ::= byte
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_TIPOINT_SHORT :
                //<TipoInt> ::= short
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_TIPOINT_INT :
                //<TipoInt> ::= int
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_TIPOINT_LONG :
                //<TipoInt> ::= long
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_TIPOINT_CHAR :
                //<TipoInt> ::= char
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_TIPOFLOTANTE_FLOAT :
                //<TipoFlotante> ::= float
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_TIPOFLOTANTE_DOUBLE :
                //<TipoFlotante> ::= double
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_TIPOREFERENCIA :
                //<TipoReferencia> ::= <Nombre>
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_TIPOREFERENCIA2 :
                //<TipoReferencia> ::= <TipoArray>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_TIPOARRAY_LBRACKET_RBRACKET :
                //<TipoArray> ::= <TipoPrimitivo> '[' ']'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_TIPOARRAY_LBRACKET_RBRACKET2 :
                //<TipoArray> ::= <Nombre> '[' ']'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_TIPOARRAY_LBRACKET_RBRACKET3 :
                //<TipoArray> ::= <TipoArray> '[' ']'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_NOMBRE :
                //<Nombre> ::= <NombreSimple>
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_NOMBRE2 :
                //<Nombre> ::= <NombreClasificado>
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_NOMBRESIMPLE_ID :
                //<NombreSimple> ::= Id
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_NOMBRECLASIFICADO_DOT_ID :
                //<NombreClasificado> ::= <Nombre> '.' Id
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString() + "." + token.Tokens[2].UserObject.ToString();

                case (int)RuleConstants.RULE_THROWS_THROWS :
                //<Throws> ::= throws <ListaTipoClase>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LISTATIPOCLASE :
                //<ListaTipoClase> ::= <Nombre>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LISTATIPOCLASE_COMMA :
                //<ListaTipoClase> ::= <ListaTipoClase> ',' <Nombre>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CUERPOMETODO :
                //<CuerpoMetodo> ::= <Block>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CUERPOMETODO_SEMI :
                //<CuerpoMetodo> ::= ';'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_DECLARACIONCONSTRUCTOR :
                //<DeclaracionConstructor> ::= <Modificador> <ConstructorDeclarator> <Throws> <CuerpoConstructor>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_DECLARACIONCONSTRUCTOR2 :
                //<DeclaracionConstructor> ::= <Modificador> <ConstructorDeclarator> <CuerpoConstructor>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_DECLARACIONCONSTRUCTOR3 :
                //<DeclaracionConstructor> ::= <ConstructorDeclarator> <Throws> <CuerpoConstructor>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_DECLARACIONCONSTRUCTOR4 :
                //<DeclaracionConstructor> ::= <ConstructorDeclarator> <CuerpoConstructor>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CONSTRUCTORDECLARATOR_LPARAN_RPARAN :
                //<ConstructorDeclarator> ::= <NombreSimple> '(' <ParamList> ')'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CONSTRUCTORDECLARATOR_LPARAN_RPARAN2 :
                //<ConstructorDeclarator> ::= <NombreSimple> '(' ')'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CUERPOCONSTRUCTOR_LBRACE_RBRACE :
                //<CuerpoConstructor> ::= '{' <InvoExplicitaConstructor> <BlockSentencias> '}'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CUERPOCONSTRUCTOR_LBRACE_RBRACE2 :
                //<CuerpoConstructor> ::= '{' <InvoExplicitaConstructor> '}'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CUERPOCONSTRUCTOR_LBRACE_RBRACE3 :
                //<CuerpoConstructor> ::= '{' <BlockSentencias> '}'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CUERPOCONSTRUCTOR_LBRACE_RBRACE4 :
                //<CuerpoConstructor> ::= '{' '}'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_INVOEXPLICITACONSTRUCTOR_THIS_LPARAN_RPARAN_SEMI :
                //<InvoExplicitaConstructor> ::= this '(' <ListaArgumento> ')' ';'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_INVOEXPLICITACONSTRUCTOR_THIS_LPARAN_RPARAN_SEMI2 :
                //<InvoExplicitaConstructor> ::= this '(' ')' ';'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_INVOEXPLICITACONSTRUCTOR_SUPER_LPARAN_RPARAN_SEMI :
                //<InvoExplicitaConstructor> ::= super '(' <ListaArgumento> ')' ';'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_INVOEXPLICITACONSTRUCTOR_SUPER_LPARAN_RPARAN_SEMI2 :
                //<InvoExplicitaConstructor> ::= super '(' ')' ';'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_DECLARACIONINTERFAZ_INTERFACE_ID :
                //<DeclaracionInterfaz> ::= <Modificador> interface Id <ExtendsInterfaces> <CuerpoInterfaz>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_DECLARACIONINTERFAZ_INTERFACE_ID2 :
                //<DeclaracionInterfaz> ::= <Modificador> interface Id <CuerpoInterfaz>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_DECLARACIONINTERFAZ_INTERFACE_ID3 :
                //<DeclaracionInterfaz> ::= interface Id <ExtendsInterfaces> <CuerpoInterfaz>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_DECLARACIONINTERFAZ_INTERFACE_ID4 :
                //<DeclaracionInterfaz> ::= interface Id <CuerpoInterfaz>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EXTENDSINTERFACES_EXTENDS :
                //<ExtendsInterfaces> ::= extends <Nombre>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EXTENDSINTERFACES_COMMA :
                //<ExtendsInterfaces> ::= <ExtendsInterfaces> ',' <Nombre>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CUERPOINTERFAZ_LBRACE_RBRACE :
                //<CuerpoInterfaz> ::= '{' <DeclaracionesMiembroInterfaz> '}'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CUERPOINTERFAZ_LBRACE_RBRACE2 :
                //<CuerpoInterfaz> ::= '{' '}'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_DECLARACIONESMIEMBROINTERFAZ :
                //<DeclaracionesMiembroInterfaz> ::= <DeclaracionMiembroInterfaz>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_DECLARACIONESMIEMBROINTERFAZ2 :
                //<DeclaracionesMiembroInterfaz> ::= <DeclaracionesMiembroInterfaz> <DeclaracionMiembroInterfaz>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_DECLARACIONMIEMBROINTERFAZ :
                //<DeclaracionMiembroInterfaz> ::= <DeclaracionCampo>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_DECLARACIONMIEMBROINTERFAZ2 :
                //<DeclaracionMiembroInterfaz> ::= <DeclaracionMetodoAbstracto>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_DECLARACIONMETODOABSTRACTO_SEMI :
                //<DeclaracionMetodoAbstracto> ::= <CabeceraMetodo> ';'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ARRAYINI_LBRACE_COMMA_RBRACE :
                //<ArrayIni> ::= '{' <VariableInis> ',' '}'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ARRAYINI_LBRACE_RBRACE :
                //<ArrayIni> ::= '{' <VariableInis> '}'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ARRAYINI_LBRACE_COMMA_RBRACE2 :
                //<ArrayIni> ::= '{' ',' '}'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ARRAYINI_LBRACE_RBRACE2 :
                //<ArrayIni> ::= '{' '}'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_VARIABLEINIS :
                //<VariableInis> ::= <VariableIni>
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_VARIABLEINIS_COMMA :
                //<VariableInis> ::= <VariableInis> ',' <VariableIni>
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString() + "," + token.Tokens[2].UserObject.ToString();

                case (int)RuleConstants.RULE_BLOCK_LBRACE_RBRACE :
                //<Block> ::= '{' <BlockSentencias> '}'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_BLOCK_LBRACE_RBRACE2 :
                //<Block> ::= '{' '}'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_BLOCKSENTENCIAS :
                //<BlockSentencias> ::= <BlockSentencia>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_BLOCKSENTENCIAS2 :
                //<BlockSentencias> ::= <BlockSentencias> <BlockSentencia>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_BLOCKSENTENCIA_SEMI :
                //<BlockSentencia> ::= <Tipo> <DeclaradoresVariable> ';'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_BLOCKSENTENCIA :
                //<BlockSentencia> ::= <Sentencia>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIA :
                //<Sentencia> ::= <SentenciaSinSubsentencia>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIA_ID_COLON :
                //<Sentencia> ::= Id ':' <Sentencia>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIA_IF_LPARAN_RPARAN :
                //<Sentencia> ::= if '(' <ExpresionAsigna> ')' <Sentencia>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIA_IF_LPARAN_RPARAN_ELSE :
                //<Sentencia> ::= if '(' <ExpresionAsigna> ')' <SentenciaIfExtendido> else <Sentencia>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIA_WHILE_LPARAN_RPARAN :
                //<Sentencia> ::= while '(' <ExpresionAsigna> ')' <Sentencia>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIA2 :
                //<Sentencia> ::= <ForSentencia>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIAIFEXTENDIDO :
                //<SentenciaIfExtendido> ::= <SentenciaSinSubsentencia>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIAIFEXTENDIDO_ID_COLON :
                //<SentenciaIfExtendido> ::= Id ':' <SentenciaIfExtendido>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIAIFEXTENDIDO_IF_LPARAN_RPARAN_ELSE :
                //<SentenciaIfExtendido> ::= if '(' <ExpresionAsigna> ')' <SentenciaIfExtendido> else <SentenciaIfExtendido>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIAIFEXTENDIDO_WHILE_LPARAN_RPARAN :
                //<SentenciaIfExtendido> ::= while '(' <ExpresionAsigna> ')' <SentenciaIfExtendido>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIAIFEXTENDIDO2 :
                //<SentenciaIfExtendido> ::= <ForSentenciaIfExtendido>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIASINSUBSENTENCIA :
                //<SentenciaSinSubsentencia> ::= <Block>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIASINSUBSENTENCIA_SEMI :
                //<SentenciaSinSubsentencia> ::= ';'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIASINSUBSENTENCIA_SEMI2 :
                //<SentenciaSinSubsentencia> ::= <SentenciaExpresion> ';'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIASINSUBSENTENCIA_SWITCH_LPARAN_RPARAN :
                //<SentenciaSinSubsentencia> ::= switch '(' <ExpresionAsigna> ')' <SwitchBlock>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIASINSUBSENTENCIA_DO_WHILE_LPARAN_RPARAN_SEMI :
                //<SentenciaSinSubsentencia> ::= do <Sentencia> while '(' <ExpresionAsigna> ')' ';'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIASINSUBSENTENCIA2 :
                //<SentenciaSinSubsentencia> ::= <BreakSentencia>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIASINSUBSENTENCIA3 :
                //<SentenciaSinSubsentencia> ::= <ContinueSentencia>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIASINSUBSENTENCIA4 :
                //<SentenciaSinSubsentencia> ::= <ReturnSentencia>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIASINSUBSENTENCIA_SYNCHRONIZED_LPARAN_RPARAN :
                //<SentenciaSinSubsentencia> ::= synchronized '(' <ExpresionAsigna> ')' <Block>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIASINSUBSENTENCIA_THROW_SEMI :
                //<SentenciaSinSubsentencia> ::= throw <ExpresionAsigna> ';'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIASINSUBSENTENCIA5 :
                //<SentenciaSinSubsentencia> ::= <TrySentencia>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIAEXPRESION :
                //<SentenciaExpresion> ::= <LeftSide> <OperadorAsignacion> <ExpresionAsigna>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIAEXPRESION_PLUSPLUS :
                //<SentenciaExpresion> ::= '++' <UnarioExpresion>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIAEXPRESION_MINUSMINUS :
                //<SentenciaExpresion> ::= -- <UnarioExpresion>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIAEXPRESION_PLUSPLUS2 :
                //<SentenciaExpresion> ::= <PosfijoExpresion> '++'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIAEXPRESION_MINUSMINUS2 :
                //<SentenciaExpresion> ::= <PosfijoExpresion> --
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIAEXPRESION2 :
                //<SentenciaExpresion> ::= <InvocacionMetodo>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SENTENCIAEXPRESION3 :
                //<SentenciaExpresion> ::= <CreacionInstancia>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SWITCHBLOCK_LBRACE_RBRACE :
                //<SwitchBlock> ::= '{' <GruposSwitch> <SwitchLabels> '}'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SWITCHBLOCK_LBRACE_RBRACE2 :
                //<SwitchBlock> ::= '{' <GruposSwitch> '}'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SWITCHBLOCK_LBRACE_RBRACE3 :
                //<SwitchBlock> ::= '{' <SwitchLabels> '}'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SWITCHBLOCK_LBRACE_RBRACE4 :
                //<SwitchBlock> ::= '{' '}'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_GRUPOSSWITCH :
                //<GruposSwitch> ::= <SwitchLabels> <BlockSentencias>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_GRUPOSSWITCH2 :
                //<GruposSwitch> ::= <GruposSwitch> <SwitchLabels> <BlockSentencias>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SWITCHLABELS :
                //<SwitchLabels> ::= <SwitchLabel>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SWITCHLABELS2 :
                //<SwitchLabels> ::= <SwitchLabels> <SwitchLabel>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SWITCHLABEL_CASE_COLON :
                //<SwitchLabel> ::= case <ExpresionAsigna> ':'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_SWITCHLABEL_DEFAULT_COLON :
                //<SwitchLabel> ::= default ':'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FORSENTENCIA_FOR_LPARAN_SEMI_SEMI_RPARAN :
                //<ForSentencia> ::= for '(' <InicializarFor> ';' <ExpresionAsigna> ';' <ForActualizar> ')' <Sentencia>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FORSENTENCIA_FOR_LPARAN_SEMI_SEMI_RPARAN2 :
                //<ForSentencia> ::= for '(' <InicializarFor> ';' <ExpresionAsigna> ';' ')' <Sentencia>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FORSENTENCIA_FOR_LPARAN_SEMI_SEMI_RPARAN3 :
                //<ForSentencia> ::= for '(' <InicializarFor> ';' ';' <ForActualizar> ')' <Sentencia>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FORSENTENCIA_FOR_LPARAN_SEMI_SEMI_RPARAN4 :
                //<ForSentencia> ::= for '(' <InicializarFor> ';' ';' ')' <Sentencia>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FORSENTENCIA_FOR_LPARAN_SEMI_SEMI_RPARAN5 :
                //<ForSentencia> ::= for '(' ';' <ExpresionAsigna> ';' <ForActualizar> ')' <Sentencia>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FORSENTENCIA_FOR_LPARAN_SEMI_SEMI_RPARAN6 :
                //<ForSentencia> ::= for '(' ';' <ExpresionAsigna> ';' ')' <Sentencia>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FORSENTENCIA_FOR_LPARAN_SEMI_SEMI_RPARAN7 :
                //<ForSentencia> ::= for '(' ';' ';' <ForActualizar> ')' <Sentencia>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FORSENTENCIA_FOR_LPARAN_SEMI_SEMI_RPARAN8 :
                //<ForSentencia> ::= for '(' ';' ';' ')' <Sentencia>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FORSENTENCIAIFEXTENDIDO_FOR_LPARAN_SEMI_SEMI_RPARAN :
                //<ForSentenciaIfExtendido> ::= for '(' <InicializarFor> ';' <ExpresionAsigna> ';' <ForActualizar> ')' <SentenciaIfExtendido>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FORSENTENCIAIFEXTENDIDO_FOR_LPARAN_SEMI_SEMI_RPARAN2 :
                //<ForSentenciaIfExtendido> ::= for '(' <InicializarFor> ';' <ExpresionAsigna> ';' ')' <SentenciaIfExtendido>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FORSENTENCIAIFEXTENDIDO_FOR_LPARAN_SEMI_SEMI_RPARAN3 :
                //<ForSentenciaIfExtendido> ::= for '(' <InicializarFor> ';' ';' <ForActualizar> ')' <SentenciaIfExtendido>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FORSENTENCIAIFEXTENDIDO_FOR_LPARAN_SEMI_SEMI_RPARAN4 :
                //<ForSentenciaIfExtendido> ::= for '(' <InicializarFor> ';' ';' ')' <SentenciaIfExtendido>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FORSENTENCIAIFEXTENDIDO_FOR_LPARAN_SEMI_SEMI_RPARAN5 :
                //<ForSentenciaIfExtendido> ::= for '(' ';' <ExpresionAsigna> ';' <ForActualizar> ')' <SentenciaIfExtendido>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FORSENTENCIAIFEXTENDIDO_FOR_LPARAN_SEMI_SEMI_RPARAN6 :
                //<ForSentenciaIfExtendido> ::= for '(' ';' <ExpresionAsigna> ';' ')' <SentenciaIfExtendido>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FORSENTENCIAIFEXTENDIDO_FOR_LPARAN_SEMI_SEMI_RPARAN7 :
                //<ForSentenciaIfExtendido> ::= for '(' ';' ';' <ForActualizar> ')' <SentenciaIfExtendido>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FORSENTENCIAIFEXTENDIDO_FOR_LPARAN_SEMI_SEMI_RPARAN8 :
                //<ForSentenciaIfExtendido> ::= for '(' ';' ';' ')' <SentenciaIfExtendido>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_INICIALIZARFOR :
                //<InicializarFor> ::= <ListadoSentenciaExpresion>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_INICIALIZARFOR2 :
                //<InicializarFor> ::= <Tipo> <DeclaradoresVariable>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_FORACTUALIZAR :
                //<ForActualizar> ::= <ListadoSentenciaExpresion>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LISTADOSENTENCIAEXPRESION :
                //<ListadoSentenciaExpresion> ::= <SentenciaExpresion>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LISTADOSENTENCIAEXPRESION_COMMA :
                //<ListadoSentenciaExpresion> ::= <ListadoSentenciaExpresion> ',' <SentenciaExpresion>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_PRIMARY :
                //<Primary> ::= <PrimaryNoNewArray>
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_PRIMARY2 :
                //<Primary> ::= <CreacionArray>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_PRIMARYNONEWARRAY :
                //<PrimaryNoNewArray> ::= <Literal>
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_PRIMARYNONEWARRAY_THIS :
                //<PrimaryNoNewArray> ::= this
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_PRIMARYNONEWARRAY_LPARAN_RPARAN :
                //<PrimaryNoNewArray> ::= '(' <ExpresionAsigna> ')'
                //todo: Create a new object using the stored user objects.
                    return "(" + token.Tokens[1].UserObject.ToString() + ")";

                case (int)RuleConstants.RULE_PRIMARYNONEWARRAY2 :
                //<PrimaryNoNewArray> ::= <CreacionInstancia>
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_PRIMARYNONEWARRAY3 :
                //<PrimaryNoNewArray> ::= <AccesoCampo>
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_PRIMARYNONEWARRAY4 :
                //<PrimaryNoNewArray> ::= <InvocacionMetodo>
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_PRIMARYNONEWARRAY5 :
                //<PrimaryNoNewArray> ::= <AccesoArray>
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_CREACIONINSTANCIA_NEW_LPARAN_RPARAN :
                //<CreacionInstancia> ::= new <Nombre> '(' <ListaArgumento> ')'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CREACIONINSTANCIA_NEW_LPARAN_RPARAN2 :
                //<CreacionInstancia> ::= new <Nombre> '(' ')'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LISTAARGUMENTO :
                //<ListaArgumento> ::= <ExpresionAsigna>
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_LISTAARGUMENTO_COMMA :
                //<ListaArgumento> ::= <ListaArgumento> ',' <ExpresionAsigna>
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString() + "," + token.Tokens[2].UserObject.ToString();

                case (int)RuleConstants.RULE_CREACIONARRAY_NEW :
                //<CreacionArray> ::= new <TipoPrimitivo> <ExprsCorchetes> <Corchetes>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CREACIONARRAY_NEW2 :
                //<CreacionArray> ::= new <TipoPrimitivo> <ExprsCorchetes>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CREACIONARRAY_NEW3 :
                //<CreacionArray> ::= new <Nombre> <ExprsCorchetes> <Corchetes>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CREACIONARRAY_NEW4 :
                //<CreacionArray> ::= new <Nombre> <ExprsCorchetes>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EXPRSCORCHETES :
                //<ExprsCorchetes> ::= <ExprCorchetes>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EXPRSCORCHETES2 :
                //<ExprsCorchetes> ::= <ExprsCorchetes> <ExprCorchetes>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EXPRCORCHETES_LBRACKET_RBRACKET :
                //<ExprCorchetes> ::= '[' <ExpresionAsigna> ']'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CORCHETES_LBRACKET_RBRACKET :
                //<Corchetes> ::= '[' ']'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CORCHETES_LBRACKET_RBRACKET2 :
                //<Corchetes> ::= <Corchetes> '[' ']'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ACCESOCAMPO_DOT_ID :
                //<AccesoCampo> ::= <Primary> '.' Id
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString() + "." + token.Tokens[2].UserObject.ToString();

                case (int)RuleConstants.RULE_ACCESOCAMPO_SUPER_DOT_ID :
                //<AccesoCampo> ::= super '.' Id
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString() + "." + token.Tokens[2].UserObject.ToString();

                case (int)RuleConstants.RULE_INVOCACIONMETODO_LPARAN_RPARAN :
                //<InvocacionMetodo> ::= <Nombre> '(' <ListaArgumento> ')'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_INVOCACIONMETODO_LPARAN_RPARAN2 :
                //<InvocacionMetodo> ::= <Nombre> '(' ')'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_INVOCACIONMETODO_DOT_ID_LPARAN_RPARAN :
                //<InvocacionMetodo> ::= <Primary> '.' Id '(' <ListaArgumento> ')'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_INVOCACIONMETODO_DOT_ID_LPARAN_RPARAN2 :
                //<InvocacionMetodo> ::= <Primary> '.' Id '(' ')'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_INVOCACIONMETODO_SUPER_DOT_ID_LPARAN_RPARAN :
                //<InvocacionMetodo> ::= super '.' Id '(' <ListaArgumento> ')'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_INVOCACIONMETODO_SUPER_DOT_ID_LPARAN_RPARAN2 :
                //<InvocacionMetodo> ::= super '.' Id '(' ')'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ACCESOARRAY_LBRACKET_RBRACKET :
                //<AccesoArray> ::= <Nombre> '[' <ExpresionAsigna> ']'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ACCESOARRAY_LBRACKET_RBRACKET2 :
                //<AccesoArray> ::= <PrimaryNoNewArray> '[' <ExpresionAsigna> ']'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CASTEXPRESION_LPARAN_RPARAN :
                //<CastExpresion> ::= '(' <TipoPrimitivo> <Corchetes> ')' <UnarioExpresion>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CASTEXPRESION_LPARAN_RPARAN2 :
                //<CastExpresion> ::= '(' <TipoPrimitivo> ')' <UnarioExpresion>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CASTEXPRESION_LPARAN_RPARAN3 :
                //<CastExpresion> ::= '(' <ExpresionAsigna> ')' <UnarioExpresionOtra>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CASTEXPRESION_LPARAN_RPARAN4 :
                //<CastExpresion> ::= '(' <Nombre> <Corchetes> ')' <UnarioExpresionOtra>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_MULTEXPRESION :
                //<MultExpresion> ::= <UnarioExpresion>
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_MULTEXPRESION_TIMES :
                //<MultExpresion> ::= <MultExpresion> '*' <UnarioExpresion>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_MULTEXPRESION_DIV :
                //<MultExpresion> ::= <MultExpresion> '/' <UnarioExpresion>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_MULTEXPRESION_PERCENT :
                //<MultExpresion> ::= <MultExpresion> '%' <UnarioExpresion>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ADDEXPRESION :
                //<AddExpresion> ::= <MultExpresion>
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_ADDEXPRESION_PLUS :
                //<AddExpresion> ::= <AddExpresion> '+' <MultExpresion>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ADDEXPRESION_MINUS :
                //<AddExpresion> ::= <AddExpresion> '-' <MultExpresion>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EXPRESIONCOMPARAR :
                //<ExpresionComparar> ::= <AddExpresion>
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_EXPRESIONCOMPARAR_LT :
                //<ExpresionComparar> ::= <ExpresionComparar> '<' <AddExpresion>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EXPRESIONCOMPARAR_GT :
                //<ExpresionComparar> ::= <ExpresionComparar> '>' <AddExpresion>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EXPRESIONCOMPARAR_LTEQ :
                //<ExpresionComparar> ::= <ExpresionComparar> '<=' <AddExpresion>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EXPRESIONCOMPARAR_GTEQ :
                //<ExpresionComparar> ::= <ExpresionComparar> '>=' <AddExpresion>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EXPRESIONCOMPARAR_INSTANCEOF :
                //<ExpresionComparar> ::= <ExpresionComparar> instanceof <TipoReferencia>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EXPRESIONIGUAL :
                //<ExpresionIgual> ::= <ExpresionComparar>
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_EXPRESIONIGUAL_EQEQ :
                //<ExpresionIgual> ::= <ExpresionIgual> '==' <ExpresionComparar>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EXPRESIONIGUAL_EXCLAMEQ :
                //<ExpresionIgual> ::= <ExpresionIgual> '!=' <ExpresionComparar>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ANDCONDICIONALEXPRESION :
                //<AndCondicionalExpresion> ::= <ExpresionIgual>
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_ANDCONDICIONALEXPRESION_AMPAMP :
                //<AndCondicionalExpresion> ::= <AndCondicionalExpresion> '&&' <ExpresionIgual>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_ORCONDICIONALEXPRESION :
                //<OrCondicionalExpresion> ::= <AndCondicionalExpresion>
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_ORCONDICIONALEXPRESION_PIPEPIPE :
                //<OrCondicionalExpresion> ::= <OrCondicionalExpresion> '||' <AndCondicionalExpresion>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_EXPRESIONCONDICIONAL :
                //<ExpresionCondicional> ::= <OrCondicionalExpresion>
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_EXPRESIONCONDICIONAL_QUESTION_COLON :
                //<ExpresionCondicional> ::= <OrCondicionalExpresion> '?' <ExpresionAsigna> ':' <ExpresionCondicional>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_POSFIJOEXPRESION :
                //<PosfijoExpresion> ::= <Primary>
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_POSFIJOEXPRESION2 :
                //<PosfijoExpresion> ::= <Nombre>
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_POSFIJOEXPRESION_PLUSPLUS :
                //<PosfijoExpresion> ::= <PosfijoExpresion> '++'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_POSFIJOEXPRESION_MINUSMINUS :
                //<PosfijoExpresion> ::= <PosfijoExpresion> --
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_UNARIOEXPRESION_PLUSPLUS :
                //<UnarioExpresion> ::= '++' <UnarioExpresion>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_UNARIOEXPRESION_MINUSMINUS :
                //<UnarioExpresion> ::= -- <UnarioExpresion>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_UNARIOEXPRESION_PLUS :
                //<UnarioExpresion> ::= '+' <UnarioExpresion>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_UNARIOEXPRESION_MINUS :
                //<UnarioExpresion> ::= '-' <UnarioExpresion>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_UNARIOEXPRESION :
                //<UnarioExpresion> ::= <UnarioExpresionOtra>
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_UNARIOEXPRESIONOTRA :
                //<UnarioExpresionOtra> ::= <PosfijoExpresion>
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_UNARIOEXPRESIONOTRA2 :
                //<UnarioExpresionOtra> ::= <CastExpresion>
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_EXPRESIONASIGNA :
                //<ExpresionAsigna> ::= <ExpresionCondicional>
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_EXPRESIONASIGNA2 :
                //<ExpresionAsigna> ::= <LeftSide> <OperadorAsignacion> <ExpresionAsigna>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_LEFTSIDE :
                //<LeftSide> ::= <Nombre>
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_LEFTSIDE2 :
                //<LeftSide> ::= <AccesoCampo>
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_LEFTSIDE3 :
                //<LeftSide> ::= <AccesoArray>
                //todo: Create a new object using the stored user objects.
                    return token.Tokens[0].UserObject.ToString();

                case (int)RuleConstants.RULE_OPERADORASIGNACION_EQ :
                //<OperadorAsignacion> ::= '='
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_OPERADORASIGNACION_TIMESEQ :
                //<OperadorAsignacion> ::= '*='
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_OPERADORASIGNACION_DIVEQ :
                //<OperadorAsignacion> ::= '/='
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_OPERADORASIGNACION_PERCENTEQ :
                //<OperadorAsignacion> ::= '%='
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_OPERADORASIGNACION_PLUSEQ :
                //<OperadorAsignacion> ::= '+='
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_OPERADORASIGNACION_MINUSEQ :
                //<OperadorAsignacion> ::= '-='
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CONTINUESENTENCIA_CONTINUE_ID_SEMI :
                //<ContinueSentencia> ::= continue Id ';'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CONTINUESENTENCIA_CONTINUE_SEMI :
                //<ContinueSentencia> ::= continue ';'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_RETURNSENTENCIA_RETURN_SEMI :
                //<ReturnSentencia> ::= return <ExpresionAsigna> ';'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_RETURNSENTENCIA_RETURN_SEMI2 :
                //<ReturnSentencia> ::= return ';'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_TRYSENTENCIA_TRY :
                //<TrySentencia> ::= try <Block> <Catches>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_TRYSENTENCIA_TRY_FINALLY :
                //<TrySentencia> ::= try <Block> <Catches> finally <Block>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_TRYSENTENCIA_TRY_FINALLY2 :
                //<TrySentencia> ::= try <Block> finally <Block>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CATCHES_CATCH_LPARAN_RPARAN :
                //<Catches> ::= catch '(' <Tipo> <DeclaradorVariableId> ')' <Block>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_CATCHES_CATCH_LPARAN_RPARAN2 :
                //<Catches> ::= <Catches> catch '(' <Tipo> <DeclaradorVariableId> ')' <Block>
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_BREAKSENTENCIA_BREAK_ID_SEMI :
                //<BreakSentencia> ::= break Id ';'
                //todo: Create a new object using the stored user objects.
                return null;

                case (int)RuleConstants.RULE_BREAKSENTENCIA_BREAK_SEMI :
                //<BreakSentencia> ::= break ';'
                //todo: Create a new object using the stored user objects.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void AcceptEvent(LALRParser parser, AcceptEventArgs args)
        {
            //todo: Use your fully reduced args.Token.UserObject
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '"+args.Token.ToString()+"'";
            MessageBox.Show(message);
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '"+args.UnexpectedToken.ToString()+"'";
            MessageBox.Show(message);
        }


    }
}
