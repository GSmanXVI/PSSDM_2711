using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    class Phone
    {
        public string Name { get; set; }
        public int Price { get; set; }
    }

    class Shop
    {
        public delegate void BuyDelegate(Shop shop);
        public event BuyDelegate NewPhoneArrived;

        public Phone NewPhone { get; set; } = null;

        public void OnNewPhoneArrived(Phone phone)
        {
            NewPhone = phone;
            NewPhoneArrived?.Invoke(this);
        }
    }

    class Customer
    {
        public string Name { get; set; }
        public int Money { get; set; }

        public void Buy(Shop shop)
        {
            if (Money >= shop.NewPhone.Price)
            {
                Money -= shop.NewPhone.Price;
                Console.WriteLine($"{Name} bought new phone!");
            }
            else
            {
                Console.WriteLine($"{Name} has no money! :(");
            }
        }
    }

    class Company
    {
        public string Name { get; set; }
        public int Money { get; set; }

        public void Buy(Shop shop)
        {
            if (Money >= shop.NewPhone.Price)
            {
                Money -= shop.NewPhone.Price;
                Console.WriteLine($"{Name} bought new phone!");
            }
            else
            {
                Console.WriteLine($"{Name} has no money! :(");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var shop = new Shop();

            var cust1 = new Customer { Name = "Gleb", Money = 10000 };
            var cust2 = new Customer { Name = "Murad", Money = 500 };
            var cust3 = new Customer { Name = "Rustam", Money = 5000 };

            var comp1 = new Company { Name = "STEP", Money = 1000000 };

            shop.NewPhoneArrived += cust1.Buy;
            shop.NewPhoneArrived += cust2.Buy;
            shop.NewPhoneArrived += cust3.Buy;
            shop.NewPhoneArrived += comp1.Buy;
            

            shop.OnNewPhoneArrived(new Phone { Name = "iPhoneX", Price = 1000 });
        }
    }
}