using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace DesignPattern.Creation.Prototype.CourseImageExample
{
    class CourseImage : Cloneable
    {
        public Bitmap Bitmap { get; set; }

        public void Initialise()
        {
            Bitmap = (Bitmap)Image.FromFile("laptop.png");
        }

        public override Cloneable Clone()
        {
            CourseImage clone = (CourseImage)this.MemberwiseClone();
            clone.Bitmap = (Bitmap)Bitmap.Clone();
            return clone as Cloneable;
        }
    }
}
