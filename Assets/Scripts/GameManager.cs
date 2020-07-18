using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager m_instance = null;

    private MapGenerator m_mapGenerator;

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
        m_mapGenerator.Build();
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
        m_instance.m_mapGenerator.Build();
    }
}
