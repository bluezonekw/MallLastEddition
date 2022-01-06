using System.Collections;
using System.Collections.Generic;
using UnityEngine;






// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 

public class DataStore
{
    public int id { get; set; }
        public int is_active { get; set; }
        public string logo { get; set; }
        public string banner { get; set; }
        public int category_id { get; set; }
        public string name { get; set; }
        public string welcome_message { get; set; }
}

public class Hall
{
  public int statsu { get; set; }
        public string message { get; set; }
        public List<DataStore> data { get; set; }
}

