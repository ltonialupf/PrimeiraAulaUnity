using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    [SerializeField] protected float _speed = 5f;
    [SerializeField] private GameObject _posTiro;
    [SerializeField] private GameObject _balaPrefab;

    private float _life = 100f;

    public void TakeDamage(float damage)
    {
        Debug.Log("Take Damage: " + damage);
        _life -= damage;
        if (_life <= 0)
        {
            Destroy(gameObject);
        }
    }

    protected void Shoot()
    {
        Bala bala = Instantiate(_balaPrefab, 
            _posTiro.transform.position, transform.rotation).GetComponent<Bala>();
        bala.SetCharacterCreated(this);
    }
}