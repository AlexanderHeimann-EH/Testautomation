/// <description>A simple color blending shader for WPF.</description>
/// <target>WPF</target>
/// <profile>ps_2_0</profile>

//-----------------------------------------------------------------------------
// Constants
//-----------------------------------------------------------------------------

/// <summary>The brightness offset.</summary>
/// <type>Color</type>
/// <defaultValue>0,0,0,0</defaultValue>
float4 BlendColor : register(c0);

//-----------------------------------------------------------------------------
// Samplers
//-----------------------------------------------------------------------------

/// <summary>The implicit input sampler passed into the pixel shader by WPF.</summary>
/// <samplingMode>Auto</samplingMode>
sampler2D Input : register(s0);

//-----------------------------------------------------------------------------
// Pixel Shader
//-----------------------------------------------------------------------------

float4 main(float2 uv : TEXCOORD) : COLOR
{
    float4 color = tex2D(Input, uv);
	color = BlendColor * color.a;
	return color;
	/*
	if(color.r == 255 && color.g == 255 && color.b == 255)
	{
		return BlendColor;
	}
	else
	{
		return BlendColor * BlendColor.a + tex2D(Input, uv) * (1.0 - BlendColor.a);
	}
	*/
}
