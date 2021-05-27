using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostEffect : MonoBehaviour
{
	// Start is called before the first frame update
	public Material monoTone;

	void OnRenderImage(RenderTexture src, RenderTexture dest)
	{
		Graphics.Blit(src, dest, monoTone);
	}
}
