using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    void Start()
    {
        GameManager.Instance.blocklimit -= 1;
    }
}