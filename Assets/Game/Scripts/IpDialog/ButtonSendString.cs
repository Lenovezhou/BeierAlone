using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSendString : SpriteButton
{
    [SerializeField]
    NumpadController nc;

    protected override string SoundPath
    {
        get
        {
            return "Move";
        }
    }

    protected override void OnPressed()
    {
        base.OnPressed();
        nc.AddString(GetComponentInChildren<UnityEngine.UI.Text>().text);
    }

    public void SendString()
    {
        //Sound.Instance.PlayerEffect("Move");
        //nc.AddString(GetComponentInChildren<UnityEngine.UI.Text>().text);
    }
    #region 父类状态抽象
    protected override void FocusIn()
    {
        //throw new System.NotImplementedException();
    }

    protected override void FocusInUpdate(float timer)
    {
        //throw new System.NotImplementedException();
    }

    protected override void FocusOut()
    {
        //throw new System.NotImplementedException();
    }

    protected override void FocusoutUpdate(float timer)
    {
        //throw new System.NotImplementedException();
    }

    #endregion
}
