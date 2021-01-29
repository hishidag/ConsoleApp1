using System;

namespace BullsAndCowsGame
{
    [Serializable]
    public class CannotOfferException : Exception
    {
        public CannotOfferException() { }
        public CannotOfferException(string message) : base(message) { }
        public CannotOfferException(string message, Exception inner) : base(message, inner) { }
        protected CannotOfferException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
