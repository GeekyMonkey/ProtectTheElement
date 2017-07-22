using UnityEngine;

public class Scr_CarbonWind : MonoBehaviour
{
    public Vector2 WindDirection;
    public float WindSpeed = 1;

    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(WindDirection * WindSpeed);
    }
}
