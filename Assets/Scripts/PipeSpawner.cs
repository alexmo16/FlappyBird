using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField]
    private float m_spawnPositionX = 20f;
    [SerializeField]
    private float m_spawnPositionY = 6f;
    [SerializeField]
    private GameObject m_pipePrefab = null;
    [SerializeField]
    private float m_maxTime = 1f;
    [SerializeField]
    private float m_heightVariant = 0f;

    private float m_timer = 0f;

    private void Spawn()
    {
        float yPosition = m_spawnPositionY + Random.Range(-m_heightVariant, m_heightVariant);
        Instantiate(m_pipePrefab, new Vector3(m_spawnPositionX, yPosition), Quaternion.identity);
    }

    private void Update()
    {
        if (m_timer > m_maxTime)
        {
            Spawn();
            m_timer = 0;
        }

        m_timer += Time.deltaTime;
    }
}
