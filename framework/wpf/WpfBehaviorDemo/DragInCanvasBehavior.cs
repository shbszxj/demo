using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Media;

namespace WpfBehaviorDemo
{
    public class DragInCanvasBehavior : Behavior<UIElement>
    {
        // Keep track of the Canvas where this element is placed.
        private Canvas canvas;

        // Keep track of when the element is being dragged.
        private bool isDragging = false;

        // When the element is clicked, record the exact position
        // where the click is made.
        private Point mouseOffset;

        protected override void OnAttached()
        {
            base.OnAttached();

            this.AssociatedObject.MouseLeftButtonDown += AssociatedObject_MouseLeftButtonDown;
            this.AssociatedObject.MouseMove += AssociatedObject_MouseMove;
            this.AssociatedObject.MouseLeftButtonUp += AssociatedObject_MouseLeftButtonUp;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            this.AssociatedObject.MouseLeftButtonDown -= AssociatedObject_MouseLeftButtonDown;
            this.AssociatedObject.MouseMove -= AssociatedObject_MouseMove;
            this.AssociatedObject.MouseLeftButtonUp -= AssociatedObject_MouseLeftButtonUp;
        }


        private void AssociatedObject_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (canvas == null)
                canvas = (Canvas)VisualTreeHelper.GetParent(this.AssociatedObject);

            isDragging = true;

            mouseOffset = e.GetPosition(AssociatedObject);

            AssociatedObject.CaptureMouse();
        }

        private void AssociatedObject_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (isDragging)
            {
                Point point = e.GetPosition(canvas);

                AssociatedObject.SetValue(Canvas.TopProperty, point.Y - mouseOffset.Y);
                AssociatedObject.SetValue(Canvas.LeftProperty, point.X - mouseOffset.X);
            }
        }

        private void AssociatedObject_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                AssociatedObject.ReleaseMouseCapture();
                isDragging = false;
            }
        }
    }
}
