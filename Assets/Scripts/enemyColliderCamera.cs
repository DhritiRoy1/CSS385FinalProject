using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyColliderCamera : MonoBehaviour
{
    private BoxCollider2D colliderEnemy;

    void Awake()
    {
        colliderEnemy = gameObject.GetComponent<BoxCollider2D>();
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
         var planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
        var point = this.transform.position;
        foreach (var plane in planes)
        {
            if (plane.GetDistanceToPoint(point) < 0)
                return false;
        }
        return true;
    }
}
