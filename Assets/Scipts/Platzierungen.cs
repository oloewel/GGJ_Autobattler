using UnityEngine;

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

    public void OnMouseDown() 
    {
        if (selected)
        {
            selected = false;
            rend.material.color = selected ? selectedColor : normalColor;
            
        }
        else
        {
            selected = true;
            rend.material.color = selected ? selectedColor : normalColor;
        }
    }
    void OnDestroy()
    {
        GameController.Instance.removeFromScene(this);
    }
}
