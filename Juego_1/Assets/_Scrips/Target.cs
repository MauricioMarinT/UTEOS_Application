using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Target : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private float minForce = 12, maxForce = 16, maxTorque = 15, xRange = 2, ySpawnPos = 0;
    private GameManager gameManager;
    private QuizManager quizManager;

    [Range(-100,100)]
    public int pointValue;

    public ParticleSystem explosionParticle;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(RandomForce(), ForceMode.Impulse);
        _rigidbody.AddTorque(x: RandomTorque(), y: RandomTorque(), z: RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
        //gameManager = GameObject.Find("Game manager").GetComponent<GameManager>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
        
    }

    private Vector3 RandomForce()
    {
        return (Vector3.up * Random.Range(minForce, maxForce));
    }

    /// <summary>
    /// Genera un Vector aleatorio en 3D
    /// </summary>
    /// <returns>Fuerza aleatoria para arriba</returns>

    private float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    /// <summary>
    /// Genera un # aleatorio 
    /// </summary>
    /// <returns>Valor aleatoria entre -maxToque y maxTorque</returns>

    private Vector3 RandomSpawnPos()
    {
        return new Vector3(x: Random.Range(-xRange, xRange), y: -ySpawnPos);
    }

     //<summary>
     //Genera una posicion aleatoria en 3D
     //</summary>
     //<returns>Posicion aleatoria en 3d Eje z = 0</returns>
     private void OnMouseOver()
     {
         if (gameManager.gameState==GameManager.GameState.inGame)
         {
             Destroy(gameObject);
             Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
             gameManager.UpdateScore(pointValue,3);
         }
         
     }

     private void OnTriggerEnter(Collider other)
     {
         if (other.CompareTag("KillZone"))
         {
             Destroy(gameObject);
             if (gameObject.CompareTag("Good"))
             {
                // gameManager.UpdateScore(-3); 
                gameManager.GameOver();
             }
         }
     }


}