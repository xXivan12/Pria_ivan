using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PongGameManage : MonoBehaviour
{

    public int puntosJ1 = 0;
    public int puntosJ2 = 0;

    public TextMeshPro MarcadorJ1;
    public TextMeshPro MarcadorJ2;

    public TextMeshPro TextoVictoria;
   

    public IA J2;
    public PLAYER J1;
    public PELOTA Ball;

    private bool RondaAcabada = true;
    public int golesMaximos = 2;
    // Start is called before the first frame update
    void Start()
    {
        //MarcadorJ1.text = "-9"; //cambiamos el texto 
        // MarcadorJ1.color = Color.red; //cambiar color 
        // MarcadorJ2.color = new Color(200f, 1f, 7f);//cambiar color mediante rgb

        J1 = FindObjectOfType<PLAYER>();      //buscamos la referencia a J1 (PLAYER)
        J2 = FindObjectOfType<IA>();          //buscamos la referencia a J2 (IA)
        Ball = FindObjectOfType<PELOTA>();    //buscamos la referencia a la pelota (PELOTA)

    }

    // Update is called once per frame
    void Update()
    {
        if (RondaAcabada &&Input.GetKeyDown(KeyCode.Space))
        
            ResetRonda();
        
    }

    public void ResetRonda()
    {
        //reset de la pelota

        Ball.ResetBall();

        //reset de J1
        J1.InicioRonda();
        //Reset de J2
        J2.ResetIA();
        //ronda vuelve a empezar
        RondaAcabada = false;
       
        MarcadorJ2.text = puntosJ2.ToString();
        MarcadorJ1.text = puntosJ1.ToString();
       
        //escondo o desactivo el textoVictoria
        TextoVictoria.gameObject.SetActive(false);
       


    }

    public void GolJugador2()
    {
        puntosJ2++;
        MarcadorJ2.text = puntosJ2.ToString();//Actualizar el texto del marcador 
        RondaAcabada = true;
        
        J1.ResetJugador();
        //Reset de J2
        J2.ResetIA();

        //comprobar fin de partida (goles maximos)
        ComprobarVictoria();
    }  

    public void GolJugador1()
    {
        puntosJ1++; //anota un punto

        MarcadorJ1.text = puntosJ1.ToString();//Actualizar el texto del marcador 
        RondaAcabada = true;
        J1.ResetJugador();
        //Reset de J2
        J2.ResetIA();
        ComprobarVictoria();
       
    }

    private void ComprobarVictoria()
    {
        if (puntosJ1 >= golesMaximos)
        {
            Debug.Log("ganaJ1");
            puntosJ1 = puntosJ2 = 0;

            //Activo el objeto texto victoria
            TextoVictoria.gameObject.SetActive(true);//accedemos al objeto del texto
            //cambio su texto a ¡GanaJ1!
            TextoVictoria.text = "¡GanaJ1!";
            
       


        }
        else if (puntosJ2 >= golesMaximos)
        {
            Debug.Log("ganaJ2");
            puntosJ1 = puntosJ2 = 0;
            //Activo el objeto textoVictoria
            TextoVictoria.gameObject.SetActive(true);
            //cambio su texto a ¡IA wins!
            TextoVictoria.text = "IA wins";
            
        }
    }
}
