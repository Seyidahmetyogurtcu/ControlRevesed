using UnityEngine;

public class Bow : MonoBehaviour
{
    #region public variables
    public GameObject arrow;
    //[Range(4,18)] public float LaunchForce = 8;
    public Transform shotPoint;
    public GameObject point;
    public int numberOfPoints;
    public float spaceBetweenPoints;
    public int shooted;
    public GameObject[] newarrows;
    #endregion

    #region private variables
    //AudioSource bowSound;
    GameObject[] points;
    Vector2 direction;
    GameObject allPoints;
    GameObject allArrows;
    private Vector2 bowPosition;
    private Vector2 mausePosition;
    private Vector2 stretchBowStart;
    private Vector2 stretchBowEnd;
    readonly private float minLaunchForce = 4f;  //read only(salt okunur) yalnıca değer başka değere atanır(okunur),
    readonly private float maxLaunchForce = 18f; //yani değerin üstüne başka değer atanmaz(yazılmaz)
    [SerializeField, Range(4, 18)] private float _myNumber;
    #endregion
    float atışhücü;
    public float LaunchForce       //normal bir değişken gibi get ve set değerleri var, ancak aldığı değeri(value) işleme sokup "_myNumber"a atıyor ve buradan okuyor, doğrudan kendi alıp okumuyor.
    {
        get { return _myNumber; }
        set { _myNumber = Mathf.Clamp(value, minLaunchForce, maxLaunchForce); }//Clamp is for give limit 
    }

    private void Awake()
    {
        allArrows = new GameObject("Arrows");
    }
    private void Start()
    {
        //bowSound = GetComponent<AudioSource>();
        points = new GameObject[numberOfPoints];
        for (int i = 0; i < numberOfPoints; i++)
        {
            points[i] = Instantiate(point, shotPoint.position, Quaternion.identity);
            //points[i].transform.parent = allPoints.transform;//in All Points, we add all created points as a child
        }
    }
    Vector2 PointPosition(float t)
    {
        Vector2 position = (Vector2)shotPoint.position + (direction.normalized * LaunchForce * t) + 0.5f * Physics2D.gravity * (t * t);
        return position;
    }

    public void Shoot(Vector3 targetPos)
    {
        direction = Vector3.Normalize(targetPos - shotPoint.position);
        float distance = Vector3.Distance(targetPos, shotPoint.position);
        shotPoint.rotation = Quaternion.Euler(direction);
        GameObject newarrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation);
        newarrow.GetComponent<Rigidbody2D>().velocity = transform.right * LaunchForce * distance;
        newarrow.transform.parent = allArrows.transform; //in All arrows, we add new created arrows as a child
        if (newarrow != null)
        {
            Destroy(newarrow, 10f);
        }
        //bowSound.Play();
    }
}
