using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace SmartEye3
{
    public partial class Form3 : Form
    {
        private DepthPerceiver DP;
        private List<List<Edge>> correspondingEdges;
        private List<Edge3D> Edges;

        private Device device;
        private PresentParameters presentParams;
        private VertexBuffer vertexBuffer;
        private CustomVertex.PositionColored[] Vertices;
        private float rotationAngle;
        
        public Form3(List<Edge3D> edges)
        {
            Edges = edges;

            /*List<AIEnginePhase.MEdge> edges = new List<AIEnginePhase.MEdge>();

            for (int i = 0; i < Edges.Count; i++)
            {
                edges.Add(new AIEnginePhase.MEdge(Edges[i].Point1.X, Edges[i].Point1.Y, Edges[i].Point1.Z, Edges[i].Point2.X, Edges[i].Point2.Y, Edges[i].Point2.Z, String.Concat("e", i)));
            }
            
            AIEnginePhase.mainForm frm = new AIEnginePhase.mainForm();
            frm.Edges = edges;
            frm.ShowDialog();*/

            InitializeComponent();
            InitializeDevice();
            InitializeMatrices();
            InitializeDeviceStates();
            InitializeData(Edges);
            InitializeVertexBuffer();
            rotationAngle = 0;
        }

        private void InitializeDevice()
        {
            presentParams = new PresentParameters();
            presentParams.BackBufferCount = 0;
            presentParams.BackBufferFormat = Format.Unknown;
            presentParams.BackBufferWidth = this.pictureBox.Width;
            presentParams.BackBufferHeight = this.pictureBox.Height;
            presentParams.DeviceWindow = this.pictureBox;
            presentParams.EnableAutoDepthStencil = false;
            presentParams.ForceNoMultiThreadedFlag = false;
            presentParams.FullScreenRefreshRateInHz = 0;
            presentParams.PresentationInterval = PresentInterval.Default;
            presentParams.SwapEffect = SwapEffect.Discard;
            presentParams.Windowed = true;

            device = new Device(0, DeviceType.Hardware, this.pictureBox, CreateFlags.SoftwareVertexProcessing, presentParams);
            device.DeviceReset += new EventHandler(OnDeviceReset);
        }

        private Vector3 FindObjectOrigin()
        {
            int maximumX = int.MinValue;
            int maximumY = int.MinValue;
            int maximumZ = int.MinValue;

            int minimumX = int.MaxValue;
            int minimumY = int.MaxValue;
            int minimumZ = int.MaxValue;

            for (int i = 0; i < Edges.Count; i++)
            {
                if (Edges[i].Point1.X > maximumX)
                {
                    maximumX = Edges[i].Point1.X;
                }

                if (Edges[i].Point2.X > maximumX)
                {
                    maximumX = Edges[i].Point2.X;
                }

                //-----------------------------//

                if (Edges[i].Point1.Y > maximumY)
                {
                    maximumY = Edges[i].Point1.Y;
                }

                if (Edges[i].Point2.Y > maximumY)
                {
                    maximumY = Edges[i].Point2.Y;
                }

                //-----------------------------//

                if (Edges[i].Point1.Z > maximumZ)
                {
                    maximumZ = Edges[i].Point1.Z;
                }

                if (Edges[i].Point2.Z > maximumZ)
                {
                    maximumZ = Edges[i].Point2.Z;
                }

                //--------------------------------------------------------------//

                if (Edges[i].Point1.X < minimumX)
                {
                    minimumX = Edges[i].Point1.X;
                }

                if (Edges[i].Point2.X < minimumX)
                {
                    minimumX = Edges[i].Point2.X;
                }

                //-----------------------------//

                if (Edges[i].Point1.Y < minimumY)
                {
                    minimumY = Edges[i].Point1.Y;
                }

                if (Edges[i].Point2.Y < minimumY)
                {
                    minimumY = Edges[i].Point2.Y;
                }

                //-----------------------------//

                if (Edges[i].Point1.Z < minimumZ)
                {
                    minimumZ = Edges[i].Point1.Z;
                }

                if (Edges[i].Point2.Z < minimumZ)
                {
                    minimumZ = Edges[i].Point2.Z;
                }
            }

            return new Vector3((float)((minimumX + maximumX) / 2), (float)((minimumY + maximumY) / 2), (float)((minimumZ + maximumZ) / 2));
        }

        private void InitializeMatrices()
        {
            Vector3 eyeVector = new Vector3(0, 0, -500);
            Vector3 lookatVector = new Vector3(0, 0, 0);
            Vector3 upVector = new Vector3(0, -1, 0);

            device.Transform.View = Matrix.LookAtLH(eyeVector, lookatVector, upVector);

            //------------------------------------------------------------------------------------//

            float fieldOfView = (float)(Math.PI / 4);
            float aspectRatio = (float)(this.pictureBox.Width / this.pictureBox.Height);
            device.Transform.Projection = Matrix.PerspectiveFovLH(fieldOfView, aspectRatio, 1, 1000);

            //------------------------------------------------------------------------------------//

            device.Transform.World = Matrix.Identity;

            //------------------------------------------------------------------------------------//

            Viewport viewPort = new Viewport();
            viewPort.X = 0;
            viewPort.Y = 0;
            viewPort.Width = this.pictureBox.Width;
            viewPort.Height = this.pictureBox.Height;
            viewPort.MinZ = 0;
            viewPort.MaxZ = 1;
            device.Viewport = viewPort;
        }

        private void InitializeDeviceStates()
        {
            device.RenderState.CullMode = Cull.CounterClockwise;
            device.RenderState.Lighting = false;
        }

        private void InitializeData()
        {
            Vertices = new CustomVertex.PositionColored[16];

            Vertices[0] = new CustomVertex.PositionColored((float)-2, (float)2, (float)4, Color.Green.ToArgb());
            Vertices[1] = new CustomVertex.PositionColored((float)2, (float)2, (float)4, Color.Green.ToArgb());

            Vertices[2] = new CustomVertex.PositionColored((float)-2, (float)2, (float)4, Color.Green.ToArgb());
            Vertices[3] = new CustomVertex.PositionColored((float)-2, (float)2, (float)0, Color.Green.ToArgb());

            Vertices[4] = new CustomVertex.PositionColored((float)-2, (float)2, (float)0, Color.Green.ToArgb());
            Vertices[5] = new CustomVertex.PositionColored((float)2, (float)2, (float)0, Color.Green.ToArgb());

            Vertices[6] = new CustomVertex.PositionColored((float)2, (float)2, (float)0, Color.Green.ToArgb());
            Vertices[7] = new CustomVertex.PositionColored((float)2, (float)2, (float)4, Color.Green.ToArgb());

            Vertices[8] = new CustomVertex.PositionColored((float)2, (float)2, (float)0, Color.Green.ToArgb());
            Vertices[9] = new CustomVertex.PositionColored((float)2, (float)0, (float)0, Color.Green.ToArgb());

            Vertices[10] = new CustomVertex.PositionColored((float)-2, (float)2, (float)0, Color.Green.ToArgb());
            Vertices[11] = new CustomVertex.PositionColored((float)-2, (float)0, (float)0, Color.Green.ToArgb());

            Vertices[12] = new CustomVertex.PositionColored((float)-2, (float)2, (float)4, Color.Green.ToArgb());
            Vertices[13] = new CustomVertex.PositionColored((float)-2, (float)0, (float)4, Color.Green.ToArgb());

            Vertices[14] = new CustomVertex.PositionColored((float)2, (float)2, (float)4, Color.Green.ToArgb());
            Vertices[15] = new CustomVertex.PositionColored((float)2, (float)0, (float)4, Color.Green.ToArgb());
        }

        private void InitializeData(List<Edge3D> edges)
        {
            Vector3 originVector = FindObjectOrigin();
            Vertices = new CustomVertex.PositionColored[edges.Count * 2];

            for (int i = 0; i < edges.Count; i++)
            {
                Vertices[i * 2] = new CustomVertex.PositionColored((float)edges[i].Point1.X - originVector.X, (float)edges[i].Point1.Y - originVector.Y, (float)edges[i].Point1.Z - originVector.Z, Color.Green.ToArgb());
                Vertices[i * 2 + 1] = new CustomVertex.PositionColored((float)edges[i].Point2.X - originVector.X, (float)edges[i].Point2.Y - originVector.Y, (float)edges[i].Point2.Z - originVector.Z, Color.Green.ToArgb());
            }
        }

        private void InitializeVertexBuffer()
        {
            Type type = typeof(CustomVertex.PositionColored);
            VertexFormats vertexFormat = CustomVertex.PositionColored.Format;
            Usage usage = Usage.WriteOnly | Usage.SoftwareProcessing;
            vertexBuffer = new VertexBuffer(type, Vertices.Length, device, usage, vertexFormat, Pool.Managed);
            vertexBuffer.SetData(Vertices, 0, LockFlags.None);
        }

        public void HeartBeat()
        {
            int result;

            if (device.CheckCooperativeLevel(out result))
            {
                try
                {
                    Render();
                }
                catch (DeviceLostException)
                {
                    device.CheckCooperativeLevel(out result);
                }
                catch (DeviceNotResetException)
                {
                    device.CheckCooperativeLevel(out result);
                }
            }

            if (result == (int)ResultCode.DeviceLost)
            {
                Thread.Sleep(500);
            }
            else if (result == (int)ResultCode.DeviceNotReset)
            {
                device.Reset(presentParams);
            }
        }

        private void Render()
        {
            device.Clear(ClearFlags.Target, Color.White, 1, 0);
            device.BeginScene();

            SetWorldMatrix();
            device.SetStreamSource(0, vertexBuffer, 0);
            device.VertexFormat = CustomVertex.PositionColored.Format;
            device.DrawPrimitives(PrimitiveType.LineList, 0, Vertices.Length / 2);

            device.EndScene();
            device.Present();
        }

        private void SetWorldMatrix()
        {
            Matrix rotationMatrix = Matrix.RotationY(rotationAngle);
            device.Transform.World = rotationMatrix;

            rotationAngle = (float)((rotationAngle + 0.05) % (2 * Math.PI));
        }

        private void OnDeviceReset(object sender, EventArgs e)
        {
            InitializeMatrices();
            InitializeDeviceStates();
        }
    }
}
