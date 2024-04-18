using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    private float moveSpeed = 2f;

    private Vector3 StartPosiition;
    
    public Vector3 offset = new Vector3(0, 5, 0);
    private float elapsedTime;
    
    private void Update()
    {
        MoveCamera();
    }

    // private void UpdatePosition()
    // {
    //     StartPosiition = transform.position;
    //     EggController.Instance.UpdateLocation = false;
    //     transform.position = new Vector3(transform.position.x, target.position.y + moveSpeed * Time.deltaTime, 0) + offset;
    //     transform.position = Vector3.Lerp(transform.position, target.position + offset, percentageComplete);
    // }

    private void MoveCamera()
    {
        Vector3 newPosition = transform.position;
        newPosition.y = target.position.y + offset.y;
        transform.position = Vector3.Lerp(transform.position, newPosition, moveSpeed * Time.deltaTime);
    }
}

