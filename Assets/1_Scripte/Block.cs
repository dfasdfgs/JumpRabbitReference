using UnityEngine;

public class Block : MonoBehaviour
{

    private static readonly int GRAVITY_SCALE = 2;


    public GameObject spwanObject;
    private bool isFloor;

    private void Awake()
    {
        GameManager.Instance.block_On = false;
    }

    private void Start()
    {
        //오브젝트 생성
        GameManager.Instance.blocklimit -= 1;
    }

    private void Update()
    {
        if (!isFloor)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
            {
                GameManager.Instance.blocklimitNun.text = "남은 배치 횟수  :  " + GameManager.Instance.blocklimit.ToString();
                ObjectMove();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                ObjectDrop();
            }
        }
    }

    private void ObjectMove()
    {
        // Screen 좌표계인 mousePosition을 World 좌표계로 바꾼다
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // 오브젝트는 x로만 움직여야 하기 때문에 y는 고정
        mousePos.y = spwanObject.transform.position.y;
        mousePos.z = spwanObject.transform.position.z;

        spwanObject.transform.position = mousePos;
    }

    private void ObjectDrop()
    {
        //마우스버튼을 떼면 gravity scale에 값을 넣어 아래로 떨어지게 한다.
        spwanObject.GetComponent<Rigidbody2D>().gravityScale = GRAVITY_SCALE;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isFloor = true;
            GameManager.Instance.block_On = true;
        }

    }
}
