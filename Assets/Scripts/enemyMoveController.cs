using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMoveController : MonoBehaviour
{
    public List<Transform> Waypoints;
    public float[] stayTime;
    public float Move_speed;
    public int Next_waypoint = 0;
    public bool Go_back_to_first_waypoint;
    public float nowTime = 0;
    public bool stayNow = false;
    public GameObject flashlight;
    Transform startPosition;

    void Start()
    {
        if (Waypoints.Count > 0)
        {
            startPosition = transform;
            transform.position = Waypoints[Next_waypoint].transform.position;
        }
    }

    private void FixedUpdate()
    {
        if (Waypoints.Count > 0)
        {
            if (transform.position == Waypoints[Next_waypoint].transform.position)
            {
                if (stayTime.Length > 0)
                {
                    if (stayTime[Next_waypoint] > 0)
                    {
                        if (nowTime < stayTime[Next_waypoint])
                        {
                            stayNow = true;
                        }
                        else
                        {
                            stayNow = false;
                        }
                    }
                    else
                    {
                        stayNow = false;
                    }
                }
            }
            if (stayNow)
            {
                nowTime += Time.fixedDeltaTime;
            }
            else
            {
                nowTime = 0;
                Move();
            }
        }
    }

    void Move()
    {
        if (Waypoints.Count > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, Waypoints[Next_waypoint].transform.position, Move_speed * Time.fixedDeltaTime);
            if (transform.position == Waypoints[Next_waypoint].transform.position)
            {
                if (Go_back_to_first_waypoint == false)
                {
                    if (Next_waypoint == Waypoints.Count - 1)
                    {
                        Go_back_to_first_waypoint = !Go_back_to_first_waypoint;
                        transform.Rotate(Vector3.up * 180);
                    }
                    else
                    {
                        Next_waypoint++;
                    }
                }
                else
                {
                    if (Next_waypoint == 0)
                    {
                        Go_back_to_first_waypoint = !Go_back_to_first_waypoint;
                        transform.Rotate(Vector3.up * 180);
                    }
                    else
                    {
                        Next_waypoint--;
                    }
                }
            }
        }
    }
}
