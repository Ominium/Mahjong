using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

public class GameManager : MonoBehaviour
{
    public Mahjong[] mahjongs = new Mahjong[136];

    public GameManager(Mahjong[] mahjongs)
    {
        this.mahjongs = mahjongs;
    }

    public Mahjong[] pmahjongs = new Mahjong[14];
    public Button[] buttons = new Button[14];
    public Sprite[] sprites = new Sprite[34];
    private void Awake()
    {
        
        for(int i=0; i < pmahjongs.Length; i++)
        {
            pmahjongs[i] = new Mahjong(0, "NULL",0, sprites[0]);
        }
        for(int i = 0; i < mahjongs.Length; i++)
        {
            mahjongs[i].rank = i;
        }
        
    }
    void Start()
    {
        for(int i = 0; i < buttons.Length; i++)
        {
            
        }   
    }
    void Send()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
