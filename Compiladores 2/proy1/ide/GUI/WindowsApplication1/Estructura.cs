using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace WindowsApplication1
{
    class Estructura
    {
        /*dice si es int*/
        public Boolean isInteger(Object value)
        {
            try
            {
                int d = System.Int32.Parse(value.ToString(), System.Globalization.NumberStyles.None);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        /*dice si es fecha*/
        public Boolean isDate(Object value)
        {
            try
            {
                DateTime d = System.DateTime.Parse(value.ToString());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /*dice si es decimal*/
        public Boolean isDecimal(Object value)
        {
            try
            {
                double d = System.Double.Parse(value.ToString(), System.Globalization.NumberStyles.AllowDecimalPoint);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        /*retorna un string con el path arreglado*/
        public string reemplazarPath(string path)
        {
            return path.Replace("\\", "\\\\");
        }

/******************************************** estructuras ************************************************/
        [Serializable]
        public struct myJLabel
        {
            public string IdOriginal; //el primer id que tuvo. este nunca se cambia
            public int arrayIndice; //la posicion en el arraylist, se usa para asignar id: id= <nombre>+indice
            public string Id;
            public string FontColor;
            public int FontSize;
            public string Text;
            public string Image;
            public string Alignment;
            public int Type; //0(normal)|1|2|3 -> letra.. normal o titulo
            public string BackColor;
            public int Width;
            public int Height;
            public int Left;
            public int Top;
            public myJLabel(int arrayIndice, string Id, string FontColor, int FontSize, string Text, string Image, string Alignment, int Type, string BackColor, int Width, int Height, int Left, int Top)
            {
                IdOriginal = Id;
                this.arrayIndice = arrayIndice;
                this.Id = Id;
                this.FontColor = FontColor;
                this.FontSize = FontSize;
                this.Text = Text;
                this.Image = Image;
                this.Alignment = Alignment;
                this.Type = Type;
                this.BackColor = BackColor;
                this.Width = Width;
                this.Height = Height;
                this.Left = Left;
                this.Top = Top; 
            }
        }

        [Serializable]
        public struct myJButton
        {
            public string IdOriginal; //el primer id que tuvo. este nunca se cambia
            public int arrayIndice; //la posicion en el arraylist, se usa para asignar id: id= <nombre>+indice
            public string Id;
            public string Text;
            public string Alignment;
            public int Width;
            public int Height;
            public int Left;
            public int Top;
            public myJButton(int arrayIndice, string Id, string Text, string Alignment, int Width, int Height,int Left,int Top)
            {
                IdOriginal = Id;
                this.arrayIndice = arrayIndice;
                this.Id = Id;
                this.Text = Text;
                this.Alignment = Alignment;
                this.Width = Width;
                this.Height = Height;
                this.Left = Left;
                this.Top = Top;
            }
        }

        [Serializable]
        public struct myJCheckBox
        {
            public string IdOriginal; //el primer id que tuvo. este nunca se cambia
            public int arrayIndice; //la posicion en el arraylist, se usa para asignar id: id= <nombre>+indice
            public string Id;
            public string Text;
            public int Value; //marcada o no
            public string BackColor;
            public int Width;
            public int Height;
            public int Left;
            public int Top;
            public myJCheckBox(int arrayIndice, string Id, string Text, int Value, string BackColor, int Width, int Height, int Left, int Top)
            {
                IdOriginal = Id;
                this.arrayIndice = arrayIndice;
                this.Id = Id;
                this.Text = Text;
                this.Value = Value;
                this.BackColor = BackColor;
                this.Width = Width;
                this.Height = Height;
                this.Left = Left;
                this.Top = Top;
            }
        }

        [Serializable]
        public struct myJRadioButton
        {
            public string IdOriginal; //el primer id que tuvo. este nunca se cambia
            public int arrayIndice; //la posicion en el arraylist, se usa para asignar id: id= <nombre>+indice
            public string Id;
            public string Text;
            public int Value; //marcada o no
            public string BackColor;
            public int Width;
            public int Height;
            public int Left;
            public int Top;
            public myJRadioButton(int arrayIndice, string Id, string Text, int Value, string BackColor, int Width, int Height, int Left, int Top)
            {
                IdOriginal = Id;
                this.arrayIndice = arrayIndice;
                this.Id = Id;
                this.Text = Text;
                this.Value = Value;
                this.BackColor = BackColor;
                this.Width = Width;
                this.Height = Height;
                this.Left = Left;
                this.Top = Top;
            }
        }

        [Serializable]
        public struct myJButtonGroup
        {
            public string IdOriginal; //el primer id que tuvo. este nunca se cambia
            public int arrayIndice; //la posicion en el arraylist, se usa para asignar id: id= <nombre>+indice
            public string Id;
            public int Type; //0(radiobutton)|1(checkbox)
            public string Elements; //lista de id separado por comas. despues con split se mete en un array
            public int Width;
            public int Height;
            public int Left;
            public int Top;
            public myJButtonGroup(int arrayIndice, string Id, int Type, string Elements, int Width, int Height, int Left, int Top)
            {
                IdOriginal = Id;
                this.arrayIndice = arrayIndice;
                this.Id = Id;
                this.Type = Type;
                this.Elements = Elements;
                this.Width = Width;
                this.Height = Height;
                this.Left = Left;
                this.Top = Top;
            }
        }

        [Serializable]
        public struct myJComboBox
        {
            public string IdOriginal; //el primer id que tuvo. este nunca se cambia
            public int arrayIndice; //la posicion en el arraylist, se usa para asignar id: id= <nombre>+indice
            public string Id;
            public string Elements; //lista de elementos separado por comas. despues con split se mete en un array
            public int Width;
            public int Height;
            public int Left;
            public int Top;
            public myJComboBox(int arrayIndice, string Id, string Elements, int Width, int Height, int Left, int Top)
            {
                IdOriginal = Id;
                this.arrayIndice = arrayIndice;
                this.Id = Id;
                this.Elements = Elements;
                this.Width = Width;
                this.Height = Height;
                this.Left = Left;
                this.Top = Top;
            }
        }

        [Serializable]
        public struct myJTextField
        {
            public string IdOriginal; //el primer id que tuvo. este nunca se cambia
            public int arrayIndice; //la posicion en el arraylist, se usa para asignar id: id= <nombre>+indice
            public string Id;
            public string Text;
            public int Width;
            public int Height;
            public int isPassword; //1(passwordfield)|0(textfield)
            public int Left;
            public int Top;
            public myJTextField(int arrayIndice, string Id, string Text, int isPassword, int Width, int Height, int Left, int Top)
            {
                IdOriginal = Id;
                this.arrayIndice = arrayIndice;
                this.Id = Id;
                this.Text = Text;
                this.isPassword = isPassword;
                this.Width = Width;
                this.Height = Height;
                this.Left = Left;
                this.Top = Top;
            }
        }

        [Serializable]
        public struct myJTextArea
        {
            public string IdOriginal; //el primer id que tuvo. este nunca se cambia
            public int arrayIndice; //la posicion en el arraylist, se usa para asignar id: id= <nombre>+indice
            public string Id;
            public string Text;
            public int Width;
            public int Height;
            public int Left;
            public int Top;
            public myJTextArea(int arrayIndice, string Id, string Text, int Width, int Height, int Left, int Top)
            {
                IdOriginal = Id;
                this.arrayIndice = arrayIndice;
                this.Id = Id;
                this.Text = Text;
                this.Width = Width;
                this.Height = Height;
                this.Left = Left;
                this.Top = Top;
            }
        }

        [Serializable]
        public struct myJTree
        {
            public string IdOriginal; //el primer id que tuvo. este nunca se cambia
            public int arrayIndice; //la posicion en el arraylist, se usa para asignar id: id= <nombre>+indice
            public string Id;
            public myMutableTreeNode Model;
            public int Width;
            public int Height;
            public int Left;
            public int Top;
            public myJTree(int arrayIndice, string Id, myMutableTreeNode Model, int Width, int Height, int Left, int Top)
            {
                IdOriginal = Id;
                this.arrayIndice = arrayIndice;
                this.Id = Id;
                this.Model = Model;
                this.Width = Width;
                this.Height = Height;
                this.Left = Left;
                this.Top = Top;
            }
        }

        [Serializable]
        public struct myMutableTreeNode
        {
            public string IdOriginal; //el primer id que tuvo. este nunca se cambia
            public int Index;
            public string Name;
            public ArrayList Children;
            public myMutableTreeNode(int indice, string nombre, ArrayList hijos)
            {
                IdOriginal = nombre;
                Index = indice;
                Name = nombre;
                Children = hijos;
            }
        }

        [Serializable]
        public struct myJTable
        {
            public string IdOriginal; //el primer id que tuvo. este nunca se cambia
            public int arrayIndice; //la posicion en el arraylist, se usa para asignar id: id= <nombre>+indice
            public string Id;
            public ArrayList Data; //array contenido de arrays que tienen la info
            public int Width;
            public int Height;
            public int Left;
            public int Top;
            public myJTable(int arrayIndice, string Id, ArrayList Data, int Width, int Height, int Left, int Top)
            {
                IdOriginal = Id;
                this.arrayIndice = arrayIndice;
                this.Id = Id;
                this.Data = Data;
                this.Width = Width;
                this.Height = Height;
                this.Left = Left;
                this.Top = Top;
            }
        }

        [Serializable]
        public struct myJPanel
        {
            public string IdOriginal; //el primer id que tuvo. este nunca se cambia
            public int arrayIndice; //la posicion en el arraylist, se usa para asignar id: id= <nombre>+indice
            public string Id;
            public string Backcolor;
            public string Border;
            public string Margin;
            public string CompoundBorder;
            public bool RoundedCorners;
            public int Width;
            public int Height;
            public int Left;
            public int Top;
            public myJPanel(int arrayIndice, string Id, string Backcolor, string Border, string Margin,string CompoundBorder,bool RoundedCorners, int Width, int Height, int Left, int Top)
            {
                IdOriginal = Id;
                this.arrayIndice = arrayIndice;
                this.Id = Id;
                this.Backcolor = Backcolor;
                this.Border = Border;
                this.Margin = Margin;
                this.CompoundBorder = CompoundBorder;
                this.RoundedCorners = RoundedCorners;
                this.Width = Width;
                this.Height = Height;
                this.Left = Left;
                this.Top = Top;
            }
        }

        [Serializable]
        public struct myJFileChooser
        {
            public string IdOriginal; //el primer id que tuvo. este nunca se cambia
            public int arrayIndice; //la posicion en el arraylist, se usa para asignar id: id= <nombre>+indice
            public string Id;
            public int Width;
            public int Height;
            public ArrayList Filters;
            public int Left;
            public int Top;
            public myJFileChooser(int arrayIndice, string Id, ArrayList Filters, int Width, int Height, int Left, int Top)
            {
                IdOriginal = Id;
                this.arrayIndice = arrayIndice;
                this.Id = Id;
                this.Filters = Filters;
                this.Width = Width;
                this.Height = Height;
                this.Left = Left;
                this.Top = Top;
            }
        }
    }
}
