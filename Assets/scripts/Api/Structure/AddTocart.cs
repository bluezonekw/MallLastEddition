using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ProductInCart
{
    public int quantity { get; set; }
    public double price { get; set; }
    public int id { get; set; }
    public string img { get; set; }
    public double total_price { get; set; }
    public string name { get; set; }
}

public class AddTocart
{
    public int statsu { get; set; }
    public string message { get; set; }
    public ProductInCart data { get; set; }
}