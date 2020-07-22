using System.Collections;
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

    [SerializeField]
    private GameObject m_gameOverCanvasPrefab = null;
    private GameObject m_gameOverCanvasInstance = null;

    [SerializeField]
    private GameObject m_inGameCanvasPrefab = null;
    private GameObject m_inGameCanvasInstance = null;

    private bool m_isPaused = true;

    private PipeSpawner m_pipeSpawner;

    private int m_finalScore = 0;

    //Must use the instance in this function
    //Because it's use like a static function by the play button.
    //It's weird because I cannot set this function static.
    public void OnStartButtonClicked()
    {
        if (m_instance.m_startMenuInstance != null)
        {
            m_instance.m_startMenuInstance.SetActive(false);
        }

        if (m_instance.m_inGameCanvasInstance != null)
        {
            m_instance.m_inGameCanvasInstance.SetActive(true);
        }

        if (m_instance.m_gameOverCanvasInstance != null)
        {
            m_instance.m_gameOverCanvasInstance.SetActive(false);
        }

        Time.timeScale = 1;
        m_instance.m_isPaused = false;
    }

    public void RestartGame(int finalScore_)
    {
        m_finalScore = finalScore_;
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

    private void InitGame(bool isReloadingGame_ = false)
    {
        m_isPaused = true;

        m_startMenuInstance = GameObject.Find(m_startMenuPrefab.name);
        m_startMenuInstance.SetActive(true);

        m_inGameCanvasInstance = GameObject.Find(m_inGameCanvasPrefab.name);
        if (m_inGameCanvasInstance != null)
        {
            m_inGameCanvasInstance.SetActive(false);
        }

        if (isReloadingGame_)
        {
            m_gameOverCanvasInstance = Instantiate(m_gameOverCanvasPrefab);
            m_gameOverCanvasInstance.SetActive(true);
            PointsRenderer pointsRenderer = m_gameOverCanvasInstance.GetComponentInChildren<PointsRenderer>(true) as PointsRenderer;
            if (pointsRenderer)
            {
                pointsRenderer.PointsSet(m_finalScore);
            }
        }
        Time.timeScale = 0;
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static private void InitializationCallback()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    static private void OnSceneLoaded(Scene arg0_, LoadSceneMode arg1_)
    {
        m_instance.InitGame(true);
    }
}
