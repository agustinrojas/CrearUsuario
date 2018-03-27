using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace Usuario
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Elije una opcion: ");
            Console.WriteLine("1- Crear un usuario: ");
            Console.WriteLine("2- Salir: ");
            int caseSwitch = int.Parse(Console.ReadLine());

            int id;
            string name;
            string surname;
            string dni;
            Guid guid;

            //recuperamos variable del app.config
            string config_string = ConfigurationManager.AppSettings["filetype"].ToString();
            string rutaFicheros = ConfigurationManager.AppSettings["rutaFichero"].ToString();


            switch (caseSwitch)
            {
                //caso crear usuario
                case 1:
                    //preguntar datos
                    Console.WriteLine("Introduce el identificador: ");
                    id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Introduce el nombre: ");
                    name = Console.ReadLine();
                    Console.WriteLine("Introduce los apellidos: ");
                    surname = Console.ReadLine();
                    Console.WriteLine("Introduce el DNI: ");
                    dni = Console.ReadLine();

                    guid = Guid.NewGuid(); 
                    

                    //preguntar o txt o JSON
                    Console.WriteLine("Elije una opcion: ");
                    Console.WriteLine("1- Guardar en TXT: ");
                    Console.WriteLine("2- Gurdar en JSON: ");
                    //esta linia es para mostrar la configuracion del fichero JSON
                    Console.WriteLine("En el app.config esta configurado: {0}", config_string);
                    int caseSwitch2 = int.Parse(Console.ReadLine());

                    

                    //Crear objeto clase alumno
                    ClaseAlumno miAlumno = new ClaseAlumno(id, name, surname, dni, guid);

                    
                    string guardarEnTxt = "Mi alumno: \n";

                    //acceder a todas las propiedades de la clase. Utilizando REFLECTION
                    Type myType = miAlumno.GetType();
                    IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
                    foreach (PropertyInfo prop in props)
                    {
                        object propValue = prop.GetValue(miAlumno, null);
                        guardarEnTxt = guardarEnTxt + prop.Name + ":" + propValue.ToString() + " ,";
                    }

                    //caso de txt o json
                    if (caseSwitch2 == 1)
                    {
                        //caso txt
                        //crear archivo
                        using (StreamWriter file = new System.IO.StreamWriter(rutaFicheros + "prueba_io.txt"))
                        {
                            //mostrar por pantalla
                            file.WriteLine(guardarEnTxt.Remove(guardarEnTxt.Length - 1));
                        }
                    }
                    else
                    {
                        //caso JSON, hemos agregado a referencias el System.Configuration, y el framework .NET JSON 4.0
                        //crear el documento en JSON
                        string json = JsonConvert.SerializeObject(miAlumno);

                        //write string to file
                        System.IO.File.WriteAllText(rutaFicheros + "prueba_JSON.txt", json);
                    }
                    break;

                case 2:
                    Console.WriteLine("Has salido");
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
        }

    }
}