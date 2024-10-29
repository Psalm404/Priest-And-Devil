using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Role
{
    public GameObject role;//model对应的游戏对?
    public bool isPriest;
    public bool inBoat;
    public bool onRight;
    public int id;

    public Role(Vector3 position, bool isPriest, int id)
    {
        this.isPriest = isPriest;
        this.id = id;
        onRight = false;
        inBoat = false;
        role = GameObject.Instantiate(Resources.Load("Prefabs/" + (isPriest ? "Farmer" : "Vampire"), typeof(GameObject))) as GameObject;
        role.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        role.transform.position = position;
        role.name = "role" + id;
        role.transform.eulerAngles = new Vector3(0, 90, 0);
        role.AddComponent<Click>();
        role.AddComponent<BoxCollider>();
    }
}