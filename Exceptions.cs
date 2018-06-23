using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    class PersonInfoException : Exception
    {
        public object Value { get; set; }

        public PersonInfoException(string message, object value = null) 
            : base(message)
        {
            Value = value;
        }
    }

    class Person
    {
        private string name;
        public string Name {
            get => name;
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                    name = value;
                else
                    throw new PersonInfoException("Incorrect name!", value);
            }
        }

        private int age;
        public int Age
        {
            get => age;
            set
            {
                if (value < 150 && value >= 0) 
                    age = value;
                else
                    throw new PersonInfoException("Incorrect age!", value);
            }
        }

        public override string ToString()
        {
            return $"{Name} {Age}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var person = new Person { Name = "Gleb", Age = -24 };
                Console.WriteLine(person);
            }
            catch (PersonInfoException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Value);
            }




            //using (var fs = new FileStream("text.txt", FileMode.Create))
            //{
            //    fs.WriteByte(65);
            //    fs.WriteByte(66);
            //    fs.WriteByte(67);
            //    fs.WriteByte(68);
            //}




            //FileStream fs = null;
            //try
            //{
            //    fs = new FileStream("text.txt", FileMode.Create);

            //    fs.WriteByte(65);
            //    fs.WriteByte(66);
            //    fs.WriteByte(67);
            //    fs.WriteByte(68);
            //}
            //catch (Exception ex)
            //{
            //    throw;
            //}
            //finally
            //{
            //    fs.Close();
            //}






            //WebClient webClient = new WebClient();
            //try
            //{
            //    var result = webClient.DownloadString("http://www.google.az");
            //    Console.WriteLine(result);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}





            //int[] arr = new int[5] { 11, 22, 33, 44, 55 };

            //try
            //{
            //    int index = Int32.Parse(Console.ReadLine());
            //    Console.WriteLine(arr[index]);
            //}
            //catch (IndexOutOfRangeException)
            //{
            //    Console.WriteLine("Вы ввели слишком большое число!");
            //}
            //catch (FormatException)
            //{
            //    Console.WriteLine("Вы ввели число некорректно!");
            //}
            //catch (Exception)
            //{
            //    Console.WriteLine("Что-то пошло не так!");
            //}

            //Console.WriteLine("End!");
        }
    }
}
