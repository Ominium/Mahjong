using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tenpai : MonoBehaviour
{
    public PlayerCtrl playerCtrl;
    
    int Pan;
    int busu;
    int Dora(Mahjong mahjong)
    {
        for(int i=0; i < playerCtrl.pmahjongs.Length; i++)
        {
            if(playerCtrl.pmahjongs[i].patt == mahjong.patt)
            {
                if(playerCtrl.pmahjongs[i].num == mahjong.num + 1)
                {
                    return Pan++;
                }
            }
        }
        return 0;
        
    }
    public int RonScore()
    {
        switch (Pan)
        {
            case 1:
                if (busu < 30)
                {
                    return 1000;
                }
                else if(busu < 40)
                {
                    return 1500;
                }
                else if(busu < 50)
                {
                    return 2000;
                }
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
            case 10:
                break;
            case 11:
                break;
            case 12:
                break;
            case 13:
                break;
            case 26:
                break;
            case 39:
                break;
            case 52:
                break;
            case 65:
                break;
            case 78:
                break;
            case 91:
                break;

            default:
                
                break;

               
        }


        return 0;

    }
    private void Start()
    {
           

    }

    private void Update()
    {
      


    }

   void Cheak()
    {

    }

}
