using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerLoader : MonoBehaviour
{
    public GameManager m_gameManager;

    private void Awake()
    {
        if (GameManager.m_instance == null)
        {
            Instantiate(m_gameManager);
        }
    }
}
