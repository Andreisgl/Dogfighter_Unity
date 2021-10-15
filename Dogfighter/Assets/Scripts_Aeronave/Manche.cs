using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Essa classe aplica os controles básicos da aeronave: Arfagem, Rolagem e Guinada (Pitch, Roll, Yaw).
*/
public class Manche : MonoBehaviour
{
    Rigidbody aero_rb;  //Cria um objeto RigidBody.


    //Vetores dos controles
        const int NUMCOMANDOS = 3;
        // 0: Pitch, 1: Roll, 2: Yaw.
        
        [SerializeField]
        float[] entradas = new float[NUMCOMANDOS]; //As entradas brutas recebidas do jogador
        
        [SerializeField]
        float[] fatores = new float[NUMCOMANDOS];   //Os fatores que multiplicam as entradas
        [SerializeField]
        float[] limitadores = new float[NUMCOMANDOS];    //Multiplicador de entrada do limitador.
        [SerializeField]
        float[] comandos = new float[NUMCOMANDOS];  //Os comandos resultantes da multiplicação das entradas, dos fatores e dos limitadores.
        

    void Start()
    {
        aero_rb = GetComponent<Rigidbody>();    //aero_rb agora é o Rigidbody da aeronave atual.

        //Definição PROVISÓRIA dos fatores
            setFator(0.6f, 0);
            setFator(0.6f, 1);
            setFator(0.6f, 2);
        //Definição PROVISÓRIA dos LIMITADORES
            limitadores[0] = 1;
            limitadores[1] = 1;
            limitadores[2] = 1;
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        entradaControles();
        atualizaComandos();

        aplicaComandos();

        //Debug.Log("Comandos: " + comandos[0] + " , " + comandos[1] + " , " +  comandos[2] );
    }

    void aplicaComandos()   //Controla a aeronave de acordo com o comando calculado.
    {
        aero_rb.transform.Rotate( comandos[0], comandos[2], -comandos[1] );
    }

    
    
    
    void atualizaComandos()
    {
        for (int i=0; i<NUMCOMANDOS; i++)
        {
            comandos[i] = comando(entradas[i], fatores[i], limitadores[i]);
        }
    }
    float comando(float entrada, float fator, float limitador)  //Calcula o comando a ser dado para um eixo específico usando entradas do teclado, fatores e limitadores.
    {
        //Bandeiras booleanas que indicam se a entrada e o fator são positivos ou negativos. Isso simplifica o código.
        // 1 = POSITIVO, 0 = NEGATIVO.
            bool entrPos;
                if(entrada >= 0) {entrPos = true;}
                else {entrPos = false;}
            bool limitPos;
                if(limitador >= 0) {limitPos = true;}
                else {limitPos = false;}

        if(entrPos == limitPos) //Se a direção(sinal) do limitador é igual à da entrada, usar o limitador...
        {
            return entrada * fator * Mathf.Abs(limitador);
        }
        else    //Se não, não limitar o movimento.
        {
            return entrada * fator;
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
