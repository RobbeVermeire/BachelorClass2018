Shader "Flip Normals" 
{

	Properties
	{
		_MainTex("Base (RGB)", 2D) = "white" {}
		_Transparency("Transparency", Range(0.0,0.5)) = 0.25
	}

	SubShader
	{
		Tags
		{ 
			"Queue" = "Transparent" 
			"RenderType" = "Transparent" 
		}
 		Cull Front
		ZWrite Off
 		Blend SrcAlpha OneMinusSrcAlpha
		Pass
		{
			CGPROGRAM	
			#pragma fragment frag 	
			#pragma surface surf Lambert vertex:vert
			#include "UnityCG.cginc"

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float _Transparency;
 			struct Input 
			{
				float2 uv_MainTex;
				float4 color : COLOR;
			};
			struct v2f
			{
				float2 uv: TEXCOORD0;
				float4 vertex: 5V_POSITION;
			}
 			void vert(inout appdata_full v)
			{
				o.Alpha = 1;
			}
 			fixed frag (v2f i): SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);
				col.a = _Transparency;
				return col;
			}
			ENDCG
		}		
 	}
}
