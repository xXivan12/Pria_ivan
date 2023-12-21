using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;


public class PELOTA : MonoBehaviour
{
    public enum Ball_Type {FIJA, LINEAL, EXPONENCIAL}
    public Ball_Type TipoBola = Ball_Type.FIJA;

    private Rigidbody2D rbPelota;
    public float speed = 1.2f;
    private float velocidadInicial = 5f;
    public PongGameManage gm; // guardamos el gamemanage (script)

    public float IncrVelLineal = 1;

    public float multiplicadorVel = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        rbPelota = GetComponent<Rigidbody2D>();

        velocidadInicial = speed; // velocidad iniciall es igual a velocidad pelota(speed), guardamos velocidad inicial para resetear.

     

        gm = FindAnyObjectByType<PongGameManage>();// lo llamamos en el start y lo busca en la escena
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Escape)) ResetBall();
    }


    void BallLaunch()
    {
        //generar la direccion aleatoria al inicio de la partida (X aleatoria, Y aleatoria)

        float dirX = Random.Range(-1f, 1f); //direccion aleatoria ente 1 x y -1 x
        float dirY = Random.Range(-1f, 1f); //direccion aleatoria entre 1y e -1 y

        //corregimos la x

        if (dirX > 0 && dirX < 0.3f) dirX = 0.3f;

        //corregimos la y

        if (dirX < 0 && dirX > -0.3f) dirX = 0.3f;

        Vector2 direccionRandom = new Vector2(dirX, dirY); // guardamos el vector2 y le ponemos el nombre direccionRandom
        direccionRandom = direccionRandom.normalized; //normalizamos la velocidad

        rbPelota.velocity = direccionRandom * speed;
    }

    public void ResetBall()
    {
        transform.position = Vector3.zero;
        speed = velocidadInicial; //igualamos la velocidad de la pelota a la velocidad inicial, para que cada vez que empieze la ronda lo haga con una velocidad establecida.
        BallLaunch();
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //si el trigger es la porteria de J2
        //J1 Marca un gol --> LLamar a golJ1 de GameManager
        if (collision.gameObject.name == "porteria2") //si el objeto con el me he chocado, tiene el nombre porteria 2 (comprobacion), esto se puede hacer con collision.gameObject.name, . tag, .layer, .GetComponent
        {
            gm.GolJugador1(); //Accede al metodo GolJugador1 del script PongGameManage
            Debug.Log("GolPorteria2");
            transform.position = Vector3.zero;//devolvemos la pelota al centro cuando marcamos un gol
            rbPelota.velocity = Vector2.zero;//establecemos su velocidad a 0 cuando marcamos un gol


            


        }
        //si el trigger es la porteria de J1
        //J2 Marca un gol --> LLamar a golJ2 de GameManager
        else if (collision.gameObject.name == "porteria1") //si el objeto con el me he chocado, tiene el nombre porteria 1 (comprobacion)
        {
            gm.GolJugador2(); //Accede al metodo GolJugador2 del script PongGameManage
            Debug.Log("GolPorteria1");
            transform.position = Vector3.zero;
            rbPelota.velocity = Vector2.zero;

            
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (TipoBola == Ball_Type.LINEAL)
        {
            //ACELERA LINEAL 
            AcelerarPelotalineal();
        }

        else if (TipoBola == Ball_Type.EXPONENCIAL)
        {
            //ACELERA EXPONENCIAL
            AcelerarPelotaExponencial();
        }


    }


    private void AcelerarPelotalineal() 
    {
        speed += IncrVelLineal;
        rbPelota.velocity = rbPelota.velocity.normalized * speed;
    }

    private void AcelerarPelotaExponencial()
    {
        rbPelota.velocity = rbPelota.velocity *= multiplicadorVel; 
    }
    
        
    
}
