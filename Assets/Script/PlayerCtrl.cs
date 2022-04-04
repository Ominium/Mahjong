using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour
{
    public GameManager game;
    public Player player;
    public Mahjong[] pmahjongs = new Mahjong[13];
    public List<Mahjong> Lmahjongs = new List<Mahjong>();
    public List<Mahjong> Tmahjongs = new List<Mahjong>();
    public Button[] buttons = new Button[14];
    public List<Pedigree> playerped = new List<Pedigree>();
    public bool turning = false;
    public Player nextplayer;
    public int num2 = 0;
    public Transform[] trs = new Transform[4];
   
    public Camera camera;


   public int Find(int a)
    {
        int num = 0;

        for (int i = 0; i < game.players.Length; i++)
        {
            num++;
            if (player.Pname == game.players[i].Pname)
            {


                break;

            }

        }

        if (num - a < game.players.Length)
        {

            return num -a;
        }
        else return 0;

    }
    void Start()
    {
        game = GameObject.Find("Canvas").GetComponent<GameManager>();
        player = gameObject.GetComponent<Player>();
        ArrayM();
        ShowM();
        camera = GameObject.Find("Camera").transform.GetChild(Find(1)).GetComponent<Camera>();
        nextplayer = game.players[Find(0)];
        camera.enabled = true;
        for(int i=0; i<trs.Length; i++)
        {
            trs[i] = GameObject.Find("trs").GetComponent<Transform>().GetChild(i);
        }
        

    }
    public void ArrayM()
    {
        for (int i = 0; i < pmahjongs.Length; i++)
        {
            int num = 1;
            while (num + i < pmahjongs.Length)
            {
                if (pmahjongs[i].rank > pmahjongs[i + num].rank && pmahjongs[i + num].num != 0)
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

    public void MThrow(int a)
    {



        if (turning)
        {
            if (a != 13)
            {
                turning = false;
                Tmahjongs.Add(pmahjongs[a]);
                pmahjongs[a] = Lmahjongs[0];
                Lmahjongs.Remove(Lmahjongs[0]);
                ArrayM();
                ShowM();


               
                Button button = game.transform.GetChild(0).GetChild(0).GetChild(buttons.Length - 1).GetComponent<Button>();
                button.gameObject.SetActive(false); ;


            }
            else
            {
                turning = false;
                Tmahjongs.Add(Lmahjongs[0]);
                Lmahjongs.Remove(Lmahjongs[0]);
                ShowM();
               
                Button button = game.transform.GetChild(0).GetChild(0).GetChild(buttons.Length - 1).GetComponent<Button>();
                button.gameObject.SetActive(false); ;
            }
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
    // Update is called once per frame
    void Update()
    {
        if (player.turned)
        {
            GetM();
            Button button = game.transform.GetChild(0).GetChild(0).GetChild(buttons.Length - 1).GetComponent<Button>();
            button.gameObject.SetActive(true);
            buttons[buttons.Length - 1] = button;
            buttons[buttons.Length - 1].image.sprite = Lmahjongs[0].sprites;
            turning = true;
        }

    }
   public void GetM()
    {
        for (int i = 0; i < game.GetComponent<GameManager>().Rmahjongs.Length; i++)
        {
            if (!game.GetComponent<GameManager>().Rmahjongs[i].used)
            {
                Mahjong mahjong;
                mahjong = game.GetComponent<GameManager>().Rmahjongs[i];
                game.GetComponent<GameManager>().Rmahjongs[i].used = true;
                Lmahjongs.Add(mahjong);
                break;
            }
        }
      
        player.turned = false;
     
    }
    public void ShowM()
    {
        for (int i = 0; i < buttons.Length - 1; i++)
        {
            Button button = game.transform.GetChild(0).GetChild(0).GetChild(i).GetComponent<Button>();
            buttons[i] = button;
            buttons[i].image.sprite = pmahjongs[i].sprites;
        }
    }

}
