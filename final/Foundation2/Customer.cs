using System;

class Customer
{
    private string _name;
    private Address _address;

    public string Name()
    {
        return _name;
    }
    public Address address()
    {
        return _address;
    }
    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }
    public bool IsInUSA()
    {
        return _address.IsInUSA();
    }


}