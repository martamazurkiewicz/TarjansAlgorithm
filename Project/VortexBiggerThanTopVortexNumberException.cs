using System;
using System.Runtime.Serialization;

namespace Project
{
    [Serializable]
    public class VortexBiggerThanTopVortexNumberException : Exception
    {
        public VortexBiggerThanTopVortexNumberException(){}
        public VortexBiggerThanTopVortexNumberException(string message) : base(message){}
        public VortexBiggerThanTopVortexNumberException(string message, Exception innerException) : base(message, innerException){}
        protected VortexBiggerThanTopVortexNumberException(SerializationInfo info, StreamingContext context) : base(info, context){}
    }
}