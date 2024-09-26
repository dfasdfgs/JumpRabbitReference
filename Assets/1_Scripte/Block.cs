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
        //������Ʈ ����
        GameManager.Instance.blocklimit -= 1;
    }

    private void Update()
    {
        if (!isFloor)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
            {
                GameManager.Instance.blocklimitNun.text = "���� ��ġ Ƚ��  :  " + GameManager.Instance.blocklimit.ToString();
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
        // Screen ��ǥ���� mousePosition�� World ��ǥ��� �ٲ۴�
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // ������Ʈ�� x�θ� �������� �ϱ� ������ y�� ����
        mousePos.y = spwanObject.transform.position.y;
        mousePos.z = spwanObject.transform.position.z;

        spwanObject.transform.position = mousePos;
    }

    private void ObjectDrop()
    {
        //���콺��ư�� ���� gravity scale�� ���� �־� �Ʒ��� �������� �Ѵ�.
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
