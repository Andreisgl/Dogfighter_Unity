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

        MetodoControle cThrottle = new MetodoControle{};
    
        
    // Start is called before the first frame update
    void Start()
    {
        aero_rb = GetComponent<Rigidbody>();    //Considera o objeto atual o Rigidbody

        //Definição dos fatores dos controles:  **Isso é provisório! Devo adicionar depois um script que aplica esses fatores baseado em dados pré-definidos de modelos de aeronaves!
        cPitch.setFator(1.0f);
        cRoll.setFator(1.0f);
        cYaw.setFator(1.0f);

        cThrottle.setFator(1.0f);   //TODO: esse fator receberá futuramente dados do empuxo do motor!
    }

    // Update is called once per frame
    void Update()
    {
        FisicaLocal fisLocal = GetComponent<FisicaLocal>();
        Debug.Log( fisLocal.getVelLocal() );
    }
    
    void FixedUpdate()
    {
        atualizaControles();    //Verifica os estados dos controles e os aplica.
    }

    void atualizaControles()
    {
        //Movimentos. Passa o valor atual de um eixo como parâmetro, recebe de volta o valor multiplicado e aplica rotação na aeronave.
         aero_rb.transform.Rotate( cPitch.saidaControle(Input.GetAxis("Pitch")), 0.0f, 0.0f );
         aero_rb.transform.Rotate( 0.0f, 0.0f, -cRoll.saidaControle(Input.GetAxis("Roll")) );
         aero_rb.transform.Rotate( 0.0f, cYaw.saidaControle(Input.GetAxis("Yaw")), 0.0f );

         aero_rb.AddForce( transform.forward * cThrottle.saidaControle(Input.GetAxis("Throttle")) );
    }
}



}