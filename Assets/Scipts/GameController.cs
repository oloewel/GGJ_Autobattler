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
    
    private float _delta = 0;
    private float _time = 0;
    private bool _roundRunning;

    public void StartRound()
    {
        if (Masken.Count == 0 || Gegner.Count == 0)
        {
            Debug.Log("Runde kann nicht starten: Team oder Gegner leer.");
            return;
        }
        _roundRunning = true;
        Debug.Log("Runde gestartet!");
    }

    public void Check()
    {
        if (Gegner.Count == 0)
        {
            _roundRunning = false;
            Debug.Log("Spieler gewinnen!");
        }
        else if (Masken.Count == 0)
        {
            _roundRunning = false;
            Debug.Log("Gegner gewinnen!");
        }
    }

    private void Awake()
    {
        // Falls schon eine Instanz existiert → diese hier zerstören
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        // Optional, falls Szenen gewechselt werden:
        // DontDestroyOnLoad(gameObject);
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

    public Maske Spawn(Transform t)
    {
        if (selectedPrefab == null)
        {
            throw new System.Exception("kein Prefab ausgewählt");
        }
        var go = Instantiate(selectedPrefab, t.position, t.rotation);
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
        if (!_roundRunning) return;

        _time += Time.deltaTime;
        if(_time <= 6) return;
        _time = 0;
        
        //Kampf-Tick: beide Seiten lassen angreifen
        for (int i = 0; i < Masken.Count; i++)
        {
            Debug.Log("Maske: Andgriff!");
            Masken[i].Attacke();   
        }

        for (int i = 0; i < Gegner.Count; i++)
         {
            Debug.Log("Gegner: Andgriff!");
            Gegner[i].Attacke();   
        }
    }



}
