using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Creation.Prototype.CourseImageExample
{
    class Program : IDesignPatternDemo
    {
        public string Title => "4.4";

        public string Description => "Prototype - Course image example";

        public void Run()
        {
            CourseImage prototype = new CourseImage();
            prototype.Initialise();

            // create image of laptop with blueprint
            CourseImageMaker maker = new CourseImageMaker();
            CourseImage blueprint = maker.CreateImage(prototype, "course_image_1.png");

            // create image of laptop with threads
            CourseImage threads = maker.CreateImage(prototype, "course_image_2.png");

            // create image of laptop with memory cards
            CourseImage memory = maker.CreateImage(prototype, "course_image_3.png");
        }
    }
}
