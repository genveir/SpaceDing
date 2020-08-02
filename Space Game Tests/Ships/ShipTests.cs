using NUnit.Framework;
using Space_Game.Carrier.Ships;
using Space_Game.Carrier.Ships.Parts.Implementations;
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
        public void CannotCreateShipWithNullParts()
        {
            Assert.Throws<ShipWithoutPartsException>(() =>
            {
                new Ship("ship", new FixedLocation(0, 0), null);
            });
        }

        [Test]
        public void CannotCreateShipWithZeroParts()
        {
            Assert.Throws<ShipWithoutPartsException>(() =>
            {
                new Ship("ship", new FixedLocation(0, 0), new List<Part>());
            });
        }

        [Test]
        public void ShipWithBridgeAndFuelAndEngineHasAcceleration()
        {
            var bridge = new Bridge(100, 1000);
            var engine = new NuclearEngine(1000, 1000);
            var tank = new FuelTank(7500);

            var ship = new Ship("ship", new FixedLocation(0, 0), bridge, engine, tank);
            
            Assert.AreNotEqual(0, ship.Acceleration);
        }

        [Test]
        public void ShipWithNoControlHasNoAcceleration()
        {
            var engine = new NuclearEngine(1000, 1000);
            var tank = new FuelTank(7500);

            var ship = new Ship("ship", new FixedLocation(0, 0), engine, tank);

            Assert.AreEqual(0, ship.Acceleration);
        }

        [Test]
        public void ShipWithoutFuelHasNoAcceleration()
        {
            var bridge = new Bridge(100, 1000);
            var engine = new NuclearEngine(1000, 1000);

            var ship = new Ship("ship", new FixedLocation(0, 0), bridge, engine);

            Assert.AreEqual(0, ship.Acceleration);
        }

        [Test]
        public void ShipWithoutEngineHasNoAcceleration()
        {
            var bridge = new Bridge(100, 1000);
            var tank = new FuelTank(7500);

            var ship = new Ship("ship", new FixedLocation(0, 0), bridge, tank);
        }
    }
}
