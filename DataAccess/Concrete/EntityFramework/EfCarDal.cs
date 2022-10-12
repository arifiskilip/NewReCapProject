using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfGenericRepository<Car, CarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarContext context = new CarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on
                             c.BrandId equals b.Id
                             join clr in context.Colors on
                             c.ColorId equals clr.Id
                             select new CarDetailDto
                             {
                                 CarId = c.Id,
                                 BrandName = b.Name,
                                 ColorName = clr.Name,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description
                             };
                return result.ToList();
            }
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            using (CarContext context = new CarContext())
            {
                return context.Set<Car>().Where(x => x.BrandId == id).ToList();
            }
        }

        public List<Car> GetCarsByColorId(int id)
        {
            using (CarContext context = new CarContext())
            {
                return context.Set<Car>().Where(x => x.ColorId == id).ToList();
            }
        }
    }
}
