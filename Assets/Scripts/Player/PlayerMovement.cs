using System;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    public bool KeyMove;

    public Camera Cam;
    public NavMeshAgent Agent;

    Rigidbody rgBody;

    void Start(){

        rgBody = GetComponent<Rigidbody> ();
    }

    void Update(){
        // KeyMovement();
        MouseMovement();
    }
    
    void KeyMovement(){

        //Inicjalizing inputs
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        //Player movement
        Vector3 Direction = new Vector3(Horizontal, 0, Vertical);
        Direction.Normalize();

        rgBody.velocity = new Vector3(Direction.x * Speed * Time.deltaTime, 0, Direction.z * Speed * Time.deltaTime);

        if(Direction != Vector3.zero){

            Quaternion toRotation = Quaternion.LookRotation(Direction, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 360 * Time.deltaTime);
        }
    }

    void MouseMovement(){
        if(Input.GetMouseButtonDown(0)){

            Ray ray = Cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit) || !KeyMove){
                
                Agent.SetDestination(hit.point);
            }
        }
    }
}