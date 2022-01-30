using Player;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private void Update()
    {
        
        Vector3 temp = PlayerMovement.Singleton.GetCurrentPlayerPosition();
        temp.z = transform.position.z;
        transform.position = temp;
    }
}
