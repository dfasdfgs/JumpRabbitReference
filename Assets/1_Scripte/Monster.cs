using UnityEngine;

public class Monster : MonoBehaviour
{
    Rigidbody2D rb;

    private float moveTime = 0f;
    private float TurnTime = 0f;

    public float MoveSpeed = 3f;

    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MonsterMove();
    }

    private void MonsterMove()
    {
        moveTime += Time.deltaTime;

        if (moveTime <= TurnTime)
        {
            this.transform.Translate(MoveSpeed * Time.deltaTime, 0, 0);
        }
        else
        {
            TurnTime = Random.Range(1, 5);
            moveTime = 0;

            transform.Rotate(0, 180, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.Instance.HP_now_lod -= 1;
            animator.SetTrigger("Attack");
        }

    }

}
