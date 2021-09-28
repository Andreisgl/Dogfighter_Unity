using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour
{
    Rigidbody aero_rb;  //Cria um objeto RigidBody.

    float entradaMotor = 0;

    void Start()
    {
        aero_rb = GetComponent<Rigidbody>();    //aero_rb agora é o Rigidbody da aeronave atual.
    }

    void Update()
    {
        
    }
    // aero_rb.AddForce( indDrag * -aero_rb.velocity );
    void FixedUpdate()
    {
        Debug.Log("Entrada Motor: " + entradaMotor);
    }

    void entradaControle() //Essa função lê as entradas dos controles e passa esse valor ao vetor global controles[].
    {
        entradaMotor = Input.GetAxis("Pitch");
    }
}
