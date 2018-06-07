import java_cup.runtime.Symbol;
import java.io.*;
import java.lang.*;

%%

DIGIT=[0-9]
PALABRA=[^\"\t\n]+

%public
%ignorecase
%unicode
%cup
%line
%char

%%

";" {
return new Symbol(sym.PCOMA, new String(yytext()));
}

"EMPRESA>>" {
return new Symbol(sym.EMPRESA, new String(yytext()));
}

"TIPO_LICENCIA>>" {
return new Symbol(sym.LICENCIA, new String(yytext()));
}

"UNIDADES>>" {
return new Symbol(sym.UNIDADES, new String(yytext()));
}

"PRODUCTO>>" {
return new Symbol(sym.PRODUCTO, new String(yytext()));
}

"SIS_OP>>" {
return new Symbol(sym.SO, new String(yytext()));
}

"FECHA_INI>>" {
return new Symbol(sym.FINI, new String(yytext()));
}

"FECHAFIN>>" {
return new Symbol(sym.FFIN, new String(yytext()));
}

"DIRECCION>>" {
return new Symbol(sym.DIRECCION, new String(yytext()));
}

"SECTOR>>" {
return new Symbol(sym.SECTOR, new String(yytext()));
}

"AREA_PROD>>" {
return new Symbol(sym.AREA, new String(yytext()));
}

\" {
return new Symbol(sym.COMILLAS, new String(yytext()));
}

\t {
return new Symbol(sym.TAB, new String(yytext()));
}

[\ \n] {/*ignorar*/}

{DIGIT}+ {
return new Symbol(sym.NUM, new String(yytext()));
}

{PALABRA} {
return new Symbol(sym.PAL, new String(yytext()));
}

. {
System.out.println("Error lexico: "+yytext());
}

