using UnityEngine;

public class Maske : MonoBehaviour
{
    public int lP = 100;
    public int sPS= 10;
    public int geschw = 1;
    public bool isGegner = false;
 
    void Awake()
    {
        GameController.Instance.addToScene(this);
    }
    void Attacke()
    {
        var A = GameController.Instance.Gegner;
        if (A.Count>0)
        {
            A[0].Hit(sPS);
        }
    }


    void Hit(int schaden)
    {
        lP -= schaden;
        if (lP <= 0)
        {
            Sterben();
        }
    }


    void Sterben()
    {
        GameController.Instance.Check();
        GameController.Instance.removeFromScene(this);
        Destroy(this);
    }


}
