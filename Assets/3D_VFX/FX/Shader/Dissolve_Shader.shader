// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Oscar/Dissolve_Shader"
{
	Properties
	{
		_Main_Tex("Main_Tex", 2D) = "white" {}
		_Noise_Tex("Noise_Tex", 2D) = "white" {}
		_Dissolve_int("Dissolve_int", Float) = -1
		_Dissolve_Line_Size("Dissolve_Line_Size", Float) = 0.05
		[HDR]_Dissolve_Color("Dissolve_Color", Color) = (1,1,1,1)
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Transparent+0" "IgnoreProjector" = "True" "IsEmissive" = "true"  }
		Cull Front
		CGPROGRAM
		#pragma target 3.0
		#pragma surface surf Unlit alpha:fade keepalpha noshadow 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform sampler2D _Main_Tex;
		uniform float4 _Main_Tex_ST;
		uniform float4 _Dissolve_Color;
		uniform sampler2D _Noise_Tex;
		SamplerState sampler_Noise_Tex;
		uniform float4 _Noise_Tex_ST;
		uniform float _Dissolve_Line_Size;
		uniform float _Dissolve_int;

		inline half4 LightingUnlit( SurfaceOutput s, half3 lightDir, half atten )
		{
			return half4 ( 0, 0, 0, s.Alpha );
		}

		void surf( Input i , inout SurfaceOutput o )
		{
			float2 uv_Main_Tex = i.uv_texcoord * _Main_Tex_ST.xy + _Main_Tex_ST.zw;
			float2 uv_Noise_Tex = i.uv_texcoord * _Noise_Tex_ST.xy + _Noise_Tex_ST.zw;
			float4 tex2DNode2 = tex2D( _Noise_Tex, uv_Noise_Tex );
			float temp_output_11_0 = saturate( floor( ( ( tex2DNode2.r + _Dissolve_Line_Size ) - _Dissolve_int ) ) );
			o.Emission = ( tex2D( _Main_Tex, uv_Main_Tex ) + ( _Dissolve_Color * ( temp_output_11_0 - saturate( floor( ( tex2DNode2.r - _Dissolve_int ) ) ) ) ) ).rgb;
			o.Alpha = temp_output_11_0;
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18500
2171;116;1493;885;1816.142;211.9634;1.3;True;False
Node;AmplifyShaderEditor.RangedFloatNode;6;-1711.197,664.0608;Inherit;False;Property;_Dissolve_Line_Size;Dissolve_Line_Size;3;0;Create;True;0;0;False;0;False;0.05;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;2;-1841.859,342.3503;Inherit;True;Property;_Noise_Tex;Noise_Tex;1;0;Create;True;0;0;False;0;False;-1;85c78d5b6e124814aa4c0d148c643122;85c78d5b6e124814aa4c0d148c643122;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;5;-1473.197,645.0608;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;4;-1460.443,485.3211;Inherit;False;Property;_Dissolve_int;Dissolve_int;2;0;Create;True;0;0;False;0;False;-1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;3;-1213.443,368.3211;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;7;-1224.197,641.0608;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.FloorOpNode;8;-1039.514,371.067;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.FloorOpNode;9;-1044.514,639.067;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;10;-892.5139,372.067;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;11;-911.5139,637.067;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;12;-704.5139,354.067;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;14;-827.0742,146.7436;Inherit;False;Property;_Dissolve_Color;Dissolve_Color;4;1;[HDR];Create;True;0;0;False;0;False;1,1,1,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;13;-532.0742,148.7436;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;1;-912.7711,-99.3338;Inherit;True;Property;_Main_Tex;Main_Tex;0;0;Create;True;0;0;False;0;False;-1;b3091084c5090df4eab1dd58984ff67b;b3091084c5090df4eab1dd58984ff67b;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;15;-339.4889,13.20108;Inherit;True;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;0,0;Float;False;True;-1;2;ASEMaterialInspector;0;0;Unlit;Oscar/Dissolve_Shader;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Front;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Transparent;0.5;True;False;0;False;Transparent;;Transparent;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;False;2;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;15;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;5;0;2;1
WireConnection;5;1;6;0
WireConnection;3;0;2;1
WireConnection;3;1;4;0
WireConnection;7;0;5;0
WireConnection;7;1;4;0
WireConnection;8;0;3;0
WireConnection;9;0;7;0
WireConnection;10;0;8;0
WireConnection;11;0;9;0
WireConnection;12;0;11;0
WireConnection;12;1;10;0
WireConnection;13;0;14;0
WireConnection;13;1;12;0
WireConnection;15;0;1;0
WireConnection;15;1;13;0
WireConnection;0;2;15;0
WireConnection;0;9;11;0
ASEEND*/
//CHKSM=9E8ABFE1DCB882BEF646F37184B9BCEB804354E3