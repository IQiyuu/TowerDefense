using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShoot : MonoBehaviour
{
    [SerializeField] private float _dmg;
    [SerializeField] private float _fireRate;
    [SerializeField] public  float _cost;
    [SerializeField] private int _level;

    [SerializeField] GameObject _bulletPrefab;

    private bool _reloading = false;
    private GameObject _target = null;

    // Start is called before the first frame update
    void Start()
    {
    }

    IEnumerator Reload() {
        //Debug.Log("Reload start");
        _reloading = true;
        yield return new WaitForSeconds(1 / _fireRate);
        _reloading = false;
        //Debug.Log("Reload end");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(_target + " " + _reloading);
        if (_target != null && !_reloading) {
            if (!_target.GetComponent<EnnemyMove>().takeDmg(_dmg))
                _target = null;
            else {
                GameObject tmp = Instantiate(_bulletPrefab);
                tmp.transform.position = transform.position;
                tmp.GetComponent<Projectiles>()._target = _target;
                tmp = null;
                StartCoroutine(Reload());
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Ennemy" && _target == null) {
            _target = col.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject == _target) {
            //Debug.Log("ennemy left range");
            _target = null;
        }
    }
}
