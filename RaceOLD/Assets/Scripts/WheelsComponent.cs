using UnityEngine;

namespace Cars
{
    public class WheelsComponent : MonoBehaviour
    {
        [SerializeField]
        private Transform _leftFrontMesh, _rightFrontMesh;
        [SerializeField]
        private Transform _leftRearMesh, _rightRearMesh;
        [SerializeField]
        private WheelCollider _leftFrontCollider, _rightFrontCollider;
        [SerializeField]
        private WheelCollider _leftRearCollider, _rightRearCollider;

        private Transform[] _frontMeshs;
        private Transform[] _rearMeshs;
        private Transform[] _allMeshs; 
        private WheelCollider[] _frontColliders;
        private WheelCollider[] _rearColliders;
        private WheelCollider[] _allColliders;

        public WheelCollider[] GetFrontWheels => _frontColliders;
        public WheelCollider[] GetRearWheels => _rearColliders;
        public WheelCollider[] GetAllWheels => _allColliders;

        private void Start()
        {
            ConfigurationColliders();
            ConfigurationMeshs();
        }
        public void UpdateVisual(float angle)
        {
            for (int i = 0; i < _frontMeshs.Length; i++)
            {
                _frontColliders[i].steerAngle = angle;
                _frontColliders[i].GetWorldPose(out Vector3 pos, out Quaternion quat);
                _frontMeshs[i].position = pos;
                _frontMeshs[i].rotation = quat;

                _rearColliders[i].GetWorldPose(out pos, out quat);
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
            _frontColliders = new WheelCollider[2] { _leftFrontCollider, _rightFrontCollider };
            _rearColliders = new WheelCollider[2] { _leftRearCollider, _rightRearCollider };
            _allColliders = new WheelCollider[4] { _leftRearCollider, _rightRearCollider, _leftFrontCollider, _rightFrontCollider };
        }
    }
}