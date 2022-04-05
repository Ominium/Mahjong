using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player : MonoBehaviour
{
    public static int startscore;
    public int score = 0;
    public string Pname = null;
    private bool cry = false;
    private bool riched = false;
    public bool turned = false;
    public string wind = null;
    private bool oya = false;
    private bool tenpai = false;
    public bool Cry
    {
        get { return cry; }
        set { cry = value; }
    }
    public bool Rich
    {
        get { return riched; }
        set { riched = value; }
    }
   
    public bool Oya
    {
        get { return oya; }
        set { oya = value; }

    }

    public bool Tenpaing
    {
        get { return tenpai; }
        set { tenpai = value; }
    }
    
  
    public Player(int a, string b, string c, bool d)
    {
        score = a;
        Pname = b;
        wind = c;
        turned = d;
    }

    void Start()
    {
        score = startscore;
    }

    void Update()
    {
        
    }
}
