using UnityEngine;

public class Vacuum : MonoBehaviour
{
    private bool isActive;
    private Transform parent;
    private Collider2D[] results;
    private ContactFilter2D filter;

    public float radius = 10;

    // Start is called before the first frame update
    void Start()
    {
        parent = this.transform.parent;
        results = new Collider2D[]{};
        filter = new ContactFilter2D();
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive) {
            var circlePos = new Vector2(parent.position.x + radius, parent.position.y);
            results = new Collider2D[]{};
            
            var numCollisions = Physics2D.OverlapCircle(circlePos, radius, filter, results);

            Debug.Log(numCollisions);

            if (numCollisions <= 0 || results.Length <= 0)
            {
                return;
            }

            foreach(var result in results) {
                if (!isSwallowable(result)) {
                    continue;
                }

                // TODO move objects
            }
        }
    }

    private bool isSwallowable(Collider2D obj) {
        return obj.GetComponent<Swallowable>() != null;
    }
}
