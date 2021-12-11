using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ProductOption
{
    public int id { get; set; }
    public string name { get; set; }
    public double price { get; set; }
    public int attribute_id { get; set; }
}

public class ProductAttribute
{
    public int id { get; set; }
    public string name { get; set; }
    public bool has_price { get; set; }
    public string selection_type { get; set; }

    public List<ProductOption> options { get; set; }
}

public class ProductData
{
    public int id { get; set; }
    public string img { get; set; }
    public int regular_price { get; set; }
    public object sale_price { get; set; }
    public int quantity { get; set; }
    public List<string> slider { get; set; }
    public List<ProductAttribute> attributes { get; set; }
    public bool in_favorite { get; set; }
    public string name { get; set; }
    public string description { get; set; }
}

public class StoreProduct
{
    public int statsu { get; set; }
    public string message { get; set; }
    public ProductData data { get; set; }
}



public class CartData
{
    public int id { get; set; }
    public int quantity { get; set; }
    public double price { get; set; }
    public List<ProductAttribute> attributes { get; set; }
    public string img { get; set; }
    public double total_price { get; set; }
    public string name { get; set; }
}
public class MainCartData
{
    public List<CartData> Carts { get; set; }

    public int shipping_price { get; set; }

}
public class CartResponse
{
    public int statsu { get; set; }
    public string message { get; set; }
    public MainCartData data { get; set; }
}

