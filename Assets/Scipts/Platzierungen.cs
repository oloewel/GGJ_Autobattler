using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Platzierungen : MonoBehaviour
{
    public bool selected;

    [SerializeField] private Color normalColor = Color.white;
    [SerializeField] private Color selectedColor = Color.red;

    private Renderer rend;
    private Maske currentMaske;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
        GameController.Instance.addToScene(this);

    }

    public void Spawn()
    {
        if(!selected || currentMaske != null) return;
        currentMaske = GameController.Instance.Spawn(transform);
        selected = false;
        rend.material.color = normalColor;
    }

    public void onSelect(bool value) 
    {
        if(currentMaske != null) return;
        selected = value;
        rend.material.color = selected ? selectedColor : normalColor;
    }
    void OnDestroy()
    {
        GameController.Instance.removeFromScene(this);
    }
}
