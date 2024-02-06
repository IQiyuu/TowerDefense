using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShoot : MonoBehaviour
{
    [SerializeField] private float _dmg;
    [SerializeField] private float _fireRate;
    [SerializeField] public  float _cost;
    [SerializeField] private int _level;
    [SerializeField] private int _fireMod = 0;
    [SerializeField] int _aoe;

    [SerializeField] GameObject _bulletPrefab;

    private bool _reloading = false;
    private List<GameObject> _inRange;
    private GameObject _target = null;

    // Start is called before the first frame update
    void Start() {
        _inRange = new List<GameObject>();
    }

    IEnumerator Reload() {
        //Debug.Log("Reload start");
        _reloading = true;
        yield return new WaitForSeconds(1 / _fireRate);
        _reloading = false;
        //Debug.Log("Reload end");
    }

    void ChoseTarget() {
        float               first = -1;
        GameObject          firstE = null;
        List<GameObject>    toDelete = new List<GameObject>();

        foreach(GameObject e in _inRange) {
            if (!e) {
                toDelete.Add(e);
                break ;
            }
            switch (_fireMod) {
                case 1:
                    if (e.GetComponent<Ennemy>().GetHp() > first || first == -1) {
                        first = e.GetComponent<Ennemy>().GetHp();
                        firstE = e;
                    }
                    break ;
                default:
                    if ((float)e.GetComponent<Ennemy>().GetIndex() < first || first == -1) {
                        first = e.GetComponent<Ennemy>().GetIndex();
                        firstE = e;
                    }
                    break ;
            }
        }
        if (!_target || _target != firstE)
            _target = firstE;
        while (toDelete.Count > 0) {
            _inRange.Remove(toDelete[0]);
            toDelete.RemoveAt(0);
        }
    }

    // Update is called once per frame
    void Update() {

        ChoseTarget();

        if (_target != null && !_reloading) {
            GameObject tmp = Instantiate(_bulletPrefab);
            tmp.transform.position = transform.position;
            tmp.GetComponent<Projectiles>()._target = _target;
            tmp.GetComponent<Projectiles>()._dmg = _dmg;
            StartCoroutine(Reload());
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Ennemy") {
            _inRange.Add(col.gameObject);
            if (_target == null)
                _target = col.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject == _target) {
            _inRange.Remove(col.gameObject);
            _target = null;
        }
    }
}
