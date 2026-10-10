using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    //敌人每次攻击造成的伤害
    public int attackDamage = 1;

    //敌人两次攻击之间的时间间隔
    public float attackInterval = 1f;

    // 下一次允许攻击的时间
    private float nextAttackTime = 0f;

    //当敌人与另一个2D碰撞体接触时，Unity会不断调用这个方法
    private void OnCollisionStay2D(Collision2D collision)
    {
        //在被碰到的物体上寻找PlayerHealth组件
        PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

        //如果找到了PlayerHealth，说明就是玩家
        if(playerHealth != null && Time.time >= nextAttackTime)
        {
            //让玩家收到一点伤害
            playerHealth.TakeDamage(attackDamage);

            //设置下一次攻击时间
            nextAttackTime = Time.time + attackInterval;
        }
    }
}
