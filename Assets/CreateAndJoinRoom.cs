using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CreateAndJoinRoom : MonoBehaviour
{
    public TMP_InputField Text;
    public NetworkManager N;

    // Start is called before the first frame update
    public void CreateRoom()
    {
        
       N.JoinOrcreateRoom(Text.text);
    }
    private void OnEnable()
    {
        Text.text = "";
    }
}
