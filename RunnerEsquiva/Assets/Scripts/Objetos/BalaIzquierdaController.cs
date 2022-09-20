using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaIzquierdaController : MonoBehaviour
{
private Rigidbody2D m_BalaIzq;

    
    
    void Awake()
    {
        m_BalaIzq = GetComponent<Rigidbody2D>();
        m_BalaIzq.velocity = new Vector3(2f,0,0);

    }


    
}
