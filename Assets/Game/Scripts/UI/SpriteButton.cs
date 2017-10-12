using HoloToolkit.Unity.InputModule;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class SpriteButton : StateMechinePro, IFocusable, IInputClickHandler
{
    #region 状态
    protected State focusin = new State();
    protected State focusout = new State();

    #endregion
    protected abstract string SoundPath { get; }


    protected virtual void Awake()
    {
        focusin.OnEnter = FocusIn;
        focusin.OnUpdate = FocusInUpdate; 
        focusout.OnEnter = FocusOut;
        focusout.OnUpdate = FocusoutUpdate;
    }

    protected void Update()
    {
        OnUpdater(Time.deltaTime);
    }


    protected void PlaySound()
    {
        Sound.Instance.PlayerEffect(SoundPath);
    }

    protected virtual void OnPressed()
    {
        PlaySound();
    }
    protected abstract void FocusIn();
    protected abstract void FocusInUpdate(float timer);
    protected abstract void FocusOut();
    protected abstract void FocusoutUpdate(float timer);

#if UNITY_EDITOR
    private void OnMouseDown()
    {
        OnPressed();
    }
#endif

    public void OnFocusEnter()
    {
        STATE = focusin;
    }

    public void OnFocusExit()
    {
        STATE = focusout;
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        OnPressed();
    }
}
