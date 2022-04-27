using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tsmahjongs
{
   
}

public class Tenpai : MonoBehaviour
{
  

    public PlayerCtrl playerCtrl;
    GameManager gameManager;
    int Pan = 0;
    int busu = 30;
    protected float oyascore = 1.0f;
    public static int ryunzzang = 0;
    bool playing = false;
    int body = 0;

    public bool Playing { 
        get { return playing; }
        set { playing = value; }
    }

    List<int> Mranks = new List<int>();
    List<string> Mpatton = new List<string>();
    private int CuzzCount;
    private int TTcount;
    private int SScount;
    public void GetMrs(List<Mahjong> mahjongs)
    {
        foreach (var Mah in mahjongs)
        {
            Mranks.Add(Mah.rank/ 4);
            Mpatton.Add(Mah.patt);
        }
    }
    void Game()
    {
        ReturnM(ref CuzzCount, ref TTcount, ref SScount);
    }
    public void ReturnM(ref int Cuzzc, ref int TTc, ref int SSc)
    {
        GetMrs(playerCtrl.pmahjongs);
            
        
        
    }



    public enum TenpaiState
    {
       
        Tenpai,
        Hworyo

    }
    public TenpaiState state;

 
    Pedigree Dora(Mahjong mahjong)
    {
        int Count = 0;
        if (playerCtrl.player.Rich)
        {

        }
        else
        {
            for (int i = 0; i < playerCtrl.pmahjongs.Count; i++)
            {
                if (playerCtrl.pmahjongs[i].patt == mahjong.patt)
                {
                    if (playerCtrl.pmahjongs[i].num == mahjong.num + 1)
                    {
                        Count++;

                        
                    }
                }
            }
        }
     
       
        Pedigree pedigree;
        pedigree = gameManager.pedigrees[40];
        pedigree.Pscore = Count+Akadora(gameManager.aka);
        pedigree.Pcryscore = Count + Akadora(gameManager.aka);




        return  pedigree; 
        
    }
    private int Akadora(bool aka)
    {
        int score = 0;
        if (aka)
        {
            for(int i=0; i<playerCtrl.pmahjongs.Count; i++)
            {
                if (playerCtrl.pmahjongs[i].Aka)
                {
                    score++;
                }
            }
            score++;
            
        }
       return score;
    }
    void Doraped()
    {
        for (int i = 0; i < Kkang.Kcount; i++)
        {

            playerCtrl.playerped.Add(Dora(playerCtrl.game.kingmah[i]));
        }
        
    }
    
    int Pancheak(List<Pedigree> pedigrees)
    {
        int Score = 0;
        if(playerCtrl.player.Cry)
        {
            for (int i = 0; i < pedigrees.Count; i++)
            {
                Score += pedigrees[i].Pcryscore;
            }
        }
        else
        {
            for (int i = 0; i < pedigrees.Count; i++)
            {
                Score += pedigrees[i].Pscore;
            }
        }
        
        return  Score;
        
    }
    public int RonScore()

    {
        if (playerCtrl.player.Oya)
        {
            oyascore = 1.5f;
        }
        Doraped();
        Pancheak(playerCtrl.playerped);


        switch (Pan)
        {
            case 1:
                if (busu < 30)
                {
                    return (int)(1000 * oyascore) + ryunzzang*300;
                }
                else if(busu < 40)
                {
                    return (int)(1300* oyascore) + ryunzzang * 300;
                }
                else if(busu < 50)
                {
                    return (int)(1500* oyascore) + ryunzzang * 300;
                }
                else if (busu < 60)
                {
                    return (int)(1600 * oyascore) + ryunzzang * 300;
                }
                else if (busu < 70)
                {
                    return (int)(2000 * oyascore) + ryunzzang * 300;
                }
                else if (busu < 80)
                {
                    return (int)(2300 * oyascore) + ryunzzang * 300;
                }
                else if (busu < 90)
                {
                    return (int)(2600 * oyascore) + ryunzzang * 300;
                }
                else if (busu < 100)
                {
                    return (int)(2900 * oyascore) + ryunzzang * 300;
                }
                else if (busu < 110)
                {
                    return (int)(3200 * oyascore) + ryunzzang * 300;
                }
                else if (busu > 110)
                {
                    return (int)(3600 * oyascore) + ryunzzang * 300;
                }
                break;
            case 2:
                if (busu < 25)
                {
                    return (int)(1300 * oyascore) + ryunzzang * 300;
                }
                else if (busu < 30)
                {
                    return (int)(1600 * oyascore) + ryunzzang * 300;
                }
                else if (busu < 40)
                {
                    return (int)(2000 * oyascore) + ryunzzang * 300;
                }
                else if (busu < 50)
                {
                    return (int)(2600 * oyascore) + ryunzzang * 300;
                }
                else if (busu < 60)
                {
                    return (int)(3200 * oyascore) + ryunzzang * 300;
                }
                else if (busu < 70)
                {
                    return (int)(3900 * oyascore) + ryunzzang * 300;
                }
                else if (busu < 80)
                {
                    return (int)(4500 * oyascore) + ryunzzang * 300;
                }
                else if (busu < 90)
                {
                    return (int)(5200 * oyascore) + ryunzzang * 300;
                }
                else if (busu < 100)
                {
                    return (int)(5800 * oyascore) + ryunzzang * 300;
                }
                else if (busu < 110)
                {
                    return (int)(6400 * oyascore) + ryunzzang * 300;
                }
                else if (busu > 110)
                {
                    return (int)(7100 * oyascore) + ryunzzang * 300;
                }
                break;
            case 3:
                if (busu < 25)
                {
                    return (int)(2600 * oyascore) + ryunzzang * 300;
                }
                else if (busu < 30)
                {
                    return (int)(3200 * oyascore) + ryunzzang * 300;
                }
                else if (busu < 40)
                {
                    return (int)(3900 * oyascore) + ryunzzang * 300;
                }
                else if (busu < 50)
                {
                    return (int)(5200 * oyascore) + ryunzzang * 300;
                }
                else if (busu < 60)
                {
                    return (int)(6400 * oyascore) + ryunzzang * 300;
                }
                else if (busu < 70)
                {
                    return (int)(7700 * oyascore) + ryunzzang * 300;
                }
                else if (busu >= 70)
                {
                    return (int)(8000 * oyascore) + ryunzzang * 300;
                }
               
                break;
            case 4:
                if (busu < 25)
                {
                    return (int)(5200 * oyascore) + ryunzzang * 300;
                }
                else if (busu < 30)
                {
                    return (int)(6400 * oyascore) + ryunzzang * 300;
                }
                else if (busu < 40)
                {
                    return (int)(7700 * oyascore) + ryunzzang * 300;
                }
                else if (busu >= 40)
                {
                    return (int)(8000 * oyascore) + ryunzzang * 300;
                }
              
                 break;
            case 5:
                return (int)(8000 * oyascore) + ryunzzang * 300;
               
            case 6:
                return (int)(12000 * oyascore) + ryunzzang * 300;
                
            case 7:
                return (int)(12000 * oyascore) + ryunzzang * 300;
                
            case 8:
                return (int)(16000 * oyascore) + ryunzzang * 300;
              
            case 9:
                return (int)(16000 * oyascore) + ryunzzang * 300;
                
            case 10:
                return (int)(24000 * oyascore) + ryunzzang * 300;
               
            case 11:
                return (int)(24000 * oyascore) + ryunzzang * 300;
            case 12:
                return (int)(24000 * oyascore) + ryunzzang * 300;
            case 13:
                return (int)(32000 * oyascore) + ryunzzang * 300;
            case 26:
                return (int)(64000 * oyascore) + ryunzzang * 300;
            case 39:
                return (int)(96000 * oyascore) + ryunzzang * 300;
            case 52:
                return (int)(128000 * oyascore) + ryunzzang * 300;
            case 65:
                return (int)(160000 * oyascore) + ryunzzang * 300;
            case 78:
                return (int)(192000 * oyascore) + ryunzzang * 300;
            case 91:
                return (int)(224000 * oyascore) + ryunzzang * 300;

            default:
                if (Pan > 13 && Pan < 26)
                {
                    return (int)(32000 * oyascore) + ryunzzang * 300;
                }
               
              
                break;

               
        }


        return 0;

    }

    private void Start()
    {
        gameManager = GameObject.Find("Canvas").GetComponent<GameManager>();

        
       
    }

    private void Update()
    {
       
        

    }


}
