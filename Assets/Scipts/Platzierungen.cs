using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Platzierungen : MonoBehaviour
{
    public bool selected;

    [SerializeField] private Color normalColor = Color.white;
    [SerializeField] private Color selectedColor = Color.red;

    private Renderer rend;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
        GameController.Instance.addToScene(this);

    }

    public void onSelect(bool value) 
    {
        selected = value;
        rend.material.color = selected ? selectedColor : normalColor;
    }
    void OnDestroy()
    {
        GameController.Instance.removeFromScene(this);
    }
}
