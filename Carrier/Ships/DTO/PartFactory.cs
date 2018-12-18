using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game.Carrier.Ships.DTO
{
    class PartFactory
    {
        public List<Part> CreateParts(List<PartDTO> parts)
        {
            var availableParts = this.GetType().Assembly.GetTypes()
                .Where(t => typeof(Part).IsAssignableFrom(t) && !t.IsAbstract);

            var newParts = new List<Part>();
            foreach(var part in parts)
            {
                var matchingAvailablePartType = availableParts.Where(ap => ap.Name == part.Name).SingleOrDefault();

                if (matchingAvailablePartType == null)
                    throw new NotImplementedException(
                        string.Format("part {0} does not exist", part.Name));

                if (matchingAvailablePartType.GetConstructor(new Type[0]) == null)
                {
                    throw new InvalidPartException(
                        string.Format("part {0} must contain a parameterless constructor to be constructed from DTO", matchingAvailablePartType.Name));
                }
                var newPart = Activator.CreateInstance(matchingAvailablePartType);
                var nameProp = matchingAvailablePartType.GetProperty("Name");
                var massProp = matchingAvailablePartType.GetProperty("Mass");

                nameProp.SetValue(newPart, part.Name);
                massProp.SetValue(newPart, Convert.ChangeType(part.Mass, typeof(int)));
                foreach (var otherProperty in part.Properties)
                {
                    var prop = matchingAvailablePartType.GetProperty(otherProperty.Key);
                    if (prop == null)
                        throw new NotImplementedException(
                            string.Format("part {0} does not have property {1}", part.Name, otherProperty.Key));

                    prop.SetValue(newPart, Convert.ChangeType(otherProperty.Value, prop.PropertyType));
                }

                newParts.Add((Part)newPart);
            }

            return newParts;
        }
    }
}
