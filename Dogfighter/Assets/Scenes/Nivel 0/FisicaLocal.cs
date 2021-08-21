using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aeronave
{

    /*
    Essa classe é responsável por administrar forças e atributos físicos da aeronave como:
        -Massa,             **PENDENTE**
        -Velocidade local,  **CONCLUÍDO**
        -Ângulo de ataque,  **CONCLUÍDO**
        -Empuxo das asas    **EM ANDAMENTO**
        -Arrasto Aerod.     **EM ANDAMENTO**
        -Força G            **PENDENTE**
        -Impulso do motor   **PENDENTE**

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
            calculaFisica();    //Função responsável por calcular velocidade relativa
            Debug.Log( "AoA V: " + getAoAVert() + "   AoA H: " + getAoAHor() );

            
            
        }


        //VARIÁVEIS E FUNÇÕES DA FÍSICA
        public Vector3 velLocal;
        void calculaFisica()
        {
            velLocal = Vector3.Normalize( transform.InverseTransformDirection(aero_rb.velocity) );  //Calcula velocidade local
                                                                                                    //Devo transformar esse método para usar quatérnios depois.
        }
        

        //FUNÇÕES PARA ÂNGULO DE ATAQUE (AoA)
            //Métodos de saída:
        public float getAoAVert()
        { return -Mathf.Atan2(velLocal.y, velLocal.z) * Mathf.Rad2Deg; }//Usa tangente para calcular o arco e o converte de radianos para graus.
        
        public float getAoAHor()
        { return -Mathf.Atan2(velLocal.x, velLocal.z) * Mathf.Rad2Deg; } //Usa tangente para calcular o arco e o converte de radianos para graus.

        public float getAoAVertNorm()   //Dá o AoA ajustado para o uso com a Animation Curve
        { return ( -Mathf.Atan2(velLocal.y, velLocal.z) /6 + 0.5f ); }
    }



}
