using UnityEngine;
using System.Collections;

public class EnterInfo : MonoBehaviour {

	public Canvas selectSex;
	public Canvas metricImperial;
	public Canvas enterInfo;

	private bool guy = false;
	private bool met = false;

	public float weight;
	public float height;
	public int age;

	public float supplies;

	public void male () {
		//Debug.Log ("your a guy");
		guy = true;
		selectSex.enabled = false;
		metricImperial.enabled = true;
	}

	public void female () {
		//Debug.Log ("your a girl");
		guy = false;
		selectSex.enabled = false;
		metricImperial.enabled = true;
	}

	public void metric () {
		//Debug.Log ("using metric system");
		met = true;
		metricImperial.enabled = false;
		enterInfo.enabled = true;
	}

	public void imperial () {
		//Debug.Log ("using imperial system");
		met = false;
		metricImperial.enabled = false;
		enterInfo.enabled = true;
	}

	public void calculate () {
		if (guy && met) {
			supplies = 66 + (13.7f * weight) + (5 * height) - (6.8f * age);
		} else if (guy && !met) {
			supplies = 66 + (6.23f * weight) + (12.7f * height) - (6.8f * age);
		} else if (!guy && met) {
			supplies = 655 + (9.6f * weight) + (1.8f * height) - (4.7f * age);
		} else if (!guy && !met) {
			supplies = 655 + ( 4.35f * weight) + (4.7f * height) - (4.7f * age);
		}
	}
}
