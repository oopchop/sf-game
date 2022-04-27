using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class ShadowFiendMove : MonoBehaviour
{
    [SerializeField] private GameObject _zCoil, _xCoil, _cCoil, _coil, _healthBar;
    [SerializeField] private float _speed;
    [SerializeField] float _maxHealth = 100;

    private float _currentHealth;
    private bool _zInCd = false, _xInCd = false, _cInCd = false, _isRotate = false;
    private PhotonView _pv;

    public event Action<float> HealthChanged; 

    void Start()
    {
        _currentHealth = _maxHealth;
        _pv = GetComponent<PhotonView>();
    }
    
    void Update()
    {
        if(!_pv.IsMine) return;

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(_speed * Time.deltaTime, 0f, 0f);
            if (_isRotate)
            {
                _isRotate = false;
                transform.localScale =
                    new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                _healthBar.transform.localScale =
                    new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }
    
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(_speed * Time.deltaTime, 0f, 0f);
            if (!_isRotate)
            {
                _isRotate = true;
                transform.localScale =
                    new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                _healthBar.transform.localScale =
                    new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }
        
        if (Input.GetKey(KeyCode.Z))
        {
            if (!_zInCd)
            {
                _zInCd = true;
                GameObject coil = PhotonNetwork.Instantiate(_coil.name, _zCoil.transform.position, Quaternion.identity) as GameObject;
                coil.GetComponent<CoilScript>().Hero = gameObject;
                StartCoroutine(zCd(5));
            }
        }

        if (Input.GetKey(KeyCode.X))
        {
            if (!_xInCd)
            {
                _xInCd = true;
                GameObject coil = PhotonNetwork.Instantiate(_coil.name, _xCoil.transform.position, Quaternion.identity) as GameObject;
                coil.GetComponent<CoilScript>().Hero = gameObject;
                StartCoroutine(xCd(5));
            }
        }

        if (Input.GetKey(KeyCode.C))
        {
            if (!_cInCd)
            {
                _cInCd = true;
                GameObject coil = PhotonNetwork.Instantiate(_coil.name, _cCoil.transform.position, Quaternion.identity) as GameObject;
                coil.GetComponent<CoilScript>().Hero = gameObject;
                StartCoroutine(cCd(5));
            }
        }
    }

    public void ChangeHealth(float value)
    {
        _currentHealth += value;

        if (_currentHealth <= 0)
        {
            Death();
        }
        else
        {
            float _currentHealthAsPerctangle = (float) _currentHealth / _maxHealth;
            HealthChanged?.Invoke(_currentHealthAsPerctangle);
        }
    }

    private void Death()
    {
        HealthChanged?.Invoke(0);
        
        Debug.Log("YOU ARE DIE");
    }

    IEnumerator zCd(float cd)
    {
        yield return new WaitForSeconds(cd);
        
        _zInCd = false;
    }
    
    IEnumerator xCd(float cd)
    {
        yield return new WaitForSeconds(cd);

        _xInCd = false;
    }
    
    IEnumerator cCd(float cd)
    {
        yield return new WaitForSeconds(cd);

        _cInCd = false;
    }
}
