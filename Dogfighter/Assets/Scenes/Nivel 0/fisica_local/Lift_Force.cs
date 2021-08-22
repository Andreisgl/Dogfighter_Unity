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
        */

        //Váriaveis para o cálculo do empuxo:

        float densAr = 0f; //Densidade do ar
        float vel = 0f; //Velocidade do ar
        float areaAsa = 0f; //Área de superfície da asa
        float CL = 0f;  //Coeficiente de empuxo da asa
        
        void Start()
        {
            
        }

    
        void Update()
        {
            
        }
    }


}