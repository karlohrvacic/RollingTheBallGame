using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindSlow : MonoBehaviour
{
    public bool Rewind = false;
    public bool Slow = false;

    public float slowdownFactor = 0.5f;
    public float slowmodeLenght = 3f;
    public float recordTime = 3f;

    List<Vector3> positions;

    void Update()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale += (1f / slowmodeLenght) * Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
        }
         if (Input.GetKey(KeyCode.F) && Slow == false)
        {
            SloMo();
            Debug.Log("Countdown started");
            Slow = true;
        }
        if (Input.GetKey(KeyCode.E) && Rewind == false)
        {
            Rewind = true;
            StartRewind();
            Debug.Log("Rewind");
            if (Input.GetKeyUp(KeyCode.E))
                StopRewind();
        }
    }
    private void Start()
    {
        positions = new List<Vector3>();
    }
    private void FixedUpdate()
    {
        if (Rewind)
            Rewersend();
        else
            Record();
    }
    void Rewersend()
    {
        if(positions.Count > 0)
        {
            
            transform.position = positions[0];
            positions.RemoveAt(0);
        }
        else
        {
            StopRewind();
        }
    }
    void Record()
    {
        if(positions.Count > Mathf.Round(recordTime/ Time.fixedDeltaTime))
        {
            positions.RemoveAt(positions.Count - 1);
        }
        positions.Insert(0, transform.position);
    }

   
    void StartRewind()
    {
        Rewind = true;

    }
    void StopRewind()
    {
        Rewind = true;
    }

    public void SloMo()
    {
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }
}