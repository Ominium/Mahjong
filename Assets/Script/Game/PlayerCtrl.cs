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
    public bool AIcheak = false;
    public Camera camera;
    public bool Oyas = false;

   public IEnumerator FirstStart()
    {
        if (Oyas)
        {
            Oyas = false;
            yield return new WaitForSeconds(2f);
            player.turned = true;
            
        }
       
    }
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
        StartPl();
        Camera();
    }
    public void StartPl()
    {
        game = GameObject.Find("Canvas").GetComponent<GameManager>();
        player = gameObject.GetComponent<Player>();
        ArrayM();
        nextplayer = game.players[Find(0)];
        num2 = 0;
        for (int i = 0; i < trs.Length; i++)
        {
            trs[i] = GameObject.Find("trs").GetComponent<Transform>().GetChild(i);
        }
        Tmahjongs.Clear();
        Lmahjongs.Clear();

    }
    public void Camera()
    {
        ShowM();
        Camera[] cameras = new Camera[4];
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i] = GameObject.Find("Camera").transform.GetChild(i).GetComponent<Camera>();
            cameras[i].enabled = false;
        }
        camera = GameObject.Find("Camera").transform.GetChild(Find(1)).GetComponent<Camera>();

        camera.enabled = true;
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
    public void Mthrow2()
    {
        GameObject[] maj = new GameObject[50];
        maj[num2] = Instantiate(Tmahjongs[num2].prefab);
        maj[num2].transform.localScale = Vector3.one;
        maj[num2].transform.localRotation = Quaternion.identity;
        maj[num2].transform.parent = GameObject.Find("Majtile").transform;
        switch (Find(1))
        {
            case 0:
                
                maj[num2].transform.position = new Vector3(trs[Find(1)].position.x + (float)(0.02 * (int)(num2%6)), trs[Find(1)].position.y, trs[Find(1)].position.z - (float)(0.0265*(int)(num2/6)));
                maj[num2].transform.rotation = Quaternion.Euler(0, 180, 0);
                break;
            case 1:
                maj[num2].transform.position = new Vector3(trs[Find(1)].position.x+ (float)(0.0265 * (int)(num2 / 6)), trs[Find(1)].position.y, trs[Find(1)].position.z + (float)(0.02 * (int)(num2 % 6)));
                maj[num2].transform.rotation = Quaternion.Euler(0, 90, 0);
                break;
            case 2:
                maj[num2].transform.position = new Vector3(trs[Find(1)].position.x - (float)(0.02 * (int)(num2 % 6)), trs[Find(1)].position.y, trs[Find(1)].position.z+ (float)(0.0265 * (int)(num2 / 6)));
                break;
            case 3:
                maj[num2].transform.position = new Vector3(trs[Find(1)].position.x- (float)(0.0265 * (int)(num2 / 6)), trs[Find(1)].position.y, trs[Find(1)].position.z - (float)(0.02 * (int)(num2 % 6)));
                maj[num2].transform.rotation = Quaternion.Euler(0, 270, 0);
                break;



        }
        num2++;
        player.turned = false;
        nextplayer.turned = true;
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


               
                
                buttons[13].image.enabled = false ;


            }
            else
            {
                turning = false;
                Tmahjongs.Add(Lmahjongs[0]);
                Lmahjongs.Remove(Lmahjongs[0]);
                ShowM();
               
                
                buttons[13].image.enabled = false;
            }
            Mthrow2();

        }

        
    }
    private void Update()
    {
        StartCoroutine(FirstStart());
    }
    // Update is called once per frame
    void LateUpdate()
    {
       
        if (player.turned&&GameManager.Gstate == GameManager.GameState.Play&& game.GetComponent<GameManager>().pmahjongs.Length > 0 && game.GetComponent<GameManager>().Rmahjongs.Length > 0)
        {
            GetM();
            if(buttons.Length > 0&& game.GetComponent<GameManager>().pmahjongs.Length > 0)
            {
                buttons[13].image.sprite = Lmahjongs[0].sprites;
                buttons[13].image.enabled = true;
            
               
                turning = true;
            }
           
        }

    }
   public void GetM()
    {

        player.turned = false;

        int used = 0;
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
                else used++;

                if (used >= game.GetComponent<GameManager>().Rmahjongs.Length - 1)
                {
                    
                    GameManager.Gameturn++;
                    GameManager.Gstate = GameManager.GameState.RoundEnd;
                    break;
                }
            }

          

        


    }
    public void ShowM()
    {
        Button button;
        for (int i = 0; i < buttons.Length; i++)
        {
            button = game.transform.GetChild(0).GetChild(0).GetChild(i).GetComponent<Button>();
            buttons[i] = button;
            if (i != buttons.Length - 1)
            {
        
                buttons[i].image.sprite = pmahjongs[i].sprites;
            }
            else if (Lmahjongs.Count !=0)
            {
                buttons[i].image.sprite = Lmahjongs[0].sprites;
                
            }
           

        }

       
    }

}
