using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] EnnemyManager _ennemyManager;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(_ennemyManager.Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
