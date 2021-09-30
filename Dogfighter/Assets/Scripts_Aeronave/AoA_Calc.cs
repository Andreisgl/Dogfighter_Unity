using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoA_Calc : MonoBehaviour
{
    Rigidbody aero_rb;  //Cria um objeto RigidBody.

    //Variáveis de física
        private Vector3 velLocalNorm;   //Vetor que indica a Velocidade Local da aeronave.

    void Start()
    {
        aero_rb = GetComponent<Rigidbody>();    //aero_rb agora é o Rigidbody da aeronave atual.

    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        calculaFisica();
        Debug.Log("velLocalNorm : " + velLocalNorm);
    }

    void calculaFisica()
    {
        velLocalNorm = Vector3.Normalize( transform.InverseTransformDirection(aero_rb.velocity) );  //Atualiza o vetor global velLocalNorm.
    }
}
