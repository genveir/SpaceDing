using NUnit.Framework;
using Space_Game.Carrier.Ships;
using Space_Game.Carrier.Ships.DTO;
using Space_Game.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game
{
    public class ShipTests
    {        
        [Test]
        public void CannotCreateShipWithoutParts()
        {
            var dto = new ShipDTO("ship", (0, 0));

            Assert.Throws<ShipWithoutPartsException>(() => dto.ToShip());
        }

        [Test]
        public void ShipWithBridgeAndFuelAndEngineHasAcceleration()
        {
            var dto = new ShipDTO("ship", (0, 0));
            dto.AddPart("Bridge", 100, ("ControlEfficiency", "1000"));
            dto.AddPart("NuclearEngine", 1000, ("FuelEfficiency", "1000"), ("MassEfficiency", "1000"));
            dto.AddPart("FuelTank", 7500);

            var ship = dto.ToShip();

            Assert.AreNotEqual(0, ship.Acceleration);
        }

        [Test]
        public void ShipWithNoControlHasNoAcceleration()
        {
            var dto = new ShipDTO("ship", (0, 0));
            dto.AddPart("NuclearEngine", 1000, ("FuelEfficiency", "1000"), ("MassEfficiency", "1000"));
            dto.AddPart("FuelTank", 7500);

            var ship = dto.ToShip();

            Assert.AreEqual(0, ship.Acceleration);
        }

        [Test]
        public void ShipWithoutFuelHasNoAcceleration()
        {
            var dto = new ShipDTO("ship", (0, 0));
            dto.AddPart("Bridge", 100, ("ControlEfficiency", "1000"));
            dto.AddPart("NuclearEngine", 1000, ("FuelEfficiency", "1000"), ("MassEfficiency", "1000"));

            var ship = dto.ToShip();

            Assert.AreEqual(0, ship.Acceleration);
        }

        [Test]
        public void ShipWithoutEngineHasNoAcceleration()
        {
            var dto = new ShipDTO("ship", (0, 0));
            dto.AddPart("Bridge", 100);
            dto.AddPart("FuelTank", 7500);

            var ship = dto.ToShip();

            Assert.AreEqual(0, ship.Acceleration);
        }
    }
}
