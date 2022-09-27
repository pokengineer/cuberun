using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boton : MonoBehaviour
{
    private bool laMusicaEstaSonando = true;
    public GameObject pantallaCreditos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void retry()
    {
        SceneManager.LoadScene("testcubo");
    }

    public void music()
    {
        GameObject musica = GameObject.Find("Musica");
        AudioSource m_MyAudioSource = musica.GetComponent<AudioSource>();
        
        if(laMusicaEstaSonando)
        {
            m_MyAudioSource.Pause();
            laMusicaEstaSonando = false;
        }
        else
        {
            m_MyAudioSource.UnPause();
            laMusicaEstaSonando  = true;
        }
    }

    public void creditos( bool activo)
    {
        pantallaCreditos.SetActive( activo );
    }

     
}