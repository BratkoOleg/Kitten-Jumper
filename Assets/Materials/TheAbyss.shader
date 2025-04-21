Shader "Xan's Shaders/Abyssal Void"
{
	Properties
	{
		[MainTex] _MainTex("Body Texture", 2D) = "black" {}
		[HDR] _UnderglowColor("Underglow Color", Color) = (0.57, 0.25, 0.69)
		_GlowSharpness("Underglow Sharpness", Range(0, 16)) = 3
		// TODO: IntRange? Whole numbers have much better performance.
	}
	SubShader
	{
		Tags { 
			"RenderType" = "Opaque" 
			"Queue" = "Geometry" 
			"ForceNoShadowCasting" = "true"
			"IgnoreProjector" = "true"
			"VRCFallback" = "Unlit"
		}

		Pass
		{
			CGPROGRAM

			// #include "XanCommon.cginc"
			// XanCommon.cginc:
			#define HEXCOLOR(r,g,b) fixed4(float3(r, g, b) / 255, 0)
			#define HEXCOLORALPHA(r,g,b,a) fixed4(r, g, b, a) / 255
			#define OBJECT_POSITION mul(unity_ObjectToWorld, float4(0, 0, 0, 1))
			#define SCREEN_SIZE _ScreenParams.xy
			///////////////////////

			#include "UnityCG.cginc"

			#pragma vertex abyssalVert
			#pragma fragment abyssalFrag
			#pragma multi_compile_fog
			#pragma multi_compile_instancing

			struct VertexInput
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
				float3 normal : NORMAL;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};
		
			struct FragmentInput
			{
				float4 vertex : SV_POSITION;
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1) // TEXCOORD1
				float3 normal : NORMAL;
				float3 viewDir : TEXCOORD2;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			UNITY_INSTANCING_BUFFER_START(Data)
				UNITY_DEFINE_INSTANCED_PROP(half4, _UnderglowColor)
				UNITY_DEFINE_INSTANCED_PROP(half, _GlowSharpness)
			UNITY_INSTANCING_BUFFER_END(Data)
			
			FragmentInput abyssalVert(VertexInput vtxIn)
			{
				FragmentInput fragIn = (FragmentInput)0;
				UNITY_SETUP_INSTANCE_ID(vtxIn);
				UNITY_TRANSFER_INSTANCE_ID(vtxIn, fragIn);
				
				fragIn.vertex = UnityObjectToClipPos(vtxIn.vertex);
				fragIn.uv = TRANSFORM_TEX(vtxIn.uv, _MainTex);
				fragIn.normal = normalize(mul(unity_ObjectToWorld, vtxIn.normal)); // This has to be normalized, otherwise scaling the mesh causes problems
				fragIn.viewDir = normalize(WorldSpaceViewDir(vtxIn.vertex));

				UNITY_TRANSFER_FOG(fragIn, fragIn.vertex);
				return fragIn;
			}


			fixed4 abyssalFrag(FragmentInput fragIn) : SV_Target
			{
				UNITY_SETUP_INSTANCE_ID(fragIn);
				
				half4 mainCol = tex2D(_MainTex, fragIn.uv);
				half4 clr = UNITY_ACCESS_INSTANCED_PROP(Data, _UnderglowColor);
				half power = UNITY_ACCESS_INSTANCED_PROP(Data, _GlowSharpness);
				
				half dot01 = saturate(dot(fragIn.viewDir, fragIn.normal));
				half deflection = saturate(pow(1 - dot01, power)); 
				// ^ This is saturated as otherwise, aggressive powers of near-zero dot products cause "sparking" on the model, 
				// where single pixels get brightness values in the hundreds or thousands, resulting in extremely bright flashes on the viewer's screen
				// Couple this with a bloom effect, and you have a single-pixel flashbang. Looks hilarious but also terrible for UX.

				mainCol += clr * deflection * 0.4;
				UNITY_APPLY_FOG(fragIn.fogCoord, mainCol);
				return mainCol;
			}
			ENDCG
		}
	}
}
