using UnityEngine;

public class Player : CharacterBase
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;

    private void Start()
    {
        _audioSource.clip = _audioClip;
        _audioSource.Play();
    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f,
            moveVertical);
        transform.Translate(movement * _speed * Time.deltaTime);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }
}