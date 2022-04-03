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
    public bool turning = false;
    public Player nextplayer;
    int num2 = 0;
    public Camera camera;
    int Find(int a)
    {
        int num = 0;
      
        for(int i=0; i < game.players.Length; i++)
        {
            num++;
            if (player.Pname == game.players[i].Pname)
            {

              
                break;
            
            }
         
        }
        
        if (num-a < game.players.Length)
        {
           
            return num-a;
        }
        else return 0;
        
    }
    void Start()
    {
        player = gameObject.GetComponent<Player>();
        ArrayM();
        ShowM();
        camera = GameObject.Find("Camera").transform.GetChild(Find(1)).GetComponent<Camera>();
        nextplayer = game.players[Find(0)];
        camera.enabled = true;

    }
   void ArrayM()
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
                Tmahjongs.Add(pmahjongs[a]);
                pmahjongs[a] = Lmahjongs[0];
                Lmahjongs.Remove(Lmahjongs[0]);
                ArrayM();
                ShowM();


                turning = false;
                Button button = game.transform.GetChild(buttons.Length - 1).GetComponent<Button>();
                button.gameObject.SetActive(false); ;


            }
            else
            {
                Tmahjongs.Add(Lmahjongs[0]);
                Lmahjongs.Remove(Lmahjongs[0]);
                ShowM();
                turning = false;
                Button button = game.transform.GetChild(buttons.Length - 1).GetComponent<Button>();
                button.gameObject.SetActive(false); ;
            }
            GameObject[] maj = new GameObject[50];
            maj[num2] = Instantiate(Tmahjongs[num2].prefab);
            maj[num2].transform.localScale = Vector3.one;
            maj[num2].transform.localRotation = Quaternion.identity;
            maj[num2].transform.Rotate(0, 180, 0);
            maj[num2].transform.position = new Vector3(-0.0518f + (float)(0.02 * num2), 0.7554f, -0.07f);
            num2++;
        }
      

    }
    // Update is called once per frame
    void Update()
    {
        if (player.turned)
        {
            GetM();
            turning = true;
        }

    }
    void GetM()
    {



        for (int i = 0; i <game.GetComponent<GameManager>().Rmahjongs.Length; i++)
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

        Button button = game.transform.GetChild(buttons.Length - 1).GetComponent<Button>();
        button.gameObject.SetActive(true);
        buttons[buttons.Length - 1] = button;
        buttons[buttons.Length - 1].image.sprite = Lmahjongs[0].sprites;
        player.turned = false;
        nextplayer.turned = true;



    }



    public void ShowM()
    {
        for (int i = 0; i < buttons.Length - 1; i++)
        {
            Button button = game.transform.GetChild(i).GetComponent<Button>();
            buttons[i] = button;
            buttons[i].image.sprite = pmahjongs[i].sprites;
        }
    }

    





























}
