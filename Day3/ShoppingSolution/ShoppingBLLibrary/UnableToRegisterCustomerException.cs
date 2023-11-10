using System.Runtime.Serialization;

namespace ShoppingBLLibrary
{
    [Serializable]
    internal class UnableToRegisterCustomerException : Exception
    {
        string message;
        public UnableToRegisterCustomerException()
        {
            message = "Unable to register at this moment";
        }
        public override string Message => message;

    }
}