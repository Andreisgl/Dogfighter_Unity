using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndDrag : MonoBehaviour
{
    Rigidbody aero_rb;  //Cria um objeto RigidBody.
    
    //Variáveis de física
        private Vector3 velGlobal;   //Vetor que indica a direção e intensidade da Velocidade Local da aeronave.
    void Start()
    {
        aero_rb = GetComponent<Rigidbody>();    //aero_rb agora é o Rigidbody da aeronave atual.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        calculaFisica();
        //Debug.Log(velGlobal);
    }

    void calculaIndDrag()
    {
        
    }

    void calculaFisica()
    {
        velGlobal = aero_rb.velocity;  //Atualiza o vetor global velGlobal.
    }
}
