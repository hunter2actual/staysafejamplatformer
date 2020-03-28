using UnityEngine;

public class Vacuum : MonoBehaviour
{
    public float radius = 10;

    private GroundedCharacterController charControl;

    // Start is called before the first frame update
    void Start()
    {
        charControl = GetComponent<GroundedCharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(charControl.Direction);

        var spherePos = new Vector3(this.transform.position.x + radius, this.transform.position.y, this.transform.position.z);
            
        var items = Physics.OverlapSphere(spherePos, radius);

        if (items.Length <= 0)
        {
            return;
        }

        foreach (var result in items) {
            if (!isSwallowable(result)) {
                continue;
            }

            var moveDirection = this.transform.position - result.transform.position;
            var magnitude = 2f;

            result.transform.Translate(moveDirection * Time.deltaTime);
        }
    }

    private bool isSwallowable(Collider obj) {
        var swallowable = obj.GetComponent<Swallowable>();

        return swallowable != null;
    }
}
