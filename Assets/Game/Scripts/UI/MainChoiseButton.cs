using HoloToolkit.Unity.InputModule;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainChoiseButton : SpriteButton, IInputClickHandler
{

    private TextMesh focuschang;
    protected override string SoundPath
    {
        get
        {
            return "MainChoiseButton";
        }
    }


    protected override void OnPressed()
    {
        //声音
        //Sound.Instance.PlayerEffect("MainChoiseButton");
        base.OnPressed();
        string str2 = gameObject.name;
        Dictionary<string, Action> acts = MessageRecever.Instance.acts;
       // DebuggerForMe.Instance.WriteForword("》" + str2,true);
        if (acts.ContainsKey(str2))
        {
            acts[str2]();
        }
        CustomMessages.Instance.SendCommand(str2);
    }

    //public void OnInputClicked(InputClickedEventData eventData)
    //{
    //    OnPressed();
    //}
    #region 父类状态机抽象
    protected override void Awake()
    {
        base.Awake();
        focuschang = GetComponentInChildren<TextMesh>();
    }
    protected override void FocusIn()
    {
        focuschang.color = Color.green;
    }

    protected override void FocusOut()
    {
        focuschang.color = Color.yellow;
    }
    protected override void FocusInUpdate(float timer)
    {
    //    focuschang.color = Color.Lerp(focuschang.color, Color.green,0.125f);
    }
    protected override void FocusoutUpdate(float timer)
    {
     //   focuschang.color = Color.Lerp(focuschang.color, Color.yellow, 0.125f);
    }
    #endregion

}
