using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Essa classe aplica os controles básicos da aeronave.
*/
public class AeroControles : MonoBehaviour
{
    Rigidbody aero_rb;  //Cria um objeto RigidBody.

    void Start()
    {
        aero_rb = GetComponent<Rigidbody>();    //aero_rb agora é o Rigidbody da aeronave atual.
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {

    }

    void atualizaControles()    //Essa função lê e atualiza o valor dos controles
    {

    }
}
