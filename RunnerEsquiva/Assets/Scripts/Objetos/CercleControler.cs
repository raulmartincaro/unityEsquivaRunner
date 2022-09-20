using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CercleControler : MonoBehaviour
{
    [SerializeField]
	private float m_Movimiento = 5f;
	[SerializeField]
	private float m_Salto = 5f;
    private int m_SaltosDisponibles=0;
    [SerializeField]
    public int m_Puntos;
    public delegate void ActualizaPuntos(int puntos);
    public event ActualizaPuntos OnActualizaPuntos;
   

    private Rigidbody2D m_Protagonista;
    SpriteRenderer sprite;
   

    public int m_Vidas = 5;
    public delegate void ActualizaVidas(int vidas);
    public event ActualizaVidas OnActualizaVidas;
    public bool invulnerabilidad = false;
    public int tiempoInvulnerabiliadad = 5;

    void Awake()
    {
        m_Protagonista = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        m_Puntos=0;
        m_Vidas=5;
        sprite= GetComponent<SpriteRenderer>();
    }
  
    // Update is called once per frame
    void Update()
    {
       
		if(Input.GetKey(KeyCode.A))
		{
			m_Protagonista.velocity = new Vector3(-m_Movimiento,m_Protagonista.velocity.y,0);
			
		}
		
		if(Input.GetKey(KeyCode.D))
		{
			
			m_Protagonista.velocity = new Vector3(m_Movimiento,m_Protagonista.velocity.y,0);
			
		}
		
		if((m_SaltosDisponibles>0)&&(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)))
		{
			m_Protagonista.velocity = new Vector3(m_Protagonista.velocity.x,m_Salto,0);
            m_SaltosDisponibles -=1;
		}

        if (invulnerabilidad == true)
        {
        
            sprite.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Tierra")
            m_SaltosDisponibles=2;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Premio")
        {
            m_Puntos += col.gameObject.GetComponent<PremioController>().Puntuacio;
            Destroy(col.gameObject);
            OnActualizaPuntos.Invoke(m_Puntos);
        }
        if (col.gameObject.tag == "Peligro")
        {
            if (invulnerabilidad == false)
            {
                Destroy(col.gameObject);
                QuitarVida(1);
            }
        }
        if (col.gameObject.tag == "Eliminador")
        {
            QuitarVida(1);
        }
    }

    void QuitarVida(int vida)
    {
        m_Vidas -= vida;
        
        if(m_Vidas<0)
            m_Vidas = 0;

        m_Protagonista.transform.position = new Vector3(6, 1, 0);
        OnActualizaVidas.Invoke(m_Vidas);
        StartCoroutine(Invulnerable());
    }

    private IEnumerator Invulnerable()
    {
        invulnerabilidad = true;
        yield return new WaitForSeconds(tiempoInvulnerabiliadad);
        invulnerabilidad = false;
    }
   
}
