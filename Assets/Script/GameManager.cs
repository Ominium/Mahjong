using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Mahjong
{
    public int rank; //¼ø¹ø
    public string patt;
    public int num;
    public Sprite sprites;
    public Mahjong(int a, string b, int c, Sprite sprite)
    {
        rank = a;
        patt = b;
        num = c;
        sprites = sprite;
    }
}

public class Pedigree
{
    public int Pscore;
    public int Pcryscore;
    public string Pname;
    public bool Pcry;
    public Pedigree(int a, int b, string c, bool d)
    {   Pscore = a;
        Pcryscore = b;
        Pname = c;
        Pcry = d;
    }

}



public class GameManager : MonoBehaviour
{
    public Mahjong[] mahjongs = new Mahjong[136];
    public Mahjong[] pmahjongs = new Mahjong[14];
    public Button[] buttons = new Button[14];
    public Sprite[] sprites = new Sprite[34];
    public Pedigree[] pedigrees = new Pedigree[46];
    string[] pedname = new string[4];
    
    
    private void Awake()
    {

        Msetup();



    }
    void Msetup()
    {
        pedname[0] = "Character";
        pedname[1] = "Circle";
        pedname[2] = "Bamboo";
        pedname[3] = "Drangons";
        
        for (int i = 0; i < pedname.Length - 1; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                for (int k = 0; k < 5; k++)
                {
                    mahjongs[(9* i) +(4* j)+k] = new Mahjong((9* i) + (4* j) + k, pedname[i],j+1 , sprites[j+3*i]);
                }
               
            }   
        }
      
        for (int i = 0; i<7; i++)
        {
            for(int j= 0; j<4; j++)
            {
                mahjongs[108+ (4*i)+j] = new Mahjong(108 + (4 * i) + j + j, pedname[3], j + 1, sprites[28+i]);
            }
                
        }
           
        
    }
    void Start()
    {
       
    }
    void Send()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
