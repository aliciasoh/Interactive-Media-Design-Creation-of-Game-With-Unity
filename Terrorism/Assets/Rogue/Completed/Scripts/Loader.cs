using UnityEngine;
using System.Collections;

namespace Completed
{	
	public class Loader : MonoBehaviour 
	{
		private GameObject levelImage;							//Image to block out level as levels are being set up, background for levelText.
		public float levelStartDelay = 2f;						//Time to wait before starting level, in seconds.

		
		void Awake ()
		{
			//Get a reference to our image LevelImage by finding it by name.
			levelImage = GameObject.Find("LevelImage");
			//Set levelImage to active blocking player's view of the game board during setup.
			levelImage.SetActive(true);

			//Call the HideLevelImage function with a delay in seconds of levelStartDelay.
			Invoke("HideLevelImage", levelStartDelay);

		}

		//Hides black image used between levels
		void HideLevelImage()
		{
			//Disable the levelImage gameObject.
			levelImage.SetActive(false);

		}
	}
}