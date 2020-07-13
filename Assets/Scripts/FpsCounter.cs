using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FpsCounter : MonoBehaviour
{
    [SerializeField]
    private Text m_fpsText;

    private float m_deltaTime = 0f;

    void Awake()
    {
        if (!Debug.isDebugBuild)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        m_deltaTime += (Time.deltaTime - m_deltaTime) * 0.1f;
        float fps = 1.0f / m_deltaTime;
        m_fpsText.text = Mathf.Ceil(fps).ToString() + " FPS";
    }
}
