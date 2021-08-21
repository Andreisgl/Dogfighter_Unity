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

        private Aeronave_Main Aero_Main;

        void Start()
        {
            /*
            Aero_Main = GetComponent<Aeronave_Main>();

            aero_rb = Aero_Main.aero_rb;    //Considera o objeto atual o Rigidbody
            */
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
        //Função de inicialização. Substitui Start()
        public void start_fisica()
        {
            Aero_Main = GetComponent<Aeronave_Main>();

            aero_rb = Aero_Main.aero_rb;    //Considera o objeto atual o Rigidbody
        }

        //VARIÁVEIS E FUNÇÕES DA FÍSICA
        Vector3 velLocal;
         public void calculaFisica()
        {
            velLocal = Vector3.Normalize( transform.InverseTransformDirection(aero_rb.velocity) );  //Calcula velocidade local
                                                                                                    //Devo transformar esse método para usar quatérnios depois.
            Debug.Log("!!!");                                                                                                    
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
