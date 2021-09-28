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
        float[] entradas = new float[NUMCOMANDOS]; //As entradas brutas recebidas do jogador
        
        [SerializeField]
        float[] fatores = new float[NUMCOMANDOS];   //Os fatores que multiplicam as entradas
        float[] comandos = new float[NUMCOMANDOS];  //Os comandos resultantes da multiplicação dos entradas e dos fatores

    void Start()
    {
        aero_rb = GetComponent<Rigidbody>();    //aero_rb agora é o Rigidbody da aeronave atual.

        //Definição PROVISÓRIA dos fatores
            setFator(0.6f, 0);
            setFator(0.6f, 1);
            setFator(0.6f, 2);
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        entradaControles();
        calculaComandos();

        aplicaComandos();

        //Debug.Log("Comandos: " + comandos[0] + " , " + comandos[1] + " , " +  comandos[2] );
    }

    void aplicaComandos()   //Controla a aeronave de acordo com o comando calculado.
    {
        aero_rb.transform.Rotate( comandos[0], comandos[2], -comandos[1] );
    }
    
    void calculaComandos()   //Essa função calcula a intensidade do comando multiplicando os valores das entradas do teclado com fatores pré-estabelecidos.
    {
        for (int i=0; i<NUMCOMANDOS; i++)
        {
            comandos[i] = entradas[i] * fatores[i];
        }
    }
    
    void entradaControles()    //Essa função lê as entradas dos controles e passa esse valor ao vetor global controles[].
    {
        entradas[0] = Input.GetAxis("Pitch");
        entradas[1] = Input.GetAxis("Roll");
        entradas[2] = Input.GetAxis("Yaw");

    }


    //Encapsulamtento:
    public void setFator(float valor, int indice)   //Índice:  0: Pitch, 1: Roll, 2: Yaw.
    {
        fatores[indice] = valor;
    }
}
