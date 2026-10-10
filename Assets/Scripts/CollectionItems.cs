using UnityEngine;
using TMPro;

public class CollectionItems : MonoBehaviour
{
    //这件收集品的代表的名称
    public string collectionItemsName = "Wisdom";

    //收集品随机出现的中心位置
    public Vector2 spawnCenter = Vector2.zero;

    //收集品可以出现的区域大小
    public Vector2 spawnArea = new Vector2(34f, 20f);

    //记录所有收集品的总进度
    //public static int collectedCount = 0;
   // public static int totalItems = 6;

    //绑定UI组件
    //public TMP_Text statusText;

    public void Start()
    {
        //在刷新区域的一半以内，随机生成x，y的坐标
        float randomX = Random.Range(spawnCenter.x - spawnArea.x / 2f, spawnCenter.x + spawnArea.x / 2f);
        float randomY = Random.Range(spawnCenter.y - spawnArea.y / 2f, spawnCenter.y + spawnArea.y / 2f);

        //把收集品移动到随机位置，并保留原来的Z坐标
        transform.position = new Vector3(randomX, randomY, transform.position.z);

       
    }

    //当其他带有collider2D 的物体进入触发区时调用
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //判断进入触发区的物体是不是玩家
        if (collision.CompareTag("Player"))
        {
            //把收集品交给CollectionCounter记录
            bool collected = CollectionCounter.Instance.CollectDefinition
                (collectionItemsName);


           

            //在 Console 中显示收集到的定义名称
            Debug.Log("Collection items: " + collectionItemsName);

            //如果收集成功后，让文字消失
            if (collected)
            {
                Destroy(gameObject);
            }
            
            
            
        }
    }

   
 
    //在Scene窗口中显示收集品的随机刷新范围
    private void OnDrawGizmosSelected()
    {
        //把范围框设置成青色，方便区别
        Gizmos.color = Color.cyan;

        //绘制刷新范围的线框
        Gizmos.DrawWireCube(new Vector3(spawnCenter.x, spawnCenter.y,0f),new Vector3(spawnArea.x, spawnArea.y,0f));

    }
}
