Shader "Toon/Tessellation (Displacement)" {
Properties {
	_Color ("Main Color", Color) = (1,1,1,1)
	_Parallax ("Height", Range (0.0, 1.0)) = 0.5
	_MainTex ("Base (RGB) Gloss (A)", 2D) = "white" {}
	_BumpMap ("Normalmap", 2D) = "bump" {}
	_ParallaxMap ("Heightmap (A)", 2D) = "black" {}
	_Ramp ("Toon Ramp (RGB)", 2D) = "gray" {} 
	_EdgeLength ("Edge length", Range(3,50)) = 10
}
SubShader { 
	Tags { "RenderType"="Opaque" }
	LOD 800
	
CGPROGRAM
#pragma surface surf ToonRamp vertex:disp tessellate:tessEdge
#include "Tessellation.cginc"

struct appdata {
	float4 vertex : POSITION;
	float4 tangent : TANGENT;
	float3 normal : NORMAL;
	float2 texcoord : TEXCOORD0;
	float2 texcoord1 : TEXCOORD1;
};

float _EdgeLength;
float _Parallax;

sampler2D _Ramp;

// custom lighting function that uses a texture ramp based
// on angle between light direction and normal
#pragma lighting ToonRamp exclude_path:prepass
inline half4 LightingToonRamp (SurfaceOutput s, half3 lightDir, half atten)
{
	#ifndef USING_DIRECTIONAL_LIGHT
	lightDir = normalize(lightDir);
	#endif
	
	half d = dot (s.Normal, lightDir)*0.5 + 0.5;
	half3 ramp = tex2D (_Ramp, float2(d,d)).rgb;
	
	half4 c;
	c.rgb = s.Albedo * _LightColor0.rgb * ramp * (atten * 2);
	c.a = 0;
	return c;
}

float4 tessEdge (appdata v0, appdata v1, appdata v2)
{
	return UnityEdgeLengthBasedTessCull (v0.vertex, v1.vertex, v2.vertex, _EdgeLength, _Parallax * 1.5f);
}

sampler2D _ParallaxMap;

void disp (inout appdata v)
{
	float d = tex2Dlod(_ParallaxMap, float4(v.texcoord.xy,0,0)).a * _Parallax;
	v.vertex.xyz += v.normal * d;
}

sampler2D _MainTex;
sampler2D _BumpMap;
float4 _Color;

struct Input {
	float2 uv_MainTex : TEXCOORD0;
	float2 uv_BumpMap;
};

void surf (Input IN, inout SurfaceOutput o) {
	half4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
	o.Albedo = c.rgb;
	o.Alpha = c.a;
	o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
}
ENDCG
}

FallBack "Toon/Lit"
}
