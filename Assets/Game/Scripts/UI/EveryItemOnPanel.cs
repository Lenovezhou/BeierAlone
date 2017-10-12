using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class EveryItemOnPanel : SpriteButton,IInputClickHandler {

    #region 字段
    private GameObject rotateobj;
    private SpriteRenderer spriterenderer;

    protected override string SoundPath
    {
        get
        {
            return "Spawn";
        }
    }
    #endregion

    #region UNITY回调
    void Start()
    {
        spriterenderer = GetComponentInChildren<SpriteRenderer>();
    }
#endregion





#region Holotoolkit回调
    protected override void OnPressed()
    {
        //声音
        base.OnPressed(); 

        string str = gameObject.name;
        string id = Guid.NewGuid().ToString();
        CustomMessages.Instance.SendSpawnCommand(str + "/" + id,transform.position);
        MessageRecever.Instance.AddobjectToWorld(str, id,transform.position);
    }

    //public void OnInputClicked(InputClickedEventData eventData)
    //{
    //    OnPressed();
    //}
    #region 父类状态机抽象
    protected override void FocusIn()
    {
        if (spriterenderer)
            spriterenderer.color = Color.green;
    }

    protected override void FocusOut()
    {
        if (spriterenderer)
            spriterenderer.color = Color.white;
    }


    protected override void FocusInUpdate(float timer)
    {
    //    spriterenderer.color = Color.Lerp(spriterenderer.color, Color.green, 0.125f);
    }
    protected override void FocusoutUpdate(float timer)
    {
    //    spriterenderer.color = Color.Lerp(spriterenderer.color, Color.yellow, 0.125f);
    }

    #endregion


    #endregion

}
