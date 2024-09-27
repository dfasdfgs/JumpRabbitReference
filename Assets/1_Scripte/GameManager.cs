using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public DataBaseManager dataBaseManager;

    public bool block_On = true;
    public bool Clear = false;
    public bool Move_On = false;
    public bool Check_1 = false;
    public bool Check_2 = false;

    public GameObject HP_UI;
    public GameObject[] HP;
    public int HP_now_lod = 3;

    public float LimitTime;
    public Text text_Timer;
    public GameObject text_Timer_;
    public GameObject[] bo;
    public Text Clear_txt;
    public Text Timer_txt;

    public GameObject End;
    public GameObject[] block;
    public GameObject asdfghjksadfjkl;
    public int blocklimit = 4;
    public Text blocklimitNun;
    public GameObject blocklimitNun_;


    public Transform R_sp_M;
    public Transform R_sp_I;
    public Transform R_sp_P;
    public Transform sp;



    private void Awake()
    {
        Instance = this;
    }


    void Start()
    {
        blocklimitNun.text = "남은 배치 횟수  :  " + blocklimit.ToString();
        random_pos();
        Block_();
        Instantiate(dataBaseManager.Poin, R_sp_P.position, R_sp_P.rotation);
        Instantiate(dataBaseManager.Item, R_sp_I.position, R_sp_I.rotation);
    }

    void random_pos()
    {
        R_sp_I.position = new Vector2(Random.Range(-6.03f, 6.09f), Random.Range(1.54f, -3.41f));
        R_sp_M.position = new Vector2(0, Random.Range(1.54f, -3.41f));
        R_sp_P.position = new Vector2(Random.Range(-6.03f, 6.09f), 3.56f);
        sp.position = new Vector2(0, 2.45f);
    }


    void Update()
    {
        if (Move_On)
        {
            LimitTime -= Time.deltaTime;
            text_Timer.text = "남은 시간 :" + Mathf.Round(LimitTime);
        }

        if (LimitTime < 0)
        {
            StartCoroutine(endscene());
        }

        HP_now();
    }
    public void Block_()
    {
        int b_Random;
        int b_int;

        b_Random = Random.Range(0, 3);
        b_int = b_Random;


        if (block_On)
        {
            if (blocklimit > 0)
            {
                Instantiate(block[b_int], sp.position, sp.rotation);
            }
            else if (blocklimit == 0)
            {
                StartCoroutine(moveon());
                block_On = false;
            }
        }
    }

    IEnumerator moveon()
    {
        asdfghjksadfjkl.SetActive(true);
        yield return new WaitForSeconds(3f);
        asdfghjksadfjkl.SetActive(false);
        yield return new WaitForSeconds(1f);
        blocklimitNun_.SetActive(false);
        text_Timer_.SetActive(true);
        HP_UI.SetActive(true);

        Instantiate(dataBaseManager.Monster, R_sp_M.position, R_sp_M.rotation);

        Move_On = true;

        yield break;
    }

    public void HP_now()
    {
        switch (HP_now_lod)
        {
            case 0:
                HP[2].SetActive(false);
                HP[1].SetActive(false);
                HP[0].SetActive(false);
                Check_2 = false;
                StartCoroutine(endscene());
                break;
            case 1:
                HP[1].SetActive(false);
                HP[0].SetActive(false);
                Check_2 = false;
                break;
            case 2:
                HP[0].SetActive(false);
                Check_2 = false;
                break;
            case 3:
                Check_2 = true;
                break;

        }
    }

    public IEnumerator endscene()
    {
        Move_On = false;
        End.SetActive(true);



        if (Clear == true)
        {
            if (Check_1 == true)
            {
                bo[0].SetActive(true);
                LimitTime += 5;
            }

            if (Check_2 == true)
            {
                bo[1].SetActive(true);
                LimitTime += 5;

            }
            if (LimitTime > dataBaseManager.H_sco)
            {
                dataBaseManager.H_sco = LimitTime;
            }
            Clear_txt.text = "성공";
        }
        else if (Clear == false)
        {
            Clear_txt.text = "실패";
        }

        Timer_txt.text = "남은 시간 : " + LimitTime.ToString("F1");

        yield break;
    }
}
