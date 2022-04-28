using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// /RegisterClass
/// </summary>
public class UserRegister
{
   public string name ;
        public string email ;
        public string phone ;
        public string address ;
        public string gander ;
        public int coins;
          public string image;
        public DateTime updated_at ;
        public DateTime created_at ;
        public int id;
}

public class DataRegister
{
    public UserRegister user ;
    public string token;
}

public class Register
{
    public int statsu ;
     public List<string> message ;
    public DataRegister data ;
}












////////LoginClass



public class Headers
{
}

public class UserLogin
{
     public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public object email_verified_at { get; set; }
        public int gander { get; set; }
        public int coins { get; set; }
        public string image { get; set; }
        public int total_orders_cost { get; set; }
        public int total_coins_spend { get; set; }
}

public class OriginalLogin
{
    public string access_token  { get; set; }
    public string token_type { get; set; }
    public int expires_in  { get; set; }
    public UserLogin user  { get; set; }
}

public class DataLogin
{
    public Headers headers { get; set; }
    public OriginalLogin original { get; set; }
    public object exception { get; set; }
}

public class Login
{
    public int statsu { get; set; }
    public string message { get; set; }
    public DataLogin data { get; set; }
}

