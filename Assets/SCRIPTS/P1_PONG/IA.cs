using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IA : MonoBehaviour
{
    private Rigidbody2D rbIA;
    public Transform pelota;
    public float speedIA ;

    // Start is called before the first frame update
    void Start()
    {
        rbIA = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {


        MovimientoIA();
       
    }

    void MovimientoIA()
    {

        //pelota.position.y <-- coordenada y de la pelota
        //transform.position.y <-- coordenada y del objeto que tiene el script

        float distancia = pelota.position.y - transform.position.y;
        distancia = Mathf.Abs(distancia);

        if ((distancia > 0.5f) && pelota.position.x > 0)
        {

            //si la pelota esta arriba
            if (pelota.position.y > transform.position.y)

            {
                rbIA.velocity = new Vector2(0, speedIA);
            }

            //si la pelota esta abajo
            else if (pelota.position.y < transform.position.y)

            {
                rbIA.velocity = new Vector2(0, -speedIA);

            }

            else rbIA.velocity = Vector2.zero;

        }

       
    }

    public void ResetIA() //reinicio la posicion
    {
        Vector3 aux = transform.position;
        aux.y = 0f;
        aux.x = 6f;

        transform.position = aux;

    }
}
