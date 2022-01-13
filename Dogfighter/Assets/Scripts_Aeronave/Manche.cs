using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Essa classe aplica os controles básicos da aeronave: Arfagem, Rolagem e Guinada (Pitch, Roll, Yaw).
*/
public class Manche : MonoBehaviour
{
    Rigidbody aero_rb;  //Cria um objeto RigidBody.

    //Inicialização de objetos de classes:
        private AoA_Calc aoa_Calc;  //Cria instância da classe AoA_Calc para receber variáveis centrais(AoA, nesse caso) para o cálculo nessa classe.
        private AoA_Limiter aoaVert_Limit;  //Cria instância da classe AoA_Limiter para AoA VERTICAL.


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
        
        [SerializeField]
        float aoaVertMax;   //Angulo de Ataque(AoA) Vertical MÁXIMO que a aeronave pode alcançar.

        [SerializeField]
        float aoaVert;  //AoA vertical atual da aeronave.


    void Start()
    {
        aero_rb = GetComponent<Rigidbody>();    //aero_rb agora é o Rigidbody da aeronave atual.
        
        //Inicialização de objetos de classes:
            aoa_Calc = GetComponent<AoA_Calc>();    //Finaliza a criação da instância de AoA_Calc.
            aoaVert_Limit = GetComponent<AoA_Limiter>();    //Finaliza a criação da instância de AoA_Limit para AoA VERTICAL.

        //Definição PROVISÓRIA dos fatores
            setFator(0.6f, 0);
            setFator(1.6f, 1);
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
        aoaVert = aoa_Calc.getAoAVert();    //Pega o valor do AoA vertical e o dá a essa variável
        aoaVert_Limit.setAnguloLimitador(aoaVert);  //Entrega o valor do AoA vertical à classe Aoa_Limiter para o cálculo da limitação.

        entradaControles();
        atualizaLimitadores();
        atualizaComandos();

        aplicaComandos();
    }

    void aplicaComandos()   //Controla a aeronave de acordo com o comando calculado.
    {
        aero_rb.transform.Rotate( -comandos[0], comandos[2], -comandos[1] );
    }

    
    void atualizaLimitadores()
    {
        limitadores[0] = aoaVert_Limit.getMultpLimite();
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
