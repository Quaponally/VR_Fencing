using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    // target prefabs
    public GameObject target;
    public GameObject parry_target;

    // target settings
    public float y_upper = 1.75f;
    public float y_lower = 1f;
    public float x_upper = 0.3f;
    public float x_lower = -0.3f;
    public float static_distance = 1.5f;
    public float lunge_distance = 2f;
    public int max_targets = 3;
    public float target_spawn_interval = 0.5f;
    public float parry_dist = 1.3f;
    public float parry_y_upper = 1.6f;
    public float parry_y_lower = 1.2f;
    public float parry_x_upper = 0.2f;
    public float parry_x_lower = -0.2f;

    // round settings
    public bool lunge_enabled = true;
    public GameObject RoundTimer;

    // script variables
    float target_timer = 0f;
    float roundTime;

    private GameObject[] targets;
    private GameObject old_target;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        roundTime = RoundTimer.GetComponent<timeCounter>().roundTime;
        //Debug.Log(roundTime);
        if(roundTime > 0)
        {
            target_timer -= Time.deltaTime;
            if(!maxTargets(transform.position, 1f, max_targets) && target_timer <= 0)
            {
                spawnTarget();
                target_timer = target_spawn_interval;
            }
            
        }
        // else
        // {
        //     // get all targets
        //     targets = GameObject.FindGameObjectsWithTag("target");
        //     foreach (GameObject old_target in targets)
        //     {
        //         //DestroyImmediate(target, true);
        //         Destroy(target.GetComponent<MeshRenderer>());
        //     }
        // }
    }

    void spawnTarget()
    {
        if(Random.value > 0.3)
        {
            stabTarget();
        }
        else
        {
            parryTarget();
        }

    }

    // check number of targets in existence 
    bool maxTargets(Vector3 location, float radius, int max_targets)
    {
        // get nearby game objects within 1u of spawner
        Collider[] nearby_objects = Physics.OverlapSphere(location, radius);

        if(nearby_objects.Length < max_targets)
        {
            return false;
        }
        else 
        {
            return true;
        }

    }

    void stabTarget()
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
        // make sure location don't overlap
        while(maxTargets(location, 0.2f, 1))
        {
            location = new Vector3(Random.Range(x_lower, x_upper), Random.Range(y_lower, y_upper), z_dist);
        }

        // spawn target , new Quaternion(0, 90, 0, 1)
        Instantiate(target, location, transform.rotation);
    }

    void parryTarget()
    {
        // randomise location
        Vector3 location;
        location = new Vector3(Random.Range(parry_x_lower, parry_x_upper), Random.Range(parry_y_lower, parry_y_upper), parry_dist);
        Instantiate(parry_target, location, transform.rotation);

    }

}
