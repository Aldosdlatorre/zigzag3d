using UnityEngine;
using System.Collections;


public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;
    public Transform lastPlatform;
    Vector3 lastPosition;
    Vector3 newPos;

    bool stop;

    void Start()
    {
        lastPosition = lastPlatform.position;

        StartCoroutine(spawnPlatforms());
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKey(KeyCode.Space))
        // {
        //     spawnPlatforms();
        // }
        
    }

    IEnumerator spawnPlatforms()
    {
        while (!stop)
        {
            GeneratePosition();

            Instantiate(platform, newPos, Quaternion.identity);

            lastPosition = newPos;

            yield return new WaitForSeconds(0.1f);
        }

        
    }

    // void spawnPlatforms()
    // {
    //     GeneratePosition();

    //     Instantiate(platform, newPos, Quaternion.identity);

    //     lastPosition = newPos;
    // }

    void GeneratePosition()
    {
        newPos = lastPosition;

        int rand = Random.Range(0, 2);

        if (rand > 0)
        {
            newPos.x += 2f;
        }
        else
        {
            newPos.z += 2f;
        }

    }
}
