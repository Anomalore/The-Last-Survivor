// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:33009,y:32691,varname:node_3138,prsc:2|emission-7241-RGB,alpha-4764-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:32593,y:32679,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Slider,id:4609,x:32239,y:33074,ptovrint:False,ptlb:Opacity,ptin:_Opacity,varname:node_4609,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.01,max:1;n:type:ShaderForge.SFN_RemapRange,id:227,x:30272,y:32853,varname:node_227,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-5040-OUT;n:type:ShaderForge.SFN_Add,id:766,x:30593,y:32853,varname:node_766,prsc:2|A-6612-R,B-6612-G;n:type:ShaderForge.SFN_ComponentMask,id:6612,x:30427,y:32853,varname:node_6612,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-227-OUT;n:type:ShaderForge.SFN_Abs,id:3943,x:30757,y:32853,varname:node_3943,prsc:2|IN-766-OUT;n:type:ShaderForge.SFN_Frac,id:8767,x:31957,y:32766,varname:node_8767,prsc:2|IN-5360-OUT;n:type:ShaderForge.SFN_Step,id:7661,x:32225,y:32767,varname:node_7661,prsc:2|A-8767-OUT,B-3975-OUT;n:type:ShaderForge.SFN_Add,id:3608,x:32675,y:33090,varname:node_3608,prsc:2|A-4609-OUT,B-5586-OUT;n:type:ShaderForge.SFN_Multiply,id:5586,x:32579,y:32919,varname:node_5586,prsc:2|A-137-OUT,B-3314-OUT;n:type:ShaderForge.SFN_Slider,id:3314,x:32239,y:32972,ptovrint:False,ptlb:LinesOpacity,ptin:_LinesOpacity,varname:node_3314,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Vector4Property,id:1330,x:29425,y:33040,ptovrint:False,ptlb:CamPosition,ptin:_CamPosition,varname:node_1330,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0,v2:0,v3:0,v4:0;n:type:ShaderForge.SFN_Subtract,id:8524,x:29608,y:32972,varname:node_8524,prsc:2|A-5219-XYZ,B-1330-XYZ;n:type:ShaderForge.SFN_Transform,id:3751,x:29768,y:32972,varname:node_3751,prsc:2,tffrom:0,tfto:2|IN-8524-OUT;n:type:ShaderForge.SFN_ComponentMask,id:4299,x:29923,y:32972,varname:node_4299,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-3751-XYZ;n:type:ShaderForge.SFN_FragmentPosition,id:5219,x:29425,y:32886,varname:node_5219,prsc:2;n:type:ShaderForge.SFN_Subtract,id:4026,x:30942,y:32853,varname:node_4026,prsc:2|A-3943-OUT,B-5475-OUT;n:type:ShaderForge.SFN_ValueProperty,id:5475,x:30748,y:33015,ptovrint:False,ptlb:LinesDistance,ptin:_LinesDistance,varname:node_5475,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.1;n:type:ShaderForge.SFN_Multiply,id:8526,x:31114,y:32853,varname:node_8526,prsc:2|A-6506-OUT,B-4026-OUT;n:type:ShaderForge.SFN_OneMinus,id:7851,x:31282,y:32899,varname:node_7851,prsc:2|IN-8526-OUT;n:type:ShaderForge.SFN_Clamp01,id:9238,x:31447,y:32853,varname:node_9238,prsc:2|IN-8526-OUT;n:type:ShaderForge.SFN_Power,id:815,x:31608,y:32766,varname:node_815,prsc:2|VAL-9238-OUT,EXP-1710-OUT;n:type:ShaderForge.SFN_Add,id:1710,x:31307,y:32602,varname:node_1710,prsc:2|A-6671-OUT,B-4957-OUT;n:type:ShaderForge.SFN_Vector1,id:4957,x:31109,y:32723,varname:node_4957,prsc:2,v1:1.01;n:type:ShaderForge.SFN_Multiply,id:5360,x:31794,y:32766,varname:node_5360,prsc:2|A-815-OUT,B-9079-OUT;n:type:ShaderForge.SFN_TexCoord,id:8293,x:29920,y:32671,varname:node_8293,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_OneMinus,id:137,x:32396,y:32814,varname:node_137,prsc:2|IN-7661-OUT;n:type:ShaderForge.SFN_Clamp01,id:4764,x:32838,y:32978,varname:node_4764,prsc:2|IN-3608-OUT;n:type:ShaderForge.SFN_SwitchProperty,id:5040,x:30096,y:32867,ptovrint:False,ptlb:UVs,ptin:_UVs,varname:node_5040,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:True|A-4299-OUT,B-8293-UVOUT;n:type:ShaderForge.SFN_Slider,id:915,x:31635,y:33056,ptovrint:False,ptlb:LinesWidth,ptin:_LinesWidth,varname:node_915,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Vector1,id:9079,x:31608,y:32916,varname:node_9079,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:6671,x:31069,y:32602,varname:node_6671,prsc:2,v1:0;n:type:ShaderForge.SFN_RemapRange,id:3975,x:32029,y:32980,varname:node_3975,prsc:2,frmn:0,frmx:1,tomn:1,tomx:0|IN-915-OUT;n:type:ShaderForge.SFN_Slider,id:1050,x:30412,y:32595,ptovrint:False,ptlb:ScaleMultiplier,ptin:_ScaleMultiplier,varname:node_1050,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Tex2d,id:2288,x:35888,y:34591,ptovrint:False,ptlb:NoiseGuide,ptin:_NoiseGuide,varname:node_8952,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:8cc1863f1aa7e2e418da68cae212ffc7,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Step,id:5373,x:36267,y:34611,varname:node_5373,prsc:2|A-5361-OUT,B-9888-OUT;n:type:ShaderForge.SFN_Slider,id:9156,x:35701,y:34783,ptovrint:False,ptlb:DissolveAmount,ptin:_DissolveAmount,varname:node_5116,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.00636333,max:1;n:type:ShaderForge.SFN_RemapRange,id:9888,x:36045,y:34781,varname:node_9888,prsc:2,frmn:0,frmx:1,tomn:-0.1,tomx:1|IN-9156-OUT;n:type:ShaderForge.SFN_Subtract,id:6433,x:35330,y:34512,varname:node_6433,prsc:2|A-8660-XYZ,B-9335-XYZ;n:type:ShaderForge.SFN_ComponentMask,id:4947,x:35506,y:34512,varname:node_4947,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-6433-OUT;n:type:ShaderForge.SFN_FragmentPosition,id:8660,x:35127,y:34428,varname:node_8660,prsc:2;n:type:ShaderForge.SFN_ObjectPosition,id:9335,x:35127,y:34559,varname:node_9335,prsc:2;n:type:ShaderForge.SFN_TexCoord,id:5655,x:35506,y:34674,varname:node_5655,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_SwitchProperty,id:2714,x:35718,y:34591,ptovrint:False,ptlb:DissolveUvCoord,ptin:_DissolveUvCoord,varname:node_3112,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:True|A-4947-OUT,B-5655-UVOUT;n:type:ShaderForge.SFN_RemapRange,id:5361,x:36056,y:34611,varname:node_5361,prsc:2,frmn:0,frmx:1,tomn:0.2,tomx:1|IN-2288-R;n:type:ShaderForge.SFN_Clamp01,id:4524,x:36608,y:34611,varname:node_4524,prsc:2|IN-9598-OUT;n:type:ShaderForge.SFN_OneMinus,id:9598,x:36445,y:34611,varname:node_9598,prsc:2|IN-5373-OUT;n:type:ShaderForge.SFN_RemapRange,id:6506,x:30832,y:32660,varname:node_6506,prsc:2,frmn:0,frmx:1,tomn:1,tomx:0|IN-1050-OUT;proporder:7241-4609-3314-1330-5475-5040-915-1050;pass:END;sub:END;*/

Shader "VaxKun/AnimeShader/Glass" {
    Properties {
        _Color ("Color", Color) = (1,1,1,1)
        _Opacity ("Opacity", Range(0, 1)) = 0.01
        _LinesOpacity ("LinesOpacity", Range(0, 1)) = 1
        _CamPosition ("CamPosition", Vector) = (0,0,0,0)
        _LinesDistance ("LinesDistance", Float ) = 0.1
        [MaterialToggle] _UVs ("UVs", Float ) = 0
        _LinesWidth ("LinesWidth", Range(0, 1)) = 0
        _ScaleMultiplier ("ScaleMultiplier", Range(0, 1)) = 0
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x xboxone ps4 psp2 n3ds wiiu switch 
            #pragma target 3.0
            uniform float4 _Color;
            uniform float _Opacity;
            uniform float _LinesOpacity;
            uniform float4 _CamPosition;
            uniform float _LinesDistance;
            uniform fixed _UVs;
            uniform float _LinesWidth;
            uniform float _ScaleMultiplier;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
////// Lighting:
////// Emissive:
                float3 emissive = _Color.rgb;
                float3 finalColor = emissive;
                float2 node_6612 = (lerp( mul( tangentTransform, (i.posWorld.rgb-_CamPosition.rgb) ).xyz.rgb.rg, i.uv0, _UVs )*2.0+-1.0).rg;
                float node_8526 = ((_ScaleMultiplier*-1.0+1.0)*(abs((node_6612.r+node_6612.g))-_LinesDistance));
                return fixed4(finalColor,saturate((_Opacity+((1.0 - step(frac((pow(saturate(node_8526),(0.0+1.01))*1.0)),(_LinesWidth*-1.0+1.0)))*_LinesOpacity))));
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x xboxone ps4 psp2 n3ds wiiu switch 
            #pragma target 3.0
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    //CustomEditor "ShaderForgeMaterialInspector"
	CustomEditor "AnimeCelShaderGlassEditor"
}
