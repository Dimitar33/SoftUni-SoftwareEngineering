using System;

namespace P02.Graphic_Editor
{
    public class StartUp
    {
        public static void Main()
        {
            var circle = new Circle();
            var square = new Square();

            var editor = new GraphicEditor();
            editor.DrawShape(circle);
            editor.DrawShape(square);
        }
    }
}
