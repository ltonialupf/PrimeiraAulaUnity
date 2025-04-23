
using System.Collections;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;
    [SerializeField] private float _damage;
    // private Rigidbody _rigidbody;

    private CharacterBase _characterCreated;
    private void Start()
    {
        // _rigidbody = GetComponent<Rigidbody>();
        // TryGetComponent(out _rigidbody);
        // _rigidbody.linearVelocity = Vector3.forward * _speed;

        // StartCoroutine(WaitLifeTime());
    }

    public void SetCharacterCreated(CharacterBase character)
    {
        _characterCreated = character;
    }
    
    // private IEnumerator WaitLifeTime()
    // {
    //     yield return new WaitForSeconds(_lifeTime);
    //     Destroy(gameObject);
    // }
    
    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        
        _lifeTime -= Time.deltaTime;
        if (_lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CharacterBase enemy))
        {
            if (enemy == _characterCreated) return;
            enemy.TakeDamage(_damage);
            Destroy(gameObject);
        }
        
        // if (other.CompareTag("Enemy"))
        // {
        //     Destroy(other.gameObject);
        //     Destroy(gameObject);
        // }
    }
}