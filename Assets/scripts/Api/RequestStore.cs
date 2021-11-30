using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Profile
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

public class SliderApi
{
    public int id { get; set; }
    public string src { get; set; }
    public string type { get; set; }
    public int sort { get; set; }
    public int store_id { get; set; }
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }
    public string wall { get; set; }
    public string src_path { get; set; }
}

public class TranslationApi
{
    public int id { get; set; }
    public string name { get; set; }
    public string welcome_message { get; set; }
    public string locale { get; set; }
    public int store_id { get; set; }
}

public class Store
{
    public int id { get; set; }
    public string email { get; set; }
    public int is_active { get; set; }
    public string logo { get; set; }
    public int position_id { get; set; }
    public int shipping_charges { get; set; }
    public int category_id { get; set; }
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }
    public DateTime email_verified_at { get; set; }
    public string banner { get; set; }
    public string logo_path { get; set; }
    public string banner_path { get; set; }
    public string name { get; set; }
    public string welcome_message { get; set; }
    public Profile profile { get; set; }
    public List<SliderApi> sliders { get; set; }
    public List<TranslationApi> translations { get; set; }
}

public class Section
{
    public int id { get; set; }
    public string name { get; set; }
    public int sort { get; set; }
    public string wall { get; set; }
    public int is_active { get; set; }
    public int store_id { get; set; }
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }
}

public class Option
{
    public int id { get; set; }
    public string name_ar { get; set; }
    public string name_en { get; set; }
    public int price { get; set; }
    public string sort { get; set; }
    public int attribute_id { get; set; }
    public int quantity { get; set; }
    public string name { get; set; }
}

public class Attribute
{
    public int id { get; set; }
    public string name_ar { get; set; }
    public string name_en { get; set; }
    public int type { get; set; }
    public int is_required { get; set; }
    public int product_id { get; set; }
    public string sort { get; set; }
    public string name { get; set; }
    public List<Option> options { get; set; }
}

public class Translation2
{
    public int id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public string locale { get; set; }
    public int product_id { get; set; }
}

public class _0
{
    public int id { get; set; }
    public string img { get; set; }
    public int regular_price { get; set; }
    public object sale_price { get; set; }
    public int is_active { get; set; }
    public string img_path { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public List<object> imagesrequest { get; set; }
    public List<Attribute> attributes { get; set; }
    public TranslationApi translation { get; set; }
}

public class _17
{
    public int id { get; set; }
    public string img { get; set; }
    public int regular_price { get; set; }
    public object sale_price { get; set; }
    public int is_active { get; set; }
    public string img_path { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public List<object> imagesrequest { get; set; }
    public List<Attribute> attributes { get; set; }
    public TranslationApi translation { get; set; }
}

public class _21
{
    public int id { get; set; }
    public string img { get; set; }
    public int regular_price { get; set; }
    public object sale_price { get; set; }
    public int is_active { get; set; }
    public string img_path { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public List<object> imagesrequest { get; set; }
    public List<Attribute> attributes { get; set; }
    public TranslationApi translation { get; set; }
}

public class _22
{
    public int id { get; set; }
    public string img { get; set; }
    public int regular_price { get; set; }
    public object sale_price { get; set; }
    public int is_active { get; set; }
    public string img_path { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public List<object> imagesRequest { get; set; }
    public List<Attribute> attributes { get; set; }
    public TranslationApi translation { get; set; }
}

public class ImageAPi
{
    public int id { get; set; }
    public string name { get; set; }
    public int store_id { get; set; }
    public int product_id { get; set; }
    public string gallery_path { get; set; }
}

public class _33
{
    public int id { get; set; }
    public string img { get; set; }
    public int regular_price { get; set; }
    public object sale_price { get; set; }
    public int is_active { get; set; }
    public string img_path { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public List<ImageAPi> imagesrequest { get; set; }
    public List<Attribute> attributes { get; set; }
    public TranslationApi translation { get; set; }
}

public class _283
{
    public _0 _0 { get; set; }
    public _17 _17 { get; set; }
    public _21 _21 { get; set; }
    public _22 _22 { get; set; }
    public _33 _33 { get; set; }
}

public class _7
{
    public int id { get; set; }
    public string img { get; set; }
    public int regular_price { get; set; }
    public object sale_price { get; set; }
    public int is_active { get; set; }
    public string img_path { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public List<object> imagesRequest { get; set; }
    public List<Attribute> attributes { get; set; }
    public TranslationApi translation { get; set; }
}

public class _15
{
    public int id { get; set; }
    public string img { get; set; }
    public int regular_price { get; set; }
    public object sale_price { get; set; }
    public int is_active { get; set; }
    public string img_path { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public List<object> images { get; set; }
    public List<Attribute> attributes { get; set; }
    public TranslationApi translation { get; set; }
}

public class _26
{
    public int id { get; set; }
    public string img { get; set; }
    public int regular_price { get; set; }
    public object sale_price { get; set; }
    public int is_active { get; set; }
    public string img_path { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public List<ImageAPi> images { get; set; }
    public List<Attribute> attributes { get; set; }
    public TranslationApi translation { get; set; }
}

public class _30
{
    public int id { get; set; }
    public string img { get; set; }
    public int regular_price { get; set; }
    public object sale_price { get; set; }
    public int is_active { get; set; }
    public string img_path { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public List<ImageAPi> images { get; set; }
    public List<Attribute> attributes { get; set; }
    public TranslationApi translation { get; set; }
}

public class _284
{
    public _7 _7 { get; set; }
    public _15 _15 { get; set; }
    public _26 _26 { get; set; }
    public _30 _30 { get; set; }
}

public class _1
{
    public int id { get; set; }
    public string img { get; set; }
    public int regular_price { get; set; }
    public object sale_price { get; set; }
    public int is_active { get; set; }
    public string img_path { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public List<object> images { get; set; }
    public List<Attribute> attributes { get; set; }
    public TranslationApi translation { get; set; }
}

public class _8
{
    public int id { get; set; }
    public string img { get; set; }
    public int regular_price { get; set; }
    public object sale_price { get; set; }
    public int is_active { get; set; }
    public string img_path { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public List<object> images { get; set; }
    public List<Attribute> attributes { get; set; }
    public TranslationApi translation { get; set; }
}

public class _285
{
    public _1 _1 { get; set; }
    public _8 _8 { get; set; }
}

public class _2
{
    public int id { get; set; }
    public string img { get; set; }
    public int regular_price { get; set; }
    public object sale_price { get; set; }
    public int is_active { get; set; }
    public string img_path { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public List<object> images { get; set; }
    public List<Attribute> attributes { get; set; }
    public TranslationApi translation { get; set; }
}

public class _20
{
    public int id { get; set; }
    public string img { get; set; }
    public int regular_price { get; set; }
    public object sale_price { get; set; }
    public int is_active { get; set; }
    public string img_path { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public List<object> images { get; set; }
    public List<Attribute> attributes { get; set; }
    public TranslationApi translation { get; set; }
}

public class _32
{
    public int id { get; set; }
    public string img { get; set; }
    public int regular_price { get; set; }
    public object sale_price { get; set; }
    public int is_active { get; set; }
    public string img_path { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public List<ImageAPi> images { get; set; }
    public List<Attribute> attributes { get; set; }
    public TranslationApi translation { get; set; }
}

public class _286
{
    public _2 _2 { get; set; }
    public _20 _20 { get; set; }
    public _32 _32 { get; set; }
}

public class _4
{
    public int id { get; set; }
    public string img { get; set; }
    public int regular_price { get; set; }
    public object sale_price { get; set; }
    public int is_active { get; set; }
    public string img_path { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public List<object> images { get; set; }
    public List<Attribute> attributes { get; set; }
    public TranslationApi translation { get; set; }
}

public class _6
{
    public int id { get; set; }
    public string img { get; set; }
    public int regular_price { get; set; }
    public object sale_price { get; set; }
    public int is_active { get; set; }
    public string img_path { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public List<object> images { get; set; }
    public List<Attribute> attributes { get; set; }
    public TranslationApi translation { get; set; }
}

public class _16
{
    public int id { get; set; }
    public string img { get; set; }
    public int regular_price { get; set; }
    public object sale_price { get; set; }
    public int is_active { get; set; }
    public string img_path { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public List<object> images { get; set; }
    public List<Attribute> attributes { get; set; }
    public TranslationApi translation { get; set; }
}

public class _29
{
    public int id { get; set; }
    public string img { get; set; }
    public int regular_price { get; set; }
    public object sale_price { get; set; }
    public int is_active { get; set; }
    public string img_path { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public List<ImageAPi> images { get; set; }
    public List<Attribute> attributes { get; set; }
    public TranslationApi translation { get; set; }
}

public class _287
{
    public _4 _4 { get; set; }
    public _6 _6 { get; set; }
    public _16 _16 { get; set; }
    public _29 _29 { get; set; }
}

public class _5
{
    public int id { get; set; }
    public string img { get; set; }
    public int regular_price { get; set; }
    public object sale_price { get; set; }
    public int is_active { get; set; }
    public string img_path { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public List<object> images { get; set; }
    public List<Attribute> attributes { get; set; }
    public TranslationApi translation { get; set; }
}

public class _12
{
    public int id { get; set; }
    public string img { get; set; }
    public int regular_price { get; set; }
    public object sale_price { get; set; }
    public int is_active { get; set; }
    public string img_path { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public List<object> images { get; set; }
    public List<Attribute> attributes { get; set; }
    public TranslationApi translation { get; set; }
}

public class _18
{
    public int id { get; set; }
    public string img { get; set; }
    public int regular_price { get; set; }
    public object sale_price { get; set; }
    public int is_active { get; set; }
    public string img_path { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public List<object> images { get; set; }
    public List<object> attributes { get; set; }
    public TranslationApi translation { get; set; }
}

public class _24
{
    public int id { get; set; }
    public string img { get; set; }
    public int regular_price { get; set; }
    public object sale_price { get; set; }
    public int is_active { get; set; }
    public string img_path { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public List<ImageAPi> images { get; set; }
    public List<Attribute> attributes { get; set; }
    public TranslationApi translation { get; set; }
}

public class _31
{
    public int id { get; set; }
    public string img { get; set; }
    public int regular_price { get; set; }
    public object sale_price { get; set; }
    public int is_active { get; set; }
    public string img_path { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public List<ImageAPi> images { get; set; }
    public List<Attribute> attributes { get; set; }
    public TranslationApi translation { get; set; }
}

public class _288
{
    public _5 _5 { get; set; }
    public _12 _12 { get; set; }
    public _18 _18 { get; set; }
    public _24 _24 { get; set; }
    public _31 _31 { get; set; }
}

public class _13
{
    public int id { get; set; }
    public string img { get; set; }
    public int regular_price { get; set; }
    public object sale_price { get; set; }
    public int is_active { get; set; }
    public string img_path { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public List<object> images { get; set; }
    public List<Attribute> attributes { get; set; }
    public TranslationApi translation { get; set; }
}

public class _19
{
    public int id { get; set; }
    public string img { get; set; }
    public int regular_price { get; set; }
    public object sale_price { get; set; }
    public int is_active { get; set; }
    public string img_path { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public List<object> images { get; set; }
    public List<Attribute> attributes { get; set; }
    public TranslationApi translation { get; set; }
}

public class _34
{
    public int id { get; set; }
    public string img { get; set; }
    public int regular_price { get; set; }
    public object sale_price { get; set; }
    public int is_active { get; set; }
    public string img_path { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public List<ImageAPi> images { get; set; }
    public List<Attribute> attributes { get; set; }
    public TranslationApi translation { get; set; }
}

public class _289
{
    public _13 _13 { get; set; }
    public _19 _19 { get; set; }
    public _34 _34 { get; set; }
}

public class _3
{
    public int id { get; set; }
    public string img { get; set; }
    public int regular_price { get; set; }
    public object sale_price { get; set; }
    public int is_active { get; set; }
    public string img_path { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public List<object> images { get; set; }
    public List<Attribute> attributes { get; set; }
    public TranslationApi translation { get; set; }
}

public class _25
{
    public int id { get; set; }
    public string img { get; set; }
    public int regular_price { get; set; }
    public object sale_price { get; set; }
    public int is_active { get; set; }
    public string img_path { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public List<ImageAPi> images { get; set; }
    public List<Attribute> attributes { get; set; }
    public TranslationApi translation { get; set; }
}

public class _27
{
    public int id { get; set; }
    public string img { get; set; }
    public int regular_price { get; set; }
    public object sale_price { get; set; }
    public int is_active { get; set; }
    public string img_path { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public List<ImageAPi> images { get; set; }
    public List<Attribute> attributes { get; set; }
    public TranslationApi translation { get; set; }
}

public class _28
{
    public int id { get; set; }
    public string img { get; set; }
    public int regular_price { get; set; }
    public object sale_price { get; set; }
    public int is_active { get; set; }
    public string img_path { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public List<ImageAPi> images { get; set; }
    public List<Attribute> attributes { get; set; }
    public TranslationApi translation { get; set; }
}

public class _290
{
    public _3 _3 { get; set; }
    public _25 _25 { get; set; }
    public _27 _27 { get; set; }
    public _28 _28 { get; set; }
}

public class _9
{
    public int id { get; set; }
    public string img { get; set; }
    public int regular_price { get; set; }
    public object sale_price { get; set; }
    public int is_active { get; set; }
    public string img_path { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public List<object> images { get; set; }
    public List<Attribute> attributes { get; set; }
    public TranslationApi translation { get; set; }
}

public class _10
{
    public int id { get; set; }
    public string img { get; set; }
    public int regular_price { get; set; }
    public object sale_price { get; set; }
    public int is_active { get; set; }
    public string img_path { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public List<object> images { get; set; }
    public List<Attribute> attributes { get; set; }
    public TranslationApi translation { get; set; }
}

public class _11
{
    public int id { get; set; }
    public string img { get; set; }
    public int regular_price { get; set; }
    public object sale_price { get; set; }
    public int is_active { get; set; }
    public string img_path { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public List<object> images { get; set; }
    public List<Attribute> attributes { get; set; }
    public TranslationApi translation { get; set; }
}

public class _14
{
    public int id { get; set; }
    public string img { get; set; }
    public int regular_price { get; set; }
    public object sale_price { get; set; }
    public int is_active { get; set; }
    public string img_path { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public List<object> images { get; set; }
    public List<Attribute> attributes { get; set; }
    public TranslationApi translation { get; set; }
}

public class _23
{
    public int id { get; set; }
    public string img { get; set; }
    public int regular_price { get; set; }
    public object sale_price { get; set; }
    public int is_active { get; set; }
    public string img_path { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public List<object> imagesRequest { get; set; }
    public List<Attribute> attributes { get; set; }
    public TranslationApi translation { get; set; }
}

public class _291
{
    public _9 _9 { get; set; }
    public _10 _10 { get; set; }
    public _11 _11 { get; set; }
    public _14 _14 { get; set; }
    public _23 _23 { get; set; }
}

public class Products
{
    public _283 _283 { get; set; }
    public _284 _284 { get; set; }
    public _285 _285 { get; set; }
    public _286 _286 { get; set; }
    public _287 _287 { get; set; }
    public _288 _288 { get; set; }
    public _289 _289 { get; set; }
    public _290 _290 { get; set; }
    public _291 _291 { get; set; }
}

public class Data
{
    public Store store { get; set; }
    public List<Section> sections { get; set; }
    public Products products { get; set; }
}

public class RequestStore
{
    public int statsu { get; set; }
    public string message { get; set; }
    public Data data { get; set; }
}

