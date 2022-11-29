using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    internal static class Reflector
    {
        static string Path = "D:\\Курс2\\ООП\\Lab11\\Lab11\\a.txt";
      
        static Reflector()
        {
            using (StreamWriter sw = new StreamWriter(Path, false)) ;
        }
        public static void GetName(Type type)
        {
            Console.WriteLine(type.Assembly);
            InFile(type.Assembly);
        }

        public static bool PubCtor(Type type)
        {
            foreach  (ConstructorInfo ctor in type.GetConstructors())
            {
                if (ctor.IsPublic)
                {   
                    InFile(true);
                    return true;
                }
            }
            InFile(false);
            return false;
        }

        public static IEnumerable<string> PubMet(Type type)
        {
            List<string> list = new List<string>();
            foreach (MethodInfo method in type.GetMethods())
            {
                if (method.IsPublic)
                {
                    list.Add(method.Name);
                    InFile(method.Name);
                }
                
            }
            return list;
        } 

        public static IEnumerable<string> Fields(Type type)
        {
            List<string> list = new List<string>();
            foreach (FieldInfo field in type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static))
            {
                if (field.IsPublic)
                {
                    list.Add(field.Name);
                    InFile(field.Name);
                }

            }
            foreach (PropertyInfo prop in type.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static))
            {
                list.Add($"{prop.PropertyType} {prop.Name}");

                InFile($"{prop.PropertyType} {prop.Name}");
            }
            return list;
        }

        public static IEnumerable<string> E(Type type)
        {
            List<string> list = new List<string>();
            Console.WriteLine("Реализованные интерфейсы:");
            foreach (Type i in type.GetInterfaces())
            {
                Console.WriteLine(i.Name);
                InFile(i.Name);
            }
            return list;
        }
        public static void F(Type type, string check)
        {
            foreach (MethodInfo method in type.GetMethods())
            {
                
                ParameterInfo[] parameters = method.GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    if (parameters[i].ParameterType.Name == check)
                    {
                        Console.WriteLine($"{method.ReturnType.Name} {method.Name}");
                        InFile($"{method.ReturnType.Name} {method.Name}");
                        break;
                    }
                    
                }
                
            }
        }

        

        public static T Create<T>(object[] parm)
        {
            Type type = typeof(T);
            object? a = Activator.CreateInstance(type, parm);
            return (T)a;
        }
       
        public static async void InFile<T>(T info)
        {
            using (StreamWriter sw = new StreamWriter(Path, true))
            {
                await sw.WriteLineAsync($"{info.ToString()}");
            }
        }

       
    }
}
