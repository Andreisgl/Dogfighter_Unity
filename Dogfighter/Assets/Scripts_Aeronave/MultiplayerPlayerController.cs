using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Mirror;

/*  MULTIPLAYER CONTROLLER PROTOTYPE!!!

This class unifies "Stick"(Manche) and "Engine"(Motor) under a single script.
Now, this script will get player input, intead of those previous classes.
*/
public class MultiplayerPlayerController : NetworkBehaviour
{
    Manche manche; //Create instance of class
    Motor motor;


    public override void OnStartLocalPlayer()
    {
        Camera.main.transform.SetParent(transform);
        Camera.main.transform.localPosition = new Vector3(0, 2, -10);
    }


    void Start()
    {
        manche = GetComponent<Manche>(); //Finalize creation of class
        motor = GetComponent<Motor>();        
    }

    
    void Update()
    {
        sendPlayerInput();
    }

    void sendPlayerInput()
    {
        //Stick(Manche) inputs:
        manche.setInput(Input.GetAxis("Pitch"), 0);
        manche.setInput(Input.GetAxis("Roll"), 1);
        manche.setInput(Input.GetAxis("Yaw"), 2);

        //Engine(Motor) inputs:
        motor.setInput(Input.GetAxis("Throttle"));
    }
}
