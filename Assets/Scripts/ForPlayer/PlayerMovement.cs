using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerMovement : MonoBehaviour
{
    [Header("General")]
    //здоров'я
    [SerializeField]private int currentHealth;
    private HealthBar _healthBar;
    //рігідбаді
    [SerializeField] private Rigidbody _rb;
    //джойстик
    public FloatingJoystick _joystick;

    //[SerializeField] private Animator _animator;
    //швидкість
    [SerializeField] private float _movementSpeed;
    //очки
    public int _schoreCount;
    //текст очки
    [SerializeField] private Text _schore;
    [SerializeField] private GameObject _attackZone;
    

    [Header("Textures")]
    [SerializeField]private MeshRenderer _renderer;
    public Texture _currentTexture;
    public Texture _hurtTexture;

    [SerializeField] private float _flashlength;
    private float _flashCounter;

    [Header("EndGame")]
    [SerializeField] private GameObject _inGameUI;
    [SerializeField] private GameObject _endGameUI;
    [SerializeField] private GameObject _pauseUI;
   



    private void Start()
    {
        _healthBar = FindObjectOfType<HealthBar>();
        _currentTexture = _renderer.material.GetTexture("_MainTex");

        StatsUpdate();
        //_storedColor = _renderer.material.GetColor("_Color");
    }

    
    private void Update()
    {
        _attackZone.transform.position = gameObject.transform.position;
        //зона атаки слідує за гравцем

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            _inGameUI.SetActive(false) ;
              _pauseUI.SetActive(false);
            _endGameUI.SetActive(true) ;
        }

        if(_flashCounter > 0)
        {
            _flashCounter -= Time.deltaTime;
            if(_flashCounter <= 0)
            {
                _renderer.material.SetTexture("_MainTex", _currentTexture);
               //_renderer.material.SetColor("_Color", _storedColor);
            }
        }

    }

    private void FixedUpdate()
    {
        _rb.velocity = new Vector3(_joystick.Horizontal * _movementSpeed,_rb.velocity.y,_joystick.Vertical * _movementSpeed);

        if(_joystick.Horizontal !=0 || _joystick.Vertical !=0)
        {
            transform.rotation = Quaternion.LookRotation(_rb.velocity);
        }    
    }

    public void HurtPlayer(int damageAmount)
    {
        currentHealth -= damageAmount;
        _healthBar.Healthfill -= 1f;
        _flashCounter = _flashlength;
        _renderer.material.SetTexture("_MainTex", _hurtTexture);
        //_renderer.material.SetColor("_Color", Color.white);
    }

    public void StatsUpdate()
    {
        currentHealth = PlayerPrefs.GetInt("Health") + 5;
    }
}
