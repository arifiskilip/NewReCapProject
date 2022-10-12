using Entities.Abstract;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class Customer : IEntity
    {
        public int Id { get; set; }
        public string ComponyName { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
        public List<Rental> Rentals { get; set; }
    }
}
