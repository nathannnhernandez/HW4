using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePipe : MonoBehaviour
{
    [SerializeField] private float _gameSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameController.Instance.GameOver)
        {
            return;
        }
        transform.Translate(Vector3.left * _gameSpeed * Time.deltaTime);
    }
}
