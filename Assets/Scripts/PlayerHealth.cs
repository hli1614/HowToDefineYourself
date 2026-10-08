using UnityEngine;
using TMPro;

using System.Data;
public class PlayerHealth : MonoBehaviour
{
    //玩家最大生命值
    public int maxHealth = 1;

    //玩家当前生命值
    private int currentHealth;

    //玩家最大护盾值
    public int maxShield = 4;

    //玩家当前护盾值
    public int currentShield;

    //游戏界面上显示生命值和护盾的文字
    public TextMeshProUGUI playerStatusText;

    //更新游戏界面上的生命值和护盾文字
    private void UpdateStatusText()
    {
        //确认已经连接了UI文字
        if(playerStatusText != null)
        {
            playerStatusText.text = "Life: " + currentHealth + " / Firewall: " + currentShield;
        }
    }

    void Start()
    {
        //游戏开始时玩家生命值为最大生命值和最大护盾值
        currentHealth = maxHealth;

        currentShield = maxShield;

        //显示初始生命值和护盾值
        UpdateStatusText();
    }

    //玩家死亡的方法
    private void Die()
    {
        Debug.Log("You have been reset.");
    }

    //玩家受到伤害
    public void TakeDamage(int damage)
    {
        ////计算护盾可以吸收多少伤害
        //int shieldDamage = Mathf.Min(currentShield, damage);

        ////扣除护盾
        //currentShield -= shieldDamage;

        ////计算护盾吸收后还剩多少伤害
        //damage -= shieldDamage;

        //如果还有护盾，就只扣除护盾
        if(currentShield > 0)
        {
            currentShield -= damage;

            //防止护盾变成负数
            if(currentShield < 0)
            {
                currentShield = 0;
            }
        }
        //没有护盾时扣除生命值
        else
        {
        //减少当前生命值
        currentHealth -= damage;
        }

        //在Console显示当前生命值和护盾
        Debug.Log("LIfe: " + currentHealth + " " + "Firewall: " + currentShield);

        //玩家受伤后更新游戏界面文字
        UpdateStatusText();

        //如果生命值小于等于0，玩家死亡
        if (currentHealth <= 0)
        {
            Die();
        }
    }

}
