using UnityEngine;
using UnityEngine.UI;

public class MaskenButton : MonoBehaviour
{
    public bool selected;
    public string MaskenTyp;
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
        GameController.Instance.addToScene(this);
    }
    


    void OnClick()
    {
        if (selected)
        {
            selected = false;
            button.image.color = Color.white;
        }
        else
        {
            selected = true;
            button.image.color = Color.red;
            GameController.Instance.Platzierungen.ForEach(e =>
            {
               e.OnMouseDown();
            });
        }
    }
    void OnDestroy()
    {
        GameController.Instance.removeFromScene(this);
    }
}


 