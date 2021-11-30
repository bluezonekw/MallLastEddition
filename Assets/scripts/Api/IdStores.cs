using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Translation
{
    public int id { get; set; }
    public string name { get; set; }
    public string welcome_message { get; set; }
    public string locale { get; set; }
    public int store_id { get; set; }
}

public class DatumPage
{
    public int id { get; set; }
    public string email { get; set; }
    public int is_active { get; set; }
    public string logo { get; set; }
    public string banner { get; set; }
    public int position_id { get; set; }
    public int category_id { get; set; }
    public string logo_path { get; set; }
    public string banner_path { get; set; }
    public string name { get; set; }
    public string welcome_message { get; set; }
    public Translation translation { get; set; }
}

public class IdStores
{
    public int statsu { get; set; }
    public string message { get; set; }
    public List<DatumPage> data { get; set; }
}

