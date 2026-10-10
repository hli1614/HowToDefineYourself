using UnityEngine;
using TMPro;
using System.Collections.Generic;
public class CollectionCounter : MonoBehaviour
{
    //让其他脚本可以找到这个管理器
    public static CollectionCounter Instance;

    //场景中的文字
    public TextMeshProUGUI countText;

    //画师致谢
    //public GameObject artistCrediText;



    // 保存已经收集过的定义
    public HashSet<string> collectedDefinitions = new HashSet<string>();

    private void Awake()
    {
        //保存当前这个管理器
        Instance = this;
        //游戏开始显示0/6
        UpdateCountText();
    
    }
    //收集一个定义
    public bool CollectDefinition(string definitionName)
    {
        //如果已经拿过，不在增加
        if (collectedDefinitions.Contains(definitionName))
        {
            return false;
        }

        // 记录新的定义
        collectedDefinitions.Add(definitionName);

        //更新计数
        UpdateCountText();

        return true;
    }

    //检查玩家是否已经集齐6种定义
    public bool HasCollectedAllDefinitions()
    {
        //HashSet种有6个不同的名称时为真
        return collectedDefinitions.Count >= 6;
    }
    //更新计数
    private void UpdateCountText()
    {
        if (countText != null)
        {
            countText.text = "Definitions: " + collectedDefinitions.Count + " / 6";
        }
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
