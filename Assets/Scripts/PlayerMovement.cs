using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Exposed

    [SerializeField]
    public float m_speed = 5;

    [SerializeField]
    float _jumpForce = 5;

    #endregion

    #region Unity Lifecycle
    // Start is called before the first frame update
    void Start()
    {
        
        _rigidbody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // Recupération des Inputs pour le déplacement
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        _direction.x = horizontal;
        _direction.y = vertical;
      
        // Recupération des Inputs pour la rotation

        _orientationInput.x = Input.GetAxisRaw("RightStickX");
        _orientationInput.z = Input.GetAxisRaw("RightStickY");

        // Recupération des Inputs pour le saut

        if (Input.GetButtonDown("Jump") && cubeIsOnTheGround == true)
        {
           Debug.Log("Jump !! ");
            _jumping = false;
        }

    }

    private void FixedUpdate()
    {
        //Movement
        Vector3 movement = new Vector3(_direction.x, 0, _direction.y);
        movement.Normalize();
        _rigidbody.velocity = movement * m_speed;

        //Rotation
        if (_orientationInput != Vector3.zero) 
        {
            Quaternion rotation = Quaternion.LookRotation(_orientationInput);
            _rigidbody.MoveRotation(rotation);
        }

        //Jump
        if (!_jumping) 
        {
            _rigidbody.AddForce(new Vector3(0, _jumpForce, 0));
            _jumping = true;
            cubeIsOnTheGround = false;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            Debug.Log("Je collisione " + other.name);
            _jumping = true;
            cubeIsOnTheGround = true;
        }
    }

    #endregion

    #region Methods

    #endregion 

    #region Private & Protected

    private Vector2 _direction = new Vector2();

    private Rigidbody _rigidbody;

    private Vector3 _orientationInput = new Vector3();

    bool _jumping;

    bool cubeIsOnTheGround;

    #endregion
}
