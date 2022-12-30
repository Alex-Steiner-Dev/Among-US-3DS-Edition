Shader "Custom/ColorMaskShader"
{
    Properties
    {
        _ColorMask("Color Mask", Color) = (1, 1, 1, 1)
    }

    SubShader
    {
        // Add the required tags and rendering pipeline here

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows

        struct Input
        {
            float2 uv_MainTex;
            float4 color;
        };

        sampler2D _MainTex;
        float4 _ColorMask;

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Get the masked colors using the Color Mask property
            float4 maskedColors = tex2D (_MainTex, IN.uv_MainTex) * _ColorMask;

            // Subtract the masked colors from each R/G/B channel before coloring
            float4 subtractedColors = tex2D (_MainTex, IN.uv_MainTex) - maskedColors;

            // Add the RGB channels together
            float4 addedColors = subtractedColors + IN.color;

            // Add the masked colors to the result
            o.Albedo = addedColors + maskedColors;
        }
        ENDCG
    }
}