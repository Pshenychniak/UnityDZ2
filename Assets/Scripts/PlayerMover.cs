using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;

    private bool _grounded;

    private void Update()
    {
        var vertical = Input.GetAxis("Vertical");
        var mouseY = Input.GetAxis("Mouse X");

        transform.Rotate(0f,mouseY,0f);

        var verticalSpeed = vertical * Time.deltaTime * _speed;
        _rigidbody.AddRelativeForce(0f,0f, verticalSpeed,ForceMode.Impulse);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Coin coin))
        {
            coin.gameObject.SetActive(false);
            
        }
    }
}
