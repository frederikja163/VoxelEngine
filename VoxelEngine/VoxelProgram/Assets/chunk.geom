#version 330 core
layout (points) in;
layout (triangle_strip, max_vertices = 24) out;

//uniform mat4 uProjection = mat4(1);
//uniform mat4 uView = mat4(1);

layout(std140) uniform Camera
{
    mat4 uProjection;
    mat4 uView;
    vec3 position;
};

out vec4 fColor;

void main()
{
    fColor = vec4(gl_in[0].gl_Position.xyz / 10f, 1);
    
    gl_Position = uProjection * uView * (gl_in[0].gl_Position + vec4(0.5f, 0.5f, 0.5f, 1f));
    EmitVertex();
    gl_Position = uProjection * uView * (gl_in[0].gl_Position + vec4(0.5f, -0.5f, 0.5f, 1f));
    EmitVertex();
    gl_Position = uProjection * uView * (gl_in[0].gl_Position + vec4(-0.5f, 0.5f, 0.5f, 1f));
    EmitVertex();
    gl_Position = uProjection * uView * (gl_in[0].gl_Position + vec4(-0.5f, -0.5f, 0.5f, 1f));
    EmitVertex();
//    gl_Position = uProjection * uView * (gl_in[0].gl_Position + vec4(-0.5f, -0.5f, -0.5f, 1f));
//    EmitVertex();
//    gl_Position = uProjection * uView * (gl_in[0].gl_Position + vec4(0.5f, -0.5f, 0.5f, 1f));
//    EmitVertex();
//    gl_Position = uProjection * uView * (gl_in[0].gl_Position + vec4(0.5f, -0.5f, -0.5f, 1f));
//    EmitVertex();
//    gl_Position = uProjection * uView * (gl_in[0].gl_Position + vec4(0.5f, 0.5f, 0.5f, 1f));
//    EmitVertex();
//    gl_Position = uProjection * uView * (gl_in[0].gl_Position + vec4(0.5f, 0.5f, -0.5f, 1f));
//    EmitVertex();
//    gl_Position = uProjection * uView * (gl_in[0].gl_Position + vec4(-0.5f, 0.5f, 0.5f, 1f));
//    EmitVertex();
//    gl_Position = uProjection * uView * (gl_in[0].gl_Position + vec4(-0.5f, 0.5f, -0.5f, 1f));
//    EmitVertex();
//    gl_Position = uProjection * uView * (gl_in[0].gl_Position + vec4(-0.5f, -0.5f, -0.5f, 1f));
//    EmitVertex();
//    gl_Position = uProjection * uView * (gl_in[0].gl_Position + vec4(0.5f, -0.5f, -0.5f, 1f));
//    EmitVertex();
//    gl_Position = uProjection * uView * (gl_in[0].gl_Position + vec4(0.5f, 0.5f, -0.5f, 1f));
//    EmitVertex();
    
    EndPrimitive();
}