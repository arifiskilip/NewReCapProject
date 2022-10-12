using Entities.Abstract;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class Brand : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Car> Cars { get; set; }
    }
}
