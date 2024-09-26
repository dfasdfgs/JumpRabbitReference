using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    Rigidbody2D rb;

    private float moveTime = 0f;
    private float TurnTime = 0f;

    public float MoveSpeed = 3f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }

    private void MonsterMove()
    {
        moveTime += Time.deltaTime;

        if (moveTime <= TurnTime)
        {
            this.transform.Translate(MoveSpeed * Time.deltaTime, 0, 0);
        }
    }
}
