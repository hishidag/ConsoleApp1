using System;
using System.Collections.Generic;
using System.Text;

namespace BullsAndCowsGame
{
    public class Digits
    {
        private int _value;

        public Digits(int digits)
        {
            Value = digits;
        }

        public int Value
        {
            get 
            {
                return _value;
            }
            set
            {
                if (value <= 0 || value >= 10) throw new IllegalDigitsException();
                _value = value;
            }
        }
    }

    [System.Serializable]
    public class IllegalDigitsException : Exception
    {
        public IllegalDigitsException() { }
        public IllegalDigitsException(string message) : base(message) { }
        public IllegalDigitsException(string message, Exception inner) : base(message, inner) { }
        protected IllegalDigitsException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
