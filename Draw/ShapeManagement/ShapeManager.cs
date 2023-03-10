using Draw.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Draw.ShapeManagement.EnumShapes;

namespace Draw.ShapeManagement
{
    class ShapeManager
    {
        private List<Shape> shapes = new List<Shape>();
        private ShapeCreator shapeCreator = new ShapeCreator();

        private SolidBrush brush;
        private SolidBrush extbrush = new SolidBrush(Color.LightGray);
        private SolidBrush selectedBrush = new SolidBrush(Color.Gray);
        private bool isMouseDown = false;
        private Graphics graphics;
        private Vector2 currentPosition;
        private Vector2 firstPoint;
        private EnumShape shape;
        private Shape newShape;
        private Shape selectedShape=null;
        private EnumShape activeShape;
        private bool select=false;
        private bool selectShape = false;

        public void setGraphics(Graphics graphics)
        {
            this.graphics = graphics;
        }

        private void Screen()
        {
            if (shapes.Count > 0)
            {
                if (selectedShape != null && select)
                {
                    selectedShape.Select(graphics, selectedBrush, currentPosition);
                    selectedShape.Brush = brush;
                }
                foreach (Shape c in shapes)
                {
                    if (c.isPointInside(currentPosition))
                    {
                        if (select)
                        {
                            c.Select(graphics, extbrush, currentPosition);
                            if (selectShape)
                            {
                                selectedShape = c;
                                brush = c.Brush;
                                selectShape = false;
                                activeShape = selectedShape.shapeEntity.shape;
                            }   
                        }
                    }
                    c.Draw(graphics);
                }
                if (selectedShape != null && select)
                {
                    if (isMouseDown)
                    {
                        selectedShape.Move(currentPosition);
                        selectedShape.Draw(graphics);

                    }
                }
            }
        } 


        public void drawScreen( Vector2 firstPoint,Vector2 currentPosition )
        {
            this.currentPosition = currentPosition;
            this.firstPoint = firstPoint;

            if (isMouseDown && !select && brush!=null)
            {
                newShape = shapeCreator.CreateNewShape(shape, firstPoint, currentPosition, brush);
                if(newShape !=null)
                    newShape.Draw(graphics, extbrush);
            }
            Screen();
        }

        public void addActiveShape()
        {
            if(isMouseDown && !select && brush != null && newShape != null)
                shapes.Add(newShape);
            isMouseDown = false;
        }

        public void drawNewShape()
        {
            isMouseDown = true;
            if (select)
            {
                selectShape = true;
            }
        }

        public void setShape(EnumShape enumShape)
        {
            this.shape = enumShape;
        }

        public EnumShape getShape()
        {
            return activeShape;
        }

        public void setColor(Color color)
        {
            if (this.brush == null)
                brush = new SolidBrush(color);
            this.brush.Color = color;
        }
        public Color getColor()
        {
           if(brush!=null)
            return this.brush.Color;
           return new Color();
        }
        public void Select()
        {
            if (select)
                selectedShape = null;
            select = !select;
        }
        public void Remove()
        {
            shapes.Remove(selectedShape);
        }
        public void Clear()
        {
            shapes.Clear();
        }
        public void SaveShapes()
        {
            Files.Save(getShapes());
        }
        public void OpenShapes()
        {
            setShapes(Files.Open());
        }

        private string getShapes()
        {
            List<ShapeEntity> shapeEntities = new List<ShapeEntity>();
            var b = shapes.Select(x => x.shapeEntity);
            return JsonConvert.SerializeObject(b);
        }

        private void setShapes(string JSON)
        {
            List<ShapeEntity> shapeEntities = shapeEntities = JsonConvert.DeserializeObject<List<ShapeEntity>>(JSON); ;

            shapeEntities.ForEach(s => {
                shapes.Add(shapeCreator.CreateNewShape(s));
            });
        }
    }
}
