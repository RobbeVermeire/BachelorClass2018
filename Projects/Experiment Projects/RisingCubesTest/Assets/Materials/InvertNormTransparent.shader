Shader "Flip Normals" {
	Properties{
		_MainTex("Base (RGB)", 2D) = "white" {}
		_Transparency("Transparency", Range(0.0,0.5)) = 0.25
	}
		SubShader{

		//Tags{ "RenderType" = "Transparent" }
		Tags{ "Queue" = "Transparent" "RenderType" = "Transparent" }

		ZWrite Off

		Blend SrcAlpha OneMinusSrcAlpha

		Cull Front

		CGPROGRAM	
#pragma fragment frag 
	
#pragma surface surf Lambert vertex:vert
		sampler2D _MainTex;
		float4 _MainTex_ST;
		float _Transparency;

	struct Input {
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
		v.normal.xyz = v.normal * -1;
	}

	void surf(Input IN, inout SurfaceOutput o) {
		fixed3 result = tex2D(_MainTex, IN.uv_MainTex);
		o.Albedo = result.rgb;
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
		Fallback "Diffuse"
}