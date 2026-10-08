using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    //当敌人刚碰到另一个2D碰撞体时，自动调用这个
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //在被碰到的物体上寻找PlayerHealth组件
        PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

        //如果找到了PlayerHealth，说明就是玩家
        if(playerHealth != null)
        {
            //让玩家收到一点伤害
            playerHealth.TakeDamage(1);
        }
    }
}
