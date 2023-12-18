using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour, IMove
{
    public Transform target;
    Vector2 direction;

    private void Update()
    {
        direction.x = target.transform.position.x;
        direction.y = target.transform.position.y;
        
        PositionUpdate(direction);
    }

    public void PositionUpdate(Vector2 direction)
    {
        transform.position = new Vector3(
            direction.x, direction.y, transform.position.z
        );
    }

    
}
