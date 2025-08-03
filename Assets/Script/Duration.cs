using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duration : MonoBehaviour
{
    [SerializeField] private float _duration;

    private float Timer;
    // Start is called before the first frame update
    void Start()
    {
        Timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= _duration)
        {
            Destroy(this.gameObject);
        }
    }
}
