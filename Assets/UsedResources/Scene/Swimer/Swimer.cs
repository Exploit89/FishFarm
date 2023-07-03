using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent (typeof(Neighborhood))]

public class Swimer : MonoBehaviour
{
    private Spawner _spawner;
    private Rigidbody _rigidbody;
    private Neighborhood _neighborhood;
    private Attractor _attractor;
    private float _velocity = 3f;
    private float _attractPull = 1f;
    private float _attractPush = 1f;
    private float _velocityMatching = 0.25f;
    private float _attractPushDistance = 1f;
    private float _colliderAvoid = 2f;
    private float _flockCentering = 0.2f;

    public Vector3 FishStartPosition
    {
        get
        {
            return transform.position;
        }
        private set
        {
            transform.position = value;
        }
    }

    private void Awake()
    {
        _neighborhood = GetComponent<Neighborhood>();
        _rigidbody = GetComponent<Rigidbody>();
        Vector3 velocity = Random.onUnitSphere * _velocity;
        _rigidbody.velocity = velocity;
        LookAhead();
    }

    private void LookAhead()
    {
        transform.LookAt(FishStartPosition + _rigidbody.velocity);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 velocity = _rigidbody.velocity;
        Vector3 velocityAvoid = Vector3.zero;
        Vector3 tooClosePosition = _neighborhood.AverageClosePosition;

        if (tooClosePosition != Vector3.zero)
        {
            velocityAvoid = FishStartPosition - tooClosePosition;
            velocityAvoid.Normalize();
            velocityAvoid *= _velocity;
        }
        Vector3 velocityAlign = _neighborhood.AverageVelocity;

        if (velocityAlign != Vector3.zero)
        {
            velocityAlign.Normalize();
            velocityAlign *= _velocity;
        }
        Vector3 velocityCenter = _neighborhood.AveragePosition;

        if (velocityCenter != Vector3.zero)
        {
            velocityCenter -= transform.position;
            velocityCenter.Normalize();
            velocityCenter *= _velocity;
        }

        Vector3 delta = _attractor.GetPosition() - FishStartPosition;
        bool attracted = (delta.magnitude > _attractPushDistance);
        Vector3 velAttract = delta.normalized * _velocity;
        float fixedDeltaTime = Time.fixedDeltaTime;

        if (velocityAvoid != Vector3.zero)
        {
            velocity = Vector3.Lerp(velocity, velocityAvoid, _colliderAvoid * fixedDeltaTime);
        }
        else
        {
            if (velocityAlign != Vector3.zero)
                velocity = Vector3.Lerp(velocity, velocityAlign, _velocityMatching * fixedDeltaTime);

            if (velocityCenter != Vector3.zero)
                velocity = Vector3.Lerp(velocity, velocityAlign, _flockCentering * fixedDeltaTime);

            if (velAttract != Vector3.zero)
            {
                if (attracted)
                    velocity = LimitSwimHeight(Vector3.Lerp(velocity, velAttract, _attractPull * fixedDeltaTime));
                else
                    velocity = LimitSwimHeight(Vector3.Lerp(velocity, -velAttract, _attractPush * fixedDeltaTime));
            }
        }
        velocity = velocity.normalized * _velocity;
        _rigidbody.velocity = velocity;
        LookAhead();
    }

    private Vector3 LimitSwimHeight(Vector3 vector)
    {
        if (vector.y > 1)
            vector.y = 1;
        return vector;
    }

    public void Init(Spawner spawner, Attractor attractor)
    {
        _spawner = spawner;
        _attractor = attractor;
    }

    public Vector3 GetRigidbodyVelocity()
    {
        Vector3 velocity = new Vector3();
        return velocity = _rigidbody.velocity;
    }
}
