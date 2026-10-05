using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //速度
    public float moveSpeed = 5f;
    // 引用 Player 身上的 Rigidbody2D 组件，用来控制移动
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // 读取左右方向输入：A/D 或左/右方向键
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        // 读取上下方向输入：W/S 或上/下方向键
        float verticalInput = Input.GetAxisRaw("Vertical");
        //把水平和垂直合并成一个二维方向
        Vector2 movementInput = new Vector2(horizontalInput, verticalInput);
        //根据输入方向和移动速度设置玩家移动速度
        rb.linearVelocity = movementInput * moveSpeed;


    }
}
