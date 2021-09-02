using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class MenuButtonManager : MonoBehaviour {

	[SerializeField]
	private Button playButton;
	[SerializeField]
	private Button quitButton;
	[SerializeField]
	private Button helpButton;

	[SerializeField]
	private Button exitHelp;

	[SerializeField]
	private Image helpInfo;
	[SerializeField]
	private Image helpInfoDescription;


	void Start() {
		helpInfo.enabled = false;
		helpInfoDescription.enabled = false;

		playButton.gameObject.SetActive(true);
		quitButton.gameObject.SetActive(true);
		helpButton.gameObject.SetActive(true);
		exitHelp.gameObject.SetActive(false);
	}


	public void PlayButtonPress() {
		SceneManager.LoadScene("NormalSea");
		Debug.Log("PLAY BUTTON PRESSED");
	}

	public void HelpButtonPress() {
		helpInfo.enabled = true;
		helpInfoDescription.enabled = true;

		playButton.gameObject.SetActive(false);
		quitButton.gameObject.SetActive(false);
		helpButton.gameObject.SetActive(false);
		exitHelp.gameObject.SetActive(true);

		Debug.Log("HELP BUTTON PRESSED");
	}

	public void QuitButtonPress() {
		Application.Quit();
		Debug.Log("QUIT BUTTON PRESSED");
	}

	public void ExitHelp() {
		helpInfo.enabled = false;
		helpInfoDescription.enabled = false;

		playButton.gameObject.SetActive(true);
		quitButton.gameObject.SetActive(true);
		helpButton.gameObject.SetActive(true);
		exitHelp.gameObject.SetActive(false);
	}
}