﻿using OpenTK;
using Sledge.Rendering.Scenes;

namespace Sledge.Rendering.Interfaces
{
    public interface IRenderer
    {
        IViewport CreateViewport();
        void DestroyViewport(IViewport viewport);

        Matrix4 SelectionTransform { get; set; }

        Scene CreateScene();
        void SetActiveScene(Scene scene);
        void RemoveScene(Scene scene);

        ITextureStorage Textures { get; }
        IMaterialStorage Materials { get; }
        IModelStorage Models { get; }
    }
}