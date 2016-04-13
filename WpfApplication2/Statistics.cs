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
        public int Appointment_func_extract_day_of_appointment(string line)
        {
            // string start_time = "";
            int day_appoint = 0;
            int i = 0, j = 0;// k = 0;
            char[] a = line.ToCharArray();
            int[] b = new int[8];

            while (i >= 0)
            {
                if (a[i] == '|')
                {
                    j++;
                }

                if (j == 1)
                {
                    b[0] = Convert.ToInt16(a[i + 1].ToString());
                    b[1] = Convert.ToInt16(a[i + 2].ToString());
                    b[2] = Convert.ToInt16(a[i + 4].ToString());
                    b[3] = Convert.ToInt16(a[i + 5].ToString());
                    b[4] = Convert.ToInt16(a[i + 7].ToString());
                    b[5] = Convert.ToInt16(a[i + 8].ToString());
                    b[6] = Convert.ToInt16(a[i + 9].ToString());
                    b[7] = Convert.ToInt16(a[i + 10].ToString());
                    j = -1;
                    break;
                }

                i++;
            }

            day_appoint = b[0] * 10 + b[1];

            return day_appoint;
        }

        public int Appointment_func_extract_month_of_appointment(string line)
        {
            // string start_time = "";
            int month_appoint = 0;
            int i = 0, j = 0;// k = 0;
            char[] a = line.ToCharArray();
            int[] b = new int[8];

            while (j >= 0)
            {
                if (a[i] == '|')
                {
                    j++;
                }

                if (j == 1)
                {
                    b[0] = Convert.ToInt16(a[i + 1].ToString());
                    b[1] = Convert.ToInt16(a[i + 2].ToString());
                    b[2] = Convert.ToInt16(a[i + 4].ToString());
                    b[3] = Convert.ToInt16(a[i + 5].ToString());
                    b[4] = Convert.ToInt16(a[i + 7].ToString());
                    b[5] = Convert.ToInt16(a[i + 8].ToString());
                    b[6] = Convert.ToInt16(a[i + 9].ToString());
                    b[7] = Convert.ToInt16(a[i + 10].ToString());
                    j = -1;
                    break;
                }

                i++;
            }

            month_appoint = b[2] * 10 + b[3];

            return month_appoint;
        }
        public int Appointment_func_extract_year_of_appointment(string line)
        {
            // string start_time = "";
            int year_appoint = 0;
            int i = 0, j = 0;// k = 0;
            char[] a = line.ToCharArray();
            int[] b = new int[8];

            while (j >= 0)
            {
                if (a[i] == '|')
                {
                    j++;
                }

                if (j == 1)
                {
                    b[0] = Convert.ToInt16( a[i + 1].ToString());
                    b[1] = Convert.ToInt16(a[i + 2].ToString());
                    b[2] = Convert.ToInt16(a[i + 4].ToString());
                    b[3] = Convert.ToInt16(a[i + 5].ToString());
                    b[4] = Convert.ToInt16(a[i + 7].ToString());
                    b[5] = Convert.ToInt16(a[i + 8].ToString());
                    b[6] = Convert.ToInt16(a[i + 9].ToString());
                    b[7] = Convert.ToInt16(a[i + 10].ToString());
                    j = -1;
                    break;
                }

                i++;
            }
            year_appoint = b[4] * 1000 + b[5] * 100 + b[6] * 10 + b[7];

            return year_appoint;
        }
        public DateTime[] Appointment_func_extract_array_dates_of_appointments()
        {
            int res = 0;
            int i = 0;
            DateTime[] vector_dates_appoints = new DateTime[2000];

            //string path1 = @"C:\Users\ScirlatacheN\Documents\Visual Studio 2015\Projects\WpfApplication2\WpfApplication2\MyAppointmentList.txt";
            string path1 = "MyAppointmentList.txt";
            System.IO.StreamReader file = new System.IO.StreamReader(path1);
            string line = "";
            int j = 0;

            while ((line = file.ReadLine()) != null)
            {               
                if (j > 2)
                {
                    var day_appoint = Appointment_func_extract_day_of_appointment(line);
                    var month_appoint = Appointment_func_extract_month_of_appointment(line);
                    var years_appoint = Appointment_func_extract_year_of_appointment(line);
                    if ((years_appoint >= DateTime.Now.Year - 5) && (years_appoint <= DateTime.Now.Year + 5))
                    {
                        DateTime DefaultDate1 = new DateTime(years_appoint, month_appoint, day_appoint);
                        //var data_colectata = DefaultDate1.Date;
                        vector_dates_appoints[i] = DefaultDate1.Date;
                    }                    
                    i++;
                }

                j++;
            }
            file.Close();

            

            return vector_dates_appoints;
        }
        public int[] get_vector_years()
        {
            //2 vectors with some values - years and appointments
            int[] years = new int[11]{0,0,0,0,0,0,0,0,0,0,0};
                  
            years[0] = DateTime.Now.Year - 5;
            years[1] = DateTime.Now.Year - 4;
            years[2] = DateTime.Now.Year - 3;
            years[3] = DateTime.Now.Year - 2;
            years[4] = DateTime.Now.Year - 1;
            years[5] = DateTime.Now.Year;
            years[6] = DateTime.Now.Year + 1;
            years[7] = DateTime.Now.Year + 2;
            years[8] = DateTime.Now.Year + 3;
            years[9] = DateTime.Now.Year + 4;
            years[10] = DateTime.Now.Year + 5;
                            
           
            

            return years;
        }
        public int[] get_vector_appointments()
        {
            //2 vectors with some values - years and appointments

            int[] appointments = new int[11]{0,0,0,0,0,0,0,0,0,0,0};
            var dates_array = Appointment_func_extract_array_dates_of_appointments();
            var years = get_vector_years();
            int jj = 0;

            for (jj =0; jj <= 10; jj++)
            {
                for (int ii = 0; ii < dates_array.Length; ii++)
			    {		
                    if ((dates_array[ii].Year == years[jj]) && (dates_array[ii].Year != 0001 ) )
                    {
                        appointments[jj]++;
                    }

                }
                
            }


            return appointments;
        }
        public int[] get_vector_appointments_per_month()
        {
            //2 vectors with some values - years and appointments

            int[] appointments = new int[12] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            var dates_array = Appointment_func_extract_array_dates_of_appointments();
            var years = get_vector_years();
            var months = new int[12] {1,2,3,4,5,6,7,8,9,10,11,12};
            int jj = 0;

            for (jj = 0; jj <= 11; jj++)
            {
                for (int ii = 0; ii < dates_array.Length; ii++)
                {
                    if ((dates_array[ii].Month == months[jj]) && (dates_array[ii].Year != 0001))
                    {
                        appointments[jj]++;
                    }

                }

            }


            return appointments;
        }
        public int[,] get_matrix_appointments_per_month()
        {
            int[,] appointments = new int[11,12] {{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
                                                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
                                                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 
                                                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }};

            var dates_array = Appointment_func_extract_array_dates_of_appointments();
            var years = get_vector_years();
            var months = new int[12] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            int jj = 0;
            int kk = 5;
            var array_length = dates_array.Length; 

            while(jj <= 10)
            {
                for (int ii = 0; ii < dates_array.Length; ii++)
                {
                    if ((dates_array[ii].Year >= DateTime.Now.Year - 5) && (dates_array[ii].Year <= DateTime.Now.Year + 5))
                    {
                        if (dates_array[ii].Year == (DateTime.Now.Year - kk))
                        {
                            var month_temp = dates_array[ii].Month;
                            appointments[jj, month_temp - 1]++;
                            //var dat = Convert.ToDateTime(1001);
                            //dates_array[ii] = (Int32)dat;
                        }                       
                    }
                }
                jj++;
                kk--;
            }
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
            var years_position_on_graph = new double[11]{0,0,0,0,0,0,0,0,0,0,0};
            //delete all the graphs which are shown now on canvas
            delete_statistics_graphic();

            // Make the X axis.
            GeometryGroup xaxis_geom = new GeometryGroup();
            xaxis_geom.Children.Add(new LineGeometry(
                new Point(0, ymax), new Point(statistics_graph.Width, ymax)));
            for (double x = xmin + step_x;
                x <= statistics_graph.Width - step_x; x += step_x)
            {

                xaxis_geom.Children.Add(new LineGeometry(
                    new Point(x, ymax - margin / 2),
                    new Point(x, ymax + margin / 2)));
                var punct_mic_x = new Point(x, ymax + margin / 2 + 10);
                var text = (i + years[0]).ToString();
                DrawText(statistics_graph, text, punct_mic_x, angle_x, font_size, HorizontalAlignment.Center, VerticalAlignment.Center);

                if (i < 11)
                {
                    years_position_on_graph[i] = x;//aici retin pozitia anilor pe graficul afisat
                }
                i++;
            }

            Path xaxis_path = new Path();
            xaxis_path.StrokeThickness = 1;
            xaxis_path.Stroke = Brushes.Black;
            xaxis_path.Data = xaxis_geom;

            statistics_graph.Children.Add(xaxis_path);

            // Make the Y ayis. - l-am pus la final pebtru ca vreau sa fie scalat pentru appointments
            GeometryGroup yaxis_geom = new GeometryGroup();
            yaxis_geom.Children.Add(new LineGeometry(new Point(xmin, 20), new Point(xmin, statistics_graph.Height)));
            for (double y = step_y; y <= statistics_graph.Height - step_y; y += step_y)
            {
                yaxis_geom.Children.Add(new LineGeometry(
                    new Point(xmin - margin / 2, y - 4),
                    new Point(xmin + margin / 2, y - 4)));
                var punct_mic_y = new Point(xmin + margin / 2 - 15, y - 5);
                var text = (ymax - y + 4).ToString();
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
            int distanta = 0;
            PointCollection points = new PointCollection();
            points.Add(new Point(years_position_on_graph[0], ymax));
            for (int x = 0; x <= 10; x += 1)
            {
                points.Add(new Point(years_position_on_graph[x],ymax - appointments[x]));
                distanta = distanta + 30;
            }
            points.Add(new Point(years_position_on_graph[10], ymax));

            Polyline polyline = new Polyline();
            polyline.StrokeThickness = 3;
            polyline.Stroke = brushes[0];
            polyline.Points = points;

            statistics_graph.Children.Add(polyline);//aici e o problema ca nu imi vede punctele pe care le vreau -- ani / appointments
                      
            var punct_label_y_axis = new Point(statistics_graph.ActualWidth - (statistics_graph.ActualWidth + 5), statistics_graph.ActualHeight / 2);
            var punct_label_x_axis = new Point(statistics_graph.ActualWidth/2, statistics_graph.ActualHeight - 10);
            var font_size_text = 18;
            DrawText(statistics_graph, "nr. of appointments", punct_label_y_axis, angle_y, font_size_text, HorizontalAlignment.Left, VerticalAlignment.Center);
            DrawText(statistics_graph, "years", punct_label_x_axis, angle_x, font_size_text, HorizontalAlignment.Left, VerticalAlignment.Center);


            

        }
        public void show_graphic_2D_works_ok_matrix(int[] years, int[,] appointments)
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
            var years_position_on_graph = new double[11] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            //delete all the graphs which are shown now on canvas
            delete_statistics_graphic();

            // Make the X axis.
            GeometryGroup xaxis_geom = new GeometryGroup();
            xaxis_geom.Children.Add(new LineGeometry(
                new Point(0, ymax), new Point(statistics_graph.Width, ymax)));
            for (double x = xmin + step_x;
                x <= statistics_graph.Width - step_x; x += step_x)
            {

                xaxis_geom.Children.Add(new LineGeometry(
                    new Point(x, ymax - margin / 2),
                    new Point(x, ymax + margin / 2)));
                var punct_mic_x = new Point(x, ymax + margin / 2 + 10);
                var text = (i + years[0]).ToString();
                DrawText(statistics_graph, text, punct_mic_x, angle_x, font_size, HorizontalAlignment.Center, VerticalAlignment.Center);

                if (i < 11)
                {
                    years_position_on_graph[i] = x;//aici retin pozitia anilor pe graficul afisat
                }
                i++;

            }

            Path xaxis_path = new Path();
            xaxis_path.StrokeThickness = 1;
            xaxis_path.Stroke = Brushes.Black;
            xaxis_path.Data = xaxis_geom;

            statistics_graph.Children.Add(xaxis_path);

            // Make the Y ayis. - l-am pus la final pebtru ca vreau sa fie scalat pentru appointments
            GeometryGroup yaxis_geom = new GeometryGroup();
            yaxis_geom.Children.Add(new LineGeometry(new Point(xmin, 20), new Point(xmin, statistics_graph.Height)));
            for (double y = step_y; y <= statistics_graph.Height - step_y; y += step_y)
            {
                yaxis_geom.Children.Add(new LineGeometry(
                    new Point(xmin - margin / 2, y - 4),
                    new Point(xmin + margin / 2, y - 4)));
                var punct_mic_y = new Point(xmin + margin / 2 - 15, y - 5);
                var text = (ymax - y + 4).ToString();
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
                    new Point(xmin + (20 * ii), 40), new Point(xmin + (20 * ii), statistics_graph.Height - 40)));
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
                    new Point(40, ymax - (step_y / 2 * jj)), new Point(statistics_graph.Width, ymax - (step_y / 2 * jj))));
                Path xaxis_path_grid_ON = new Path();
                xaxis_path_grid_ON.StrokeThickness = 0.2;
                xaxis_path_grid_ON.Stroke = Brushes.Black;
                xaxis_path_grid_ON.Data = xaxis_geom_grid_ON;

                statistics_graph.Children.Add(xaxis_path_grid_ON);
            }

            //<--Make the grid ON on the graphic displayed



            // Make some data sets.
            Brush[] brushes = { Brushes.Red, Brushes.Green, Brushes.Blue, 
                                  Brushes.Yellow, Brushes.Magenta, Brushes.HotPink, 
                                  Brushes.Khaki, Brushes.MidnightBlue, Brushes.CornflowerBlue, 
                                  Brushes.Coral, Brushes.Chocolate};
            Random rand = new Random();
            int distanta = 0;
            PointCollection points = new PointCollection();
            points.Add(new Point(years_position_on_graph[0], ymax));
            for (int x = 0; x <= 10; x += 1)
            {
                for (int ii = 0; ii < 12; ii++)
                {
			        points.Add(new Point(years_position_on_graph[x], ymax - appointments[0,ii]));
                    distanta = distanta + 30;
                }
            }
            points.Add(new Point(years_position_on_graph[10], ymax));

            Polyline polyline = new Polyline();
            polyline.StrokeThickness = 3;
            polyline.Stroke = brushes[0];
            polyline.Points = points;

            statistics_graph.Children.Add(polyline);//aici e o problema ca nu imi vede punctele pe care le vreau -- ani / appointments

            ///////////////////////////////////
            for (int x = 0; x <= 10; x += 1)
            {
                for (int ii = 0; ii < 12; ii++)
                {
                    points.Add(new Point(years_position_on_graph[x], ymax - appointments[1, ii]));
                    distanta = distanta + 30;
                }
            }
            points.Add(new Point(years_position_on_graph[10], ymax));

            Polyline polyline1 = new Polyline();
            polyline.StrokeThickness = 3;
            polyline.Stroke = brushes[1];
            polyline.Points = points;

            statistics_graph.Children.Add(polyline1);//aici e o problema ca nu imi vede punctele pe care le vreau -- ani / appointments

            ////////////////////////////////////////
            for (int x = 0; x <= 10; x += 1)
            {
                for (int ii = 0; ii < 12; ii++)
                {
                    points.Add(new Point(years_position_on_graph[x], ymax - appointments[2, ii]));
                    distanta = distanta + 30;
                }
            }
            points.Add(new Point(years_position_on_graph[10], ymax));

            Polyline polyline2 = new Polyline();
            polyline2.StrokeThickness = 3;
            polyline2.Stroke = brushes[2];
            polyline2.Points = points;

            statistics_graph.Children.Add(polyline2);//aici e o problema ca nu imi vede punctele pe care le vreau -- ani / appointments
            ////////////////////////////////////////////
            for (int x = 0; x <= 10; x += 1)
            {
                for (int ii = 0; ii < 12; ii++)
                {
                    points.Add(new Point(years_position_on_graph[x], ymax - appointments[3, ii]));
                    distanta = distanta + 30;
                }
            }
            points.Add(new Point(years_position_on_graph[10], ymax));

            Polyline polyline3 = new Polyline();
            polyline3.StrokeThickness = 3;
            polyline3.Stroke = brushes[3];
            polyline3.Points = points;

            statistics_graph.Children.Add(polyline3);//aici e o problema ca nu imi vede punctele pe care le vreau -- ani / appointments

////////////////////////////////
            //for (int x = 0; x <= 10; x += 1)
            //{
            for (int ii = 0; ii < 12; ii++)
            {
                points.Add(new Point(years_position_on_graph[4], ymax - appointments[4, ii]));
                distanta = distanta + 30;
            }
            //}
            points.Add(new Point(years_position_on_graph[10], ymax));

            Polyline polyline4 = new Polyline();
            polyline4.StrokeThickness = 3;
            polyline4.Stroke = brushes[4];
            polyline4.Points = points;

            statistics_graph.Children.Add(polyline4);//aici e o problema ca nu imi vede punctele pe care le vreau -- ani / appointments

/////////////////////////////////
            //for (int x = 0; x <= 10; x += 1)
            //{
            for (int ii = 0; ii < 12; ii++)
            {
                points.Add(new Point(years_position_on_graph[5], ymax - appointments[5, ii]));
                distanta = distanta + 30;
            }
            //}
            points.Add(new Point(years_position_on_graph[10], ymax));

            Polyline polyline5 = new Polyline();
            polyline5.StrokeThickness = 3;
            polyline5.Stroke = brushes[5];
            polyline5.Points = points;

            statistics_graph.Children.Add(polyline5);//aici e o problema ca nu imi vede punctele pe care le vreau -- ani / appointments

////////////////////////////////////////////
            //for (int x = 0; x <= 10; x += 1)
            //{
            for (int ii = 0; ii < 12; ii++)
            {
                points.Add(new Point(years_position_on_graph[6], ymax - appointments[6, ii]));
                distanta = distanta + 30;
            }
            //}
            points.Add(new Point(years_position_on_graph[10], ymax));

            Polyline polyline6 = new Polyline();
            polyline6.StrokeThickness = 3;
            polyline6.Stroke = brushes[6];
            polyline6.Points = points;

            statistics_graph.Children.Add(polyline6);//aici e o problema ca nu imi vede punctele pe care le vreau -- ani / appointments

///////////////////////////////////////////
            //for (int x = 0; x <= 10; x += 1)
            //{
            for (int ii = 0; ii < 12; ii++)
            {
                points.Add(new Point(years_position_on_graph[7], ymax - appointments[7, ii]));
                distanta = distanta + 30;
            }
            //}
            points.Add(new Point(years_position_on_graph[10], ymax));

            Polyline polyline7 = new Polyline();
            polyline7.StrokeThickness = 3;
            polyline7.Stroke = brushes[7];
            polyline7.Points = points;

            statistics_graph.Children.Add(polyline7);//aici e o problema ca nu imi vede punctele pe care le vreau -- ani / appointments

/////////////////////////////////////////




            /////////////////////////////////////

            var punct_label_y_axis = new Point(statistics_graph.ActualWidth - (statistics_graph.ActualWidth + 5), statistics_graph.ActualHeight / 2);
            var punct_label_x_axis = new Point(statistics_graph.ActualWidth / 2, statistics_graph.ActualHeight - 10);
            var font_size_text = 18;
            DrawText(statistics_graph, "nr. of appointments", punct_label_y_axis, angle_y, font_size_text, HorizontalAlignment.Left, VerticalAlignment.Center);
            DrawText(statistics_graph, "years", punct_label_x_axis, angle_x, font_size_text, HorizontalAlignment.Left, VerticalAlignment.Center);
            
        }
        public void show_graphic_2D_works_appointments_per_months(int[] years, int[] appointments)
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
            var month_position_on_graph = new double[12] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            var months_in_year = new string[12] {"Jan", "Feb", "Mar", "Apr", "May", "Jun","Jul", "Aug", "Sep", "Oct", "Nov", "Dec"};
            //delete all the graphs which are shown now on canvas
            delete_statistics_graphic();

            // Make the X axis.
            GeometryGroup xaxis_geom = new GeometryGroup();
            xaxis_geom.Children.Add(new LineGeometry(
                new Point(0, ymax), new Point(statistics_graph.Width, ymax)));
            for (double x = xmin + step_x;
                x <= statistics_graph.Width - step_x; x += step_x)
            {

                xaxis_geom.Children.Add(new LineGeometry(
                    new Point(x, ymax - margin / 2),
                    new Point(x, ymax + margin / 2)));
                var punct_mic_x = new Point(x, ymax + margin / 2 + 10);

                if (i <= 11)
                {
                    var text = months_in_year[i];
                    DrawText(statistics_graph, text, punct_mic_x, angle_x, font_size, HorizontalAlignment.Center, VerticalAlignment.Center);
                    month_position_on_graph[i] = x;//aici retin pozitia lunilor pe graficul afisat
                }
               
                i++;

            }

            Path xaxis_path = new Path();
            xaxis_path.StrokeThickness = 1;
            xaxis_path.Stroke = Brushes.Black;
            xaxis_path.Data = xaxis_geom;

            statistics_graph.Children.Add(xaxis_path);

            // Make the Y ayis. - l-am pus la final pebtru ca vreau sa fie scalat pentru appointments
            GeometryGroup yaxis_geom = new GeometryGroup();
            yaxis_geom.Children.Add(new LineGeometry(new Point(xmin, 20), new Point(xmin, statistics_graph.Height)));
            for (double y = step_y; y <= statistics_graph.Height - step_y; y += step_y)
            {
                yaxis_geom.Children.Add(new LineGeometry(
                    new Point(xmin - margin / 2, y - 4),
                    new Point(xmin + margin / 2, y - 4)));
                var punct_mic_y = new Point(xmin + margin / 2 - 15, y - 5);
                var text = (ymax - y + 4).ToString();
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
                    new Point(xmin + (20 * ii), 40), new Point(xmin + (20 * ii), statistics_graph.Height - 40)));
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
                    new Point(40, ymax - (step_y / 2 * jj)), new Point(statistics_graph.Width, ymax - (step_y / 2 * jj))));
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
            PointCollection points = new PointCollection();
            PointCollection points_green = new PointCollection();
               for (int x = 0; x <= 11; x++)
                {
                    points.Add(new Point(month_position_on_graph[x] - 4, ymax));
                    points.Add(new Point(month_position_on_graph[x], ymax - appointments[x]));
                    points.Add(new Point(month_position_on_graph[x] + 4, ymax));
                }
               
                               
            

            Polyline polyline = new Polyline();
            polyline.StrokeThickness = 5;
            polyline.Stroke = brushes[0];
            polyline.Points = points;
            
            statistics_graph.Children.Add(polyline);//aici e o problema ca nu imi vede punctele pe care le vreau -- ani / appointments
            

            var punct_label_y_axis = new Point(statistics_graph.ActualWidth - (statistics_graph.ActualWidth + 5), statistics_graph.ActualHeight / 2);
            var punct_label_x_axis = new Point(statistics_graph.ActualWidth / 2, statistics_graph.ActualHeight - 10);
            var font_size_text = 18;
            DrawText(statistics_graph, "nr. of appointments", punct_label_y_axis, angle_y, font_size_text, HorizontalAlignment.Left, VerticalAlignment.Center);
            DrawText(statistics_graph, "months", punct_label_x_axis, angle_x, font_size_text, HorizontalAlignment.Left, VerticalAlignment.Center);


            

        }
        public void show_graphic_2D_works_appointments_per_months_matrix(int[] years, int[,] appointments)
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
            var month_position_on_graph = new double[12] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            var months_in_year = new string[12] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
            //delete all the graphs which are shown now on canvas
            delete_statistics_graphic();

            // Make the X axis.
            GeometryGroup xaxis_geom = new GeometryGroup();
            xaxis_geom.Children.Add(new LineGeometry(
                new Point(0, ymax), new Point(statistics_graph.Width, ymax)));
            for (double x = xmin + step_x;
                x <= statistics_graph.Width - step_x; x += step_x)
            {

                xaxis_geom.Children.Add(new LineGeometry(
                    new Point(x, ymax - margin / 2),
                    new Point(x, ymax + margin / 2)));
                var punct_mic_x = new Point(x, ymax + margin / 2 + 10);

                if (i <= 11)
                {
                    var text = months_in_year[i];
                    DrawText(statistics_graph, text, punct_mic_x, angle_x, font_size, HorizontalAlignment.Center, VerticalAlignment.Center);
                    month_position_on_graph[i] = x;//aici retin pozitia lunilor pe graficul afisat
                }

                i++;

            }

            Path xaxis_path = new Path();
            xaxis_path.StrokeThickness = 1;
            xaxis_path.Stroke = Brushes.Black;
            xaxis_path.Data = xaxis_geom;

            statistics_graph.Children.Add(xaxis_path);

            // Make the Y ayis. - l-am pus la final pebtru ca vreau sa fie scalat pentru appointments
            GeometryGroup yaxis_geom = new GeometryGroup();
            yaxis_geom.Children.Add(new LineGeometry(new Point(xmin, 20), new Point(xmin, statistics_graph.Height)));
            for (double y = step_y; y <= statistics_graph.Height - step_y; y += step_y)
            {
                yaxis_geom.Children.Add(new LineGeometry(
                    new Point(xmin - margin / 2, y - 4),
                    new Point(xmin + margin / 2, y - 4)));
                var punct_mic_y = new Point(xmin + margin / 2 - 15, y - 5);
                var text = (ymax - y + 4).ToString();
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
                    new Point(xmin + (20 * ii), 40), new Point(xmin + (20 * ii), statistics_graph.Height - 40)));
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
                    new Point(40, ymax - (step_y / 2 * jj)), new Point(statistics_graph.Width, ymax - (step_y / 2 * jj))));
                Path xaxis_path_grid_ON = new Path();
                xaxis_path_grid_ON.StrokeThickness = 0.2;
                xaxis_path_grid_ON.Stroke = Brushes.Black;
                xaxis_path_grid_ON.Data = xaxis_geom_grid_ON;

                statistics_graph.Children.Add(xaxis_path_grid_ON);
            }

            //<--Make the grid ON on the graphic displayed
            

            // Make some data sets.
            Brush[] brushes = { Brushes.Red, Brushes.Green, Brushes.Blue,
                              Brushes.Yellow, Brushes.DarkMagenta, Brushes.LightCoral,
                              Brushes.SaddleBrown, Brushes.LavenderBlush, Brushes.Khaki,
                              Brushes.IndianRed, Brushes.Honeydew                          
                              };
            Random rand = new Random();
            PointCollection points = new PointCollection();
            PointCollection points_green = new PointCollection();
            for (int x = 0; x <= 11; x++)
            {
                for (int yy = 0; yy <= 10; yy++)
                {
                    points.Add(new Point(month_position_on_graph[x] - 4, ymax));
                    points.Add(new Point(month_position_on_graph[x], ymax - appointments[yy,x]));
                    points.Add(new Point(month_position_on_graph[x] + 4, ymax));    
                }

                Polyline polyline = new Polyline();
                polyline.StrokeThickness = 5;
                polyline.Stroke = brushes[0];
                polyline.Points = points;

                statistics_graph.Children.Add(polyline);//aici e o problema ca nu imi vede punctele pe care le vreau -- ani / appointments
                
            }

                 
            var punct_label_y_axis = new Point(statistics_graph.ActualWidth - (statistics_graph.ActualWidth + 5), statistics_graph.ActualHeight / 2);
            var punct_label_x_axis = new Point(statistics_graph.ActualWidth / 2, statistics_graph.ActualHeight - 10);
            var font_size_text = 18;
            DrawText(statistics_graph, "nr. of appointments", punct_label_y_axis, angle_y, font_size_text, HorizontalAlignment.Left, VerticalAlignment.Center);
            DrawText(statistics_graph, "months", punct_label_x_axis, angle_x, font_size_text, HorizontalAlignment.Left, VerticalAlignment.Center);




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

        //nars
        }
}