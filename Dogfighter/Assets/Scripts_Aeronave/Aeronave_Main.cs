using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Essa classe reúne dados e estados provenientes de outras classes para acesso mais limpo. 
*/
public class Aeronave_Main : MonoBehaviour
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

    void controles()
    {
        
    }
}
