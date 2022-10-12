using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserManager userManager = new UserManager(new EfUserDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            Rental rental = new Rental()
            {
                CarId = 1,
                CustomerId = 1,
                RentDate = DateTime.Now

            };
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            string message = rentalManager.Add(rental).Message;
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine(message);
            //foreach (var item in carManager.GetCarDetails().Data)
            //{
            //    Console.WriteLine(item.CarId + " " + item.BrandName + " " + item.Description + " " + item.ColorName + " " + item.DailyPrice);
            //}
        }
    }
}
