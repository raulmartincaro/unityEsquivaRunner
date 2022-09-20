using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerInferiorController : MonoBehaviour
{
    [SerializeField]
    private GameObject m_BalaInferior;

    [SerializeField]
    private float m_SpawnRate = 1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCoroutine());
        
    }

   IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            GameObject spawned = Instantiate(m_BalaInferior);

            spawned.transform.position = new Vector3((Random.Range(-17,17)),-14,0);
            yield return new WaitForSeconds(m_SpawnRate);

        }
    }
}
