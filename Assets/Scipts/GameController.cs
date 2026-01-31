using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance {get; private set; }
    public List<Platzierungen> Platzierungen {get; private set; } = new();
    public List<MaskenButton> MaskenButtons {get; private set; }= new();
    public List<Maske> Masken {get; private set; }= new();
    public List<Maske> Gegner {get; private set; }= new();


    public GameObject tank;
    public GameObject kämpfer;
    public GameObject magier;
    public GameObject selectedPrefab;
    
    [SerializeField] private float roundTime = 0f;

    GameController()
    {
        Instance ??= this;
    }
    public void Check()
    {
        //Überprüfe ob noch Gegner vorhanden sind.
    }

    public void SelectTank()
    {
        Instance.selectedPrefab = tank;
    }
    public void SelectKämpfer()
    {
        Instance.selectedPrefab = kämpfer;
    }
    public void SelectMagier()
    {
        Instance.selectedPrefab = magier;
    }

    public Maske Spawn(Transform transform)
    {
        if (selectedPrefab == null)
        {
            throw new System.Exception("kein Prefab ausgewählt");
        }
        Debug.Log("Local; "+ transform.localPosition);
        Debug.Log("world; "+ transform.position);
        Debug.Log("Trans; "+ transform);
        var go = Instantiate(selectedPrefab ,transform.position, Quaternion.Euler(-90f, 180f, 0f));
        return go.GetComponent<Maske>();
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
        else if (p is Maske)
        {
            if ((p as Maske).isGegner)
            {
                Gegner.Add(p as Maske);
            }
            else
            {
                Masken.Add(p as Maske);
            }
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
        else if (r is Maske)
        {
            if ((r as Maske).isGegner)
            {
                Gegner.Remove(r as Maske);
            }
            {
                Masken.Remove(r as Maske);
            }
            
        }
    }
    void Update()
    {
        if (roundTime>0)
        {
            //Dinge passieren!
            
        } 



    }



}
