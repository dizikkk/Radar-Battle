using UnityEngine;

public class WarriorMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _heading;

    private float _distance;

    public void Move(Vector3 enemyPosition)
    {
        _heading = enemyPosition - gameObject.transform.position;
        _distance = _heading.magnitude;

        if (_distance > 2f)
            transform.position = Vector3.Lerp(gameObject.transform.position, enemyPosition, _speed * Time.deltaTime);
    }
}