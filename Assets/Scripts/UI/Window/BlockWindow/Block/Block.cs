using UnityEngine;

namespace BusinessSimulator
{
    public class Block : MonoBehaviour
    {
        private View _view;

        public void SetView(View view)
        {
            _view = view;
        }
    }
}
