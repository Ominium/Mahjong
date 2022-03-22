using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player : MonoBehaviour
{
    public int score = 0;
    public string Pname = null;
    public bool cry = false;
    public bool riched = false;
    public bool turned = false;
    public string wind = null;

    public Player(int a, string b, string c)
    {
        score = a;
        Pname = b;
        wind = c;
    }

    void Start()
    {
      
    }

    void Update()
    {
        
    }
}
