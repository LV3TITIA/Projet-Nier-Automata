using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyHealth : MonoBehaviour
{
    #region Exposed
    [SerializeField]
    int _ennemyHealth;
    #endregion

    #region Unity Lifecycle
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            //Debug.Log("Nombre de vie : " + _ennemyHealth);
            _ennemyHealth--;
            if (_ennemyHealth <= 0)
            {
                _gameManager.EnnemysDecreament();
                Destroy(gameObject);

            }
        }
       
            
         
    }

    #endregion

    #region Methodes
    #endregion

    #region Private & Protected

    private GameManager _gameManager;

    #endregion
}
