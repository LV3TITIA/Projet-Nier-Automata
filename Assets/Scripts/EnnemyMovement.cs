using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyMovement : MonoBehaviour
{
    #region Exposed

    [SerializeField]

    public float m_speed = 10f;
    public float m_rotationSpeed = 10f;

    #endregion

    #region Unity Lifecycle
    void Start()
    {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();

        _rigidbody = GetComponent<Rigidbody>();

    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        Vector3 directionToPlayer = playerTransform.position - transform.position;
        Quaternion rotationToPlayer = Quaternion.LookRotation(directionToPlayer);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, rotationToPlayer, m_rotationSpeed * Time.deltaTime);

        _rigidbody.velocity = transform.forward * m_speed;
        _rigidbody.MoveRotation(rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Je collisione " + other.name);
       if (other.gameObject.name == "Playertrigger")
        {
            Destroy(gameObject);
        }
    }

    #endregion

    #region Methodes
    #endregion

    #region Private & Protected

    private Rigidbody _rigidbody;

    private Transform playerTransform;

    #endregion
}
