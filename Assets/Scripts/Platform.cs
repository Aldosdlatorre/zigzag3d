using UnityEngine;

public class Platform : MonoBehaviour
{

    public GameObject coin;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int randomCoin = Random.Range(0, 10);

        Vector3 coinPos = transform.position;
        coinPos.y += 1f;
        if (randomCoin < 1)
        {
            // Spawn coin
            Instantiate(coin, coinPos, coin.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("Fall", 0.2f);
        }	
        
    }

    void Fall()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        Destroy(gameObject, 1f);
    }
}
