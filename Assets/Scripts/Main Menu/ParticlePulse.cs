using UnityEngine;

public class ParticlePulse : MonoBehaviour
{
    // Reference to the ParticleSystem (assign via Inspector or let the script get it)
    public ParticleSystem ps;
    
    // Base emission rate (particles per second)
    public float baseEmissionRate = 15f;
    
    // Additional particles per second added when pulse is at peak
    public float pulseAmplitude = 10f;
    
    // Speed at which the pulse oscillates
    public float pulseSpeed = 1f;
    
    // Cached reference to the emission module
    private ParticleSystem.EmissionModule emissionModule;

    void Start()
    {
        // If not assigned in the Inspector, try to get the ParticleSystem component on this GameObject.
        if (ps == null)
            ps = GetComponent<ParticleSystem>();

        // Cache the emission module for later modifications.
        emissionModule = ps.emission;
    }

    void Update()
    {
        // Calculate a pulse value between 0 and 1 using a sine wave.
        float pulse = (Mathf.Sin(Time.time * pulseSpeed) + 1f) * 0.5f;
        
        // Compute the current emission rate.
        float currentRate = baseEmissionRate + pulse * pulseAmplitude;
        
        // Apply the calculated rate to the ParticleSystem's emission module.
        emissionModule.rateOverTime = new ParticleSystem.MinMaxCurve(currentRate);
    }
}
