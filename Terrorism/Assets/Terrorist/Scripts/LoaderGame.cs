using UnityEngine;
using System.Collections;

namespace Completed
{	
	public class LoaderGame : MonoBehaviour 
	{
		private GameObject levelImage;							//Image to block out level as levels are being set up, background for levelText.
		public float levelStartDelay = 2f;						//Time to wait before starting level, in seconds.
		private GameObject controlImage;
		private GameObject overall;
		private GameObject controls;


		void Awake ()
		{
			//Get a reference to our image LevelImage by finding it by name.
			levelImage = GameObject.Find("LevelText");
			overall = GameObject.Find("LevelImage");
			controls = GameObject.Find("Image");



			//Set levelImage to active blocking player's view of the game board during setup.
			levelImage.SetActive(true);
			controls.SetActive(false);


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

			controlImage.SetActive(true);
			controls.SetActive(true);

			Invoke("HideControlText", 5f);
		}

		void HideControlText()
		{
			//Disable the levelImage gameObject.
			controlImage.SetActive(false);
			controls.SetActive(false);

			overall.SetActive(false);

		}
	}
}