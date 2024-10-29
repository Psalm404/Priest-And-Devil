using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;


public class Boat
{
    public GameObject boat;
    public Role[] roles;
    public bool isRight;
    public int priestCount, devilCount; //���ϵ���ʦ�Ͷ�ħ����

    public Boat(Vector3 position)
    {
        boat = GameObject.Instantiate(Resources.Load("Prefabs/Boat", typeof(GameObject))) as GameObject;
        boat.name = "Boat";
        boat.transform.position = position;
        boat.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);

        roles = new Role[2];        // �������������ɫ
        isRight = false;         // ��ʼ�����
        priestCount = devilCount = 0;      // ��ʼ��ʦ��ħ������Ϊ0
        boat.transform.eulerAngles = new Vector3(0, -90, 0);
        boat.AddComponent<BoxCollider>();              // �����ײ���
        boat.AddComponent<Click>();                    // ��ӵ����� 
    }
}