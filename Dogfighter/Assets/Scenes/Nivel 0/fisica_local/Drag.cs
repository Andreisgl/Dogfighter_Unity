using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aeronave
{

    /*
        Essa classe calcula a força de Arrasto (Drag) de acordo com a orientação da aeronave relativa ao vetor de velocidade local.
        Isso é obtido interpolando os valores de Área e CD dos 6 lados da aeronave baseado no Ângulo de Ataque da aeronave.

        Essa classe futuramente precisará de dados de:
        -Densidade do ar ambiente
    */

    public class Drag : MonoBehaviour
    {
        //Componentes de outras classes:
            private AoA_Calc aoa_Calc;  //Cria instância da classe AoA_Calc para receber o AoA e usar para o cálculo nessa classe

        Rigidbody aero_rb;  //Cria um objeto RigidBody
        
        //Váriaveis para o cálculo do arrasto:
        float densAr = 0f; //Densidade do ar  (Kg/m^3 - Quilograma por metro cúbico)
        float vel = 0f; //Velocidade do ar.  (m/s - Metros por segundo)
        float[] areaCorpo = new float[6]; //Área de superfície do corpo do avião em todas as 6 direções!  (m^2 - Metro quadrado)
                                          //0: Frente, 1: Trás, 2: Direita, 3: Esquerda, 4: Cima, 5: Baixo
        float[] cdCorpo = new float[6];   //Coeficiente de arrasto do corpo do avião em todas as 6 direções!  (m^2 - Metro quadrado)
                                          //0: Frente, 1: Trás, 2: Direita, 3: Esquerda, 4: Cima, 5: Baixo
        //float CD = 0f;  //Coeficiente de arrasto do corpo.  (Unidade sem dimensão)


        void Start()
        {
            aero_rb = GetComponent<Rigidbody>();    //Considera o objeto atual o Rigidbody

            //Componentes de outras classes:
                aoa_Calc = GetComponent<AoA_Calc>();    //Finaliza a criação da instâncuia de AoA_Calc
            //Valores das váriaveis de arrasto:
            //ATENÇÃO!!! - TODO - Essas definições são provisórias. Esses dados serão recuperados de outras classes depois!
            densAr = 1.201f;
            //vel = 0f;
                //Define provisoriamente os valores do vetor de áreas do corpo.
                areaCorpo[0] = 0.25f * 28f;  //0,25x a área das asas, no olhômetro    
                areaCorpo[1] = 0.25f * 28f;  //0,25x a área das asas, no olhômetro  
                areaCorpo[2] = 2f * 28f;  //2x a área das asas, no olhômetro
                areaCorpo[3] = 2f * 28f;  //2x a área das asas, no olhômetro
                areaCorpo[4] = 3f * 28f;    //3x a área das asas, no olhômetro
                areaCorpo[5] = 3f * 28f;    //3x a área das asas, no olhômetro
                
                //Define provisoriamente os valores do CD do corpo.
                cdCorpo[0] = 0.0175f; //Valor obtido na internet
                cdCorpo[1] = 0.0175f; //Coloquei o mesmo do outro por preguiça
                cdCorpo[2] = 1.98f;   //Valor de uma chapa perpendicular ao fluxo.
                cdCorpo[3] = 1.98f;   //Valor de uma chapa perpendicular ao fluxo.
                cdCorpo[4] = 1.98f;   //Valor de uma chapa perpendicular ao fluxo.
                cdCorpo[5] = 1.98f;   //Valor de uma chapa perpendicular ao fluxo.
        }

        
        void Update()
        {
            
        }

        void FixedUpdate()
        {
            velLocal = transform.InverseTransformDirection(aero_rb.velocity);

            //Debug.Log( velLocal );

            inicializaCurvaAreaCD(areaCorpo, areaX, areaY, areaZ);    //Inicializa a curva de área

            atualizaVetor();
        }

        Vector3 velLocal;
        

         //Essas curvas têm tempo de 1 a -1, correspondendp às componentes do vetor Velocidade Normalizado.
        public AnimationCurve areaX, areaY, areaZ; //Representa a área de cada direção

        void atualizaVetor()    //Essa função retorna ÁREA * CD para o cálculo da força de arrasto. Os outros valores (Velocidade e sua direção, densidade do ar) são adicionados posteriormente.
        {
            Vector3 velNorm = Vector3.Normalize( velLocal );    //Vetor de velocidade local normalizado.

            //Vector3 drag;   //Esse vetor junta as componentes para dar a magnitude exata do arrasto.
            //Debug.Log( drag );
        }

       

        public AnimationCurve cdX, cdY, cdZ;   //Representa o CD de cada direção

        void inicializaCurvaAreaCD(float []vetor, AnimationCurve curvaX, AnimationCurve curvaY, AnimationCurve curvaZ) //Essa função inicializa as curvas de Area e CD. Recebe vetor e as três curvas, respectivamente.
        {
            areaZ.AddKey(1, vetor[0]);  //Orientado para frente
            areaZ.AddKey(0, 0);             //Componente == 0
            areaZ.AddKey(-1, vetor[1]); //Orientado para trás

            areaX.AddKey(1, vetor[3]);  //Orientado para a esquerda
            areaX.AddKey(0, 0);             //Componente == 0
            areaX.AddKey(-1, vetor[2]); //Orientado para a direita

            areaY.AddKey(1, vetor[5]);  //Orientado para baixo
            areaY.AddKey(0, 0);             //Componente == 0
            areaY.AddKey(-1, vetor[4]); //Orientado para cima
        }
        void inicializaCurvaCD()
        {
            
        }

  
    }


}