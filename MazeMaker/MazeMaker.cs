using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MazeMaker
{
    public partial class MazeMaker : Form
    {
        int w=20, h=20;
        public MazeMaker()
        {
            InitializeComponent();
            makeMaze(w,h);
        }

        public void makeMaze(int width, int height)
        {
            // dimensions of generated maze
    	    int r=width, c=height;

            char[,] maz = new char[r,c];
            for(int x = 0; x < r; x++) {
                for(int y = 0; y < c; y++){
                    maz[x,y] = '*';
                }
            }

            Random rand = new Random(DateTime.UtcNow.Millisecond);

            // select random point and open as start node
            Point st = new Point((int)(rand.Next(r)), (int)(rand.Next(c)), null);
            maz[st.r, st.c] = 'S';
 
            // iterate through direct neighbours of node
            List<Point> frontier = new List<Point>();
            for(int x=-1;x<=1;x++){
        	    for(int y=-1;y<=1;y++){
        		    if(x==0&&y==0||x!=0&&y!=0) //skip the starting point
        			    continue;
        		    try{
        			    if(maz[st.r+x, st.c+y]=='.') 
							continue;
        		    }catch(Exception e){ // ignore ArrayIndexOutOfBounds
        			    continue;
        		    }
					
        		    // add eligible points to frontier
        		    frontier.Add(new Point(st.r+x,st.c+y,st));
        	    }
			}
			
            Point last=null;
            while(frontier.Count>0){
        	    // pick current node at random
        	    Point cu = frontier[rand.Next(frontier.Count)];
                frontier.Remove(cu);
        	    Point op = cu.opposite();
        	    try{
        		    // if both node and its opposite are walls
        		    if(maz[cu.r, cu.c]=='*'){
        			    if(maz[op.r, op.c]=='*'){
 
        				    // open path between the nodes
        				    maz[cu.r, cu.c]='.';
        				    maz[op.r, op.c]='.';
 
        				    // store last node in order to mark it later
        				    last = op;
 
        				    // iterate through direct neighbours of node, same as earlier
        				    for(int x=-1;x<=1;x++)
				        	    for(int y=-1;y<=1;y++){
				        		    if(x==0&&y==0||x!=0&&y!=0)
				        			    continue;
				        		    try{
				        			    if(maz[op.r+x, op.c+y]=='.') continue;
				        		    }catch(Exception e){
				        			    continue;
				        		    }
				        		    frontier.Add(new Point(op.r+x,op.c+y,op));
				        	    }
        			    }
        		    }
        	    }catch(Exception e){ // ignore NullPointer and ArrayIndexOutOfBounds
        	    }
 
        	    // if algorithm has resolved, mark end node
        	    if(frontier.Count == 0)
        		    maz[last.r, last.c]='E';
            }

            printToLabel(maz, r, c);
            printToPicturebox(maz, r, c);
        }

        private void printToLabel(char[,] maz, int r, int c)
        {
            maze.Text = "";
            // print final maze as text
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    maze.Text += maz[i, j] + " ";
                }
                maze.Text += string.Format("{0}", Environment.NewLine);
            }
        }


        private void printToPicturebox(char[,] maz, int r, int c)
        {
            Bitmap drawArea = new Bitmap(mazeBox.Size.Width, mazeBox.Size.Height);
            mazeBox.Image = drawArea;
            // Create solid brush.
            SolidBrush blueBrush = new SolidBrush(Color.Blue);
            Graphics g = Graphics.FromImage(drawArea);
            //g.Clear(Color.Black);

            float width = 20.0F;
            float height = 20.0F;
            // print final maze
            for (int i = 0; i < r; i++){
                for (int j = 0; j < c; j++){
                    if (maz[i, j] == '*'){
                        g.FillRectangle(blueBrush, j*width, i*height, width, height);
                    } else if (maz[i, j] == 'S'){
                        Font drawFont = new Font("Arial", 16);
                        SolidBrush drawBrush = new SolidBrush(Color.White);
                        StringFormat drawFormat = new StringFormat();
                        // Draw string to screen.
                        g.DrawString("S", drawFont, drawBrush, j*width, i*height, drawFormat);
                    } else if (maz[i, j] == 'E'){
                        Font drawFont = new Font("Arial", 16);
                        SolidBrush drawBrush = new SolidBrush(Color.White);
                        StringFormat drawFormat = new StringFormat();
                        // Draw string to screen.
                        g.DrawString("E", drawFont, drawBrush, j * width, i * height, drawFormat);
                    }
                }
            }
        }

        private void redoButton_Click(object sender, EventArgs e)
        {
            makeMaze(w,h);
        }

    }

    class Point{
    	public int r, c;
    	public Point parent;
		
    	public Point(int x, int y, Point p){
    		r=x;
			c=y;
			parent=p;
    	}
    	// compute opposite node given that it is in the other direction from the parent
    	public Point opposite(){
    		if(this.r != parent.r)
    			return new Point(this.r+(this.r<parent.r?-1:0)+(this.r>parent.r?1:0),this.c,this);
    		if(this.c != parent.c)
    			return new Point(this.r,this.c+(this.c<parent.c?-1:0)+(this.c>parent.c?1:0),this);
    		return null;
    	}
    }
}
