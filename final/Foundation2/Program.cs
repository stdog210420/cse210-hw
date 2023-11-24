using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        List<Product> _nonUsaProducts = new List<Product>();
        List<Product> _usaProducts = new List<Product>();
        Address _nonUsaAddress = new Address("Lower O'Connell Street", "Dublin", "Dublin 2", "Ireland");
        Address _usaAddress = new Address("256 W 47th Street", "New York", "New York", "USA");
        Customer _nonUsaCustomer = new Customer("Julia Roberts",  _nonUsaAddress);
        Customer _usaCustomer = new Customer("Taylor Alison Swift", _usaAddress);
        Product _nonUsaProduct1 = new Product("Blue and White Porcelain Ashtray", 123, 1000, 1);
        Product _nonUsaProduct2 = new Product("Six Harmony Bedside Cabinet", 124, 1500, 1);
        Product _nonUsaProduct3 = new Product("Miniature Carved Flower Bowl and Plate Set", 125, 75, 2);
        Product _usaProduct1 = new Product("Ivory-inlaid Gold Bowl and Chopsticks Set", 234, 50, 5);
        Product _usaProduct2 = new Product("Embroidered Vanity Table with Hollow Carvings", 235, 2000, 2);

        Order _nonUsaOrder = new Order(_nonUsaCustomer, _nonUsaProducts, _nonUsaAddress);
        Order _usaOrder = new Order(_usaCustomer, _usaProducts, _usaAddress);


    }
}