using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMovement : MonoBehaviour
{
    private Vector3 startPos;
    private float xChange = 0;
    private float yChange = 0;
    private float zChange = 0;

    [Header("XMovement")]
    public bool xMoving;
    public bool xUsingSin;
    public float xAmp;
    public float xPeriod;

    [Header("YMovement")]
    public bool yMoving;
    public bool yUsingSin;
    public float yAmp;
    public float yPeriod;

    [Header("ZMovement")]
    public bool zMoving;
    public bool zUsingSin;
    public float zAmp;
    public float zPeriod;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;    
    }

    // Update is called once per frame
    void Update()
    {
        if(xMoving)
        {
            xChange = WaveMove(xAmp, xPeriod, xUsingSin);
        }
        if(yMoving)
        {
            yChange = WaveMove(yAmp, yPeriod, yUsingSin);
        }
        if(zMoving)
        {
            zChange = WaveMove(zAmp, zPeriod, zUsingSin);
        }
        transform.position = new Vector3(startPos.x + xChange, startPos.y + yChange, startPos.z + zChange);
    }

    public float WaveMove(float amp, float period, bool isUsingSin)
    {
        if (period != 0)
        {
            if (isUsingSin)
            {
                return amp * Mathf.Sin(Time.time * (6.28f / period));
            }
            else
            {
                return amp * Mathf.Cos(Time.time * (6.28f / period));
            }
        }
        else
            return 0;
    }
}
