using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyfishController : MonoBehaviour
{
    public float EnemyHealthNumberJellyfish = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyHealthNumberJellyfish < 1)
        {
            Destroy(gameObject);
        }
    }
}
