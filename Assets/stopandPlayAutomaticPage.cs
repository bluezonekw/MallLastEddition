using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UI.Pagination
{
    public class stopandPlayAutomaticPage : MonoBehaviour
    {
        public PagedRect paged;
    // Start is called before the first frame update
    void Start()
        {
            paged.AutomaticallyMoveToNextPage = false;
        }
        public void AnimationOnOff()
        {
            paged.AutomaticallyMoveToNextPage = !paged.AutomaticallyMoveToNextPage;

        }
        // Update is called once per frame
        void Update()
        {

        }
    }
}