using System;

namespace BSPFileReader
{

    class Program
    {
        static void Main(string[] args)
        {
            BSP        map  = new BSP("ep1_c17_00.bsp");
            vertext[] data = map.DumpLump<vertext>();

            Console.WriteLine(map);
            Console.WriteLine("Chunks for dface_t loaded.");
            Console.WriteLine("Count: {0}", data.Length );

            Console.ReadLine();
        }
    }

}
