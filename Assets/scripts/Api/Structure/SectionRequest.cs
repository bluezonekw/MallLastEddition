using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionRequestData
{
    public int id ;
    public string img ;
      public string name ; 
        public object sale_price  ; 
        public int regular_price ; 
    public bool in_favorite ;
    public int current_page ;
    public List<SectionRequestData> data ;
    public string first_page_url ;
    public int from ;
    public string next_page_url ;
    public string path ;
    public string per_page ;
    public string prev_page_url ;
    public int to ;
}

public class SectionRequest
{
    public int statsu ;
    public string message ;
    public SectionRequestData data ;
}


