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

        Vector3 velLocal;   //Cria vetor de velocidade local.


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
            calculaVelLocal();
            Debug.Log( calculaAngAtq(velLocal.y, velLocal.z) );
        }




        void calculaVelLocal()
        {
            velLocal = transform.InverseTransformDirection(aero_rb.velocity);
            
        }

        float calculaAngAtq(float vel1, float vel2)
        {
            Vector2 vetAux; //Cria vetor bidimensional cujos componentes serão usados para calcular o ângulo de ataque.
            vetAux = new Vector2(vel1, vel2);    //Adiciona os valores de velocidade local ao vetor.

            if(vel1 < 0)  //Se o nariz aponta para cima:
                return Vector2.Angle( vetAux, transform.forward );
            else    //Se está neutro/aponta para baixo:
                return -Vector2.Angle( -vetAux, transform.forward );   
        }



        //Métodos de encapsulamento

        public Vector3 getVelLocal()
        {
            return velLocal;
        }
    }



}
