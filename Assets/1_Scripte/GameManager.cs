using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool Check_1 = false;
    public GameObject block;
    public int blocklimit;

    [SerializeField] Vector2 SPpoint;

    void Start()
    {
        Instance = this;
        Block_();
    }

    void Update()
    {
        
    }
    private void Block_()
    {
        if (blocklimit > 0)
        {
            Instantiate(block);
        }
    }
}
