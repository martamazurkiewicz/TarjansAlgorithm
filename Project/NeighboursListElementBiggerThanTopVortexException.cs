using System;
using System.Runtime.Serialization;

namespace Project
{
    [Serializable]
    public class NeighboursListElementBiggerThanTopVortexException : Exception
    {
        public NeighboursListElementBiggerThanTopVortexException(){}
        public NeighboursListElementBiggerThanTopVortexException(string message) : base(message){}
        public NeighboursListElementBiggerThanTopVortexException(string message, Exception innerException) : base(message, innerException){}
        protected NeighboursListElementBiggerThanTopVortexException(SerializationInfo info, StreamingContext context) : base(info, context){}
    }
}