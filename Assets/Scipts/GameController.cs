using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance {get; private set; }
    public List<Platzierungen> Platzierungen {get; private set; } = new();
    public List<MaskenButton> MaskenButtons {get; private set; }= new();

    GameController()
    {
        Instance ??= this;
    }

    
    public void addToScene<T>(T p)
    {
        if(p is Platzierungen)
        {
            Platzierungen.Add(p as Platzierungen);
        }
        else if (p is MaskenButton)
        {
            MaskenButtons.Add(p as MaskenButton);
        }
    }
    public void removeFromScene<T>(T r)
    {
        if (r is Platzierungen)
        {
            Platzierungen.Remove(r as Platzierungen);
        }
        else if (r is MaskenButton)
        {
            MaskenButtons.Remove(r as MaskenButton);
        }
    }
}
