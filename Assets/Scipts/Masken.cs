using NUnit.Framework;
using UnityEngine;

public class Maske : MonoBehaviour
{
    public int lP = 100;
    public int sPS= 10;
    public int geschw = 1;
    public bool isGegner = false;
    private Animator animator;
    private bool isDying = false;



    void Awake()
    {
        GameController.Instance.addToScene(this);
        animator = GetComponent<Animator>();
    }
    public void Attacke()
    {
        var targets = isGegner ? GameController.Instance.Masken : GameController.Instance.Gegner;
        if(targets.Count > 0) 
        {
            targets[0].Hit(sPS);
            animator.SetTrigger("Attacke");
        }
    }


    public void Hit(int schaden)
    {
        if (isDying) return;
        lP -= schaden;
        if (lP <= 0)
        {
            isDying = true;
            animator.SetTrigger("Sterben");
        }
    }


    public void Sterben()
    {

        Debug.Log("STERBEN!");
        GameController.Instance.Check();
        GameController.Instance.removeFromScene(this);
        Destroy(gameObject);
        
    }


}
