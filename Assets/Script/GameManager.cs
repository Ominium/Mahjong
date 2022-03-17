using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Mahjong[] mahjongs = new Mahjong[136];
    public Mahjong[] pmahjongs = new Mahjong[14];
    public Button[] buttons = new Button[14];
    GameManager game = new GameManager();
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
