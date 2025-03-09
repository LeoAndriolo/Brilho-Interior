using UnityEngine;

public class StretchSpriteUI : MonoBehaviour
{
    // Reference to your PlayerMovement script
    public PlayerMovement playerMovement;

    // Scale values: adjust these to get the desired subtle effect.
    public float jumpScaleY = 1.2f;    // When airborne
    public float groundScaleY = 0.8f;  // When on the ground
    public float defaultScaleX = 1f;   // Horizontal scale remains unchanged
    public float lerpSpeed = 5f;       // Speed of transition

    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        // Determine target vertical scale based on whether the player is grounded.
        // Assumes PlayerMovement has a public property "IsGrounded".
        float targetScaleY = playerMovement.IsGrounded ? groundScaleY : jumpScaleY;
        
        // Smoothly interpolate the current scale toward the target value.
        Vector3 currentScale = rectTransform.localScale;
        currentScale.y = Mathf.Lerp(currentScale.y, targetScaleY, Time.deltaTime * lerpSpeed);
        currentScale.x = defaultScaleX; // Ensure horizontal scale remains constant.
        rectTransform.localScale = currentScale;
    }
}
