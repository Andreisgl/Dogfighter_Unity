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

    GLOSSÁRIO:
    -AoA: Ângulo de Ataque. Ângulo do nariz da aeronave relativo à direção ao qual o ar se move relativo à aeronave.
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
            velLocal = Vector3.Normalize( transform.InverseTransformDirection(aero_rb.velocity) );
            getAngAtaqVert();
            //Debug.Log( Mathf.Asin(dir.x) );
        }

        Vector3 velLocal;
        float dir;

        


        //Métodos de saída:
        void getAngAtaqVert()
        {
            dir = -Mathf.Atan2(velLocal.y, velLocal.z) * Mathf.Rad2Deg; //Usa tangente para calcular o arco e o converte de radianos para graus.
        }
        
        float getAngAtaqHor()
        {

        }
        



        //Métodos de encapsulamento

    }



}
