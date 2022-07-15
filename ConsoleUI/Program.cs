using System;
using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
           //ColorTest();
            //BrandTest();
           //CarTest();
        }

        private static void ColorTest()
        {
            Color yesil = new Color { ColorId =8, ColorName = "Bronz" };
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(yesil);
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void BrandTest()
        {
            //Brand tesla = new Brand {BrandId = 8, BrandName = "MitsuBishi" };
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            //brandManager.Add(tesla);
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void CarTest()
        {
            //Car myCar = new Car
            //{
            //    CarId = 4,BrandId=8,ColorId=3,
            //    CarName = "Tesla-M3", ModelYear = new DateTime(2021),
            //    DailyPrice = 1500, Description="Tesla Model3 Yeşil Lüx Araç." 
            //};
                 
            CarManager carManager = new CarManager(new EfCarDal());
           //carManager.Add(myCar);

            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {

                foreach (var car in result.Data)
                {
                    Console.WriteLine("Araç Adı : " + car.CarName+"\n" +
                        "Aracın Markası : " + car.BrandName + "\n" + 
                        "Aracın Rengi : " + car.ColorName + "\n" + 
                        "Aracın Günlük Fiyatı : " + car.DailyPrice + "\n");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
