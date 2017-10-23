// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Personal/BeginnerShader/1_FlatColorShader" {
	Properties{
		_Color ("Color", Color) = (1.0,1.0,1.0,1.0)
	}
	SubShader {
		Pass {
			CGPROGRAM

			//pragmas
			#pragma vertex vert
			#pragma fragment frag

			//user defined variables
			uniform float4 _Color;
			//base input structs
			struct vertexInput{
				float4 vertex : POSITION;
			};
			struct vertexOutput{
				float4 pos : SV_POSITION;
			};
			//vertex function
			vertexOutput vert(vertexInput vIn){
				vertexOutput vOut;
				vOut.pos = UnityObjectToClipPos(vIn.vertex);
				return vOut;
			}
			//fragment Function
			float4 frag(vertexOutput o): COLOR
			{
				return _Color;
			}

			ENDCG
		}
	}
	//comment out during development
	Fallback "Diffuse"
}