using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TextureHandler : AssetPostprocessor
{
    void OnPreprocessTexture()
    {
        TextureImporter tex_importer = assetImporter as TextureImporter;
        tex_importer.maxTextureSize = 728;
    }
}
