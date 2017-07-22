using UnityEngine;

public class Scr_Antimatter : MonoBehaviour
{

    public float Lifespan = 5;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Lifespan -= Time.deltaTime;
        if (Lifespan <= 0)
        {
            Destroy(gameObject);
        }
    }
}
