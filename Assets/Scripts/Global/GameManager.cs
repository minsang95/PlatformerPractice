using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletoneBase<GameManager>
{
    public Action OnGameStart;
    public Action OnGameEnd;

    private void Awake()
    {
        Init();
    }
    public void CallGameStart()
    {
        OnGameStart?.Invoke();
    }
}
