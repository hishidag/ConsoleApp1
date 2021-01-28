using System;

namespace ConsoleApp1
{
    public class NotSetInfoException : Exception
    {
        public NotSetInfoException() { }

        public NotSetInfoException(string message) : base(message) { }

        public NotSetInfoException(string message, Exception inner) : base(message, inner) { }

        protected NotSetInfoException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

}
