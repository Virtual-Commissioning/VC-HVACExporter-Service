using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HVACExporter.Models.Zone
{
    public class FrameAndDivider
    {
        public string Id { get; set; }
        public double FrameWidth { get; set; }
        public string FrameMaterial { get; set; }
        public double SillDepth { get; set; }

        public FrameAndDivider(string id, double frameWidth, string frameMaterial, double sillDepth)
        {
            Id = id;
            FrameWidth = frameWidth;
            FrameMaterial = frameMaterial;
            SillDepth = sillDepth;
        }
    }
}