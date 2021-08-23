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
                areaCorpo[0] = 0.5f * 28f;  //1,5x a área das asas, no olhômetro    
                areaCorpo[1] = 0.5f * 28f;  //1,5x a área das asas, no olhômetro  
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
            
            //CD = 0f;

            inicializaCurvasArea();
            inicializaCurvasCD();
        }

        
        void Update()
        {
            
        }

        void FixedUpdate()
        {
            Debug.Log
            (
                "Area ZX: " + curvaAreaZX.Evaluate(aoa_Calc.getAoAHor()) +
                "  CD ZX: " + curvaCDZX.Evaluate(aoa_Calc.getAoAHor()) +

                "      Area ZY: " + curvaAreaZY.Evaluate(aoa_Calc.getAoAVert()) +
                "  CD ZY: " + curvaCDZY.Evaluate(aoa_Calc.getAoAVert())

            );
        }

        //Curvas de área:
        public AnimationCurve curvaAreaZX;  //Indicará a interpolação dos valores de área ao girarem no eixo Y (Horizontal). (Frente e trás, cima e baixo)
        public AnimationCurve curvaAreaZY;  //Indicará a interpolação dos valores de área ao girarem no eixo X (Vertical). (Frente e trás, esquerda e direita)

        public AnimationCurve curvaCDZX;  //Indicará a interpolação dos valores de CD ao girarem no eixo Y (Horizontal). (Frente e trás, cima e baixo)
        public AnimationCurve curvaCDZY;  //Indicará a interpolação dos valores de CD ao girarem no eixo X (Vertical). (Frente e trás, esquerda e direita)

        //Curvas de CD:
        void inicializaCurvasArea()   //Inicializa os valores de Área das curvas de animação
        {
            //Gira no sentido horário. Pega dados de AoA Horizontal.
            curvaAreaZX.AddKey(0f, areaCorpo[0]); //Frente
            curvaAreaZX.AddKey(90f, areaCorpo[2]); //Direita

            curvaAreaZX.AddKey(180f, areaCorpo[1]); //Trás
            curvaAreaZX.AddKey(-180f, areaCorpo[1]); //Trás, só que vindo do negativo

            curvaAreaZX.AddKey(-90f, areaCorpo[3]); //Esquerda

            //Gira no sentido horário. Pega dados de AoA Vertical.
            curvaAreaZY.AddKey(0f, areaCorpo[0]); //Frente
            curvaAreaZY.AddKey(90f, areaCorpo[4]); //Cima
            
            curvaAreaZY.AddKey(180f, areaCorpo[1]); //Trás
            curvaAreaZY.AddKey(-180f, areaCorpo[1]); //Trás, só que vindo do negativo

            curvaAreaZY.AddKey(-90f, areaCorpo[5]); //Baixo
        }
        void inicializaCurvasCD()   //Inicializa os valores de CD das curvas de animação
        {
            //Gira no sentido horário. Pega dados de AoA Horizontal.
            curvaCDZX.AddKey(0f, cdCorpo[0]); //Frente
            curvaCDZX.AddKey(90f, cdCorpo[2]); //Direita

            curvaCDZX.AddKey(180f, cdCorpo[1]); //Trás só que vindo do negativo
            curvaCDZX.AddKey(-180f, cdCorpo[1]); //Trás só que vindo do negativo

            curvaCDZX.AddKey(-90f, cdCorpo[3]); //Esquerda

            //Gira no sentido horário. Pega dados de AoA Vertical.
            curvaCDZY.AddKey(0f, cdCorpo[0]); //Frente
            curvaCDZY.AddKey(90f, cdCorpo[4]); //Cima

            curvaCDZY.AddKey(180f, cdCorpo[1]); //Trás
            curvaCDZY.AddKey(-180f, cdCorpo[1]); //Trás só que vindo do negativo

            curvaCDZY.AddKey(-90f, cdCorpo[5]); //Baixo
        }
        void calculaDrag()
        {
            //Drag = 0.5f * densAr * vel^2 * areaCorpo * cdCorpo


        }

        void atualizaAreasCorpo()   //Essa função insere valores no array "areaCorpo"
        {
            //Essa função receberá valores automaticamente e será útil no futuro.
        }
    }


}