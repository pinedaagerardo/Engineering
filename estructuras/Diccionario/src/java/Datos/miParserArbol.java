package Datos;


//----------------------------------------------------
// The following code was generated by CUP v0.10k
// Thu May 01 01:38:59 CST 2008
//----------------------------------------------------

import java_cup.runtime.*;
import java.io.*;
import javax.swing.*;
import java.util.*;

/** CUP v0.10k generated parser.
  * @version Thu May 01 01:38:59 CST 2008
  */
public class miParserArbol extends java_cup.runtime.lr_parser {

  /** Default constructor. */
  public miParserArbol() {super();}

  /** Constructor which sets the default scanner. */
  public miParserArbol(java_cup.runtime.Scanner s) {super(s);}

  /** Production table. */
  protected static final short _production_table[][] = 
    unpackFromStrings(new String[] {
    "\000\006\000\002\002\004\000\002\003\004\000\002\003" +
    "\003\000\002\004\010\000\002\004\006\000\002\004\004" +
    "" });

  /** Access to production table. */
  public short[][] production_table() {return _production_table;}

  /** Parse-action table. */
  protected static final short[][] _action_table = 
    unpackFromStrings(new String[] {
    "\000\015\000\004\006\004\001\002\000\006\004\011\005" +
    "\012\001\002\000\004\002\010\001\002\000\006\002\uffff" +
    "\006\004\001\002\000\004\002\000\001\002\000\004\002" +
    "\001\001\002\000\004\006\013\001\002\000\006\002\ufffc" +
    "\006\ufffc\001\002\000\006\004\014\005\015\001\002\000" +
    "\004\006\016\001\002\000\006\002\ufffd\006\ufffd\001\002" +
    "\000\004\005\017\001\002\000\006\002\ufffe\006\ufffe\001" +
    "\002" });

  /** Access to parse-action table. */
  public short[][] action_table() {return _action_table;}

  /** <code>reduce_goto</code> table. */
  protected static final short[][] _reduce_table = 
    unpackFromStrings(new String[] {
    "\000\015\000\006\003\004\004\005\001\001\000\002\001" +
    "\001\000\002\001\001\000\006\003\006\004\005\001\001" +
    "\000\002\001\001\000\002\001\001\000\002\001\001\000" +
    "\002\001\001\000\002\001\001\000\002\001\001\000\002" +
    "\001\001\000\002\001\001\000\002\001\001" });

  /** Access to <code>reduce_goto</code> table. */
  public short[][] reduce_table() {return _reduce_table;}

  /** Instance of action encapsulation class. */
  protected CUP$miParserArbol$actions action_obj;

  /** Action encapsulation object initializer. */
  protected void init_actions()
    {
      action_obj = new CUP$miParserArbol$actions(this);
    }

  /** Invoke a user supplied parse action. */
  public java_cup.runtime.Symbol do_action(
    int                        act_num,
    java_cup.runtime.lr_parser parser,
    java.util.Stack            stack,
    int                        top)
    throws java.lang.Exception
  {
    /* call code in generated class */
    return action_obj.CUP$miParserArbol$do_action(act_num, parser, stack, top);
  }

  /** Indicates start state. */
  public int start_state() {return 0;}
  /** Indicates start production. */
  public int start_production() {return 0;}

  /** <code>EOF</code> Symbol index. */
  public int EOF_sym() {return 0;}

  /** <code>error</code> Symbol index. */
  public int error_sym() {return 1;}



	public static void main(String args[]) throws Exception{
		new miParserArbol(new miScannerArbol(new FileInputStream(args[0]))).parse();
		
	}

	public void syntax_error(Symbol s){
		TokenValue tok=(TokenValue)s.value;
		System.out.println("Error sintactico. Simbolo: "+tok.getLexema());
		//JOptionPane.showMessageDialog(new JFrame(),"Error sintactico. Simbolo: "+tok.getLexema(),"Error sintactico",JOptionPane.ERROR_MESSAGE);
	}

	public void unrecovered_syntax_error(Symbol s) throws java.lang.Exception{
		TokenValue tok=(TokenValue)s.value;
		System.out.println("Error sin recuperacion. Simbolo: "+tok.getLexema());
		//JOptionPane.showMessageDialog(new JFrame(),"Error sin recuperacion. Simbolo: "+tok.getLexema(),"Error sin recuperacion",JOptionPane.ERROR_MESSAGE);
	}



}

/** Cup generated class to encapsulate user supplied action code.*/
class CUP$miParserArbol$actions {


public Vector Vpalabra=new Vector();
public Vector Vtraduccion=new Vector();
public Vector Vimagen=new Vector();

  private final miParserArbol parser;

  /** Constructor */
  CUP$miParserArbol$actions(miParserArbol parser) {
    this.parser = parser;
  }

  /** Method with the actual generated action code. */
  public final java_cup.runtime.Symbol CUP$miParserArbol$do_action(
    int                        CUP$miParserArbol$act_num,
    java_cup.runtime.lr_parser CUP$miParserArbol$parser,
    java.util.Stack            CUP$miParserArbol$stack,
    int                        CUP$miParserArbol$top)
    throws java.lang.Exception
    {
      /* Symbol object for return from actions */
      java_cup.runtime.Symbol CUP$miParserArbol$result;

      /* select the action based on the action number */
      switch (CUP$miParserArbol$act_num)
        {
          /*. . . . . . . . . . . . . . . . . . . .*/
          case 5: // expresion ::= ALFANUMERICO PCOMA 
            {
              Object RESULT = null;
		int palleft = ((java_cup.runtime.Symbol)CUP$miParserArbol$stack.elementAt(CUP$miParserArbol$top-1)).left;
		int palright = ((java_cup.runtime.Symbol)CUP$miParserArbol$stack.elementAt(CUP$miParserArbol$top-1)).right;
		TokenValue pal = (TokenValue)((java_cup.runtime.Symbol) CUP$miParserArbol$stack.elementAt(CUP$miParserArbol$top-1)).value;
		
Vpalabra.addElement(pal.getLexema());
Vtraduccion.addElement(" ");
Vimagen.addElement(" ");

              CUP$miParserArbol$result = new java_cup.runtime.Symbol(2/*expresion*/, ((java_cup.runtime.Symbol)CUP$miParserArbol$stack.elementAt(CUP$miParserArbol$top-1)).left, ((java_cup.runtime.Symbol)CUP$miParserArbol$stack.elementAt(CUP$miParserArbol$top-0)).right, RESULT);
            }
          return CUP$miParserArbol$result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 4: // expresion ::= ALFANUMERICO COMA ALFANUMERICO PCOMA 
            {
              Object RESULT = null;
		int palleft = ((java_cup.runtime.Symbol)CUP$miParserArbol$stack.elementAt(CUP$miParserArbol$top-3)).left;
		int palright = ((java_cup.runtime.Symbol)CUP$miParserArbol$stack.elementAt(CUP$miParserArbol$top-3)).right;
		TokenValue pal = (TokenValue)((java_cup.runtime.Symbol) CUP$miParserArbol$stack.elementAt(CUP$miParserArbol$top-3)).value;
		int tradleft = ((java_cup.runtime.Symbol)CUP$miParserArbol$stack.elementAt(CUP$miParserArbol$top-1)).left;
		int tradright = ((java_cup.runtime.Symbol)CUP$miParserArbol$stack.elementAt(CUP$miParserArbol$top-1)).right;
		TokenValue trad = (TokenValue)((java_cup.runtime.Symbol) CUP$miParserArbol$stack.elementAt(CUP$miParserArbol$top-1)).value;
		
Vpalabra.addElement(pal.getLexema());
Vtraduccion.addElement(trad.getLexema());
Vimagen.addElement(" ");

              CUP$miParserArbol$result = new java_cup.runtime.Symbol(2/*expresion*/, ((java_cup.runtime.Symbol)CUP$miParserArbol$stack.elementAt(CUP$miParserArbol$top-3)).left, ((java_cup.runtime.Symbol)CUP$miParserArbol$stack.elementAt(CUP$miParserArbol$top-0)).right, RESULT);
            }
          return CUP$miParserArbol$result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 3: // expresion ::= ALFANUMERICO COMA ALFANUMERICO COMA ALFANUMERICO PCOMA 
            {
              Object RESULT = null;
		int palleft = ((java_cup.runtime.Symbol)CUP$miParserArbol$stack.elementAt(CUP$miParserArbol$top-5)).left;
		int palright = ((java_cup.runtime.Symbol)CUP$miParserArbol$stack.elementAt(CUP$miParserArbol$top-5)).right;
		TokenValue pal = (TokenValue)((java_cup.runtime.Symbol) CUP$miParserArbol$stack.elementAt(CUP$miParserArbol$top-5)).value;
		int tradleft = ((java_cup.runtime.Symbol)CUP$miParserArbol$stack.elementAt(CUP$miParserArbol$top-3)).left;
		int tradright = ((java_cup.runtime.Symbol)CUP$miParserArbol$stack.elementAt(CUP$miParserArbol$top-3)).right;
		TokenValue trad = (TokenValue)((java_cup.runtime.Symbol) CUP$miParserArbol$stack.elementAt(CUP$miParserArbol$top-3)).value;
		int imgleft = ((java_cup.runtime.Symbol)CUP$miParserArbol$stack.elementAt(CUP$miParserArbol$top-1)).left;
		int imgright = ((java_cup.runtime.Symbol)CUP$miParserArbol$stack.elementAt(CUP$miParserArbol$top-1)).right;
		TokenValue img = (TokenValue)((java_cup.runtime.Symbol) CUP$miParserArbol$stack.elementAt(CUP$miParserArbol$top-1)).value;
		
Vpalabra.addElement(pal.getLexema());
Vtraduccion.addElement(trad.getLexema());
Vimagen.addElement(img.getLexema());

              CUP$miParserArbol$result = new java_cup.runtime.Symbol(2/*expresion*/, ((java_cup.runtime.Symbol)CUP$miParserArbol$stack.elementAt(CUP$miParserArbol$top-5)).left, ((java_cup.runtime.Symbol)CUP$miParserArbol$stack.elementAt(CUP$miParserArbol$top-0)).right, RESULT);
            }
          return CUP$miParserArbol$result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 2: // inicio ::= expresion 
            {
              Object RESULT = null;
		
              CUP$miParserArbol$result = new java_cup.runtime.Symbol(1/*inicio*/, ((java_cup.runtime.Symbol)CUP$miParserArbol$stack.elementAt(CUP$miParserArbol$top-0)).left, ((java_cup.runtime.Symbol)CUP$miParserArbol$stack.elementAt(CUP$miParserArbol$top-0)).right, RESULT);
            }
          return CUP$miParserArbol$result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 1: // inicio ::= expresion inicio 
            {
              Object RESULT = null;
		
              CUP$miParserArbol$result = new java_cup.runtime.Symbol(1/*inicio*/, ((java_cup.runtime.Symbol)CUP$miParserArbol$stack.elementAt(CUP$miParserArbol$top-1)).left, ((java_cup.runtime.Symbol)CUP$miParserArbol$stack.elementAt(CUP$miParserArbol$top-0)).right, RESULT);
            }
          return CUP$miParserArbol$result;

          /*. . . . . . . . . . . . . . . . . . . .*/
          case 0: // $START ::= inicio EOF 
            {
              Object RESULT = null;
		int start_valleft = ((java_cup.runtime.Symbol)CUP$miParserArbol$stack.elementAt(CUP$miParserArbol$top-1)).left;
		int start_valright = ((java_cup.runtime.Symbol)CUP$miParserArbol$stack.elementAt(CUP$miParserArbol$top-1)).right;
		Object start_val = (Object)((java_cup.runtime.Symbol) CUP$miParserArbol$stack.elementAt(CUP$miParserArbol$top-1)).value;
		RESULT = start_val;
              CUP$miParserArbol$result = new java_cup.runtime.Symbol(0/*$START*/, ((java_cup.runtime.Symbol)CUP$miParserArbol$stack.elementAt(CUP$miParserArbol$top-1)).left, ((java_cup.runtime.Symbol)CUP$miParserArbol$stack.elementAt(CUP$miParserArbol$top-0)).right, RESULT);
            }
          /* ACCEPT */
          CUP$miParserArbol$parser.done_parsing();
          return CUP$miParserArbol$result;

          /* . . . . . .*/
          default:
            throw new Exception(
               "Invalid action number found in internal parse table");

        }
    }
}
