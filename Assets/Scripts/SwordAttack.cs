using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    //剑攻击持续的时间
    public float attackDuration = 0.2f;

    //攻击剩余时间
    private float attackTimer;

    //挥剑开始和结束的角度
    private float swingStartAngle = -70f;
    private float swingEndAngle = 70f;

    //剑的图片组件
    private SpriteRenderer swordRenderere;

    //剑的攻击碰撞器
    private BoxCollider2D swordCollider;

    //获取玩家的移动脚本
    //private PlayerMovement playerMovement;

    //获取SwordPivot旋转中心
    private Transform swordPivot;

    //剑的声音组件
    private AudioSource swordAudio;


    void SetAttackActive(bool active)
    {
        // 控制剑是否显示
        swordRenderere.enabled = active;

        //控制剑的攻击碰撞范围是否启用
        swordCollider.enabled = active;
    }

    //根据玩家最后的移动方向旋转剑
    //private void UpdateSwordDirection()
    //{
    //    // 把二维方向转换成角度
    //    float angle = Mathf.Atan2(
    //        playerMovement.lastMoveDirection.y,
    //        playerMovement.lastMoveDirection.x
    //    ) * Mathf.Rad2Deg;

    //    // 让剑按照这个角度旋转
    //    transform.localRotation = Quaternion.Euler(0, 0, angle);
    //}


    void Start()
    {
        //获取Sword身上的组件
        swordRenderere = GetComponent<SpriteRenderer>();
        swordCollider = GetComponent<BoxCollider2D>();

        swordAudio = GetComponent<AudioSource>();
        //获取父级物品Player身上的playerMovement脚本
        //playerMovement = GetComponentInParent<PlayerMovement>();

        //获取Sword的父物体SwordPivot
        swordPivot = transform.parent;

        //游戏开始时隐藏剑和攻击范围
        SetAttackActive(false);
    }

    private void Update()
    {
        //根据玩家最后移动方向改变剑的朝向
        //UpdateSwordDirection();

        //鼠标按下左键，如果没有攻击时，开始攻击
        if (Input.GetMouseButtonDown(0) && attackTimer <= 0) 
        {
            attackTimer = attackDuration;

            //把剑放到挥剑开始的地方
            swordPivot.localRotation = Quaternion.Euler(0, 0, swingStartAngle);

            SetAttackActive(true);

            //播放挥剑声音
            if(swordAudio != null)
            {
                swordAudio.Play();
            }
        }

        //攻击持续倒计时
        if(attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;

            //计算挥剑进度，范围是0到1
            float swingProgress = 1f - attackTimer / attackDuration;

            //根据进度计算当前剑的角度
            float swingAngle = Mathf.Lerp(swingStartAngle,swingEndAngle, swingProgress);

            //旋转SwordPivot，让剑完成挥砍
            swordPivot.localRotation = Quaternion.Euler(0, 0, swingAngle);

            //时间结束后隐藏剑
            if (attackTimer <= 0)
            {
                //将剑恢复到玩家当前的面向方向
                swordPivot.localRotation = Quaternion.identity;

                SetAttackActive(false);
            }
        }
    }
    //当剑的攻击碰撞器碰到其他碰撞器时调用
    private void OnTriggerEnter2D(Collider2D other)
    {
        //尝试获取被击中物体上的EnemyHealth脚本
        EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();

        //如果被击中的物体确实有EnemyHealth脚本
        if(enemyHealth != null)
        {
            // 对敌人造成1点伤害
            enemyHealth.TakeDamage(1);
        }
    }
}
