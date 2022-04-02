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
    public bool oya = false;
    public bool tenpai = false;
    public Player(int a, string b, string c, bool d)
    {
        score = a;
        Pname = b;
        wind = c;
        turned = d;
    }

    void Start()
    {
        score = 25000;
    }

    void Update()
    {
        
    }
}
