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
*/

public class Controles : MonoBehaviour
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
}



}