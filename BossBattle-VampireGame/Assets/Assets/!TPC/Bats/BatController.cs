using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class BatController : MonoBehaviour
{

    public GameObject _player,_blood;
    public NavMeshAgent _nav;
    public Animator _anim;
    public float _health;
    public bool isDie;
    public GameObject _Bullet;
    int _bulletWait;
    public float MoveDis;
    private void OnEnable()
    {
        _player = GameObject.FindGameObjectWithTag("Player");

        
    }

    private void Update()
    {
        FncSeekingPlayer();
    }

    void FncSeekingPlayer()
    {
        if (_player)
        {
            if (isDie == false)
            {
                float _dis = Vector3.Distance(this.transform.position, _player.transform.position);

                if (_dis > MoveDis)
                {
                    _anim.SetBool("Move", true);
                    _nav.SetDestination(_player.transform.position);
                }
                else
                {
                    _anim.SetBool("Move", false);
                    _anim.SetBool("Attack", true);
                }
            }
        }
    }


    public void FncGiveDamage()
    {
        if(_bulletWait ==0)
        {
            _Bullet.GetComponent<AttackMove>()._player = _player.transform;
            Instantiate(_Bullet, transform.position, Quaternion.identity);
        }
        _bulletWait++;

        if(_bulletWait >10)
        {
            _bulletWait = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Hand"))
        {
            if(_player.GetComponent<Controller>()._isAttack)
            {
                if(isDie == false)
                {
                    StartCoroutine(Ie_Blood());
                    this
                        ._health -= 10;
                    //_anim.SetTrigger("Damage");

                    if(this._health <=0)
                    {
                        isDie = true;
                        _anim.SetBool("Attack", false);
                        _anim.SetTrigger("Die");
                        FncDestroy();
                    }
                }

           
            }
        }
    }

    IEnumerator Ie_Blood()
    {
        _blood.SetActive(true);
        yield return new WaitForSecondsRealtime(0.5f);
        _blood.SetActive(false);
    }

    void FncDestroy()
    {
        Destroy(this.gameObject, 2);
    }
}
