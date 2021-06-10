using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class swordPresence : MonoBehaviour
{
    public List<GameObject> swordPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(swordPrefab[0], transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
