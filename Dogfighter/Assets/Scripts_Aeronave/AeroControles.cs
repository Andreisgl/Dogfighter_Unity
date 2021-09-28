using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Essa classe aplica os controles básicos da aeronave: Arfagem, Rolagem e Guinada (Pitch, Roll, Yaw).
*/
public class AeroControles : MonoBehaviour
{
    Rigidbody aero_rb;  //Cria um objeto RigidBody.


    //Vetores dos controles?
    float[] controles = new float[3];   // 0: Pitch, 1: Roll, 2: Yaw.
    void Start()
    {
        aero_rb = GetComponent<Rigidbody>();    //aero_rb agora é o Rigidbody da aeronave atual.
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        entradaControles();

        Debug.Log("Controles: " + controles[0] + " , " + controles[1] + " , " +  controles[2] );
    }

    
    void entradaControles()    //Essa função lê e atualiza o valor das entradas dos controles
    {
        controles[0] = Input.GetAxis("Pitch");
        controles[1] = Input.GetAxis("Roll");
        controles[2] = Input.GetAxis("Yaw");

    }
}
