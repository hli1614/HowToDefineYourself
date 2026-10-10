using UnityEngine;
using System.Collections;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    // 需要生成的敌人Prefab
    public GameObject enemyPrefab;

    //总共生成的敌人的数量
    public int totalEnemies = 10;

    //每个敌人生成之间的时间间隔
    public float spawnInterval = 3f;

    //敌人随机出现区域的宽度和高度
    public Vector2 spawnAreaSize = new Vector2(36f, 20f);

    //玩家胜利时显示的文字
    public TextMeshProUGUI victoryText;

    //玩家胜利后显示重新开始按钮
    public GameObject restartButton;

    //画师致谢
    public GameObject artistCrediText;



    //检查场中是否还有敌人
    private bool AllEnemiesDefeated()
    {
        //寻找场中所有带EnemyHealth的敌人
        EnemyHealth[] remainingEnemies = FindObjectsByType<EnemyHealth>(FindObjectsSortMode.None);

        //如果数量为0，则全部消灭
        return remainingEnemies.Length == 0;
    }

    //显示胜利画面
    private void ShowVictory()
    {
        //检查玩家是否已经收集全部6个定义
        bool collectedAllDefinitions = CollectionCounter.Instance != null
            && CollectionCounter.Instance.HasCollectedAllDefinitions();

        //显示胜利文字
        if(victoryText != null)
        {
            if (collectedAllDefinitions)
            {
                victoryText.text = "You are the light of humanity.";
            }
            else
            {
                victoryText.text = "You eliminated the dissenters.";
            }
            
            victoryText.gameObject.SetActive(true);
        }

        //显示重新开始按钮
        if (restartButton != null)
        {
            restartButton.SetActive(true);
        }

        //显示画师致谢
        if(artistCrediText != null)
        {
            artistCrediText.SetActive(true);
        }

        //暂停游戏
        Time.timeScale = 0f;
    }


    //逐个刷怪程序
    private IEnumerator SpawnEnemies()
    {
        //重复生成敌人，直到达到总数量
        for(int i=0; i < totalEnemies; i++)
        {
            //在一个限定区域随机选择一个x和y位置
            float randomX = Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f);
            float randomY = Random.Range(-spawnAreaSize.y / 2f, spawnAreaSize.y / 2f);

            //把随机位置加到EnemySpawner的位置上
            Vector2 spawnPosition = (Vector2)transform.position + new Vector2(randomX, randomY);

            //在随机位置生成一个敌人
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            //等待指定时间后再生成下一个敌人
            yield return new WaitForSeconds(spawnInterval);

        }

        //敌人全部生成后，等待所有敌人被消灭
        yield return new WaitUntil(AllEnemiesDefeated);

        //显示胜利画面
        ShowVictory();
    }

    //在Scene窗口中画出刷怪范围，方便调整
    private void OnDrawGizmosSelected()
    {
        //设置范围线框颜色
        Gizmos.color = Color.red;

        //画出刷怪区域的矩形线框
        Gizmos.DrawWireCube(transform.position, spawnAreaSize);
    }

    //游戏开始时自动启动刷怪程序
    private void Start()
    {
        //游戏开始时隐藏胜利文字和致谢
        if(victoryText != null)
        {
            victoryText.gameObject.SetActive(false);
        }
        if(artistCrediText != null)
        {
            restartButton.SetActive(false);
        }

        //游戏开始时隐藏重新开始按钮
        if (restartButton != null)
        {
            restartButton.SetActive(false);
        }

        //启动逐个生成敌人程序
        StartCoroutine(SpawnEnemies());
    }

}
