//===========================================
//Copyright (c) Coalition of Good-Hearted Engineers
//Free To Use To Find Comfort and Peace
//============================================

using Xeptions;

namespace Sheenam.Api.Services.Foundations.Guests.Exceptions
{
    public class GuestDependencyException : Xeption
    {
        public GuestDependencyException(Xeption innerException) 
            :base(message: "Guest dependency error occurred, contact support",
                 innerException)
        { }
    }
}
