using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Points
{
    /// <summary>
    /// Логика взаимодействия для Cube.xaml
    /// </summary>
    public partial class Cube : Window
    {
        Canvas canvas = new Canvas();
        Rectangle rectangle = new Rectangle();

        struct xyz
        {
            public float x;
            public float y;
            public float z;
        }
        struct triangle
        {
            public xyz one;
            public xyz two;
            public xyz three;
        }
        List<triangle> mesh = new List<triangle>();
        void AddTriangleToMesh(xyz vertex1, xyz vertex2, xyz vertex3)
        {
            triangle newTriangle = new triangle();
            newTriangle.one = vertex1;
            newTriangle.two = vertex2;
            newTriangle.three = vertex3;

            mesh.Add(newTriangle);
        }
        
        float fNear = 0.1f;
        float fFar = 1000.0f;
        static float fFov = 90.0f;
        float fAspectRatio = 1.0f;
        float fFovRad = (float)Convert.ToDouble(1.0f / Math.Tan(fFov * 0.5f / 180.0f * Math.PI));
             
        struct Mat4x4
        {
            public float[,] m;
            public Mat4x4(int size)
            {
                m = new float[size,size];
            }
        }
        Mat4x4 mat4x4 = new Mat4x4(4);
        private void fillmat4x4()
        { 
            mat4x4.m[0, 0] = fAspectRatio * fFovRad;
            mat4x4.m[1, 1] = fFovRad;
            mat4x4.m[2, 2] = fFar / (fFar - fNear);
            mat4x4.m[3, 2] = (-fFar * fNear) / (fFar - fNear);
            mat4x4.m[2, 3] = 1.0f;
            mat4x4.m[3, 3] = 0.0f;
        }

        private void MultiplyMatrix(xyz i, xyz o, Mat4x4 m)
        {
            o.x = i.x * m.m[0, 0] + i.y * m.m[1, 0] + i.z * m.m[2, 0] + m.m[3, 0];
            o.y = i.x * m.m[0, 1] + i.y * m.m[1, 1] + i.z * m.m[2, 1] + m.m[3, 1];
            o.z = i.x * m.m[0, 2] + i.y * m.m[1, 2] + i.z * m.m[2, 2] + m.m[3, 2];
            float w = i.x * m.m[0, 3] + i.y * m.m[1, 3] + i.z * m.m[2, 3] + m.m[3, 3];
            if (w != 0.0f)
            {
                o.x /= w;
                o.y /= w;
                o.z/= w;
            }
        }
        private void darwTriangles()
        {
            foreach (triangle tri in mesh)
            {
                triangle triprojected = tri;
                triangle triTranslanted = tri;

                //triTranslanted.one.z = tri.one.z + 3.0f;
                //triTranslanted.two.z = tri.two.z + 3.0f;
                //triTranslanted.three.z = tri.three.z + 3.0f;

                MultiplyMatrix(triTranslanted.one,triprojected.one,mat4x4);
                MultiplyMatrix(triTranslanted.two, triprojected.two, mat4x4);
                MultiplyMatrix(triTranslanted.three, triprojected.three, mat4x4);
                //scsle
                //
                triprojected.one.x += 1.0f; triprojected.one.y += 1.0f;
                triprojected.two.x += 1.0f; triprojected.two.y += 1.0f;
                triprojected.three.x += 1.0f; triprojected.three.y += 1.0f;

                triprojected.one.x *= 0.5f * 500.0f;
                triprojected.one.y *= 0.5f * 500.0f;
                triprojected.two.x *= 0.5f * 500.0f;
                triprojected.two.y *= 0.5f * 500.0f;
                triprojected.three.x *= 0.5f * 500.0f;
                triprojected.three.y *= 0.5f * 500.0f;

                DrawTriangle(triprojected.one.x, triprojected.one.y,
                    triprojected.two.x, triprojected.two.y,
                    triprojected.three.x, triprojected.three.y);
            }
            
        }
        public void DrawTriangle(float x1, float y1, float x2, float y2, float x3, float y3)
        {
            drawLine(x1,y1,x2,y2);
            drawLine(x2,y2,x3,y3);
            drawLine(x3,y3,x1,y2);           
        }
        public void drawLine(float x1, float y1, float x2, float y2)
        {
            Line myLine = new Line();
            myLine.Stroke = System.Windows.Media.Brushes.Red;
            myLine.X1 = x1;
            myLine.X2 = x2;
            myLine.Y1 = y1;
            myLine.Y2 = y2;
            myLine.HorizontalAlignment = HorizontalAlignment.Left;
            myLine.VerticalAlignment = VerticalAlignment.Center;
            myLine.StrokeThickness = 2;
            canvas.Children.Add(myLine);
        }
        public Cube() 
        {
            InitializeComponent();
            DrawOnCanvas();
            DrawCube();
            fillmat4x4();
            CoordinatesMeshCube();
            darwTriangles();
            //drawLine(250.0f, 250.0f, 251.0f, 251.0f);
        }
        private void DrawCube()
        {
            Rectangle one = new Rectangle();
        }

        private void DrawOnCanvas()
        {
            // Создаем элемент Canvas
            canvas.Width = 500;
            canvas.Height = 500;

            // Создаем прямоугольник и добавляем его на Canvas

            rectangle.Width = 500;
            rectangle.Height = 500;
            rectangle.Fill = Brushes.White;
            Canvas.SetLeft(rectangle, 0);
            Canvas.SetTop(rectangle, 0);
            canvas.Children.Add(rectangle);
            this.Content = canvas;
        }

        private void CoordinatesMeshCube()
        {
            // one row in the video, one triangle
            // South
            xyz v1 = new xyz { x = 0.0f, y = 0.0f, z = 0.0f };
            xyz v2 = new xyz { x = 0.0f, y = 1.0f, z = 0.0f };
            xyz v3 = new xyz { x = 1.0f, y = 1.0f, z = 0.0f };
            AddTriangleToMesh(v1, v2, v3);
            v1 = new xyz { x = 0.0f, y = 0.0f, z = 0.0f };
            v2 = new xyz { x = 1.0f, y = 1.0f, z = 0.0f };
            v3 = new xyz { x = 1.0f, y = 0.0f, z = 0.0f };
            AddTriangleToMesh(v1, v2, v3);

            //East
            v1 = new xyz { x = 1.0f, y = 0.0f, z = 0.0f };
            v2 = new xyz { x = 1.0f, y = 1.0f, z = 0.0f };
            v3 = new xyz { x = 1.0f, y = 1.0f, z = 1.0f };
            AddTriangleToMesh(v1, v2, v3);
            v1 = new xyz { x = 1.0f, y = 0.0f, z = 0.0f };
            v2 = new xyz { x = 1.0f, y = 1.0f, z = 1.0f };
            v3 = new xyz { x = 1.0f, y = 0.0f, z = 1.0f };
            AddTriangleToMesh(v1, v2, v3);

            //North
            v1 = new xyz { x = 1.0f, y = 0.0f, z = 1.0f };
            v2 = new xyz { x = 1.0f, y = 1.0f, z = 1.0f };
            v3 = new xyz { x = 0.0f, y = 1.0f, z = 1.0f };
            AddTriangleToMesh(v1, v2, v3);
            v1 = new xyz { x = 1.0f, y = 0.0f, z = 1.0f };
            v2 = new xyz { x = 0.0f, y = 1.0f, z = 1.0f };
            v3 = new xyz { x = 0.0f, y = 0.0f, z = 1.0f };
            AddTriangleToMesh(v1, v2, v3);

            //West
            v1 = new xyz { x = 0.0f, y = 0.0f, z = 1.0f };
            v2 = new xyz { x = 0.0f, y = 1.0f, z = 1.0f };
            v3 = new xyz { x = 0.0f, y = 1.0f, z = 0.0f };
            AddTriangleToMesh(v1, v2, v3);
            v1 = new xyz { x = 0.0f, y = 0.0f, z = 1.0f };
            v2 = new xyz { x = 0.0f, y = 1.0f, z = 0.0f };
            v3 = new xyz { x = 0.0f, y = 0.0f, z = 0.0f };
            AddTriangleToMesh(v1, v2, v3);

            //Top
            v1 = new xyz { x = 0.0f, y = 1.0f, z = 0.0f };
            v2 = new xyz { x = 0.0f, y = 1.0f, z = 1.0f };
            v3 = new xyz { x = 1.0f, y = 1.0f, z = 1.0f };
            AddTriangleToMesh(v1, v2, v3);
            v1 = new xyz { x = 0.0f, y = 1.0f, z = 0.0f };
            v2 = new xyz { x = 1.0f, y = 1.0f, z = 1.0f };
            v3 = new xyz { x = 1.0f, y = 1.0f, z = 0.0f };
            AddTriangleToMesh(v1, v2, v3);

            //Bottom
            v1 = new xyz { x = 1.0f, y = 0.0f, z = 1.0f };
            v2 = new xyz { x = 0.0f, y = 0.0f, z = 1.0f };
            v3 = new xyz { x = 0.0f, y = 0.0f, z = 0.0f };
            AddTriangleToMesh(v1, v2, v3);
            v1 = new xyz { x = 1.0f, y = 0.0f, z = 1.0f };
            v2 = new xyz { x = 0.0f, y = 0.0f, z = 0.0f };
            v3 = new xyz { x = 1.0f, y = 0.0f, z = 0.0f };
            AddTriangleToMesh(v1, v2, v3);

        }
    }
}
