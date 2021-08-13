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

        float anguloAtqVert;

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
            Debug.Log("Aoa Vert: " + calculaAngAtqVert() );
            Debug.Log("\tAoa Hor: " + calculaAngAtqHor() );
        }




        void calculaVelLocal()
        {
            velLocal = transform.InverseTransformDirection(aero_rb.velocity);
            
        }


        //Métodos de saída:
        float calculaAngAtqVert()
        {
            Vector2 vetYZ; //Cria vetor bidimensional cujas componentes representam um plano local YZ. A partir dele será calculado o ângulo de ataque

            vetYZ = new Vector2(velLocal.y, velLocal.z);    //Adiciona os valores de velocidade local ao vetor.

            if(velLocal.y < 0)  //Se o nariz aponta para cima:
                return Vector2.Angle( vetYZ, transform.forward );
            else    //Se está neutro/aponta para baixo:
                return -Vector2.Angle( -vetYZ, transform.forward );
        }
        float calculaAngAtqHor()
        {
            Vector2 vetYZ; //Cria vetor bidimensional cujas componentes representam um plano local YZ. A partir dele será calculado o ângulo de ataque

            vetYZ = new Vector2(velLocal.x, velLocal.z);    //Adiciona os valores de velocidade local ao vetor.

            if(velLocal.y < 0)  //Se o nariz aponta para cima:
                return Vector2.Angle( vetYZ, transform.forward );
            else    //Se está neutro/aponta para baixo:
                return -Vector2.Angle( -vetYZ, transform.forward );
        }



        //Métodos de encapsulamento

        public Vector3 getVelLocal()
        {
            return velLocal;
        }
    }



}
