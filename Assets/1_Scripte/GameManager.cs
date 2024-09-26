using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool Move_On = false;
    public bool block_On = true;
    public bool Check_1 = false;
    public GameObject block;
    public GameObject asdfghjksadfjkl;
    public int blocklimit;
    public Text blocklimitNun;


    void Start()
    {
        blocklimitNun.text = "남은 배치 횟수  :  " + blocklimit.ToString();
        Instance = this;
    }

    void Update()
    {
        Block_();
    }
    private void Block_()
    {
        if (block_On)
        {
            if (blocklimit > 0)
            {
                Instantiate(block);
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
        Move_On = true;

        yield break;
    }


}
