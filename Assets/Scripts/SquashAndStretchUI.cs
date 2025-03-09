using UnityEngine;
using System.Collections;

public class SquashAndStretchUI : MonoBehaviour
{
    public PlayerMovement playerMovement;   // Assign in Inspector
    private RectTransform rectTransform;

    // Scale settings
    public Vector3 normalScale = new Vector3(1f, 1f, 1f);
    public Vector3 jumpScale = new Vector3(1f, 1.2f, 1f);
    public Vector3 landScale = new Vector3(1f, 0.8f, 1f);

    // Transition speeds
    public float stretchDuration = 0.1f;
    public float squashDuration = 0.05f;

    // Internal state
    private bool wasGrounded = true;
    private Coroutine currentCoroutine;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        rectTransform.localScale = normalScale;
    }

    void Update()
    {
        bool isGrounded = playerMovement.IsGrounded;

        // Check for transition from ground to air (jump)
        if (!isGrounded && wasGrounded)
        {
            // Stop any ongoing animation to avoid overlap
            if (currentCoroutine != null)
                StopCoroutine(currentCoroutine);

            // Stretch upward
            currentCoroutine = StartCoroutine(ScaleOverTime(rectTransform.localScale, jumpScale, stretchDuration));
        }
        // Check for transition from air to ground (landing)
        else if (isGrounded && !wasGrounded)
        {
            if (currentCoroutine != null)
                StopCoroutine(currentCoroutine);

            // Squash down, then return to normal
            currentCoroutine = StartCoroutine(LandSquash());
        }

        wasGrounded = isGrounded;
    }

    private IEnumerator LandSquash()
    {
        // Go from jumpScale (or whatever current scale) to landScale
        yield return StartCoroutine(ScaleOverTime(rectTransform.localScale, landScale, squashDuration));
        // Then go back to normalScale
        yield return StartCoroutine(ScaleOverTime(rectTransform.localScale, normalScale, squashDuration));
    }

    private IEnumerator ScaleOverTime(Vector3 fromScale, Vector3 toScale, float duration)
    {
        float time = 0f;
        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;
            rectTransform.localScale = Vector3.Lerp(fromScale, toScale, t);
            yield return null;
        }
        rectTransform.localScale = toScale;
    }
}
