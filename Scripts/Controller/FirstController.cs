﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstController : MonoBehaviour, ISceneController, IUserAction
{
    ShoreCtrl leftShoreController, rightShoreController;
    River river;
    BoatCtrl boatController;
    RoleCtrl[] roleControllers = new RoleCtrl[6];
    MoveCtrl moveController;
    public bool isRunning;
    float time;

    public void LoadResources()
    {
        //如果有，则释放原有的GameObject
        for (int i = 0; i < 6; i++)
        {
            if (roleControllers[i] != null)
            {
                Destroy(roleControllers[i].GetModelGameObject());
            }
        }
        if (leftShoreController != null) Destroy(leftShoreController.GetModelGameObject());
        if (rightShoreController != null) Destroy(rightShoreController.GetModelGameObject());
        if (boatController != null)
        {
            Destroy(boatController.GetModelGameObject());
        }

        //role
        roleControllers = new RoleCtrl[6];
        for (int i = 0; i < 6; ++i)
        {
            roleControllers[i] = new RoleCtrl();
            roleControllers[i].CreateRole(Position.role_shore[i], i < 3 ? true : false, i);
        }

        //shore
        leftShoreController = new ShoreCtrl();
        leftShoreController.CreateShore(Position.left_shore);
        leftShoreController.GetShore().shore.name = "left_shore";
        rightShoreController = new ShoreCtrl();
        rightShoreController.CreateShore(Position.right_shore);
        rightShoreController.GetShore().shore.name = "right_shore";

        //将人物添加并定位至左�?  
        foreach (RoleCtrl roleController in roleControllers)
        {
            roleController.GetRoleModel().role.transform.localPosition = leftShoreController.AddRole(roleController.GetRoleModel());
        }
        //boat
        boatController = new BoatCtrl();
        boatController.CreateBoat(Position.left_boat);

        //river
        if (river == null)
            river = new River(Position.river);

        //move
        moveController = new MoveCtrl();

        isRunning = true;
        time = 200;


    }


    public void MoveBoat()
    {
        if (isRunning == false || moveController.GetIsMoving()) return;
        if (boatController.GetBoatModel().isRight)
        {
            moveController.SetMove(Position.left_boat, boatController.GetBoatModel().boat);
        }
        else
        {
            moveController.SetMove(Position.right_boat, boatController.GetBoatModel().boat);
        }
        boatController.GetBoatModel().isRight = !boatController.GetBoatModel().isRight;
    }

    public void MoveRole(Role roleModel)
    {
        if (isRunning == false || moveController.GetIsMoving()) return;
        if (roleModel.inBoat)
        {
            if (boatController.GetBoatModel().isRight)
            {
                moveController.SetMove(rightShoreController.AddRole(roleModel), roleModel.role);
            }
            else
            {
                moveController.SetMove(leftShoreController.AddRole(roleModel), roleModel.role);
            }
            roleModel.onRight = boatController.GetBoatModel().isRight;
            boatController.RemoveRole(roleModel);

            // 设置角色方向
            roleModel.role.transform.eulerAngles = roleModel.onRight ? new Vector3(0, -90, 0) : new Vector3(0, 90, 0);
        }
        else
        {
            if (!boatController.HasPosition()) return;
            if (boatController.GetBoatModel().isRight == roleModel.onRight)
            {
                if (roleModel.onRight)
                {
                    rightShoreController.RemoveRole(roleModel);
                }
                else
                {
                    leftShoreController.RemoveRole(roleModel);
                }
                moveController.SetMove(boatController.AddRole(roleModel), roleModel.role);
            }
        }
    }

    public void Check()
    {
        if (isRunning == false) return;
        this.gameObject.GetComponent<UserGUI>().gameMessage = "";
        if (rightShoreController.GetShore().priestCount == 3)
        {
            this.gameObject.GetComponent<UserGUI>().gameMessage = "You Win!";
            isRunning = false;
        }
        else
        {
            int leftPriestCount, rightPriestCount, leftDevilCount, rightDevilCount;
            leftPriestCount = leftShoreController.GetShore().priestCount + (boatController.GetBoatModel().isRight ? 0 : boatController.GetBoatModel().priestCount);
            rightPriestCount = rightShoreController.GetShore().priestCount + (boatController.GetBoatModel().isRight ? boatController.GetBoatModel().priestCount : 0);
            leftDevilCount = leftShoreController.GetShore().devilCount + (boatController.GetBoatModel().isRight ? 0 : boatController.GetBoatModel().devilCount);
            rightDevilCount = rightShoreController.GetShore().devilCount + (boatController.GetBoatModel().isRight ? boatController.GetBoatModel().devilCount : 0);
            if ((leftPriestCount != 0 && leftPriestCount < leftDevilCount || rightPriestCount != 0 && rightPriestCount < rightDevilCount) && moveController.GetIsMoving() == false)
            {
                this.gameObject.GetComponent<UserGUI>().gameMessage = "Game Over!";
                isRunning = false;
            }
        }
    }

    void Awake()
    {
        SSDirector.GetInstance().CurrentSceneController = this;
        LoadResources();
        this.gameObject.AddComponent<UserGUI>();
    }

    void Update()
    {
        if (isRunning)
        {
            time -= Time.deltaTime;
            this.gameObject.GetComponent<UserGUI>().time = (int)time;
            if (time <= 0)
            {
                this.gameObject.GetComponent<UserGUI>().time = 0;
                this.gameObject.GetComponent<UserGUI>().gameMessage = "Game Over!";
                isRunning = false;
            }
        }
    }
    public void RestartGame()
    {
        LoadResources();
    }
}