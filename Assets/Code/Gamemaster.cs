using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemaster : MonoBehaviour {
	public GameObject Hoop;
	public GameObject Player;
	public string Game_State = "Title";

	public GameObject Game_Start;
	public GameObject Game_End;
	public int Score = 0;
	public UnityEngine.UI.Text Score_Text;
	public UnityEngine.UI.Text End_Highscore;
	public UnityEngine.UI.Text End_Score;

	void Start () {
		Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
	}

	void Update () {
		if (Input.GetMouseButtonDown(0) && Game_State == "Title") {
			Game_State = "Game";
			Game_Start.SetActive(false);
			Player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
			Generate_Hoop();
			StartCoroutine(Fade(Score_Text, 2));
		}

		Score_Text.text = Score.ToString();

		if (Game_State == "End") {
			Destroy(Player);
			Game_State = "Death";
			Game_End.SetActive(true);
			if (Score > PlayerPrefs.GetInt("Highscore")) {
				PlayerPrefs.SetInt("Highscore", Score);
			}
			End_Highscore.text = " Highscore: " + PlayerPrefs.GetInt("Highscore");
			End_Score.text = " Score: " + Score;
		}
	}

	public void Generate_Hoop () {
		Instantiate(Hoop, new Vector2(Random.Range(-2.45f,2.45f), Random.Range(-4f,-1.5f)), Quaternion.identity);
	}

	IEnumerator Fade (UnityEngine.UI.Text Text, float Type) { //If type is positive then fade in. Vice versa is vice versa.
		yield return new WaitForSecondsRealtime(3);

		for (int i = 255; i > 0; i += Mathf.RoundToInt(Type)) {
			Text.color = new Color(Text.color.r, Text.color.b, Text.color.b, Text.color.a + Type/255);
			yield return new WaitForSecondsRealtime(.01f);
		}
		Text.color = new Color(Text.color.r, Text.color.b, Text.color.b, 1);
		yield return null;
	}

	public void Restart () {
		Application.LoadLevel("Main");
	}
}
