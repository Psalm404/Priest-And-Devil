using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserGUI : MonoBehaviour
{
    IUserAction userAction;
    public string gameMessage;
    public int time;
    GUIStyle style, bigstyle;
    FirstController controller;
    // Start is called before the first frame update
    void Start()
    {
        time = 60;
        userAction = SSDirector.GetInstance().CurrentSceneController as IUserAction;
        controller = SSDirector.GetInstance().CurrentSceneController as FirstController;
        style = new GUIStyle();
        style.normal.textColor = Color.white;
        style.fontSize = 100;
    }

    // Update is called once per frame
    void OnGUI()
    {
        userAction.Check();
        GUI.Label(new Rect(250, 20, 50, 200), gameMessage, style);
        GUI.Label(new Rect(40, 20, 100, 50), "Time: " + time, style);
        Rect infoButtonRect = new Rect(1600, Screen.height * 0.9f, 50, 25);
        if (GUI.Button(infoButtonRect, "?"))
        {
            // 按钮点击逻辑
        }
        // 文本提示内容
        string tooltipText = "牧师与魔鬼 Priests and Devils 是一款益智游戏，您将在其中帮助 Priests and Devils 在规定时间内过河。河的一侧有 3 个牧师和 3 个恶魔。他们都想到达这条河的另一边，但只有一艘船，而且这艘船每次只能搭载两个人。并且必须有一个人将船从一侧驾驶到另一侧。在 Flash 游戏中，您可以单击它们来移动它们，然后单击开始按钮将船移动到另一个方向。如果牧师的人数不敌河两岸的恶魔，他们就会被杀死，游戏就结束了。您可以通过多种>方式尝试。让所有牧师都活着！祝你好运！";

        // 创建自定义的 GUIStyle 用来计算文本大小
        GUIStyle tooltipStyle = new GUIStyle(GUI.skin.box);
        tooltipStyle.wordWrap = true; // 自动换行

        // 限制提示框的最大宽度
        float maxWidth = 300; // 设置最大宽度
        float textHeight = tooltipStyle.CalcHeight(new GUIContent(tooltipText), maxWidth);
        // 计算文本的宽高
        Vector2 textSize = tooltipStyle.CalcSize(new GUIContent(tooltipText));
        // 检查鼠标是否悬停在按钮上
        if (infoButtonRect.Contains(Event.current.mousePosition))
        {
            // 显示自适应大小的提示框
            Rect tooltipRect = new Rect(infoButtonRect.x - 80, infoButtonRect.y + 25, maxWidth + 10, textHeight + 10); // 加一些边距
            GUI.Box(tooltipRect, tooltipText, tooltipStyle);
        }
        // 添加重新开始按钮
        if (GUI.Button(new Rect(1500, Screen.height * 0.8f, Screen.width*0.2f, 50), "重新开始"))
        {
            controller.RestartGame();
        }
    }
}