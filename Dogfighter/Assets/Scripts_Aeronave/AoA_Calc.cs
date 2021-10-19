using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoA_Calc : MonoBehaviour
{
    Rigidbody aero_rb;  //Cria um objeto RigidBody.

    //Variáveis de física
        private Vector3 velLocalNorm;   //Vetor normalizado que indica a direção da Velocidade Local da aeronave.

        [SerializeField]
        float aoaVert = 0;  //Guarda o valor do Aoa Vertical.

        [SerializeField]
        float aoaHor = 0;   //Guarda o valor do Aoa Horizontal.

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
        calculaAoA();
        //Debug.Log("AoA V: " + aoaVert + "  -  AoA H:" + aoaHor);
    }

    void calculaFisica()
    {
        velLocalNorm = Vector3.Normalize( transform.InverseTransformDirection(aero_rb.velocity) );  //Atualiza o vetor global velLocalNorm.
    }

    //Métodos de cálculo do AoA Vertical e AoA Horizontal:
    
    void calculaAoA()
    {
        //Usa tangente para calcular o arco e o converte de radianos para graus.
        aoaVert = -Mathf.Atan2(velLocalNorm.y, velLocalNorm.z) * Mathf.Rad2Deg; //Calcula AoA Vertical
        aoaHor = -Mathf.Atan2(velLocalNorm.x, velLocalNorm.z) * Mathf.Rad2Deg;  //Calculla AoA Horizontal

    }

    //Encapsulamento:
    public float getAoAVert()
    {
        return aoaVert;
    }
    public float getAoAHor()
    {
        return aoaHor;
    }

}
