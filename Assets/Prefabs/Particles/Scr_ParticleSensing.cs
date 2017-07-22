using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ParticleSensing : MonoBehaviour
{
    [Header("Connections")]
    public float Distance = 2f;
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
            var otherParticleSensing = other.GetComponent<ParticleSensing>();
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
        if (!IsConnected(other))
        {
            SpringJoint2D springJoint = gameObject.AddComponent<SpringJoint2D>();
            springJoint.connectedBody = other.GetComponent<Rigidbody2D>();
        }
    }
}
