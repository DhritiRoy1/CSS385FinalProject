using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class levelOneController : MonoBehaviour
{
    // LevelOneController but script is used in tutorial level

    // Level specific game object prefabs
    public GameObject easyEnemyPrefab;
    public GameObject trophyUIPrefab;
    public GameObject keyPrefab;

    void Start()
    {
        // Enemies
        GameObject easyEnemy = Instantiate(easyEnemyPrefab, new UnityEngine.Vector3(5.54f, -3.57f, -0.2f), UnityEngine.Quaternion.identity);

        // keys
        GameObject key1 = Instantiate(keyPrefab, new UnityEngine.Vector3(0,0,0), UnityEngine.Quaternion.identity);
        GameObject key2 = Instantiate(keyPrefab, new UnityEngine.Vector3(0,0,0), UnityEngine.Quaternion.identity);
        GameObject key3 = Instantiate(keyPrefab, new UnityEngine.Vector3(0,0,0), UnityEngine.Quaternion.identity);

        // UI for keys
        GameObject trophyUI1 = Instantiate(trophyUIPrefab, new UnityEngine.Vector3(0,0,0), UnityEngine.Quaternion.identity);
        GameObject trophyUI2 = Instantiate(trophyUIPrefab, new UnityEngine.Vector3(0,0,0), UnityEngine.Quaternion.identity);
        GameObject trophyUI3 = Instantiate(trophyUIPrefab, new UnityEngine.Vector3(0,0,0), UnityEngine.Quaternion.identity);
    }

    void Update()
    {
        
    }
}
