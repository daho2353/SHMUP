using UnityEngine;                 // Required for Unity
using System.Collections;          // Required for Arrays & other Collections

public class Enemy : MonoBehaviour
{
    [Header("Set in the Unity Inspector")]
    public float speed = 10f;      // The speed in m/s
    public float fireRate = 0.3f;  // Seconds/shot (Unused)
    public float health = 10;
    public int score = 100;      // Points earned for destroying this”
    // This is a Property: A method that acts like a field
    private BoundsCheck bndCheck;
    void Awake()
    {
        bndCheck = GetComponent<BoundsCheck>();
    }
    public Vector3 pos
    {                                                // a
        get
        {
            return (this.transform.position);
        }
        set
        {
            this.transform.position = value;
        }
    }

    void Update()
    {
        Move();
        if(bndCheck != null && bndCheck.offDown)
        {
            Destroy(gameObject);
        }
    }

    public virtual void Move()
    {                                        // b
        Vector3 tempPos = pos;
        tempPos.y -= speed * Time.deltaTime;
        pos = tempPos;
    }

    private void OnCollisionEnter(Collision coll)
    {
        GameObject otherRootGO = coll.transform.root.gameObject;
        if(otherRootGO.tag == "ProjectileHero")
        {
            Destroy(otherRootGO);
            Destroy(gameObject);
        }
        else
        {
            print("Enemy hit by Non-ProjectileHero" + otherRootGO.name);
        }
    }

}
