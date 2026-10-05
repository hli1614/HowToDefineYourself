using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    //要紧跟随的目标是玩家
    public Transform target;

    //摄像机与玩家之间的距离
    public Vector3 offset = new Vector3(0, 0, -10);

    void Start()
    {
        //如果Inspector中没有设置目标，就自动寻找Player
        if (target == null)
        {
            GameObject playerObject = GameObject.Find("Player");

            //如果找到了Player，就获取它的变化
            if (playerObject != null)
            {
                target = playerObject.transform;
            }
            else
            {
                Debug.LogError("Can't Find palyer.");
            }

        }
    }
    void LateUpdate()
    {
        // 临时测试：每帧打印摄像机跟随脚本是否正在执行
        //Debug.Log("CameraFollow 正在运行");
        // 如果没有目标就不跟随
        if (target == null)
        {
            return;
        }
        transform.position = target.position + offset;
    }
}
    


