using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        ICentralBankService _centralBankService;

        public ProductManager(ICentralBankService centralBankService)
        {
            _centralBankService = centralBankService;
        }

        public void Sell(Product product, Customer customer)
        {
            decimal price = product.Price;

            if (customer.IsStudent)
            {
                price = product.Price * (decimal)0.90;
            }
            if(customer.IsOfficer)
            {
                price = product.Price * (decimal)0.80;
            }

            price = _centralBankService.ConvertRate(new CurrencyRate { Currency = 1, Price = 1000 });

            Console.WriteLine(price);
        }
    }
}
