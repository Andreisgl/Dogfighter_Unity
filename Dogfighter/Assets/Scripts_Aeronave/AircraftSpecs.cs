using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
Essa classe contém os parâmetros da aeronave, como:

-Fatores de manche
-Liimitadores de Aoa
-Peso
-Empuxo do motor

-Área de asa

-Áreas de superfície (vetor)
-Coeficientes de arrasto (vetor)

*/


public class AircraftSpecs : MonoBehaviour
{
    
    float pitchFactor = 0.6f;
    float rollFactor = 1.6f;
    float yawFactor = 0.6f;

    float limiterVertAoa = 20f;
    float limiterHorAoa = 10f;

    float weight;

    float enginePower;

    float wingArea;
    
    float[] surfaceArea;
    float[] dragCoefficient;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    
}
