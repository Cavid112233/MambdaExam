using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.Business.Exceptions
{
    public class ImageContentException : Exception
    {
        public ImageContentException(string? message) : base(message)
        {
        }
    }
}
