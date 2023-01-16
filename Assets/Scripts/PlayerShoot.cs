using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    #region Exposed

    [SerializeField]
    GameObject _bulletPrefab;

    [SerializeField]
    float m_fireRate = 0.35f;


    #endregion

    #region Unity Lifecycle
    void Start()
    {

    }

    void Update()
    {
        if(Input.GetAxisRaw("Shoot") != 0 && Time.timeSinceLevelLoad > _nextTimeToShoot)
        {
            _nextTimeToShoot = Time.timeSinceLevelLoad + m_fireRate;
            Instantiate(_bulletPrefab, transform.position, transform.rotation);
        }
    }
    #endregion

    #region Methodes
    #endregion

     #region Private & Protected

    private float _nextTimeToShoot;
    #endregion
}
