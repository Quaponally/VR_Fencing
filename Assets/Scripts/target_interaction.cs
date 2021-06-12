using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target_interaction : MonoBehaviour
{
    public GameObject hit_effect;
    public float target_lifetime = 3f;
    public GameObject scoreBoard;

    float lifetime;

    // Start is called before the first frame update
    void Start()
    {
        lifetime = target_lifetime;
    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        if(lifetime <= 0 )
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        targetHit();
        
    }

    void targetHit()
    {
        Debug.Log("Target Collided");
        Instantiate(hit_effect, transform.position, transform.rotation);
        Destroy(gameObject);
        scoreBoard.GetComponent<scoreCounter>().changeScore(1);
    }
 
}
