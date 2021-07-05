using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParryTargetInteraction : MonoBehaviour
{
    public GameObject hit_effect;
    public float target_lifetime = 4f;
    GameObject scoreBoard;
    public float force = 0.2f;
    public float delay = 0.5f;

    private bool TargetHit = false;

    float lifetime;
    Rigidbody target_rb;

    //public GameObject parry_sound_go;
    AudioSource parry_sound;

    // Start is called before the first frame update
    void Start()
    {
        lifetime = target_lifetime;
        target_rb = GetComponent<Rigidbody>();
        parry_sound = GameObject.Find("ParrySound").GetComponent<AudioSource>();
        scoreBoard = GameObject.Find("ScoreBoard");
    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        if(lifetime <= 0)
        {
            Destroy(gameObject);
        }
        
    }

    void FixedUpdate()
    {
        if(lifetime <= target_lifetime - delay)
        {
            target_rb.AddForce(transform.up * force);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        targetHit();
        deflect();
        parry_sound.Play();
    }

    private void OnCollisionStay()
    {
        deflect();
    }

    private void OnCollisionExit()
    {
        parry_sound.Stop();
    }

    void targetHit()
    {
        Instantiate(hit_effect, transform.position, transform.rotation);
        if(!TargetHit)
        {
            scoreBoard.GetComponent<scoreCounter>().changeScore(5);
            TargetHit = true;
        }
        
    }

    void deflect()
    {
        Instantiate(hit_effect, transform.position, transform.rotation);
        Vector3 parry_direction = new Vector3(1,0,0);
        //target_rb.AddForce(parry_direction * 50f);
    }
}
