using UnityEngine;

//导入Unity的场景管理功能
using UnityEngine.SceneManagement;

public class RestartGame :MonoBehaviour
{
    //重新开始游戏的方法
    //public表示这个方法可以显示再按钮的On click列表中
    public void Restart()
    {
        //恢复正常游戏速度
        //因为玩家死亡时我们吧Time.timeScale设置成了0
        Time.timeScale = 1f;

        //获取当前场景的名字，并重新加载这个场景
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    
}
