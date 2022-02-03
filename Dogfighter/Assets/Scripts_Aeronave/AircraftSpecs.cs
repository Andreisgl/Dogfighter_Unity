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

float pitchFactor;
float rollFactor;
float yawFactor;

float limiterVertAoa;
float limiterHorAoa;

float weight;

float enginePower;

float wingArea;

float[] surfaceArea;
float[] dragCoefficient;

public class AircraftSpecs : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    
}
