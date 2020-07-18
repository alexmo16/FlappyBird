using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager m_instance = null;

    private MapGenerator m_mapGenerator;

    [SerializeField]
    private GameObject m_startMenuPrefab = null;
    private GameObject m_startMenuInstance = null;

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
        m_mapGenerator = GetComponent<MapGenerator>();
        InitGame();
    }

    private void InitGame()
    {
        Time.timeScale = 0;
        m_startMenuInstance = GameObject.Find(m_startMenuPrefab.name);
        m_startMenuInstance.SetActive(true);
        m_mapGenerator.Build();
    }

    public void OnStartButtonClicked()
    {
        m_instance.m_startMenuInstance.SetActive(false);
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
