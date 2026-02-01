using UnityEngine;
using UnityEngine.InputSystem;

public class RaycastClicker : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float maxDistance = 200f;
    [SerializeField] private LayerMask hitLayers = ~0; // alles

    private void Awake()
    {
        if (cam == null) cam = Camera.main;
    }

    private void Update()
    {
        if (Mouse.current == null) return;
        if (!Mouse.current.leftButton.wasPressedThisFrame) return;

        Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance, hitLayers))
        {
            var clickable = hit.collider.GetComponentInParent<Platzierungen>();
            if (clickable != null && clickable.isSelectable && clickable.selected)
            {
                clickable.Spawn();
            }
        }
    }
}
