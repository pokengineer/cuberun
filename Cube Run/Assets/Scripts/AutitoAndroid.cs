using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutitoAndroid : MonoBehaviour
{
    public int carril = 0;
    public float[] carriles = new float[3];

    Vector3 desiredPosition;

    public Rigidbody rb;

    //movimiento
    private bool choco = false;
    private bool estadoblando = false;
    public float speed= 50;
    private AnimacionCuboScript acs;

    //swipe
    private Vector2 firstPressPos;
    private Vector2 secondPressPos;
    private Vector2 currentSwipe;
    private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position
    private float dragDistance;  //minimum distance for a swipe to be registered

    //camara
    public GameObject camara;



 
    void Start()
    {
        dragDistance = Screen.height * 30 / 100; //dragDistance is 15% height of the screen
        
        GameObject cubito = GameObject.Find("Pj");
        acs = cubito.GetComponent<AnimacionCuboScript>(); 
    }
 
    void Update()
    {
        
        if(!estadoblando && !choco)
        {
            Swipe();
        }

    }

    void LateUpdate()
    {
        //movimiento
        desiredPosition = new Vector3( carriles[carril], transform.position.y ,transform.position.z + speed * Time.deltaTime * 5) ;
        Vector3 smoothedPosition = Vector3.Lerp( transform.position, desiredPosition, (float)0.2);
        if( smoothedPosition.x > transform.position.x * 0.9  || smoothedPosition.x < transform.position.x * 1.1 )
        {
            estadoblando = false;
        }
        print(smoothedPosition.x + " - " + transform.position.x);
        transform.position = smoothedPosition;
    }

    private void doblarDerecha()
    {
        if(carril < 2)
        {
            carril +=1 ;
            estadoblando = true;
            acs.estaDoblandoD( true, carril );
        }

    }

    private void doblarIzquierda()
    {
        if(carril > 0)
        {
            carril -= 1;
            estadoblando = true;
            acs.estaDoblandoI( true, carril );
        }

    }

    public void subirVelocidad()
    {
        if(speed < 100)
        {
            speed +=  (transform.position.z / 50 );
            //speed*= 1.1f;
            camara.GetComponent<Camara>().smoothspeed /= 1.05f;
            camara.GetComponent<Camara>().offset.z += 0.1f;

        }


    }

    void OnCollisionEnter(Collision collision)
    {
        if( collision.collider.gameObject.tag == "Obstaculo" )
        {
            speed = 0;
            choco = true;

            GameObject go = GameObject.Find("Manager");
            go.GetComponent<GameManager>().choco();
            print("chocaste");
        }
    }



    public void Swipe()
    {
    //celu2
        if (Input.touchCount == 1) // user is touching the screen with a single touch
        {
            Touch touch = Input.GetTouch(0); // get the touch
            if (touch.phase == TouchPhase.Began) //check for the first touch
            {
                fp = touch.position;
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved) // update the last position based on where they moved
            {
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
            {
                lp = touch.position;  //last touch position. Ommitted if you use list
 
                //Check if drag distance is greater than 20% of the screen height
                if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
                {//It's a drag
                 //check if the drag is vertical or horizontal
                    if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
                    {   //If the horizontal movement is greater than the vertical movement...
                        if ((lp.x > fp.x))  //If the movement was to the right)
                        {   //Right swipe
                            doblarDerecha();
                        }
                        else
                        {   //Left swipe
                            doblarIzquierda();
                        }
                    }
                    else
                    {   //the vertical movement is greater than the horizontal movement
                        if (lp.y > fp.y)  //If the movement was up
                        {   //Up swipe
                        }
                        else
                        {   //Down swipe
                        }
                    }
                }
                else
                {   //It's a tap as the drag distance is less than 20% of the screen height
                    
                }
            }
        }


        
        //compu
        if(Input.GetMouseButtonDown(0))
        {
            //save began touch 2d point
            firstPressPos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
        }
        if(Input.GetMouseButtonUp(0))
        {
                //save ended touch 2d point
            secondPressPos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
        
                //create vector from the two points
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
            
            //normalize the 2d vector
            currentSwipe.Normalize();
    
            //swipe upwards
            if(currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
            {
            }
            //swipe down
            if(currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
            {
            }
            //swipe left
            if(currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
            {
                doblarIzquierda();
            }
            //swipe right
            if(currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
            {
                doblarDerecha();
            }
        }
        
    }

}
