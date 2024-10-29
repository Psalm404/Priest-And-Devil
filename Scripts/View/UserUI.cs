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
            // ��ť����߼�
        }
        // �ı���ʾ����
        string tooltipText = "��ʦ��ħ�� Priests and Devils ��һ��������Ϸ�����������а��� Priests and Devils �ڹ涨ʱ���ڹ��ӡ��ӵ�һ���� 3 ����ʦ�� 3 ����ħ�����Ƕ��뵽�������ӵ���һ�ߣ���ֻ��һ�Ҵ����������Ҵ�ÿ��ֻ�ܴ��������ˡ����ұ�����һ���˽�����һ���ʻ����һ�ࡣ�� Flash ��Ϸ�У������Ե����������ƶ����ǣ�Ȼ�󵥻���ʼ��ť�����ƶ�����һ�����������ʦ���������к������Ķ�ħ�����Ǿͻᱻɱ������Ϸ�ͽ����ˡ�������ͨ������>��ʽ���ԡ���������ʦ�����ţ�ף����ˣ�";

        // �����Զ���� GUIStyle ���������ı���С
        GUIStyle tooltipStyle = new GUIStyle(GUI.skin.box);
        tooltipStyle.wordWrap = true; // �Զ�����

        // ������ʾ��������
        float maxWidth = 300; // ���������
        float textHeight = tooltipStyle.CalcHeight(new GUIContent(tooltipText), maxWidth);
        // �����ı��Ŀ��
        Vector2 textSize = tooltipStyle.CalcSize(new GUIContent(tooltipText));
        // �������Ƿ���ͣ�ڰ�ť��
        if (infoButtonRect.Contains(Event.current.mousePosition))
        {
            // ��ʾ����Ӧ��С����ʾ��
            Rect tooltipRect = new Rect(infoButtonRect.x - 80, infoButtonRect.y + 25, maxWidth + 10, textHeight + 10); // ��һЩ�߾�
            GUI.Box(tooltipRect, tooltipText, tooltipStyle);
        }
        // ������¿�ʼ��ť
        if (GUI.Button(new Rect(1500, Screen.height * 0.8f, Screen.width*0.2f, 50), "���¿�ʼ"))
        {
            controller.RestartGame();
        }
    }
}