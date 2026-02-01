using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Platzierungen : MonoBehaviour
{
    public bool selected;

    [SerializeField] private Color normalColor = Color.white;
    [SerializeField] private Color selectedColor = Color.red;

    public virtual bool isSelectable => true;

    private Renderer rend;
    private Maske currentMaske;

    protected virtual void Awake()
    {
        rend = GetComponent<Renderer>();
        GameController.Instance.addToScene(this);
    }
    public void OnGamestart()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
    public void Spawn(GameObject gameObject = null)
    {
        if(currentMaske != null) return;
        currentMaske = GameController.Instance.Spawn(transform, gameObject);
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
