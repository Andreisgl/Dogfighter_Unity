using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Essa classe aplica arrasto normal e arrasto induzido de acordo com seus cálculos.
*/
public class Drag : MonoBehaviour
{
    Rigidbody aero_rb;  //Cria um objeto RigidBody.
    
    //Variáveis de física
        private Vector3 velGlobal;   //Vetor que indica a direção e intensidade da Velocidade Local da aeronave.
        float valorArrasto; //Valor da força de arrasto (Drag) a ser aplicada em Newtons.
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

    void calculaArrInd()    //Calcula o Arrasto Induzido da aeronave.
    {
        
    }

    void calculaFisica()
    {
        velGlobal = aero_rb.velocity;  //Atualiza o vetor global velGlobal.
    }
}
