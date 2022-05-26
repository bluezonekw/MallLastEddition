
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystem 
{
    
    public static void Save<T>(T obj,string key)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path =Application.persistentDataPath + "\\Notifications" ;
       
        Debug.Log(path);
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        FileStream stream = new FileStream(path + key, FileMode.Create);
        formatter.Serialize(stream, obj);
        stream.Close();
        Debug.Log("Mc");


    }





    public static T Load<T>( string key)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Notifications/"  + key;
        T obj = default;
        if (File.Exists(path))
        {
            FileStream stream1 = new FileStream(path, FileMode.Open);
            obj = (T)formatter.Deserialize(stream1);

            stream1.Close();

        }
        else
        {
            Debug.Log(path  + "       not found");
        }

        return obj;


    }
    
    public static bool SaveExits(string Key)
    {
        string path = Application.persistentDataPath + Path.DirectorySeparatorChar + "Notifications" + Path.DirectorySeparatorChar + Key;
        return File.Exists(path);
    }

}
