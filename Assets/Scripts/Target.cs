 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    Rigidbody targetRB;
    private GameManager gameManager;


    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float torque = 10;
    private float xRange = 4;
    private float ySpawnPos = 4;

    public ParticleSystem explosion;

    // Start is called before the first frame update
    void Start()
    {
        targetRB = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        targetRB.AddForce(RandomForce(), ForceMode.Impulse);

        targetRB.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(),ForceMode.Impulse);

        transform.position = RandomSpawnPos();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {

        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);


            if (gameObject.CompareTag("Bad"))
            {
                gameManager.UpdateScore(-10);
            }
            else if (gameObject.CompareTag("G1"))
            {
                gameManager.UpdateScore(15);
            }
            else if (gameObject.CompareTag("G2"))
            {
                gameManager.UpdateScore(10);
            }
            else if (gameObject.CompareTag("G3"))
            {
                gameManager.UpdateScore(5);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }


    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-torque, torque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), -ySpawnPos);
    }

}
