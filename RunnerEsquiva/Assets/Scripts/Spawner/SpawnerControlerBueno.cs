using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerControlerBueno : MonoBehaviour
{
    [SerializeField]
    private GameObject m_Diamante;
    [SerializeField]
    private GameObject m_Oro;
  
    private GameObject m_SpawnZone;
    [SerializeField]
    private float m_SpawnRate = 3f;

    [SerializeField]
    private float m_ratio=0f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }
    IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            m_ratio=Random.Range(0,6);

            
            Vector3 spawnLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0));
            Vector3 spawnRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
            if(m_ratio<5)
            {
                GameObject spawned = Instantiate(m_Diamante);
                spawned.transform.position = new Vector3(Random.Range(spawnLeft.x+20, spawnRight.x-20),8,0);
            }
            
           if(m_ratio==5)
            {
                GameObject spawned = Instantiate(m_Oro);
                spawned.transform.position = new Vector3(Random.Range(spawnLeft.x+20, spawnRight.x-20),8,0);  
            }
            yield return new WaitForSeconds(m_SpawnRate);

        }
    }
}
