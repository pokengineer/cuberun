using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject auto;
    public float[] carriles = new float[3];
    public int frecuencia;
    private float z;

    //obstaculos
    public GameObject obs;
    public GameObject obsDos;
    private int obstaculos = 0;
    private GameObject[] ListaObs = new GameObject[15];
    private int pListaObs;
    private int dificultad = 1;
    private int velocidad=0;

    //calles
    public GameObject[] Calles = new GameObject[2];

    //UI
    public GameObject PantallaFinal;
    public Text puntaje;

    //audio
    public GameObject musica;

    //Efectos
    public ParticleSystem explosion;
    public GameObject pop;

    
    // Start is called before the first frame update
    void Start()
    {
        pListaObs = 1;
    }

    // Update is called once per frame
    void Update()
    {
        z = auto.transform.position.z;
        //frecuencia = 100 - 10*dificultad;
        dificultad = (int)z/1000;

        //spawn objetos
        if( obstaculos * 100 < z )
        {
            if(  z > 1000 &&  Random.Range(-2.5f,1f) > 0 )
            {
                spawnObstaculox2();
            }
            else
            {
                spawnObstaculo();
            }
        }


        //calle infinita
        if( z-50 > dificultad * 1000 )
        {
            Calles[dificultad%2].transform.position = new Vector3(0,0,  dificultad*1000+1500);
        }

        if( z > (dificultad+1)*300 && velocidad != (dificultad+1)*300 )
        {
            velocidad = (dificultad+1)*300;
            auto.GetComponent<AutitoAndroid>().subirVelocidad( );
        }

        puntaje.text = ((int)(z/42)).ToString();

    }

    private void spawnObstaculo()
    {   
        ListaObs[obstaculos%15] = Instantiate( obs , new Vector3( carriles[(int)Random.Range(0f,2.999f)] , 0.5f , z + frecuencia ) , Quaternion.identity);

        Destroy( ListaObs[pListaObs%15] );
        //print(ListaObs[pListaObs%15]);
        this.obstaculos++;
        this.pListaObs++;
    }

    private void spawnObstaculox2()
    {   
        if( Random.Range(-1f,1f) > 0)
        {
            ListaObs[obstaculos%15] = Instantiate( obsDos , new Vector3( 0.55f , 0.5f , z + frecuencia ) , Quaternion.identity);
        }else
        {
            ListaObs[obstaculos%15] = Instantiate( obsDos , new Vector3( -0.55f , 0.5f , z + frecuencia ) , Quaternion.identity);
        }

        Destroy( ListaObs[pListaObs%15] );
        //print(ListaObs[pListaObs%15]);
        this.obstaculos++;
        this.pListaObs++;
    }

    public void choco()
    {
        PantallaFinal.SetActive( true );
        AudioSource m_MyAudioSource = musica.GetComponent<AudioSource>();
        Instantiate(explosion, auto.transform.position , Quaternion.identity);
        Instantiate(pop);
        //Destroy(auto);
        auto.SetActive(false);
        m_MyAudioSource.Stop();
    }
}
