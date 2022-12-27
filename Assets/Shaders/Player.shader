Shader "Custom/PlayerShader"
{
    Properties
    {
        _MainTexture("Texture", 2D) = "white" {}
        _BrightColor("Bright Color", Color) = (1,1,1,1)
        _ShadowColor("Shadow Color", Color) = (0,0,0,1)
        _VisorColor("Visor Color", Color) = (0.5,0.5,0.5,1)
    }

        SubShader
        {
            // Add any rendering options or pass statements here
            // For example:
            // Pass
            // {
            //   // Add any rendering commands here
            // }

            CGPROGRAM
            #pragma surface surf Standard fullforwardshadows

            struct SurfaceOutputStandard
            {
                float4 Albedo;
                float3 Normal;
                float4 Emission;
                float3 WorldPos;
                float3 WorldNormal;
                float3 WorldTangent;
                float3 WorldBitangent;
                float3 ViewDir;
                float Specular;
                float Smoothness;
                float3 ReflectDir;
                float3 ReflectColor;
                float3 RefractDir;
                float3 RefractColor;
                float3 Fresnel;
                float Alpha;
                float EmissionScale;
                float Translucency;
                float EmissionIntensity;
            };

        // Code to separate the different colors of the sprite
        int allChannels = In.r + In.b + In.g;
        float mask = min(min(In.b,In.g),allChannels);
        float brightMask = In.r - mask;
        float shadowMask = In.b - mask;
        float visorMask = In.g - mask;

        // Code to apply the different colors to the sprite
        float4 result;
        result += brightMask * _BrightColor;
        result += shadowMask * _ShadowColor;
        result += visorMask * _VisorColor;
        result += mask;
        result.a = In.a;

        // Code to apply the texture to the sprite
        result *= tex2D(_MainTexture, IN.uv_MainTex);

        // Return the final color of the sprite
        return result;

        ENDCG
        }
}
