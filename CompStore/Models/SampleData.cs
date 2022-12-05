using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.ComponentModel;
using System.Linq;

namespace CompStore.Models
{
    public class SampleData
    {
        public static void Initialize(ApplicationContext context)
        {
            if (context.Laptops.Any())
            {
                return;   // DB has been seeded
            }

            context.Laptops.AddRange(
                    new Laptop
                    {
                        LaptopName = "MacBook Air",
                        CompanyName = "Apple",
                        Price = 1000,
                        ModelProccesor = "Apple M1",
                        RamLaptop = "8 GB",
                        LaptopDisplay = "13,3 inch",
                        Imglink = "Content/image/MacBookAir.jpg"


                    },
                    new Laptop
                    {
                        LaptopName = "Surface Laptop 4",
                        CompanyName = "Microsoft",
                        Price = 1000,
                        ModelProccesor = "AMD Razen 5",
                        RamLaptop = "8 GB",
                        LaptopDisplay = "13 inch",
                        Imglink = "Content/image/SurfaceLaptop4.jpg"
                    },
                    new Laptop
                    {
                        LaptopName = "ThinkPad x1",
                        CompanyName = "Lenovo",
                        Price = 1500,
                        ModelProccesor = "Intel Core i7",
                        RamLaptop = "16 GB",
                        LaptopDisplay = "14 inch",
                        Imglink = "Content/image/ThinkPad.jpg"
                    },
                    new Laptop
                    {
                        LaptopName = "XPS",
                        CompanyName = "Dell",
                        Price = 1200,
                        ModelProccesor = "Intel Core i5",
                        LaptopDisplay = "15 inch",
                        RamLaptop = "8 GB",
                        Imglink = "Content/image/XPS.jpg"
                    }
             );
            context.SaveChanges();
        }
    }
}
