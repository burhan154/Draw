using Draw.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Draw.ShapeManagement.EnumShapes;

namespace Draw.ShapeManagement
{
    class ShapeManager
    {
        private List<Shape> shapes = new List<Shape>();


        private SolidBrush brush = new SolidBrush(Color.Blue);
        private SolidBrush extbrush = new SolidBrush(Color.LightGray);
        private SolidBrush selectedBrush = new SolidBrush(Color.Gray);
        private bool isMouseDown = false;

        private Vector2 currentPosition;
        private Vector2 firstPoint;
        private EnumShape shape;

        private Shape selectedShape=null;

        private bool select=false;
        private bool selectShape = false;

        private void Screen(Graphics graphics)
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
                    //selectedShape = c;
                    if (c.isPointInside(currentPosition))
                    {
                        //isMouseDown = false;
                        if (select)
                        {
                            c.Select(graphics, extbrush, currentPosition);
                            if (selectShape)
                            {
                                selectedShape = c;
                                brush = c.Brush;
                                selectShape = false;
                            }   
                        }
                        else
                        {
                            //selectedShape = null;
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


        public void drawScreen(Graphics graphics, Vector2 firstPoint,Vector2 currentPosition )
        {
            this.currentPosition = currentPosition;
            this.firstPoint = firstPoint;

            //graphics.ClipBounds.Size;

            if (isMouseDown && !select)
            {
                //select = false;
                Shape newShape = CreateNewShape(shape, firstPoint, currentPosition, brush);
                newShape.Draw(graphics, extbrush);
            }
            Screen(graphics);
        }

        public void addActiveShape()
        {
            if(isMouseDown && !select)
                shapes.Add(CreateNewShape(shape, firstPoint, currentPosition, brush));
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
        public void setColor(Color color)
        {
            this.brush.Color = color;
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

        public string getShapes()
        {
            List<ShapeEntity> shapeEntities = new List<ShapeEntity>();
            var b = shapes.Select(x => x.shapeEntity);
            return JsonConvert.SerializeObject(b);
        }

        public void setShapes(string JSON)
        {
            List<ShapeEntity> shapeEntities = shapeEntities = JsonConvert.DeserializeObject<List<ShapeEntity>>(JSON); ;

            shapeEntities.ForEach(s => {
                shapes.Add(CreateNewShape(s));
            });
        }
    }
}
