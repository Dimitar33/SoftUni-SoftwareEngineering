﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Stream_Progress
{
    public class StreamProgressInfo
    {
        private IStream file;
       
        // If we want to stream a music file, we can't
      
        public StreamProgressInfo(IStream file)
        {
            this.file = file;
        }


        public int CalculateCurrentPercent()
        {
            return (file.BytesSent * 100) / this.file.Length;
        }
    }
}
