using UnityEngine;

[RequireComponent(typeof(Collider))]
public class HighlightOnHover : MonoBehaviour
{
    [Header("Options de surbrillance")]
    [SerializeField] private Color highlightColor = Color.yellow;
    [SerializeField] private bool useEmission = true;
    [SerializeField] private bool useTrail = false;

    private Renderer objectRenderer;
    private Color originalColor;
    private TrailRenderer trail;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();

        if (objectRenderer != null)
        {
            originalColor = objectRenderer.material.color;
        }

        if (useTrail)
        {
            trail = GetComponent<TrailRenderer>();
            if (trail == null)
            {
                trail = gameObject.AddComponent<TrailRenderer>();
                trail.time = 0.5f;
                trail.startWidth = 0.1f;
                trail.endWidth = 0f;
                trail.emitting = false;
            }
        }
    }

    void OnMouseEnter()
    {
        if (objectRenderer != null)
        {
            if (useEmission)
            {
                objectRenderer.material.EnableKeyword("_EMISSION");
                objectRenderer.material.SetColor("_EmissionColor", highlightColor);
            }
            else
            {
                objectRenderer.material.color = highlightColor;
            }
        }

        if (useTrail && trail != null)
        {
            trail.emitting = true;
        }
    }

    void OnMouseExit()
    {
        if (objectRenderer != null)
        {
            if (useEmission)
            {
                objectRenderer.material.SetColor("_EmissionColor", Color.black);
                objectRenderer.material.DisableKeyword("_EMISSION");
            }
            else
            {
                objectRenderer.material.color = originalColor;
            }
        }

        if (useTrail && trail != null)
        {
            trail.emitting = false;
        }
    }
}

