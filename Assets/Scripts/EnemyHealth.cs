using UnityEngine;

public class EnemyHealth :MonoBehaviour
{
    // 敌人的最大生命值
    public int maxHealth = 3;

    //敌人的当前生命值
    private int currentHealth;

    void Start()
    {
        //游戏开始时生命值为最大生命值
        currentHealth = maxHealth;
    }
    //受到伤害的方法
    public void TakeDamage(int damage)
    {
        //减少生命值
        currentHealth -= damage;

        //如果生命值小于等于0，敌人死亡
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

}
