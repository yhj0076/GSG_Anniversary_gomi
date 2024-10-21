// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Oscar/ Glitch_Shader"
{
	Properties
	{
		_Main_Tex("Main_Tex", 2D) = "white" {}
		_Noise_Str("Noise_Str", Float) = 0.2
		_Alpha_Pow("Alpha_Pow", Float) = 4
		_Noise_int("Noise_int", Float) = 100
		_Sin_Time("Sin_Time", Float) = 1
		[HDR]_Main_Color("Main_Color", Color) = (1,1,1,0)
		_Noise_Panner("Noise_Panner", Vector) = (0,0,0,0)
		[Toggle(_UES_NOISE_UP_ON)] _Ues_Noise_UP("Ues_Noise_UP", Float) = 0
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Transparent+0" "IgnoreProjector" = "True" "IsEmissive" = "true"  }
		Cull Off
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 3.0
		#pragma shader_feature_local _UES_NOISE_UP_ON
		#pragma surface surf Unlit alpha:fade keepalpha noshadow noambient novertexlights nolightmap  nodynlightmap nodirlightmap nofog nometa noforwardadd 
		struct Input
		{
			float2 uv_texcoord;
			float4 vertexColor : COLOR;
		};

		uniform sampler2D _Main_Tex;
		uniform float2 _Noise_Panner;
		uniform float _Noise_int;
		uniform float _Sin_Time;
		uniform float _Noise_Str;
		uniform float4 _Main_Color;
		uniform float _Alpha_Pow;


		float3 mod2D289( float3 x ) { return x - floor( x * ( 1.0 / 289.0 ) ) * 289.0; }

		float2 mod2D289( float2 x ) { return x - floor( x * ( 1.0 / 289.0 ) ) * 289.0; }

		float3 permute( float3 x ) { return mod2D289( ( ( x * 34.0 ) + 1.0 ) * x ); }

		float snoise( float2 v )
		{
			const float4 C = float4( 0.211324865405187, 0.366025403784439, -0.577350269189626, 0.024390243902439 );
			float2 i = floor( v + dot( v, C.yy ) );
			float2 x0 = v - i + dot( i, C.xx );
			float2 i1;
			i1 = ( x0.x > x0.y ) ? float2( 1.0, 0.0 ) : float2( 0.0, 1.0 );
			float4 x12 = x0.xyxy + C.xxzz;
			x12.xy -= i1;
			i = mod2D289( i );
			float3 p = permute( permute( i.y + float3( 0.0, i1.y, 1.0 ) ) + i.x + float3( 0.0, i1.x, 1.0 ) );
			float3 m = max( 0.5 - float3( dot( x0, x0 ), dot( x12.xy, x12.xy ), dot( x12.zw, x12.zw ) ), 0.0 );
			m = m * m;
			m = m * m;
			float3 x = 2.0 * frac( p * C.www ) - 1.0;
			float3 h = abs( x ) - 0.5;
			float3 ox = floor( x + 0.5 );
			float3 a0 = x - ox;
			m *= 1.79284291400159 - 0.85373472095314 * ( a0 * a0 + h * h );
			float3 g;
			g.x = a0.x * x0.x + h.x * x0.y;
			g.yz = a0.yz * x12.xz + h.yz * x12.yw;
			return 130.0 * dot( m, g );
		}


		inline half4 LightingUnlit( SurfaceOutput s, half3 lightDir, half atten )
		{
			return half4 ( 0, 0, 0, s.Alpha );
		}

		void surf( Input i , inout SurfaceOutput o )
		{
			#ifdef _UES_NOISE_UP_ON
				float staticSwitch86 = i.uv_texcoord.x;
			#else
				float staticSwitch86 = i.uv_texcoord.y;
			#endif
			float2 appendResult84 = (float2(0.0 , staticSwitch86));
			float2 panner83 = ( 1.0 * _Time.y * _Noise_Panner + appendResult84);
			float simplePerlin2D21 = snoise( panner83*_Noise_int );
			simplePerlin2D21 = simplePerlin2D21*0.5 + 0.5;
			float mulTime48 = _Time.y * _Sin_Time;
			float4 tex2DNode1 = tex2D( _Main_Tex, ( i.uv_texcoord + ( simplePerlin2D21 * ( sin( mulTime48 ) * _Noise_Str ) ) ) );
			o.Emission = ( tex2DNode1 * _Main_Color * i.vertexColor ).rgb;
			o.Alpha = ( tex2DNode1 * pow( ( ( i.uv_texcoord.x * ( 1.0 - i.uv_texcoord.x ) * _Alpha_Pow ) * ( i.uv_texcoord.y * ( 1.0 - i.uv_texcoord.y ) * _Alpha_Pow ) ) , 2.0 ) * i.vertexColor.a ).r;
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18500
319;119;1493;885;2340.612;502.9144;1.6107;True;False
Node;AmplifyShaderEditor.TextureCoordinatesNode;19;-2257.772,-25.93392;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.StaticSwitch;86;-2029.297,-0.8414001;Inherit;False;Property;_Ues_Noise_UP;Ues_Noise_UP;7;0;Create;True;0;0;False;0;False;0;0;0;True;;Toggle;2;Key0;Key1;Create;True;True;9;1;FLOAT;0;False;0;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT;0;False;7;FLOAT;0;False;8;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;49;-1548.786,360.4763;Inherit;False;Property;_Sin_Time;Sin_Time;4;0;Create;True;0;0;False;0;False;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.Vector2Node;85;-1792.297,103.1586;Inherit;False;Property;_Noise_Panner;Noise_Panner;6;0;Create;True;0;0;False;0;False;0,0;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SimpleTimeNode;48;-1546.786,275.4763;Inherit;False;1;0;FLOAT;100;False;1;FLOAT;0
Node;AmplifyShaderEditor.DynamicAppendNode;84;-1785.297,-18.8414;Inherit;False;FLOAT2;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;23;-1158.181,390.9492;Inherit;False;Property;_Noise_Str;Noise_Str;1;0;Create;True;0;0;False;0;False;0.2;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;50;-936.084,569.9988;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.PannerNode;83;-1588.297,-22.8414;Inherit;False;3;0;FLOAT2;0,0;False;2;FLOAT2;0,0;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RangedFloatNode;26;-1518.494,150.8227;Inherit;False;Property;_Noise_int;Noise_int;3;0;Create;True;0;0;False;0;False;100;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SinOpNode;46;-1358.786,277.4763;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.NoiseGeneratorNode;21;-1365.644,4.051956;Inherit;True;Simplex2D;True;False;2;0;FLOAT2;0,0;False;1;FLOAT;500;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;55;-703.0837,617.9987;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;30;-1145.654,276.8184;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;56;-704.0837,731.9987;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;60;-705.0232,819.7865;Inherit;False;Property;_Alpha_Pow;Alpha_Pow;2;0;Create;True;0;0;False;0;False;4;4;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;58;-505.0834,747.9987;Inherit;False;3;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;25;-1076.767,-116.4939;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;22;-1079.005,14.25388;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;57;-513.0834,594.9988;Inherit;False;3;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;24;-816.2043,-41.71617;Inherit;False;2;2;0;FLOAT2;0,0;False;1;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;59;-330.0836,663.9987;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.VertexColorNode;82;-540.6385,291.7213;Inherit;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.PowerNode;61;-177.0836,662.8989;Inherit;False;False;2;0;FLOAT;0;False;1;FLOAT;2;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;1;-626.0858,31.2938;Inherit;True;Property;_Main_Tex;Main_Tex;0;0;Create;True;0;0;False;0;False;-1;df3361ea25101af44931768a7c889d3f;df3361ea25101af44931768a7c889d3f;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;64;-295.5479,170.9858;Inherit;False;Property;_Main_Color;Main_Color;5;1;[HDR];Create;True;0;0;False;0;False;1,1,1,0;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;62;-341.9889,337.3788;Inherit;False;3;3;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;63;-172.5022,36.44216;Inherit;False;3;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;0,0;Float;False;True;-1;2;ASEMaterialInspector;0;0;Unlit;Oscar/ Glitch_Shader;False;False;False;False;True;True;True;True;True;True;True;True;False;False;True;False;False;False;False;False;False;Off;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Transparent;0.5;True;False;0;False;Transparent;;Transparent;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;False;2;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;15;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;86;1;19;2
WireConnection;86;0;19;1
WireConnection;48;0;49;0
WireConnection;84;1;86;0
WireConnection;83;0;84;0
WireConnection;83;2;85;0
WireConnection;46;0;48;0
WireConnection;21;0;83;0
WireConnection;21;1;26;0
WireConnection;55;0;50;1
WireConnection;30;0;46;0
WireConnection;30;1;23;0
WireConnection;56;0;50;2
WireConnection;58;0;50;2
WireConnection;58;1;56;0
WireConnection;58;2;60;0
WireConnection;22;0;21;0
WireConnection;22;1;30;0
WireConnection;57;0;50;1
WireConnection;57;1;55;0
WireConnection;57;2;60;0
WireConnection;24;0;25;0
WireConnection;24;1;22;0
WireConnection;59;0;57;0
WireConnection;59;1;58;0
WireConnection;61;0;59;0
WireConnection;1;1;24;0
WireConnection;62;0;1;0
WireConnection;62;1;61;0
WireConnection;62;2;82;4
WireConnection;63;0;1;0
WireConnection;63;1;64;0
WireConnection;63;2;82;0
WireConnection;0;2;63;0
WireConnection;0;9;62;0
ASEEND*/
//CHKSM=BBA50644D65098783072351B3B9E7622BB196760