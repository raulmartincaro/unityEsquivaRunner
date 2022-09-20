using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    private static GameManager m_Instance;
    public static GameManager Instance
    {
        get { return m_Instance; }
    }

    //[SerializeField]
    private CercleControler m_Protagonista;
    [SerializeField]
    private GameObject m_spawnerInferior;
    [SerializeField]
    private GameObject m_spawnerIzquierdo;
    [SerializeField]
    private GameObject m_spawnerSuperior;

    int m_level = 1;
    public int manag_puntos=0;
    public delegate void ActualizaNivell(int nivell);
    public event ActualizaNivell OnActualizaNivell;

    
     private void Awake()
    {
        if (m_Instance == null)
            m_Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
        Init();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "GameScene")
            Init();
    }

    void Init()
    {
        m_Protagonista = FindObjectOfType<CercleControler>();
        m_Protagonista.OnActualizaPuntos += ActualizarPuntuacion;
        m_Protagonista.OnActualizaVidas += ActualizarVidas;
        m_level = 1;
        manag_puntos = 0;
    }

    void Deinitialize()
    {
        m_Protagonista.OnActualizaPuntos -= ActualizarPuntuacion;
        m_Protagonista.OnActualizaVidas -= ActualizarVidas;
    }

    void Update(){
          if (Input.GetKeyDown(KeyCode.R))
          {
               Deinitialize();
               SceneManager.LoadScene("GameScene");
          }    
    }
    
  
    //gestion de subda de niveles
    void ActualizarPuntuacion(int puntos)
    {
        manag_puntos=puntos;
        if (puntos == 10||puntos==11)
        {
            LevelUp(2);
        }
        if (puntos == 20|| puntos==21)
        {
            LevelUp(3);
        }
        //implementacion de niveles infinitos sin repeticion
        if ((puntos%10==0||(puntos-1)%10==0)&&puntos>21)
        {
            if(puntos/10==m_level||(puntos-1)/10==m_level)
            LevelUp(m_level+1);
        }

    }

    void LevelUp(int level)
    {
        if (level != m_level)
        {
            m_level = level;
            levelUp();
        }
    }
  
    
   void levelUp()
    {
        switch (m_level)
        {
            case 2:
                Instantiate(m_spawnerInferior);
                break;
            case 3:
                Instantiate(m_spawnerIzquierdo);
                break;
            default:
                int creacion =(Random.Range(0,2));
                if(creacion==0){
                Instantiate(m_spawnerInferior);
                }else{
                Instantiate(m_spawnerSuperior);
                }
            break;
        }

        OnActualizaNivell.Invoke(m_level);
    }

    //carga de pantalla de gameOver
    private void ActualizarVidas(int vidas)
    {
      
       if(vidas==0)
            SceneManager.LoadScene("GameOver");


    }
}
