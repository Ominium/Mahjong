using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Tsmahjongs
{
    public List<Mahjong> mahjongs = new List<Mahjong>();
    

}

public class Tenpai : MonoBehaviour
{
    public List<List<Mahjong>> Mahjongs = new List<List<Mahjong>>();
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
   

    public List<List<Mahjong>> tsmahjongs = new List<List<Mahjong>>();
    public List<Mahjong> ttmahjongs = new List<Mahjong>();
    public List<Mahjong> ssmahjongs = new List<Mahjong>();
    public List<Mahjong> playerMahjong = new List<Mahjong> { };



    public enum TenpaiState
    {
       
        Tenpai,
        Hworyo
    }
    void testcheak()
    {

        if (playing)
        {

            playing = false;


            tsmahjongs.Clear();
            ttmahjongs.Clear();
            ssmahjongs.Clear();
            int sscount = 1;
            playerMahjong.AddRange(playerCtrl.pmahjongs);
            while (playerMahjong.Count != 0)
            {

                ttmahjongs.Add(playerMahjong[0]);
                ssmahjongs.Add(playerMahjong[0]);
                playerMahjong.RemoveAt(0);
                for (int j = 0; j < playerMahjong.Count; j++)
                {

                    if (ttmahjongs[0].rank == 0)
                    {

                        if (playerCtrl.pmahjongs[j].rank / 4 == 0)
                        {
                            ttmahjongs.Add(playerMahjong[j]);
                            playerMahjong.RemoveAt(j);
                        }
                        else if (playerCtrl.pmahjongs[j].rank / 4 == sscount)
                        {
                            ssmahjongs.Add(playerMahjong[j]);
                            playerMahjong.RemoveAt(j);
                            sscount++;

                        }
                    }
                    else
                    {
                        sscount = (ttmahjongs[0].rank / 4) + 1;
                        if (ttmahjongs[0].rank / 4 == playerMahjong[j].rank / 4)
                        {
                            ttmahjongs.Add(playerMahjong[j]);
                            playerMahjong.RemoveAt(j);
                        }
                        else if (playerCtrl.pmahjongs[j].rank / 4 == sscount)
                        {
                            ssmahjongs.Add(playerMahjong[j]);
                            playerMahjong.RemoveAt(j);
                        }
                    }
                    if (ttmahjongs.Count == 3)
                    {
                        tsmahjongs.Add(new List<Mahjong>(ttmahjongs));
                        ttmahjongs.Clear();
                    }
                    if (ttmahjongs.Count == 2 && j == playerMahjong.Count - 1)
                    {
                        tsmahjongs.Add(new List<Mahjong>(ttmahjongs));
                        ttmahjongs.Clear();
                    }
                    if (ssmahjongs.Count == 3)
                    {
                        tsmahjongs.Add(new List<Mahjong>(ssmahjongs));
                        ssmahjongs.Clear();
                    }
                    if (ssmahjongs.Count == 2 && j == playerMahjong.Count - 1)
                    {
                        tsmahjongs.Add(new List<Mahjong>(ssmahjongs));
                        ssmahjongs.Clear();
                    }
                    if (ttmahjongs.Count == 1 && j == playerMahjong.Count - 1)
                    {
                        tsmahjongs.Add(new List<Mahjong>(ttmahjongs));
                        ttmahjongs.Clear();
                    }

                    if (ssmahjongs.Count == 1 && j == playerMahjong.Count - 1)
                    {
                        tsmahjongs.Add(new List<Mahjong>(ssmahjongs));
                        ssmahjongs.Clear();
                    }


                }
                for (int i = 0; i < tsmahjongs.Count; i++)
                {
                    for (int j = 0; j < tsmahjongs[i].Count; j++)
                    {

                        Debug.Log(tsmahjongs[i][j].num);

                    }
                }

            }
        }
    }
    /*
    for (int i = 0; i < playerCtrl.pmahjongs.Count -1; i++)
    {
        ttmahjongs.Clear();
        ssmahjongs.Clear();
        ttmahjongs.Add(playerCtrl.pmahjongs[i]);
        ssmahjongs.Add(playerCtrl.pmahjongs[i]);              

        for (int j = i +1 ; j < playerCtrl.pmahjongs.Count; j++)
        {

            if (playerCtrl.pmahjongs[i].rank == 0)
            {
                if (playerCtrl.pmahjongs[j].rank / 4 == 0)
                {
                    ttmahjongs.Add(playerCtrl.pmahjongs[j]);
                    if (ttmahjongs.Count > 2)
                    {
                        tsmahjongs.Add(new List<Mahjong>(ttmahjongs));
                        ttmahjongs.Clear();
                        if (i < playerCtrl.pmahjongs.Count - 2)
                        {
                            i = i + 2;
                        }                               
                        else
                        {
                            break;
                        }

                        break;
                    }
                }
            }
            else if ((playerCtrl.pmahjongs[i].rank / 4) == playerCtrl.pmahjongs[j].rank / 4)
            {
                ttmahjongs.Add(playerCtrl.pmahjongs[j]);
                if (ttmahjongs.Count > 2)
                {
                    tsmahjongs.Add(new List<Mahjong>(ttmahjongs));
                    ttmahjongs.Clear();
                    if (i < playerCtrl.pmahjongs.Count - 2)
                    {
                        i = i + 2;
                    }                       
                    else
                    {
                        break;
                    }
                    break;
                }
            }
            else if ((playerCtrl.pmahjongs[i].rank / 4) == (playerCtrl.pmahjongs[j].rank / 4) - 1)
            {
                ssmahjongs.Add(playerCtrl.pmahjongs[j]);
                if( j < playerCtrl.pmahjongs.Count - 1)
                {
                    for (int z = j + 1; z < playerCtrl.pmahjongs.Count; z++)
                    {
                        if ((playerCtrl.pmahjongs[j].rank / 4) == (playerCtrl.pmahjongs[z].rank / 4) - 1)
                        {
                            ssmahjongs.Add(playerCtrl.pmahjongs[z]);
                            if (z < playerCtrl.pmahjongs.Count - 1)
                            {
                                i
                            }
                            break;
                        }

                    }
                }

                if (ssmahjongs.Count > 2)
                {
                    tsmahjongs.Add(new List<Mahjong>(ssmahjongs));

                    ssmahjongs.Clear();


                    break;
                }
                else
                {
                    tsmahjongs.Add(new List<Mahjong>(ssmahjongs));

                    ssmahjongs.Clear();
                }
            }
            else if((playerCtrl.pmahjongs[i].rank / 4) == (playerCtrl.pmahjongs[j].rank / 4) - 2)
            {
                ssmahjongs.Add(playerCtrl.pmahjongs[j]);

            }
        }

        if (ttmahjongs.Count == 2)
        {
            tsmahjongs.Add(new List<Mahjong>(ttmahjongs));
            ttmahjongs.Clear();                  
            i++;
            if(i ==playerCtrl.pmahjongs.Count)
            {
                break;
            }

        }


    }

    for(int i= 0; i < playerCtrl.Cmahjongs.Count; i++)
    {
        tsmahjongs.Add(playerCtrl.Cmahjongs[i]);
    }


    for(int i= 0; i<tsmahjongs.Count; i++)
    {
        for(int j = 0; j< tsmahjongs[i].Count; j++)
        {

            Debug.Log(tsmahjongs[i][j].num);

        }
    }

}*/


    Pedigree tanchancheak()
    {

        return gameManager.pedigrees[13];
        return gameManager.pedigrees[5];
        return null;

    }
   
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
        pedigree.Pscore = Count;
        pedigree.Pcryscore = Count;




        return  pedigree; 
        
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
       
        testcheak();

    }

   void Cheak()
    {

    }

}
