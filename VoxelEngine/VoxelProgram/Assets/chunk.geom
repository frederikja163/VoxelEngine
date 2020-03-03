#version 330 core
layout (points) in;
layout (triangle_strip, max_vertices = 12) out;

struct Camera{
    mat4 Projection;
    mat4 View;
    vec3 Position;
};
uniform Camera UCamera = Camera(mat4(1), mat4(1), vec3(0));

uniform mat4 UProjection = mat4(1);
uniform mat4 UView = mat4(1);
uniform vec3 UPosition = vec3(0, 0, 0);

out vec4 FColor;

void main()
{
    //FColor = vec4(gl_in[0].gl_Position.xyz / 2, 1);
    FColor = vec4(UCamera.Position, 1);
    //FColor = vec4(1);
    
    vec3 relPosition = UCamera.Position + vec3(0.25) - gl_in[0].gl_Position.xyz;
    float x = sign(relPosition.x) / 2;
    float y = sign(relPosition.y) / 2;
    float z = sign(relPosition.z) / 2;
    
    gl_Position = UCamera.Projection * UCamera.View * (gl_in[0].gl_Position + vec4(x, y, z, 1));
    EmitVertex();
    gl_Position = UCamera.Projection * UCamera.View * (gl_in[0].gl_Position + vec4(-x, y, z, 1));
    EmitVertex();
    gl_Position = UCamera.Projection * UCamera.View * (gl_in[0].gl_Position + vec4(x, y, -z, 1));
    EmitVertex();
    gl_Position = UCamera.Projection * UCamera.View * (gl_in[0].gl_Position + vec4(-x, y, -z, 1));
    EmitVertex();
    EndPrimitive();

    gl_Position = UCamera.Projection * UCamera.View * (gl_in[0].gl_Position + vec4(x, y, z, 1));
    EmitVertex();
    gl_Position = UCamera.Projection * UCamera.View * (gl_in[0].gl_Position + vec4(x, -y, z, 1));
    EmitVertex();
    gl_Position = UCamera.Projection * UCamera.View * (gl_in[0].gl_Position + vec4(x, y, -z, 1));
    EmitVertex();
    gl_Position = UCamera.Projection * UCamera.View * (gl_in[0].gl_Position + vec4(x, -y, -z, 1));
    EmitVertex();
    EndPrimitive();

    gl_Position = UCamera.Projection * UCamera.View * (gl_in[0].gl_Position + vec4(x, y, z, 1));
    EmitVertex();
    gl_Position = UCamera.Projection * UCamera.View * (gl_in[0].gl_Position + vec4(-x, y, z, 1));
    EmitVertex();
    gl_Position = UCamera.Projection * UCamera.View * (gl_in[0].gl_Position + vec4(x, -y, z, 1));
    EmitVertex();
    gl_Position = UCamera.Projection * UCamera.View * (gl_in[0].gl_Position + vec4(-x, -y, z, 1));
    EmitVertex();
    EndPrimitive();
}