using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FavData
{
    public int id { get; set; }
    public string img { get; set; }
    public int regular_price { get; set; }
    public object sale_price { get; set; }
    public bool in_favorite { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public int current_page { get; set; }
    public List<FavData> data { get; set; }
    public string first_page_url { get; set; }
    public int from { get; set; }
    public object next_page_url { get; set; }
    public string path { get; set; }
    public int per_page { get; set; }
    public object prev_page_url { get; set; }
    public int to { get; set; }
}

public class FavRequest
{
    public int statsu { get; set; }
    public string message { get; set; }
    public FavData data { get; set; }
}