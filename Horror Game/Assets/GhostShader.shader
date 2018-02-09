Shader "Custom/GhostShader" 
{
	Properties
	{
		_TexTint ("Texture Tint", COLOR) = (1, 1, 1, 1)
		_MainTex ("Texture", 2D) = "white" {}
	}

	SubShader
	{
		Tags {"Queue" = "Transparent"}

		Pass
		{ ColorMask 0 }
		Pass
		{
			Cull Back
			ZWrite Off
			Blend SrcAlpha OneMinusSrcAlpha

			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag

			uniform sampler2D _MainTex;
			float4 _TexTint;

			struct vertexInput
			{
				float4 vertex : POSITION;
				float4 texcoord : TEXCOORD0;
			};
			struct vertexOutput
			{
				float4 pos : SV_POSITION;
				float4 tex : TEXCOORD0;
			};

			vertexOutput vert (vertexInput input)
			{
				vertexOutput output;

				output.tex = input.texcoord;
				output.pos = UnityObjectToClipPos(input.vertex);
				return output;
			}
			float4 frag(vertexOutput input) : COLOR
			{
				float4 color = tex2D(_MainTex, input.tex.xy) * _TexTint;

				return color;
			}

			ENDCG
		}
	}

	Fallback "Unlit/Transparent"
}
