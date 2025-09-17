using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("player�̈ړ����x")]
    public float speed = 5f;

    Talking _talking;
    public Rigidbody2D rb;
    public string collidedObjectName;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _talking = FindAnyObjectByType<Talking>();
    }

    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        // ���͂��܂Ƃ߂Ď擾
        float moveX = Input.GetAxisRaw("Horizontal"); // -1,0,1
        float moveY = Input.GetAxisRaw("Vertical");   // -1,0,1

        // �ړ��x�N�g�����쐬
        Vector2 move = new Vector2(moveX, moveY) * speed;

        // Rigidbody�ɑ��
        rb.velocity = move;
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collidedObjectName = collision.gameObject.name;
           Debug.Log("Enter!");
    }
}
