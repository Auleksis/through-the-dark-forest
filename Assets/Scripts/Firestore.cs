using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firestore : MonoBehaviour
{
    [SerializeField] GameObject fireballTemplate;

    private Queue<GameObject> availableFireballs;

    private void Start()
    {
        availableFireballs = new Queue<GameObject>();
    }

    public GameObject GetFireball()
    {
        if (availableFireballs.Count > 0)
        {
            GameObject queueFireball = availableFireballs.Dequeue();
            queueFireball.SetActive(true);
            return queueFireball;
        }

        GameObject fireball = Instantiate(fireballTemplate, transform.position, Quaternion.identity);

        fireball.transform.parent = transform;

        fireball.GetComponent<Fireball>().firestore = this;

        return fireball;
    }

    public void StoteFireball(GameObject fireball)
    {
        availableFireballs.Enqueue(fireball);
    }
}
