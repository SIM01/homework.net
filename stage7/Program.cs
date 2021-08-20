using System;
using System.Collections;
using System.Reflection;

namespace stage7
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly myAssembly =
                Assembly.LoadFile(
                    @"/home/sim/RiderProjects/ClassesSampleFor.Net/DexPractic/BankSystem/bin/Debug/net5.0/BankSystem.dll");

            var myType = myAssembly.GetType("BankSystem.Service.BankService", true, true);

            var myObject = Activator.CreateInstance(myType);

            Type[] emptyArgumentTypes = Type.EmptyTypes;
            var ctor = myType.GetConstructor(emptyArgumentTypes);
            var instance = ctor.Invoke(new object[] { });

            var myFields = myObject.GetType()
                .GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var f in myFields)
            {
                Console.WriteLine($"{f.Name}");
                if (f.Name == "clients")
                {
                    var list = f.GetValue(myObject);
                    /*
                    var tmpProperty = list.GetType().GetProperties();
                    
                    foreach (var p in tmpProperty)
                    {
                        if (p.Name == "Name")
                        {
                            //Console.WriteLine($"{p.GetValue(list[0])}");  
                        }
                    }
                    */
                }
            }

            var myMethod = myType.GetMethod("GetFilePath", BindingFlags.NonPublic | BindingFlags.Instance);
            var result = myMethod.Invoke(myObject, new object[] {"Client"});
            Console.WriteLine(result.ToString());

            Assembly myAssembly2 =
                Assembly.LoadFile("/home/sim/RiderProjects/homework.net/stage6/bin/Debug/net5.0/stage6.dll");
            var myType2 = myAssembly2.GetType("stage6.Figure", true, true);
            var myObject2 = Activator.CreateInstance(myType2);

            var myProperty2 = myObject2.GetType().GetProperties();

            foreach (var f in myProperty2)
            {
                Console.WriteLine($"{f.Name}");
            }
        }
    }
}