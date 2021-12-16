using Artillery.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Artillery.DataProcessor.ExportDto
{
    public class ExportShellsJsonDto
    {
        public double ShellWeight { get; set; }
        public string Caliber { get; set; }
        public List<ExportGundsJsonDto> Guns { get; set; }
    }
}
