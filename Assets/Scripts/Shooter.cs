using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float firingRate = 0.1f;

    [Header("AI")]
    [SerializeField] bool useAI;
    // Start is called before the first frame update


    [HideInInspector]public bool isFiring = false;


    Coroutine fireCoroutine;

    AudioPlayer audioPlayer;

    private void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start()
    {
        if (useAI)
        {
            isFiring = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }


    void Fire()
    {
        if (isFiring && fireCoroutine == null)
        {
            fireCoroutine = StartCoroutine(FireContinuously());
        }
        else if(!isFiring && fireCoroutine !=null)
        {
            StopCoroutine(fireCoroutine);
            fireCoroutine = null;
        }
       
    }

    IEnumerator FireContinuously()
    {

        while (true)
        {
            GameObject instance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if(rb != null)
            {
                rb.velocity = transform.up * projectileSpeed;
            }
            Destroy(instance,projectileLifetime);

            

            if (useAI)
            {
                yield return new WaitForSecondsRealtime(GetRandomFiringRate());
            }
            else
            {
                audioPlayer.PlayShootingClip();
                yield return new WaitForSecondsRealtime(firingRate);
            }
            
            
        }
    }

    public float GetRandomFiringRate()
    {
        float spawnTime = Random.Range(0.3f, 2f);
        return Mathf.Clamp(spawnTime, 0.1f, float.MaxValue);
    }
}
