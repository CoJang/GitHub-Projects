Shader "Custom/FOWshader"
{
    Properties
    {
        _Color ("Color", Color) = (0,0,0,1)
        _MainTex ("Alpha Zero (A)", 2D) = "white" {}
		_MainTex2("Alpha Mid (A)", 2D) = "white" {}
    }
    SubShader
    {
        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Lambert alpha:blend

        // Use shader model 3.0 target, to get nicer looking lighting
        //#pragma target 3.0

        sampler2D _MainTex;
		sampler2D _MainTex2;


        struct Input
        {
            float2 uv_MainTex;
        };

        float4 _Color;


        //UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        //UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutput o)
        {
			fixed4 colorZero = tex2D(_MainTex, IN.uv_MainTex);
			fixed4 colorMid = tex2D(_MainTex2, IN.uv_MainTex);

			o.Albedo = _Color;
			float alpha = 1.0f - colorZero.g - colorMid.g / 4;
			o.Alpha = alpha;
        }
        ENDCG
    }
}
