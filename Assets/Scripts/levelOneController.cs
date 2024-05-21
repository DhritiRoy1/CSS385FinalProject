using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelOneController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject easyEnemy;
    void Start()
    {
        Instantiate(easyEnemy, new Vector3(5.54f, -3.57f, -0.2f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
