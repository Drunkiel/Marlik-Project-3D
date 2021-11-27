using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Player;

    public float TimeSmooth;
    public float Xplus, Yplus, Zplus;
    private Vector3 currVelocity;

    // Update is called once per frame
    void Update()
    {

        Vector3 newCameraPosition = new Vector3(Player.transform.position.x + Xplus, Player.transform.position.y + Yplus, Player.transform.position.z + Zplus);
        
        transform.position = Vector3.SmoothDamp(transform.position, newCameraPosition, ref currVelocity, TimeSmooth);
    }
}
