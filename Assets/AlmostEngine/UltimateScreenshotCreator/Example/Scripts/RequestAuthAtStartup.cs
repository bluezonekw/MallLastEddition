using UnityEngine;
using System.Collections;



using AlmostEngine.Screenshot;

namespace AlmostEngine.Examples
{
		public class RequestAuthAtStartup : MonoBehaviour
		{
				void Start ()
				{
						#if UNITY_IOS
						if(!iOsUtils.HasGalleryAuthorization()){
							iOsUtils.RequestGalleryAuthorization();
						}
						#endif
				}
		}
}