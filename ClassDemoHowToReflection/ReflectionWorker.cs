using System;
using System.Linq;
using System.Reflection;

namespace ClassDemoHowToReflection
{
    internal class ReflectionWorker
    {
        public ReflectionWorker()
        {
        }

        public void Start()
        {
            Object o = new Person() { Id = 9, Name = "Peter" };
            Console.WriteLine("Person object ==> " + o);

            /*
             * Reflection
             */
            Type t = o.GetType();

            Console.WriteLine("full name " + t.FullName);
            Console.WriteLine("is interface " + t.IsInterface);
            Console.WriteLine("is class " + t.IsClass);
            Console.WriteLine("Base Class type " + t.BaseType);

            Console.WriteLine(" === properties == ");
            foreach (PropertyInfo info in t.GetProperties())
            {
                Console.WriteLine(info);
            }

            Console.WriteLine(" === methods == ");
            foreach (MethodInfo info in t.GetMethods())
            {
                Console.WriteLine(info);
            }

            
            /*
             * Like to call a method
             */
            MethodInfo setIdMethod = t.GetMethods().First(m => m.Name == "set_Id");
            setIdMethod.Invoke(o, new object[] { 12 }); // kalder metode
            Console.WriteLine("Person after call " + o);

            PropertyInfo idprop = t.GetProperty("Id");
            Console.WriteLine($"Id prop is {idprop.Name} value {idprop.GetValue(o)}");

        }
    }

    internal class Person
    {
        public String Name { get; set; }

        public int Id { get; set; }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Id)}: {Id}";
        }
    }
}