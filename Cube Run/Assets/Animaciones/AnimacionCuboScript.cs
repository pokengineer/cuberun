using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionCuboScript : MonoBehaviour
{
    private Animator m_Animator;
    private int carrilPrevio;
    private int carrilActual;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    // public void estaDoblandoI( bool estaDoblando, int carril)
    // {
    //     m_Animator.Play("izquierda");
    // }

    // public void estaDoblandoD( bool estaDoblando, int carril)
    // {
    //     m_Animator.Play("derecha");
    // }

    public void estaDoblandoI( bool estaDoblando, int carril)
    {
        //m_Animator.SetBool("Izquierda", estaDoblando);
        if( estaDoblando && carril == 0)
        {
            //print("d" + estaDoblando);   
            m_Animator.Play("izquierda");         
        }
        else if( estaDoblando && carril == 1)
        {
            //print("d" + estaDoblando);   
            m_Animator.Play("izquierda 2"); 
        }
    }

    public void estaDoblandoD( bool estaDoblando, int carril)
    {
        //m_Animator.SetBool("Derecha", estaDoblando);
        if( estaDoblando && carril == 1)
        {
            //print("d" + estaDoblando);   
            m_Animator.Play("derecha");         
        }
        else if( estaDoblando && carril == 2)
        {
            //print("d" + estaDoblando);   
            m_Animator.Play("derecha 2"); 
        }

        //gameObject.GetComponent<Animator>().Play("Coin_Collect_Anim");
        
    }
}
