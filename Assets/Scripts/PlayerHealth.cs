using UnityEngine;
using TMPro;

using System.Data;
using Unity.VisualScripting;
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

    //玩家死亡时显示游戏结束文字
    public TextMeshProUGUI gmaeOverText;

    //玩家死亡后就显示重新开始按钮
    public GameObject restartButton;

    //游戏开始时隐藏重新开始按钮
    
    




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

        //确保游戏开始时正常运行
        Time.timeScale = 1f;

        //游戏开始时隐藏游戏结束文字
        if(gmaeOverText != null)
        {
            gmaeOverText.gameObject.SetActive(false);
        }

        //游戏开始时隐藏重新开始按钮
        if(restartButton != null )
        {
            restartButton.SetActive(false);
        }
    }

    //玩家死亡的方法
    private void Die()
    {
        Debug.Log("You have been reset.");

        //如果已经连接游戏结束文字，就显示它
        if(gmaeOverText != null)
        {
            gmaeOverText.text = "You have been reset.";
            gmaeOverText.gameObject.SetActive(true);
        }
        if(restartButton != null)
        {
            restartButton.SetActive(true);
        }


        //将游戏时间速度设为0，让整个游戏暂停
        Time.timeScale = 0f;

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
