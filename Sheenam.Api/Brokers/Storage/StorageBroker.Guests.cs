//===========================================
//Copyright (c) Coalition of Good-Hearted Engineers
//Free To Use Comfort and Peace
//============================================

using Microsoft.EntityFrameworkCore;
using Sheenam.Api.Models.Foundations.Guests;

namespace Sheenam.Api.Brokers.Storage
{
    public partial class StorageBroker
    {
        public DbSet<Guest> Guests { get; set; }
    }
}
