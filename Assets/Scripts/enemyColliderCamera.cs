using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyColliderCamera : MonoBehaviour
{
    private BoxCollider2D colliderEnemy;
    private Camera cameraMain;
    void Awake()
    {
        colliderEnemy = gameObject.GetComponent<BoxCollider2D>();
        cameraMain = Camera.main;
        colliderEnemy.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isEnemyInFrame())
        {
            colliderEnemy.enabled = true;
        }
        else
        {
            colliderEnemy.enabled = false;
        }

        
    }

    bool isEnemyInFrame()
    {
        Vector3 viewportPosition = cameraMain.WorldToViewportPoint(transform.position);
         return viewportPosition.x > 0.25f && viewportPosition.x < 0.75f 
        && viewportPosition.y > 0.25f && viewportPosition.y < 0.75f 
        && viewportPosition.z > 0;
    }
}
