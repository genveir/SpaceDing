using Space_Game.BasicModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game.Simulation
{
    class SolarSystem
    {
        public IEnumerable<IBody> Bodies { get; set; }

        public bool Observed { get; set; }

        public void Update()
        {
            if (Observed)
            {
                Parallel.ForEach(Bodies, body =>
                {
                    body.Update();
                });
            }
            else
            {
                UpdateUnobserved();
            }
        }

        private void UpdateUnobserved()
        {
            // do stuff with less detail
        }
    }
}