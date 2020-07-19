﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager m_instance = null;

    [SerializeField]
    private GameObject m_startMenuPrefab = null;
    private GameObject m_startMenuInstance = null;

    private bool m_isPaused = true;

    private PipeSpawner m_pipeSpawner;

    //Must use the instance in this function
    //Because it's use like a static function by the play button.
    //It's weird because I cannot set this function static.
    public void OnStartButtonClicked()
    {
        m_instance.m_startMenuInstance.SetActive(false);
        Time.timeScale = 1;
        m_instance.m_isPaused = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public bool IsPausedGet()
    {
        return m_isPaused;
    }

    private void Awake()
    {
        if (m_instance == null)
        {
            m_instance = this;
        }
        else if (m_instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        m_pipeSpawner = GetComponent<PipeSpawner>();
        InitGame();
    }

    private void InitGame()
    {
        m_startMenuInstance = GameObject.Find(m_startMenuPrefab.name);
        m_startMenuInstance.SetActive(true);
        Time.timeScale = 0;
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static private void InitializationCallback()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    static private void OnSceneLoaded(Scene arg0_, LoadSceneMode arg1_)
    {
        m_instance.InitGame();
    }
}
