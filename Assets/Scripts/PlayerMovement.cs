using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //速度
    public float moveSpeed = 5f;
    // 引用 Player 身上的 Rigidbody2D 组件，用来控制移动
    private Rigidbody2D rb;

    //玩家最后一次移动的方向
    //Vector2.right 表示向右，也就是（1，0）
    public Vector2 lastMoveDirection = Vector2.right;

    //让玩家面向鼠标，并限制为8个方向
    private void UpdateFacingDirection()
    {
        //获取鼠标在屏幕上的位置，并转换成游戏坐标
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //计算玩家指向鼠标的方向
        Vector2 lookDirection = mouseWorldPosition - transform.position;

        //根据方向计算角度
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        //把角度限制为8个方向，每个方向相差45度
        float snappedAngle = Mathf.Round(angle / 45f) * 45f;

        //旋转玩家
        transform.rotation = Quaternion.Euler(0, 0, snappedAngle+90f);
    }
    
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

        //如果玩家正在移动，就记录当前移动方向
        if(movementInput != Vector2.zero)
        {
            //把方向转换成长度为1的单位方向
            lastMoveDirection = movementInput.normalized; 
        }

        //根据输入方向和移动速度设置玩家移动速度
        rb.linearVelocity = movementInput * moveSpeed;

        //让玩家面向鼠标方向
        UpdateFacingDirection();

    }
}
