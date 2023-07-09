using UnityEngine;

public class Bow : MonoBehaviour
{
    #region public variables
    public GameObject arrow;
    public Transform shotPoint;
    public int shooted;
    public GameObject[] newarrows;
    #endregion

    #region private variables
    //AudioSource bowSound;
    Vector2 direction;
    GameObject allArrows;
    readonly private float minLaunchForce = 4f;  //read only(salt okunur) yalnıca değer başka değere atanır(okunur),
    readonly private float maxLaunchForce = 18f; //yani değerin üstüne başka değer atanmaz(yazılmaz)
    [SerializeField, Range(4, 18)] private float _myNumber;
    #endregion
    public float LaunchForce       //normal bir değişken gibi get ve set değerleri var, ancak aldığı değeri(value) işleme sokup "_myNumber"a atıyor ve buradan okuyor, doğrudan kendi alıp okumuyor.
    {
        get { return _myNumber; }
        set { _myNumber = Mathf.Clamp(value, minLaunchForce, maxLaunchForce); }//Clamp is for give limit 
    }

    private void Awake()
    {
        allArrows = new GameObject("Arrows");
    }

    public void Shoot(Vector3 targetPos)
    {
        direction = Vector3.Normalize(targetPos - shotPoint.position);
        float distance = Vector3.Distance(targetPos, shotPoint.position);
        shotPoint.rotation = Quaternion.Euler(direction);
        GameObject newarrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation);
        newarrow.GetComponent<Rigidbody2D>().velocity = direction * LaunchForce * distance;
        newarrow.transform.parent = allArrows.transform; //in All arrows, we add new created arrows as a child
        if (newarrow != null)
        {
            Destroy(newarrow, 10f);
        }
        //bowSound.Play();
    }
}
