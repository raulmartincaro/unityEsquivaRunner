using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIGameOver : MonoBehaviour
{
[SerializeField]
private TMPro.TextMeshProUGUI m_TextoOver;

  private void Awake()
    {
        m_TextoOver.text+="La puntuacion final es " + GameManager.Instance.manag_puntos;
        
    }

}
