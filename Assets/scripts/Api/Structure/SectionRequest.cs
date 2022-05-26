using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionRequestData
{
    public object current_page;
    public object first_page_url;
    public object from;
    public object next_page_url;
    public object path;
    public object per_page;
    public object prev_page_url;
    public object to;
    public List<Dataforproduct> data;






  
}
public class Dataforproduct
{
    public int id;
    public string img;
    public int? sale_price;
    public double regular_price;
    public bool in_favorite;
    public string name;
    public string description;
}

public class SectionRequest
{
    public int statsu ;
    public string message ;
    public SectionRequestData data ;
}


