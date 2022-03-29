using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public GameManager game;
    public Player player;
    List<Pedigree> playerped = new List<Pedigree>();
    void Hwaryo()
    {
        int Pan = 0;
        int busu = 0;
        int score = 0;
        if (Pan > 4&& (busu >=40|| Pan >= 4))
        {
            score = 8000;
            if(Pan > 5)
            {
                score = 12000;
            }
            if (Pan > 7)
            {
                score = 16000;
            }
            if (Pan > 9)
            {
                score = 24000;
            }
            if (Pan > 12)
            {
                score = 32000;
            }
            
        }


        if (player.oya)
        {
            score = (int)(score * 1.5);
        }


    }
    int Returnped()
    {
        int ddoiz = 0;
        int cuzz= 0;
        int sunz = 0;
        int count;
        for(count = 0; count < game.pmahjongs.Length-1; count++)
        {
            if(game.pmahjongs[count].patt != "Dragon")
            {
                if(game.pmahjongs[count].patt == game.pmahjongs[count + 1].patt)
                {
                    if(game.pmahjongs[count].num == game.pmahjongs[count + 1].num)
                    {
                        if((game.pmahjongs[count].num == game.pmahjongs[count + 2].num)&& game.pmahjongs[count].patt == game.pmahjongs[count + 2].patt)
                        {
                            cuzz++;
                            count = count + 3;
                        }
                        else if (game.pmahjongs[count].num == game.pmahjongs[count + 1].num - 1 && game.pmahjongs[count + 1].num - 1 == game.pmahjongs[count + 1].num - 2)
                        {
                            sunz++;
                            count = count + 3;
                        };

                    }
                    else if(game.pmahjongs[count].num == game.pmahjongs[count + 1].num-1&& game.pmahjongs[count + 1].num - 1== game.pmahjongs[count + 1].num - 2&& game.pmahjongs[count].patt == game.pmahjongs[count + 2].patt)
                    {
                        sunz++;
                        count = count + 3;
                    
                     }

                }
                
            }
        }
        return 0;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
