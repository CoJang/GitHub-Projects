Shader "Custom/NewImageEffectShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

			// mesh data : vertex Position, vertex normal, UVs, tangents, vertex colors
			// appdata = Vertex input
            struct VertexInput
            {
                float4 vertex : POSITION;
				//float4 colors : COLOR;
				//float4 normal : NORMAL;
				//float4 tangent : TANGENT;
                float2 uv0 : TEXCOORD0;
				//float2 uv1 : TEXCOORD1;
            };

			// v2f = Vertex Output
			// Vertex Output's vertex = ClipSpacePosition
            struct VertexOutput
            {
                float2 uv : TEXCOORD0;
                float4 clipSpacePos : SV_POSITION;
            };

			// Vertex Shader
			VertexOutput vert (VertexInput v)
            {
				VertexOutput o;
                o.clipSpacePos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv0;
                return o;
            }

            sampler2D _MainTex;

			fixed4 frag(VertexOutput i) : SV_Target
			{
				//fixed4 col = tex2D(_MainTex, i.uv + float2(0, sin(i.uv.y + _Time[3]) / 10));
				
				fixed4 col = tex2D(_MainTex, i.uv);
				//col = 1 - col;

                return col;
            }
            ENDCG
        }
    }
}
