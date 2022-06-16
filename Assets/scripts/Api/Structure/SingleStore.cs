using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class StoreProfile
{
    public int id { get; set; }
    public int shipping_charges { get; set; }
    public int delivery_time_days { get; set; }
    public int delivery_time_hours { get; set; }
    public int delivery_time_minutes { get; set; }
    public string phone { get; set; }
    public string phone2 { get; set; }
    public string email_contact { get; set; }
    public string facebook { get; set; }
    public string instagram { get; set; }
    public string whatsapp { get; set; }
    public string twitter { get; set; }
    public bool special_discount { get; set; }
    public int discount_ratio { get; set; }
    public int discount_min_price { get; set; }
    public string how_to_buy { get; set; }
    public string terms { get; set; }
    public string retrieval { get; set; }
    public int store_id { get; set; }


}

public class StoreInfo
{
    public int id { get; set; }
    public int is_active { get; set; }
    public int category_id { get; set; }
    public string logo { get; set; }
    public string parent_id { get; set; }
    public string name { get; set; }
    public string welcome_message { get; set; }
    public StoreProfile profile { get; set; }
}

public class RightSlidder
{
    public string src { get; set; }
    public string type { get; set; }
}

public class CenterSlidder
{
    public string src { get; set; }
    public string type { get; set; }
}

public class LeftSlidder
{
    public string src { get; set; }
    public string type { get; set; }
}

public class Sliders
{
    public List<RightSlidder> right { get; set; }
    public List<CenterSlidder> center { get; set; }
    public List<LeftSlidder> left { get; set; }
}

public class ProductInfo
{
    public int id { get; set; }
    public string img { get; set; }
    public int section_id { get; set; }
    public bool in_favorite { get; set; }
    public string name { get; set; }
    public string description { get; set; }

}

public class SectionInfo
{
    public int id { get; set; }
    public string wall { get; set; }
    public string position { get; set; }
    public List<ProductInfo> products { get; set; }
}

public class SingleStoreRequest
{
    public StoreInfo store { get; set; }
    public Sliders sliders { get; set; }
    public List<SectionInfo> sections { get; set; }
}

public class FirstStoreRequest
{
    public int statsu { get; set; }
    public string message { get; set; }
    public SingleStoreRequest data { get; set; }
}
















/*
public class StoreProfile
{
    public int id { get; set; }
    public string phone { get; set; }
    public string phone2 { get; set; }
    public string email_contact { get; set; }
    public string facebook { get; set; }
    public string instagram { get; set; }
    public string whatsapp { get; set; }
    public string twitter { get; set; }
    public int store_id { get; set; }
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }
}

public class StoreMessage
{
   public int id { get; set; }
    public string name { get; set; }
    public string welcome_message { get; set; }
    public string locale { get; set; }
    public int store_id { get; set; }
}

public class StoreInfo
{
    public int id { get; set; }
    public StoreProfile profile { get; set; }
    public StoreMessage translation { get; set; }
}

public class RightSlider
{
    public string src { get; set; }
    public string type { get; set; }
}

public class CenterSlider
{
    public string src { get; set; }
    public string type { get; set; }
}

public class LeftSlider
{
    public string src { get; set; }
    public string type { get; set; }
}

public class Sliders
{
    public List<RightSlider> right { get; set; }
    public List<CenterSlider> center { get; set; }
    public List<LeftSlider> left { get; set; }
}

public class ExProduct
{
    public int id { get; set; }
    public string img { get; set; }
    public int section_id { get; set; }
}

public class SectionInfos
{
    public int id { get; set; }
    public string wall { get; set; }
    public string position { get; set; }
    public ExProduct Exproduct { get; set; }
}

public class StoreDatas
{
    public StoreInfo store { get; set; }
    public Sliders sliders { get; set; }
    public List<SectionInfos> sectionms { get; set; }
}

public class SingleStore
{
    public int statsu { get; set; }
    public string message { get; set; }
    public StoreDatas data { get; set; }
}*/