using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsRenderer : MonoBehaviour
{
    private Text m_PointsText;

    public void PointsSet(int points_)
    {
        m_PointsText.text = points_.ToString();
    }

    private void Awake()
    {
        m_PointsText = GetComponent<Text>();
        m_PointsText.text = "";
    }

    private void Start()
    {
        m_PointsText.enabled = false;
    }

    private void Update()
    {
        if (!m_PointsText.IsActive())
        {
            m_PointsText.enabled = true;
        }
    }
}
