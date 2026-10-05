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

    void SetAttackActive(bool active)
    {
        // 控制剑是否显示
        swordRenderere.enabled = active;

        //控制剑的攻击碰撞范围是否启用
        swordCollider.enabled = active;
    }

    void Start()
    {
        //获取Sword身上的组件
        swordRenderere = GetComponent<SpriteRenderer>();
        swordCollider = GetComponent<BoxCollider2D>();

        //游戏开始时隐藏剑和攻击范围
        SetAttackActive(false);
    }

    private void Update()
    {
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
