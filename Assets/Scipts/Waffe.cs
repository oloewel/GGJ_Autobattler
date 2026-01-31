using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(Renderer))]
public class Waffe : MonoBehaviour
{
    [SerializeField] private Mesh mesh;
    private bool isAnimating = false;
    private Renderer rend;
    private Color defaultColor;

    void Awake()
    {
        rend = GetComponent<Renderer>();
        defaultColor = rend.material.color;
    }

    private void reset()
    {
        isAnimating = false;
        rend.material.color = defaultColor;
    }

    public void Attack()
    {
        if(isAnimating) return;
        isAnimating = true;
        rend.material.color = Color.red;
        // TODO: Animation
        Invoke(nameof(reset), 1f);
    }
}