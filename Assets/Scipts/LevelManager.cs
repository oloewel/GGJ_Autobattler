using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Unity.VisualScripting;
public class LevelManager : MonoBehaviour
{
    public List<GameObject> myList;
    int currentIndex = 0;
    public int lp= 0;
    public void Next()
    {
        myList[currentIndex].SetActive(false);
        if(currentIndex + 1 < myList.Count)
        {
            myList[++currentIndex].SetActive(true);
        } else
        {    
            myList[currentIndex = 0].SetActive(true);
        }  
        
    }
}

