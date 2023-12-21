using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYER : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    public bool jugadorActivo = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
         
    }

    // Update is called once per frame
    void Update()
    {
        if (jugadorActivo)
        {
            InpuntJugador();
        }
    }

    public void ResetJugador()//Reinicio la posicion
    {
        Vector3 aux = transform.position;
        aux.y = 0f;
        transform.position = aux;
        jugadorActivo = false;
        rb.velocity = Vector3.zero;
        
    }

    public void InicioRonda()
    {
       
        jugadorActivo = true;

    }


    private void InpuntJugador()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector2(0, 1) * speed;
        }

        else if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector2(0, -1) * speed;

        }

        else rb.velocity = Vector2.zero;


    }
}
