using System;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Serialization;

class Order
{
    private Customer _customer;
    private Address _address;
    private List<Product> _products;
    public Customer Customer()
    {
        return _customer;
    }

    // public List<Product> GetProducts()
    // {
    //     return _products;
    // }
    public Address Address()
    {
        return _address;
    }
    public Order(Customer customer, List<Product> products, Address address)
    {
        _customer = customer;
        _products = products;
        _address = address;
    }
    // public void AddProduct()
    // {
    //     _products.Add(_product);
    // }
    public double SumTotalPrice()
    {
        double _shippingCost;
        double totalPrice = 0;
        if (_customer.IsInUSA())
        {
            _shippingCost = 5;
        }
        else
        {
            _shippingCost = 35;
        }
        foreach (var product in _products)
        {
            totalPrice += product.GetTotalPrice();
        }
        return totalPrice + _shippingCost;
    }
    public string GetPackingLable()
    {   int i = 0;
        List<string> _labels = new List<string>();
        foreach (var product in _products)
        {   
            string _label= $"{product.ItemName()}, No.{product.productID()}";
            _labels.Add(_label);
        }
        i ++;
        // 使用 string.Join 將 List<string> 中的字串用換行符串接成一個字串
        return string.Join(Environment.NewLine, _labels);
        // return string.Join(Environment.NewLine, _labels);
    }
    public string GetShippingLabel()
    {
        return $"Shipping to: {_customer.Name()}\n{_customer.address().GetFullAddress()}";
    }

}