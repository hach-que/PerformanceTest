using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public interface IInterface
    {
        int Test();
    }

    public class ClassVirtual
    {
        public virtual int Test()
        {
            return 1;
        }
    }

    public class ClassWithExplicitInterface : IInterface
    {
        public virtual int Test()
        {
            return 1;
        }

        int IInterface.Test()
        {
            return 1;
        }
    }

    public class ClassWithImplicitInterface : IInterface
    {
        public virtual int Test()
        {
            return 1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var nvms = 0f;
            var xpms = 0f;
            var xpims = 0f;
            var ipms = 0f;
            for (var ii = 0; ii < 10; ii++)
            {
                Console.WriteLine("Test " + ii);
                var stopwatchnv = Stopwatch.StartNew();
                var classnv = new ClassVirtual();
                for (var i = 0; i < 600000000; i++)
                {
                    classnv.Test();
                }
                stopwatchnv.Stop();
                Console.WriteLine("Class with virtual method: " + stopwatchnv.ElapsedMilliseconds);
                nvms += stopwatchnv.ElapsedMilliseconds;

                var stopwatchxp = Stopwatch.StartNew();
                var classxp = new ClassWithExplicitInterface();
                for (var i = 0; i < 600000000; i++)
                {
                    classxp.Test();
                }
                stopwatchxp.Stop();
                Console.WriteLine("Class with explicit interface, accessed via method: " +
                                  stopwatchxp.ElapsedMilliseconds);
                xpms += stopwatchxp.ElapsedMilliseconds;

                var stopwatchxpi = Stopwatch.StartNew();
                var classxpi = (IInterface) new ClassWithExplicitInterface();
                for (var i = 0; i < 600000000; i++)
                {
                    classxpi.Test();
                }
                stopwatchxpi.Stop();
                Console.WriteLine("Class with explicit interface, accessed via interface: " +
                                  stopwatchxpi.ElapsedMilliseconds);
                xpims += stopwatchxpi.ElapsedMilliseconds;

                var stopwatchip = Stopwatch.StartNew();
                var classip = (IInterface) new ClassWithImplicitInterface();
                for (var i = 0; i < 600000000; i++)
                {
                    classip.Test();
                }
                stopwatchip.Stop();
                Console.WriteLine("Class with implicit interface, accessed via interface: " +
                                  stopwatchip.ElapsedMilliseconds);
                ipms += stopwatchip.ElapsedMilliseconds;
            }
            Console.WriteLine("Summary: Class with virtual method: " + nvms / 10f);
            Console.WriteLine("Summary: Class with explicit interface, accessed via method: " + xpms / 10f);
            Console.WriteLine("Summary: Class with explicit interface, accessed via interface: " + xpims / 10f);
            Console.WriteLine("Summary: Class with implicit interface, accessed via interface: " + ipms / 10f);

            Console.ReadKey();
        }
    }
}
