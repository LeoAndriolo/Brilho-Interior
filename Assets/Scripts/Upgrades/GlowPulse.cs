using UnityEngine;

public class GlowPulse : MonoBehaviour
{
    public Material glowMaterial;  // Assign the emissive material in the Inspector.
    public float pulseSpeed = 1f;
    public float minIntensity = 0.5f;
    public float maxIntensity = 1.5f;
    
    private Color baseEmissionColor;

    void Start()
    {
        if (glowMaterial.HasProperty("_EmissionColor"))
        {
            baseEmissionColor = glowMaterial.GetColor("_EmissionColor");
        }
    }

    void Update()
    {
        // Calculate a pulse value between minIntensity and maxIntensity.
        float emissionIntensity = Mathf.Lerp(minIntensity, maxIntensity, (Mathf.Sin(Time.time * pulseSpeed) + 1f) / 2f);
        glowMaterial.SetColor("_EmissionColor", baseEmissionColor * emissionIntensity);
    }
}
