using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shore
{
    public GameObject shore;
    public int priestCount, devilCount;
    public Shore(Vector3 position)
    {
        shore = GameObject.Instantiate(Resources.Load("Prefabs/Shore", typeof(GameObject))) as GameObject;
        shore.transform.localScale = new Vector3(6f, 4.8f, 20f);
        shore.transform.position = position;
        priestCount = devilCount = 0;
    }
}