using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Aeronave
{

    /*
        Essa classe aplica a força de Empuxo (Lift) das asas baseado em:
        -Ângulo de Ataque(AoA): Calculado na classe AoA_Calc.
        -Coeficiente de Empuxo(CL): Calculado na classe CL_AoA.
    */

    public class Lift_Force : MonoBehaviour
    {
        /*
            L is the resulting lift force
            ρ (rho) is the air density
            v is the velocity
            A is the surface area
            CL is the coefficient of lift

            Formula do empuxo:

            L = 0,5 * A * rho * CL * v^2
        */

        //Váriaveis para o cálculo do empuxo:

        float densAr = 0f; //Densidade do ar  (Kg/m^3 - Quilograma por metro cúbico)
        float vel = 0f; //Velocidade do ar.  (m/s - Metros por segundo)
        float areaAsa = 0f; //Área de superfície da asa.  (m^2 - Metro quadraado)
        float CL = 0f;  //Coeficiente de empuxo da asa.  (Unidade sem dimensão)
        
        void Start()
        {
            //ATENÇÃO!!! - TODO - Essas definições são provisórias. Esses dados serão recuperados de outras classes depois!
            densAr = 1.201f;
            //vel = 1f;
            areaAsa = 28f;  //28m^2: Area da asa do F-16
            //CL = 1;
        }

    
        void Update()
        {
            
        }


        float calculaLift()
        {
            // L = 0,5 . A . rho . CL . v^2
            return 0.5f * areaAsa * densAr * CL * Mathf.Pow(vel, 2);
        }


    }


}