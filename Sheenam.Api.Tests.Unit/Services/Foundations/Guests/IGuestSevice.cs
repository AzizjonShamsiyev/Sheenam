using Sheenam.Api.Models.Foundations.Guests;

namespace Sheenam.Api.Tests.Unit.Services.Foundations.Guests
{
    public interface IGuestSevice
    {
        ValueTask<Guest> AddGuestAsync(Guest guests);
    }
}
