using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    #region Exposed

    [SerializeField]
    int _health = 5;

    [SerializeField]
    Image _healthBarGreen;

    [SerializeField]
    Image _healthBarRed;

    #endregion

    #region Unity Lifecycle
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        _originHealth = _health;

        Debug.Log("Mon random = " + Random.Range(1, 50));
    }

    void Update()
    {
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _health--;
            float coef = _health / _originHealth;
            _healthBarGreen.rectTransform.sizeDelta = new Vector2(_healthBarRed.rectTransform.sizeDelta.x * coef, _healthBarGreen.rectTransform.sizeDelta.y);
            //Debug.Log("Ma vie est de : " + _health);
            if (_health <=0)
            {
                 _gameManager.Defeat();
            }
       
        }

    }


    #endregion

    #region Methodes
    #endregion

    #region Private & Protected

    private GameManager _gameManager;

    private float _originHealth;

    #endregion
}
