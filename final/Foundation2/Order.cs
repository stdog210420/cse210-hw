using System;
using System.Xml.Serialization;

class Order
{
    private Customer _customer;
    private Product _product;
    private Address _address;
    private int _shippingCost; 
    private List<Product> _products;

    public List<Product> GetProducts()
    {
        return _products;
    }
    public Order(Customer customer, List<Product> products, Address address)
    {
        _customer = customer;
        _products = products;
        _address = address;
    }
    public void AddProduct()
    {
        _products.Add(_product);
    }
    public double SumTotalPrice()
    {
        double totalPrice = 0;
        double shippingCost;
        if (_customer.IsInUSA())
        {
            shippingCost = 5;
        }
        else
        {
            shippingCost = 35;
        }
        foreach (var product in _products)
        {
            totalPrice += product.GetTotalPrice();
        }
        return totalPrice + shippingCost;
    }
    public string GetPackingLable()
    {
        List<string> _labels = new List<string>();
        foreach (var product in _products)
        {
            string _label= $"{product.ItemName()}  {product.productID()}";
            _labels.Add(_label);
        }
        // 使用 string.Join 將 List<string> 中的字串用換行符串接成一個字串
        return string.Join(Environment.NewLine, _labels);
    }
    public string GetShippingLabel()
    {
        return $"Shipping to: {_customer.Name()}\n{_customer.address().GetFullAddress()}";
    }

}