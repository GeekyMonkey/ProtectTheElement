using UnityEngine;

public class Scr_UraniumSpinner : MonoBehaviour
{
    public float RotationSpeed = 0.5f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, RotationSpeed * Time.deltaTime);
    }
}
