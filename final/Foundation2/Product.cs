using System;

class Product
{
    private string _itemName;
    private int _productID;
    private float _price;
    private int _quantity;
    public string ItemName()
    {
        return _itemName;
    }
    public int productID()
    {
        return _productID;
    }
    public float Price()
    {
        return _price;
    }
    public int Quantity()
    {
        return _quantity;
    }

    public Product (string itemName, int productID, float price, int quantity)
    {
        _itemName = itemName;
        _productID = productID;
        _price = price;
        _quantity = quantity;
    }
    public double GetTotalPrice()
    {
        return _price * _quantity;
    }

}