using UnityEngine;
using static Unity.VisualScripting.Member;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;

    public float Speed = 4f;
    public float JumpPower = 5f;
    public float Jumplimt = 10f;

    private bool justJump = false;
    private Animator animator;
    private bool faceRight;
    private bool isFloor = true;

    public AudioSource source;
    public AudioClip clip;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (GameManager.Instance.Move_On)
        {
            Move();
            Jump();
            JumpCheck();
        }
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
            animator.SetBool("Move", true);
            if (!faceRight) Filp();
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Speed * Time.deltaTime);
            animator.SetBool("Move", true);
            if (faceRight) Filp();
        }
        else
        {
            animator.SetBool("Move", false);
        }
    }
    private void Jump()
    {
        if (justJump)
        {
            justJump = false;

            rigidbody2d.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
            source.PlayOneShot(clip);
            animator.SetTrigger("Jump");
            JumpPower = 5;
        }
    }

    private void Filp()
    {
        faceRight = !faceRight;

        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void JumpCheck()
    {
        if (isFloor)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                justJump = true;
            }
            else if (Input.GetKey(KeyCode.Space))
            {
                //최대 10까지...
                if (Jumplimt > JumpPower)
                    JumpPower += 0.01f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isFloor = true;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isFloor = false;
        }
    }
}
