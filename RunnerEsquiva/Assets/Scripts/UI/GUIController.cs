using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIController : MonoBehaviour
{

    [SerializeField]
    private CercleControler m_Protagonista;
    [SerializeField]
    private TMPro.TextMeshProUGUI m_TextoPuntos;
    [SerializeField]
    private TMPro.TextMeshProUGUI m_TextoVidas;
    [SerializeField]
    private GameManager m_GameManager;
    [SerializeField]
    private TMPro.TextMeshProUGUI m_TextoLevel;
    private void Awake()
    {
       
        m_Protagonista.OnActualizaPuntos += ActualizarPuntuacion;
        m_Protagonista.OnActualizaVidas += ActualizarVidas;
        m_GameManager.OnActualizaNivell += ActualizaNivell;
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
        m_GameManager = FindObjectOfType<GameManager>();
        m_Protagonista.OnActualizaPuntos += ActualizarPuntuacion;
        m_Protagonista.OnActualizaVidas += ActualizarVidas;
        m_GameManager.OnActualizaNivell += ActualizaNivell;
    }


    private void ActualizarPuntuacion(int puntos)
    {
        m_TextoPuntos.text = "Puntuacio: "+puntos;
    }

    private void ActualizarVidas(int vidas)
    {
        m_TextoVidas.text = "Vides: " + vidas;
    }
    private void ActualizaNivell(int nivell)
    {
            m_TextoLevel.text = "Nivell: " + nivell;
    }

    private void OnDestroy()
    {
        m_Protagonista.OnActualizaPuntos -= ActualizarPuntuacion;
        m_Protagonista.OnActualizaVidas -= ActualizarVidas;
        m_GameManager.OnActualizaNivell -= ActualizaNivell;

    }
}
