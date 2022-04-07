using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Huro : MonoBehaviour
{
    private int HuroCount = 0;
    Player player;
    public int Huroget { get; set; }
   
    bool Cry()
    {
        if (HuroCount > 0)
        {
            return true;
        }
        return false;
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
       
    }

    // Update is called once per frame
    void Update()
    {
        player.Cry = Cry();
    }
}
