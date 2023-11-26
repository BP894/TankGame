using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner_Death : MonoBehaviour
{
    public static ItemSpawner_Death instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<ItemSpawner_Death>();
            }

            return m_instance;
        }
    }
    private static ItemSpawner_Death m_instance;

    public GameObject[] items;
    public void Spawn(Vector3 spawnPosition)
    {
        GameObject selectedItem = items[Random.Range(0, items.Length)];
        spawnPosition.y = 1.1f;
        GameObject item = Instantiate(selectedItem, spawnPosition, Quaternion.identity);

        Destroy(item, 10.0f);
    }
}
