using UnityEngine;

namespace Cars
{
    public class WheelsComponent : MonoBehaviour
    {
        [SerializeField] private Transform _leftFrontMesh, _rightFrontMesh;

        [SerializeField] private Transform _leftRearMesh, _rightRearMesh;

        [SerializeField] private WheelCollider _leftFrontCollider, _rightFrontCollider;

        [SerializeField] private WheelCollider _leftRearCollider, _rightRearCollider;

        private Transform[] _allMeshs;

        private Transform[] _frontMeshs;
        private Transform[] _rearMeshs;

        public WheelCollider[] GetFrontWheels { get; private set; }

        public WheelCollider[] GetRearWheels { get; private set; }

        public WheelCollider[] GetAllWheels { get; private set; }

        private void Start()
        {
            ConfigurationColliders();
            ConfigurationMeshs();
        }

        public void UpdateVisual(float angle)
        {
            for (var i = 0; i < _frontMeshs.Length; i++)
            {
                GetFrontWheels[i].steerAngle = angle;
                GetFrontWheels[i].GetWorldPose(out var pos, out var quat);
                _frontMeshs[i].position = pos;
                _frontMeshs[i].rotation = quat;

                GetRearWheels[i].GetWorldPose(out pos, out quat);
                _rearMeshs[i].position = pos;
                _rearMeshs[i].rotation = quat;
            }
        }

        private void ConfigurationMeshs()
        {
            _frontMeshs = new Transform[2] { _leftFrontMesh, _rightFrontMesh };
            _rearMeshs = new Transform[2] { _leftFrontMesh, _rightRearMesh };
            _allMeshs = new Transform[4] { _leftFrontMesh, _rightRearMesh, _leftFrontMesh, _rightFrontMesh };
        }

        private void ConfigurationColliders()
        {
            GetFrontWheels = new WheelCollider[2] { _leftFrontCollider, _rightFrontCollider };
            GetRearWheels = new WheelCollider[2] { _leftRearCollider, _rightRearCollider };
            GetAllWheels = new WheelCollider[4]
                { _leftRearCollider, _rightRearCollider, _leftFrontCollider, _rightFrontCollider };
        }
    }
}