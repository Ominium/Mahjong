using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICtrl : PlayerCtrl
{


   
    void Start()
    {
        AIcheak = true;
        StartPl();

        

    }
    IEnumerator AIthrow()
    {



        if (turning&&Lmahjongs.Count>0)
        {
            turning = false;
            Tmahjongs.Add(Lmahjongs[0]);
            Lmahjongs.Remove(Lmahjongs[0]);
            yield return new WaitForSeconds(0.02f);
            Mthrow2();


        }
    }
    private void Update()
    {
        StartCoroutine(FirstStart());
    }
    void LateUpdate()
    {
        if (player.turned&&GameManager.Gstate == GameManager.GameState.Play)
        {
            GetM();
            turning = true;
           StartCoroutine( AIthrow());
          

        }
    }
}
