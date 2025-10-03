using System.Security.Cryptography;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("playerの移動速度")]
    public float speed = 5f;

    Talking _talking;
    public Rigidbody2D rb;
    public string collidedObjectName;

    // スプライト差し替え用
   public  SpriteRenderer spriteRenderer;
    public Sprite spriteUp;
    public Sprite spriteDown;
    public Sprite spriteLeft;
    public Sprite spriteRight;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _talking = FindAnyObjectByType<Talking>();

        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }

    private void Update()
    {
        // 会話中は動くの禁止
        if (Talking.IsInConversation)
            return;
    }

    private void FixedUpdate()
    {
        float moveX = Input.GetAxisRaw("Horizontal"); // -1,0,1
        float moveY = Input.GetAxisRaw("Vertical");   // -1,0,1

        Vector2 move = Vector2.zero;

        // 横移動
        if (moveX > 0)
        {
            move = Vector2.right * speed;
            spriteRenderer.sprite = spriteRight;
        }
        else if (moveX < 0)
        {
            move = Vector2.left * speed;
            spriteRenderer.sprite = spriteLeft;
        }

        // 縦移動（横入力がないときだけ縦を優先）
        else if (moveY > 0)
        {
            move = Vector2.up * speed;
            spriteRenderer.sprite = spriteUp;
        }
        else if (moveY < 0)
        {
            move = Vector2.down * speed;
            spriteRenderer.sprite = spriteDown;
        }
        else
        {
            move = Vector2.zero; // 停止中
        }

        rb.velocity = move;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collidedObjectName = collision.gameObject.name;
        Debug.Log("Enter!");
    }
}
