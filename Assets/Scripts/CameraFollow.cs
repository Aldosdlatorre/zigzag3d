using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;

    Vector3 distance;
    public float smoothValue;

    void Start()
    {
        distance = target.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(target.position.y >= 0)
        {
            Follow();
        }
        
    }

    void Follow()
    {
        Vector3 currentPos = transform.position;
        Vector3 targetPos = target.position - distance;

        transform.position = Vector3.Lerp(currentPos, targetPos, smoothValue * Time.deltaTime);
    }
}
