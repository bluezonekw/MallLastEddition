using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SectionRequestData
{
    public int id { get; set; }
    public string img { get; set; }
    public bool in_favorite { get; set; }
    public int current_page { get; set; }
    public List<SectionRequestData> data { get; set; }
    public string first_page_url { get; set; }
    public int from { get; set; }
    public string next_page_url { get; set; }
    public string path { get; set; }
    public string per_page { get; set; }
    public string prev_page_url { get; set; }
    public int to { get; set; }
}

public class SectionRequest
{
    public int statsu { get; set; }
    public string message { get; set; }
    public SectionRequestData data { get; set; }
}


