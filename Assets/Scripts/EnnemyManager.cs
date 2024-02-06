using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyManager : MonoBehaviour
{
    [SerializeField] GameObject _ennemyPrefab;
    [SerializeField] GameObject _ennemyTankPrefab;

    // Start is called before the first frame update
    void Start() {
        
    }

    public IEnumerator Spawn() {
        GameObject tmp = Instantiate(_ennemyTankPrefab);
        tmp.transform.position = new Vector3(-10,0,0);
        tmp.GetComponent<Ennemy>().SetIndex(0);
        yield return new WaitForSeconds(0.2f);
        for (int i = 1; i < 4; i++) {
            tmp = Instantiate(_ennemyPrefab);
            tmp.transform.position = new Vector3(-10,0,0);
            tmp.GetComponent<Ennemy>().SetIndex(i);
            //if (i == 3)
             //   tmp.GetComponent<Ennemy>()._speed = 9;
            yield return new WaitForSeconds(0.2f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
