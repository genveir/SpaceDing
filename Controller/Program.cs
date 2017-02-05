using ApplicationDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game.Controller
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var controller = new SpaceGameController();

            controller.Start();
        }
    }
}
