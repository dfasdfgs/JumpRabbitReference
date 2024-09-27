using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class Block : MonoBehaviour
{

    private static readonly int GRAVITY_SCALE = 2;


    public Camera camera;
    public GameObject cam;
    public float speed = 1f;

    public Transform spwanObject;

    private bool isFloor = true;

    private void Awake()
    {
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        GameManager.Instance.block_On = false;
    }

    private void Start()
    {
        //������Ʈ ����
        GameManager.Instance.blocklimit -= 1;
    }

    private void Update()
    {
        if (isFloor)
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
        if (isFloor)
        {
            if (collision.gameObject.tag == "Floor")
            {
                isFloor = false;

                GameManager.Instance.block_On = true;
                StartCoroutine(Cam_O());
            }
        }
    }

    IEnumerator Cam_O()
    {
        Vector3 Pos = this.transform.position;

        Pos.z = -10f;

        camera.orthographicSize = 4f;
        camera.transform.position = Pos;

        yield return new WaitForSeconds(2f);

        camera.orthographicSize = 5;
        camera.transform.position = new Vector3(0, -0f,-10);

        GameManager.Instance.Block_();

        yield break;
    }
}
