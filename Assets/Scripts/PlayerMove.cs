using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("playerの移動速度")]
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
        if (collidedObjectName == "Green" && Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("上キーが押されました。");
            _talking.Message();
        }
    }

    private void FixedUpdate()
    {
        // 入力をまとめて取得
        float moveX = Input.GetAxisRaw("Horizontal"); // -1,0,1
        float moveY = Input.GetAxisRaw("Vertical");   // -1,0,1

        // 移動ベクトルを作成
        Vector2 move = new Vector2(moveX, moveY) * speed;

        // Rigidbodyに代入
        rb.velocity = move;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collidedObjectName = collision.gameObject.name;
        Debug.Log("Enter!");
    }
}
