using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Essa classe aplica os controles básicos da aeronave: Arfagem, Rolagem e Guinada (Pitch, Roll, Yaw).
*/
public class AeroControles : MonoBehaviour
{
    Rigidbody aero_rb;  //Cria um objeto RigidBody.


    //Vetores dos controles
        const int NUMCOMANDOS = 3;
        // 0: Pitch, 1: Roll, 2: Yaw.
        float[] controles = new float[NUMCOMANDOS]; //As entradas brutas recebidas do jogador
        float[] fatores = new float[NUMCOMANDOS];   //Os fatores que multiplicam as entradas
        float[] comandos = new float[NUMCOMANDOS];  //Os comandos resultantes da multiplicação dos controles e dos fatores

    void Start()
    {
        aero_rb = GetComponent<Rigidbody>();    //aero_rb agora é o Rigidbody da aeronave atual.

        //Definição PROVISÓRIA dos fatores
            fatores[0] = 0.5f;
            fatores[1] = 0.5f;
            fatores[2] = 0.5f;
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        entradaControles();
        calculaComandos();

        Debug.Log("Comandos: " + comandos[0] + " , " + comandos[1] + " , " +  comandos[2] );
    }
    
    void calculaComandos()   //Essa função calcula a intensidade do comando multiplicando os valores das entradas do teclado com fatores pré-estabelecidos.
    {
        for (int i=0; i<NUMCOMANDOS; i++)
        {
            comandos[i] = controles[i] * fatores[i];
        }
    }
    
    void entradaControles()    //Essa função lê as entradas dos controles e passa esse valor ao vetor global controles[].
    {
        controles[0] = Input.GetAxis("Pitch");
        controles[1] = Input.GetAxis("Roll");
        controles[2] = Input.GetAxis("Yaw");

    }
}
