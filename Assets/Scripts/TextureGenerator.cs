using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TextureGenerator
{
    public static Texture2D TextureFromColourMap(Color[] colourMap, int width, int height) {
        Texture2D texture = new Texture2D(width, height);
        texture.filterMode = FilterMode.Point; // Fix the texture too blurring issue
        texture.wrapMode = TextureWrapMode.Clamp; // Fix the texture edge repeat issue
        texture.SetPixels(colourMap);
        texture.Apply();
        return texture;
    }

    public static Texture2D TextureFromHeightMap(float[,] heightMap) {
        int width = heightMap.GetLength(0); // For the 1st dimension
        int height = heightMap.GetLength(1); // For the 2nd dimension

        // Generate a 1-D array of black and white colors and apply them to the texture
        Color[] colourMap = new Color[width * height];
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                colourMap[y * width + x] = Color.Lerp(Color.black, Color.white, heightMap[x, y]); // 0~1 is the same range as the noiseMap, so we just use it here
            }
        }
        return TextureFromColourMap(colourMap, width, height);
    }
}
