using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHandler : MonoBehaviour
{
    public Controller _C;
    public GameObject[] _swords;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            _swords[0].SetActive(false);
            _swords[1].SetActive(true);
            SwordAttack();
        }

    }

    void SwordAttack()
    {
        _C.canMove = false;
        _C.characterAnimator.SetTrigger("SwordAttack");
    }

    public void FncReacive()
    {
        _swords[0].SetActive(true);
        _swords[1].SetActive(false);
    }
}
