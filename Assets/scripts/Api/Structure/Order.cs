using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class OrderData
{
    public int products_count { get; set; }
    public int order_price { get; set; }
    public int shipping_price { get; set; }
    public int discount { get; set; }
    public int final_price { get; set; }
    public string note { get; set; }
    public string coupon_code { get; set; }
    public int delivery_time { get; set; }
    public string payment_method { get; set; }
    public int created_at { get; set; }
    public int id { get; set; }
    public string image { get; set; }
}

public class Order
{
    public int statsu { get; set; }
    public string message { get; set; }
    public OrderData data { get; set; }
}

