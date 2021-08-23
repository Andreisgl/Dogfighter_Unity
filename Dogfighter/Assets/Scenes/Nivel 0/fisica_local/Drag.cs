using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aeronave
{

    /*
        Essa classe calcula a força de Arrasto (Drag) de acordo com a orientação da aeronave relativa ao vetor de velocidade local

        Essa classe futuramente precisará de dados de:
        -Densidade do ar ambiente
    */

    public class Drag : MonoBehaviour
    {
        Rigidbody aero_rb;  //Cria um objeto RigidBody
        
        //Váriaveis para o cálculo do arrasto:
        float densAr = 0f; //Densidade do ar  (Kg/m^3 - Quilograma por metro cúbico)
        float vel = 0f; //Velocidade do ar.  (m/s - Metros por segundo)
        float[] areaCorpo = new float[6]; //Área de superfície do corpo do avião em todas as 6 direções!  (m^2 - Metro quadrado)
                                          //0: Frente, 1: Trás, 2: Direita, 3: Esquerda, 4: Cima, 5: Baixo
        float[] CDCorpo = new float[6];   //Coeficiente de arrasto do corpo do avião em todas as 6 direções!  (m^2 - Metro quadrado)
                                          //0: Frente, 1: Trás, 2: Direita, 3: Esquerda, 4: Cima, 5: Baixo
        //float CD = 0f;  //Coeficiente de arrasto do corpo.  (Unidade sem dimensão)


        void Start()
        {
            aero_rb = GetComponent<Rigidbody>();    //Considera o objeto atual o Rigidbody

            //Valores das váriaveis de arrasto:
            //ATENÇÃO!!! - TODO - Essas definições são provisórias. Esses dados serão recuperados de outras classes depois!
            densAr = 1.201f;
            //vel = 0f;
                //Define provisoriamente os valores do vetor de áreas do corpo.
                areaCorpo[0] = ;
                areaCorpo[1] = ;
                areaCorpo[2] = 1.5f * 28f;  //1,5x a área das asas, no olhômetro
                areaCorpo[3] = 1.5f * 28f;  //1,5x a área das asas, no olhômetro
                areaCorpo[4] = 3f * 28f;    //3x a área das asas, no olhômetro
                areaCorpo[5] = 3f * 28f;    //3x a área das asas, no olhômetro
                
                //Define provisoriamente os valores do CD do corpo.
                areaCorpo[0] = 0.0175f; //Valor obtido na internet
                areaCorpo[1] = 0.0175f; //Coloquei o mesmo do outro por preguiça
                areaCorpo[2] = 1.98f;   //Valor de uma chapa perpendicular ao fluxo.
                areaCorpo[3] = 1.98f;   //Valor de uma chapa perpendicular ao fluxo.
                areaCorpo[4] = 1.98f;   //Valor de uma chapa perpendicular ao fluxo.
                areaCorpo[5] = 1.98f;   //Valor de uma chapa perpendicular ao fluxo.
            
            //CD = 0f;
        }

        
        void Update()
        {
            
        }

        void calculaDrag()
        {

        }

        void atualizaAreasCorpo()   //Essa função insere valores no array "areaCorpo"
        {
            //Essa função receberá valores automaticamente e será útil no futuro.
        }
    }


}