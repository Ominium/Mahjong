using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using Photon.Pun;
using Photon.Realtime;
[System.Serializable]
public class Mahjong
{
    public int rank; 
    public string patt;
    public int num;
    public Sprite sprites;
    public bool used = false;
    public GameObject prefab;
    private bool aka = false;
    public bool Aka
    {
        get { return aka; }
        set { aka = value; }
    }
    public Mahjong(int a, string b, int c, Sprite sprite, bool d, GameObject e)
    {
        rank = a;
        patt = b;
        num = c;
        sprites = sprite;
        used = d;
        prefab = e;
    }
    

    public bool YoguPae()
    {
        if (patt == "Dragons" || num == 1 || num == 9)
        {
            return true;
        }
        else return false;

    }
 

   
}
[System.Serializable]
public class Pedigree
{
    public int Pscore;
    public int Pcryscore;
    public string Pname;
    public bool Pcry;
    public bool Yackman;
    public Pedigree(int a, int b, string c, bool d)
    {
        Pscore = a;
        Pcryscore = b;
        Pname = c;
        Pcry = d;
    }


}



public class GameManager : MonoBehaviour
{
    public enum GameState
    {
       Start,
        Ready,
        Play,
        RoundEnd,
        GameEnd,
    }
    private string GameWinds;
    public string gameWinds
    {
        get { return GameWinds; }
        set {gameWinds = value; }
    }
    public GameObject pgroup;
    public Mahjong[] mahjongs = new Mahjong[136];
    public Mahjong[] Rmahjongs = new Mahjong[136];
    public Sprite[] sprites = new Sprite[34];
    public Sprite[] akasprites = new Sprite[3];
    public Pedigree[] pedigrees = new Pedigree[48];
    string[] pedname = new string[4];
    public Player[] players = new Player[4];
    public Mahjong[] kingmah = new Mahjong[14];
    public Sprite back;
    public bool aka = false;
    public GameObject[] mprefabs = new GameObject[34];
    public GameObject[] akaprefabs = new GameObject[3];
    int num2 = 0;
    string[] winds = new string[4];
    public string[] Winds
    {
        get { return winds;}
        set { winds = value; }  
    }
    private static GameManager _instance = null;
    public PhotonView photonView;
    public bool isConnect = false;
    public Image[] images = new Image[5];
    public static GameState Gstate;
    public static int Gameturn = 0;
    public float Rtime = 0.0f;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameManager();
            }
            return _instance;
        }
    }
   
    void ReadyGame()
    {
        for (int i = 0; i < players.Length; i++)
        {
            players[i].GetComponent<PlayerCtrl>().StartPl();
        }
        for (int i = 0; i < players.Length; i++)
        {
            if (!players[i].GetComponent<PlayerCtrl>().AIcheak)
            {
                players[i].GetComponent<PlayerCtrl>().Camera();
            }
            
        }
        for (int i = 0; i < players.Length; i++)
        {
            players[i].turned = false;
            if (players[i].wind == "East")
            {
                players[i].GetComponent<PlayerCtrl>().Oyas = true;
                players[i].Oya = true;
            }
            
        }
        Gstate = GameState.Play;
    }

    void PlayGame()
    {
       // SceneManager.LoadScene(1);
    }
    void RoundEnd()
    {
       
       
        for (int i = 0; i < players.Length; i++)
        {
           
                players[i].turned = false;
            players[i].Oya = false;
            players[i].GetComponent<PlayerCtrl>().pmahjongs.Clear();



        }
        GameObject[] gameObjects;
        gameObjects = GameObject.FindGameObjectsWithTag("Mahjongs");
      
        for(int i = 0;i<gameObjects.Length;i++)
        {
            Destroy(gameObjects[i]);
        }
        GameWinds = winds[Gameturn / 2];
        Msetup();
        PlayerSet2();
        SplitM();
      

    }
    void GameEnd()
    {
       
        SceneManager.LoadScene(0);
    }
    void GamePlayState(GameState state) // ???? ???? 
    {

        switch (state)
        {


            case GameState.Ready:
                ReadyGame();
                Gstate = GameState.Play;
                break;
            case GameState.Play:
                PlayGame();
                break;
            case GameState.RoundEnd:
              RoundEnd();
               
                break;
            case GameState.GameEnd:
              GameEnd();
                break;
        }
    }
    private void Awake()
    {
        
        
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        Gstate = GameState.Start;
        PlayerSet();
        for (int i = 0; i < players.Length; i++)
        {
            players[i].turned = false;
            if (players[i].wind == "East")
            {
                players[i].GetComponent<PlayerCtrl>().Oyas = true;
                players[i].Oya = true;
            }
           
        }
        Msetup();
        SplitM();
       

    }
    IEnumerator CreatePlayer()
    {
        yield return new WaitUntil(() => isConnect);
        GameObject playertemp = PhotonNetwork.Instantiate("Player", Vector3.one, Quaternion.identity);

    }
    void PlayerSet2()
    {
      
       
        for (int i = 0; i < players.Length; i++)
        {
            if (i == players.Length - 1)
            {
                break;
            }
            Player player;

            player = players[i];

          
            players[i] = players[i + 1];
            players [i + 1]= player;
            
                   

        }
        for (int i = 0; i < players.Length; i++)
        {
            players[i].wind = winds[i];
        }
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].wind == "East")
            {
                players[i].GetComponent<PlayerCtrl>().Oyas = true;
                players[i].Oya = true;
            }
            
        }
        
      
    }
    void PlayerSet()
    {
        winds[0] = "East";
        winds[1] = "South";
        winds[2] = "West";
        winds[3] = "North";
        int random = 0;
        for (int i = 0; i < players.Length; i++)
        {
            players[i] = pgroup.GetComponent<Transform>().GetChild(i).GetComponent<Player>();
            players[0].Pname = PhotonNetwork.NickName;
        }


        for (int i = 0; i < players.Length; i++)
        {
            Player player;
            random = UnityEngine.Random.Range(0, 4);
            player = players[i];
            players[i] = players[random];
            players[random] = player;


        }


        for (int i = 0; i < players.Length; i++)
        {
            players[i].wind = winds[i];
        }

      

    }

    void Msetup()
    {
        pedname[0] = "Character";
        pedname[1] = "Circle";
        pedname[2] = "Bamboo";
        pedname[3] = "Drangons";
        for (int i = 0; i < mahjongs.Length; i++)
        {
            mahjongs[i] = new Mahjong(0, "NULL", 0, sprites[0], false, null);
        }

        for (int i = 0; i < mahjongs.Length; i++)
        {
            mahjongs[i].rank = i;
        }
        for (int j = 0; j < 3; j++)
        {
            for (int i = 0; i < 36; i++)
            {
                mahjongs[i + 36 * j].patt = pedname[j];
            }
        }
        int num = 0;
        for (int i = 0; i < 9; i++)
        {
            for (int j = 1; j % 5 != 0; j++)
            {
                mahjongs[num].num = i + 1;
                mahjongs[num].sprites = sprites[i];
                mahjongs[num].prefab = mprefabs[i];
                num++;
            }
        }
        num = 0;
        for (int i = 0; i < 9; i++)
        {
            for (int j = 1; j % 5 != 0; j++)
            {
                mahjongs[36 + num].num = i + 1;
                mahjongs[36 + num].sprites = sprites[9 + i];
                mahjongs[36 + num].prefab = mprefabs[9 + i];
                num++;
            }
        }
        num = 0;
        for (int i = 0; i < 9; i++)
        {
            for (int j = 1; j % 5 != 0; j++)
            {
                mahjongs[72 + num].num = i + 1;
                mahjongs[72 + num].sprites = sprites[18 + i];
                mahjongs[72 + num].prefab = mprefabs[18 + i];
                num++;
            }
        }


        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                mahjongs[108 + (4 * i) + j] = new Mahjong(108 + (4 * i) + j, pedname[3], i+1, sprites[27 + i], false, mprefabs[27 + i]);
            }

        }


    }
    void SplitM()
    {
       
        int random = 0;
        for (int i = 0; i < Rmahjongs.Length; i++)
        {
            Rmahjongs[i] = mahjongs[i];
        }
        for (int i = 0; i < Rmahjongs.Length; i++)
        {
            random = UnityEngine.Random.Range(0, 136);
            Mahjong mahjong;
            mahjong = Rmahjongs[i];
            Rmahjongs[i] = Rmahjongs[random];
            Rmahjongs[random] = mahjong;
        }

        for (int i = 0; i < players.Length; i++)
        {
            for (int j = 0; j < 13; j++)
            {
                Rmahjongs[players.Length * i + j].used = true;
                players[i].GetComponent<PlayerCtrl>().pmahjongs.Add( Rmahjongs[players.Length * i + j]);
            }


        }
        for (int i = 1; i < kingmah.Length + 1; i++)
        {
            Rmahjongs[Rmahjongs.Length - i].used = true;
            kingmah[i - 1] = Rmahjongs[Rmahjongs.Length - i];


        }
        Gstate = GameState.Ready;
        Kmsignal(0);
        
    }

    public void Kmsignal(int a)
    {
        for (int i = 0; i < images.Length; i++)
        {
            images[i] = GameObject.Find("DoraPan").transform.GetChild(i).GetComponent<Image>();
            images[i].sprite = back;
        }
        for (int i = 0; i < a + 1; i++)
        {
            images[i].sprite = kingmah[i].sprites;
        }

    }
    void Start()
    {







    }
    // Update is called once per frame
    void Update()
    {
        GamePlayState(Gstate);
        if((players[0].score < 0)|| (players[1].score< 0)|| (players[2].score < 0)|| (players[3].score < 0)|| Gameturn ==7)
        {
            Gstate = GameState.GameEnd;
        }
    }
}

