using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GuideText : MonoBehaviour
{
    public GameObject guidePanel;
	private TextMeshProUGUI _guideText;
	private float time = 0f;
	private bool _isTextChanged = false;

	private void Start()
	{
		_guideText = guidePanel.GetComponentInChildren<TextMeshProUGUI>();
	}

	void Update()
    {
		if (PickUpAbility._isColliding)
            guidePanel.SetActive(true);

		if (PickUpAbility._isColliding && Input.GetKeyDown(KeyCode.E))
		{
			_guideText.text = "You learned invisibility skill!";
			_isTextChanged = true;
		}

		if (guidePanel.activeInHierarchy && _isTextChanged)
		{
			time += 1 * Time.deltaTime;
			if (time > 3)
			{
				guidePanel.SetActive(false);
			}
		}
	}
}
