using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerControlerIzquierdo : MonoBehaviour
{
   [SerializeField]
    private GameObject m_BalaIzquierda;


    private GameObject m_SpawnZone;

    [SerializeField]
    private float m_SpawnRate = 5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCoroutine());
        
    }

   IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            GameObject spawned = Instantiate(m_BalaIzquierda);

            spawned.transform.position = new Vector3(-20,(Random.Range(-2.4f,0)),0);
            yield return new WaitForSeconds(m_SpawnRate);

        }
    }
}
