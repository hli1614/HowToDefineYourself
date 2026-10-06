using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    //剑攻击持续的时间
    public float attackDuration = 0.2f;

    //攻击剩余时间
    private float attackTimer;

    //剑的图片组件
    private SpriteRenderer swordRenderere;

    //剑的攻击碰撞器
    private BoxCollider2D swordCollider;

    //获取玩家的移动脚本
    private PlayerMovement playerMovement;

    void SetAttackActive(bool active)
    {
        // 控制剑是否显示
        swordRenderere.enabled = active;

        //控制剑的攻击碰撞范围是否启用
        swordCollider.enabled = active;
    }

    //根据玩家最后的移动方向旋转剑
    private void UpdateSwordDirection()
    {
        //把二维方向转化成角度
        float angle = Mathf.Atan2(
            playerMovement.lastMoveDirection.y,
            playerMovement.lastMoveDirection.x) * Mathf.Rad2Deg;

        //让剑按照这个角度旋转
        transform.localRotation = Quaternion.Euler(0, 0, angle);
    }


    void Start()
    {
        //获取Sword身上的组件
        swordRenderere = GetComponent<SpriteRenderer>();
        swordCollider = GetComponent<BoxCollider2D>();

        //获取父级物品Player身上的playerMovement脚本
        playerMovement = GetComponentInParent<PlayerMovement>();

        //游戏开始时隐藏剑和攻击范围
        SetAttackActive(false);
    }

    private void Update()
    {
        //根据玩家最后移动方向改变剑的朝向
        UpdateSwordDirection();

        //鼠标按下左键，如果没有攻击时，开始攻击
        if (Input.GetMouseButtonDown(0) && attackTimer <= 0) 
        {
            attackTimer = attackDuration;
            SetAttackActive(true);
        }

        //攻击持续倒计时
        if(attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;

            //时间结束后隐藏剑
            if (attackTimer <= 0)
            {
                SetAttackActive(false);
            }
        }
    }
}
