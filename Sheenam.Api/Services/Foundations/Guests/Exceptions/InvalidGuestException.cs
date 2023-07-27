//===========================================
//Copyright (c) Coalition of Good-Hearted Engineers
//Free To Use To Find Comfort and Peace
//============================================

using Xeptions;

namespace Sheenam.Api.Services.Foundations.Guests.Exceptions
{
    public class InvalidGuestException : Xeption
    {
        public InvalidGuestException()
            :base(message: "Guest is invalid")
        { }
    }
}
