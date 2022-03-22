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
    public bool used = false;

    public Mahjong(int a, string b, int c, Sprite sprite, bool d)
    {
        rank = a;
        patt = b;
        num = c;
        sprites = sprite;
        used = d;
    }
}
[System.Serializable]
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
    Mahjong[] Rmahjongs = new Mahjong[136];
    public Mahjong[] pmahjongs = new Mahjong[13];
    public Button[] buttons = new Button[14];
    public Sprite[] sprites = new Sprite[37];
    public Pedigree[] pedigrees = new Pedigree[48];
    string[] pedname = new string[4];
    public Player[] players = new Player[4];
    public List<Mahjong> Lmahjongs = new List<Mahjong>();
    public List<Mahjong> Tmahjongs = new List<Mahjong>();
    private void Awake()
    {





    }
    void Msetup()
    {
        pedname[0] = "Character";
        pedname[1] = "Circle";
        pedname[2] = "Bamboo";
        pedname[3] = "Drangons";
        for (int i = 0; i < mahjongs.Length; i++)
        {
            mahjongs[i] = new Mahjong(0, "NULL", 0, sprites[0], false);
        }

        for (int i = 0; i < mahjongs.Length; i++)
        {
            mahjongs[i].rank = i;
        }
        for (int j = 0; j < 3; j++)
        {
            for (int i = 0; i < 36; i++)
            {
                mahjongs[i + 36 * j].patt = pedname[j];
            }
        }
        int num = 0;
        for (int i = 0; i < 9; i++)
        {
            for (int j = 1; j % 5 != 0; j++)
            {
                mahjongs[num].num = i + 1;
                mahjongs[num].sprites = sprites[i];
                num++;
            }
        }
        num = 0;
        for (int i = 0; i < 9; i++)
        {
            for (int j = 1; j % 5 != 0; j++)
            {
                mahjongs[36 + num].num = i + 1;
                mahjongs[36 + num].sprites = sprites[9 + i];
                num++;
            }
        }
        num = 0;
        for (int i = 0; i < 9; i++)
        {
            for (int j = 1; j % 5 != 0; j++)
            {
                mahjongs[72 + num].num = i + 1;
                mahjongs[72 + num].sprites = sprites[18 + i];
                num++;
            }
        }


        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                mahjongs[108 + (4 * i) + j] = new Mahjong(108 + (4 * i) + j, pedname[3], i, sprites[27 + i], false);
            }

        }
       
       
    }
    void SplitM()
    {
        int random = 0;
        for (int i = 0; i < Rmahjongs.Length; i++)
        {
            Rmahjongs[i] = mahjongs[i];
        }
        for (int i = 0; i < Rmahjongs.Length; i++)
        {
            random = Random.Range(0, 136);
            Mahjong mahjong;
            mahjong = Rmahjongs[i];
            Rmahjongs[i] = Rmahjongs[random];
            Rmahjongs[random] = mahjong;
        }

        for (int i = 0; i < pmahjongs.Length; i++)
        {
            Rmahjongs[i].used = true;
            pmahjongs[i] = Rmahjongs[i];
            
        }

    }
    void ArrayM()
    {
        for(int i=0; i<pmahjongs.Length; i++)
        {
            int num = 1;
            while (num + i < pmahjongs.Length)
            {
                if (pmahjongs[i].rank > pmahjongs[i + num].rank&& pmahjongs[i + num].num !=0)
                {
                    Mahjong mahjong;
                    mahjong = pmahjongs[i];
                    pmahjongs[i] = pmahjongs[i + num];
                    pmahjongs[i + num] = mahjong;
                }
                else num++;
            }

            
          
        }
        
   
    }

    void GetM()
    {

        if (GetComponent<Player>().turned)
        {
            for(int i=0; i < Rmahjongs.Length; i++)
            {
                if (!Rmahjongs[i].used)
                {
                    Mahjong mahjong;
                    mahjong = Rmahjongs[i];
                    Rmahjongs[i].used = true;
                    Lmahjongs.Add(mahjong);
                    break;
                }
              
            }
            
            Button button = transform.GetChild(buttons.Length - 1).GetComponent<Button>();
            buttons[buttons.Length-1] = button;
            buttons[buttons.Length - 1].image.sprite = Lmahjongs[0].sprites;
            players[0].turned = false;
        }
    }
    public void MThrow(int a)
    {
        if( a!= 13)
        {
            Tmahjongs.Add(pmahjongs[a]);
            pmahjongs[a] = Lmahjongs[0];
            Lmahjongs.Remove(Lmahjongs[0]);
            ArrayM();
        }
       else
        {

        }
       
    }
    void Start()
    {

        Msetup();
        SplitM();
        ArrayM();


        players[0].wind = "East";
        
      

        
         for (int i = 0; i < buttons.Length - 1; i++)
            {
                Button button = transform.GetChild(i).GetComponent<Button>();
                buttons[i] = button;
                buttons[i].image.sprite = pmahjongs[i].sprites;
            }
        
        if (players[0].wind == "East")
        {
            players[0].turned = true;
        }
    }
        // Update is called once per frame
        void Update()
        {
        GetM();
        }
    }

