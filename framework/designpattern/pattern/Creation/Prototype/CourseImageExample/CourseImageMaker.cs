using System.Drawing;

namespace DesignPattern.Creation.Prototype.CourseImageExample
{
    class CourseImageMaker
    {
        public CourseImage CreateImage(CourseImage prototype, string imagePath)
        {
            CourseImage image = (CourseImage)prototype.Clone();

            using (var blend = Image.FromFile(imagePath))
            {
                using (var canvas = Graphics.FromImage(image.Bitmap))
                {
                    canvas.DrawImage(blend, 115, 32);
                }
            }
            return image;
        }
    }
}
