using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICtrl : PlayerCtrl
{
   
    
    
    void Start()
    {
        
        player = gameObject.GetComponent<AI>();
        game = GameObject.Find("Canvas").GetComponent<GameManager>();
        ArrayM();
        ShowM();
       
        nextplayer = game.players[Find(0)];
        for (int i = 0; i < trs.Length; i++)
        {
            trs[i] = GameObject.Find("trs").GetComponent<Transform>().GetChild(i);
        }

    }
    IEnumerator AIthrow()
    {



        if (turning)
        {
            yield return new WaitForSeconds(1.2f);
            Tmahjongs.Add(Lmahjongs[0]);
             Lmahjongs.Remove(Lmahjongs[0]);
               
              turning = false;


            GameObject[] maj = new GameObject[50];
            maj[num2] = Instantiate(Tmahjongs[num2].prefab);
            maj[num2].transform.localScale = Vector3.one;
            maj[num2].transform.localRotation = Quaternion.identity;
            
            switch (Find(1))
            {
                case 0:
                    maj[num2].transform.position = new Vector3(trs[Find(1)].position.x + (float)(0.02 * num2), trs[Find(1)].position.y, trs[Find(1)].position.z);
                    maj[num2].transform.rotation = Quaternion.Euler(0, 180, 0);
                    break;
                case 1:
                    maj[num2].transform.position = new Vector3(trs[Find(1)].position.x, trs[Find(1)].position.y, trs[Find(1)].position.z + (float)(0.02 * num2));
                    maj[num2].transform.rotation = Quaternion.Euler(0, 90, 0);
                    break;
                case 2:
                    maj[num2].transform.position = new Vector3(trs[Find(1)].position.x - (float)(0.02 * num2), trs[Find(1)].position.y, trs[Find(1)].position.z);
                    break;
                case 3:
                    maj[num2].transform.position = new Vector3(trs[Find(1)].position.x, trs[Find(1)].position.y, trs[Find(1)].position.z - (float)(0.02 * num2));
                    maj[num2].transform.rotation = Quaternion.Euler(0, 270, 0);
                    break;





            }

            num2++;
            player.turned = false;
            nextplayer.turned = true;
          


        }
    }

    void Update()
    {
        if (player.turned)
        {
            GetM();
            turning = true;
           StartCoroutine( AIthrow());
          

        }
    }
}
