using Entities.Abstract;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class Car : IEntity
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public string ModelYear { get; set; }
        public double DailyPrice { get; set; }
        public string Description { get; set; }

        public Brand Brand { get; set; }
        public Color Color { get; set; }
        public List<Rental> Rentals { get; set; }
        public List<CarImage> CarImages { get; set; }
    }
}
