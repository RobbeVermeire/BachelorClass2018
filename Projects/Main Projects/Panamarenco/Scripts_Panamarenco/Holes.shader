Shader "Holes" 
{
     Properties 
	 {
       _MainTex ("Texture (RGB)", 2D) = "white" {}
       [PerRendererData] _SliceGuide ("Slice Guide (RGB)", 2D) = "white" {}
       _SliceAmount ("Slice Amount", Range(0.0, 1.0)) = 0.9
	 }
     SubShader 
	   {
		Tags { "RenderType" = "Transparent" }
		Cull Off
	    CGPROGRAM
		#pragma surface surf Lambert 
		   struct Input 
			{
			   float2 uv_MainTex;
			   float2 uv_SliceGuide;
			   float _SliceAmount;
		   };

		   sampler2D _MainTex;
		   sampler2D _SliceGuide;
		   float _SliceAmount;

		   void surf (Input IN, inout SurfaceOutput o) 
		   {
			   clip(tex2D (_SliceGuide, IN.uv_SliceGuide).rgb - _SliceAmount);
			   o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
		   }
	    ENDCG
     }
     Fallback "Diffuse"
}