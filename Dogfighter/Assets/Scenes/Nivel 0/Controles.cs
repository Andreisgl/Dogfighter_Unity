using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aeronave
{

/*
Essa classe atua em conjunto com a classe "MetodoControle".
Ela recebe as entradas dos comandos da aeronave, os fatores,
os passa para "MetodoControle" para cálculo
e aplica recebe a saída para aplicar em movimentos na da aeronave.

Ela também será usada para a limitação de força G e ângulo de ataque.

**Ainda não tenho certeza se a usarei para calcular esses efeitos também. Provavelmente sim.
*/

public class Controles : MonoBehaviour
{
    Rigidbody aero_rb;  //Cria um objeto RigidBody


    //Objetos de declaração dos controles:
        MetodoControle cPitch = new MetodoControle{};
        MetodoControle cRoll = new MetodoControle{};
        MetodoControle cYaw = new MetodoControle{};

        MetodoControle cThrust = new MetodoControle{};
    //Definição dos fatores dos controles:
        cPitch.setFator(1.0f);
        cRoll.setFator(1.0f);
        cYaw.setFator(1.0f);

        cThrottle.setFator(1.0f);

    // Start is called before the first frame update
    void Start()
    {
        aero_rb = GetComponent<Rigidbody>();    //Considera o objeto atual o Rigidbody
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}



}