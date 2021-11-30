using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace UI.Pagination
{    
    public partial class PagedRect_LayoutGroup
    {
        public override void SetLayoutHorizontal()
        {
            SetChildrenAlongAxis(0, IsVertical);
        }

        public override void SetLayoutVertical()
        {
            SetChildrenAlongAxis(1, IsVertical);
        }

        protected void CalcAlongAxis(int axis, bool isVertical)
        {                        
            float totalSize = 0f;
            for (int i = 0; i < rectChildren.Count; i++)
            {
                var page = rectChildren[i].GetComponent<Page>();

                if (page == null) continue; // ignore any non-page children

                if (axis == 0)
                {
                    totalSize += page.layoutElement.preferredWidth * page.DesiredScale.x;
                }
                else
                {
                    totalSize += page.layoutElement.preferredHeight * page.DesiredScale.y;
                }
            }            

            SetLayoutInputForAxis(totalSize, totalSize, 1, axis);
        }

        protected void SetChildrenAlongAxis(int axis, bool isVertical)
        {            
            if (!isVertical)
            {
                SetChildrenHorizontal(axis);
            }
            else
            {
                SetChildrenVertical(axis);
            }            
        }

        protected void SetChildrenHorizontal(int axis)
        {
            float offset = 0f;

            for (int i = 0; i < rectChildren.Count; i++)
            {
                var page = rectChildren[i].GetComponent<Page>();

                if (page == null) continue; // ignore any non-page children
                
                if (axis == 1)
                {
                    SetChildAlongAxis(rectChildren[i], axis, 0, rectTransform.rect.height);                    
                }
                else
                {
                    page.rectTransform.pivot = new Vector2(0, 0.5f);

                    page.rectTransform.localPosition = new Vector2(offset, page.rectTransform.localPosition.y);
                    page.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, page.layoutElement.preferredWidth);

                    var actualWidth = page.layoutElement.preferredWidth * GetPageDesiredScale(page, 0);

                    offset += actualWidth;
                }

                offset += pagedRect.SpaceBetweenPages;
            }
        }

        protected void SetChildrenVertical(int axis)
        {
            float offset = 0f;

            for (int i = 0; i < rectChildren.Count; i++)
            {
                var page = rectChildren[i].GetComponent<Page>();

                if (page == null) continue; // ignore any non-page children
                
                if (axis == 0)
                {
                    SetChildAlongAxis(rectChildren[i], axis, 0, rectTransform.rect.width);       
                }
                else
                {
                    page.rectTransform.pivot = new Vector2(0.5f, 1);
                    page.rectTransform.localPosition = new Vector2(page.rectTransform.localPosition.x, offset);
                    page.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, page.layoutElement.preferredHeight);

                    var actualHeight = page.layoutElement.preferredHeight * GetPageDesiredScale(page, 1);
                    
                    offset -= actualHeight;                    
                }

                offset -= pagedRect.SpaceBetweenPages;
            }
        }

        protected float GetPageDesiredScale(Page page, int axis)
        {
            if (pagedRect.ShowPagePreviews)
            {                
                if (axis == 0)
                {
                    return page.DesiredScale.x;       
                }
                else
                {
                    return page.DesiredScale.y;
                }
            }

            return 1f;
        }
    }
}
