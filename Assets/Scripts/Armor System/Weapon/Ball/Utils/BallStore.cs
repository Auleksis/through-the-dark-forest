using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallStore : MonoBehaviour
{
    //[SerializeField] Spell[] spells; 

    private Dictionary<Spell, Queue<GameObject>> ballsStore;

    private void Awake()
    {
        ballsStore = new Dictionary<Spell, Queue<GameObject>>();

        /*foreach (Spell spell in spells)
        {
            ballsStore[spell] = new Queue<GameObject>();
        }*/
    }

    public void AddSpell(Spell spell)
    {
        ballsStore[spell] = new Queue<GameObject>();
    }

    public void AddBall(GameObject ball, Spell spell)
    {
        ballsStore[spell].Enqueue(ball);
    }

    public GameObject GetBall(Spell spell)
    {
        if (ballsStore[spell].Count > 0)
        {
            GameObject ball = ballsStore[spell].Dequeue();
            ball.SetActive(true);
            return ball;
        }

        GameObject newBall = Instantiate(spell.GetSpellBall().gameObject, transform.position, Quaternion.identity);

        return newBall;
    }
}
