using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staticRunningBackground : MonoBehaviour
{
    private float cameraBoundX;
    public float randomSpeed;
    public float randomDepth;
    // Start is called before the first frame update
    void Start()
    {
      cameraBoundX = Camera.main.transform.position.x + Camera.main.transform.position.x;
      randomSpeed = Random.Range(2.0f, 3.0f);
      randomDepth = Random.Range(-1.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        // if the sprite is within the bounds of the camera, keep travelling right
        if (6 > transform.position.x)
        {
            transform.Translate(Vector2.right * Time.deltaTime * randomSpeed);
        }
        // if not, reset sprite position to the starting point
        else
        {
            transform.position = new Vector3(-5.0f, -1.5f, randomDepth);
        }
        
    }
}
