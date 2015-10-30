using System;

namespace BSPFileReader
{

    class Program
    {
        static void Main(string[] args)
        {
            BSP       map  = new BSP("ep1_c17_00.bsp");
            dface_t[] data = map.GetLump<dface_t>();

            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n");
            Console.WriteLine(map);
            Console.WriteLine("Chunks for dface_t loaded.");
            Console.WriteLine("Count: {0}", data.Length );

            foreach ( dface_t f in data )
                Console.WriteLine("Planenum: {0}, Firstedge: {1}, Originface: {2}", f.planenum, f.firstedge, f.origFace);

            Console.ReadLine();
        }
    }

}
