using DxfService.Contracts;
using IxMilia.Dxf;
using IxMilia.Dxf.Entities;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Media;


namespace DxfService
{
    public class DxfService : IDxfSerrvice
    {
         
        public PathGeometry DxfToPathGeometry(string filePath)
        {
            var dxf = DxfFile.Load(filePath);
            var geometry = new PathGeometry();

            foreach (var entity in dxf.Entities)
            {
                switch (entity)
                {
                    case DxfLine line:
                        geometry.Figures.Add(LineToFigure(line));
                        break;

                    case DxfArc arc:
                        geometry.Figures.Add(ArcToFigure(arc));
                        break;

                    case DxfCircle circle:
                        geometry.Figures.Add(CircleToFigure(circle));
                        break;

                    case DxfLwPolyline lw:
                        geometry.Figures.Add(PolylineToFigure(lw));
                        break;
                }
            }

            return geometry;
        }
        private PathFigure LineToFigure(DxfLine line)
        {
            return new PathFigure
            {
                StartPoint = new System.Windows.Point(line.P1.X, line.P1.Y),
                Segments =
                {
                    new LineSegment(
                        new System.Windows.Point(line.P2.X, line.P2.Y),
                        true)
                },
                IsClosed = false
            };
        }
        private PathFigure ArcToFigure(DxfArc arc)
        {
            double startRad = arc.StartAngle * Math.PI / 180.0;
            double endRad = arc.EndAngle * Math.PI / 180.0;

            System.Windows.Point start = new System.Windows.Point(
                arc.Center.X + arc.Radius * Math.Cos(startRad),
                arc.Center.Y + arc.Radius * Math.Sin(startRad));

            System.Windows.Point end = new System.Windows.Point(
                arc.Center.X + arc.Radius * Math.Cos(endRad),
                arc.Center.Y + arc.Radius * Math.Sin(endRad));

            bool isLargeArc = Math.Abs(arc.EndAngle - arc.StartAngle) > 180;

            return new PathFigure
            {
                StartPoint = start,
                Segments =
        {
            new ArcSegment
            {
                Point = end,
                Size = new System.Windows.Size(arc.Radius, arc.Radius),
                IsLargeArc = isLargeArc,
                SweepDirection = SweepDirection.Counterclockwise,
                IsStroked = true
            }
        },
                IsClosed = false
            };
        }
        private PathFigure CircleToFigure(DxfCircle c)
        {
            System.Windows.Point start = new System.Windows.Point(c.Center.X + c.Radius, c.Center.Y);

            var fig = new PathFigure { StartPoint = start, IsClosed = true };

            fig.Segments.Add(new ArcSegment(
                new System.Windows.Point(c.Center.X - c.Radius, c.Center.Y),
                new System.Windows.Size(c.Radius, c.Radius),
                0,
                false,
                SweepDirection.Counterclockwise,
                true));

            fig.Segments.Add(new ArcSegment(
                start,
                new System.Windows.Size(c.Radius, c.Radius),
                0,
                false,
                SweepDirection.Counterclockwise,
                true));

            return fig;
        }

        private PathFigure PolylineToFigure(DxfLwPolyline pl)
        {
            var points = pl.Vertices
                .Select(v => new System.Windows.Point(v.X, v.Y))
                .ToList();

            return new PathFigure
            {
                StartPoint = points[0],
                Segments =
        {
            new PolyLineSegment(points.Skip(1), true)
        },
                IsClosed = pl.IsClosed
            };
        }

    }
}
