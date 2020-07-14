using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolowPlayerScript : MonoBehaviour
{
    [SerializeField]
    private Transform m_target = null;
    private Transform m_transform;

    private void Start()
    {
        m_transform = GetComponent<Transform>();
    }

    private void Update()
    {
        m_transform.position = new Vector3(m_target.position.x, m_transform.position.y, m_transform.position.z);
    }
}
