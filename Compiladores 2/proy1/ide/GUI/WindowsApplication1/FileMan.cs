using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;


namespace WindowsApplication1
{
    public class FileMan
    {
        StreamWriter writer;
        String filename;
        
        IFormatter formatter = new BinaryFormatter(); //para leer/escribir archivos binarios
        FileStream fs; //flujo para archivos binarios
        string binFile; //archivo binario

/******************************************** Archivos Binarios ********************************************/
        //abre un flujo para escribir un archivo binario
        public void binOpen(string file)
        {
            binFile = file;
            borrarArchivo(file);
            fs = new FileStream(file, FileMode.Append);
        }
        
        //escribe un ArrayList a un archivo binario
        public void binWrite(ArrayList data)
        {
            formatter.Serialize(fs, data);
        }

        //cierra el flujo abierto y hace copia de respaldo del archivo escrito
        public void binClose()
        {
            fs.Close();
            File.Copy(binFile, binFile + ".bak", true);
        }

        //lee un archivo binario que contiene uno o mas ArrayList y los devuelve en un IEnumerator
        public IEnumerator binRead(string file)
        {
            ArrayList data = new ArrayList();
            fs = new FileStream(file, FileMode.Open);
            try
            {
                while (true)
                {
                    ArrayList tmp_data = (ArrayList)formatter.Deserialize(fs);
                    data.Add(tmp_data);
                }
            }
            catch { }
            fs.Close();
            return data.GetEnumerator();
        }
/**************************************************************************************************************/        

        //crea una carpeta; si la carpeta ya existe no hace nada
        public void crearCarpeta(String nombre)
        {
            DirectoryInfo DIR = new DirectoryInfo(nombre);
            if (!DIR.Exists)
            {
                DIR.Create();
            }
        }

        //dice si existe o no una carpeta
        public Boolean existeCarpeta(String nombre)
        {
            DirectoryInfo DIR = new DirectoryInfo(nombre);
            return DIR.Exists;
        }

        //dice si existe o no un archivo
        public Boolean existeArchivo(String nombre)
        {
            return File.Exists(nombre);
        }

        //abre con append o crea archivo
        public void abrir(String filename)
        {
            this.filename = filename;
            writer = File.AppendText(filename);
        }

        //borra un archivo si existe
        public void borrarArchivo(String filename)
        {
            if(existeArchivo(filename)) File.Delete(filename);
        }

        //retorna en un string el archivo entero
        public String leerTodo(String archivo)
        {
            String tmp;
            StreamReader reader = new StreamReader(new FileStream(archivo, FileMode.Open, FileAccess.Read));
            tmp = reader.ReadToEnd();
            reader.Close();
            return tmp;
        }

        //cierra un archivo abierto
        public void cerrar()
        {
            writer.Close();
            filename = "";
        }

        //escribe en un archivo abierto un String
        public void escribir(String texto)
        {
            writer.Write(texto);
        }

        //escribe en un archivo abierto una linea
        public void escribirLinea(String linea)
        {
            writer.WriteLine(linea);
        }
    }
}
