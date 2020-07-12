using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    private int m_columns = 20;
    private int m_rows = 10;

    private Transform m_map;
    private List<Vector3> m_grid = new List<Vector3>();

    [SerializeField]
    private GameObject m_dirtTile = null;
    [SerializeField]
    private int m_dirtMaxLevel = 1;

    [SerializeField]
    private GameObject m_groundTile = null;

    [SerializeField]
    private GameObject m_smallPipeTile = null;

    public void Build()
    {
        m_map = new GameObject("Map").transform;
        int counter = 0;

        for (int x = 0; x <= m_columns; ++x)
        {
            for (int y = 0; y <= m_rows; ++y)
            {
                GameObject toInstantiate = null;

                if (y <= m_dirtMaxLevel)
                {
                    toInstantiate = m_dirtTile;
                }
                else if (y == m_dirtMaxLevel + 1)
                {
                    toInstantiate = m_groundTile;
                }
                //temp logic for pipes
                else if ( y == m_dirtMaxLevel + 2 && x % 2 == 0)
                {
                    toInstantiate = m_smallPipeTile;
                }

                if (toInstantiate != null)
                {
                    GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;
                    instance.transform.SetParent(m_map);
                }
            }
            counter++;
        }
    }
}
