using ApplicationDomain;
using ApplicationDomain.Controller;
using Space_Game.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game.Controller
{
    public class LocationSelector : ISelector<ILocation>
    {
        private IModel model;

        public LocationSelector(IModel model)
        {
            this.model = model;
        }

        public void SelectAt(ILocation Location)
        {
            
        }
    }
}
