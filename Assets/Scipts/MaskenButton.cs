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
    
    void Disable()
    {
        selected = false;
        button.image.color = Color.white;
        GameController.Instance.Platzierungen.ForEach(e =>
            {
               e.OnMouseDown();
            });
    }


    void OnClick()
    {
        if (selected)
        {
            Disable();
        }
        else
        {
            GameController.Instance.MaskenButtons.ForEach(e =>
            {
               if (e != this)
                {
                   e.Disable(); 
                }
            });
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


 