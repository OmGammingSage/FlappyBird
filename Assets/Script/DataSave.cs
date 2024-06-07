using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSave : MonoBehaviour
{
    #region GetInstance

    public static DataSave Instance;

    private void Awake()
    {
        if (LoadGameData())
        {
            _HomeMenu.gameObject.SetActive(true);
            _Tutoria.gameObject.SetActive(false);
        }
        else
        {
            _HomeMenu.gameObject.SetActive(false);
            _Tutoria.gameObject.SetActive(true);
            SaveDataGame();
        }

        Instance = this;
    }

    #endregion

    [SerializeField] private GameObject _Tutoria;
    [SerializeField] private GameObject _HomeMenu;

    private int _Score;

    public void SaveData(int score)
    {
        PlayerPrefs.SetInt("Score", score);
    }

    public int LoadData()
    {
        _Score = PlayerPrefs.GetInt("Score", 0);
        return _Score;
    }

    public void SaveDataGame()
    {
        PlayerPrefs.SetInt("IsTutoria", 1);
    }

    private bool LoadGameData()
    {
        bool IsLoad = (PlayerPrefs.GetInt("IsTutoria", 0) == 1 ? true : false);
        return IsLoad;
    }
}