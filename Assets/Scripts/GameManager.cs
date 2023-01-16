using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Exposed

    [SerializeField]
    int _ennemysCount;

    #endregion

    #region Unity Lifecycle
    void Start()
    {
        _ennemysCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    void Update()
    {
       
    }
    #endregion

    #region Methodes

    public void EnnemysDecreament()
    {
        _ennemysCount--;
       

        if(_ennemysCount <= 0)
        {
            Victory();
        }
    }

    private void Victory()
    {
        Debug.Log("____________VICTOIRE !____________");
    }

    public void Defeat()
    {
        Debug.Log("___________DEFAITE !____________");
    }

    #endregion

    #region Private & Protected
    #endregion
}
