using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class enemyMechanicEasy : MonoBehaviour
{
    float flipIntervalSec = 5.0f;
    // Black enemy (Easy) : Flip every 5 seconds
    // Green enemy (Medium) : Flip every 3 seconds, ability to move around a little bit but not random
    // Red enemy (Hard) : Flip every 3 seconds, random movements
    // Boss (Very Hard) : Random chance of seeing player through walls
    
    void Awake()
    {
        StartCoroutine(flipEnemyAction(flipIntervalSec));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator flipEnemyAction(float seconds)
    {
        while(true)
        {
            yield return new WaitForSeconds(seconds);      
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Game Over");
        }
    }
}
