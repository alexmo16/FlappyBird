using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsRenderer : MonoBehaviour
{
    private Text m_PointsText;

    void Awake()
    {
        m_PointsText = GetComponent<Text>();
        m_PointsText.text = "";
        m_PointsText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.m_instance.IsPausedGet() && !m_PointsText.IsActive())
        {
            m_PointsText.enabled = true;
        }
    }

    public void PointsSet(int points_)
    {
        m_PointsText.text = points_.ToString();
    }
}
