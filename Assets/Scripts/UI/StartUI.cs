using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartUI : MonoBehaviour
{
    private Button StartBtn;
    private void Awake()
    {
        StartBtn = GetComponentInChildren<Button>();
        StartBtn.onClick.AddListener(GameManager.Instance.CallGameStart);
    }
    private void Start()
    {
        GameManager.Instance.OnGameStart += GameStart;
    }
    private void GameStart()
    {
        SceneManager.LoadScene("MainScene");
    }
}
