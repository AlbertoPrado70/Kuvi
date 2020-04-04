Shader "Kuvi/Background" {

    Properties {
        _Color1 ("Top", Color) = (1,1,1,1)
        _Color2 ("Bottom", Color) = (0,0,0,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
        _Emission ("Emission", Color) = (0,0,0,1)
    }

    SubShader {

        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM

            #pragma surface surf Standard fullforwardshadows

            #pragma target 3.0

            sampler2D _MainTex;

            struct Input {
            float2 uv_MainTex;
            };

            half _Glossiness;
            half _Metallic;
            fixed4 _Emission;
            fixed4 _Color1;
            fixed4 _Color2;

            UNITY_INSTANCING_BUFFER_START(Props)
            UNITY_INSTANCING_BUFFER_END(Props)

            void surf (Input IN, inout SurfaceOutputStandard o) {
            fixed4 gradColor = lerp(_Color1, _Color2, IN.uv_MainTex.y);

            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * gradColor;

            o.Albedo = c.rgb;
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Emission = _Emission * (1 - IN.uv_MainTex.y);
            o.Alpha = c.a;
            }

        ENDCG

    }

    FallBack "Diffuse"

}
