using UnityEngine;
using System.Collections;

namespace Completed
{	
	public class LoaderGame2 : MonoBehaviour 
	{
		private GameObject levelImage;							//Image to block out level as levels are being set up, background for levelText.
		public float levelStartDelay = 2f;						//Time to wait before starting level, in seconds.
		private GameObject controlImage;
		private GameObject overall;
		private GameObject levelImage1;							//Image to block out level as levels are being set up, background for levelText.


		void Awake ()
		{
			//Get a reference to our image LevelImage by finding it by name.
			levelImage = GameObject.Find("LevelText");
			levelImage1 = GameObject.Find("LevelText (1)");
			levelImage1.SetActive(false);

			overall = GameObject.Find("LevelImage (2)");


			//Set levelImage to active blocking player's view of the game board during setup.
			levelImage.SetActive(true);

			//Call the HideLevelImage function with a delay in seconds of levelStartDelay.
			Invoke("HideLevelImage", levelStartDelay);

			controlImage = GameObject.Find("ControlText");
			controlImage.SetActive(false);



		}

		//Hides black image used between levels
		void HideLevelImage()
		{
			//Disable the levelImage gameObject.
			levelImage.SetActive(false);

			levelImage1.SetActive(true);
			Invoke("HideLevelImage1", 5f);
		}

		void HideLevelImage1(){
			//Disable the levelImage gameObject.
			levelImage1.SetActive(false);
			controlImage.SetActive(true);
			Invoke("HideControlText", 5f);
		}

		void HideControlText()
		{
			//Disable the levelImage gameObject.
			controlImage.SetActive(false);
			overall.SetActive(false);

		}
	}
}