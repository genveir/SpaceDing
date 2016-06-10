using Space_Game.BasicModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game.Simulation
{
    public class Universe : IUpdatable
    {
        public IEnumerable<SolarSystem> Systems { get; set; }

        public bool Observed
        {
            get
            {
                return true;
            }

            set
            {
                // the universe should always be observed
                throw new NotImplementedException();
            }
        }

        public void Update()
        {
            Time.Increment();

            Parallel.ForEach(Systems, system =>
            {
                system.Update();
            });
        }
    }
}
