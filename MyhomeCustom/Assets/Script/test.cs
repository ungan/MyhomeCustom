using UnityEngine;

public class test : MonoBehaviour
{
    public int width = 5;
    public int height = 3;
    public float cellSize = 1f;
    public Material lineMaterial;

    void OnPostRender()
    {
        if (!lineMaterial) return;

        lineMaterial.SetPass(0);
        GL.Begin(GL.LINES);
        GL.Color(Color.gray);

        for (int x = 0; x <= width; x++)
        {
            float xPos = x * cellSize;
            GL.Vertex3(xPos, 0f, 0f);
            GL.Vertex3(xPos, 0f, height * cellSize);
        }

        for (int z = 0; z <= height; z++)
        {
            float zPos = z * cellSize;
            GL.Vertex3(0f, 0f, zPos);
            GL.Vertex3(width * cellSize, 0f, zPos);
        }

        GL.End();
    }
}
