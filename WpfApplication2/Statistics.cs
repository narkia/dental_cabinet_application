using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Windows.Resources;


namespace WpfApplication2
{
    public partial class MainWindow : Window
    {

        public void busiest_day_of_the_year()
        {
            // MessageBox.Show("am vrut sa afisez un graphic cu cea mai ocupata zi din an.. nush ce am reusit sau ba..");
            const double margin = 10;
            double xmin = margin;
            double xmax = statistics_graph.Width - margin;
            double ymin = margin;
            double ymax = statistics_graph.Height - margin;
            const double step = 20;

            //delete all the graphs which are shown now on canvas
            delete_statistics_graphic();

            // Make the X axis.
            GeometryGroup xaxis_geom = new GeometryGroup();
            xaxis_geom.Children.Add(new LineGeometry(
                new Point(0, ymax), new Point(statistics_graph.Width, ymax)));
            for (double x = xmin + step; x <= statistics_graph.Width - step; x += step)
            {
                xaxis_geom.Children.Add(new LineGeometry(
                    new Point(x, ymax - margin / 2),
                    new Point(x, ymax + margin / 2)));
            }

            System.Windows.Shapes.Path xaxis_path = new System.Windows.Shapes.Path();
            xaxis_path.StrokeThickness = 0.5;
            xaxis_path.Stroke = Brushes.Black;
            xaxis_path.Data = xaxis_geom;

            statistics_graph.Children.Add(xaxis_path);

            // Make the Y ayis.
            GeometryGroup yaxis_geom = new GeometryGroup();
            yaxis_geom.Children.Add(new LineGeometry(
                new Point(xmin, 0), new Point(xmin, statistics_graph.Height)));
            for (double y = step; y <= statistics_graph.Height - step; y += step)
            {
                yaxis_geom.Children.Add(new LineGeometry(
                    new Point(xmin - margin / 2, y),
                    new Point(xmin + margin / 2, y)));
            }

            System.Windows.Shapes.Path yaxis_path = new System.Windows.Shapes.Path();
            yaxis_path.StrokeThickness = 0.5;
            yaxis_path.Stroke = Brushes.Black;
            yaxis_path.Data = yaxis_geom;
            yaxis_path.Tag = "anii";

            statistics_graph.Children.Add(yaxis_path);

            // Make some data sets.
            Brush[] brushes = { Brushes.BurlyWood, Brushes.Green, Brushes.Blue };
            Random rand = new Random();
            for (int data_set = 0; data_set < 3; data_set++)
            {
                //int last_y = rand.Next((int)ymin, (int)ymax);

                PointCollection points = new PointCollection();
                /*for (double x = xmin; x <= xmax; x += step)
                {
                    last_y = rand.Next(last_y - 10, last_y + 10);
                    if (last_y < ymin) last_y = (int)ymin;
                    if (last_y > ymax) last_y = (int)ymax;*/
                for (int x = 15; x < 400; x = x + 4)
                {
                    for (int j = 10; j <= 240; j = j + 6)
                    {
                        points.Add(new Point(x, j));
                    }
                }

                Polyline polyline = new Polyline();
                
                polyline.StrokeThickness = 1;
                polyline.Stroke = brushes[data_set];
                polyline.Points = points;

                statistics_graph.Children.Add(polyline);
                
            }
        }

        //nars

        public void delete_statistics_graphic()
        {
            statistics_graph.Children.Clear();
        }

        //public 

        //nars - exemplu de graphic care mi-a mers in alt proiect mai mic
        //dar trebbuie adaptat la ce imi trebuie mie
        //-->
        public int[] get_vector_years()
        {
            //2 vectors with some values - years and appointments
            int[] years = new int[7];
            years[6] = (int)statistics_graph.ActualWidth - 100;
            years[5] = (int)statistics_graph.ActualWidth - 200;
            years[4] = (int)statistics_graph.ActualWidth - 300;
            years[3] = (int)statistics_graph.ActualWidth - 370;
            years[2] = (int)statistics_graph.ActualWidth - 410;
            years[1] = (int)statistics_graph.ActualWidth - 450;
            years[0] = (int)statistics_graph.ActualWidth - 600;

            return years;
        }
        public int[] get_vector_appointments()
        {
            //2 vectors with some values - years and appointments

            int[] appointments = new int[7];
            appointments[6] = (int)statistics_graph.ActualHeight - 570;
            appointments[5] = (int)statistics_graph.ActualHeight - 150;
            appointments[4] = (int)statistics_graph.ActualHeight - 200;
            appointments[3] = (int)statistics_graph.ActualHeight - 175;
            appointments[2] = (int)statistics_graph.ActualHeight - 350;
            appointments[1] = (int)statistics_graph.ActualHeight - 210;
            appointments[0] = (int)statistics_graph.ActualHeight - 500;

            return appointments;
        }

        public void show_graphic_2D_works_ok(int[] years, int[] appointments)
        {
            const double margin1 = 40;
            const double margin = 15;
            double xmin = margin1;
            double xmax = statistics_graph.Width - margin1;
            double ymin = margin1;
            double ymax = statistics_graph.Height - margin1;
            const double step_x = 40;
            const double step_y = 30;
            const int font_size = 12;
            var i = 0;
            double angle_y = -90;
            double angle_x = 0;

            //delete all the graphs which are shown now on canvas
            delete_statistics_graphic();

            // Make the X axis.
            GeometryGroup xaxis_geom = new GeometryGroup();
            xaxis_geom.Children.Add(new LineGeometry(
                new Point(0, ymax), new Point(statistics_graph.Width, ymax)));
            for (double x = xmin + step_x;
                x <= statistics_graph.Width - step_x; x += step_x)
            {
                i++;

                xaxis_geom.Children.Add(new LineGeometry(
                    new Point(x, ymax - margin / 2),
                    new Point(x, ymax + margin / 2)));
                var punct_mic_x = new Point(x, ymax + margin / 2 + 10);
                var text = (i + 2014).ToString();
                DrawText(statistics_graph, text, punct_mic_x, angle_x, font_size, HorizontalAlignment.Center, VerticalAlignment.Center);

            }

            Path xaxis_path = new Path();
            xaxis_path.StrokeThickness = 1;
            xaxis_path.Stroke = Brushes.Black;
            xaxis_path.Data = xaxis_geom;

            statistics_graph.Children.Add(xaxis_path);

            // Make the Y ayis.
            GeometryGroup yaxis_geom = new GeometryGroup();
            yaxis_geom.Children.Add(new LineGeometry(
                new Point(xmin, 20), new Point(xmin, statistics_graph.Height)));
            for (double y = step_y; y <= statistics_graph.Height - step_y; y += step_y)
            {
                yaxis_geom.Children.Add(new LineGeometry(
                    new Point(xmin - margin / 2, y),
                    new Point(xmin + margin / 2, y)));
                var punct_mic_y = new Point(xmin + margin / 2 - 15, y - 5);
                var text = (ymax - y).ToString();
                DrawText(statistics_graph, text, punct_mic_y, angle_x, font_size, HorizontalAlignment.Center, VerticalAlignment.Center);

            }
            Path yaxis_path = new Path();
            yaxis_path.StrokeThickness = 1;
            yaxis_path.Stroke = Brushes.Black;
            yaxis_path.Data = yaxis_geom;

            statistics_graph.Children.Add(yaxis_path);

            //Make the grid ON on the graphic displayed-->
            for (int ii = 1; ii < 30; ii++)
            {
                GeometryGroup yaxis_geom_grid_ON = new GeometryGroup();
                yaxis_geom_grid_ON.Children.Add(new LineGeometry(
                    new Point(xmin + (20*ii), 40), new Point(xmin + (20 * ii), statistics_graph.Height-40)));
                Path yaxis_path_grid_ON = new Path();
                yaxis_path_grid_ON.StrokeThickness = 0.1;
                yaxis_path_grid_ON.Stroke = Brushes.Black;
                yaxis_path_grid_ON.Data = yaxis_geom_grid_ON;

                statistics_graph.Children.Add(yaxis_path_grid_ON);
            }
            for (int jj = 1; jj < 50; jj++)
            {
                    // Make the X axis.
                GeometryGroup xaxis_geom_grid_ON = new GeometryGroup();
                xaxis_geom_grid_ON.Children.Add(new LineGeometry(
                    new Point(40, ymax - (step_y/2 * jj)), new Point(statistics_graph.Width, ymax - (step_y/2 * jj))));                         
                Path xaxis_path_grid_ON = new Path();
                xaxis_path_grid_ON.StrokeThickness = 0.2;
                xaxis_path_grid_ON.Stroke = Brushes.Black;
                xaxis_path_grid_ON.Data = xaxis_geom_grid_ON;

                statistics_graph.Children.Add(xaxis_path_grid_ON);
            }

            //<--Make the grid ON on the graphic displayed

            

            // Make some data sets.
            Brush[] brushes = { Brushes.Red, Brushes.Green, Brushes.Blue };
            Random rand = new Random();
            for (int data_set = 0; data_set < 3; data_set++)
            {
                int last_y = rand.Next((int)ymin, (int)ymax);

                PointCollection points = new PointCollection();
                for (int x = 0; x <= 6; x += 1)
                {
                    points.Add(new Point(years[x], appointments[x]));
                }

                Polyline polyline = new Polyline();
                polyline.StrokeThickness = 5;
                polyline.Stroke = brushes[data_set];
                polyline.Points = points;

                statistics_graph.Children.Add(polyline);


            }

            var punct_label_y_axis = new Point(statistics_graph.ActualWidth - (statistics_graph.ActualWidth + 5), statistics_graph.ActualHeight / 2);
            var punct_label_x_axis = new Point(statistics_graph.ActualWidth/2, statistics_graph.ActualHeight - 10);
            var font_size_text = 18;


            DrawText(statistics_graph, "nr. of appointments", punct_label_y_axis, angle_y, font_size_text, HorizontalAlignment.Left, VerticalAlignment.Center);
            DrawText(statistics_graph, "years", punct_label_x_axis, angle_x, font_size_text, HorizontalAlignment.Left, VerticalAlignment.Center);

        }

        // Position a label at the indicated point.
        public void DrawText(Canvas can, string text, Point location, double angle, double font_size, HorizontalAlignment halign, VerticalAlignment valign)
        {
            // Make the label.
            Label label = new Label();
            label.Content = text;
            label.FontSize = font_size;
            label.FontWeight = FontWeights.Bold;
            can.Children.Add(label);

            // Rotate if desired.
            if (angle != 0)
                label.LayoutTransform = new RotateTransform(angle);

            // Position the label.
            label.Measure(new Size(double.MaxValue, double.MaxValue));

            double x = location.X;
            if (halign == HorizontalAlignment.Center)
                x -= label.DesiredSize.Width / 2;
            else if (halign == HorizontalAlignment.Right)
                x -= label.DesiredSize.Width;
            Canvas.SetLeft(label, x);

            double y = location.Y;
            if (valign == VerticalAlignment.Center)
                y -= label.DesiredSize.Height / 2;
            else if (valign == VerticalAlignment.Bottom)
                y -= label.DesiredSize.Height;
            Canvas.SetTop(label, y);
        }

        //<--nars

        
        }
}