using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aeronave
{

    /*
    Essa classe é responsável por administrar forças e atributos físicos da aeronave como:
        -Massa,             **PENDENTE**
        -Velocidade local,  **PENDENTE**
        -Ângulo de ataque,  **EM ANDAMENTO**
        -Empuxo das asas    **PENDENTE**

    */

    public class FisicaLocal : MonoBehaviour
    {
        Rigidbody aero_rb;  //Cria um objeto RigidBody


        // Start is called before the first frame update
        void Start()
        {
            aero_rb = GetComponent<Rigidbody>();    //Considera o objeto atual o Rigidbody
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        void FixedUpdate()
        {
            teste();
        }

        void teste()
        {
            Vector3 velLocal = Vector3.Normalize( transform.InverseTransformDirection(aero_rb.velocity) );

            Vector3 dir = velLocal - transform.forward; //Mostra a diferença entre o vetor de velocidade local e o vetor forward. Aparenta funcionar bem!

            Debug.Log( dir + "   |   " + velLocal);

        }


        //Métodos de saída:
     



        //Métodos de encapsulamento

    }



}
