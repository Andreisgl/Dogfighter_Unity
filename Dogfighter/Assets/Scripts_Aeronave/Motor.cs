using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour
{
    Rigidbody aero_rb;  //Cria um objeto RigidBody.

    float entradaMotor = 0;

    [SerializeField]
    float potenciaMotor = 160000.0f;

    float comandoMotor = 0;

    void Start()
    {
        aero_rb = GetComponent<Rigidbody>();    //aero_rb agora é o Rigidbody da aeronave atual.
    }

    void Update()
    {
        
    }
    
    void FixedUpdate()
    {
        entradaControle();
        calculaComando();
        aplicaComando();
        //Debug.Log("COMANDO Motor: " + comandoMotor);
    }
    
    void aplicaComando()
    {
        aero_rb.AddForce( comandoMotor * aero_rb.transform.forward );
    }
    void calculaComando()
    {
        comandoMotor = entradaMotor * potenciaMotor;
    }
    void entradaControle() //Essa função lê as entradas dos controles e passa esse valor ao vetor global controles[].
    { 
        //entradaMotor = Input.GetAxis("Throttle");
        if (entradaMotor <= 0)
        {
            entradaMotor = 0.5f;
        }
    }

    //Encapsulamento
    public void setPotencia(float potencia)
    {
        potenciaMotor = potencia;
    }

    public void setInput(float value)
    {
        entradaMotor = value;
    }
}
