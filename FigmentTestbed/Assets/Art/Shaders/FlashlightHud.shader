Shader "UI/FlashlightHud"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Tint ("Tint", Color) = (1, 1, 1, 1)
		_DepletionTint ("DepletionTint", Color) = (1, 1, 1, 1)
		_BackgroundTint ("Background Tint", Color) = (1, 1, 1, 1)
		_Progress ("Battery Charge", Range(0, 1)) = 1
	}
	SubShader
	{
		Tags { "RenderType"="Opaque"}
		LOD 100

		Pass
		{
			Blend SrcAlpha OneMinusSrcAlpha
			ZWrite On
			ZTest On

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float4 _Tint;
			float4 _DepletionTint;
			float4 _BackgroundTint;
			float _Progress;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 smp = tex2D(_MainTex, i.uv);
				float pos = ((.5 + _Progress*.5*smp.a) - smp.r);
				fixed4 col = _Tint;
				if(pos < 0)
				col = _DepletionTint;
				if(smp.r < .5  && smp.a > 0)
				col = _BackgroundTint;
				clip(0 - (1 - smp.a));
				return col;
			}
			ENDCG
		}
	}
}
