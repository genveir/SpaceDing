using System;
using System.Runtime.Serialization;

namespace Space_Game.Carrier.Ships
{
    [Serializable]
    internal class ShipWithoutPartsException : Exception
    {
        public ShipWithoutPartsException()
        {
        }

        public ShipWithoutPartsException(string message) : base(message)
        {
        }

        public ShipWithoutPartsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ShipWithoutPartsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}