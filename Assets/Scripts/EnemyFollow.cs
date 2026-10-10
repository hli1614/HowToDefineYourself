using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    //Enemy 要追踪玩家
    public Transform target;

    //Enemy 的移动速度
    public float moveSpeed = 2f;

    //Enemy 身上的Rigidbody2D
    private Rigidbody2D rb;

    void Start()
    {
        //获取Enemy的Rigidbody2D
        rb = GetComponent<Rigidbody2D>();

        // 如果没有手动设置目标，就自动寻找Player
        if(target == null)
        {
            //寻找名字为Player的游戏对象
            GameObject playerObject = GameObject.Find("Player");

            //确认找到了Player
            if(playerObject != null)
            {
                // 把Player的Transform设置为追踪目标
                target = playerObject.transform;
            }
            else
            {
                //如果没有找到Player，就在Console中显示警告
                Debug.LogWarning("Not find player");
            }
        }
    }
    void FixedUpdate()
    {
        //如果没有玩家就停止移动
        if(target == null){
            return;
        }

        //计算Enemy朝玩家移动后的位置
        Vector2 newPosition = Vector2.MoveTowards(
            rb.position,
            target.position,
            moveSpeed * Time.fixedDeltaTime);
        //使用Rigidbody2D移动Enemy
        rb.MovePosition(newPosition);
    }
}

