using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.FrameAndDivider
{
    public class FrameAndDivider
    {
        public string WindowId{ get; set; }
        public double FrameWidth { get; set; }
        public string FrameMaterial { get; set; }
        public double SillDepth { get; set; }

        public FrameAndDivider(string windowId, double frameWidth, string frameMaterial, double sillDepth)
        {
            WindowId = windowId;
            FrameWidth = frameWidth;
            FrameMaterial = frameMaterial;
            SillDepth = sillDepth;
        }
    }
}