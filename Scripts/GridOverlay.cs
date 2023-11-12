using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridOverlay : MonoBehaviour
{
    private Material lineMaterial;

    public bool showMain=true;
    public bool showSub=false;

    public int gridSizeX;
    public int gridSizeY;

    public float startX;
    public float startY;
    public float startz;

    public float smallStep;
    public float largeStep;

    public Color mainColor=new Color(0f,1f,0f,1f);
    public Color subColor =  new Color(0f,0.5f,0f,1f);

    void CreateLineMaterial()
    {
        if (!lineMaterial)
        {
            var shader = Shader.Find("Hidden/Internal-Colored");
            lineMaterial = new Material(shader);

        
            lineMaterial.hideFlags=HideFlags.HideAndDontSave;
            lineMaterial.SetInt ("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha) ;
            lineMaterial.SetInt("_DstBlend",(int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            lineMaterial.SetInt("_Zwrite",0);
            lineMaterial.SetInt("_Cull",(int)UnityEngine.Rendering.CullMode.Off);
        }
    }
    private void OnDisable()
    {
        DestroyImmediate(lineMaterial);

    }
    private void OnPostRender()
    {
        CreateLineMaterial();
        lineMaterial.SetPass(0);
        GL.Begin(GL.LINES);
        if (showSub)
        {
            GL.Color(subColor);
            for (float y =0;y <= gridSizeY; y += smallStep)
            {
                GL.Vertex3(startX,startY+y,startz);
                GL.Vertex3(startX + gridSizeX,startY+y,startz);
            }
            for (float x =0;x <= gridSizeX;x+=smallStep)
            {
                GL.Vertex3(startX + x,startY,startz);
                GL.Vertex3(startX + x,startY+gridSizeY,startz);
            }
        }
        if (showMain)
        {

            GL.Color(mainColor);
            for (float y =0;y <= gridSizeY; y += largeStep)
            {
                GL.Vertex3(startX,startY+y,startz);
                GL.Vertex3(startX + gridSizeX,startY+y,startz);
            }
            for (float x =0;x <= gridSizeX;x+=largeStep)
            {
                GL.Vertex3(startX + x,startY,startz);
                GL.Vertex3(startX + x,startY+gridSizeY,startz);
            }
        }
        GL.End();

        }
}
