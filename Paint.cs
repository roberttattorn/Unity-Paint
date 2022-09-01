using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Paint : MonoBehaviour
{
	public Camera cam;
	private int brush=0;
	private int colour =0;
	private Color pallette;
	public GameObject body;
	public GameObject tail;
	public GameObject engine1;
	public GameObject engine2;
	public GameObject toggle1;
	public GameObject toggle2;
	public GameObject toggle3;
	public GameObject black;
	public GameObject orange;
	public GameObject blue;
	public GameObject grey;
	public GameObject red;
	public GameObject yellow;
	public GameObject cyan;
	public GameObject brown;
	public GameObject purple;
	public GameObject green;

	private Texture2D tex ;
	private Vector2 pixelUV;
	
	void Start()
	{
		//cam = GetComponent<Camera>();
		PlayerPrefs.SetInt("livery",0);
	}
	
	void Update()
	{
		if (Input.GetMouseButton(0))
		{
		
		RaycastHit hit;

		if (!Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit,500))
			return;
		//NoTE: make sure to add mesh collider for target object
		Renderer rend = hit.transform.GetComponent<Renderer>();
		MeshCollider meshCollider = hit.collider as MeshCollider;
		//Debug.Log(rend.sharedMaterial.mainTexture);//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
		if (rend == null || rend.sharedMaterial == null || rend.sharedMaterial.mainTexture == null || meshCollider == null)
			return;

		//if(hit.transform.name!="body")
			//return;           //exit script
		if(Input.GetKey(KeyCode.LeftShift))
			return; 
		//Debug.Log("raying");//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
		 tex = rend.material.mainTexture as Texture2D;
		 pixelUV = hit.textureCoord;
		pixelUV.x *= tex.width;
		pixelUV.y *= tex.height;
		if(brush==0)
		{     if(colour==0)//black
				 tex.SetPixel((int)pixelUV.x, (int)pixelUV.y, Color.black);
				if(colour==1)//green
					tex.SetPixel((int)pixelUV.x, (int)pixelUV.y, Color.green);
				if(colour==2)//grey
					tex.SetPixel((int)pixelUV.x, (int)pixelUV.y, Color.grey);
				if(colour==3)//blue
					tex.SetPixel((int)pixelUV.x, (int)pixelUV.y, Color.blue);
				if(colour==4)//orange
					tex.SetPixel((int)pixelUV.x, (int)pixelUV.y, new Color( 255, 127, 39 ));
				if(colour==5)//brown
					tex.SetPixel((int)pixelUV.x, (int)pixelUV.y, new Color( 185, 122,87 ));
				if(colour==6)//purple
					tex.SetPixel((int)pixelUV.x, (int)pixelUV.y, new Color( 163, 73, 164 ));
				if(colour==7)//cyan
					tex.SetPixel((int)pixelUV.x, (int)pixelUV.y, Color.cyan);
				if(colour==8)//red
					tex.SetPixel((int)pixelUV.x, (int)pixelUV.y, Color.red);
				if(colour==9)//yellow
					tex.SetPixel((int)pixelUV.x, (int)pixelUV.y, Color.yellow);
			tex.Apply();}
			else
				if(brush==1)
			{     if(colour==0)//black
				{Brush(Color.black);}
				if(colour==1)//green
				{  Brush(Color.green);}
				if(colour==2)//grey
				{Brush(Color.grey);}
				if(colour==3)//blue
				{Brush(Color.blue);}
				if(colour==4)//orange
				{Brush(new Color( 255, 127, 39 )); }
				if(colour==5)//brown
				{Brush(new Color( 185, 122, 87 )); }
				if(colour==6)//purple
				{Brush(new Color( 164, 73,164 )); }
				if(colour==7)//cyan
				{Brush(Color.cyan);}
				if(colour==8)//red
				{Brush(Color.red);}
				if(colour==9)//yellow
				{Brush(Color.yellow);}
				tex.Apply();}

			if(brush==2)
			{     if(colour==0)//black
				{BigBrush(Color.black);}
				if(colour==1)//green
				{  BigBrush(Color.green);}
				if(colour==2)//grey
				{BigBrush(Color.grey);}
				if(colour==3)//blue
				{BigBrush(Color.blue);}
				if(colour==4)//orange
				{BigBrush(new Color( 255, 127, 39 )); }
				if(colour==5)//brown
				{BigBrush(new Color( 185, 122, 87 )); }
				if(colour==6)//purple
				{BigBrush(new Color( 164, 73,164 )); }
				if(colour==7)//cyan
				{BigBrush(Color.cyan);}
				if(colour==8)//red
				{BigBrush(Color.red);}
				if(colour==9)//yellow
				{BigBrush(Color.yellow);}
				tex.Apply();}
	   }//xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
	}

	public void Reset(){
		Renderer rend = body.GetComponent<Renderer>();
		Texture2D tex = rend.material.mainTexture as Texture2D;
		for(int i=1;i<=tex.height ;i++){
			for(int j=1;j<=tex.width ;j++)
				tex.SetPixel(j, i, Color.white);
		}
		tex.Apply();
		rend = tail.GetComponent<Renderer>();
		tex = rend.material.mainTexture as Texture2D;
		for(int i=1;i<=tex.height ;i++){
			for(int j=1;j<=tex.width ;j++)
				tex.SetPixel(j, i, Color.white);
		}
		tex.Apply();
		rend = engine1.GetComponent<Renderer>();
		tex = rend.material.mainTexture as Texture2D;
		for(int i=1;i<=tex.height ;i++){
			for(int j=1;j<=tex.width ;j++)
				tex.SetPixel(j, i, Color.white);
		}
		tex.Apply();
		rend = engine2.GetComponent<Renderer>();
		tex = rend.material.mainTexture as Texture2D;
		for(int i=1;i<=tex.height ;i++){
			for(int j=1;j<=tex.width ;j++)
				tex.SetPixel(j, i, Color.white);
		}
		tex.Apply();
	}

	public void Brush1(){
		if(toggle1.GetComponent<Toggle>().isOn)
		brush=0;
	}

	public void Brush2(){
		if(toggle2.GetComponent<Toggle>().isOn)
		brush=1;
	}
	public void Brush3(){
		if(toggle3.GetComponent<Toggle>().isOn)
		brush=2;
	}

	public void Black(){
		if(black.GetComponent<Toggle>().isOn)
		colour=0;
	}
	public void Green(){
		if(green.GetComponent<Toggle>().isOn)
		colour=1;
	}
	public void Grey(){
		if(grey.GetComponent<Toggle>().isOn)
		colour=2;
	}
	public void Blue(){
		if(blue.GetComponent<Toggle>().isOn)
		colour=3;
	}
	public void Orange(){
		if(orange.GetComponent<Toggle>().isOn)
		colour=4;
	}
	public void Brown(){
		if(brown.GetComponent<Toggle>().isOn)
		colour=5;
	}
	public void Purple(){
		if(purple.GetComponent<Toggle>().isOn)
		colour=6;
	}
	public void Cyan(){
		if(cyan.GetComponent<Toggle>().isOn)
		colour=7;
	}
	public void Red(){
		if(red.GetComponent<Toggle>().isOn)
		colour=8;
	}
	public void Yellow(){
		if(yellow.GetComponent<Toggle>().isOn)
		colour=9;
	}

	void Brush(Color pallette){
		tex.SetPixel((int)pixelUV.x, (int)pixelUV.y, pallette);
		tex.SetPixel((int)pixelUV.x+1, (int)pixelUV.y, pallette);
		tex.SetPixel((int)pixelUV.x-1, (int)pixelUV.y, pallette);
		tex.SetPixel((int)pixelUV.x, (int)pixelUV.y+1, pallette);
		tex.SetPixel((int)pixelUV.x, (int)pixelUV.y-1, pallette);
		tex.SetPixel((int)pixelUV.x+1, (int)pixelUV.y+1, pallette);
		tex.SetPixel((int)pixelUV.x-1, (int)pixelUV.y-1, pallette);
		tex.SetPixel((int)pixelUV.x+1, (int)pixelUV.y-1, pallette);
		tex.SetPixel((int)pixelUV.x-1, (int)pixelUV.y+1, pallette);
	}

	void BigBrush(Color pallette){
		tex.SetPixel((int)pixelUV.x, (int)pixelUV.y, pallette);tex.SetPixel((int)pixelUV.x+2, (int)pixelUV.y+1, pallette);
		tex.SetPixel((int)pixelUV.x+1, (int)pixelUV.y, pallette);tex.SetPixel((int)pixelUV.x-2, (int)pixelUV.y-1, pallette);
		tex.SetPixel((int)pixelUV.x-1, (int)pixelUV.y, pallette);tex.SetPixel((int)pixelUV.x+2, (int)pixelUV.y, pallette);
		tex.SetPixel((int)pixelUV.x, (int)pixelUV.y+1, pallette);tex.SetPixel((int)pixelUV.x-2, (int)pixelUV.y, pallette);
		tex.SetPixel((int)pixelUV.x, (int)pixelUV.y-1, pallette);tex.SetPixel((int)pixelUV.x, (int)pixelUV.y+2, pallette);
		tex.SetPixel((int)pixelUV.x+1, (int)pixelUV.y+1, pallette);tex.SetPixel((int)pixelUV.x, (int)pixelUV.y-2, pallette);
		tex.SetPixel((int)pixelUV.x-1, (int)pixelUV.y-1, pallette);tex.SetPixel((int)pixelUV.x+1, (int)pixelUV.y+2, pallette);
		tex.SetPixel((int)pixelUV.x+1, (int)pixelUV.y-1, pallette);tex.SetPixel((int)pixelUV.x-1, (int)pixelUV.y+2, pallette);
		tex.SetPixel((int)pixelUV.x-1, (int)pixelUV.y+1, pallette);tex.SetPixel((int)pixelUV.x+2, (int)pixelUV.y-1, pallette);
		tex.SetPixel((int)pixelUV.x-2, (int)pixelUV.y+1, pallette);
	}

}