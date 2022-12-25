using UnityEngine;

namespace BusinessSimulator
{
    public class Block : MonoBehaviour
    {
        public View View { get; private set; }

        public void SetView(View view)
        {
            View = view;
        }
    }
}
