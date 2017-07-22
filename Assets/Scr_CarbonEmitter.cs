using UnityEngine;

public class Scr_CarbonEmitter : MonoBehaviour
{
    public int StartQty = 4;
    public float SecondsBetween = 1;
    public Vector2 Range = new Vector2(5, 4);
    public GameObject CarbonPrefab;

    private float Reload;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < StartQty; i++)
        {
            Emit();
        }
    }

    void Emit()
    {
        var newCarbon = GameObject.Instantiate(CarbonPrefab);
        newCarbon.transform.position = new Vector3(UnityEngine.Random.Range(-Range.x, Range.x), UnityEngine.Random.Range(-Range.y, Range.y), newCarbon.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        Reload += Time.deltaTime;
        if (Reload > SecondsBetween)
        {
            Emit();
            Reload = 0;
        }

    }
}
