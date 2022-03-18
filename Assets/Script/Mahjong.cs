using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mahjong :MonoBehaviour
{
    public int rank; //¼ø¹ø
    public string patt;
    public int num;
    public Sprite sprites;
    public Mahjong(int a,string b,int c,Sprite sprite)
    {
        rank = a;
        patt = b;
        num = c;
        sprites = sprite;
    }
}
