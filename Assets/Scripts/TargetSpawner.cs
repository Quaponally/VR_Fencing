using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    // target prefab
    public GameObject target;

    // target settings
    public float y_upper = 1.75f;
    public float y_lower = 1f;
    public float x_upper = 0.3f;
    public float x_lower = -0.3f;
    public float static_distance = 2f;
    public float lunge_distance = 2.5f;
    public int max_targets = 3;
    public float target_spawn_interval = 0.5f;

    // round settings
    public bool lunge_enabled = true;
    public GameObject RoundTimer;

    // script variables
    float target_timer = 0f;
    float roundTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        roundTime = RoundTimer.GetComponent<timeCounter>().roundTime;
        Debug.Log(roundTime);
        if(roundTime > 0)
        {
            target_timer -= Time.deltaTime;
            if(!maxTargets() && target_timer <= 0)
            {
                spawnTarget();
                target_timer = target_spawn_interval;
            }
            
        }
    }

    void spawnTarget()
    {
        // lunge or static selection
        float z_dist;

        if(Random.value > 0.75 && lunge_enabled)
        {
            z_dist =  lunge_distance;
        }
        else 
        {
            z_dist = static_distance;
        }

        // randomise location
        Vector3 location;
        location = new Vector3(Random.Range(x_lower, x_upper), Random.Range(y_lower, y_upper), z_dist);

        // spawn target , new Quaternion(0, 90, 0, 1)
        Instantiate(target, location, transform.rotation);

    }

    // check number of targets in existence 
    bool maxTargets()
    {
        // get nearby game objects within 1u of spawner
        Collider[] nearby_objects = Physics.OverlapSphere(transform.position, 1f);

        if(nearby_objects.Length < max_targets)
        {
            return false;
        }
        else 
        {
            return true;
        }

    }

    

}