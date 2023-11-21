namespace HotelApplication.Exceptions
{
    public class NoReviewsAvailableException : Exception
    {
        string message;
        public NoReviewsAvailableException()
        {
            message = "No reviews are available to view";
        }
        public override string Message => message;
    }
}