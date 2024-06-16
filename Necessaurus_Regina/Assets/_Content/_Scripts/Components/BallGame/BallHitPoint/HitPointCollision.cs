using BallGame.Managers;
using BallGame.Player.Controller;
using UnityEngine;

namespace BallGame.Components.Player.HitPoint.Collision
{
    public class HitPointCollision : MonoBehaviour
    {
        [SerializeField] private E_HitVersions _hitVersion;
        [SerializeField] private float _bounceForce;
        [SerializeField] private float _minAngle;
        [SerializeField] private float _maxAngle;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Ball ball = collision.GetComponent<Ball>();
            if (ball != null)
            {
                BallCollision(ball);
            }
        }

        private void BallCollision(Ball ball)
        {
            ball.BounceBall(GetNewSpeed(ball));
            BallScoreManager.Instance.AddAction(_hitVersion);
            BallScoreManager.Instance.AddScore("Hit");
            EventHub.BallHitPlayer(_hitVersion);
        }

        private Vector3 GetNewSpeed(Ball ball)
        {
            Vector2 normal = CalculateNormal(ball.transform);
            float angle = Vector2.SignedAngle(Vector2.up, normal);
            angle = Mathf.Clamp(angle, _minAngle, _maxAngle);
            normal = Quaternion.Euler(0, 0, angle) * Vector2.up;
            Vector3 reflectDirection = Vector2.Reflect(ball.rb.velocity, normal);

            return reflectDirection.normalized * _bounceForce;
        }
        private Vector2 CalculateNormal(Transform other)
        {
            return (other.position - transform.position).normalized;
        }
    }
}
