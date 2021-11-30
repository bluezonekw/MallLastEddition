using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class RequestStoresData
{

    public int current_page { get; set; }
    public List<StoreDate> Store { get; set; }
    public string first_page_url { get; set; }
    public int from { get; set; }
    public string next_page_url { get; set; }
    public string path { get; set; }
    public string per_page { get; set; }
    public object prev_page_url { get; set; }
    public int to { get; set; }
}
public class StoreDate
{
    public int id { get; set; }
    public int is_active { get; set; }
    public string logo { get; set; }
    public string banner { get; set; }
    public int category_id { get; set; }
    public string name { get; set; }
    public string welcome_message { get; set; }
    public List<translations> translations { get; set; }
}
public class translations
{
    public int id { get; set; }

    public string name { get; set; }
    public string welcome_message { get; set; }

    public string locale { get; set; }

    public int store_id { get; set; }


}
public class Hall
    {
        public int statsu { get; set; }
        public string message { get; set; }
        public RequestStoresData data { get; set; }
    }











*/






// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
public class Translationsss
{
    public int id { get; set; }
    public string name { get; set; }
    public string welcome_message { get; set; }
    public string locale { get; set; }
    public int store_id { get; set; }
}

public class DataStore
{
    public int id { get; set; }
    public int is_active { get; set; }
    public string logo { get; set; }
    public string banner { get; set; }
    public int category_id { get; set; }
    public string name { get; set; }
    public string welcome_message { get; set; }
    public List<Translationsss> translations { get; set; }
    public int current_page { get; set; }
    public List<DataStore> data { get; set; }
    public string first_page_url { get; set; }
    public int from { get; set; }
    public string next_page_url { get; set; }
    public string path { get; set; }
    public string per_page { get; set; }
    public object prev_page_url { get; set; }
    public int to { get; set; }
}

public class Hall
{
    public int statsu { get; set; }
    public string message { get; set; }
    public DataStore data { get; set; }
}

