using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Player;
    public Camera Cam;

    public int Max_FieldOfView, Min_FieldOfView;
    private Vector3 currVelocity;

    Vector3 previousPosition;

    void Start(){

        Cam.transform.position = Player.transform.position;
        Cam.transform.Translate(new Vector3(0, 2, -20));
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
        RotateCamera();
        // ScrollCamera();
    }

    void MoveCamera(){

        Cam.transform.position = Player.transform.position;
        Cam.transform.Translate(new Vector3(0, 2, -20)); 
    }
    
    void RotateCamera(){

        if(Input.GetMouseButtonDown(1)){
            previousPosition = Cam.ScreenToViewportPoint(Input.mousePosition);
        }

        if(Input.GetMouseButton(1)){
            
            Vector3 Direction = previousPosition - Cam.ScreenToViewportPoint(Input.mousePosition);
            Cam.transform.Rotate(new Vector3(0, 1, 0), -Direction.x * 180, Space.World);

            MoveCamera();

            previousPosition = Cam.ScreenToViewportPoint(Input.mousePosition);
        }
    }

    void ScrollCamera(){
        
        if(Cam.fieldOfView != Max_FieldOfView || Cam.fieldOfView != Min_FieldOfView){

            Cam.fieldOfView += Input.mouseScrollDelta.y;

        }   else if(Cam.fieldOfView >= Max_FieldOfView){

            Cam.fieldOfView = Max_FieldOfView;

        }   else if(Cam.fieldOfView <= Min_FieldOfView){

            Cam.fieldOfView = Min_FieldOfView;
        }

    }
}
