using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSound : MonoBehaviour
{
    public AudioSource a;
    public void play()
    {
        a.Play();
    }
}
