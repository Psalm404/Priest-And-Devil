using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position  //�洢���ж����λ��
{
    //�̶�λ�ã��������꣩
    public static Vector3 left_shore = new Vector3(-8, -3, 0);
    public static Vector3 right_shore = new Vector3(8, -3, 0);
    public static Vector3 river = new Vector3(0, -4, 0);
    public static Vector3 left_boat = new Vector3(-2.8f, -2.3f, -0.2f);
    public static Vector3 right_boat = new Vector3(3.1f, -2.3f, -0.2f);

    //��ɫ����ڰ��ߵ�λ��(�������)
    public static Vector3[] role_shore = new Vector3[] { new Vector3(-0.2f, 0.5f, 0), new Vector3(-0.1f, 0.5f, 0), new Vector3(0.0f, 0.5f, 0), new Vector3(0.1f, 0.5f, 0), new Vector3(0.2f, 0.5f, 0), new Vector3(0.3f, 0.5f, 0) };

    //��ɫ����ڴ���λ��(�������)
    public static Vector3[] role_boat = new Vector3[] { new Vector3(0.2f, 0.85f, 0), new Vector3(0.2f, 0.85f, 7) };

}