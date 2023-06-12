using System;
using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    // Angle and Movement Variables
    [SerializeField] private Vector2 minMaxAngle;
    [SerializeField] private float speed;

    // Ball Count Variables
    [SerializeField] private int ballCounter;
    public static string BallCounterString;

    // Physics Variables
    [SerializeField] private LayerMask layerMask;
    private RaycastHit2D _ray;
    private Vector2 _reflectPosition;

    // Ball Prefab and Object Variables
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private GameObject ball;

    // Permission Variables
    private float _angle;
    private bool _shootBallsPermission = false;

    private static Vector2 startPosition = new Vector2(0, (float)-3.3);
    private static GameObject sSpawner;
    private static GameObject sBall;

    private void Start()
    {
        gameObject.transform.position = startPosition;
        ball.transform.position = startPosition;
        sSpawner = gameObject;
        BallCounterString = ballCounter.ToString();
    }

    private void FixedUpdate()
    {
        var balls = GameObject.FindGameObjectsWithTag("Ball");
        var squares = GameObject.FindGameObjectsWithTag("Square");

        if (balls.Length == 0)
        {
            BallCounterString = ballCounter.ToString();
        }

        if (balls.Length == 0)
        {
            if (Input.touchCount > 0)
            {
                _ray = Physics2D.Raycast(transform.position, transform.up, 15f, layerMask);
                _reflectPosition = Vector2.Reflect(new Vector3(_ray.point.x,_ray.point.y) - transform.position,_ray.normal);
                Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
                Vector3 dir = Input.mousePosition - pos;
                _angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
                if (_angle >= minMaxAngle.x && _angle <= minMaxAngle.y)
                {
                    Debug.DrawRay(transform.position,transform.up * _ray.distance, Color.red);
                    Debug.DrawRay(_ray.point,_reflectPosition.normalized * 2f, Color.green);
                }
                transform.rotation = Quaternion.AngleAxis(_angle,transform.forward);
                _shootBallsPermission = true;
                SpawnedBall.NewSpawnerPositionGet = false;
            }
        }

        if (SpawnedBall.NewSpawnerPositionGet && balls.Length == 0)
        {
            ball.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            ball.transform.position = SpawnedBall.NewSpawnerPosition;
            gameObject.transform.position = SpawnedBall.NewSpawnerPosition;
        }

        if (SpawnedBall.DestroyedBalls == ballCounter)
        {
            
        }
    }
    private IEnumerator ShootBalls()
    {
        
        for (int i = ballCounter; i > 0; i--)
        {
            BallCounterString = (i).ToString();
            yield return new WaitForSeconds(0.2f);
            GameObject ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
            ball.GetComponent<Rigidbody2D>().AddForce(transform.up * _ray.distance * speed);
            if (i == 1)
            {
                BallCounterString = "";
            }
        }
        ball.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
    }

    public void Update()
    {
        if (Input.touchCount == 0 && _shootBallsPermission && ballCounter > 0)
        {
            StartCoroutine(ShootBalls());
            _shootBallsPermission = false;
            StartCoroutine(waitForNoBalls());
            ballCounter += SpawnedBall.DestroyedBalls;
            BallCounterString = ballCounter.ToString();
            SpawnedBall.DestroyedBalls = 0;
        }
    }

    private IEnumerator waitForNoBalls()
    {
        var balls = GameObject.FindGameObjectsWithTag("Ball");
        while (balls.Length > 0)
        {
            yield return new WaitForSeconds(0.1f);
        }
        Debug.Log(balls.Length + "ballsLength");
    }
}
    
