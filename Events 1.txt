
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

    interface IBuyer
    {
        void Buy(Shop shop);
    }

    class Shop
    {
        List<IBuyer> subscribers = new List<IBuyer>();

        public Phone NewPhone { get; set; } = null;

        public void AddSubscriber(IBuyer customer)
        {
            subscribers.Add(customer);
        }

        public void RemoveSubscriber(IBuyer customer)
        {
            subscribers.Remove(customer);
        }

        public void NewPhoneArrived(Phone phone)
        {
            NewPhone = phone;

            foreach (var item in subscribers)
            {
                item.Buy(this);
            }
        }
    }

    class Customer : IBuyer
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

    class Company : IBuyer
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

            shop.AddSubscriber(cust1);
            shop.AddSubscriber(cust2);
            shop.AddSubscriber(cust3);
            shop.AddSubscriber(comp1);

            shop.NewPhoneArrived(new Phone { Name = "iPhoneX", Price = 1000 });
        }
    }
}