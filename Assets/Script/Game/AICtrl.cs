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



        if (turning)
        {
            turning = false;
            Tmahjongs.Add(pmahjongs[13]);
            pmahjongs.Remove(pmahjongs[13]);
            yield return new WaitForSeconds(1.2f);
            Mthrow2();


        }
    }
    private void Update()
    {
        StartCoroutine(FirstStart());
    }
    void LateUpdate()
    {
        time += Time.deltaTime;
       
        if (player.turned&&GameManager.Gstate == GameManager.GameState.Play)
        {
            GetM();
            turning = true;
           StartCoroutine( AIthrow());
          

        }
    }
}
