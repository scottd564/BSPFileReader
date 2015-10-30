using System;
using System.IO;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSPFileReader
{

    class Program
    {

        static void Main(string[] args)
        {
            BSP map = new BSP("ep1_c17_00.bsp");
            map.GetLump();

            Console.WriteLine(map);
            Console.ReadLine();
        }

    }

}
