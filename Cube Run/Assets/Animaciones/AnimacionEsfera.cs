using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionEsfera : MonoBehaviour
{
    private Animator m_Animator;
    private int carrilPrevio;
    private int carrilActual;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setestaDoblando( bool estaDoblando)
    {
        setestaDoblandoI(estaDoblando,0);
        setestaDoblandoD(estaDoblando,0);
    }

    public void setCarril( int carril )
    {
        // m_Animator.SetInteger("Carril", carril);
        // print("carril set" + carril);
    }

    public void setestaDoblandoI( bool estaDoblando, int carril)
    {
        //m_Animator.SetBool("Izquierda", estaDoblando);
        if( estaDoblando && carril == 0)
        {
            //print("d" + estaDoblando);   
            m_Animator.Play("s1to0");         
        }
        else if( estaDoblando && carril == 1)
        {
            //print("d" + estaDoblando);   
            m_Animator.Play("s2to1"); 
        }
    }

    public void setestaDoblandoD( bool estaDoblando, int carril)
    {
        //m_Animator.SetBool("Derecha", estaDoblando);
        if( estaDoblando && carril == 1)
        {
            //print("d" + estaDoblando);   
            m_Animator.Play("s0to1");         
        }
        else if( estaDoblando && carril == 2)
        {
            //print("d" + estaDoblando);   
            m_Animator.Play("s1to2"); 
        }

        //gameObject.GetComponent<Animator>().Play("Coin_Collect_Anim");
        
    }
}
