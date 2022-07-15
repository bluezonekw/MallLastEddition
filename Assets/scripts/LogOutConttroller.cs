using RestSharp;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogOutConttroller : MonoBehaviour
{
    public GameObject loading;
   public void logout()
    {

     string   savePath = Application.persistentDataPath + Path.DirectorySeparatorChar + "savedGames.sx";

        if (File.Exists(savePath))
        {
            //SaveLoad.savedGames.Clear();
            File.Delete(savePath);
         
            // Debug.Log( "Data delete in : (       " + savePath + "       )  ");

        }
        else
        {
            // Debug.Log("notdelete");

        }

        loading.SetActive(true);

        var client = new RestClient("https://mymall-kw.com/api/V1/logout");
        client.Timeout = -1;
        var request = new RestRequest(Method.POST);
        request.AddHeader("password_api", "mall_2021_m3m");
        request.AddHeader("lang_api", "ar");

        if(!UPDownMenu.Login)
        {
            request.AddHeader("auth-token",ApiClasses.Register.data.token);
            IRestResponse response = client.Execute(request);
        }
        else
        {
            request.AddHeader("auth-token", ApiClasses.Login.data.original.access_token);
            IRestResponse response = client.Execute(request);
        }
        VisitorLogin.logout=true;
        loadSceneWithName("UI");
    }
    public void loadSceneWithName(string scenename)
    {

        Debug.Log("sceneName to load: " + scenename);
        SceneManager.LoadScene(scenename);
        Debug.Log("sceneName to load: " + scenename);
    }
}
