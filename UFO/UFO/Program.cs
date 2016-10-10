using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UFOGame.Classes;

namespace UFOGame
{
    class Program
    {
        static void Main(string[] args)
        {
            UFOInterface tardis = new UFOInterface();

            tardis.Run();
        }
    }
}
