﻿//===========================================
//Copyright (c) Coalition of Good-Hearted Engineers
//Free To Use To Find Comfort and Peace
//============================================

using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;
using Sheenam.Api.Models.Foundations.Guests;
using Sheenam.Api.Models.Foundations.Guests.Exceptions;
using Sheenam.Api.Tests.Unit.Services.Foundations.Guests;
using System.Threading.Tasks;

namespace Sheenam.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class GuestsController : RESTFulController
    {
        private readonly IGuestSevice guestSevice;

        public GuestsController(IGuestSevice guestService)
        {
            this.guestSevice = guestService;
        }

        [HttpPost]
        public async ValueTask<ActionResult<Guest>> PostGuestAsync(Guest guest)
        {
            try
            {
                Guest postedGuest = await this.guestSevice.AddGuestAsync(guest);

                return Created(postedGuest);
            }
            catch (GuestValidationException guestValidationException)
            {
                return BadRequest(guestValidationException.InnerException);
            }
            catch(GuestDependencyValidationException guestDependencyValidationException)
                when(guestDependencyValidationException.InnerException is AlreadyExistGuestException)
            {
                return Conflict(guestDependencyValidationException.InnerException);
            }
            catch(GuestDependencyValidationException guestDependencyValidationException)
            {
                return BadRequest(guestDependencyValidationException.InnerException);
            }
            catch(GuestDependencyException guestDependencyException) 
            {
                return InternalServerError(guestDependencyException.InnerException);
            }
            catch(GuestServiceException guestServiceException)
            {
                return InternalServerError(guestServiceException.InnerException);
            }
        }
    }
}
