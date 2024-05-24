using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.Business.Exceptions
{
    public class ImageSizeException : Exception
    {
        public ImageSizeException(string? message) : base(message)
        {
        }
    }
}
