using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Scr_ParticleSensing : MonoBehaviour
{
    [Header("Connections")]
    public float SpringDistance = 2f;
    public float Damping = 0.3f;

    public List<ParticleConnection> Connections;

    // Use this for initialization
    void Start()
    {
        this.Connections = new List<ParticleConnection>();

    }

    // Update is called once per frame
    void Update()
    {
        // update lines
        foreach (var connection in Connections)
        {
            Vector3[] positions = new Vector3[2];
            positions[0] = this.transform.position;
            positions[1] = connection.OtherGameObject.transform.position;
            if (connection.LineRenderer != null)
            {
                connection.LineRenderer.SetPositions(positions);
            }
        }
    }

    private void FixedUpdate()
    {
        // Sense all nearby particles
        var particles = FindObjectsOfType<Scr_ParticleSensing>();
        bool isUranium = tag == "Uranium";

        // Only look for later ones
        int i;
        bool foundSelf = false;
        for (i = 0; i < particles.Length; i++)
        {
            if (particles[i] == this)
            {
                foundSelf = true;
            }
            else if (foundSelf || isUranium)
            {
                var other = particles[i].gameObject;
                float distance = (other.transform.position - this.transform.position).magnitude;
                if (distance <= SpringDistance)
                {
                    if (isUranium)
                    {
                        Debug.Log(i + " Uranium near " + other.name);
                    }
                    AttachSpringTo(other);
                }
            }
        }

    }

    /// <summary>
    /// Is the other particle already connected to this one?
    /// </summary>
    /// <param name="other">The other particle</param>
    public bool IsConnected(GameObject other)
    {
        bool connected = this.Connections.Any(c => c.OtherGameObject == other);
        if (!connected)
        {
            // Check if the other object owns a connection to this one
            var otherParticleSensing = other.GetComponent<Scr_ParticleSensing>();
            if (otherParticleSensing != null)
            {
                connected = otherParticleSensing.Connections.Any(c => c.OtherGameObject == this.gameObject);
            }
        }
        return connected;
    }

    /// <summary>
    /// Attach a spring to the other object
    /// </summary>
    /// <param name="other">Object to connect to</param>
    public void AttachSpringTo(GameObject other)
    {
        // Not if it's already connected
        if (IsConnected(other))
        {
            Debug.Log("Already connected to " + other.name);
        }
        else
        {
            // Create the spring
            SpringJoint2D springJoint = gameObject.AddComponent<SpringJoint2D>();
            springJoint.distance = this.SpringDistance;
            springJoint.autoConfigureDistance = false;
            springJoint.connectedBody = other.GetComponent<Rigidbody2D>();
            springJoint.anchor = new Vector2(transform.localScale.x / 2, 0);
            springJoint.connectedAnchor = new Vector2(other.transform.localScale.x / 2, 0); ;

            // Line Renderer
            var lineRenderer = gameObject.AddComponent<LineRenderer>();
            if (lineRenderer != null)
            {
                lineRenderer.endWidth = lineRenderer.startWidth = .05f;
            }

            // Add to the list of connections
            this.Connections.Add(new ParticleConnection
            {
                OtherGameObject = other,
                Spring = springJoint,
                LineRenderer = lineRenderer
            });

            // Once connected with the uranium, remove wind
            //if (this.tag == "Uranium")
            //{
            var wind = other.GetComponent<Scr_CarbonWind>();
            if (wind != null)
            {
                wind.enabled = false;
            }
            //}
        }
    }
}
